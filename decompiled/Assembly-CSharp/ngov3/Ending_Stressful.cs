using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UniRx;

namespace ngov3;

public class Ending_Stressful : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Stressful _003C_003E4__this;

		public CancellationToken cancellationToken;

		private void MoveNext()
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			Ending_Stressful CS_0024_003C_003E8__locals5 = _003C_003E4__this;
			try
			{
				((NgoEvent)CS_0024_003C_003E8__locals5).startEvent(cancellationToken);
				AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_kincho);
				SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Stressful;
				SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
				SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
				SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Stressful_Tweet001);
				SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Stressful_Tweet002);
				SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Stressful_Tweet003);
				SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
				SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Poketter).Maximize();
				SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Poketter).Uncloseable();
				SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
				CS_0024_003C_003E8__locals5._disposable = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Take<int>(Observable.Where<int>(ObserveExtensions.ObserveEveryValueChanged<PoketterManager, int>(SingletonMonoBehaviour<PoketterManager>.Instance, (Func<PoketterManager, int>)((PoketterManager pktr) => ((Collection<TweetData>)(object)pktr._tweetQueue).Count), (FrameCountType)0, false), (Func<int, bool>)((int count) => count == 0)), 1), (Action<int>)async delegate
				{
					CS_0024_003C_003E8__locals5._disposable.Dispose();
					await NgoEvent.DelaySkippable(Constants.MIDDLE);
					PostEffectManager.Instance.SetShader(EffectType.Noisy);
					SingletonMonoBehaviour<PoketterManager>.Instance.isDeleted.SetValueAndForceNotify(true);
					PostEffectManager.Instance.ResetShaderCalmly();
					await NgoEvent.DelaySkippable(Constants.SLOW);
					AchievementStatsUpdater.UpdateStats("Ending_Stressful");
					SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
					CS_0024_003C_003E8__locals5.endEvent();
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals5.compositeDisposable);
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

	private IDisposable _disposable;

	protected override void Awake()
	{
		base.Awake();
	}

	[AsyncStateMachine(typeof(_003CstartEvent_003Ed__2))]
	public override UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CstartEvent_003Ed__2 _003CstartEvent_003Ed__3 = default(_003CstartEvent_003Ed__2);
		_003CstartEvent_003Ed__3._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartEvent_003Ed__3._003C_003E4__this = this;
		_003CstartEvent_003Ed__3.cancellationToken = cancellationToken;
		_003CstartEvent_003Ed__3._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__3._003C_003Et__builder)).Start<_003CstartEvent_003Ed__2>(ref _003CstartEvent_003Ed__3);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__3._003C_003Et__builder)).Task;
	}
}
