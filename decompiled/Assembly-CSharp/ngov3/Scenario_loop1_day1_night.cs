using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Scenario_loop1_day1_night : NgoEvent
{
	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tutorial_night);
		endEvent();
	}
}
