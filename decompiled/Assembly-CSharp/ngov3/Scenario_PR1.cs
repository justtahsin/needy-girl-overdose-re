using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Scenario_PR1 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.getChip(AlphaType.PR, 1);
		endEvent();
	}
}
