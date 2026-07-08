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
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		((Selectable)this).Awake();
		targetGraphic2D = ((Component)this).GetComponent<SpriteRenderer>();
		if ((Object)(object)targetGraphic2D != (Object)null && (int)((Selectable)this).transition == 1)
		{
			defaultColor = targetGraphic2D.color;
			SpriteRenderer obj = targetGraphic2D;
			ColorBlock colors = ((Selectable)this).colors;
			obj.color = ((ColorBlock)(ref colors)).normalColor * defaultColor;
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		((Selectable)this).OnPointerEnter(eventData);
		if ((Object)(object)targetGraphic2D != (Object)null && (int)((Selectable)this).transition == 1)
		{
			ColorBlock colors = ((Selectable)this).colors;
			Color color = ((ColorBlock)(ref colors)).selectedColor * defaultColor;
			targetGraphic2D.color = color;
		}
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		((Selectable)this).OnPointerExit(eventData);
		if ((Object)(object)targetGraphic2D != (Object)null && (int)((Selectable)this).transition == 1)
		{
			ColorBlock colors = ((Selectable)this).colors;
			Color color = ((ColorBlock)(ref colors)).normalColor * defaultColor;
			targetGraphic2D.color = color;
		}
	}
}
