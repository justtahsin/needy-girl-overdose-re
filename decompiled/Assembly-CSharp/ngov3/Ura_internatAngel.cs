using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace ngov3;

public class Ura_internatAngel : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__0 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ura_internatAngel _003C_003E4__this;

		public CancellationToken cancellationToken;

		private void MoveNext()
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Ura_internatAngel ura_internatAngel = _003C_003E4__this;
			try
			{
				((NgoEvent)ura_internatAngel).startEvent(cancellationToken);
				SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
				SingletonMonoBehaviour<EventManager>.Instance.alpha = AlphaType.Angel;
				SingletonMonoBehaviour<EventManager>.Instance.alphaLevel = 6;
				SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
				SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Action_HaishinStart>();
				ura_internatAngel.endEvent();
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
