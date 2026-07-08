using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchInputModule : StandaloneInputModule
{
	[Header("\ufffdV\ufffd[\ufffd\ufffd\ufffd\ufffd\ufffd\u0303J\ufffd\ufffd\ufffd\ufffd\ufffd\ufffd\ufffdZ\ufffdb\ufffdg")]
	public Camera cameraMain;

	[Header("\ufffdX\ufffdN\ufffd\ufffd\ufffd[\ufffd\ufffd\ufffd\ufffd\ufffdx")]
	public float scrollSpeed = 1f;

	[Header("\ufffdJ\ufffd[\ufffd\ufffd\ufffd\ufffd\ufffdGameObject")]
	public GameObject cursorObject;

	private readonly MouseState _mouseState = new MouseState();

	private Player _player;

	protected override void Awake()
	{
		_player = ReInput.players.GetPlayer(0);
	}

	public override void Process()
	{
		if (base.eventSystem.isFocused || !ShouldIgnoreEventsOnNoFocus())
		{
			SendUpdateEventToSelectedObject();
			ProcessControllerEvent();
		}
	}

	public void ProcessControllerEvent()
	{
		MouseState mousePointerEventData = GetMousePointerEventData();
		MouseButtonEventData eventData = mousePointerEventData.GetButtonState(PointerEventData.InputButton.Left).eventData;
		ProcessMousePress(eventData);
		ProcessMove(eventData.buttonData);
		ProcessDrag(eventData.buttonData);
		ProcessMousePress(mousePointerEventData.GetButtonState(PointerEventData.InputButton.Right).eventData);
		ProcessDrag(mousePointerEventData.GetButtonState(PointerEventData.InputButton.Right).eventData.buttonData);
		ProcessMousePress(mousePointerEventData.GetButtonState(PointerEventData.InputButton.Middle).eventData);
		ProcessDrag(mousePointerEventData.GetButtonState(PointerEventData.InputButton.Middle).eventData.buttonData);
		if (!Mathf.Approximately(eventData.buttonData.scrollDelta.sqrMagnitude, 0f))
		{
			ExecuteEvents.ExecuteHierarchy(ExecuteEvents.GetEventHandler<IScrollHandler>(eventData.buttonData.pointerCurrentRaycast.gameObject), eventData.buttonData, ExecuteEvents.scrollHandler);
		}
	}

	protected override MouseState GetMousePointerEventData()
	{
		PointerEventData data;
		bool pointerData = GetPointerData(-1, out data, create: true);
		data.Reset();
		Vector3 position = cursorObject.transform.position;
		Vector3 vector = cameraMain.WorldToScreenPoint(position);
		if (pointerData)
		{
			data.position = vector;
		}
		Vector2 vector2 = vector;
		if (Cursor.lockState == CursorLockMode.Locked)
		{
			data.position = new Vector2(-1f, -1f);
			data.delta = Vector2.zero;
		}
		else
		{
			data.delta = vector2 - data.position;
			data.position = vector2;
		}
		Vector2 vector3 = new Vector2(_player.GetAxis("Scroll Horizontal"), _player.GetAxis("Scroll Vertical"));
		data.scrollDelta = vector3 * scrollSpeed * Time.deltaTime;
		data.button = PointerEventData.InputButton.Left;
		base.eventSystem.RaycastAll(data, m_RaycastResultCache);
		RaycastResult pointerCurrentRaycast = BaseInputModule.FindFirstRaycast(m_RaycastResultCache);
		data.pointerCurrentRaycast = pointerCurrentRaycast;
		m_RaycastResultCache.Clear();
		GetPointerData(-2, out var data2, create: true);
		data2.Reset();
		CopyFromTo(data, data2);
		data2.button = PointerEventData.InputButton.Right;
		GetPointerData(-3, out var data3, create: true);
		data3.Reset();
		CopyFromTo(data, data3);
		data3.button = PointerEventData.InputButton.Middle;
		_mouseState.SetButtonState(PointerEventData.InputButton.Left, StateForSwitchControllerButton("Click"), data);
		_mouseState.SetButtonState(PointerEventData.InputButton.Right, StateForSwitchControllerButton(""), data2);
		_mouseState.SetButtonState(PointerEventData.InputButton.Middle, StateForSwitchControllerButton(""), data3);
		return _mouseState;
	}

	protected PointerEventData.FramePressState StateForSwitchControllerButton(string buttonName)
	{
		bool buttonDown = _player.GetButtonDown(buttonName);
		bool buttonUp = _player.GetButtonUp(buttonName);
		if (buttonDown && buttonUp)
		{
			return PointerEventData.FramePressState.PressedAndReleased;
		}
		if (buttonDown)
		{
			return PointerEventData.FramePressState.Pressed;
		}
		if (buttonUp)
		{
			return PointerEventData.FramePressState.Released;
		}
		return PointerEventData.FramePressState.NotChanged;
	}

	private bool ShouldIgnoreEventsOnNoFocus()
	{
		return true;
	}
}
