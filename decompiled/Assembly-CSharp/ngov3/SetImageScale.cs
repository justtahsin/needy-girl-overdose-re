using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class SetImageScale : MonoBehaviour
{
	[SerializeField]
	private FitType fitType;

	private Image image;

	private RectTransform rect;

	private RectTransform parentRect;

	[SerializeField]
	private int nativeSizex = 1;

	[SerializeField]
	private int nativeSizey = 1;

	[SerializeField]
	private float scale;

	public float Scale => scale;

	public void Start()
	{
		image = ((Component)this).GetComponent<Image>();
		Transform transform = ((Component)this).gameObject.transform;
		rect = (RectTransform)(object)((transform is RectTransform) ? transform : null);
		Transform transform2 = ((Component)((Transform)rect).parent).gameObject.transform;
		parentRect = (RectTransform)(object)((transform2 is RectTransform) ? transform2 : null);
		ScaleToParent();
		ObservableExtensions.Subscribe<Rect>(ObserveExtensions.ObserveEveryValueChanged<GameObject, Rect>(((Component)parentRect).gameObject, (Func<GameObject, Rect>)((GameObject _) => parentRect.rect), (FrameCountType)0, false), (Action<Rect>)delegate
		{
			ScaleToParent();
		});
	}

	private void SetDefaultSize()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)image.sprite != (Object)null)
		{
			((Graphic)image).SetNativeSize();
			nativeSizex = Mathf.FloorToInt(rect.sizeDelta.x);
			nativeSizey = Mathf.FloorToInt(rect.sizeDelta.y);
		}
	}

	public float ScaleToParent()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		if (nativeSizex == 1)
		{
			SetDefaultSize();
		}
		Rect val = parentRect.rect;
		float width = ((Rect)(ref val)).width;
		val = parentRect.rect;
		float height = ((Rect)(ref val)).height;
		float val2 = width / (float)nativeSizex;
		float val3 = height / (float)nativeSizey;
		if (fitType == FitType.Contain)
		{
			float num = Math.Min(val2, val3);
			if (num < 1f)
			{
				scale = num;
			}
			else
			{
				scale = Mathf.FloorToInt(num);
			}
		}
		else
		{
			scale = Mathf.CeilToInt(Math.Max(val2, val3));
			if (scale < 1f)
			{
				scale = 1f;
			}
		}
		rect.sizeDelta = new Vector2((float)nativeSizex * scale, (float)nativeSizey * scale);
		return scale;
	}
}
