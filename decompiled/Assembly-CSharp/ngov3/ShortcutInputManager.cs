using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using Rewired;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Events;
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CCommentSelect_Next_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		private LiveComment _003CtargetComment_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_014c;
				}
				IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Find((IWindow x) => x.appType == AppType.Broadcast);
				if (window != null)
				{
					Live component = window.nakamiApp.GetComponent<Live>();
					List<LiveComment> selectableComments = component.SelectableComments;
					_003CtargetComment_003E5__2 = null;
					if (component.SelectableComments.Count > 0)
					{
						if ((Object)(object)component.SelectingComment == (Object)null)
						{
							_003CtargetComment_003E5__2 = selectableComments[selectableComments.Count - 1];
							component.CommentScrollToLatest();
						}
						else
						{
							for (int num2 = selectableComments.IndexOf(component.SelectingComment) + 1; num2 < selectableComments.Count && num2 <= selectableComments.Count; num2++)
							{
								if (!selectableComments[num2].IsDeleted)
								{
									_003CtargetComment_003E5__2 = selectableComments[num2];
									component.CommentScrollToTarget(_003CtargetComment_003E5__2);
									break;
								}
							}
						}
						YieldAwaitable val2 = UniTask.Yield();
						val = ((YieldAwaitable)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CCommentSelect_Next_003Ed__38>(ref val, ref this);
							return;
						}
						goto IL_014c;
					}
				}
				goto end_IL_0007;
				IL_014c:
				((Awaiter)(ref val)).GetResult();
				if ((Object)(object)_003CtargetComment_003E5__2 != (Object)null)
				{
					UniTaskVoid val3 = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(((Component)_003CtargetComment_003E5__2).transform.position, 0.1f);
					((UniTaskVoid)(ref val3)).Forget();
				}
				end_IL_0007:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003CtargetComment_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CtargetComment_003E5__2 = null;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CCommentSelect_Prev_003Ed__37 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		private LiveComment _003CtargetComment_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0142;
				}
				IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Find((IWindow x) => x.appType == AppType.Broadcast);
				if (window != null)
				{
					Live component = window.nakamiApp.GetComponent<Live>();
					List<LiveComment> selectableComments = component.SelectableComments;
					_003CtargetComment_003E5__2 = null;
					if (component.SelectableComments.Count > 0)
					{
						if ((Object)(object)component.SelectingComment == (Object)null)
						{
							_003CtargetComment_003E5__2 = selectableComments[selectableComments.Count - 1];
							component.CommentScrollToLatest();
						}
						else
						{
							int num2 = selectableComments.IndexOf(component.SelectingComment) - 1;
							while (num2 >= 0 && num2 >= 0)
							{
								if (!selectableComments[num2].IsDeleted)
								{
									_003CtargetComment_003E5__2 = selectableComments[num2];
									component.CommentScrollToTarget(_003CtargetComment_003E5__2);
									break;
								}
								num2--;
							}
						}
						YieldAwaitable val2 = UniTask.Yield();
						val = ((YieldAwaitable)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CCommentSelect_Prev_003Ed__37>(ref val, ref this);
							return;
						}
						goto IL_0142;
					}
				}
				goto end_IL_0007;
				IL_0142:
				((Awaiter)(ref val)).GetResult();
				if ((Object)(object)_003CtargetComment_003E5__2 != (Object)null)
				{
					UniTaskVoid val3 = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(((Component)_003CtargetComment_003E5__2).transform.position, 0.1f);
					((UniTaskVoid)(ref val3)).Forget();
				}
				end_IL_0007:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003CtargetComment_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CtargetComment_003E5__2 = null;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
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
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Cancel"))), (Action<Unit>)delegate
		{
			OnCancelPushed();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Notification Shortcut"))), (Action<Unit>)delegate
		{
			MoveToNotification();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Desktop App Shortcut"))), (Action<Unit>)delegate
		{
			MoveToDesktopIcon();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Start"))), (Action<Unit>)delegate
		{
			OpenStartButton();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("ControllerGuide"))), (Action<Unit>)delegate
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.ShowGuide();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("ControllerGuideLive"))), (Action<Unit>)delegate
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.ShowLiveGuide();
		});
		ReactiveProperty<bool> isCombinationOfLAndR = new ReactiveProperty<bool>(false);
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => !isCombinationOfLAndR.Value)), (Func<Unit, bool>)((Unit _) => _player.GetButtonUp("Window Change Prev"))), (Action<Unit>)delegate
		{
			WindowChangeToPrev();
			ResetSelectIndex();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => !isCombinationOfLAndR.Value)), (Func<Unit, bool>)((Unit _) => _player.GetButtonUp("Window Change Next"))), (Action<Unit>)delegate
		{
			WindowChangeToNext();
			ResetSelectIndex();
		});
		ObservableExtensions.Subscribe<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Action<Unit>)delegate
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
		ObservableExtensions.Subscribe<bool>(Observable.Where<bool>(ReactivePropertyExtensions.SkipLatestValueOnSubscribe<bool>((IReadOnlyReactiveProperty<bool>)(object)isCombinationOfLAndR), (Func<bool, bool>)((bool b) => b)), (Action<bool>)delegate
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
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetAnyButtonDown())), (Action<Unit>)delegate
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
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Item Select Prev"))), (Action<Unit>)delegate
		{
			ItemSelectPrev();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Item Select Next"))), (Action<Unit>)delegate
		{
			ItemSelectNext();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Item Select Up"))), (Action<Unit>)delegate
		{
			ItemSelectVertical();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Item Select Down"))), (Action<Unit>)delegate
		{
			ItemSelectVertical(isPositive: false);
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Item Select Left"))), (Action<Unit>)delegate
		{
			ItemSelectHorizontal(isPositive: false);
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Item Select Right"))), (Action<Unit>)delegate
		{
			ItemSelectHorizontal();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Skip"))), (Action<Unit>)delegate
		{
			MoveToSkip();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("SpeedDown"))), (Action<Unit>)delegate
		{
			SpeedDown();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("SpeedUp"))), (Action<Unit>)delegate
		{
			SpeedUp();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("CommentSelect Prev"))), (Action<Unit>)delegate
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			CommentSelect_Prev();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("CommentSelect Next"))), (Action<Unit>)delegate
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			CommentSelect_Next();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Change Mode D-Pad LR"))), (Action<Unit>)delegate
		{
			List<RuleSet> ruleSets = _player.controllers.maps.layoutManager.ruleSets;
			int num = ruleSets.FindIndex((RuleSet ruleSet) => ruleSet.enabled);
			num = (num + 1) % ruleSets.Count;
			foreach (RuleSet item in ruleSets)
			{
				item.enabled = false;
			}
			ruleSets[num].enabled = true;
			_player.controllers.maps.layoutManager.Apply();
		});
	}

	public void ChangeControllerMode(ControllerMode mode)
	{
		List<RuleSet> ruleSets = _player.controllers.maps.layoutManager.ruleSets;
		foreach (RuleSet item in ruleSets)
		{
			item.enabled = false;
		}
		switch (mode)
		{
		case ControllerMode.Desktop:
			ruleSets.Find((RuleSet ruleSet) => ruleSet.tag == "Item Select LR").enabled = true;
			break;
		case ControllerMode.Haishin:
			ruleSets.Find((RuleSet ruleSet) => ruleSet.tag == "Haishin").enabled = true;
			break;
		case ControllerMode.MV_Playing:
			ruleSets.Find((RuleSet ruleSet) => ruleSet.tag == "MV Playing").enabled = true;
			break;
		}
		_player.controllers.maps.layoutManager.Apply();
	}

	private void OnCancelPushed()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide == (Object)null)
		{
			return;
		}
		UniTaskVoid val;
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.IsShowing)
		{
			val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.CloseButtonPos, 0.1f);
			((UniTaskVoid)(ref val)).Forget();
			return;
		}
		if (_isCancelPushed)
		{
			WindowChangeToNext();
		}
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.FirstOrDefault((IWindow w) => w.activeState == ActiveState.Active);
		if (window != null && (Object)(object)window._close != (Object)null)
		{
			val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(((Component)window._close).transform.position, 0.1f);
			((UniTaskVoid)(ref val)).Forget();
		}
		_isCancelPushed = true;
	}

	private void MoveToNotification()
	{
		if (!((Object)(object)SingletonMonoBehaviour<NotificationManager>.Instance.NotiferParent != (Object)null) || ((Transform)SingletonMonoBehaviour<NotificationManager>.Instance.NotiferParent).childCount <= 0)
		{
			return;
		}
		Transform child = ((Transform)SingletonMonoBehaviour<NotificationManager>.Instance.NotiferParent).GetChild(0);
		if (!((Object)(object)child == (Object)null))
		{
			Notification component = ((Component)child).GetComponent<Notification>();
			if ((Object)(object)component != (Object)null)
			{
				component.clickedAction?.Invoke();
			}
		}
	}

	private void MoveToDesktopIcon()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		ShortcutParent shortcutParent = null;
		Transform val = null;
		UniTaskVoid val2;
		if (((Component)_desktopShortCutParent).GetComponent<CanvasGroup>().interactable)
		{
			if (_desktopShortCutIndex < 0)
			{
				MinimizeWindowsWithoutEssential();
			}
			shortcutParent = _desktopShortCutParent;
		}
		else
		{
			if (!((Component)_desktopHakkyoShortCutParent).GetComponent<CanvasGroup>().interactable)
			{
				if (((Component)_loginShortCut).GetComponent<CanvasGroup>().interactable)
				{
					val = ((Component)_loginShortCut).transform;
					val2 = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(val.position, 0.1f);
					((UniTaskVoid)(ref val2)).Forget();
				}
				else if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Sucide)
				{
					GameObject val3 = GameObject.Find("liveend");
					if ((Object)(object)val3 != (Object)null)
					{
						val2 = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(val3.transform.position, 0.1f);
						((UniTaskVoid)(ref val2)).Forget();
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
		val = shortcutParent.SelectabelObjects[_desktopShortCutIndex].transform;
		val2 = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(val.position, 0.1f);
		((UniTaskVoid)(ref val2)).Forget();
	}

	private void OpenStartButton()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		UniTaskVoid val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(_startButton.position, 0.1f);
		((UniTaskVoid)(ref val)).Forget();
	}

	private void MinimizeAllWindow()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.WindowList.ForEach(delegate(IWindow w)
		{
			if ((w.windowState == WindowState.opened || w.windowState == WindowState.maximized) && (Object)(object)w._minimize != (Object)null && ((Selectable)w._minimize).interactable && w.appType != AppType.Webcam)
			{
				((UnityEvent)w._minimize.onClick).Invoke();
			}
		});
	}

	private void MinimizeWindowsWithoutEssential()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Where((IWindow w) => w.appType != AppType.Webcam && w.appType != AppType.WebcamMini && w.appType != AppType.TaskManager).ToList().ForEach(delegate(IWindow w)
		{
			if (w.windowState == WindowState.opened || w.windowState == WindowState.maximized)
			{
				((UnityEvent)w._minimize.onClick).Invoke();
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
		if ((Object)(object)SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide == (Object)null)
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
			if (!((Object)(object)SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList.ElementAtOrDefault(num) == (Object)null))
			{
				IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList.ElementAtOrDefault(num).window;
				SingletonMonoBehaviour<WindowManager>.Instance.Touched(window);
			}
		}
	}

	private void WindowChangeToNext()
	{
		if ((Object)(object)SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide == (Object)null)
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
			if (!((Object)(object)SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList.ElementAtOrDefault(num) == (Object)null) && (Object)(object)SingletonMonoBehaviour<WindowManager>.Instance.TaskBarList.ElementAtOrDefault(num) != (Object)null)
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
			list.Add(((Component)SingletonMonoBehaviour<NetaManager>.Instance.ChipGetCover.NectButton).gameObject);
			return list;
		}
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.IsShowing)
		{
			return SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.GetSelectableObject();
		}
		if (_startMenu.IsShowIng)
		{
			list.AddRange(from btn in ((Component)_startMenu).GetComponentsInChildren<StartMenuButtonSwitcher>()
				select ((Component)btn).gameObject into obj
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
			list.Add(((Component)activeWindow.nakamiApp.GetComponentsInChildren<Amehead>().First()).gameObject);
			break;
		case AppType.Jine:
			list.AddRange(activeWindow.nakamiApp.GetComponent<JineView2D>().SelectableObjects);
			break;
		case AppType.Asobu:
		case AppType.AsobuNeedy:
		case AppType.AsobuLust:
			list.AddRange(from btn in activeWindow.nakamiApp.GetComponentsInChildren<Button>()
				select ((Component)btn).gameObject);
			break;
		case AppType.Sleep:
			list.AddRange(from btn in activeWindow.nakamiApp.GetComponentsInChildren<Button>()
				select ((Component)btn).gameObject);
			break;
		case AppType.Internet:
		case AppType.Dinder:
		case AppType.Keijiban:
			list.AddRange(from btn in activeWindow.nakamiApp.GetComponentsInChildren<Button>()
				select ((Component)btn).gameObject);
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
				select ((Component)btn).gameObject into obj
				where obj.activeInHierarchy
				select obj);
			break;
		case AppType.MyPicture:
			list.AddRange(from btn in activeWindow.nakamiApp.GetComponentsInChildren<Button>()
				select ((Component)btn).gameObject);
			break;
		case AppType.RebootDialog:
		case AppType.TimePassDialog:
		case AppType.sayonalastDialog:
			list.AddRange(from btn in activeWindow.nakamiApp.GetComponentsInChildren<Button>()
				select ((Component)btn).gameObject);
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
			list.Add(((Component)activeWindow.nakamiApp.GetComponentsInChildren<ActionIdeon>()[0]).gameObject);
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
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		if (_selectIndex < 0 || _selectIndex > selectableObjects.Count)
		{
			_selectIndex = 0;
		}
		else if (--_selectIndex < 0)
		{
			_selectIndex = selectableObjects.Count - 1;
		}
		UniTaskVoid val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjects[_selectIndex].transform.position, 0.1f);
		((UniTaskVoid)(ref val)).Forget();
	}

	private void ItemSelectNext_Normal(List<GameObject> selectableObjects)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if (_selectIndex < 0)
		{
			_selectIndex = 0;
		}
		else if (++_selectIndex >= selectableObjects.Count)
		{
			_selectIndex = 0;
		}
		UniTaskVoid val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjects[_selectIndex].transform.position, 0.1f);
		((UniTaskVoid)(ref val)).Forget();
	}

	private void ItemSelectPrev_NetaChoose(List<GameObject> selectableObjects)
	{
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)selectableObjects[0].GetComponent<NetaChipAlpha>() == (Object)null)
		{
			ItemSelectPrev_Normal(selectableObjects);
			return;
		}
		GameObject val = null;
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
				val = ((Component)component).gameObject;
				break;
			}
		}
		if ((Object)(object)val != (Object)null)
		{
			UniTaskVoid val2 = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjects[_selectIndex].transform.position, 0.1f);
			((UniTaskVoid)(ref val2)).Forget();
		}
	}

	private void ItemSelectNext_NetaChoose(List<GameObject> selectableObjects)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)selectableObjects[0].GetComponent<NetaChipAlpha>() == (Object)null)
		{
			ItemSelectNext_Normal(selectableObjects);
			return;
		}
		GameObject val = null;
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
				val = ((Component)component).gameObject;
				break;
			}
		}
		if ((Object)(object)val != (Object)null)
		{
			UniTaskVoid val2 = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjects[_selectIndex].transform.position, 0.1f);
			((UniTaskVoid)(ref val2)).Forget();
		}
	}

	private void ItemSelectHorizontal(bool isPositive = true)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
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
		UniTaskVoid val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjectsInActiveWindow[_selectIndex].transform.position, 0.1f);
		((UniTaskVoid)(ref val)).Forget();
	}

	private void ItemSelectVertical(bool isPositive = true)
	{
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
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
				UniTaskVoid val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjectsInActiveWindow[_selectIndex].transform.position, 0.1f);
				((UniTaskVoid)(ref val)).Forget();
			}
		}
	}

	private void MoveToSkip()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Find((IWindow x) => x.appType == AppType.Broadcast);
		if (window != null)
		{
			Vector3 position = ((Component)window.nakamiApp.GetComponent<Live>()._HaisinSkip).transform.position;
			UniTaskVoid val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(position, 0.1f);
			((UniTaskVoid)(ref val)).Forget();
		}
	}

	private void SpeedUp()
	{
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Find((IWindow x) => x.appType == AppType.Broadcast);
		if (window != null)
		{
			window.nakamiApp.GetComponent<Live>().ToggleSpeed();
		}
	}

	private void SpeedDown()
	{
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Find((IWindow x) => x.appType == AppType.Broadcast);
		if (window != null)
		{
			window.nakamiApp.GetComponent<Live>().DownSpeed();
		}
	}

	[AsyncStateMachine(typeof(_003CCommentSelect_Prev_003Ed__37))]
	private UniTask CommentSelect_Prev()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_003CCommentSelect_Prev_003Ed__37 _003CCommentSelect_Prev_003Ed__38 = default(_003CCommentSelect_Prev_003Ed__37);
		_003CCommentSelect_Prev_003Ed__38._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CCommentSelect_Prev_003Ed__38._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CCommentSelect_Prev_003Ed__38._003C_003Et__builder)).Start<_003CCommentSelect_Prev_003Ed__37>(ref _003CCommentSelect_Prev_003Ed__38);
		return ((AsyncUniTaskMethodBuilder)(ref _003CCommentSelect_Prev_003Ed__38._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCommentSelect_Next_003Ed__38))]
	private UniTask CommentSelect_Next()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_003CCommentSelect_Next_003Ed__38 _003CCommentSelect_Next_003Ed__39 = default(_003CCommentSelect_Next_003Ed__38);
		_003CCommentSelect_Next_003Ed__39._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CCommentSelect_Next_003Ed__39._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CCommentSelect_Next_003Ed__39._003C_003Et__builder)).Start<_003CCommentSelect_Next_003Ed__38>(ref _003CCommentSelect_Next_003Ed__39);
		return ((AsyncUniTaskMethodBuilder)(ref _003CCommentSelect_Next_003Ed__39._003C_003Et__builder)).Task;
	}
}
