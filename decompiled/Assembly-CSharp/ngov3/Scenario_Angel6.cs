using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Scenario_Angel6 : NgoEvent
{
	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_yami, isLoop: true);
		SingletonMonoBehaviour<EventManager>.Instance.getChip(AlphaType.Angel, 6);
		AchievementStatsUpdater.UpdateStats("Haisin_Mokuhyou");
		endEvent();
	}
}
