using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
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
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Item Select Prev"))), (Action<Unit>)delegate
		{
			ItemSelectPrev();
		});
		ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => _player.GetButtonDown("Item Select Next"))), (Action<Unit>)delegate
		{
			ItemSelectNext();
		});
	}

	private void ItemSelectPrev()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		UniTaskVoid val;
		if (!_omake.ChoosingZip)
		{
			if (_omake.ContinueObj.activeInHierarchy)
			{
				val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(_omake.ContinueObj.transform.position, 0.1f);
				((UniTaskVoid)(ref val)).Forget();
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
			val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjects[_selectIndex].transform.position, 0.1f);
			((UniTaskVoid)(ref val)).Forget();
		}
	}

	private void ItemSelectNext()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		UniTaskVoid val;
		if (!_omake.ChoosingZip)
		{
			if (_omake.ContinueObj.activeInHierarchy)
			{
				val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(_omake.ContinueObj.transform.position, 0.1f);
				((UniTaskVoid)(ref val)).Forget();
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
			val = SingletonMonoBehaviour<CursorManager>.Instance.MoveToAsync(selectableObjects[_selectIndex].transform.position, 0.1f);
			((UniTaskVoid)(ref val)).Forget();
		}
	}
}
