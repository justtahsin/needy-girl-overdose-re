using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_Dox : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_Dox;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_F);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dox_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dox_JINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dox_JINE003);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
		endEvent();
	}
}
