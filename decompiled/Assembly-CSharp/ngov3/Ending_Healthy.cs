using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_Healthy : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Healthy;
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Poketter).Maximize();
		SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Poketter).Uncloseable();
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_kenjo);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Kenjou_Tweet001);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Kenjou_Tweet002);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Kenjou_Tweet003);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		AchievementStatsUpdater.UpdateStats("Ending_Healthy");
		endEvent();
	}
}
