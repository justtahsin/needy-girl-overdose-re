using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Scenario_trauma_pigaiya : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Event_Dialog>();
		endEvent();
	}
}
