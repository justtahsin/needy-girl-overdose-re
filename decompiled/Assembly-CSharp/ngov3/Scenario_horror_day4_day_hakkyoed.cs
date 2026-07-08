using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class Scenario_horror_day4_day_hakkyoed : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		GameObject.Find("HakkyoShortCutParent").GetComponent<CanvasGroup>().alpha = 0f;
		GameObject.Find("HakkyoShortCutParent").GetComponent<CanvasGroup>().interactable = false;
		GameObject.Find("HakkyoShortCutParent").GetComponent<CanvasGroup>().blocksRaycasts = false;
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Hakkyo);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_craziness");
		PostEffectManager.Instance.ResetShader();
		PostEffectManager.Instance.SetShader(EffectType.GoCrazy);
		float weight = 0f;
		await DOTween.To(() => weight, delegate(float x)
		{
			PostEffectManager.Instance.SetShaderWeight(x);
		}, 1f, 1.2f).SetEase(Ease.InExpo).Play();
		PostEffectManager.Instance.ResetShaderCalmly();
		foreach (Transform item in SingletonMonoBehaviour<EventManager>.Instance.hakkyoRotationObjectTr)
		{
			item.DORotate(new Vector3(0f, 0f, 2.6f), 0.2f).SetEase(Ease.OutBounce).Play();
		}
		AudioManager.Instance.StopByType(SoundType.BGM_chime);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_horrornoise_A, isLoop: true);
		GameObject.Find("EndingCover").transform.Find("water").gameObject.SetActive(value: true);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_idle_happy_d");
		await NgoEvent.DelaySkippable(3000);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE007);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE009);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE010);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE011);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE012);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE013);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE014);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE015);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day4_LINE015_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day4_LINE015_pi).Subscribe(async delegate
		{
			eventContinue2();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue2()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE016);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day4_LINE016_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day4_LINE016_pi).Subscribe(async delegate
		{
			eventContinue3();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue3()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE017);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day4_LINE017_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day4_LINE017_pi).Subscribe(async delegate
		{
			eventContinue4();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue4()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE018);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day4_LINE018_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day4_LINE018_pi).Subscribe(async delegate
		{
			eventContinue5();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue5()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE019);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day4_LINE019_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day4_LINE019_pi).Subscribe(async delegate
		{
			eventContinue6();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue6()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE020);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day4_LINE020_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day4_LINE020_pi).Subscribe(async delegate
		{
			eventContinue7();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue7()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE021);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		await NgoEvent.DelaySkippable(Constants.FAST);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_KowaiInternet_Day4_Tweet001);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_KowaiInternet_Day4_Tweet002);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_KowaiInternet_Day4_Tweet003);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_KowaiInternet_Day4_Tweet004);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_KowaiInternet_Day4_Tweet005);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
		await NgoEvent.DelaySkippable(Constants.SLOW);
		(from v in SingletonMonoBehaviour<PoketterManager>.Instance.ObserveEveryValueChanged((PoketterManager _poketter) => SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count)
			where v == 0
			select v).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<StatusManager>.Instance.timePassing(2);
			SingletonMonoBehaviour<WindowManager>.Instance.CleanOnCommand();
			SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
			SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Jine);
			SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Poketter);
			SingletonMonoBehaviour<CommandManager>.Instance.disableAllCommands();
			PostEffectManager.Instance.SetShader(EffectType.Psyche);
			PostEffectManager.Instance.SetShaderWeight(1f);
			PostEffectManager.Instance.ResetShaderCalmly();
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Bank);
			AudioManager.Instance.PlayBgmByType(SoundType.BANK_bank);
			HaishinFirstAnimation.LoadHaishinFirstAnimation().Forget();
			await UniTask.Delay(6000);
			await UniTask.Delay(10000);
			SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Bank);
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Broadcast);
			SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(AppType.Broadcast);
			SingletonMonoBehaviour<WindowManager>.Instance.UnMovable(AppType.Broadcast);
			AudioManager.Instance.PlayBgmByType(SoundType.BGM_horrornoise_B, isLoop: true);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
