using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Scenario_Achieved_Aim : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_happy);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Aim_Achieved_Day14_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Aim_Achieved_Day14_JINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Aim_Achieved_Day14_JINE003);
		endEvent();
	}
}
