using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Scenario_Angel1 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_happy, isLoop: true);
		SingletonMonoBehaviour<EventManager>.Instance.getChip(AlphaType.Angel, 1);
		AchievementStatsUpdater.UpdateStats("Haisin_Shuueki");
		endEvent();
	}
}
