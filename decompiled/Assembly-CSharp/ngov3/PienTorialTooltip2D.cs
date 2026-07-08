using UnityEngine;

namespace ngov3;

public class PienTorialTooltip2D : Tooltip2D
{
	public override void SetHomingPos()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)rect == (Object)null))
		{
			SetBaloonPos();
			Vector3 cursorPosition = SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition;
			Vector3 position = Camera.main.ScreenToWorldPoint(cursorPosition);
			position.z = ((Transform)rect).position.z;
			((Transform)rect).position = position;
			float num = Mathf.Max(LEFTBORDER - ((Transform)leftUp).position.x, 0f);
			float num2 = Mathf.Max(((Transform)leftUp).position.y - UPBORDER, 0f);
			if (num > 0f || num2 > 0f)
			{
				position.x += num;
				position.y -= num2;
				((Transform)rect).position = position;
			}
		}
	}

	public override void SetBaloonPos()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		base.BaloonRect.anchoredPosition = new Vector2(base.BaloonRect.sizeDelta.x / -2f, base.BaloonRect.sizeDelta.y / 2f);
	}
}
