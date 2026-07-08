using UnityEngine;

namespace ngov3;

public class PienTorialTooltip : Tooltip
{
	public override void SetHomingPos()
	{
		Vector3 cursorPosition = SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition;
		cursorPosition.z = 10f;
		Vector3 position = Camera.main.ScreenToWorldPoint(cursorPosition);
		base.transform.position = position;
		float x = rect.localPosition.x;
		float y = rect.localPosition.y;
		float f = Mathf.Clamp(x, RIGHTBORDER - rect.sizeDelta.x, LEFTBORDER);
		float f2 = Mathf.Clamp(y, BELOWBORDER, UNDERBORDER - rect.sizeDelta.y);
		rect.localPosition = new Vector3(Mathf.Round(f), Mathf.Round(f2), 0f);
	}
}
