using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Scenario_start_follower_low : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_kincho, isLoop: true);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_start_follower_low_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_start_follower_low_LINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_start_follower_low_LINE003);
		endEvent();
	}
}
