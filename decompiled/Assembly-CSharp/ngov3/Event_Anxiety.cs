using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_Anxiety : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_Anxiety;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_FLow);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Anxiety_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Anxiety_JINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Anxiety_JINE003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Anxiety_JINE004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Anxiety_JINE005);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Anxiety_JINE006);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 2);
		endEvent();
	}
}
