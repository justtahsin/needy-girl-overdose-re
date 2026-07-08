using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace ngov3;

public class Scenario_horror_day5_day : NgoEvent
{
	private Transform panel;

	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.isHorror = true;
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_horrornoise_A, isLoop: true);
		GameObject.Find("MainPanel").GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
		GameObject.Find("InvertVolume").GetComponent<Volume>().enabled = true;
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.TaskManager);
		HaishinFirstAnimation.LoadHaishinFirstAnimation().Forget();
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0.2f);
		GameObject.Find("HakkyoShortCutParent").GetComponent<CanvasGroup>().alpha = 0f;
		GameObject.Find("HakkyoShortCutParent").GetComponent<CanvasGroup>().interactable = false;
		GameObject.Find("HakkyoShortCutParent").GetComponent<CanvasGroup>().blocksRaycasts = false;
		PostEffectManager.Instance.SetShader(EffectType.SatujinNoise);
		PostEffectManager.Instance.SetShaderWeight(0.02f);
		panel = GameObject.Find("MainPanel").transform;
		GameObject.Find("MainPanel").GetComponent<RectMask2D>().enabled = false;
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE002);
		panel.localScale = new Vector3(1f, -1f, 1f);
		await NgoEvent.DelaySkippable(50);
		panel.localScale = new Vector3(1f, 1f, 1f);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE003);
		PostEffectManager.Instance.SetShaderWeight(0f);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE005);
		PostEffectManager.Instance.SetShaderWeight(0.05f);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE006);
		panel.localScale = new Vector3(1f, -1f, 1f);
		await NgoEvent.DelaySkippable(10);
		panel.localScale = new Vector3(1f, 1f, 1f);
		PostEffectManager.Instance.SetShaderWeight(0f);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day5_LINE006_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day5_LINE006_pi).Subscribe(async delegate
		{
			PostEffectManager.Instance.SetShaderWeight(0.05f);
			eventContinue1();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue1()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE007);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE008);
		PostEffectManager.Instance.SetShaderWeight(0f);
		panel.localScale = new Vector3(1f, -1f, 1f);
		await NgoEvent.DelaySkippable(10);
		panel.localScale = new Vector3(1f, 1f, 1f);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE009);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day5_LINE009_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day5_LINE009_pi).Subscribe(async delegate
		{
			await eventContinue2();
		}).AddTo(compositeDisposable);
	}

	private async UniTask eventContinue2()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE010);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE011);
		PostEffectManager.Instance.SetShaderWeight(0.02f);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE012);
		PostEffectManager.Instance.SetShaderWeight(0f);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE013);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE014);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day5_LINE014_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day5_LINE014_pi).Subscribe(async delegate
		{
			panel.localScale = new Vector3(1f, -1f, 1f);
			await NgoEvent.DelaySkippable(100);
			panel.localScale = new Vector3(1f, 1f, 1f);
			await NgoEvent.DelaySkippable(100);
			panel.localScale = new Vector3(1f, -1f, 1f);
			await NgoEvent.DelaySkippable(100);
			panel.localScale = new Vector3(1f, 1f, 1f);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue3();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue3()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE015);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE016);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE017);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day5_LINE017_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day5_LINE017_pi).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE018);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue4();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue4()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE019);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE020);
		PostEffectManager.Instance.SetShaderWeight(0.02f);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE021);
		PostEffectManager.Instance.SetShaderWeight(0f);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE022);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE023);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day5_LINE023_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day5_LINE023_pi).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE024);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue5();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue5()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE025);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day5_LINE026);
		PostEffectManager.Instance.SetShaderWeight(0.02f);
		PostEffectManager.Instance.SetShader(EffectType.Yugami);
		float weight = 0f;
		await DOTween.To(() => weight, delegate(float x)
		{
			PostEffectManager.Instance.SetShaderWeight(x);
		}, 1f, 2.2f).SetEase(Ease.OutExpo).Play();
		SingletonMonoBehaviour<StatusManager>.Instance.timePassing(2);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		GameObject.Find("EndingCover").transform.Find("water").gameObject.SetActive(value: false);
		PostEffectManager.Instance.ResetShader();
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_KowaiInternet;
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Action_HaishinDark>();
		endEvent();
	}
}
