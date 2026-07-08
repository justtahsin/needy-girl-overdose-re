using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class App_Webcam : MonoBehaviour
{
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private NeedyGirlAnimatorBehavior _needyBehavior;

	private Button _button;

	private Image _view;

	[SerializeField]
	private Image _girl;

	[SerializeField]
	private GameObject _Ame;

	[SerializeField]
	public Amehead AmeHead;

	public BehaviorSubject<KeyValuePair<string, int>> OnAnimOneShot = new BehaviorSubject<KeyValuePair<string, int>>(new KeyValuePair<string, int>("stream_ame_idle", 1000));

	[SerializeField]
	private Image _backGround;

	[SerializeField]
	private Sprite background_no_shield;

	[SerializeField]
	private Sprite background_silver_shield;

	[SerializeField]
	private Sprite background_gold_shield;

	[SerializeField]
	private Sprite _background_happy;

	[SerializeField]
	public GameObject _noChair;

	[SerializeField]
	public GameObject _screenSaver;

	[SerializeField]
	private Image _screenSaverImage;

	[SerializeField]
	private Sprite _screenSaver1;

	[SerializeField]
	private Sprite _screenSaver2;

	[SerializeField]
	private Sprite _screenSaver3;

	private string _currentAnim;

	private bool isPlaying;

	private string overrideClipName_0 = "Clip0";

	private string overrideClipName_1 = "Clip1";

	private AnimatorOverrideController overrideController;

	public string CurrentAnim => _currentAnim;

	private void Awake()
	{
		_needyBehavior = _animator.GetBehaviour<NeedyGirlAnimatorBehavior>();
		_button = GetComponent<Button>();
		_view = GetComponent<Image>();
		SingletonMonoBehaviour<WebCamManager>.Instance.hidegirl.Subscribe(delegate(bool isHide)
		{
			HideGirl(isHide);
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<WebCamManager>.Instance._currentAnim.Subscribe(delegate(string anim)
		{
			PlayAnim(anim);
		}).AddTo(base.gameObject);
		OnAnimOneShot.Where((KeyValuePair<string, int> anim) => anim.Key != "stream_ame_h_heart" || anim.Key != "stream_ame_out_e").Pairwise().Subscribe(async delegate(Pair<KeyValuePair<string, int>> anim)
		{
			string pre = _currentAnim;
			KeyValuePair<string, int> current = anim.Current;
			PlayAnimOneShot(current.Key);
			await UniTask.Delay(current.Value);
			PlayAnim(pre);
		})
			.AddTo(base.gameObject);
		_needyBehavior.OnStateExitAsObservable().Subscribe(delegate
		{
			OnExittedAnim(CurrentAnim);
		}).AddTo(base.gameObject);
	}

	private void Start()
	{
		SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex).Subscribe(delegate
		{
			bgView();
		}).AddTo(base.gameObject);
		overrideController = new AnimatorOverrideController();
		overrideController.runtimeAnimatorController = _animator.runtimeAnimatorController;
		_animator.runtimeAnimatorController = overrideController;
	}

	private void bgView()
	{
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
		_noChair.SetActive(status2 < 11);
		if (status > 100000 && status2 > 14)
		{
			_backGround.sprite = background_silver_shield;
		}
		if (status > 1000000 && status2 > 27)
		{
			_backGround.sprite = background_gold_shield;
		}
		_screenSaver.SetActive(SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_None && !SingletonMonoBehaviour<EventManager>.Instance.isHorror);
		switch (Random.Range(0, 3))
		{
		case 0:
			_screenSaverImage.sprite = _screenSaver1;
			break;
		case 1:
			_screenSaverImage.sprite = _screenSaver2;
			break;
		default:
			_screenSaverImage.sprite = _screenSaver3;
			break;
		}
	}

	public void Nade()
	{
		if (!SingletonMonoBehaviour<EventManager>.Instance.isHorror && !(CurrentAnim == "stream_ame_h_heart") && !SingletonMonoBehaviour<WebCamManager>.Instance.hidegirl.Value && !CurrentAnim.StartsWith("stream_ame_out_"))
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_nadenade_1);
			if (!CurrentAnim.StartsWith("stream_ame_hair_"))
			{
				SingletonMonoBehaviour<WebCamManager>.Instance.happy();
			}
		}
	}

	private void OnExittedAnim(string animName)
	{
		if (!(animName == "stream_ame_h_heart") && animName == "stream_ame_handspinner1")
		{
			PlayAnim("stream_ame_handspinner2");
		}
	}

	private void OnExittedOneShot(AnimatorStateInfo state)
	{
		state.IsName("stream_ame_h_heart");
	}

	public async UniTask Yusayusa()
	{
		_currentAnim = "";
		RectTransform target = _backGround.gameObject.transform as RectTransform;
		await DOTween.Sequence().AppendCallback(delegate
		{
			PlayAnim("stream_ame_h_heart");
		}).Append(target.DOAnchorPosY(-10f, 0.19999999f, snapping: true))
			.AppendCallback(delegate
			{
				AudioManager.Instance.PlaySeByType(SoundType.SE_piyo);
				SingletonMonoBehaviour<VibrationInputManager>.Instance.Vibrate(0.1f, 0.5f, 25f, 0.25f, 50f);
			})
			.Append(target.DOAnchorPosY(10f, 0.19999999f, snapping: true))
			.SetRelative()
			.SetLoops(8)
			.Play();
	}

	public async UniTask PlayAnim(string name)
	{
		if (name == null || name.Length <= 1)
		{
			return;
		}
		_currentAnim = name;
		string currentClipName;
		string overrideClipName;
		if (_animator.GetCurrentAnimatorStateInfo(0).IsName(overrideClipName_1))
		{
			currentClipName = overrideClipName_1;
			overrideClipName = overrideClipName_0;
		}
		else
		{
			currentClipName = overrideClipName_0;
			overrideClipName = overrideClipName_1;
		}
		AnimationClip animationClip = await LoadWebcamData.LoadAnimation(name + ".anim");
		if (!animationClip.isLooping || !(overrideController[currentClipName] == animationClip))
		{
			overrideController[overrideClipName] = animationClip;
			if (_animator != null)
			{
				_animator?.Play(overrideClipName, 0, 0f);
			}
		}
	}

	public void PlayAnimOneShot(string name)
	{
		_animator.Play(name);
	}

	public void HideGirl(bool onoff)
	{
		if (!(_Ame == null))
		{
			_Ame.SetActive(!onoff);
		}
	}
}
