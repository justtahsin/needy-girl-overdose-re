using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_Av : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Av;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		SingletonMonoBehaviour<WebCamManager>.Instance.GoOut();
		await UniTask.Delay(Constants.SLOW);
		AudioManager.Instance.PlaySeByType(SoundType.SE_zugyaaaann);
		SingletonMonoBehaviour<WebCamManager>.Instance.HideGirl();
		await UniTask.Delay(Constants.SLOW);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_kenjo);
		switch (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)
		{
		case LanguageType.JP:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_AV_Tweet001);
			break;
		case LanguageType.CN:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_AV_Tweet001_cn);
			break;
		case LanguageType.KO:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_AV_Tweet001_ko);
			break;
		case LanguageType.TW:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_AV_Tweet001_tch);
			break;
		case LanguageType.VN:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_AV_Tweet001_vn);
			break;
		case LanguageType.FR:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_AV_Tweet001_fr);
			break;
		case LanguageType.IT:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_AV_Tweet001_it);
			break;
		case LanguageType.GE:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_AV_Tweet001_ge);
			break;
		case LanguageType.SP:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_AV_Tweet001_sp);
			break;
		case LanguageType.RU:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_AV_Tweet001_ru);
			break;
		default:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_AV_Tweet001_en);
			break;
		}
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
		SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Result).Uncloseable();
		await UniTask.Delay(3000);
		AudioManager.Instance.PlaySeByType(SoundType.SE_wow);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Follower, 50000);
		await UniTask.Delay(3000);
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		AchievementStatsUpdater.UpdateStats("Ending_Av");
		endEvent();
	}
}
