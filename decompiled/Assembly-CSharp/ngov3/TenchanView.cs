using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class TenchanView : MonoBehaviour
{
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private Image _view;

	[SerializeField]
	private Image _girl;

	protected NeedyGirlAnimatorBehavior _needyBehavior;

	[SerializeField]
	public Image _backGround;

	[SerializeField]
	public GameObject _noChair;

	[SerializeField]
	public Sprite background_no_shield;

	[SerializeField]
	public Sprite background_silver_shield;

	[SerializeField]
	public Sprite background_gold_shield;

	[SerializeField]
	public Sprite background_kinen1;

	[SerializeField]
	public Sprite background_kinen2;

	[SerializeField]
	public Sprite background_kinen3;

	[SerializeField]
	public Sprite background_kinen4;

	[SerializeField]
	public Sprite background_kinen5;

	[SerializeField]
	public Sprite _background_horror;

	[SerializeField]
	public Sprite _background_kyouso;

	[SerializeField]
	public Sprite _background_happy;

	[SerializeField]
	public Sprite _background_ntr;

	[SerializeField]
	public Sprite _background_sayonara1;

	[SerializeField]
	public Sprite _background_sayonara2;

	[SerializeField]
	private Sprite _endView;

	[SerializeField]
	private Sprite _uchikiri;

	[SerializeField]
	private AnimationClip akarukuClip;

	private float prevSpeed;

	public BehaviorSubject<KeyValuePair<string, int>> OnAnimOneShot = new BehaviorSubject<KeyValuePair<string, int>>(new KeyValuePair<string, int>("stream_ame_idle", 1000));

	private string _currentAnim;

	private bool isStopAtEnd;

	private string overrideClipName_0 = "Clip0";

	private string overrideClipName_1 = "Clip1";

	private AnimatorOverrideController overrideController;

	private CancellationTokenSource _animationCancelSource;

	private bool liveEnd;

	public string CurrentAnim => _currentAnim;

	public bool LiveEnd => liveEnd;

	private void Awake()
	{
		_needyBehavior = _animator.GetBehaviour<NeedyGirlAnimatorBehavior>();
		if (!(_noChair == null))
		{
			_noChair.SetActive(SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) < 11 || (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Hnahaisin && SingletonMonoBehaviour<EventManager>.Instance.alphaLevel == 4) || (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.ASMR && SingletonMonoBehaviour<EventManager>.Instance.alphaLevel == 5) || SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Angel);
		}
	}

	private void Start()
	{
		if (string.IsNullOrEmpty(_currentAnim))
		{
			PlayAnim("stream_cho_akaruku");
		}
		OnAnimOneShot.Pairwise().Subscribe(async delegate(Pair<KeyValuePair<string, int>> anim)
		{
			string pre = _currentAnim;
			KeyValuePair<string, int> current = anim.Current;
			PlayAnim(current.Key);
			await UniTask.Delay(current.Value);
			PlayAnim(pre);
		}).AddTo(base.gameObject);
	}

	private void OnExittedAnim(AnimatorStateInfo state)
	{
		if (!isStopAtEnd)
		{
			PlayAnim(CurrentAnim);
		}
	}

	public async UniTask PlayAnim(string name)
	{
		if (name == null || name.Length <= 1)
		{
			return;
		}
		if (overrideController == null)
		{
			overrideController = new AnimatorOverrideController();
			overrideController.runtimeAnimatorController = _animator.runtimeAnimatorController;
			_animator.runtimeAnimatorController = overrideController;
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
		if (_animationCancelSource != null)
		{
			_animationCancelSource.Cancel();
		}
		if (name == "stream_cho_akaruku")
		{
			overrideController[overrideClipName] = akarukuClip;
			_animator.Play(overrideClipName, 0, 0f);
			_animationCancelSource = null;
			return;
		}
		_animationCancelSource = new CancellationTokenSource();
		AnimationClip animationClip = await LoadLiveViewData.LoadAnimation(name + ".anim", _animationCancelSource.Token);
		if (currentClipName == "stream_cho_akaruku.anim" || !animationClip.isLooping || !(overrideController[currentClipName] == animationClip))
		{
			overrideController[overrideClipName] = animationClip;
			_animator.Play(overrideClipName, 0, 0f);
			_animationCancelSource = null;
		}
	}

	public void PlayAnimOneShot(string name)
	{
		isStopAtEnd = false;
		_animator.speed = 1f;
		_animator.Play(name);
	}

	public void HideGirl()
	{
		if (!(_girl == null))
		{
			_girl.enabled = false;
		}
	}

	public void OnEndStream()
	{
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Meta && SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_KowaiInternet && SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Kyouso && SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Grand && SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Sucide && SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Ginga)
		{
			if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_DarkAngel)
			{
				SingletonMonoBehaviour<EventManager>.Instance.cover.gameObject.SetActive(value: true);
				SingletonMonoBehaviour<EventManager>.Instance.cover.transform.GetChild(0).gameObject.SetActive(value: true);
			}
			else if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Yami && SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.JP)
			{
				_animator.enabled = false;
				_view.gameObject.SetActive(value: true);
				_view.sprite = _uchikiri;
			}
			else
			{
				ShowEndView();
			}
		}
	}

	public void ShowEndView()
	{
		AudioManager.Instance.PlaySeByType(SoundType.SE_endHaishin);
		_animator.enabled = false;
		_view.gameObject.SetActive(value: true);
		_view.sprite = _endView;
		LoadLiveViewData.DeleteAllCache();
		liveEnd = true;
	}

	public void ReWindEndView()
	{
		liveEnd = false;
		_animator.enabled = true;
		_view.gameObject.SetActive(value: false);
	}

	private void OnDestroy()
	{
		LoadLiveViewData.DeleteAllCache();
	}
}
