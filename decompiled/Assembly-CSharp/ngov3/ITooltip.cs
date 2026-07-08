using UnityEngine;

namespace ngov3;

public interface ITooltip : IFader
{
	void SetPos(Vector3 pos);

	void SetHomingPos();

	void SetData(TooltipType type, Vector3 pos, bool isHoming, string nakamiText = "");

	void SetBaloonPos();
}
