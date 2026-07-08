using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UnityEngine;

namespace ngov3;

public class Event_Uzagarami_Dokuhaku : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Event_Uzagarami_Dokuhaku _003C_003E4__this;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Event_Uzagarami_Dokuhaku event_Uzagarami_Dokuhaku = _003C_003E4__this;
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
						goto IL_0141;
					}
					((NgoEvent)event_Uzagarami_Dokuhaku).startEvent(cancellationToken);
					if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) >= 60)
					{
						event_Uzagarami_Dokuhaku.endEvent();
					}
					event_Uzagarami_Dokuhaku.eventName = event_Uzagarami_Dokuhaku.getUniqueUzagaramiId();
					if (!event_Uzagarami_Dokuhaku.eventName.StartsWith("LineWeekDay"))
					{
						SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue(event_Uzagarami_Dokuhaku.eventName);
						goto IL_0164;
					}
					SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory((JineType)Enum.Parse(typeof(JineType), event_Uzagarami_Dokuhaku.eventName));
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__3>(ref val, ref this);
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
				val2 = NgoEvent.DelaySkippable(Constants.MIDDLE);
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__3>(ref val, ref this);
					return;
				}
				goto IL_0141;
				IL_0164:
				event_Uzagarami_Dokuhaku.endEvent();
				goto end_IL_000e;
				IL_0141:
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
				goto IL_0164;
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

	private static List<string> UzagaramiAll()
	{
		List<string> list = new List<string>();
		for (int i = 3; i <= 152; i++)
		{
			string item = "LineWeekDay" + $"{i:D3}";
			list.Add(item);
		}
		return list;
	}

	protected override void Awake()
	{
		base.Awake();
	}

	private string getUniqueUzagaramiId()
	{
		IEnumerable<string> source = UzagaramiAll().Except(SingletonMonoBehaviour<EventManager>.Instance.eventsHistory);
		if (source.Count() == 0)
		{
			return "Event_tekiTalk";
		}
		return source.ElementAt(Random.Range(0, source.Count()));
	}

	[AsyncStateMachine(typeof(_003CstartEvent_003Ed__3))]
	public override UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CstartEvent_003Ed__3 _003CstartEvent_003Ed__4 = default(_003CstartEvent_003Ed__3);
		_003CstartEvent_003Ed__4._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartEvent_003Ed__4._003C_003E4__this = this;
		_003CstartEvent_003Ed__4.cancellationToken = cancellationToken;
		_003CstartEvent_003Ed__4._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__4._003C_003Et__builder)).Start<_003CstartEvent_003Ed__3>(ref _003CstartEvent_003Ed__4);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__4._003C_003Et__builder)).Task;
	}
}
