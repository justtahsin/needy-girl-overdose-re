using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ngov3;

public class Amehead : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Button _button;

	public CursorMode cursorMode;

	public Vector2 hotSpot = Vector2.zero;

	public ReactiveProperty<int> NadeCount = new ReactiveProperty<int>(0);

	private SetImageScale ameImageScale;

	private void Awake()
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		_button = ((Component)this).GetComponent<Button>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_button), (Action<Unit>)delegate
		{
			((Component)((Component)this).gameObject.transform.parent.parent).GetComponent<App_Webcam>().Nade();
			ReactiveProperty<int> nadeCount = NadeCount;
			int value = nadeCount.Value;
			nadeCount.Value = value + 1;
		}), ((Component)this).gameObject);
		ameImageScale = ((Component)((Component)this).transform.parent).GetComponent<SetImageScale>();
		if ((Object)(object)ameImageScale != (Object)null)
		{
			RectTransform rectTr = ((Component)this).GetComponent<RectTransform>();
			Vector2 nativeSize = rectTr.sizeDelta;
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(ObserveExtensions.ObserveEveryValueChanged<Amehead, float>(this, (Func<Amehead, float>)((Amehead _) => ameImageScale.Scale), (FrameCountType)0, false), (Action<float>)delegate(float scale)
			{
				//IL_0020: Unknown result type (might be due to invalid IL or missing references)
				rectTr.sizeDelta = new Vector2(nativeSize.x * scale, nativeSize.y * scale);
			}), (Component)(object)this);
		}
	}

	public void OnPointerEnter(PointerEventData e)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(SingletonMonoBehaviour<EventManager>.Instance.handCursor, hotSpot, cursorMode);
	}

	public void OnPointerExit(PointerEventData e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, hotSpot, cursorMode);
	}
}
