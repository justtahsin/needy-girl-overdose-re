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
using UniRx;
using UnityEngine;

namespace ngov3;

public class EventTekitouhenji : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EventTekitouhenji _003C_003E4__this;

		private void MoveNext()
		{
			EventTekitouhenji CS_0024_003C_003E8__locals14 = _003C_003E4__this;
			try
			{
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.RepeatUntilDestroy<int>(Observable.FirstOrDefault<int>(Observable.Throttle<int>(Observable.Scan<int, int>(Observable.Select<CollectionAddEvent<JineData>, int>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.responseType == ResponseType.Stamp && x.Value.user == JineUserType.pi)), (Func<CollectionAddEvent<JineData>, int>)((CollectionAddEvent<JineData> _) => 1)), 0, (Func<int, int, int>)((int element, int acc) => element + acc)), TimeSpan.FromSeconds(1.5))), (Component)(object)CS_0024_003C_003E8__locals14), (Action<int>)async delegate(int counter)
				{
					if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_None && !SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) < 80 && counter < 4 && SingletonMonoBehaviour<JineManager>.Instance.history.Last().responseType == ResponseType.Stamp && SingletonMonoBehaviour<JineManager>.Instance.history.Last().user == JineUserType.pi && Random.Range(0, 100) > 20)
					{
						List<JineData> rawdatas = SingletonMonoBehaviour<JineManager>.Instance.history.Last().stampType switch
						{
							StampType.OK => CS_0024_003C_003E8__locals14.ok, 
							StampType.Saikouka => CS_0024_003C_003E8__locals14.saikouka, 
							StampType.Pien => CS_0024_003C_003E8__locals14.pien, 
							StampType.Waritodoudemoii => CS_0024_003C_003E8__locals14.waritodoudemoii, 
							StampType.Gomen => CS_0024_003C_003E8__locals14.gomen, 
							StampType.Bujisibou => CS_0024_003C_003E8__locals14.bujisibou, 
							StampType.Love => CS_0024_003C_003E8__locals14.love, 
							_ => CS_0024_003C_003E8__locals14.sorena, 
						};
						rawdatas.AddRange(CS_0024_003C_003E8__locals14.amestamps);
						await UniTask.Delay(400, false, (PlayerLoopTiming)8, default(CancellationToken), false);
						SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(rawdatas[Random.Range(0, rawdatas.Count)]);
					}
				}), ((Component)CS_0024_003C_003E8__locals14).gameObject);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.RepeatUntilDestroy<int>(Observable.FirstOrDefault<int>(Observable.Throttle<int>(Observable.Scan<int, int>(Observable.Select<CollectionAddEvent<JineData>, int>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.responseType == ResponseType.Stamp && x.Value.user == JineUserType.pi)), (Func<CollectionAddEvent<JineData>, int>)((CollectionAddEvent<JineData> _) => 1)), 0, (Func<int, int, int>)((int element, int acc) => element + acc)), TimeSpan.FromSeconds(1.5))), (Component)(object)CS_0024_003C_003E8__locals14), (Action<int>)async delegate(int counter)
				{
					if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_None && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) < 80 && counter >= 4)
					{
						await UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
						List<JineData> rendasuruna = CS_0024_003C_003E8__locals14.rendasuruna;
						SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(rendasuruna[Random.Range(0, rendasuruna.Count)]);
					}
				}), ((Component)CS_0024_003C_003E8__locals14).gameObject);
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

	private const int AMERESPONSEPERCENTAGE = 20;

	private const int AMERESPONSEMILLISECOND = 400;

	private StampType lastStamp;

	private List<JineData> amestamps = new List<JineData>
	{
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.AmeStamp_ame),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.AmeStamp_aseru),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.AmeStamp_imajudori),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.AmeStamp_kanzennakyuutai),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.AmeStamp_kawaikunai),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.AmeStamp_kiitenai),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.AmeStamp_toketeiru),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.AmeStamp_zzz)
	};

	private List<JineData> waritodoudemoii = new List<JineData>
	{
		new JineData(JineType.Jine_Reply_doudemoii_1),
		new JineData(JineType.Jine_Reply_doudemoii_2),
		new JineData(JineType.Jine_Reply_doudemoii_3),
		new JineData(JineType.Jine_Reply_doudemoii_4),
		new JineData(JineType.Jine_Reply_doudemoii_5),
		new JineData(JineType.Jine_Reply_doudemoii_6),
		new JineData(JineType.Jine_Reply_doudemoii_7),
		new JineData(JineType.doudemoii_add1),
		new JineData(JineType.doudemoii_add2),
		new JineData(JineType.doudemoii_add3),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Sorena),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Waritodoudemoii)
	};

	private List<JineData> sorena = new List<JineData>
	{
		new JineData(JineType.Jine_Reply_sorena_1),
		new JineData(JineType.Jine_Reply_sorena_2),
		new JineData(JineType.Jine_Reply_sorena_3),
		new JineData(JineType.Jine_Reply_sorena_4),
		new JineData(JineType.Jine_Reply_sorena_5),
		new JineData(JineType.Jine_Reply_sorena_6),
		new JineData(JineType.sorena_add1),
		new JineData(JineType.sorena_add2),
		new JineData(JineType.sorena_add3),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Sorena),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Waritodoudemoii)
	};

	private List<JineData> saikouka = new List<JineData>
	{
		new JineData(JineType.Jine_Reply_saikouka_1),
		new JineData(JineType.Jine_Reply_saikouka_2),
		new JineData(JineType.Jine_Reply_saikouka_3),
		new JineData(JineType.Jine_Reply_saikouka_4),
		new JineData(JineType.Jine_Reply_saikouka_5),
		new JineData(JineType.Jine_Reply_saikouka_6),
		new JineData(JineType.Jine_Reply_saikouka_7),
		new JineData(JineType.saikouka_add1),
		new JineData(JineType.saikouka_add2),
		new JineData(JineType.saikouka_add3),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.OK),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Saikouka),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Love)
	};

	private List<JineData> pien = new List<JineData>
	{
		new JineData(JineType.Jine_Reply_pien_1),
		new JineData(JineType.Jine_Reply_pien_2),
		new JineData(JineType.Jine_Reply_pien_3),
		new JineData(JineType.Jine_Reply_pien_4),
		new JineData(JineType.Jine_Reply_pien_5),
		new JineData(JineType.Jine_Reply_pien_6),
		new JineData(JineType.Jine_Reply_pien_7),
		new JineData(JineType.pien_add1),
		new JineData(JineType.pien_add2),
		new JineData(JineType.pien_add3),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Bujisibou),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Gomen),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Pien)
	};

	private List<JineData> ok = new List<JineData>
	{
		new JineData(JineType.Jine_Reply_ok_1),
		new JineData(JineType.Jine_Reply_ok_2),
		new JineData(JineType.Jine_Reply_ok_3),
		new JineData(JineType.Jine_Reply_ok_4),
		new JineData(JineType.Jine_Reply_ok_5),
		new JineData(JineType.Jine_Reply_ok_6),
		new JineData(JineType.Jine_Reply_ok_7),
		new JineData(JineType.ok_add1),
		new JineData(JineType.ok_add2),
		new JineData(JineType.ok_add3),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.OK),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Saikouka),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Love)
	};

	private List<JineData> love = new List<JineData>
	{
		new JineData(JineType.Jine_Reply_love_1),
		new JineData(JineType.Jine_Reply_love_2),
		new JineData(JineType.Jine_Reply_love_3),
		new JineData(JineType.Jine_Reply_love_4),
		new JineData(JineType.Jine_Reply_love_5),
		new JineData(JineType.Jine_Reply_love_6),
		new JineData(JineType.Jine_Reply_love_7),
		new JineData(JineType.love_add1),
		new JineData(JineType.love_add2),
		new JineData(JineType.love_add3),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Sorena),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Saikouka),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Love)
	};

	private List<JineData> gomen = new List<JineData>
	{
		new JineData(JineType.Jine_Reply_gomen_1),
		new JineData(JineType.Jine_Reply_gomen_2),
		new JineData(JineType.Jine_Reply_gomen_3),
		new JineData(JineType.Jine_Reply_gomen_4),
		new JineData(JineType.Jine_Reply_gomen_5),
		new JineData(JineType.Jine_Reply_gomen_6),
		new JineData(JineType.Jine_Reply_gomen_7),
		new JineData(JineType.gomen_add1),
		new JineData(JineType.gomen_add2),
		new JineData(JineType.gomen_add3),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Bujisibou),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Gomen),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Pien)
	};

	private List<JineData> bujisibou = new List<JineData>
	{
		new JineData(JineType.Jine_Reply_sibou_1),
		new JineData(JineType.Jine_Reply_sibou_2),
		new JineData(JineType.Jine_Reply_sibou_3),
		new JineData(JineType.Jine_Reply_sibou_4),
		new JineData(JineType.Jine_Reply_sibou_5),
		new JineData(JineType.Jine_Reply_sibou_6),
		new JineData(JineType.Jine_Reply_sibou_7),
		new JineData(JineType.dead_add1),
		new JineData(JineType.dead_add2),
		new JineData(JineType.dead_add3),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Bujisibou),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Gomen),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Pien)
	};

	private List<JineData> rendasuruna = new List<JineData>
	{
		new JineData(JineType.renda_add1),
		new JineData(JineType.renda_add2),
		new JineData(JineType.renda_add3)
	};

	private List<JineData> datas = new List<JineData>
	{
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.OK),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Saikouka),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Love),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Sorena),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Waritodoudemoii),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Bujisibou),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Gomen),
		new JineData(JineUserType.ame, JineType.None, ResponseType.Stamp, StampType.Pien),
		new JineData(JineType.JINE_Reply001),
		new JineData(JineType.JINE_Reply002),
		new JineData(JineType.JINE_Reply003),
		new JineData(JineType.JINE_Reply004),
		new JineData(JineType.JINE_Reply005),
		new JineData(JineType.JINE_Reply006),
		new JineData(JineType.JINE_Reply007),
		new JineData(JineType.JINE_Reply008),
		new JineData(JineType.JINE_Reply009),
		new JineData(JineType.JINE_Reply010),
		new JineData(JineType.JINE_Reply011)
	};

	private void Awake()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		UniTaskExtensions.Forget(startEvent());
	}

	[AsyncStateMachine(typeof(_003CstartEvent_003Ed__15))]
	private UniTask startEvent()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CstartEvent_003Ed__15 _003CstartEvent_003Ed__16 = default(_003CstartEvent_003Ed__15);
		_003CstartEvent_003Ed__16._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartEvent_003Ed__16._003C_003E4__this = this;
		_003CstartEvent_003Ed__16._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__16._003C_003Et__builder)).Start<_003CstartEvent_003Ed__15>(ref _003CstartEvent_003Ed__16);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__16._003C_003Et__builder)).Task;
	}
}
