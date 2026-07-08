using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Scenario_happa_kentoraikeike : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_happy, isLoop: true);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_happa_kentoraikeike_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_happa_kentoraikeike_LINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_happa_kentoraikeike_LINE003);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await NadeNade(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_happa_kentoraikeike_LINE004);
			await NgoEvent.DelaySkippable(Constants.SLOW);
			endEvent();
		});
	}
}
