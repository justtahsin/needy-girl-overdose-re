using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ngov3;

public class TooltipCaller : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	public bool isShowTooltip;

	[SerializeField]
	public bool isTutorial;

	[SerializeField]
	private bool isHoming;

	[SerializeField]
	public TooltipType type;

	[TextArea(1, 3)]
	[SerializeField]
	public string textNakami;

	private Vector3 pos;

	[SerializeField]
	private Button target;

	private BoxCollider2D collider2D;

	private CanvasGroup parentCanvas;

	[SerializeField]
	private Vector2 colliderSize = new Vector2(35f, 35f);

	[SerializeField]
	private Vector2 colliderOffset = new Vector2(0f, 0f);

	private bool CanAbleCallToolTip
	{
		get
		{
			if (parentCanvas == null)
			{
				return true;
			}
			return parentCanvas.interactable;
		}
	}

	private void Start()
	{
		parentCanvas = base.transform.parent.GetComponent<CanvasGroup>();
	}

	public void OnPointerEnter(PointerEventData e)
	{
		if (isShowTooltip && (type != TooltipType.None || !(textNakami == "")))
		{
			if (isTutorial)
			{
				SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(type, textNakami);
			}
			else
			{
				Show(type, isHoming, textNakami);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (CanAbleCallToolTip)
		{
			OnPointerEnter(null);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (CanAbleCallToolTip)
		{
			OnPointerExit(null);
		}
	}

	public void OnPointerExit(PointerEventData e)
	{
		Hide();
	}

	private void OnDestroy()
	{
		Hide();
	}

	public void OnOff(bool enable)
	{
		isShowTooltip = enable;
	}

	public void Show()
	{
		SingletonMonoBehaviour<TooltipManager>.Instance.Show(target.transform.localPosition, type, isHoming, textNakami);
	}

	private void Show(TooltipType type, bool isHoming, string textNakami = "")
	{
		if (isHoming)
		{
			pos = new Vector3(SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition.x - 242f, SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition.y, 0f);
		}
		else
		{
			pos = target.transform.localPosition;
		}
		SingletonMonoBehaviour<TooltipManager>.Instance.Show(pos, type, isHoming, textNakami);
	}

	public void Hide()
	{
		if (!(SingletonMonoBehaviour<TooltipManager>.Instance == null))
		{
			SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
		}
	}
}
