using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(RectTransform))]
public class RectSizeSyncSpriteRendererSizeExtensions : MonoBehaviour
{
	[SerializeField]
	private RectSizeSyncPivot rectSizeSyncPivot;

	public RectSizeSyncPivot RectSizeSyncPivot => rectSizeSyncPivot;

	public void SetRectSizeSyncPivot(RectSizeSyncPivot rectSizeSyncPivot)
	{
		this.rectSizeSyncPivot = rectSizeSyncPivot;
	}

	private void Start()
	{
		RectTransform rectTransform = GetComponent<RectTransform>();
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		Vector2 prevSize = rectTransform.rect.size;
		(from _ in this.UpdateAsObservable()
			select rectTransform.rect.size).DistinctUntilChanged().Subscribe(delegate(Vector2 size)
		{
			float num = prevSize.x - size.x;
			float num2 = prevSize.y - size.y;
			sprite.size = size;
			switch (rectSizeSyncPivot)
			{
			case RectSizeSyncPivot.LEFT:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x - num / 2f, rectTransform.anchoredPosition.y);
				break;
			case RectSizeSyncPivot.RIGHT:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + num / 2f, rectTransform.anchoredPosition.y);
				break;
			case RectSizeSyncPivot.TOP:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + num2 / 2f);
				break;
			case RectSizeSyncPivot.BOTTOM:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - num2 / 2f);
				break;
			case RectSizeSyncPivot.TOP_LEFT:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x - num / 2f, rectTransform.anchoredPosition.y + num2 / 2f);
				break;
			case RectSizeSyncPivot.TOP_RIGHT:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + num / 2f, rectTransform.anchoredPosition.y + num2 / 2f);
				break;
			case RectSizeSyncPivot.BOTTOM_LEFT:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x - num / 2f, rectTransform.anchoredPosition.y - num2 / 2f);
				break;
			case RectSizeSyncPivot.BOTTOM_RIGHT:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + num / 2f, rectTransform.anchoredPosition.y - num2 / 2f);
				break;
			}
			prevSize = size;
		}).AddTo(base.gameObject);
	}
}
