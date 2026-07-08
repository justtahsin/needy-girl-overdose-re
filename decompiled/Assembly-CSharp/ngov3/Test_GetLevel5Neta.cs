using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Test_GetLevel5Neta : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		foreach (AlphaType value in Enum.GetValues(typeof(AlphaType)))
		{
			SingletonMonoBehaviour<NetaManager>.Instance.GetChip(value, 5);
		}
		endEvent();
	}
}
