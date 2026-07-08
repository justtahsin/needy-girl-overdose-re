using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ngov3;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(RectSizeSyncBoxCollider2D))]
public class Button2D : Button
{
	private SpriteRenderer targetGraphic2D;

	private Color defaultColor = Color.white;

	protected override void Awake()
	{
		base.Awake();
		targetGraphic2D = GetComponent<SpriteRenderer>();
		if (targetGraphic2D != null && base.transition == Transition.ColorTint)
		{
			defaultColor = targetGraphic2D.color;
			targetGraphic2D.color = base.colors.normalColor * defaultColor;
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		if (targetGraphic2D != null && base.transition == Transition.ColorTint)
		{
			Color color = base.colors.selectedColor * defaultColor;
			targetGraphic2D.color = color;
		}
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		if (targetGraphic2D != null && base.transition == Transition.ColorTint)
		{
			Color color = base.colors.normalColor * defaultColor;
			targetGraphic2D.color = color;
		}
	}
}
