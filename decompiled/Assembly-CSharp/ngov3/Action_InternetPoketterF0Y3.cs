using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Action_InternetPoketterF0Y3 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken, skipWatchSp: true);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_egosearching");
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.EgosaResult);
		await NgoEvent.DelaySkippable(Constants.SLOW * 3);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Tweet_egosa, CommandResult.success));
		endEvent();
	}
}
