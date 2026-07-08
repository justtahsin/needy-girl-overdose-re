using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Action_Needy : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
		PostEffectManager.Instance.SetShader(EffectType.Otona);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_out_e");
		await UniTask.Delay(6000);
		await SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Webcam).GetComponent<App_Webcam>().Yusayusa();
		await NgoEvent.DelaySkippable(3400);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
		PostEffectManager.Instance.ResetShaderCalmly();
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Kyouizon_ChoutenTweet001);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Kyouizon_AmechanTweet001);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter).Maximize();
		SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
		await NgoEvent.DelaySkippable(3400);
		AchievementStatsUpdater.UpdateStats("Ending_Needy");
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		endEvent();
	}
}
