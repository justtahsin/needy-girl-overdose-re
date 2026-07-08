using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class HaishinStart_Ideon : NgoEvent
{
	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken, skipWatchSp: true);
		SingletonMonoBehaviour<WindowManager>.Instance.CleanOnCommand();
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
		ClickableAllScreen(onoff: false);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Broadcast);
		SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(AppType.Broadcast);
		SingletonMonoBehaviour<WindowManager>.Instance.UnMovable(AppType.Broadcast);
		endEvent();
	}
}
