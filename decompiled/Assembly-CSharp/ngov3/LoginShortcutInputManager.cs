using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Rewired;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

public class LoginShortcutInputManager : SingletonMonoBehaviour<LoginShortcutInputManager>
{
	private Player _player;

	private Boot _boot;

	private int _selectIndex = -1;

	private new void Awake()
	{
		base.Awake();
		_player = ReInput.players.GetPlayer(0);
		_boot = GameObject.Find("Panel").GetComponent<Boot>();
	}

	private void Start()
	{
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Cancel"))), (Action<Unit>)delegate
		{
			Cancel();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("ControllerGuide"))), (Action<Unit>)delegate
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.ShowGuide();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Item Select Prev"))), (Action<Unit>)delegate
		{
			ItemSelectPrev();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Item Select Next"))), (Action<Unit>)delegate
		{
			ItemSelectNext();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonUp("Window Change Prev"))), (Action<Unit>)delegate
		{
			WindowChangeToPrev();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonUp("Window Change Next"))), (Action<Unit>)delegate
		{
			WindowChangeToNext();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetAnyButton())), (Action<Unit>)delegate
		{
			if (!_player.GetButton("Item Select Prev") && !_player.GetButton("Item Select Next"))
			{
				_selectIndex = -1;
			}
		});
	}

	private void Cancel()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		UniTaskVoid val;
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.IsShowing)
		{
			val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.CloseButtonPos, 0.1f);
			((UniTaskVoid)(ref val)).Forget();
			return;
		}
		if (SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Count > 0)
		{
			IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.FirstOrDefault((IWindow w) => w.activeState == ActiveState.Active);
			val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(((Component)window._close).transform.position, 0.1f);
			((UniTaskVoid)(ref val)).Forget();
			return;
		}
		GameObject cancelObject = _boot.GetCancelObject();
		if ((Object)(object)cancelObject != (Object)null)
		{
			val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(cancelObject.transform.position, 0.1f);
			((UniTaskVoid)(ref val)).Forget();
		}
	}

	private void ItemSelectPrev()
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		List<GameObject> list = null;
		list = ((!SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.IsShowing) ? _boot.GetSelectableObjects() : SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.GetSelectableObject());
		if (list.Count > 0)
		{
			if (_selectIndex < 0 || _selectIndex > list.Count)
			{
				_selectIndex = 0;
			}
			else if (--_selectIndex < 0)
			{
				_selectIndex = list.Count - 1;
			}
			UniTaskVoid val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(list[_selectIndex].transform.position, 0.1f);
			((UniTaskVoid)(ref val)).Forget();
		}
	}

	private void ItemSelectNext()
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		List<GameObject> list = null;
		list = ((!SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.IsShowing) ? _boot.GetSelectableObjects() : SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.GetSelectableObject());
		if (list.Count > 0)
		{
			if (_selectIndex < 0)
			{
				_selectIndex = 0;
			}
			else if (++_selectIndex >= list.Count)
			{
				_selectIndex = 0;
			}
			UniTaskVoid val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(list[_selectIndex].transform.position, 0.1f);
			((UniTaskVoid)(ref val)).Forget();
		}
	}

	private void WindowChangeToPrev()
	{
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.IsShowing)
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.ChangeTabPreview();
		}
	}

	private void WindowChangeToNext()
	{
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.IsShowing)
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.ChangeTabNext();
		}
	}
}
