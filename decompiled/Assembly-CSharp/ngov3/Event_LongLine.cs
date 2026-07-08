using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;

namespace ngov3;

public class Event_LongLine : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		int id = Random.Range(0, 5);
		List<JineType> jines = new List<JineType>
		{
			JineType.Event_LongLINE001,
			JineType.Event_LongLINE002,
			JineType.Event_LongLINE003,
			JineType.Event_LongLINE004,
			JineType.Event_LongLINE005
		};
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(jines[id]);
		SingletonMonoBehaviour<EventManager>.Instance.Trauma = jines[id];
		endEvent();
	}
}
