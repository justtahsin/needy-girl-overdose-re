using UnityEngine;

public static class RectTransformExtensions
{
	public static void SetPivotWithKeepingPosition(this RectTransform rectTransform, Vector2 targetPivot)
	{
		Vector2 vector = targetPivot - rectTransform.pivot;
		rectTransform.pivot = targetPivot;
		Vector2 vector2 = new Vector2(rectTransform.sizeDelta.x * vector.x, rectTransform.sizeDelta.y * vector.y);
		rectTransform.anchoredPosition += vector2;
	}

	public static void SetPivotWithKeepingPosition(this RectTransform rectTransform, float x, float y)
	{
		rectTransform.SetPivotWithKeepingPosition(new Vector2(x, y));
	}

	public static void SetAnchorWithKeepingPosition(this RectTransform rectTransform, Vector2 targetAnchor)
	{
		rectTransform.SetAnchorWithKeepingPosition(targetAnchor, targetAnchor);
	}

	public static void SetAnchorWithKeepingPosition(this RectTransform rectTransform, float x, float y)
	{
		rectTransform.SetAnchorWithKeepingPosition(new Vector2(x, y));
	}

	public static void SetAnchorWithKeepingPosition(this RectTransform rectTransform, Vector2 targetMinAnchor, Vector2 targetMaxAnchor)
	{
		RectTransform obj = rectTransform.parent as RectTransform;
		if (obj == null)
		{
			Debug.LogError("Parent cannot find.");
		}
		Vector2 vector = targetMinAnchor - rectTransform.anchorMin;
		Vector2 vector2 = targetMaxAnchor - rectTransform.anchorMax;
		rectTransform.anchorMin = targetMinAnchor;
		rectTransform.anchorMax = targetMaxAnchor;
		float num = obj.rect.width * vector.x;
		float num2 = obj.rect.width * vector2.x;
		float num3 = obj.rect.height * vector.y;
		float num4 = obj.rect.height * vector2.y;
		rectTransform.sizeDelta += new Vector2(num - num2, num3 - num4);
		Vector2 pivot = rectTransform.pivot;
		rectTransform.anchoredPosition -= new Vector2(num * (1f - pivot.x) + num2 * pivot.x, num3 * (1f - pivot.y) + num4 * pivot.y);
	}

	public static void SetAnchorWithKeepingPosition(this RectTransform rectTransform, float minX, float minY, float maxX, float maxY)
	{
		rectTransform.SetAnchorWithKeepingPosition(new Vector2(minX, minY), new Vector2(maxX, maxY));
	}
}
