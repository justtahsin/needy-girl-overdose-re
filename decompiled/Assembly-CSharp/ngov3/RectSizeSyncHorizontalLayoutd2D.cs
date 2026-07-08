using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(HorizontalGridLayout2D))]
public class RectSizeSyncHorizontalLayoutd2D : MonoBehaviour
{
	private RectTransform rectTransform;

	private HorizontalGridLayout2D layout2D;

	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		layout2D = GetComponent<HorizontalGridLayout2D>();
		(from _ in this.UpdateAsObservable()
			select layout2D.CurrentWidth).DistinctUntilChanged().Subscribe(delegate
		{
			WidthSet();
		}).AddTo(base.gameObject);
	}

	private void WidthSet()
	{
		Vector2 sizeDelta = new Vector2(layout2D.CurrentWidth, rectTransform.sizeDelta.y);
		rectTransform.sizeDelta = sizeDelta;
	}
}
