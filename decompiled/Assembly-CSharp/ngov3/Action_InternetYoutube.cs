using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Action_InternetYoutube : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken, skipWatchSp: true);
		AudioManager.Instance.PlaySeByType(SoundType.SE_gosogoso);
		SingletonMonoBehaviour<WebCamManager>.Instance.Movie();
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.InternetYoutube, CommandResult.success));
		endEvent();
	}
}
