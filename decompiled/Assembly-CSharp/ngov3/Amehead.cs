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
		_button = GetComponent<Button>();
		_button.OnClickAsObservable().Subscribe(delegate
		{
			base.gameObject.transform.parent.parent.GetComponent<App_Webcam>().Nade();
			NadeCount.Value++;
		}).AddTo(base.gameObject);
		ameImageScale = base.transform.parent.GetComponent<SetImageScale>();
		if (ameImageScale != null)
		{
			RectTransform rectTr = GetComponent<RectTransform>();
			Vector2 nativeSize = rectTr.sizeDelta;
			this.ObserveEveryValueChanged((Amehead _) => ameImageScale.Scale).Subscribe(delegate(float scale)
			{
				rectTr.sizeDelta = new Vector2(nativeSize.x * scale, nativeSize.y * scale);
			}).AddTo(this);
		}
	}

	public void OnPointerEnter(PointerEventData e)
	{
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(SingletonMonoBehaviour<EventManager>.Instance.handCursor, hotSpot, cursorMode);
	}

	public void OnPointerExit(PointerEventData e)
	{
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, hotSpot, cursorMode);
	}
}
