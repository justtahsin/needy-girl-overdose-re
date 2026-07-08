using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_Antherline : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_Antherline;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_L);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Antherline_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Antherline_JINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Antherline_JINE003);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
		endEvent();
	}
}
