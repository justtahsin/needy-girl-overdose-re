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

namespace ngov3;

public class Event_Okusan : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Event_Okusan _003C_003E4__this;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Event_Okusan CS_0024_003C_003E8__locals10 = _003C_003E4__this;
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
						goto IL_010b;
					}
					((NgoEvent)CS_0024_003C_003E8__locals10).startEvent(cancellationToken);
					SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
					SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan001);
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
				val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan002);
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
					return;
				}
				goto IL_010b;
				IL_010b:
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
				{
					JineType.Event_Okusan002_Option1,
					JineType.Event_Okusan002_Option2,
					JineType.Event_Okusan002_Option3
				});
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Okusan002_Option1)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan004);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan005);
					DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>(ObserveExtensions.ObserveEveryValueChanged<NotificationManager, int>(SingletonMonoBehaviour<NotificationManager>.Instance, (Func<NotificationManager, int>)((NotificationManager notificationManager) => ((Transform)SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent).childCount), (FrameCountType)0, false), (Func<int, bool>)((int v) => v == 0)), (Action<int>)async delegate
					{
						await NgoEvent.DelaySkippable(Constants.MIDDLE);
						SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
						IWindow w = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.GoOut);
						SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(w);
						CS_0024_003C_003E8__locals10.endEvent();
					}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals10.compositeDisposable);
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals10.compositeDisposable);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Okusan002_Option2)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan007);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan008);
					DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>(ObserveExtensions.ObserveEveryValueChanged<NotificationManager, int>(SingletonMonoBehaviour<NotificationManager>.Instance, (Func<NotificationManager, int>)((NotificationManager notificationManager) => ((Transform)SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent).childCount), (FrameCountType)0, false), (Func<int, bool>)((int v) => v == 0)), (Action<int>)async delegate
					{
						await NgoEvent.DelaySkippable(Constants.MIDDLE);
						await SingletonMonoBehaviour<EventManager>.Instance.ExecuteActionConfirmed(ActionType.PlayIchatuku, CmdType.PlayIchatukuIchatuku, isEventCommand: true);
						CS_0024_003C_003E8__locals10.endEvent();
					}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals10.compositeDisposable);
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals10.compositeDisposable);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Okusan002_Option3)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan010);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan011);
					DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>(ObserveExtensions.ObserveEveryValueChanged<NotificationManager, int>(SingletonMonoBehaviour<NotificationManager>.Instance, (Func<NotificationManager, int>)((NotificationManager notificationManager) => ((Transform)SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent).childCount), (FrameCountType)0, false), (Func<int, bool>)((int v) => v == 0)), (Action<int>)async delegate
					{
						await NgoEvent.DelaySkippable(Constants.MIDDLE);
						await SingletonMonoBehaviour<EventManager>.Instance.ExecuteActionConfirmed(ActionType.PlayMakeLove, CmdType.PlayMakeLove, isEventCommand: true);
						await UniTask.Delay(4500, false, (PlayerLoopTiming)8, default(CancellationToken), false);
						CS_0024_003C_003E8__locals10.endEvent();
					}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals10.compositeDisposable);
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals10.compositeDisposable);
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
