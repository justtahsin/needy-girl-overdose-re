using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;

namespace ngov3;

public class Event_Uzagarami_Dokuhaku : NgoEvent
{
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
		return source.ElementAt(UnityEngine.Random.Range(0, source.Count()));
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) >= 60)
		{
			endEvent();
		}
		eventName = getUniqueUzagaramiId();
		if (eventName.StartsWith("LineWeekDay"))
		{
			SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory((JineType)Enum.Parse(typeof(JineType), eventName));
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		}
		else
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue(eventName);
		}
		endEvent();
	}
}
