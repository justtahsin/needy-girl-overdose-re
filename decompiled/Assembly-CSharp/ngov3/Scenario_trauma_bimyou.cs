using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Scenario_trauma_bimyou : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_kincho, isLoop: true);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Scenario_trauma_iketeru_Tweet001_ura, isOmote: false);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Scenario_trauma_iketeru_Tweet002_ura, isOmote: false);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		(from v in SingletonMonoBehaviour<PoketterManager>.Instance.ObserveEveryValueChanged((PoketterManager _poketter) => SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count)
			where v == 0
			select v).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.SLOW);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
