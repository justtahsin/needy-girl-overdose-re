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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(_changed, hotSpot, cursorMode);
	}

	public void OnPointerExit(PointerEventData e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, hotSpot, cursorMode);
	}
}
