using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Scenario_poem_saiaku : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		endEvent();
	}
}
