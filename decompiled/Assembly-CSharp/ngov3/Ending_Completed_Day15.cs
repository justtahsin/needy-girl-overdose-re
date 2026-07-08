using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Ending_Completed_Day15 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<WebCamManager>.Instance.GoOut();
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		PostEffectManager.Instance.AnmakuWeight(1f);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		PostEffectManager.Instance.ResetShader();
		SingletonMonoBehaviour<EventManager>.Instance.ApplyStatus(CmdType.SleepToNight2);
		await UniTask.Delay(1000);
		await SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
		await SingletonMonoBehaviour<StatusManager>.Instance.timePassing(2);
		SingletonMonoBehaviour<EventManager>.Instance.alpha = AlphaType.PR;
		SingletonMonoBehaviour<EventManager>.Instance.alphaLevel = 1;
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
