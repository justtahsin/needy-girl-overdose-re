using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using NGO;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class App_Webcam : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<KeyValuePair<string, int>, bool> _003C_003E9__26_2;

		public static TweenCallback _003C_003E9__32_1;

		internal bool _003CAwake_003Eb__26_2(KeyValuePair<string, int> anim)
		{
			if (!(anim.Key != "stream_ame_h_heart"))
			{
				return anim.Key != "stream_ame_out_e";
			}
			return true;
		}

		internal void _003CYusayusa_003Eb__32_1()
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_piyo);
			SingletonMonoBehaviour<VibrationInputManager>.Instance.Vibrate(0.1f, 0.5f, 25f, 0.25f, 50f);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CPlayAnim_003Ed__33 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public string name;

		public App_Webcam _003C_003E4__this;

		private string _003CcurrentClipName_003E5__2;

		private string _003CoverrideClipName_003E5__3;

		private Awaiter<AnimationClip> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			App_Webcam app_Webcam = _003C_003E4__this;
			try
			{
				Awaiter<AnimationClip> val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<AnimationClip>);
					num = (_003C_003E1__state = -1);
					goto IL_0109;
				}
				if (name != null && name.Length > 1)
				{
					app_Webcam._currentAnim = name;
					AnimatorStateInfo currentAnimatorStateInfo = app_Webcam._animator.GetCurrentAnimatorStateInfo(0);
					_003CcurrentClipName_003E5__2 = "";
					_003CoverrideClipName_003E5__3 = "";
					if (((AnimatorStateInfo)(ref currentAnimatorStateInfo)).IsName(app_Webcam.overrideClipName_1))
					{
						_003CcurrentClipName_003E5__2 = app_Webcam.overrideClipName_1;
						_003CoverrideClipName_003E5__3 = app_Webcam.overrideClipName_0;
					}
					else
					{
						_003CcurrentClipName_003E5__2 = app_Webcam.overrideClipName_0;
						_003CoverrideClipName_003E5__3 = app_Webcam.overrideClipName_1;
					}
					val = LoadWebcamData.LoadAnimation(name + ".anim").GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<AnimationClip>, _003CPlayAnim_003Ed__33>(ref val, ref this);
						return;
					}
					goto IL_0109;
				}
				goto end_IL_000e;
				IL_0109:
				AnimationClip result = val.GetResult();
				if (!((Motion)result).isLooping || !((Object)(object)app_Webcam.overrideController[_003CcurrentClipName_003E5__2] == (Object)(object)result))
				{
					app_Webcam.overrideController[_003CoverrideClipName_003E5__3] = result;
					if ((Object)(object)app_Webcam._animator != (Object)null)
					{
						Animator animator = app_Webcam._animator;
						if (animator != null)
						{
							animator.Play(_003CoverrideClipName_003E5__3, 0, 0f);
						}
					}
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003CcurrentClipName_003E5__2 = null;
				_003CoverrideClipName_003E5__3 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CcurrentClipName_003E5__2 = null;
			_003CoverrideClipName_003E5__3 = null;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CYusayusa_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public App_Webcam _003C_003E4__this;

		private TweenAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected O, but got Unknown
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			App_Webcam CS_0024_003C_003E8__locals3 = _003C_003E4__this;
			try
			{
				TweenAwaiter val3;
				if (num != 0)
				{
					CS_0024_003C_003E8__locals3._currentAnim = "";
					Transform transform = ((Component)CS_0024_003C_003E8__locals3._backGround).gameObject.transform;
					RectTransform val = (RectTransform)(object)((transform is RectTransform) ? transform : null);
					Sequence obj = TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(DOTween.Sequence(), (TweenCallback)delegate
					{
						//IL_0006: Unknown result type (might be due to invalid IL or missing references)
						CS_0024_003C_003E8__locals3.PlayAnim("stream_ame_h_heart");
					}), (Tween)(object)DOTweenModuleUI.DOAnchorPosY(val, -10f, 0.19999999f, true));
					object obj2 = _003C_003Ec._003C_003E9__32_1;
					if (obj2 == null)
					{
						TweenCallback val2 = delegate
						{
							AudioManager.Instance.PlaySeByType(SoundType.SE_piyo);
							SingletonMonoBehaviour<VibrationInputManager>.Instance.Vibrate(0.1f, 0.5f, 25f, 0.25f, 50f);
						};
						_003C_003Ec._003C_003E9__32_1 = val2;
						obj2 = (object)val2;
					}
					val3 = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<Sequence>(TweenSettingsExtensions.SetLoops<Sequence>(TweenSettingsExtensions.SetRelative<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(obj, (TweenCallback)obj2), (Tween)(object)DOTweenModuleUI.DOAnchorPosY(val, 10f, 0.19999999f, true))), 8)));
					if (!((TweenAwaiter)(ref val3)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val3;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CYusayusa_003Ed__32>(ref val3, ref this);
						return;
					}
				}
				else
				{
					val3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TweenAwaiter)(ref val3)).GetResult();
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

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
		_button = ((Component)this).GetComponent<Button>();
		_view = ((Component)this).GetComponent<Image>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>((IObservable<bool>)SingletonMonoBehaviour<WebCamManager>.Instance.hidegirl, (Action<bool>)delegate(bool isHide)
		{
			HideGirl(isHide);
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<string>((IObservable<string>)SingletonMonoBehaviour<WebCamManager>.Instance._currentAnim, (Action<string>)delegate(string anim)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			PlayAnim(anim);
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Pair<KeyValuePair<string, int>>>(Observable.Pairwise<KeyValuePair<string, int>>(Observable.Where<KeyValuePair<string, int>>((IObservable<KeyValuePair<string, int>>)OnAnimOneShot, (Func<KeyValuePair<string, int>, bool>)((KeyValuePair<string, int> anim) => anim.Key != "stream_ame_h_heart" || anim.Key != "stream_ame_out_e"))), (Action<Pair<KeyValuePair<string, int>>>)async delegate(Pair<KeyValuePair<string, int>> anim)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			string pre = _currentAnim;
			KeyValuePair<string, int> current = anim.Current;
			PlayAnimOneShot(current.Key);
			await UniTask.Delay(current.Value, false, (PlayerLoopTiming)8, default(CancellationToken), false);
			PlayAnim(pre);
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<OnStateInfo>(((ObservableStateMachineTrigger)_needyBehavior).OnStateExitAsObservable(), (Action<OnStateInfo>)delegate
		{
			OnExittedAnim(CurrentAnim);
		}), ((Component)this).gameObject);
	}

	private void Start()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex), (Action<int>)delegate
		{
			bgView();
		}), ((Component)this).gameObject);
		overrideController = new AnimatorOverrideController();
		overrideController.runtimeAnimatorController = _animator.runtimeAnimatorController;
		_animator.runtimeAnimatorController = (RuntimeAnimatorController)(object)overrideController;
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
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (!(animName == "stream_ame_h_heart") && animName == "stream_ame_handspinner1")
		{
			PlayAnim("stream_ame_handspinner2");
		}
	}

	private void OnExittedOneShot(AnimatorStateInfo state)
	{
		((AnimatorStateInfo)(ref state)).IsName("stream_ame_h_heart");
	}

	[AsyncStateMachine(typeof(_003CYusayusa_003Ed__32))]
	public UniTask Yusayusa()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CYusayusa_003Ed__32 _003CYusayusa_003Ed__33 = default(_003CYusayusa_003Ed__32);
		_003CYusayusa_003Ed__33._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CYusayusa_003Ed__33._003C_003E4__this = this;
		_003CYusayusa_003Ed__33._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CYusayusa_003Ed__33._003C_003Et__builder)).Start<_003CYusayusa_003Ed__32>(ref _003CYusayusa_003Ed__33);
		return ((AsyncUniTaskMethodBuilder)(ref _003CYusayusa_003Ed__33._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CPlayAnim_003Ed__33))]
	public UniTask PlayAnim(string name)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CPlayAnim_003Ed__33 _003CPlayAnim_003Ed__34 = default(_003CPlayAnim_003Ed__33);
		_003CPlayAnim_003Ed__34._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CPlayAnim_003Ed__34._003C_003E4__this = this;
		_003CPlayAnim_003Ed__34.name = name;
		_003CPlayAnim_003Ed__34._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CPlayAnim_003Ed__34._003C_003Et__builder)).Start<_003CPlayAnim_003Ed__33>(ref _003CPlayAnim_003Ed__34);
		return ((AsyncUniTaskMethodBuilder)(ref _003CPlayAnim_003Ed__34._003C_003Et__builder)).Task;
	}

	public void PlayAnimOneShot(string name)
	{
		_animator.Play(name);
	}

	public void HideGirl(bool onoff)
	{
		if (!((Object)(object)_Ame == (Object)null))
		{
			_Ame.SetActive(!onoff);
		}
	}
}
