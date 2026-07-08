using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Action_OdekakeShinjuku : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken, skipWatchSp: true);
		await GoOut();
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Odekake_sinjuku, CommandResult.success));
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		await BackFromOdekake();
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		endEvent();
	}
}
