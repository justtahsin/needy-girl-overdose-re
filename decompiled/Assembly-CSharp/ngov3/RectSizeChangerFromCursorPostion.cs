using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(RectSizeSyncSpriteRendererSizeExtensions))]
[RequireComponent(typeof(RectTransform))]
public class RectSizeChangerFromCursorPostion : MonoBehaviour
{
	private Vector2 prevCursorPostion;

	private RectSizeSyncPivot prevRectSizeSyncPivot;

	private RectTransform rect;

	private RectSizeSyncSpriteRendererSizeExtensions rectSizeSyncSpriteRendererSizeExtensions;

	[SerializeField]
	private float changeAmount = 1f;

	private void Start()
	{
		rect = GetComponent<RectTransform>();
		rectSizeSyncSpriteRendererSizeExtensions = GetComponent<RectSizeSyncSpriteRendererSizeExtensions>();
	}

	public void RestCursorPostion()
	{
		prevCursorPostion = default(Vector2);
	}

	public void ChageRectSizeFromCursorPostion(Vector2 cursorPostion, RectSizeSyncPivot rectSizeSyncPivot)
	{
		rectSizeSyncSpriteRendererSizeExtensions.SetRectSizeSyncPivot(rectSizeSyncPivot);
		if (prevCursorPostion == default(Vector2))
		{
			prevCursorPostion = cursorPostion;
		}
		float num = (float)Screen.width / 1920f;
		float num2 = (prevCursorPostion.x - cursorPostion.x) * changeAmount;
		float num3 = (prevCursorPostion.y - cursorPostion.y) * changeAmount;
		switch (rectSizeSyncSpriteRendererSizeExtensions.RectSizeSyncPivot)
		{
		case RectSizeSyncPivot.LEFT:
			rect.sizeDelta = new Vector2(rect.sizeDelta.x - num2 / num, rect.sizeDelta.y);
			break;
		case RectSizeSyncPivot.RIGHT:
			rect.sizeDelta = new Vector2(rect.sizeDelta.x + num2 / num, rect.sizeDelta.y);
			break;
		case RectSizeSyncPivot.TOP:
			rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + num3 / num);
			break;
		case RectSizeSyncPivot.BOTTOM:
			rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y - num3 / num);
			break;
		case RectSizeSyncPivot.TOP_LEFT:
			rect.sizeDelta = new Vector2(rect.sizeDelta.x - num2 / num, rect.sizeDelta.y + num3 / num);
			break;
		case RectSizeSyncPivot.TOP_RIGHT:
			rect.sizeDelta = new Vector2(rect.sizeDelta.x + num2 / num, rect.sizeDelta.y + num3 / num);
			break;
		case RectSizeSyncPivot.BOTTOM_LEFT:
			rect.sizeDelta = new Vector2(rect.sizeDelta.x - num2 / num, rect.sizeDelta.y - num3 / num);
			break;
		case RectSizeSyncPivot.BOTTOM_RIGHT:
			rect.sizeDelta = new Vector2(rect.sizeDelta.x + num2 / num, rect.sizeDelta.y - num3 / num);
			break;
		}
		if (rect.sizeDelta.x < 120f)
		{
			rect.sizeDelta = new Vector2(120f, rect.sizeDelta.y);
		}
		if (rect.sizeDelta.y < 60f)
		{
			rect.sizeDelta = new Vector2(rect.sizeDelta.x, 60f);
		}
		prevCursorPostion = cursorPostion;
		prevRectSizeSyncPivot = rectSizeSyncSpriteRendererSizeExtensions.RectSizeSyncPivot;
	}
}
