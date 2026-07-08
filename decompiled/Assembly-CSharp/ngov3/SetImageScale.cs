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
		image = GetComponent<Image>();
		rect = base.gameObject.transform as RectTransform;
		parentRect = rect.parent.gameObject.transform as RectTransform;
		ScaleToParent();
		parentRect.gameObject.ObserveEveryValueChanged((GameObject _) => parentRect.rect).Subscribe(delegate
		{
			ScaleToParent();
		});
	}

	private void SetDefaultSize()
	{
		if (image.sprite != null)
		{
			image.SetNativeSize();
			nativeSizex = Mathf.FloorToInt(rect.sizeDelta.x);
			nativeSizey = Mathf.FloorToInt(rect.sizeDelta.y);
		}
	}

	public float ScaleToParent()
	{
		if (nativeSizex == 1)
		{
			SetDefaultSize();
		}
		float width = parentRect.rect.width;
		float height = parentRect.rect.height;
		float val = width / (float)nativeSizex;
		float val2 = height / (float)nativeSizey;
		if (fitType == FitType.Contain)
		{
			float num = Math.Min(val, val2);
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
			scale = Mathf.CeilToInt(Math.Max(val, val2));
			if (scale < 1f)
			{
				scale = 1f;
			}
		}
		rect.sizeDelta = new Vector2((float)nativeSizex * scale, (float)nativeSizey * scale);
		return scale;
	}
}
