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
		rect = ((Component)this).GetComponent<RectTransform>();
		rectSizeSyncSpriteRendererSizeExtensions = ((Component)this).GetComponent<RectSizeSyncSpriteRendererSizeExtensions>();
	}

	public void RestCursorPostion()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		prevCursorPostion = default(Vector2);
	}

	public void ChageRectSizeFromCursorPostion(Vector2 cursorPostion, RectSizeSyncPivot rectSizeSyncPivot)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
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
