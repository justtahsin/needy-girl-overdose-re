using System.Collections.Generic;
using Rewired;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

public class EndingShortcutInputManager : SingletonMonoBehaviour<EndingShortcutInputManager>
{
	private Player _player;

	private EndingOmake _omake;

	private int _selectIndex = -1;

	private new void Awake()
	{
		base.Awake();
		_player = ReInput.players.GetPlayer(0);
		_omake = GameObject.Find("Panel").GetComponent<EndingOmake>();
	}

	private void Start()
	{
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
	}

	private void ItemSelectPrev()
	{
		if (!_omake.ChoosingZip)
		{
			if (_omake.ContinueObj.activeInHierarchy)
			{
				SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(_omake.ContinueObj.transform.position, 0.1f).Forget();
			}
			return;
		}
		List<GameObject> selectableObjects = _omake.SelectableObjects;
		if (selectableObjects.Count > 0)
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
	}

	private void ItemSelectNext()
	{
		if (!_omake.ChoosingZip)
		{
			if (_omake.ContinueObj.activeInHierarchy)
			{
				SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(_omake.ContinueObj.transform.position, 0.1f).Forget();
			}
			return;
		}
		List<GameObject> selectableObjects = _omake.SelectableObjects;
		if (selectableObjects.Count > 0)
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
	}
}
