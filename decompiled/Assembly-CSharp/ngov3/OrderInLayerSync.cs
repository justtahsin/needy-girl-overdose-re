using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Rendering;

namespace ngov3;

public class OrderInLayerSync : MonoBehaviour
{
	[SerializeField]
	private SortingGroup sorting;

	[SerializeField]
	private Canvas canvas;

	private void Start()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.DistinctUntilChanged<int>(Observable.Select<Unit, int>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, int>)((Unit _) => sorting.sortingOrder))), (Action<int>)delegate(int order)
		{
			canvas.sortingOrder = order;
		}), ((Component)this).gameObject);
	}
}
