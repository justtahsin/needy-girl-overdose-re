using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_Brokenphone : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_Brokenphone;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_Y);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Brokenphone_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Brokenphone_JINE002);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 3);
		endEvent();
	}
}
