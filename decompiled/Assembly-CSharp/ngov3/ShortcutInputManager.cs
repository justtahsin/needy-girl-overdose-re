using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using NGO;
using Rewired;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ShortcutInputManager : SingletonMonoBehaviour<ShortcutInputManager>
{
	public enum ControllerMode
	{
		Desktop,
		Haishin,
		MV_Playing
	}

	private Player _player;

	private int _selectIndex = -1;

	private StartMenuView _startMenu;

	private Transform _startButton;

	private int _desktopShortCutIndex = -1;

	private ShortcutParent _desktopShortCutParent;

	private ShortcutParent _desktopHakkyoShortCutParent;

	private ShortcutParent _loginShortCut;

	private bool _isCancelPushed;

	public Player Player => _player;

	protected override void Awake()
	{
		base.Awake();
		_player = ReInput.players.GetPlayer(0);
		_desktopShortCutParent = GameObject.Find("ShortCutParent").GetComponent<ShortcutParent>();
		_desktopHakkyoShortCutParent = GameObject.Find("HakkyoShortCutParent").GetComponent<ShortcutParent>();
		_loginShortCut = GameObject.Find("LoginShortCut").GetComponent<ShortcutParent>();
		_startMenu = GameObject.Find("StartMenu").GetComponent<StartMenuView>();
		_startButton = GameObject.Find("StartButton").transform;
	}

	private void Start()
	{
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("Cancel")
			select _).Subscribe(delegate
		{
			OnCancelPushed();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("Notification Shortcut")
			select _).Subscribe(delegate
		{
			MoveToNotification();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("Desktop App Shortcut")
			select _).Subscribe(delegate
		{
			MoveToDesktopIcon();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("Start")
			select _).Subscribe(delegate
		{
			OpenStartButton();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("ControllerGuide")
			select _).Subscribe(delegate
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.ShowGuide();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("ControllerGuideLive")
			select _).Subscribe(delegate
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.ShowLiveGuide();
		});
		ReactiveProperty<bool> isCombinationOfLAndR = new ReactiveProperty<bool>(initialValue: false);
		(from _ in this.UpdateAsObservable()
			where !isCombinationOfLAndR.Value
			where _player.GetButtonUp("Window Change Prev")
			select _).Subscribe(delegate
		{
			WindowChangeToPrev();
			ResetSelectIndex();
		});
		(from _ in this.UpdateAsObservable()
			where !isCombinationOfLAndR.Value
			where _player.GetButtonUp("Window Change Next")
			select _).Subscribe(delegate
		{
			WindowChangeToNext();
			ResetSelectIndex();
		});
		this.UpdateAsObservable().Subscribe(delegate
		{
			if (isCombinationOfLAndR.Value)
			{
				isCombinationOfLAndR.Value = _player.GetButton("Window Change Prev") || _player.GetButton("Window Change Next");
			}
			else
			{
				isCombinationOfLAndR.Value = _player.GetButton("Window Change Prev") && _player.GetButton("Window Change Next");
			}
		});
		(from b in isCombinationOfLAndR.SkipLatestValueOnSubscribe()
			where b
			select b).Subscribe(delegate
		{
			if (SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Where((IWindow w) => w.appType != AppType.Webcam).Any((IWindow w) => w.windowState == WindowState.opened || w.windowState == WindowState.maximized))
			{
				MinimizeAllWindow();
			}
			else
			{
				PopAllWindow();
			}
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetAnyButtonDown()
			select _).Subscribe(delegate
		{
			if (_isCancelPushed && !_player.GetButton("Cancel"))
			{
				_isCancelPushed = false;
			}
			if (_desktopShortCutIndex >= 0 && !_player.GetButton("Desktop App Shortcut"))
			{
				_desktopShortCutIndex = -1;
			}
			if (_selectIndex >= 0 && !_player.GetButtonDown("Item Select Prev") && !_player.GetButtonDown("Item Select Next"))
			{
				_selectIndex = -1;
			}
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("Item Select Prev")
			select _).Subscribe(delegate
		{
			ItemSelectPrev();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("Item Select Next")
			select _).Subscribe(delegate
		{
			ItemSelectNext();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("Item Select Up")
			select _).Subscribe(delegate
		{
			ItemSelectVertical();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("Item Select Down")
			select _).Subscribe(delegate
		{
			ItemSelectVertical(isPositive: false);
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("Item Select Left")
			select _).Subscribe(delegate
		{
			ItemSelectHorizontal(isPositive: false);
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("Item Select Right")
			select _).Subscribe(delegate
		{
			ItemSelectHorizontal();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("Skip")
			select _).Subscribe(delegate
		{
			MoveToSkip();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("SpeedDown")
			select _).Subscribe(delegate
		{
			SpeedDown();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("SpeedUp")
			select _).Subscribe(delegate
		{
			SpeedUp();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("CommentSelect Prev")
			select _).Subscribe(delegate
		{
			CommentSelect_Prev();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("CommentSelect Next")
			select _).Subscribe(delegate
		{
			CommentSelect_Next();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("Change Mode D-Pad LR")
			select _).Subscribe(delegate
		{
			List<ControllerMapLayoutManager.RuleSet> ruleSets = _player.controllers.maps.layoutManager.ruleSets;
			int num = ruleSets.FindIndex((ControllerMapLayoutManager.RuleSet ruleSet) => ruleSet.enabled);
			num = (num + 1) % ruleSets.Count;
			foreach (ControllerMapLayoutManager.RuleSet item in ruleSets)
			{
				item.enabled = false;
			}
			ruleSets[num].enabled = true;
			_player.controllers.maps.layoutManager.Apply();
		});
	}

	public void ChangeControllerMode(ControllerMode mode)
	{
		List<ControllerMapLayoutManager.RuleSet> ruleSets = _player.controllers.maps.layoutManager.ruleSets;
		foreach (ControllerMapLayoutManager.RuleSet item in ruleSets)
		{
			item.enabled = false;
		}
		switch (mode)
		{
		case ControllerMode.Desktop:
			ruleSets.Find((ControllerMapLayoutManager.RuleSet ruleSet) => ruleSet.tag == "Item Select LR").enabled = true;
			break;
		case ControllerMode.Haishin:
			ruleSets.Find((ControllerMapLayoutManager.RuleSet ruleSet) => ruleSet.tag == "Haishin").enabled = true;
			break;
		case ControllerMode.MV_Playing:
			ruleSets.Find((ControllerMapLayoutManager.RuleSet ruleSet) => ruleSet.tag == "MV Playing").enabled = true;
			break;
		}
		_player.controllers.maps.layoutManager.Apply();
	}

	private void OnCancelPushed()
	{
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide == null)
		{
			return;
		}
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.IsShowing)
		{
			SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.CloseButtonPos, 0.1f).Forget();
			return;
		}
		if (_isCancelPushed)
		{
			WindowChangeToNext();
		}
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.FirstOrDefault((IWindow w) => w.activeState == ActiveState.Active);
		if (window != null && window._close != null)
		{
			SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(window._close.transform.position, 0.1f).Forget();
		}
		_isCancelPushed = true;
	}

	private void MoveToNotification()
	{
		if (!(SingletonMonoBehaviour<NotificationManager>.Instance.NotiferParent != null) || SingletonMonoBehaviour<NotificationManager>.Instance.NotiferParent.childCount <= 0)
		{
			return;
		}
		Transform child = SingletonMonoBehaviour<NotificationManager>.Instance.NotiferParent.GetChild(0);
		if (!(child == null))
		{
			Notification component = child.GetComponent<Notification>();
			if (component != null)
			{
				component.clickedAction?.Invoke();
			}
		}
	}

	private void MoveToDesktopIcon()
	{
		ShortcutParent shortcutParent = null;
		Transform transform = null;
		if (_desktopShortCutParent.GetComponent<CanvasGroup>().interactable)
		{
			if (_desktopShortCutIndex < 0)
			{
				MinimizeWindowsWithoutEssential();
			}
			shortcutParent = _desktopShortCutParent;
		}
		else
		{
			if (!_desktopHakkyoShortCutParent.GetComponent<CanvasGroup>().interactable)
			{
				if (_loginShortCut.GetComponent<CanvasGroup>().interactable)
				{
					transform = _loginShortCut.transform;
					SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(transform.position, 0.1f).Forget();
				}
				else if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Sucide)
				{
					GameObject gameObject = GameObject.Find("liveend");
					if (gameObject != null)
					{
						SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(gameObject.transform.position, 0.1f).Forget();
					}
				}
				return;
			}
			shortcutParent = _desktopHakkyoShortCutParent;
		}
		_desktopShortCutIndex++;
		if (_desktopShortCutIndex >= shortcutParent.SelectabelObjects.Count)
		{
			_desktopShortCutIndex = 0;
		}
		transform = shortcutParent.SelectabelObjects[_desktopShortCutIndex].transform;
		SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(transform.position, 0.1f).Forget();
	}

	private void OpenStartButton()
	{
		SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(_startButton.position, 0.1f).Forget();
	}

	private void MinimizeAllWindow()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.WindowList.ForEach(delegate(IWindow w)
		{
			if ((w.windowState == WindowState.opened || w.windowState == WindowState.maximized) && w._minimize != null && w._minimize.interactable && w.appType != AppType.Webcam)
			{
				w._minimize.onClick.Invoke();
			}
		});
	}

	private void MinimizeWindowsWithoutEssential()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Where((IWindow w) => w.appType != AppType.Webcam && w.appType != AppType.WebcamMini && w.appType != AppType.TaskManager).ToList().ForEach(delegate(IWindow w)
		{
			if (w.windowState == WindowState.opened || w.windowState == WindowState.maximized)
			{
				w._minimize.onClick.Invoke();
			}
		});
	}

	private void PopAllWindow()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Where((IWindow w) => w.appType != AppType.Webcam && w.appType != AppType.WebcamMini).ToList().ForEach(delegate(IWindow w)
		{
			w.Pop();
			SingletonMonoBehaviour<WindowManager>.Instance.getTaskbarByWindow(SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList, w).Pop();
		});
		SingletonMonoBehaviour<WindowManager>.Instance.ActivateFirst();
	}

	private void WindowChangeToPrev()
	{
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide == null)
		{
			return;
		}
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.IsShowing)
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.ChangeTabPreview();
		}
		else if (SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList != null)
		{
			int num = SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList.FindIndex((TaskButton t) => t.window.activeState == ActiveState.Active);
			if (--num < 0)
			{
				num = SingletonMonoBehaviour<WindowManager>.Instance.Count() - 1;
			}
			if (!(SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList.ElementAtOrDefault(num) == null))
			{
				IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList.ElementAtOrDefault(num).window;
				SingletonMonoBehaviour<WindowManager>.Instance.Touched(window);
			}
		}
	}

	private void WindowChangeToNext()
	{
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide == null)
		{
			return;
		}
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.IsShowing)
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.ChangeTabNext();
		}
		else if (SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList != null)
		{
			int num = SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList.FindIndex((TaskButton t) => t.window.activeState == ActiveState.Active);
			if (++num >= SingletonMonoBehaviour<WindowManager>.Instance.Count())
			{
				num = 0;
			}
			if (!(SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList.ElementAtOrDefault(num) == null) && SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList.ElementAtOrDefault(num) != null)
			{
				IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList.ElementAtOrDefault(num).window;
				SingletonMonoBehaviour<WindowManager>.Instance.Touched(window);
			}
		}
	}

	private void ResetSelectIndex()
	{
		_selectIndex = -1;
	}

	private List<GameObject> GetSelectableObjectsInActiveWindow(IWindow activeWindow)
	{
		List<GameObject> list = new List<GameObject>();
		if (SingletonMonoBehaviour<NetaManager>.Instance.ChipGetCover.isGetting.Value)
		{
			list.Add(SingletonMonoBehaviour<NetaManager>.Instance.ChipGetCover.NectButton.gameObject);
			return list;
		}
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.IsShowing)
		{
			return SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.GetSelectableObject();
		}
		if (_startMenu.IsShowIng)
		{
			list.AddRange(from btn in _startMenu.GetComponentsInChildren<StartMenuButtonSwitcher>()
				select btn.gameObject into obj
				where obj.activeInHierarchy
				select obj);
			return list;
		}
		if (SingletonMonoBehaviour<MetaCanvas>.Instance.IsShowing)
		{
			list.AddRange(SingletonMonoBehaviour<MetaCanvas>.Instance.SelectableObjects);
			return list;
		}
		if (activeWindow == null || activeWindow.windowState == WindowState.minimized || activeWindow.windowState == WindowState.closed)
		{
			return list;
		}
		switch (activeWindow.appType)
		{
		case AppType.Webcam:
			list.Add(activeWindow.nakamiApp.GetComponentsInChildren<Amehead>().First().gameObject);
			break;
		case AppType.Jine:
			list.AddRange(activeWindow.nakamiApp.GetComponent<JineView2D>().SelectableObjects);
			break;
		case AppType.Asobu:
		case AppType.AsobuNeedy:
		case AppType.AsobuLust:
			list.AddRange(from btn in activeWindow.nakamiApp.GetComponentsInChildren<Button>()
				select btn.gameObject);
			break;
		case AppType.Sleep:
			list.AddRange(from btn in activeWindow.nakamiApp.GetComponentsInChildren<Button>()
				select btn.gameObject);
			break;
		case AppType.Internet:
		case AppType.Dinder:
		case AppType.Keijiban:
			list.AddRange(from btn in activeWindow.nakamiApp.GetComponentsInChildren<Button>()
				select btn.gameObject);
			break;
		case AppType.GoOut:
			list.AddRange(activeWindow.nakamiApp.GetComponent<Odekake>().SelectableObjects.Where((GameObject obj) => obj.activeInHierarchy));
			break;
		case AppType.NetaChoose:
			list.AddRange(activeWindow.nakamiApp.GetComponent<NetachipChooser>().SelectableObjects);
			break;
		case AppType.PillDypass:
		case AppType.PillPuron:
		case AppType.PillHipron:
		case AppType.PillHappa:
		case AppType.PillPsyche:
			list.AddRange(from btn in activeWindow.nakamiApp.GetComponentsInChildren<Button>()
				select btn.gameObject into obj
				where obj.activeInHierarchy
				select obj);
			break;
		case AppType.MyPicture:
			list.AddRange(from btn in activeWindow.nakamiApp.GetComponentsInChildren<Button>()
				select btn.gameObject);
			break;
		case AppType.RebootDialog:
		case AppType.TimePassDialog:
		case AppType.sayonalastDialog:
			list.AddRange(from btn in activeWindow.nakamiApp.GetComponentsInChildren<Button>()
				select btn.gameObject);
			break;
		case AppType.ControlPanel:
			list.AddRange(activeWindow.nakamiApp.GetComponent<ControllPanelView>().GetSelectableObjects());
			break;
		case AppType.Login:
			list.Add(activeWindow.nakamiApp.GetComponent<Login>().LoginButtonObj);
			break;
		case AppType.Die:
			list.AddRange(activeWindow.nakamiApp.GetComponent<Dielog>().SelectableObejcts);
			break;
		case AppType.Hakkyo:
			list.AddRange(activeWindow.nakamiApp.GetComponent<HakkyoDialog>().SelectableObjects);
			break;
		case AppType.EndingDialog:
			list.Add(activeWindow.nakamiApp.GetComponent<EndingDialog>().SubmitButtonObject);
			break;
		case AppType.Ideon_taiki:
			list.Add(activeWindow.nakamiApp.GetComponentsInChildren<ActionIdeon>()[0].gameObject);
			break;
		}
		return list;
	}

	private void ItemSelectPrev()
	{
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.FirstOrDefault((IWindow w) => w.activeState == ActiveState.Active);
		List<GameObject> selectableObjectsInActiveWindow = GetSelectableObjectsInActiveWindow(window);
		if (selectableObjectsInActiveWindow.Count <= 0)
		{
			return;
		}
		if (window == null)
		{
			ItemSelectPrev_Normal(selectableObjectsInActiveWindow);
		}
		else if (window.appType == AppType.NetaChoose)
		{
			if (window.nakamiApp.GetComponent<NetachipChooser>().status == ChoosingStatus.go)
			{
				ItemSelectPrev_Normal(selectableObjectsInActiveWindow);
			}
			else
			{
				ItemSelectPrev_NetaChoose(selectableObjectsInActiveWindow);
			}
		}
		else
		{
			ItemSelectPrev_Normal(selectableObjectsInActiveWindow);
		}
	}

	private void ItemSelectNext()
	{
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.FirstOrDefault((IWindow w) => w.activeState == ActiveState.Active);
		List<GameObject> selectableObjectsInActiveWindow = GetSelectableObjectsInActiveWindow(window);
		if (selectableObjectsInActiveWindow.Count <= 0)
		{
			return;
		}
		if (window == null)
		{
			ItemSelectNext_Normal(selectableObjectsInActiveWindow);
		}
		else if (window.appType == AppType.NetaChoose)
		{
			if (window.nakamiApp.GetComponent<NetachipChooser>().status == ChoosingStatus.go)
			{
				ItemSelectNext_Normal(selectableObjectsInActiveWindow);
			}
			else
			{
				ItemSelectNext_NetaChoose(selectableObjectsInActiveWindow);
			}
		}
		else
		{
			ItemSelectNext_Normal(selectableObjectsInActiveWindow);
		}
	}

	private void ItemSelectPrev_Normal(List<GameObject> selectableObjects)
	{
		if (_selectIndex < 0 || _selectIndex > selectableObjects.Count)
		{
			_selectIndex = 0;
		}
		else if (--_selectIndex < 0)
		{
			_selectIndex = selectableObjects.Count - 1;
		}
		SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjects[_selectIndex].transform.position, 0.1f).Forget();
	}

	private void ItemSelectNext_Normal(List<GameObject> selectableObjects)
	{
		if (_selectIndex < 0)
		{
			_selectIndex = 0;
		}
		else if (++_selectIndex >= selectableObjects.Count)
		{
			_selectIndex = 0;
		}
		SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjects[_selectIndex].transform.position, 0.1f).Forget();
	}

	private void ItemSelectPrev_NetaChoose(List<GameObject> selectableObjects)
	{
		if (selectableObjects[0].GetComponent<NetaChipAlpha>() == null)
		{
			ItemSelectPrev_Normal(selectableObjects);
			return;
		}
		GameObject gameObject = null;
		for (int i = 0; i < selectableObjects.Count; i++)
		{
			if (_selectIndex < 0 || _selectIndex > selectableObjects.Count)
			{
				_selectIndex = 0;
			}
			else if (--_selectIndex < 0)
			{
				_selectIndex = selectableObjects.Count - 1;
			}
			NetaChipAlpha component = selectableObjects[_selectIndex].GetComponent<NetaChipAlpha>();
			if (component.IsChoosable)
			{
				gameObject = component.gameObject;
				break;
			}
		}
		if (gameObject != null)
		{
			SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjects[_selectIndex].transform.position, 0.1f).Forget();
		}
	}

	private void ItemSelectNext_NetaChoose(List<GameObject> selectableObjects)
	{
		if (selectableObjects[0].GetComponent<NetaChipAlpha>() == null)
		{
			ItemSelectNext_Normal(selectableObjects);
			return;
		}
		GameObject gameObject = null;
		for (int i = 0; i < selectableObjects.Count; i++)
		{
			if (_selectIndex < 0)
			{
				_selectIndex = 0;
			}
			else if (++_selectIndex >= selectableObjects.Count)
			{
				_selectIndex = 0;
			}
			NetaChipAlpha component = selectableObjects[_selectIndex].GetComponent<NetaChipAlpha>();
			if (component.IsChoosable)
			{
				gameObject = component.gameObject;
				break;
			}
		}
		if (gameObject != null)
		{
			SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjects[_selectIndex].transform.position, 0.1f).Forget();
		}
	}

	private void ItemSelectHorizontal(bool isPositive = true)
	{
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.FirstOrDefault((IWindow w) => w.activeState == ActiveState.Active);
		List<GameObject> selectableObjectsInActiveWindow = GetSelectableObjectsInActiveWindow(window);
		if (selectableObjectsInActiveWindow.Count == 0)
		{
			return;
		}
		switch (window.appType)
		{
		case AppType.Internet:
			return;
		case AppType.NetaChoose:
			if (window.nakamiApp.GetComponent<NetachipChooser>().status == ChoosingStatus.go)
			{
				return;
			}
			break;
		}
		_selectIndex = (isPositive ? (_selectIndex + 1) : (_selectIndex - 1));
		_selectIndex = Mathf.Clamp(_selectIndex, 0, selectableObjectsInActiveWindow.Count - 1);
		SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjectsInActiveWindow[_selectIndex].transform.position, 0.1f).Forget();
	}

	private void ItemSelectVertical(bool isPositive = true)
	{
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.FirstOrDefault((IWindow w) => w.activeState == ActiveState.Active);
		List<GameObject> selectableObjectsInActiveWindow = GetSelectableObjectsInActiveWindow(window);
		if (selectableObjectsInActiveWindow.Count != 0)
		{
			int num = window.appType switch
			{
				AppType.Webcam => 1, 
				AppType.Internet => 1, 
				AppType.NetaChoose => (window.nakamiApp.GetComponent<NetachipChooser>().status != ChoosingStatus.alpha) ? 1 : 2, 
				AppType.Jine => 4, 
				AppType.MyPicture => 4, 
				_ => 0, 
			};
			if (num > 0)
			{
				_selectIndex = (isPositive ? (_selectIndex - num) : (_selectIndex + num));
				_selectIndex = Mathf.Clamp(_selectIndex, 0, selectableObjectsInActiveWindow.Count - 1);
				SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjectsInActiveWindow[_selectIndex].transform.position, 0.1f).Forget();
			}
		}
	}

	private void MoveToSkip()
	{
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Find((IWindow x) => x.appType == AppType.Broadcast);
		if (window != null)
		{
			Vector3 position = window.nakamiApp.GetComponent<Live>()._HaisinSkip.transform.position;
			SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(position, 0.1f).Forget();
		}
	}

	private void SpeedUp()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Find((IWindow x) => x.appType == AppType.Broadcast)?.nakamiApp.GetComponent<Live>().ToggleSpeed();
	}

	private void SpeedDown()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Find((IWindow x) => x.appType == AppType.Broadcast)?.nakamiApp.GetComponent<Live>().DownSpeed();
	}

	private async UniTask CommentSelect_Prev()
	{
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Find((IWindow x) => x.appType == AppType.Broadcast);
		if (window == null)
		{
			return;
		}
		Live component = window.nakamiApp.GetComponent<Live>();
		List<LiveComment> selectableComments = component.SelectableComments;
		LiveComment targetComment = null;
		if (component.SelectableComments.Count <= 0)
		{
			return;
		}
		if (component.SelectingComment == null)
		{
			targetComment = selectableComments[selectableComments.Count - 1];
			component.CommentScrollToLatest();
		}
		else
		{
			int num = selectableComments.IndexOf(component.SelectingComment) - 1;
			while (num >= 0 && num >= 0)
			{
				if (!selectableComments[num].IsDeleted)
				{
					targetComment = selectableComments[num];
					component.CommentScrollToTarget(targetComment);
					break;
				}
				num--;
			}
		}
		await UniTask.Yield();
		if (targetComment != null)
		{
			SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(targetComment.transform.position, 0.1f).Forget();
		}
	}

	private async UniTask CommentSelect_Next()
	{
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Find((IWindow x) => x.appType == AppType.Broadcast);
		if (window == null)
		{
			return;
		}
		Live component = window.nakamiApp.GetComponent<Live>();
		List<LiveComment> selectableComments = component.SelectableComments;
		LiveComment targetComment = null;
		if (component.SelectableComments.Count <= 0)
		{
			return;
		}
		if (component.SelectingComment == null)
		{
			targetComment = selectableComments[selectableComments.Count - 1];
			component.CommentScrollToLatest();
		}
		else
		{
			for (int num = selectableComments.IndexOf(component.SelectingComment) + 1; num < selectableComments.Count && num <= selectableComments.Count; num++)
			{
				if (!selectableComments[num].IsDeleted)
				{
					targetComment = selectableComments[num];
					component.CommentScrollToTarget(targetComment);
					break;
				}
			}
		}
		await UniTask.Yield();
		if (targetComment != null)
		{
			SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(targetComment.transform.position, 0.1f).Forget();
		}
	}
}
