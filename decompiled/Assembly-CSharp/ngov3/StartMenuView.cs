using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ngov3;

public class StartMenuView : MonoBehaviour
{
	[SerializeField]
	private RectTransform _rect;

	[SerializeField]
	private StartButton _startButton;

	[SerializeField]
	private Button _startMenuParent;

	[SerializeField]
	private TMP_Text _logo;

	[SerializeField]
	private TMP_Text _newGameText;

	[SerializeField]
	private Button _newGameButton;

	[SerializeField]
	private Button _loadGameButton;

	[SerializeField]
	private Button _controllerGuideButton;

	[SerializeField]
	private Button _myPictureButton;

	[SerializeField]
	private Button _controllPanelButton;

	[SerializeField]
	private Button _rebootButton;

	[SerializeField]
	private Button _shutDownButton;

	private CanvasGroup _canvasGroup;

	[SerializeField]
	private int _tweenMillisecond = 100;

	private float _fromHeight;

	[SerializeField]
	private Ease _easeType;

	private bool _isShowing;

	private bool _hasSaveData;

	private Vector3 _defaultPosition;

	public bool IsShowIng => _isShowing;

	public StartButton StartButton => _startButton;

	private void Start()
	{
	}

	private void Awake()
	{
		_shutDownButton.gameObject.SetActive(value: true);
		_controllerGuideButton.gameObject.SetActive(value: false);
		_newGameButton.gameObject.SetActive(value: true);
		_loadGameButton.gameObject.SetActive(value: true);
		_defaultPosition = _rect.localPosition;
		_fromHeight = _rect.localPosition.y;
		_canvasGroup = GetComponent<CanvasGroup>();
		_startButton.OnStartButton.Subscribe(delegate
		{
			if (_isShowing)
			{
				OnHide().Forget();
			}
			else
			{
				OnShow().Forget();
			}
		}).AddTo(base.gameObject);
		OnLanguageUpdated();
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
		{
			OnLanguageUpdated();
		}).AddTo(base.gameObject);
		_newGameButton.OnClickAsObservable().Subscribe(delegate
		{
			OnNewGame();
		}).AddTo(base.gameObject);
		_loadGameButton.OnClickAsObservable().Subscribe(delegate
		{
			OnStartGame();
		}).AddTo(base.gameObject);
		if (_controllerGuideButton != null)
		{
			_controllerGuideButton.OnClickAsObservable().Subscribe(delegate
			{
				OnControllerGuide();
			}).AddTo(base.gameObject);
		}
		_myPictureButton.OnClickAsObservable().Subscribe(delegate
		{
			OnShowMyPicture();
		}).AddTo(base.gameObject);
		_controllPanelButton.OnClickAsObservable().Subscribe(delegate
		{
			OnControllPanel();
		}).AddTo(base.gameObject);
		_rebootButton.OnClickAsObservable().Subscribe(delegate
		{
			OnReboot();
		}).AddTo(base.gameObject);
		if (_shutDownButton != null)
		{
			_shutDownButton.OnClickAsObservable().Subscribe(delegate
			{
				OnShutDown();
			}).AddTo(base.gameObject);
		}
		ResetPosition();
	}

	private void OnTitle()
	{
	}

	public async UniTask OnShow()
	{
		ResetPosition();
		_logo.text = NgoEx.SystemTextFromType(SystemTextType.Common_NGO, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_canvasGroup.interactable = true;
		float duration = (float)_tweenMillisecond / 1000f;
		float endValue = _rect.sizeDelta.y + 48f;
		_isShowing = true;
		_rect.DOKill();
		try
		{
			await _rect.DOLocalMoveY(endValue, duration).SetRelative().SetEase(_easeType)
				.Play();
		}
		catch (OperationCanceledException)
		{
			throw;
		}
		catch (NullReferenceException)
		{
			throw;
		}
		catch (MissingReferenceException)
		{
			throw;
		}
		_startMenuParent.gameObject.GetComponent<Image>().raycastTarget = true;
		_startMenuParent.OnClickAsObservable().Subscribe(async delegate
		{
			await OnHide();
		}).AddTo(_startMenuParent.gameObject);
	}

	public async UniTask OnHide()
	{
		_startMenuParent.gameObject.GetComponent<Image>().raycastTarget = false;
		_canvasGroup.interactable = false;
		float duration = (float)_tweenMillisecond / 1000f;
		_rect.DOKill();
		try
		{
			await _rect.DOLocalMoveY(_fromHeight, duration).SetEase(_easeType).Play();
		}
		catch (OperationCanceledException)
		{
			throw;
		}
		catch (NullReferenceException)
		{
			throw;
		}
		catch (MissingReferenceException)
		{
			throw;
		}
		_isShowing = false;
	}

	private async void OnNewGame()
	{
		AudioManager.Instance.StopBgm();
		PostEffectManager.Instance.ResetShader();
		SingletonMonoBehaviour<Settings>.Instance.nowSaveFile = "";
		SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = false;
		AudioManager.Instance.PlaySeByType(SoundType.SE_command_execute);
		await Resources.UnloadUnusedAssets().ToUniTask();
		SceneManager.LoadScene("WindowUITestScene");
	}

	private void OnStartGame()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.LoadData);
		OnHide().Forget();
	}

	private void OnControllPanel()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.ControlPanel);
		OnHide().Forget();
	}

	private void OnShowMyPicture()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.MyPicture);
		OnHide().Forget();
	}

	private async void OnReboot()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.RebootDialog);
		OnHide().Forget();
	}

	private void OnControllerGuide()
	{
		SingletonMonoBehaviour<ControllerGuideManager>.Instance.ForceShowGuide();
		OnHide().Forget();
	}

	private async void OnShutDown()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.ShutDownDialog);
		OnHide().Forget();
	}

	public void OnLanguageUpdated()
	{
		_newGameText.text = (_hasSaveData ? NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Newgame01, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) : NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Newgame00, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		_loadGameButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Continue, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_myPictureButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_MyPicture, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_controllPanelButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Config, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_rebootButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Restart, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_shutDownButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Shutdown, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	private void ResetPosition()
	{
		base.transform.localPosition = _defaultPosition;
	}
}
