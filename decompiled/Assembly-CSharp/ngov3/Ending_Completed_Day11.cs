using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;

namespace ngov3;

public class Ending_Completed_Day11 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await UniTask.Delay(1000);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.PillDypass);
		window.nakamiApp.GetComponentInChildren<SheetView>().OnDose();
		window.nakamiApp.GetComponentInChildren<SheetView>().OnDose();
		window.nakamiApp.GetComponentInChildren<SheetView>().OnDose();
		AudioManager.Instance.PlaySeByType(SoundType.SE_takepill_lv1);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim(SingletonMonoBehaviour<EventManager>.Instance.PlatformDiffAnimationMaster.GetAnimationNameFromKey(PlatformDiffAnimationKey.DAYPASS));
		await NgoEvent.DelaySkippable(Constants.SLOW);
		float weight = 0f;
		PostEffectManager.Instance.SetShader(EffectType.OD);
		await DOTween.To(() => weight, delegate(float x)
		{
			PostEffectManager.Instance.SetShaderWeight(x);
		}, 0.8f, 1.2f).SetEase(Ease.InExpo).Play();
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Kusuri_shohou_od, CommandResult.success));
		PostEffectManager.Instance.ResetShaderCalmly();
		SingletonMonoBehaviour<EventManager>.Instance.ApplyStatus(CmdType.OkusuriDaypassOverdoseY2);
		await UniTask.Delay(1000);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		await SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
		await SingletonMonoBehaviour<StatusManager>.Instance.timePassing(2);
		SingletonMonoBehaviour<EventManager>.Instance.alpha = AlphaType.Gamejikkyou;
		SingletonMonoBehaviour<EventManager>.Instance.alphaLevel = 3;
		await HaishinFirstAnimation.LoadHaishinFirstAnimation();
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Broadcast);
		await UniTask.Delay(6000);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Broadcast);
		CmdType a = SingletonMonoBehaviour<CommandManager>.Instance.ChooseCommand(ActionType.Haishin);
		SingletonMonoBehaviour<EventManager>.Instance.ApplyStatus(a);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		tweetFromTip(SingletonMonoBehaviour<EventManager>.Instance.alpha, SingletonMonoBehaviour<EventManager>.Instance.alphaLevel);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
		SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.TaskManager));
		await SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
		await UniTask.Delay(1000);
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<DayPassing>();
		endEvent();
	}
}
