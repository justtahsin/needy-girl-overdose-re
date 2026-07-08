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

public class Event_Kurorekishi : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CConsumerStartEvent_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Event_Kurorekishi _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Event_Kurorekishi CS_0024_003C_003E8__locals11 = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
					UniTask val = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi001);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CConsumerStartEvent_003Ed__3>(ref val2, ref this);
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
					JineType.Event_Kurorekisi001_Option001,
					JineType.Event_Kurorekisi001_Option002,
					JineType.Event_Kurorekisi001_Option003
				});
				CS_0024_003C_003E8__locals11._disposable = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi001_Option001 || x.Value.id == JineType.Event_Kurorekisi001_Option002 || x.Value.id == JineType.Event_Kurorekisi001_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi002);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi003);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi004);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi005);
					CS_0024_003C_003E8__locals11._disposable.Dispose();
					SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
					{
						JineType.Event_Kurorekisi005_Option001,
						JineType.Event_Kurorekisi005_Option002,
						JineType.Event_Kurorekisi005_Option003
					});
					CS_0024_003C_003E8__locals11._disposable = ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi005_Option001 || x.Value.id == JineType.Event_Kurorekisi005_Option002 || x.Value.id == JineType.Event_Kurorekisi005_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
					{
						CS_0024_003C_003E8__locals11._disposable.Dispose();
						await NgoEvent.DelaySkippable(Constants.FAST);
						await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi006);
						await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi007);
						await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi008);
						await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi009);
						SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
						{
							JineType.Event_Kurorekisi009_Option001,
							JineType.Event_Kurorekisi009_Option002,
							JineType.Event_Kurorekisi009_Option003
						});
						DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi009_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
						{
							await NgoEvent.DelaySkippable(Constants.FAST);
							await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi010);
							SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
							CS_0024_003C_003E8__locals11.endEvent();
						}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals11.compositeDisposable);
						DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi009_Option002)), (Action<CollectionAddEvent<JineData>>)async delegate
						{
							await NgoEvent.DelaySkippable(Constants.FAST);
							await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi011);
							await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi012);
							SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
							CS_0024_003C_003E8__locals11.endEvent();
						}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals11.compositeDisposable);
						DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi009_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
						{
							await NgoEvent.DelaySkippable(Constants.FAST);
							await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi013);
							await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi014);
							SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
							CS_0024_003C_003E8__locals11.endEvent();
						}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals11.compositeDisposable);
					});
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals11.compositeDisposable);
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
	private struct _003CstartEvent_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Event_Kurorekishi _003C_003E4__this;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Event_Kurorekishi CS_0024_003C_003E8__locals11 = _003C_003E4__this;
			try
			{
				Awaiter val;
				switch (num)
				{
				default:
				{
					((NgoEvent)CS_0024_003C_003E8__locals11).startEvent(cancellationToken);
					SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
					UniTask val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi001);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__2>(ref val, ref this);
						return;
					}
					break;
				}
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					((Awaiter)(ref val)).GetResult();
					goto end_IL_000e;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					break;
				}
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
				CS_0024_003C_003E8__locals11._disposable = ObservableExtensions.Subscribe<string>((IObservable<string>)SingletonMonoBehaviour<JineManager>.Instance.Message, (Action<string>)async delegate(string m)
				{
					SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, m));
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi002);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi003);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi004);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi005);
					CS_0024_003C_003E8__locals11._disposable.Dispose();
					SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
					CS_0024_003C_003E8__locals11._disposable = ObservableExtensions.Subscribe<string>((IObservable<string>)SingletonMonoBehaviour<JineManager>.Instance.Message, (Action<string>)async delegate(string n)
					{
						SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, n));
						CS_0024_003C_003E8__locals11._disposable.Dispose();
						await NgoEvent.DelaySkippable(Constants.FAST);
						await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi006);
						await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi007);
						await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi008);
						await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi009);
						SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
						{
							JineType.Event_Kurorekisi009_Option001,
							JineType.Event_Kurorekisi009_Option002,
							JineType.Event_Kurorekisi009_Option003
						});
						DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi009_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
						{
							await NgoEvent.DelaySkippable(Constants.FAST);
							await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi010);
							SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
							CS_0024_003C_003E8__locals11.endEvent();
						}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals11.compositeDisposable);
						DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi009_Option002)), (Action<CollectionAddEvent<JineData>>)async delegate
						{
							await NgoEvent.DelaySkippable(Constants.FAST);
							await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi011);
							await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi012);
							SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
							CS_0024_003C_003E8__locals11.endEvent();
						}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals11.compositeDisposable);
						DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi009_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
						{
							await NgoEvent.DelaySkippable(Constants.FAST);
							await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi013);
							await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi014);
							SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
							CS_0024_003C_003E8__locals11.endEvent();
						}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals11.compositeDisposable);
					});
				});
				end_IL_000e:;
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

	[AsyncStateMachine(typeof(_003CConsumerStartEvent_003Ed__3))]
	private UniTask ConsumerStartEvent()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CConsumerStartEvent_003Ed__3 _003CConsumerStartEvent_003Ed__4 = default(_003CConsumerStartEvent_003Ed__3);
		_003CConsumerStartEvent_003Ed__4._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CConsumerStartEvent_003Ed__4._003C_003E4__this = this;
		_003CConsumerStartEvent_003Ed__4._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CConsumerStartEvent_003Ed__4._003C_003Et__builder)).Start<_003CConsumerStartEvent_003Ed__3>(ref _003CConsumerStartEvent_003Ed__4);
		return ((AsyncUniTaskMethodBuilder)(ref _003CConsumerStartEvent_003Ed__4._003C_003Et__builder)).Task;
	}
}
