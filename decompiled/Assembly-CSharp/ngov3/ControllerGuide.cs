using System.Collections.Generic;
using DG.Tweening;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ControllerGuide : MonoBehaviour
{
	public enum TabType
	{
		Desktop,
		Live,
		Login
	}

	[SerializeField]
	private CanvasGroup _group;

	[Header("Buttons")]
	[SerializeField]
	private Button _closeButton;

	[SerializeField]
	private Button _desktopTabButton;

	[SerializeField]
	private Button _liveTabButton;

	[SerializeField]
	private Button _loginTabButton;

	[Header("Tabs")]
	[SerializeField]
	private Transform _desktopTab;

	[SerializeField]
	private Transform _liveTab;

	[SerializeField]
	private Transform _loginTab;

	[Header("Contents")]
	[SerializeField]
	private GameObject _desktopContent;

	[SerializeField]
	private GameObject _liveContent;

	[SerializeField]
	private GameObject _loginContent;

	private Live _activeLiveApp;

	private bool _isShowing;

	private Sequence _showCloseSequence;

	public Live ActiveLiveApp
	{
		get
		{
			return _activeLiveApp;
		}
		set
		{
			_activeLiveApp = value;
		}
	}

	public bool IsShowing => _isShowing;

	public Vector3 CloseButtonPos => _closeButton.transform.position;

	private void Awake()
	{
		_closeButton.OnClickAsObservable().Subscribe(delegate
		{
			CloseGuide();
		}).AddTo(this);
		_desktopTabButton.OnClickAsObservable().Subscribe(delegate
		{
			SetTab(TabType.Desktop);
		}).AddTo(this);
		_liveTabButton.OnClickAsObservable().Subscribe(delegate
		{
			SetTab(TabType.Live);
		}).AddTo(this);
		_loginTabButton.OnClickAsObservable().Subscribe(delegate
		{
			SetTab(TabType.Login);
		}).AddTo(this);
		CloseGuideImmediate();
	}

	public void ChangeState(TabType tab)
	{
		if (_isShowing)
		{
			CloseGuide();
		}
		else
		{
			ShowGuide(tab);
		}
	}

	private void ShowGuide(TabType tab)
	{
		SetTab(tab);
		SetHaishinPause(pause: true);
		ChangeControllerModeOnLive(ShortcutInputManager.ControllerMode.Desktop);
		_isShowing = true;
		AudioManager.Instance.PlaySeByType(SoundType.SE_pop_tutorial);
		StopSequence();
		_showCloseSequence = DOTween.Sequence().OnStart(delegate
		{
			_group.alpha = 0f;
			_group.interactable = false;
			_group.blocksRaycasts = true;
		}).Append(_group.DOFade(1f, 0.4f))
			.AppendCallback(delegate
			{
				_group.interactable = true;
				_showCloseSequence = null;
			})
			.Play();
	}

	private void SetTab(TabType tab)
	{
		switch (tab)
		{
		case TabType.Desktop:
			_desktopContent.SetActive(value: true);
			_liveContent.SetActive(value: false);
			_loginContent.SetActive(value: false);
			_desktopTab.SetAsLastSibling();
			break;
		case TabType.Live:
			_desktopContent.SetActive(value: false);
			_liveContent.SetActive(value: true);
			_loginContent.SetActive(value: false);
			_liveTab.SetAsLastSibling();
			break;
		case TabType.Login:
			_desktopContent.SetActive(value: false);
			_liveContent.SetActive(value: false);
			_loginContent.SetActive(value: true);
			_loginTab.SetAsLastSibling();
			break;
		default:
			_desktopContent.SetActive(value: true);
			_liveContent.SetActive(value: false);
			_loginContent.SetActive(value: false);
			_desktopTab.SetAsLastSibling();
			break;
		}
		SetText(tab);
	}

	protected virtual void SetText(TabType tab)
	{
	}

	private void CloseGuide()
	{
		_isShowing = false;
		StopSequence();
		_showCloseSequence = DOTween.Sequence().OnStart(delegate
		{
			_group.interactable = false;
			_group.blocksRaycasts = true;
		}).Append(_group.DOFade(0f, 0.2f))
			.OnComplete(delegate
			{
				_group.blocksRaycasts = false;
				SetHaishinPause(pause: false);
				ChangeControllerModeOnLive(ShortcutInputManager.ControllerMode.Haishin);
				_showCloseSequence = null;
			})
			.SetAutoKill(autoKillOnCompletion: false)
			.Play();
	}

	public void CloseGuideImmediate()
	{
		_isShowing = false;
		StopSequence();
		_group.interactable = false;
		_group.blocksRaycasts = false;
		_group.alpha = 0f;
		SetHaishinPause(pause: false);
		ChangeControllerModeOnLive(ShortcutInputManager.ControllerMode.Haishin);
	}

	private void StopSequence()
	{
		if (_showCloseSequence != null)
		{
			_showCloseSequence.Kill();
			_showCloseSequence = null;
		}
	}

	private void SetHaishinPause(bool pause)
	{
		if (_activeLiveApp != null)
		{
			_activeLiveApp.NowPlaying.isPause = pause;
		}
	}

	private void ChangeControllerModeOnLive(ShortcutInputManager.ControllerMode mode)
	{
		if ((bool)_activeLiveApp)
		{
			SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(mode);
		}
	}

	public List<GameObject> GetSelectableObject()
	{
		return new List<GameObject> { _desktopTabButton.gameObject, _liveTabButton.gameObject, _loginTabButton.gameObject };
	}

	public void ChangeTabNext()
	{
		if (_desktopContent.activeInHierarchy)
		{
			SetTab(TabType.Live);
		}
		else if (_liveContent.activeInHierarchy)
		{
			SetTab(TabType.Login);
		}
	}

	public void ChangeTabPreview()
	{
		if (_liveContent.activeInHierarchy)
		{
			SetTab(TabType.Desktop);
		}
		else if (_loginContent.activeInHierarchy)
		{
			SetTab(TabType.Live);
		}
	}
}
