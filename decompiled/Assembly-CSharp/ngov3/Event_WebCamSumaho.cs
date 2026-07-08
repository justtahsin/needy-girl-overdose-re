using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

namespace ngov3;

public class Event_WebCamSumaho : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003COnLooking_003Ed__0 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public int looking;

		public Event_WebCamSumaho _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Event_WebCamSumaho event_WebCamSumaho = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
					UniTask val = UniTask.Delay(looking, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnLooking_003Ed__0>(ref val2, ref this);
						return;
					}
				}
				else
				{
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val2)).GetResult();
				event_WebCamSumaho.OnBlur();
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartLooking_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		private void MoveNext()
		{
			try
			{
				SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
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

	[AsyncStateMachine(typeof(_003COnLooking_003Ed__0))]
	public UniTask OnLooking(int looking = 2000)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003COnLooking_003Ed__0 _003COnLooking_003Ed__1 = default(_003COnLooking_003Ed__0);
		_003COnLooking_003Ed__1._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003COnLooking_003Ed__1._003C_003E4__this = this;
		_003COnLooking_003Ed__1.looking = looking;
		_003COnLooking_003Ed__1._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003COnLooking_003Ed__1._003C_003Et__builder)).Start<_003COnLooking_003Ed__0>(ref _003COnLooking_003Ed__1);
		return ((AsyncUniTaskMethodBuilder)(ref _003COnLooking_003Ed__1._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CStartLooking_003Ed__1))]
	public UniTask StartLooking()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_003CStartLooking_003Ed__1 _003CStartLooking_003Ed__2 = default(_003CStartLooking_003Ed__1);
		_003CStartLooking_003Ed__2._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CStartLooking_003Ed__2._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CStartLooking_003Ed__2._003C_003Et__builder)).Start<_003CStartLooking_003Ed__1>(ref _003CStartLooking_003Ed__2);
		return ((AsyncUniTaskMethodBuilder)(ref _003CStartLooking_003Ed__2._003C_003Et__builder)).Task;
	}

	public void OnBlur()
	{
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayCurrentAnim();
	}
}
