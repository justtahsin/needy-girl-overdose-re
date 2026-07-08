using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class EventTekitouhenji : MonoBehaviour
{
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
		startEvent().Forget();
	}

	private async UniTask startEvent()
	{
		(from _ in SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory
			where _.Value.responseType == ResponseType.Stamp && _.Value.user == JineUserType.pi
			select 1).Scan(0, (int element, int acc) => element + acc).Throttle(TimeSpan.FromSeconds(1.5)).FirstOrDefault()
			.RepeatUntilDestroy(this)
			.Subscribe(async delegate(int counter)
			{
				if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_None && !SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) < 80 && counter < 4 && SingletonMonoBehaviour<JineManager>.Instance.history.Last().responseType == ResponseType.Stamp && SingletonMonoBehaviour<JineManager>.Instance.history.Last().user == JineUserType.pi && UnityEngine.Random.Range(0, 100) > 20)
				{
					List<JineData> rawdatas = SingletonMonoBehaviour<JineManager>.Instance.history.Last().stampType switch
					{
						StampType.OK => ok, 
						StampType.Saikouka => saikouka, 
						StampType.Pien => pien, 
						StampType.Waritodoudemoii => waritodoudemoii, 
						StampType.Gomen => gomen, 
						StampType.Bujisibou => bujisibou, 
						StampType.Love => love, 
						_ => sorena, 
					};
					rawdatas.AddRange(amestamps);
					await UniTask.Delay(400);
					SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(rawdatas[UnityEngine.Random.Range(0, rawdatas.Count)]);
				}
			})
			.AddTo(base.gameObject);
		(from _ in SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory
			where _.Value.responseType == ResponseType.Stamp && _.Value.user == JineUserType.pi
			select 1).Scan(0, (int element, int acc) => element + acc).Throttle(TimeSpan.FromSeconds(1.5)).FirstOrDefault()
			.RepeatUntilDestroy(this)
			.Subscribe(async delegate(int counter)
			{
				if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_None && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) < 80 && counter >= 4)
				{
					await UniTask.Delay(1000);
					List<JineData> list = rendasuruna;
					SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(list[UnityEngine.Random.Range(0, list.Count)]);
				}
			})
			.AddTo(base.gameObject);
	}
}
