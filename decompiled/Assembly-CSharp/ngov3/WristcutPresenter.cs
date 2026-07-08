using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UniRx;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(WristcutView))]
public sealed class WristcutPresenter : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003COnStartWristcutGame_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public WristcutPresenter _003C_003E4__this;

		private object _003C_003Eu__1;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			WristcutPresenter wristcutPresenter = _003C_003E4__this;
			try
			{
				AsyncSubject<Cut> val;
				if (num != 0)
				{
					int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
					wristcutPresenter._model = new WristcutModel(status);
					wristcutPresenter._view.OnStartGame(status, wristcutPresenter._model.CutCount);
					DisposableExtensions.AddTo<IDisposable>(wristcutPresenter._view.OnGoButton.Subscribe((IObserver<Cut>)wristcutPresenter._model.OnCut), ((Component)wristcutPresenter).gameObject);
					val = Observable.GetAwaiter<Cut>(wristcutPresenter._view.OnGoButton);
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitOnCompleted<AsyncSubject<Cut>, _003COnStartWristcutGame_003Ed__3>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = (AsyncSubject<Cut>)_003C_003Eu__1;
					_003C_003Eu__1 = null;
					num = (_003C_003E1__state = -1);
				}
				val.GetResult();
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

	private WristcutModel _model;

	private WristcutView _view;

	public void Awake()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		_view = ((Component)this).GetComponent<WristcutView>();
		UniTaskExtensions.Forget(OnStartWristcutGame());
	}

	[AsyncStateMachine(typeof(_003COnStartWristcutGame_003Ed__3))]
	public UniTask OnStartWristcutGame()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003COnStartWristcutGame_003Ed__3 _003COnStartWristcutGame_003Ed__4 = default(_003COnStartWristcutGame_003Ed__3);
		_003COnStartWristcutGame_003Ed__4._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003COnStartWristcutGame_003Ed__4._003C_003E4__this = this;
		_003COnStartWristcutGame_003Ed__4._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003COnStartWristcutGame_003Ed__4._003C_003Et__builder)).Start<_003COnStartWristcutGame_003Ed__3>(ref _003COnStartWristcutGame_003Ed__4);
		return ((AsyncUniTaskMethodBuilder)(ref _003COnStartWristcutGame_003Ed__4._003C_003Et__builder)).Task;
	}
}
