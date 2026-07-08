using System;
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

	public Vector3 CloseButtonPos => ((Component)_closeButton).transform.position;

	private void Awake()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_closeButton), (Action<Unit>)delegate
		{
			CloseGuide();
		}), (Component)(object)this);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_desktopTabButton), (Action<Unit>)delegate
		{
			SetTab(TabType.Desktop);
		}), (Component)(object)this);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_liveTabButton), (Action<Unit>)delegate
		{
			SetTab(TabType.Live);
		}), (Component)(object)this);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_loginTabButton), (Action<Unit>)delegate
		{
			SetTab(TabType.Login);
		}), (Component)(object)this);
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
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		SetTab(tab);
		SetHaishinPause(pause: true);
		ChangeControllerModeOnLive(ShortcutInputManager.ControllerMode.Desktop);
		_isShowing = true;
		AudioManager.Instance.PlaySeByType(SoundType.SE_pop_tutorial);
		StopSequence();
		_showCloseSequence = TweenExtensions.Play<Sequence>(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Append(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
		{
			_group.alpha = 0f;
			_group.interactable = false;
			_group.blocksRaycasts = true;
		}), (Tween)(object)DOTweenModuleUI.DOFade(_group, 1f, 0.4f)), (TweenCallback)delegate
		{
			_group.interactable = true;
			_showCloseSequence = null;
		}));
	}

	private void SetTab(TabType tab)
	{
		switch (tab)
		{
		case TabType.Desktop:
			_desktopContent.SetActive(true);
			_liveContent.SetActive(false);
			_loginContent.SetActive(false);
			_desktopTab.SetAsLastSibling();
			break;
		case TabType.Live:
			_desktopContent.SetActive(false);
			_liveContent.SetActive(true);
			_loginContent.SetActive(false);
			_liveTab.SetAsLastSibling();
			break;
		case TabType.Login:
			_desktopContent.SetActive(false);
			_liveContent.SetActive(false);
			_loginContent.SetActive(true);
			_loginTab.SetAsLastSibling();
			break;
		default:
			_desktopContent.SetActive(true);
			_liveContent.SetActive(false);
			_loginContent.SetActive(false);
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
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		_isShowing = false;
		StopSequence();
		_showCloseSequence = TweenExtensions.Play<Sequence>(TweenSettingsExtensions.SetAutoKill<Sequence>(TweenSettingsExtensions.OnComplete<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
		{
			_group.interactable = false;
			_group.blocksRaycasts = true;
		}), (Tween)(object)DOTweenModuleUI.DOFade(_group, 0f, 0.2f)), (TweenCallback)delegate
		{
			_group.blocksRaycasts = false;
			SetHaishinPause(pause: false);
			ChangeControllerModeOnLive(ShortcutInputManager.ControllerMode.Haishin);
			_showCloseSequence = null;
		}), false));
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
			TweenExtensions.Kill((Tween)(object)_showCloseSequence, false);
			_showCloseSequence = null;
		}
	}

	private void SetHaishinPause(bool pause)
	{
		if ((Object)(object)_activeLiveApp != (Object)null)
		{
			_activeLiveApp.NowPlaying.isPause = pause;
		}
	}

	private void ChangeControllerModeOnLive(ShortcutInputManager.ControllerMode mode)
	{
		if (Object.op_Implicit((Object)(object)_activeLiveApp))
		{
			SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(mode);
		}
	}

	public List<GameObject> GetSelectableObject()
	{
		return new List<GameObject>
		{
			((Component)_desktopTabButton).gameObject,
			((Component)_liveTabButton).gameObject,
			((Component)_loginTabButton).gameObject
		};
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
