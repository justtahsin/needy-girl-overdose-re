using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_Urge : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_Urge;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_FLow);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Urge_JINE001);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
		endEvent();
	}
}
