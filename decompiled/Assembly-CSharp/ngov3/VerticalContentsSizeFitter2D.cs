using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

public class VerticalContentsSizeFitter2D : MonoBehaviour
{
	[SerializeField]
	private RectTransform thisRect;

	[SerializeField]
	private List<RectTransform> childObjects;

	private void Start()
	{
		(from _ in this.UpdateAsObservable()
			select (from to in childObjects
				where to.gameObject.activeSelf
				select to.rect.size).Sum((Vector2 size) => size.y)).DistinctUntilChanged().Subscribe(delegate(float currentHight)
		{
			Vector2 sizeDelta = new Vector2(thisRect.sizeDelta.x, currentHight);
			thisRect.sizeDelta = sizeDelta;
		}).AddTo(base.gameObject);
	}
}
