using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;
using ngov3.Effect;

namespace ngov3;

public class Ending_Yarisute : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Yarisute;
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_endng_normal, isLoop: true);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Yarisute000);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Yarisute003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Yarisute004);
		SingletonMonoBehaviour<NotificationManager>.Instance.AddMaturoNotifier();
		(from v in SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart)
			where v == 3
			select v).Subscribe(async delegate
		{
			StartOwakare();
		}).AddTo(compositeDisposable);
	}

	private async UniTask StartOwakare()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_happy, isLoop: true);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Yarisute_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Yarisute_LINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Yarisute_LINE003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Yarisute_LINE004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Yarisute_LINE005);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_Yarisute_LINE005_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Yarisute_LINE005_pi).Subscribe(async delegate
		{
			eventContinue1();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue1()
	{
		await NgoEvent.DelaySkippable(2500);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Yarisute_LINE006);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_Yarisute_LINE006_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Yarisute_LINE006_pi).Subscribe(async delegate
		{
			eventContinue2();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue2()
	{
		await NgoEvent.DelaySkippable(2500);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Yarisute_LINE007);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
		SingletonMonoBehaviour<EventManager>.Instance.HideShortcut();
		await GameObject.Find("DayPassingCover").GetComponent<IDayPassing>().yearsPass();
		SingletonMonoBehaviour<StatusManager>.Instance.timePassing(2);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Yarisute_Tweet001);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Poketter).Maximize();
		SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Poketter).Uncloseable();
		await NgoEvent.DelaySkippable(Constants.SLOW);
		PostEffectManager.Instance.SetShader(EffectType.Bleeding);
		PostEffectManager.Instance.SetShaderWeight(0.02f);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_kenjo, isLoop: true);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Yarisute_Tweet002);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Yarisute_Tweet003);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Yarisute_Tweet004);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Yarisute_Tweet005);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Yarisute_Tweet006);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Yarisute_Tweet007);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		Asobareteru();
	}

	private async UniTask Asobareteru()
	{
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Yarisute_Tweet008);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		PostEffectManager.Instance.SetShaderWeight(0.3f);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_yami, isLoop: true);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Yarisute_Tweet009);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Yarisute_Tweet010);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Yarisute_Tweet011);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_Yarisute_Tweet012);
		Ikari();
	}

	private async UniTask Ikari()
	{
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Yarisute_Tweet013);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		PostEffectManager.Instance.ResetShaderCalmly();
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_kincho, isLoop: true);
		SingletonMonoBehaviour<ChanceEffectController>.Instance.OnReach(ChanceEffectType.Chainsaw);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Yarisute_Tweet014);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Yarisute_Tweet015);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Yarisute_Tweet016);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Yarisute_Tweet018);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Yarisute_Tweet019);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		Yarisutend();
	}

	private async UniTask Yarisutend()
	{
		SingletonMonoBehaviour<ChanceEffectController>.Instance.OnFever();
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Yarisute_Tweet020);
		await UniTask.Delay(Constants.SLOW);
		await UniTask.Delay(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Where((bool v) => !v).Subscribe(delegate
		{
			SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
			AchievementStatsUpdater.UpdateStats("Ending_Yarisute");
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
