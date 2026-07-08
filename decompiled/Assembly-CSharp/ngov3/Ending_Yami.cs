using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_Yami : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Yami;
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 1f);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Yandakarisuma_Tweet001);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Yandakarisuma_Tweet002);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Yandakarisuma_Tweet003);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Yandakarisuma_Tweet004);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Yandakarisuma_Tweet005);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Yandakarisuma_Tweet006);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
		SingletonMonoBehaviour<EventManager>.Instance.alpha = AlphaType.Yamihaishin;
		SingletonMonoBehaviour<EventManager>.Instance.alphaLevel = 5;
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Broadcast);
		SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(AppType.Broadcast);
		SingletonMonoBehaviour<WindowManager>.Instance.UnMovable(AppType.Broadcast);
		endEvent();
	}
}
