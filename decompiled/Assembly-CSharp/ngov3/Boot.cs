using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ngov3;

public class Boot : MonoBehaviour
{
	[SerializeField]
	private Button ButtonToTestScene;

	[SerializeField]
	private CanvasGroup Bios;

	[SerializeField]
	private GameObject NSO;

	[SerializeField]
	private CanvasGroup biosBooting;

	[SerializeField]
	private TMP_Text bootingText;

	[SerializeField]
	private CanvasGroup Splash;

	[SerializeField]
	private Image BootImage;

	[SerializeField]
	private Sprite enBoot;

	[SerializeField]
	private CanvasGroup Login;

	[SerializeField]
	private RectTransform openControlPanel;

	[SerializeField]
	private GameObject Hint;

	[SerializeField]
	private Transform endingParent;

	[SerializeField]
	private GameObject _achievedBlock;

	[SerializeField]
	private GameObject _unachievedBlock;

	[SerializeField]
	private Button liveGenButton;

	[SerializeField]
	private CanvasGroup Caution;

	[SerializeField]
	private TMP_Text Caution_Header;

	[SerializeField]
	private TMP_Text Caution_Nakami;

	[SerializeField]
	private TMP_Text Caution_Ok;

	[SerializeField]
	private TMP_Text Caution_Cancel;

	[SerializeField]
	private Button Ok;

	[SerializeField]
	private Button Cancel;

	[SerializeField]
	private CanvasGroup ChooseUser;

	[SerializeField]
	private Button Data1;

	[SerializeField]
	private Button Data2;

	[SerializeField]
	private Button Data3;

	[SerializeField]
	private Button Data0;

	[SerializeField]
	private Sprite ame;

	[SerializeField]
	private Sprite ten;

	[SerializeField]
	private CanvasGroup ChooseDay;

	[SerializeField]
	private Image DataIcon;

	[SerializeField]
	private TMP_Text _Hyouji;

	[SerializeField]
	private Button Back;

	[SerializeField]
	private TMP_Dropdown days;

	[SerializeField]
	private Button StartButton;

	[SerializeField]
	private Button NewAccount;

	[SerializeField]
	private string chosenDay = "";

	[SerializeField]
	private CanvasGroup Welcome;

	[SerializeField]
	private Image WelcomeIcon;

	[SerializeField]
	private TMP_Text WelcomeText;

	private Sequence biosSequence;

	private Sequence splashSequence;

	private string beforeText = "";

	private AsyncOperation asyncLoad;

	private bool assetLoadComplete;

	[SerializeField]
	private Texture2D playstationCoursor;

	private List<GameObject> endingBlocks = new List<GameObject>();

	public void Awake()
	{
		DisposeManager();
		AudioManager.Instance.StopAll();
		CleanEnds();
	}

	private void DisposeManager()
	{
		if (PostEffectManager.Instance != null)
		{
			PostEffectManager.Instance.Dispose();
		}
	}

