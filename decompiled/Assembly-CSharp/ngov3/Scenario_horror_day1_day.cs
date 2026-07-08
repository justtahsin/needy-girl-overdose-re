using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using UniRx;

namespace ngov3;

public class Scenario_horror_day1_day : NgoEvent
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
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE003);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.EgosaResult);
		await UniTask.Delay(Constants.SLOW * 2);
		await NgoEvent.DelaySkippable(Constants.SLOW * 2);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_KowaiInternet_Day1_Tweet001);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_KowaiInternet_Day1_Tweet002);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_KowaiInternet_Day1_Tweet003);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_KowaiInternet_Day1_Tweet004);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_KowaiInternet_Day1_Tweet005);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		(from count in SingletonMonoBehaviour<PoketterManager>.Instance.ObserveEveryValueChanged((PoketterManager pktr) => pktr._tweetQueue.Count)
			where count == 0
			select count).Take(1).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			await takePill();
		}).AddTo(compositeDisposable);
	}

	private async UniTask takePill()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim(SingletonMonoBehaviour<EventManager>.Instance.PlatformDiffAnimationMaster.GetAnimationNameFromKey(PlatformDiffAnimationKey.DAYPASS));
		AudioManager.Instance.PlaySeByType(SoundType.SE_takepill_lv1);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_KowaiInternet_Day1_Tweet006, new List<KusoRepType>
		{
			KusoRepType.Ending_KowaiInternet_Day1_KusoRep001,
			KusoRepType.Ending_KowaiInternet_Day1_KusoRep002,
			KusoRepType.Ending_KowaiInternet_Day1_KusoRep003,
			KusoRepType.Ending_KowaiInternet_Day1_KusoRep004
		});
		if (SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter) != null)
		{
			SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
		}
		await NgoEvent.DelaySkippable(Constants.SLOW * 4);
		await NgoEvent.DelaySkippable(Constants.SLOW * 4);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE006);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE007);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE009);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day1_LINE009_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day1_LINE009_pi).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE010);
			eventContinue1();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue1()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE011);
		await NgoEvent.DelaySkippable(2000);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim(SingletonMonoBehaviour<EventManager>.Instance.PlatformDiffAnimationMaster.GetAnimationNameFromKey(PlatformDiffAnimationKey.HIPURON));
		AudioManager.Instance.PlaySeByType(SoundType.SE_takepill_lv3);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		float weight = 0f;
		PostEffectManager.Instance.SetShader(EffectType.OD3);
		await DOTween.To(() => weight, delegate(float x)
		{
			PostEffectManager.Instance.SetShaderWeight(x);
		}, 0.2f, 1.2f).SetEase(Ease.InExpo).Play();
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		PostEffectManager.Instance.ResetShaderCalmly();
		SingletonMonoBehaviour<StatusManager>.Instance.timePassing(2);
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Action_HaishinStart>();
		endEvent();
	}
}
