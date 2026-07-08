using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Scenario_loop1_day0_night_AfterHaisin : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.executingAction = CmdType.None;
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Day0_Poketter_001);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
		CancellationTokenSource cts = new CancellationTokenSource();
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Result).GetComponent<PoketterView2D>().shootTweetAll(cts);
		await UniTask.Delay(Constants.MIDDLE);
		await NgoEvent.DelaySkippable(SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count * Constants.SLOW + Constants.MIDDLE);
		SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.TaskManager));
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Follower, 1000);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 10);
		await SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
		SingletonMonoBehaviour<WindowManager>.Instance.CleanOnCommand();
		SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = true;
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_egosearching");
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<JineManager>.Instance.addTimeSeparator(-1);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE017);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE018);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE019);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE020);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE021);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE022);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE023);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Day0_JINE023_Oprtion001,
			JineType.Day0_JINE023_Oprtion002
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Day0_JINE023_Oprtion001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE024);
			eventContinue1();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Day0_JINE023_Oprtion002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE025);
			eventContinue1();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue1()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE026);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE027);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE028);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE029);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE030);
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<DayPassing>();
		endEvent();
	}
}
