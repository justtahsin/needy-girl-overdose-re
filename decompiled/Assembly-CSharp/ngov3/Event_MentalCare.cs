using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_MentalCare : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_MentalCare;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_L);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MentalCare_JINE001);
		await NadeNade(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MentalCare_JINE002);
			endEvent();
		});
	}
}
