using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(VerticalGridLayout2D))]
public class RectSizeSyncVerticalLayoutd2D : MonoBehaviour
{
	private RectTransform rectTransform;

	private VerticalGridLayout2D layout2D;

	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		layout2D = GetComponent<VerticalGridLayout2D>();
		(from _ in this.UpdateAsObservable()
			select layout2D.CurrentHight).DistinctUntilChanged().Subscribe(delegate
		{
			HightSet();
		}).AddTo(base.gameObject);
	}

	[ContextMenu("高さを手動セット")]
	public void HightSet()
	{
		rectTransform.offsetMax = new Vector2(0f, rectTransform.offsetMax.y);
		Vector2 sizeDelta = new Vector2(rectTransform.sizeDelta.x, layout2D.CurrentHight);
		rectTransform.sizeDelta = sizeDelta;
	}
}
