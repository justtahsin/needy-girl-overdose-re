using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class DayPassing : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		Debug.Log("日数経過");
		SingletonMonoBehaviour<CursorManager>.Instance.DisableLiveCursorMode();
		base.startEvent(cancellationToken);
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_None || SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Completed)
		{
			endEvent();
		}
		ReactiveProperty<int> statusObservable = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart);
		ReactiveProperty<int> statusObservable2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex);
		statusObservable.Value = 0;
		statusObservable2.Value++;
		endEvent();
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}
}
