using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Action_EntameGame : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken, skipWatchSp: true);
		AudioManager.Instance.PlaySeByType(SoundType.SE_gamePlay);
		SingletonMonoBehaviour<WebCamManager>.Instance.Gaming();
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Amechan_game, CommandResult.success));
		AudioManager.Instance.StopByType(SoundType.SE_gamePlay);
		endEvent();
	}
}
