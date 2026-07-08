using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Action_InternetPoketterF0Y12 : NgoEvent
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
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Tweet_normal, CommandResult.success));
		endEvent();
	}
}
