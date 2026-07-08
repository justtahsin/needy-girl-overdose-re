using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Ending_Bad : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Bad;
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Bad000);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Bad001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Bad002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Bad003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Bad004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Bad005);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Bad006);
		SingletonMonoBehaviour<NotificationManager>.Instance.AddMaturoNotifier();
		(from v in SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart)
			where v == 3
			select v).Subscribe(async delegate
		{
			night();
		}).AddTo(compositeDisposable);
	}

	private async UniTask night()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_yami);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_bad000);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_bad001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_bad002);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_out_a");
		await UniTask.Delay(Constants.SLOW);
		SingletonMonoBehaviour<WebCamManager>.Instance.HideGirl();
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_bad_ura);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_bad_omote);
		await UniTask.Delay(Constants.SLOW);
		(from count in SingletonMonoBehaviour<PoketterManager>.Instance.ObserveEveryValueChanged((PoketterManager pktr) => pktr._tweetQueue.Count)
			where count == 0
			select count).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.SLOW);
			PostEffectManager.Instance.SetShader(EffectType.Noisy);
			PostEffectManager.Instance.SetShaderWeight(1f);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<PoketterManager>.Instance.isBlocked.Value = true;
			PostEffectManager.Instance.ResetShader();
			SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Ending_Work_Last);
			await UniTask.Delay(Constants.SLOW * 2);
			AchievementStatsUpdater.UpdateStats("Ending_Bad");
			SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
			await UniTask.Delay(Constants.SLOW * 4000);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
