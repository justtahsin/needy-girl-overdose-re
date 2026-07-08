using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UniRx;
using UnityEngine;

namespace ngov3;

public class Action_HaishinEnd : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Action_HaishinEnd _003C_003E4__this;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Action_HaishinEnd action_HaishinEnd = _003C_003E4__this;
			try
			{
				Awaiter val;
				UniTask val2;
				if (num != 0)
				{
					if (num == 1)
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01f0;
					}
					((NgoEvent)action_HaishinEnd).startEvent(cancellationToken);
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Broadcast);
					CmdType cmdType = SingletonMonoBehaviour<CommandManager>.Instance.ChooseCommand(ActionType.Haishin);
					SingletonMonoBehaviour<EventManager>.Instance.executingAction = cmdType;
					SingletonMonoBehaviour<EventManager>.Instance.ApplyStatus(cmdType);
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
					action_HaishinEnd.tweetFromTip(SingletonMonoBehaviour<EventManager>.Instance.alpha, SingletonMonoBehaviour<EventManager>.Instance.alphaLevel);
					SingletonMonoBehaviour<EventManager>.Instance.setActionHistory($"{SingletonMonoBehaviour<EventManager>.Instance.alpha}_{SingletonMonoBehaviour<EventManager>.Instance.alphaLevel}");
					new CancellationTokenSource();
					if (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count > 0)
					{
						SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
					}
					SingletonMonoBehaviour<EventManager>.Instance.Aim.Value = "はいしん";
					SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.TaskManager));
					val2 = SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__6>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val)).GetResult();
				if (((Transform)SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent).childCount > 0)
				{
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Jine);
					val2 = NgoEvent.DelaySkippable(((Transform)SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent).childCount * Constants.MIDDLE);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__6>(ref val, ref this);
						return;
					}
					goto IL_01f0;
				}
				goto IL_01f7;
				IL_01f0:
				((Awaiter)(ref val)).GetResult();
				goto IL_01f7;
				IL_01f7:
				SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, Vector2.zero, (CursorMode)0);
				SingletonMonoBehaviour<EventManager>.Instance.TimePass();
				SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = false;
				action_HaishinEnd.endEvent();
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

	private IDisposable CancelToken = (IDisposable)new SingleAssignmentDisposable();

	private IDisposable token1 = (IDisposable)new SingleAssignmentDisposable();

	private IDisposable token2 = (IDisposable)new SingleAssignmentDisposable();

	private IDisposable token3 = (IDisposable)new SingleAssignmentDisposable();

	private ReactiveProperty<bool> isCleaned = new ReactiveProperty<bool>(true);

	protected override void Awake()
	{
		base.Awake();
	}

	[AsyncStateMachine(typeof(_003CstartEvent_003Ed__6))]
	public override UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CstartEvent_003Ed__6 _003CstartEvent_003Ed__7 = default(_003CstartEvent_003Ed__6);
		_003CstartEvent_003Ed__7._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartEvent_003Ed__7._003C_003E4__this = this;
		_003CstartEvent_003Ed__7.cancellationToken = cancellationToken;
		_003CstartEvent_003Ed__7._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__7._003C_003Et__builder)).Start<_003CstartEvent_003Ed__6>(ref _003CstartEvent_003Ed__7);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__7._003C_003Et__builder)).Task;
	}

	private bool checkCleaned()
	{
		if (((Transform)SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent).childCount == 0 && ((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count == 0)
		{
			return SingletonMonoBehaviour<EventManager>.Instance.eventQueue.Count == 0;
		}
		return false;
	}
}
