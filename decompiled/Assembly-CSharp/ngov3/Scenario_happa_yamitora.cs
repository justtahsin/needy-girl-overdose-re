using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Scenario_happa_yamitora : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_yami, isLoop: true);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_happa_yamitora_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_happa_yamitora_LINE002);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		endEvent();
	}
}
