using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Scenario_topstreamer_trahappaikeikeatonobi : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_atonobi_LINE001);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_trahappaikeike_LINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_trahappaikeike_LINE003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_trahappaikeike_LINE004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_trahappaikeike_LINE005);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_trahappaikeike_LINE006);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_trahappaikeike_LINE007);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_trahappaikeike_LINE008);
		await NgoEvent.DelaySkippable(1400);
		endEvent();
	}
}
