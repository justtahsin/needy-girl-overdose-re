using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_Completed_Day16 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Jine);
		await UniTask.Delay(6000);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_Completed_day18_000);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_Completed_day18_001);
		await UniTask.Delay(12000);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.GoOut);
		await UniTask.Delay(1000);
		SingletonMonoBehaviour<WindowManager>.Instance.Close(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.GoOut));
		await GoOut();
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Odekake_nakano, CommandResult.success));
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		await UniTask.Delay(1000);
		SingletonMonoBehaviour<EventManager>.Instance.ApplyStatus(CmdType.OdekakeNakano);
		await UniTask.Delay(1000);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		await SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
		await SingletonMonoBehaviour<StatusManager>.Instance.timePassing(2);
		await UniTask.Delay(1000);
		SingletonMonoBehaviour<EventManager>.Instance.alpha = AlphaType.Gamejikkyou;
		SingletonMonoBehaviour<EventManager>.Instance.alphaLevel = 4;
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
