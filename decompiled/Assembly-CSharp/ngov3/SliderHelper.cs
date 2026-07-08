using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ngov3;

public class SliderHelper : MonoBehaviour, IPointerUpHandler, IEventSystemHandler
{
	[SerializeField]
	private Slider slider;

	[SerializeField]
	private SliderManager manager;

	private void Awake()
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		manager.UpdateStatusToNumber();
	}
}
