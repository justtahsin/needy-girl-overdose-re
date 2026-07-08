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

public class Scenario_loop1_day1_day : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Scenario_loop1_day1_day _003C_003E4__this;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0356: Unknown result type (might be due to invalid IL or missing references)
			//IL_035b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0362: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_031b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0320: Unknown result type (might be due to invalid IL or missing references)
			//IL_0323: Unknown result type (might be due to invalid IL or missing references)
			//IL_0328: Unknown result type (might be due to invalid IL or missing references)
			//IL_0382: Unknown result type (might be due to invalid IL or missing references)
			//IL_0387: Unknown result type (might be due to invalid IL or missing references)
			//IL_038a: Unknown result type (might be due to invalid IL or missing references)
			//IL_038f: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_033c: Unknown result type (might be due to invalid IL or missing references)
			//IL_033d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Scenario_loop1_day1_day CS_0024_003C_003E8__locals4 = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					((NgoEvent)CS_0024_003C_003E8__locals4).startEvent(cancellationToken);
					val2 = NgoEvent.DelaySkippable(Constants.MIDDLE);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_00a0;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00a0;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0107;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_016e;
				case 3:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01d5;
				case 4:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_023c;
				case 5:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02a3;
				case 6:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_030a;
				case 7:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0371;
				case 8:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0371:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE008);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 8);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					break;
					IL_00a0:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE001);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_0107;
					IL_023c:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE005);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_02a3;
					IL_0107:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE002);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_016e;
					IL_030a:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE007);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 7);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_0371;
					IL_016e:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE003);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_01d5;
					IL_02a3:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE006);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_030a;
					IL_01d5:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE004);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_023c;
				}
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Day1_JINE008_Option001 });
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Day1_JINE008_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE009);
					await NgoEvent.DelaySkippable(Constants.MIDDLE);
					SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = false;
					SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: true);
					SingletonMonoBehaviour<WebCamManager>.Instance.RandomizeAmeAnimation();
					SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tooltip_firstStamp);
					SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
					DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.responseType == ResponseType.Stamp && x.Value.user == JineUserType.pi)), (Action<CollectionAddEvent<JineData>>)delegate
					{
						SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
						SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tooltip_day2);
						CS_0024_003C_003E8__locals4.endEvent();
					}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals4.compositeDisposable);
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals4.compositeDisposable);
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
