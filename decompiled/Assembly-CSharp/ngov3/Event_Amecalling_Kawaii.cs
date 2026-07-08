using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_Amecalling_Kawaii : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_YLow);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Calling);
		AudioManager.Instance.PlaySeByType(SoundType.SE_LINE_Call);
		await NgoEvent.DelaySkippable(Constants.FAST);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Calling);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Amecalling_Kawaii_JINE001);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
		endEvent();
	}
}
