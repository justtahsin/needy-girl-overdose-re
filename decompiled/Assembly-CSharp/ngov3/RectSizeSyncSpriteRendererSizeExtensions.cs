using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(RectTransform))]
public class RectSizeSyncSpriteRendererSizeExtensions : MonoBehaviour
{
	[SerializeField]
	private RectSizeSyncPivot rectSizeSyncPivot;

	public RectSizeSyncPivot RectSizeSyncPivot => rectSizeSyncPivot;

	public void SetRectSizeSyncPivot(RectSizeSyncPivot rectSizeSyncPivot)
	{
		this.rectSizeSyncPivot = rectSizeSyncPivot;
	}

	private void Start()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		RectTransform rectTransform = ((Component)this).GetComponent<RectTransform>();
		SpriteRenderer sprite = ((Component)this).GetComponent<SpriteRenderer>();
		Rect rect = rectTransform.rect;
		Vector2 prevSize = ((Rect)(ref rect)).size;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector2>(Observable.DistinctUntilChanged<Vector2>(Observable.Select<Unit, Vector2>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, Vector2>)delegate
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Rect rect2 = rectTransform.rect;
			return ((Rect)(ref rect2)).size;
		})), (Action<Vector2>)delegate(Vector2 size)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0237: Unknown result type (might be due to invalid IL or missing references)
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0261: Unknown result type (might be due to invalid IL or missing references)
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			float num = prevSize.x - size.x;
			float num2 = prevSize.y - size.y;
			sprite.size = size;
			switch (rectSizeSyncPivot)
			{
			case RectSizeSyncPivot.LEFT:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x - num / 2f, rectTransform.anchoredPosition.y);
				break;
			case RectSizeSyncPivot.RIGHT:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + num / 2f, rectTransform.anchoredPosition.y);
				break;
			case RectSizeSyncPivot.TOP:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + num2 / 2f);
				break;
			case RectSizeSyncPivot.BOTTOM:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - num2 / 2f);
				break;
			case RectSizeSyncPivot.TOP_LEFT:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x - num / 2f, rectTransform.anchoredPosition.y + num2 / 2f);
				break;
			case RectSizeSyncPivot.TOP_RIGHT:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + num / 2f, rectTransform.anchoredPosition.y + num2 / 2f);
				break;
			case RectSizeSyncPivot.BOTTOM_LEFT:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x - num / 2f, rectTransform.anchoredPosition.y - num2 / 2f);
				break;
			case RectSizeSyncPivot.BOTTOM_RIGHT:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + num / 2f, rectTransform.anchoredPosition.y - num2 / 2f);
				break;
			}
			prevSize = size;
		}), ((Component)this).gameObject);
	}
}
