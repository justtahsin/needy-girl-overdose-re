using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Scenario_topstreamer_yadahappakeikeatonobi : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_yami, isLoop: true);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_atonobi_LINE001);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_yadahappakeike_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_yadahappakeike_LINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_yadahappakeike_LINE003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_yadahappakeike_LINE004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_yadahappakeike_LINE005);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_yadahappakeike_LINE006);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_yadahappakeike_LINE007);
		await NgoEvent.DelaySkippable(1400);
		endEvent();
	}
}
