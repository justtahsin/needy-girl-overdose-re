using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ngov3;

public class Event_Uzagarami_Kaiwa : NgoEvent
{
	private static List<string> heijouEvents = new List<string>
	{
		"Event_AmePiercerd", "Event_Fetish", "Event_Haikuwoyome", "Event_Hairstyle", "Event_Instead", "Event_Kurorekishi", "Event_Money", "Event_MuchaGag", "Event_NextDate", "Event_Pudding",
		"Event_Sea", "Event_Seikei", "Event_Suki10", "Event_Test", "Event_UberEats", "Event_Yutabon", "Event_AmeFuture", "Event_Charahen", "Event_Sumabura", "Event_Yandeiru"
	};

	private static List<string> YamiLow5 = new List<string> { "Kenjo_4" };

	private static List<string> YamiLow10 = new List<string> { "Kenjo_3" };

	private static List<string> YamiLow15 = new List<string> { "Kenjo_2" };

	private static List<string> YamiLow20 = new List<string> { "Kenjo_1" };

	private static List<string> SFHigh1 = new List<string> { "StressHi_FollowHi_1" };

	private static List<string> SFHigh2 = new List<string> { "StressHi_FollowHi_2" };

	private static List<string> SFHigh3 = new List<string> { "StressHi_FollowHi_3" };

	private static List<string> SFHigh4 = new List<string> { "StressHi_FollowHi_4" };

	private static List<string> YFHigh3 = new List<string> { "YamiHi_FollowHi_3" };

	private static List<string> YFHigh4 = new List<string> { "YamiHi_FollowHi_4" };

	private static List<string> YFHigh5 = new List<string> { "YamiHi_FollowHi_5" };

	private static List<string> YLHigh1 = new List<string> { "YamiHi_SukiHi_1" };

	private static List<string> YLHigh2 = new List<string> { "YamiHi_SukiHi_2" };

	private static List<string> YLHigh3 = new List<string> { "YamiHi_SukiHi_3" };

	private static List<string> YLHigh4 = new List<string> { "YamiHi_SukiHi_4", "Event_Sokubaku" };

	private static List<string> FollowerHigh = new List<string> { "Event_Copyceleb", "Event_Dox", "Event_MailInterview", "Event_MenheraFriend" };

	private static List<string> FollowerLow = new List<string> { "Event_Anxiety", "Event_Approval", "Event_Choudare", "Event_Urge", "Event_Pinojien" };

	private static List<string> FollowerLowAfterHaishin = new List<string> { "Event_Kasoworry" };

	private static List<string> StressHigh = new List<string> { "Event_Damon", "Event_HelpJINE", "Event_Limit", "Event_Okiru_Afternoon", "Event_Okiru_Night" };

	private static List<string> StressHigh_egosa = new List<string> { "Event_Egosastop" };

	private static List<string> HaishinSiyou = new List<string> { "Event_HaishinSiyou" };

	private static List<string> StressLow = new List<string> { "Event_Newthings", "Event_Nickname", "Event_Watchword" };

	private static List<string> LoveHigh = new List<string> { "Event_Antherline", "Event_Gameholic", "Event_Hemp", "Event_LoveJINE", "Event_Manicure", "Event_MentalCare", "Event_Chyoroin", "Event_DateHolic", "Event_Okusan" };

	private static List<string> LoveLow = new List<string> { "Event_Doubt", "Event_Singlebed", "Event_Suggest" };

	private static List<string> YamiHigh = new List<string> { "Event_4timesJINE", "Event_Amecalling_Kowai", "Event_Brokenphone", "Event_Negativ", "Event_DrugHolic", "Event_Jisatumisui" };

	private static List<string> YamiLow = new List<string> { "Event_Advice", "Event_Amecalling_Kawaii", "Event_Cheerup", "Event_Flower" };

	private static List<string> UzagaramiAll()
	{
		List<string> list = new List<string>();
		for (int i = 1; i <= 100; i++)
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
		List<string> list = new List<string>();
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love);
		int status3 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami);
		int status4 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress);
		bool flag = SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Stress) >= 120;
		if (status3 < 20)
		{
			list.AddRange(YamiLow20);
		}
		if (status3 < 15)
		{
			list.AddRange(YamiLow15);
		}
		if (status3 < 10)
		{
			list.AddRange(YamiLow10);
		}
		if (status3 < 5)
		{
			list.AddRange(YamiLow5);
		}
		if (status3 > 40 && status2 > 40)
		{
			list.AddRange(YLHigh1);
		}
		if (status3 > 60 && status2 > 60)
		{
			list.AddRange(YLHigh2);
		}
		if (status3 > 80 && status2 > 80)
		{
			list.AddRange(YLHigh4);
		}
		if (flag && status > 100000)
		{
			list.AddRange(SFHigh1);
		}
		if (flag && status > 250000)
		{
			list.AddRange(SFHigh2);
		}
		if (flag && status > 500000)
		{
			list.AddRange(SFHigh3);
		}
		if (flag && status > 1000000)
		{
			list.AddRange(SFHigh4);
		}
		if (status3 > 60 && status > 250000)
		{
			list.AddRange(YFHigh3);
		}
		if (status3 > 60 && status > 500000)
		{
			list.AddRange(YFHigh4);
		}
		if (status3 > 60 && status > 1000000)
		{
			list.AddRange(YFHigh5);
		}
		if (status > 500000)
		{
			list.AddRange(FollowerHigh);
		}
		if (status < 100000)
		{
			list.AddRange(FollowerLow);
		}
		if (status < 100000 && (from str in SingletonMonoBehaviour<EventManager>.Instance.dayActionHistory.TakeLast(1)
			where str.Contains("_")
			select str).ToList().Count == 1)
		{
			list.AddRange(FollowerLowAfterHaishin);
		}
		if (status2 > 60)
		{
			list.AddRange(LoveHigh);
		}
		if (status2 < 20)
		{
			list.AddRange(LoveLow);
		}
		if (status3 > 60)
		{
			list.AddRange(YamiHigh);
		}
		if (status3 < 40)
		{
			list.AddRange(YamiLow);
		}
		if (status4 > 60)
		{
			list.AddRange(StressHigh);
		}
		if (status4 > 60 && SingletonMonoBehaviour<EventManager>.Instance.dayActionHistory.TakeLast(3).Contains("InternetPoketterF0Y3"))
		{
			list.AddRange(StressHigh_egosa);
		}
		if (status4 < 20)
		{
			list.AddRange(StressLow);
		}
		if (status > 10000 && (from str in SingletonMonoBehaviour<EventManager>.Instance.dayActionHistory.TakeLast(12)
			where str.Contains("_")
			select str).ToList().Count == 0)
		{
			list.AddRange(HaishinSiyou);
		}
		IEnumerable<string> source = list.Except(SingletonMonoBehaviour<EventManager>.Instance.eventsHistory);
		if (source.Count() < 5)
		{
			list.AddRange(heijouEvents);
			source = list.Except(SingletonMonoBehaviour<EventManager>.Instance.eventsHistory);
		}
		if (source.Count() == 0)
		{
			return "Event_tekiTalk";
		}
		return source.ElementAt(Random.Range(0, source.Count()));
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
		eventName = getUniqueUzagaramiId();
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue(eventName);
		endEvent();
	}
}
