using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_Chyoroin : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Choroin001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Choroin002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Choroin003);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		NadeNade(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Choroin004);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		});
	}
}
