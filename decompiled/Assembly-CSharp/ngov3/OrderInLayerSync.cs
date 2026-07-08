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
		(from _ in this.UpdateAsObservable()
			select sorting.sortingOrder).DistinctUntilChanged().Subscribe(delegate(int order)
		{
			canvas.sortingOrder = order;
		}).AddTo(base.gameObject);
	}
}
