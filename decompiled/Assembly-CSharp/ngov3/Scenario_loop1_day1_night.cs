using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace ngov3;

public class Scenario_loop1_day1_night : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__0 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Scenario_loop1_day1_night _003C_003E4__this;

		public CancellationToken cancellationToken;

		private void MoveNext()
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Scenario_loop1_day1_night scenario_loop1_day1_night = _003C_003E4__this;
			try
			{
				((NgoEvent)scenario_loop1_day1_night).startEvent(cancellationToken);
				SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tutorial_night);
				scenario_loop1_day1_night.endEvent();
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

	[AsyncStateMachine(typeof(_003CstartEvent_003Ed__0))]
	public override UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CstartEvent_003Ed__0 _003CstartEvent_003Ed__1 = default(_003CstartEvent_003Ed__0);
		_003CstartEvent_003Ed__1._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartEvent_003Ed__1._003C_003E4__this = this;
		_003CstartEvent_003Ed__1.cancellationToken = cancellationToken;
		_003CstartEvent_003Ed__1._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__1._003C_003Et__builder)).Start<_003CstartEvent_003Ed__0>(ref _003CstartEvent_003Ed__1);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__1._003C_003Et__builder)).Task;
	}
}
