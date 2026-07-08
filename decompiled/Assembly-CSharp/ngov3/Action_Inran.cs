using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Action_Inran : NgoEvent
{
	private int yarucount;

	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
		SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.MadeLoveCounter) > 8)
		{
			SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
			AchievementStatsUpdater.UpdateStats("Ending_Lust");
		}
		if (!SingletonMonoBehaviour<WebCamManager>.Instance.hidegirl.Value)
		{
			SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_out_e");
			await UniTask.Delay(4000);
		}
		else
		{
			SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("");
			SingletonMonoBehaviour<WebCamManager>.Instance.HideGirl(onoff: true);
		}
		await SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Webcam).GetComponent<App_Webcam>().Yusayusa();
		SingletonMonoBehaviour<WebCamManager>.Instance.HideGirl();
		await NgoEvent.DelaySkippable(3400);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.MadeLoveCounter, 1);
		SingletonMonoBehaviour<ChanceEffectController>.Instance.OnFever();
		SingletonMonoBehaviour<TooltipManager>.Instance.Show(TooltipType.Tooltip_yaru);
		endEvent();
	}
}
