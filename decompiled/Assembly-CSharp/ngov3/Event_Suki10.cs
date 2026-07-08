using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_Suki10 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Suki10_JINE001);
		SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
		await NgoEvent.DelaySkippable(6000);
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Suki10_JINE002);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
		endEvent();
	}

	private async UniTask ConsumerStartEvent()
	{
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Suki10_JINE001);
		SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
		await NgoEvent.DelaySkippable(6000);
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Suki10_JINE002);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
		endEvent();
	}
}
