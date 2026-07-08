using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Ending_Ideon_afterHaishin : NgoEvent
{
	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
		PostEffectManager.Instance.ResetShader();
		await NgoEvent.DelaySkippable(4000);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Ideon_webcam);
		await UniTask.Delay(4000);
		await UniTask.Delay(4000);
		AchievementStatsUpdater.UpdateStats("Ending_Ideon");
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		endEvent();
	}
}
