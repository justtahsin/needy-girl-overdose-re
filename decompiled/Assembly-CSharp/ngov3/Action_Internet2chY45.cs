using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Action_Internet2chY45 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken, skipWatchSp: true);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_egosearching");
		SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Keijiban).GetComponent<KitsuneView>().Jien();
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Kitsune_tataku, CommandResult.success));
		endEvent();
	}
}
