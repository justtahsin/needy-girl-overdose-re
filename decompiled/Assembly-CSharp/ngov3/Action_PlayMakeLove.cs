using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Action_PlayMakeLove : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken, skipWatchSp: true);
		SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
		PostEffectManager.Instance.SetShader(EffectType.Otona);
		IWindow ame = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		ame.Uncloseable();
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_out_e");
		await UniTask.Delay(3400);
		await SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Webcam).GetComponent<App_Webcam>().Yusayusa();
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("");
		PostEffectManager.Instance.ResetShaderCalmly();
		switch (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.MadeLoveCounter))
		{
		case 0:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Yaru_sex, CommandResult.times0));
			break;
		case 1:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Yaru_sex, CommandResult.times1));
			break;
		case 2:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Yaru_sex, CommandResult.times2));
			break;
		case 3:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Yaru_sex, CommandResult.times3));
			break;
		case 4:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Yaru_sex, CommandResult.times4));
			break;
		case 5:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Yaru_sex, CommandResult.times5));
			break;
		default:
			SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Lust;
			SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Ending_Lust>();
			break;
		}
		await NgoEvent.DelaySkippable(Constants.FAST);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.MadeLoveCounter, 1);
		ame.Closeable();
		endEvent();
	}
}
