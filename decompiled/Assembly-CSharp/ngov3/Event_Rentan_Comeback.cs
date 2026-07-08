using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_Rentan_Comeback : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_None;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0.2f);
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursorShowHide(show: true);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Webcam).Maximize();
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_smile");
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Rentan_Comeback001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Rentan_Comeback002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Rentan_Comeback003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Rentan_Comeback004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Rentan_Comeback005);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Rentan_Comeback006);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Rentan_Comeback007);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Rentan_Comeback008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Rentan_Comeback009);
		SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Webcam).Maximize();
		SingletonMonoBehaviour<NotificationManager>.Instance.AddTimePassingNotifier(3);
		endEvent();
	}
}
