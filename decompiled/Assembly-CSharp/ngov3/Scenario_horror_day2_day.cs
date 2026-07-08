using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;

namespace ngov3;

public class Scenario_horror_day2_day : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.TaskManager);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.EgosaResult);
		await UniTask.Delay(Constants.MIDDLE * 3);
		await NgoEvent.DelaySkippable(Constants.MIDDLE * 3);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_vomiting1");
		await UniTask.Delay(Constants.MIDDLE);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Keijiban);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW * 2);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_vomiting2");
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_KowaiInternet_Day2_Tweet001);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_KowaiInternet_Day2_Tweet002);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_KowaiInternet_Day2_Tweet003, new List<KusoRepType>
		{
			KusoRepType.Ending_KowaiInternet_Day2_KusoRep001,
			KusoRepType.Ending_KowaiInternet_Day2_KusoRep002,
			KusoRepType.KowaiInternet_Day2_Kusorep1,
			KusoRepType.KowaiInternet_Day2_Kusorep2,
			KusoRepType.KowaiInternet_Day2_Kusorep3,
			KusoRepType.KowaiInternet_Day2_Kusorep4,
			KusoRepType.KowaiInternet_Day2_Kusorep5,
			KusoRepType.KowaiInternet_Day2_Kusorep6
		});
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		(from v in SingletonMonoBehaviour<PoketterManager>.Instance.ObserveEveryValueChanged((PoketterManager _poketter) => SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count)
			where v == 0
			select v).Subscribe(async delegate
		{
			await UniTask.Delay(Constants.MIDDLE);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<StatusManager>.Instance.timePassing(2);
			PostEffectManager.Instance.AnmakuWeight(0.3f);
			SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Action_HaishinStart>();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
