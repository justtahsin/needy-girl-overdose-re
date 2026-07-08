using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Scenario_day0_poem : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<DayPassing>();
		endEvent();
	}
}
