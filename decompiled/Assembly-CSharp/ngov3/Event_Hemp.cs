using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_Hemp : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_Hemp;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_L);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Hemp_JINE001);
		endEvent();
	}
}
