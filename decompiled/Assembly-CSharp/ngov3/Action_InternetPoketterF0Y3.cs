using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;

namespace ngov3;

public class Action_InternetPoketterF0Y3 : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Action_InternetPoketterF0Y3 _003C_003E4__this;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Action_InternetPoketterF0Y3 action_InternetPoketterF0Y = _003C_003E4__this;
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
						goto IL_00ff;
					}
					action_InternetPoketterF0Y.startEvent(cancellationToken, skipWatchSp: true);
					SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_egosearching");
					val2 = NgoEvent.DelaySkippable(Constants.MIDDLE);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
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
				SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.EgosaResult);
				val2 = NgoEvent.DelaySkippable(Constants.SLOW * 3);
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
					return;
				}
				goto IL_00ff;
				IL_00ff:
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Tweet_egosa, CommandResult.success));
				action_InternetPoketterF0Y.endEvent();
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

	protected override void Awake()
	{
		base.Awake();
	}

	[AsyncStateMachine(typeof(_003CstartEvent_003Ed__1))]
	public override UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CstartEvent_003Ed__1 _003CstartEvent_003Ed__2 = default(_003CstartEvent_003Ed__1);
		_003CstartEvent_003Ed__2._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartEvent_003Ed__2._003C_003E4__this = this;
		_003CstartEvent_003Ed__2.cancellationToken = cancellationToken;
		_003CstartEvent_003Ed__2._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__2._003C_003Et__builder)).Start<_003CstartEvent_003Ed__1>(ref _003CstartEvent_003Ed__2);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__2._003C_003Et__builder)).Task;
	}
}
