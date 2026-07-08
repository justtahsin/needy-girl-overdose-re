using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Ending_Stressful : NgoEvent
{
	private IDisposable _disposable;

	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_kincho);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Stressful;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Stressful_Tweet001);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Stressful_Tweet002);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Stressful_Tweet003);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Poketter).Maximize();
		SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Poketter).Uncloseable();
		SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
		_disposable = (from count in SingletonMonoBehaviour<PoketterManager>.Instance.ObserveEveryValueChanged((PoketterManager pktr) => pktr._tweetQueue.Count)
			where count == 0
			select count).Take(1).Subscribe(async delegate
		{
			_disposable.Dispose();
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			PostEffectManager.Instance.SetShader(EffectType.Noisy);
			SingletonMonoBehaviour<PoketterManager>.Instance.isDeleted.SetValueAndForceNotify(value: true);
			PostEffectManager.Instance.ResetShaderCalmly();
			await NgoEvent.DelaySkippable(Constants.SLOW);
			AchievementStatsUpdater.UpdateStats("Ending_Stressful");
			SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
