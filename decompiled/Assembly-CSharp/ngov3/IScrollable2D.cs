using UnityEngine.UI;

namespace ngov3;

public interface IScrollable2D
{
	RewiredScrollReceiver RewiredScrollReceiver { get; }

	ScrollRect ScrollRect { get; }
}
