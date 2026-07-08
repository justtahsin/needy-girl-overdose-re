using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_Doubt : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_Doubt;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_LLow);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Doubt_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Doubt_JINE002);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
		endEvent();
	}
}
