using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Ending_Meta : NgoEvent
{
	private TMP_Text _jimaku;

	private LanguageType _lang;

	private GameObject _tenWindow;

	private GameObject _tenbody;

	private GameObject _tenhand;

	private Button _button1;

	private Button _button2;

	private IDisposable _disposable;

	protected override void Awake()
	{
		base.Awake();
	}

	private void Update()
	{
		PostEffectManager.Instance.SetShaderWeight(UnityEngine.Random.Range(0.2f, 0.25f));
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Meta;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		_lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		_jimaku = GameObject.Find("EndingCover").transform.Find("jimaku").Find("jimakuText").gameObject.GetComponent<TMP_Text>();
		_tenWindow = GameObject.Find("EndingCover").transform.Find("castwindow").gameObject;
		_tenbody = _tenWindow.transform.GetChild(0).GetChild(1).gameObject;
		_tenhand = GameObject.Find("EndingCover").transform.Find("meta").gameObject;
		_button1 = GameObject.Find("Metacover").transform.Find("Button1").gameObject.GetComponent<Button>();
		_button2 = GameObject.Find("Metacover").transform.Find("Button2").gameObject.GetComponent<Button>();
		PostEffectManager.Instance.ResetShader();
		PostEffectManager.Instance.SetShader(EffectType.Psyche);
		PostEffectManager.Instance.SetShaderWeight(0.2f);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
		SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Jine);
		SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Poketter);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.NetaChoose);
		SingletonMonoBehaviour<CommandManager>.Instance.disableAllCommands();
		SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = true;
		SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.Tension).Value = 20;
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Bank);
		AudioManager.Instance.PlayBgmByType(SoundType.BANK_bank);
		await UniTask.Delay(5000);
		GameObject.Find("ShortCutParent").transform.DORotate(new Vector3(0f, 0f, 1200f), 10f).Play();
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 1f);
		await UniTask.Delay(4000);
		GameObject.Find("MainPanel").GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
		await UniTask.Delay(3000);
		SingletonMonoBehaviour<TaskbarManager>.Instance.TaskBarGroup.alpha = 0f;
		await UniTask.Delay(2000);
		GameObject.Find("Obi").SetActive(value: false);
		await UniTask.Delay(1000);
		await startCast();
	}

	private async UniTask startCast()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Bank);
		_tenWindow.SetActive(value: true);
		_tenbody.transform.DOScale(new Vector3(6f, 6f, 1f), 60f).Play();
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
		GameObject.Find("EndingCover").transform.Find("jimaku").gameObject.SetActive(value: true);
		await Speak(NgoEx.TenTalk("Ending_Meta_Comment001", _lang));
		await Speak(NgoEx.TenTalk("Ending_Meta_Comment002", _lang));
		await Speak(NgoEx.TenTalk("Ending_Meta_Comment003", _lang));
		await Speak(NgoEx.TenTalk("Ending_Meta005", _lang));
		ShowButton1(NgoEx.TenTalk("Ending_Meta006_pi", _lang));
		_disposable = _button1.OnClickAsObservable().Subscribe(async delegate
		{
			_disposable.Dispose();
			_button1.gameObject.SetActive(value: false);
			await Speak(NgoEx.TenTalk("Ending_Meta007", _lang));
			await Speak(NgoEx.TenTalk("Ending_Meta008", _lang));
			await Speak(NgoEx.TenTalk("Ending_Meta009", _lang));
			await Speak(NgoEx.TenTalk("Ending_Meta010", _lang));
			ShowButton1(NgoEx.TenTalk("Ending_Meta011_pi", _lang));
			_disposable = _button1.OnClickAsObservable().Subscribe(async delegate
			{
				_disposable.Dispose();
				_button1.gameObject.SetActive(value: false);
				await Speak(NgoEx.TenTalk("Ending_Meta012", _lang));
				await Speak(NgoEx.TenTalk("Ending_Meta013", _lang));
				ShowButton1(NgoEx.TenTalk("Ending_Meta014_pi", _lang));
				ShowButton2(NgoEx.TenTalk("Ending_Meta015_pi", _lang));
				_disposable = _button1.OnClickAsObservable().Subscribe(delegate
				{
					end();
				}).AddTo(compositeDisposable);
				_disposable = _button2.OnClickAsObservable().Subscribe(delegate
				{
					end();
				}).AddTo(compositeDisposable);
			}).AddTo(compositeDisposable);
		}).AddTo(compositeDisposable);
	}

	private async UniTask end()
	{
		_button1.gameObject.SetActive(value: false);
		_button2.gameObject.SetActive(value: false);
		await Speak(NgoEx.TenTalk("Ending_Meta016", _lang));
		await Speak(NgoEx.TenTalk("Ending_Meta_Comment004", _lang));
		_tenbody.SetActive(value: false);
		_tenhand.SetActive(value: true);
		await Speak(NgoEx.TenTalk("Ending_Meta_Comment005", _lang));
		await UniTask.Delay(Constants.SLOW);
		AchievementStatsUpdater.UpdateStats("Ending_Meta");
		SingletonMonoBehaviour<EventManager>.Instance.CallEnding();
		endEvent();
	}

	private void ShowButton1(string labeltext)
	{
		_button1.GetComponentInChildren<TMP_Text>().text = labeltext;
		_button1.gameObject.SetActive(value: true);
	}

	private void ShowButton2(string labeltext)
	{
		_button2.GetComponentInChildren<TMP_Text>().text = labeltext;
		_button2.gameObject.SetActive(value: true);
	}

	private async UniTask Speak(string nakami)
	{
		_jimaku.text = "";
		float num = 0.3f;
		await _jimaku.DOText(nakami, (float)nakami.Length * num).SetEase(Ease.Linear).Play();
		await UniTask.Delay(Constants.MIDDLE);
	}
}
