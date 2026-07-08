using UnityEngine;

public static class RectTransformExtensions
{
	public static void SetPivotWithKeepingPosition(this RectTransform rectTransform, Vector2 targetPivot)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = targetPivot - rectTransform.pivot;
		rectTransform.pivot = targetPivot;
		Vector2 val2 = default(Vector2);
		((Vector2)(ref val2))._002Ector(rectTransform.sizeDelta.x * val.x, rectTransform.sizeDelta.y * val.y);
		rectTransform.anchoredPosition += val2;
	}

	public static void SetPivotWithKeepingPosition(this RectTransform rectTransform, float x, float y)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		rectTransform.SetPivotWithKeepingPosition(new Vector2(x, y));
	}

	public static void SetAnchorWithKeepingPosition(this RectTransform rectTransform, Vector2 targetAnchor)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		rectTransform.SetAnchorWithKeepingPosition(targetAnchor, targetAnchor);
	}

	public static void SetAnchorWithKeepingPosition(this RectTransform rectTransform, float x, float y)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		rectTransform.SetAnchorWithKeepingPosition(new Vector2(x, y));
	}

	public static void SetAnchorWithKeepingPosition(this RectTransform rectTransform, Vector2 targetMinAnchor, Vector2 targetMaxAnchor)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		Transform parent = ((Transform)rectTransform).parent;
		Transform obj = ((parent is RectTransform) ? parent : null);
		if ((Object)(object)obj == (Object)null)
		{
			Debug.LogError((object)"Parent cannot find.");
		}
		Vector2 val = targetMinAnchor - rectTransform.anchorMin;
		Vector2 val2 = targetMaxAnchor - rectTransform.anchorMax;
		rectTransform.anchorMin = targetMinAnchor;
		rectTransform.anchorMax = targetMaxAnchor;
		Rect rect = ((RectTransform)obj).rect;
		float num = ((Rect)(ref rect)).width * val.x;
		rect = ((RectTransform)obj).rect;
		float num2 = ((Rect)(ref rect)).width * val2.x;
		rect = ((RectTransform)obj).rect;
		float num3 = ((Rect)(ref rect)).height * val.y;
		rect = ((RectTransform)obj).rect;
		float num4 = ((Rect)(ref rect)).height * val2.y;
		rectTransform.sizeDelta += new Vector2(num - num2, num3 - num4);
		Vector2 pivot = rectTransform.pivot;
		rectTransform.anchoredPosition -= new Vector2(num * (1f - pivot.x) + num2 * pivot.x, num3 * (1f - pivot.y) + num4 * pivot.y);
	}

	public static void SetAnchorWithKeepingPosition(this RectTransform rectTransform, float minX, float minY, float maxX, float maxY)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		rectTransform.SetAnchorWithKeepingPosition(new Vector2(minX, minY), new Vector2(maxX, maxY));
	}
}
