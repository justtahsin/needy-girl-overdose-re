using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;
using ngov3.Effect;

namespace ngov3;

public class Ending_Yami_AfterHaishin : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
		await GameObject.Find("DayPassingCover").GetComponent<IDayPassing>().yearsPass(isBackObi: false);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_dead, isLoop: true);
		SingletonMonoBehaviour<EventManager>.Instance.HideShortcut();
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Keijiban);
		window.Maximize();
		window.Uncloseable();
		await UniTask.Delay(Constants.SLOW * 6);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		AchievementStatsUpdater.UpdateStats("Ending_Yami");
		endEvent();
	}
}
