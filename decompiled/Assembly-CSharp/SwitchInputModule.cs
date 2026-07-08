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
		if (((BaseInputModule)this).eventSystem.isFocused || !ShouldIgnoreEventsOnNoFocus())
		{
			((StandaloneInputModule)this).SendUpdateEventToSelectedObject();
			ProcessControllerEvent();
		}
	}

	public void ProcessControllerEvent()
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		MouseState mousePointerEventData = ((PointerInputModule)this).GetMousePointerEventData();
		MouseButtonEventData eventData = mousePointerEventData.GetButtonState((InputButton)0).eventData;
		((StandaloneInputModule)this).ProcessMousePress(eventData);
		((PointerInputModule)this).ProcessMove(eventData.buttonData);
		((PointerInputModule)this).ProcessDrag(eventData.buttonData);
		((StandaloneInputModule)this).ProcessMousePress(mousePointerEventData.GetButtonState((InputButton)1).eventData);
		((PointerInputModule)this).ProcessDrag(mousePointerEventData.GetButtonState((InputButton)1).eventData.buttonData);
		((StandaloneInputModule)this).ProcessMousePress(mousePointerEventData.GetButtonState((InputButton)2).eventData);
		((PointerInputModule)this).ProcessDrag(mousePointerEventData.GetButtonState((InputButton)2).eventData.buttonData);
		Vector2 scrollDelta = eventData.buttonData.scrollDelta;
		if (!Mathf.Approximately(((Vector2)(ref scrollDelta)).sqrMagnitude, 0f))
		{
			RaycastResult pointerCurrentRaycast = eventData.buttonData.pointerCurrentRaycast;
			ExecuteEvents.ExecuteHierarchy<IScrollHandler>(ExecuteEvents.GetEventHandler<IScrollHandler>(((RaycastResult)(ref pointerCurrentRaycast)).gameObject), (BaseEventData)(object)eventData.buttonData, ExecuteEvents.scrollHandler);
		}
	}

	protected override MouseState GetMousePointerEventData()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		PointerEventData val = default(PointerEventData);
		bool pointerData = ((PointerInputModule)this).GetPointerData(-1, ref val, true);
		((AbstractEventData)val).Reset();
		Vector3 position = cursorObject.transform.position;
		Vector3 val2 = cameraMain.WorldToScreenPoint(position);
		if (pointerData)
		{
			val.position = Vector2.op_Implicit(val2);
		}
		Vector2 val3 = Vector2.op_Implicit(val2);
		if ((int)Cursor.lockState == 1)
		{
			val.position = new Vector2(-1f, -1f);
			val.delta = Vector2.zero;
		}
		else
		{
			val.delta = val3 - val.position;
			val.position = val3;
		}
		Vector2 val4 = default(Vector2);
		((Vector2)(ref val4))._002Ector(_player.GetAxis("Scroll Horizontal"), _player.GetAxis("Scroll Vertical"));
		val.scrollDelta = val4 * scrollSpeed * Time.deltaTime;
		val.button = (InputButton)0;
		((BaseInputModule)this).eventSystem.RaycastAll(val, ((BaseInputModule)this).m_RaycastResultCache);
		RaycastResult pointerCurrentRaycast = BaseInputModule.FindFirstRaycast(((BaseInputModule)this).m_RaycastResultCache);
		val.pointerCurrentRaycast = pointerCurrentRaycast;
		((BaseInputModule)this).m_RaycastResultCache.Clear();
		PointerEventData val5 = default(PointerEventData);
		((PointerInputModule)this).GetPointerData(-2, ref val5, true);
		((AbstractEventData)val5).Reset();
		((PointerInputModule)this).CopyFromTo(val, val5);
		val5.button = (InputButton)1;
		PointerEventData val6 = default(PointerEventData);
		((PointerInputModule)this).GetPointerData(-3, ref val6, true);
		((AbstractEventData)val6).Reset();
		((PointerInputModule)this).CopyFromTo(val, val6);
		val6.button = (InputButton)2;
		_mouseState.SetButtonState((InputButton)0, StateForSwitchControllerButton("Click"), val);
		_mouseState.SetButtonState((InputButton)1, StateForSwitchControllerButton(""), val5);
		_mouseState.SetButtonState((InputButton)2, StateForSwitchControllerButton(""), val6);
		return _mouseState;
	}

	protected FramePressState StateForSwitchControllerButton(string buttonName)
	{
		bool buttonDown = _player.GetButtonDown(buttonName);
		bool buttonUp = _player.GetButtonUp(buttonName);
		if (!(buttonDown && buttonUp))
		{
			if (!buttonDown)
			{
				if (!buttonUp)
				{
					return (FramePressState)3;
				}
				return (FramePressState)1;
			}
			return (FramePressState)0;
		}
		return (FramePressState)2;
	}

	private bool ShouldIgnoreEventsOnNoFocus()
	{
		return true;
	}
}
