using UnityEngine;

namespace ngov3;

public class PienTorialTooltip : Tooltip
{
	public override void SetHomingPos()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		Vector3 cursorPosition = SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition;
		cursorPosition.z = 10f;
		Vector3 position = Camera.main.ScreenToWorldPoint(cursorPosition);
		((Component)this).transform.position = position;
		float x = ((Transform)rect).localPosition.x;
		float y = ((Transform)rect).localPosition.y;
		float num = Mathf.Clamp(x, RIGHTBORDER - rect.sizeDelta.x, LEFTBORDER);
		float num2 = Mathf.Clamp(y, BELOWBORDER, UNDERBORDER - rect.sizeDelta.y);
		((Transform)rect).localPosition = new Vector3(Mathf.Round(num), Mathf.Round(num2), 0f);
	}
}
