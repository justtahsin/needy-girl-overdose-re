using System.Collections.Generic;
using System.Linq;
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
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("Cancel")
			select _).Subscribe(delegate
		{
			Cancel();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonDown("ControllerGuide")
			select _).Subscribe(delegate
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.ShowGuide();
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
			where _player.GetButtonUp("Window Change Prev")
			select _).Subscribe(delegate
		{
			WindowChangeToPrev();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetButtonUp("Window Change Next")
			select _).Subscribe(delegate
		{
			WindowChangeToNext();
		});
		(from _ in this.UpdateAsObservable()
			where _player.GetAnyButton()
			select _).Subscribe(delegate
		{
			if (!_player.GetButton("Item Select Prev") && !_player.GetButton("Item Select Next"))
			{
				_selectIndex = -1;
			}
		});
	}

	private void Cancel()
	{
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.IsShowing)
		{
			SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(SingletonMonoBehaviour<ControllerGuideManager>.Instance.Guide.CloseButtonPos, 0.1f).Forget();
			return;
		}
		if (SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Count > 0)
		{
			IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.FirstOrDefault((IWindow w) => w.activeState == ActiveState.Active);
			SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(window._close.transform.position, 0.1f).Forget();
			return;
		}
		GameObject cancelObject = _boot.GetCancelObject();
		if (cancelObject != null)
		{
			SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(cancelObject.transform.position, 0.1f).Forget();
		}
	}

	private void ItemSelectPrev()
	{
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
			SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(list[_selectIndex].transform.position, 0.1f).Forget();
		}
	}

	private void ItemSelectNext()
	{
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
			SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(list[_selectIndex].transform.position, 0.1f).Forget();
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
