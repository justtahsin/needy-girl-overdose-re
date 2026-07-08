using UnityEngine;

namespace ngov3;

public class PienTorialTooltip2D : Tooltip2D
{
	public override void SetHomingPos()
	{
		if (!(rect == null))
		{
			SetBaloonPos();
			Vector3 cursorPosition = SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition;
			Vector3 position = Camera.main.ScreenToWorldPoint(cursorPosition);
			position.z = rect.position.z;
			rect.position = position;
			float num = Mathf.Max(LEFTBORDER - leftUp.position.x, 0f);
			float num2 = Mathf.Max(leftUp.position.y - UPBORDER, 0f);
			if (num > 0f || num2 > 0f)
			{
				position.x += num;
				position.y -= num2;
				rect.position = position;
			}
		}
	}

	public override void SetBaloonPos()
	{
		base.BaloonRect.anchoredPosition = new Vector2(base.BaloonRect.sizeDelta.x / -2f, base.BaloonRect.sizeDelta.y / 2f);
	}
}
