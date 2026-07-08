using System;
using UniRx;
using UnityEngine;

namespace ngov3;

public class PronHorror : SheetView
{
	protected override void Start()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(OnDosed(), (Action<bool>)delegate
		{
			IntReactiveProperty currentDoseCount = _currentDoseCount;
			int value = ((ReactiveProperty<int>)(object)currentDoseCount).Value;
			((ReactiveProperty<int>)(object)currentDoseCount).Value = value + 1;
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)_currentDoseCount, (Action<int>)delegate(int count)
		{
			FetchOverDose(count);
		}), ((Component)this).gameObject);
	}

	private void FetchOverDose(int count)
	{
		if (count > _tekiryou)
		{
			((Component)_odButton).gameObject.SetActive(true);
		}
	}
}
