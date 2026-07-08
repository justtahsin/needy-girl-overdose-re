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

namespace ngov3;

public class Event_NextDate : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Event_NextDate _003C_003E4__this;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Event_NextDate CS_0024_003C_003E8__locals7 = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					((NgoEvent)CS_0024_003C_003E8__locals7).startEvent(cancellationToken);
					SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
					UniTask val = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate001);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val2, ref this);
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
				SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
				{
					JineType.Event_NextDate001_Option001,
					JineType.Event_NextDate001_Option002,
					JineType.Event_NextDate001_Option003
				});
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_NextDate001_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate002);
					SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
					CS_0024_003C_003E8__locals7.eventContinue1();
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals7.compositeDisposable);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_NextDate001_Option002)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate003);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate004);
					SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
					CS_0024_003C_003E8__locals7.eventContinue1();
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals7.compositeDisposable);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_NextDate001_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate005);
					SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
					CS_0024_003C_003E8__locals7.eventContinue1();
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals7.compositeDisposable);
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
		type = EventType.Event_Advice;
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

	private async void eventContinue1()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate006);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_NextDate006_Optuion001,
			JineType.Event_NextDate006_Optuion002,
			JineType.Event_NextDate006_Optuion003
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_NextDate006_Optuion001)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate007);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate008);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			eventContinue2();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_NextDate006_Optuion002)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate009);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate010);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			eventContinue2();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_NextDate006_Optuion003)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate011);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			eventContinue2();
		}), (ICollection<IDisposable>)compositeDisposable);
	}

	private async void eventContinue2()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate012);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_NextDate012_Option001,
			JineType.Event_NextDate012_Option002,
			JineType.Event_NextDate012_Option003
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_NextDate012_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Love, 1);
			eventContinue3();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_NextDate012_Option002)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Love, 1);
			eventContinue3();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_NextDate012_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Love, 1);
			eventContinue3();
		}), (ICollection<IDisposable>)compositeDisposable);
	}

	private async void eventContinue3()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate013);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_NextDate013_Optuin001,
			JineType.Event_NextDate013_Optuin001,
			JineType.Event_NextDate013_Optuin001
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_NextDate013_Optuin001)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_NextDate014);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Love, 1);
			endEvent();
		}), (ICollection<IDisposable>)compositeDisposable);
	}
}
