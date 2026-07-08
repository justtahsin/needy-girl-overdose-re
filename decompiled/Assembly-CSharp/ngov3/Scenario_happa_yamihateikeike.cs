using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Scenario_happa_yamihateikeike : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_yami, isLoop: true);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_happa_yamihateikeike_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_happa_yamihateikeike_LINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_happa_yamihateikeike_LINE003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_happa_yamihateikeike_LINE004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_happa_yamihateikeike_LINE005);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		endEvent();
	}
}
