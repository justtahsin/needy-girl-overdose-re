using UnityEngine;
using UnityEngine.EventSystems;

namespace ngov3;

public class MouseCursor : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Texture2D _changed;

	public Vector2 hotSpot = new Vector2(0.5f, 0.5f);

	public CursorMode cursorMode;

	private void Start()
	{
	}

	public void OnPointerEnter(PointerEventData e)
	{
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(_changed, hotSpot, cursorMode);
	}

	public void OnPointerExit(PointerEventData e)
	{
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, hotSpot, cursorMode);
	}
}
