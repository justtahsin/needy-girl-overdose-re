using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class TenchanView : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CPlayAnim_003Ed__36 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public string name;

		public TenchanView _003C_003E4__this;

		private string _003CcurrentClipName_003E5__2;

		private string _003CoverrideClipName_003E5__3;

		private Awaiter<AnimationClip> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			TenchanView tenchanView = _003C_003E4__this;
			try
			{
				Awaiter<AnimationClip> val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<AnimationClip>);
					num = (_003C_003E1__state = -1);
					goto IL_01be;
				}
				if (name != null && name.Length > 1)
				{
					if ((Object)(object)tenchanView.overrideController == (Object)null)
					{
						tenchanView.overrideController = new AnimatorOverrideController();
						tenchanView.overrideController.runtimeAnimatorController = tenchanView._animator.runtimeAnimatorController;
						tenchanView._animator.runtimeAnimatorController = (RuntimeAnimatorController)(object)tenchanView.overrideController;
					}
					tenchanView._currentAnim = name;
					AnimatorStateInfo currentAnimatorStateInfo = tenchanView._animator.GetCurrentAnimatorStateInfo(0);
					_003CcurrentClipName_003E5__2 = "";
					_003CoverrideClipName_003E5__3 = "";
					if (((AnimatorStateInfo)(ref currentAnimatorStateInfo)).IsName(tenchanView.overrideClipName_1))
					{
						_003CcurrentClipName_003E5__2 = tenchanView.overrideClipName_1;
						_003CoverrideClipName_003E5__3 = tenchanView.overrideClipName_0;
					}
					else
					{
						_003CcurrentClipName_003E5__2 = tenchanView.overrideClipName_0;
						_003CoverrideClipName_003E5__3 = tenchanView.overrideClipName_1;
					}
					if (tenchanView._animationCancelSource != null)
					{
						tenchanView._animationCancelSource.Cancel();
					}
					if (!(name == "stream_cho_akaruku"))
					{
						tenchanView._animationCancelSource = new CancellationTokenSource();
						val = LoadLiveViewData.LoadAnimation(name + ".anim", tenchanView._animationCancelSource.Token).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<AnimationClip>, _003CPlayAnim_003Ed__36>(ref val, ref this);
							return;
						}
						goto IL_01be;
					}
					tenchanView.overrideController[_003CoverrideClipName_003E5__3] = tenchanView.akarukuClip;
					tenchanView._animator.Play(_003CoverrideClipName_003E5__3, 0, 0f);
					tenchanView._animationCancelSource = null;
				}
				goto end_IL_000e;
				IL_01be:
				AnimationClip result = val.GetResult();
				if (_003CcurrentClipName_003E5__2 == "stream_cho_akaruku.anim" || !((Motion)result).isLooping || !((Object)(object)tenchanView.overrideController[_003CcurrentClipName_003E5__2] == (Object)(object)result))
				{
					tenchanView.overrideController[_003CoverrideClipName_003E5__3] = result;
					tenchanView._animator.Play(_003CoverrideClipName_003E5__3, 0, 0f);
					tenchanView._animationCancelSource = null;
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
		if (!((Object)(object)_noChair == (Object)null))
		{
			_noChair.SetActive(SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) < 11 || (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Hnahaisin && SingletonMonoBehaviour<EventManager>.Instance.alphaLevel == 4) || (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.ASMR && SingletonMonoBehaviour<EventManager>.Instance.alphaLevel == 5) || SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Angel);
		}
	}

	private void Start()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(_currentAnim))
		{
			PlayAnim("stream_cho_akaruku");
		}
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Pair<KeyValuePair<string, int>>>(Observable.Pairwise<KeyValuePair<string, int>>((IObservable<KeyValuePair<string, int>>)OnAnimOneShot), (Action<Pair<KeyValuePair<string, int>>>)async delegate(Pair<KeyValuePair<string, int>> anim)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			string pre = _currentAnim;
			KeyValuePair<string, int> current = anim.Current;
			PlayAnim(current.Key);
			await UniTask.Delay(current.Value, false, (PlayerLoopTiming)8, default(CancellationToken), false);
			PlayAnim(pre);
		}), ((Component)this).gameObject);
	}

	private void OnExittedAnim(AnimatorStateInfo state)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (!isStopAtEnd)
		{
			PlayAnim(CurrentAnim);
		}
	}

	[AsyncStateMachine(typeof(_003CPlayAnim_003Ed__36))]
	public UniTask PlayAnim(string name)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CPlayAnim_003Ed__36 _003CPlayAnim_003Ed__37 = default(_003CPlayAnim_003Ed__36);
		_003CPlayAnim_003Ed__37._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CPlayAnim_003Ed__37._003C_003E4__this = this;
		_003CPlayAnim_003Ed__37.name = name;
		_003CPlayAnim_003Ed__37._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CPlayAnim_003Ed__37._003C_003Et__builder)).Start<_003CPlayAnim_003Ed__36>(ref _003CPlayAnim_003Ed__37);
		return ((AsyncUniTaskMethodBuilder)(ref _003CPlayAnim_003Ed__37._003C_003Et__builder)).Task;
	}

	public void PlayAnimOneShot(string name)
	{
		isStopAtEnd = false;
		_animator.speed = 1f;
		_animator.Play(name);
	}

	public void HideGirl()
	{
		if (!((Object)(object)_girl == (Object)null))
		{
			((Behaviour)_girl).enabled = false;
		}
	}

	public void OnEndStream()
	{
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Meta && SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_KowaiInternet && SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Kyouso && SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Grand && SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Sucide && SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Ginga)
		{
			if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_DarkAngel)
			{
				((Component)SingletonMonoBehaviour<EventManager>.Instance.cover).gameObject.SetActive(true);
				((Component)((Component)SingletonMonoBehaviour<EventManager>.Instance.cover).transform.GetChild(0)).gameObject.SetActive(true);
			}
			else if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Yami && SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.JP)
			{
				((Behaviour)_animator).enabled = false;
				((Component)_view).gameObject.SetActive(true);
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
		((Behaviour)_animator).enabled = false;
		((Component)_view).gameObject.SetActive(true);
		_view.sprite = _endView;
		LoadLiveViewData.DeleteAllCache();
		liveEnd = true;
	}

	public void ReWindEndView()
	{
		liveEnd = false;
		((Behaviour)_animator).enabled = true;
		((Component)_view).gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		LoadLiveViewData.DeleteAllCache();
	}
}
