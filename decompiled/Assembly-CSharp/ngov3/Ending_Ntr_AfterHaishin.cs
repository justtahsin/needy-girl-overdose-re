using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_Ntr_AfterHaishin : NgoEvent
{
	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_NTR_Haisin_Tweet001);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Poketter).Maximize();
		SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Poketter).Uncloseable();
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Ntr;
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		AchievementStatsUpdater.UpdateStats("Ending_Ntr");
		endEvent();
	}
}
