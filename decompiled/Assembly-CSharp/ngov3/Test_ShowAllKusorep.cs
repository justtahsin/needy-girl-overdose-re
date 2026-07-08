using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Test_ShowAllKusorep : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		List<KusoRepType> list = new List<KusoRepType>();
		foreach (KusoRepType value in Enum.GetValues(typeof(KusoRepType)))
		{
			list.Add(value);
		}
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps("uwaaa", isOmote: true, list);
		endEvent();
	}
}
