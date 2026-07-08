using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Action_InternetDeai2 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken, skipWatchSp: true);
		await SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Dinder).GetComponent<TinderView>().OnChoosed();
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_out_a");
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		PostEffectManager.Instance.AnmakuWeight(1f);
		AudioManager.Instance.PlaySeByType(SoundType.SE_zugyaaaann);
		await NgoEvent.DelaySkippable(Constants.FAST);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Deai, CommandResult.success));
		SingletonMonoBehaviour<WebCamManager>.Instance.RandomizeAmeAnimation();
		PostEffectManager.Instance.ResetShader();
		endEvent();
	}
}