	public async void Start()
	{
		Debug.Log("Start1");
		liveGenButton.gameObject.SetActive(value: true);
		(from _ in this.UpdateAsObservable()
			select SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value).DistinctUntilChanged().Skip(1).Subscribe(delegate(LanguageType lang)
		{
			ChangeLanguage(lang);
		})
			.AddTo(base.gameObject);
		if (ButtonToTestScene != null)
		{
			ButtonToTestScene.OnClickAsObservable().Subscribe(delegate
			{
				OnDebugButtonClicked();
			}).AddTo(base.gameObject);
		}
		Debug.Log("Start2");
		if (SaveRelayer.IsSettingDataExists())
		{
			SingletonMonoBehaviour<Settings>.Instance.Load();
			if (SingletonMonoBehaviour<Settings>.Instance.adieu)
			{
				SingletonMonoBehaviour<Settings>.Instance.saveNumber = 0;
				SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = true;
				SingletonMonoBehaviour<Settings>.Instance.nowSaveFile = "Data0_Day30" + SaveRelayer.EXTENTION;
				SceneManager.LoadScene("WindowUITestScene");
			}
			if (SingletonMonoBehaviour<Settings>.Instance.mitaEnd.Contains(EndingType.Ending_Grand) && SingletonMonoBehaviour<Settings>.Instance.mitaEnd.Contains(EndingType.Ending_Happy))
			{
				Hint.SetActive(value: true);
			}
			List<EndingType> list = SingletonMonoBehaviour<Settings>.Instance.mitaEnd.Distinct().ToList();
			list.Remove(EndingType.Ending_NetShut);
			if (list.Count >= 24)
			{
				Data0.gameObject.SetActive(value: true);
			}
		}
		else
		{
			if (Application.systemLanguage == SystemLanguage.Japanese)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.JP);
			}
			else if (Application.systemLanguage == SystemLanguage.Korean)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.KO);
			}
			else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.TW);
			}
			else if (Application.systemLanguage == SystemLanguage.Vietnamese)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.VN);
			}
			else if (Application.systemLanguage == SystemLanguage.Chinese || Application.systemLanguage == SystemLanguage.ChineseSimplified)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.CN);
			}
			else if (Application.systemLanguage == SystemLanguage.French)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.FR);
			}
			else if (Application.systemLanguage == SystemLanguage.Italian)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.IT);
			}
			else if (Application.systemLanguage == SystemLanguage.German)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.GE);
			}
			else if (Application.systemLanguage == SystemLanguage.Spanish)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.SP);
			}
			else if (Application.systemLanguage == SystemLanguage.Russian)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.RU);
			}
			else
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.EN);
			}
			SingletonMonoBehaviour<Settings>.Instance.SetResolution();
			SingletonMonoBehaviour<Settings>.Instance.Save();
		}
		ShowEnds();
		Debug.Log("Start3");
		Bios.gameObject.GetComponent<Button>().OnClickAsObservable().Subscribe(delegate
		{
			onClickBios();
		})
			.AddTo(base.gameObject);
		Splash.gameObject.GetComponent<Button>().OnClickAsObservable().Subscribe(delegate
		{
			onClickSplash();
		})
			.AddTo(base.gameObject);
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate(LanguageType lang)
		{
			SetCaution(lang);
		}).AddTo(base.gameObject);
		NSO.SetActive(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN);
		SingletonMonoBehaviour<Settings>.Instance.AddCreditImage();
		Login.gameObject.SetActive(value: false);
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursorShowHide(show: false);
		Debug.Log("Start4");
		await BootOS();
	}

	private void onClickBios()
	{
		Debug.Log("onClickBios");
		if (assetLoadComplete)
		{
			Debug.Log("onClickBios:assetLoadComplete");
			biosSequence.Kill(complete: true);
		}
	}

	private void onClickSplash()
	{
		Debug.Log("onClickSplash");
		if (assetLoadComplete)
		{
			Debug.Log("onClickSplash:assetLoadComplete");
			splashSequence.Kill(complete: true);
		}
	}

	public async UniTask BootOS()
	{
		Debug.Log("BootOS:1");
		float num = 3f;
		float waitInBios = 8f;
		float waitInSplash = 7f;
		UniTask loadAssetTask = LoadAssets();
		if (!LoadAppData.IsAppDataExist())
		{
			Bios.alpha = 0f;
			await UniTask.Delay(Mathf.FloorToInt(num * 1000f));
			Bios.alpha = 1f;
		}
		if (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN)
		{
			BootImage.gameObject.GetComponent<Image>().sprite = enBoot;
		}
		biosSequence = DOTween.Sequence().OnStart(delegate
		{
			AudioManager.Instance.StopAll();
			AudioManager.Instance.PlaySeByType(SoundType.SE_BIOS_piko);
			Bios.alpha = 1f;
		}).AppendInterval(1.4f)
			.AppendCallback(delegate
			{
				AudioManager.Instance.PlaySeByType(SoundType.SE_BIOS_HDD);
			})
			.Append(bootingText.DOText("Booting Windose20.............................", waitInBios).SetEase(Ease.OutQuad));
		await biosSequence.Play();
		Bios.gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
		Bios.alpha = 0f;
		Bios.interactable = false;
		Bios.blocksRaycasts = false;
		Bios.gameObject.SetActive(value: false);
		Debug.Log("BootOS:2");
		splashSequence = DOTween.Sequence().AppendCallback(delegate
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_Boot);
		}).Append(Splash.DOFade(1f, 2.2f))
			.AppendInterval(waitInSplash)
			.Append(Splash.DOFade(0f, 0.2f));
		await splashSequence.Play();
		await loadAssetTask;
		Debug.Log("アセットのロードが完了しました");
		Splash.interactable = false;
		Splash.blocksRaycasts = false;
		Splash.gameObject.SetActive(value: false);
		AudioManager.Instance.StopByType(SoundType.SE_Boot);
		Login.gameObject.SetActive(value: true);
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursorShowHide(show: true);
		SingletonMonoBehaviour<CursorManager>.Instance.MoveCursorToCenter();
		waitAccept();
	}

	private void waitAccept()
	{
		Debug.Log("waitAccept:1");
		AudioManager.Instance.PlaySeByType(SoundType.SE_Boot_Caution);
		AudioManager.Instance.PlayBgmById("BGM_OP_PV");
		Login.alpha = 1f;
		Login.interactable = true;
		ChooseDay.alpha = 0f;
		ChooseDay.interactable = false;
		ChooseDay.blocksRaycasts = false;
		ChooseUser.alpha = 0f;
		ChooseUser.interactable = false;
		ChooseUser.blocksRaycasts = false;
		Welcome.alpha = 0f;
		Welcome.interactable = false;
		Welcome.blocksRaycasts = false;
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance != null)
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = true;
		}
		Debug.Log("waitAccept:2");
		SetCaution(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		Ok.OnClickAsObservable().Subscribe(delegate
		{
			Debug.Log("waitAccept:3");
			openControlPanel.anchoredPosition = new Vector2(50f, -60f);
			WaitChooseUser();
		}).AddTo(Ok);
		Cancel.OnClickAsObservable().Subscribe(delegate
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
			Application.Quit();
		}).AddTo(Cancel);
		Cancel.gameObject.SetActive(value: true);
		Data1.OnClickAsObservable().Subscribe(delegate
		{
			WaitChooseDay(1);
		}).AddTo(Data1);
		Data2.OnClickAsObservable().Subscribe(delegate
		{
			WaitChooseDay(2);
		}).AddTo(Data2);
		Data3.OnClickAsObservable().Subscribe(delegate
		{
			WaitChooseDay(3);
		}).AddTo(Data3);
		Debug.Log("waitAccept:END");
	}

	private void WaitChooseUser()
	{
		AudioManager.Instance.StopByType(SoundType.SE_BIOS_HDD);
		AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
		Caution.alpha = 0f;
		Caution.interactable = false;
		Caution.blocksRaycasts = false;
		Caution.gameObject.SetActive(value: false);
		ChooseDay.alpha = 0f;
		ChooseDay.interactable = false;
		ChooseDay.blocksRaycasts = false;
		Welcome.alpha = 0f;
		Welcome.interactable = false;
		Welcome.blocksRaycasts = false;
		ChooseUser.alpha = 1f;
		ChooseUser.interactable = true;
		ChooseUser.blocksRaycasts = true;
		if (SaveRelayer.IsSlotDataExists("Data1_Day1" + SaveRelayer.EXTENTION))
		{
			Data1.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = ten;
		}
		else
		{
			Data1.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = ame;
		}
		if (SaveRelayer.IsSlotDataExists("Data2_Day1" + SaveRelayer.EXTENTION))
		{
			Data2.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = ten;
		}
		else
		{
			Data2.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = ame;
		}
		if (SaveRelayer.IsSlotDataExists("Data3_Day1" + SaveRelayer.EXTENTION))
		{
			Data3.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = ten;
		}
		else
		{
			Data3.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = ame;
		}
	}

	private void SetCaution(LanguageType lang)
	{
		Caution_Header.text = NgoEx.SystemTextFromType(SystemTextType.System_caution_title, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		Caution_Nakami.text = NgoEx.SystemTextFromType(SystemTextType.System_caution, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		Caution_Ok.text = NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		Caution_Cancel.text = NgoEx.SystemTextFromType(SystemTextType.Dialog_Cancell, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	private void WaitChooseDay(int _DataNumber)
	{
		Caution.alpha = 0f;
		Caution.interactable = false;
		Caution.blocksRaycasts = false;
		ChooseUser.alpha = 0f;
		ChooseUser.interactable = false;
		ChooseUser.blocksRaycasts = false;
		Welcome.alpha = 0f;
		Welcome.interactable = false;
		Welcome.blocksRaycasts = false;
		ChooseDay.alpha = 1f;
		ChooseDay.interactable = true;
		ChooseDay.blocksRaycasts = true;
		SingletonMonoBehaviour<Settings>.Instance.saveNumber = _DataNumber;
		AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
		Back.gameObject.GetComponentInChildren<TMP_Text>().text = "◀";
		_Hyouji.text = $"Data{_DataNumber}";
		SetChosenDayText(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value, _DataNumber);
		setChosenDay();
		IDisposable disp0 = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate(LanguageType lang)
		{
			SetChosenDayText(lang, _DataNumber);
		}).AddTo(base.gameObject);
		IDisposable disp1 = NewAccount.OnClickAsObservable().Subscribe(async delegate
		{
			await StartGame(_DataNumber);
		}).AddTo(base.gameObject);
		IDisposable disp2 = (from _ in StartButton.OnClickAsObservable()
			where chosenDay == "Day1"
			select _).Subscribe(async delegate
		{
			await StartGame(_DataNumber);
		}).AddTo(base.gameObject);
		IDisposable disp3 = (from _ in StartButton.OnClickAsObservable()
			where chosenDay != "Day1"
			select _).Subscribe(async delegate
		{
			await Resume(_DataNumber, $"Data{_DataNumber}_{chosenDay}");
		}).AddTo(base.gameObject);
		Back.OnClickAsObservable().Subscribe(delegate
		{
			days.onValueChanged.RemoveAllListeners();
			disp0.Dispose();
			disp1.Dispose();
			disp2.Dispose();
			disp3.Dispose();
			WaitChooseUser();
		}).AddTo(Back);
	}

	private void SetChosenDayText(LanguageType lang, int _DataNumber)
	{
		days.options.Clear();
		for (int num = 30; num >= 2; num--)
		{
			if (SaveRelayer.IsSlotDataExists($"Data{_DataNumber}_Day{num}{SaveRelayer.EXTENTION}"))
			{
				days.options.Add(new TMP_Dropdown.OptionData
				{
					text = NgoEx.DayText(num, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)
				});
			}
		}
		days.options.Add(new TMP_Dropdown.OptionData
		{
			text = NgoEx.DayText(1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)
		});
		days.RefreshShownValue();
		if (SaveRelayer.IsSlotDataExists($"Data{_DataNumber}_Day1{SaveRelayer.EXTENTION}"))
		{
			DataIcon.sprite = ten;
			NewAccount.gameObject.SetActive(value: true);
			NewAccount.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Newgame01, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			StartButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Continue, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else
		{
			DataIcon.sprite = ame;
			NewAccount.gameObject.SetActive(value: false);
			StartButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Newgame00, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
	}

	private void setChosenDay()
	{
		chosenDay = "Day" + Regex.Replace(days.options[days.value].text, "[^0-9]", "");
		days.onValueChanged.AddListener(delegate
		{
			chosenDay = "Day" + Regex.Replace(days.options[days.value].text, "[^0-9]", "");
		});
	}

	private async UniTask Resume(int datanum, string datapath)
	{
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursorShowHide(show: false);
		await showWelcome();
		SingletonMonoBehaviour<Settings>.Instance.saveNumber = datanum;
		SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = true;
		SingletonMonoBehaviour<Settings>.Instance.nowSaveFile = datapath + SaveRelayer.EXTENTION;
		await Resources.UnloadUnusedAssets().ToUniTask();
		SceneManager.LoadSceneAsync("WindowUITestScene");
	}

	private async UniTask showWelcome(bool startover = false)
	{
		ChooseDay.alpha = 0f;
		ChooseDay.interactable = false;
		ChooseDay.blocksRaycasts = false;
		Welcome.alpha = 1f;
		Welcome.interactable = true;
		Welcome.blocksRaycasts = true;
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance != null)
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = false;
		}
		WelcomeText.text = NgoEx.SystemTextFromType(SystemTextType.Window_Welcome, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		AudioManager.Instance?.StopBgm();
		AudioManager.Instance?.PlaySeByType(SoundType.SE_command_execute);
		if (!startover)
		{
			WelcomeIcon.sprite = ten;
		}
		else
		{
			WelcomeIcon.sprite = ame;
			await WelcomeIcon.gameObject.transform.DOScale(new Vector3(0f, 2f, 1f), 0.2f).Play();
			WelcomeIcon.sprite = ten;
			await WelcomeIcon.gameObject.transform.DOScale(new Vector3(2f, 2f, 1f), 0.2f).Play();
		}
		await UniTask.Delay(Constants.FAST);
	}

	private async UniTask StartGame(int saveNumber)
	{
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursorShowHide(show: false);
		await showWelcome(startover: true);
		SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = false;
		SingletonMonoBehaviour<Settings>.Instance.saveNumber = saveNumber;
		await Resources.UnloadUnusedAssets().ToUniTask();
		SceneManager.LoadScene("WindowUITestScene");
	}

	private void CleanEnds()
	{
		foreach (GameObject endingBlock in endingBlocks)
		{
			UnityEngine.Object.Destroy(endingBlock);
		}
		endingBlocks = new List<GameObject>();
	}

	private void ShowEnds()
	{
		List<EndingType> mitaEnd = SingletonMonoBehaviour<Settings>.Instance.mitaEnd;
		string id;
		foreach (EndingType value in Enum.GetValues(typeof(EndingType)))
		{
			if (value != EndingType.Ending_None && value != EndingType.Ending_Completed && value != EndingType.Ending_NetShut)
			{
				EndingMaster.Param param = NgoEx.EndingFromType(value);
				id = param.Id;
				NgoEx.SetEndingTextByLanguage(param, out var endName, out var endJisseki);
				if (mitaEnd.Exists((EndingType gotend) => gotend.ToString() == id))
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(_achievedBlock, endingParent);
					gameObject.GetComponent<TooltipCaller>().isShowTooltip = true;
					gameObject.GetComponent<TooltipCaller>().textNakami = endName + "\n" + endJisseki;
					endingBlocks.Add(gameObject);
				}
				else
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(_unachievedBlock, endingParent);
					gameObject2.GetComponent<TooltipCaller>().isShowTooltip = true;
					gameObject2.GetComponent<TooltipCaller>().textNakami = endName + "\n" + endJisseki;
					endingBlocks.Add(gameObject2);
				}
			}
		}
	}

	private void ChangeLanguage(LanguageType lang)
	{
		CleanEnds();
		ShowEnds();
	}

	private async UniTask LoadAssets()
	{
		Debug.Log("LoadAssets");
		new CancellationTokenSource();
		await LoadAppData.LoadAppDataAsset();
		assetLoadComplete = true;
		Debug.Log("assetLoadComplete!!");
	}

	public List<GameObject> GetSelectableObjects()
	{
		List<GameObject> list = new List<GameObject>();
		if (SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Count > 0)
		{
			IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.FirstOrDefault((IWindow w) => w.activeState == ActiveState.Active);
			switch (window.appType)
			{
			case AppType.ControlPanel:
				list = window.nakamiApp.GetComponent<ControllPanelView>().GetSelectableObjects();
				break;
			case AppType.MyPicture:
				list.AddRange(from btn in window.nakamiApp.GetComponentsInChildren<Button>()
					select btn.gameObject);
				break;
			case AppType.LastEnd:
				list.AddRange(window.nakamiApp.GetComponent<adieuDialog>().SelectableObjects);
				break;
			}
		}
		else if (Caution.interactable)
		{
			list.Add(Ok.gameObject);
		}
		else if (ChooseUser.interactable)
		{
			list.Add(Data1.gameObject);
			list.Add(Data2.gameObject);
			list.Add(Data3.gameObject);
		}
		else if (ChooseDay.interactable && !days.GetComponentInChildren<ScrollRect>(includeInactive: false))
		{
			list.Add(StartButton.gameObject);
			list.Add(days.gameObject);
		}
		return list;
	}

	public GameObject GetCancelObject()
	{
		if (ChooseDay.interactable && SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Count <= 0)
		{
			return Back.gameObject;
		}
		return null;
	}

	public void OnDebugButtonClicked()
	{
		SingletonMonoBehaviour<Settings>.Instance.saveNumber = 4;
		SceneManager.LoadScene("Window2DTestScene");
	}
}
