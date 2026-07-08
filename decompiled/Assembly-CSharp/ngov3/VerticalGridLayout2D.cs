using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

public class VerticalGridLayout2D : MonoBehaviour
{
	[SerializeField]
	private PreLoadLayoutElement2D[] preLoadLayoutElements;

	private List<ILayoutElement2D> targetObjects = new List<ILayoutElement2D>();

	[SerializeField]
	private float padding = 5f;

	[SerializeField]
	private float marginTop;

	[SerializeField]
	private float marginBottom;

	[SerializeField]
	private float marginLeft;

	private RectSizeSyncVerticalLayoutd2D _sizeSync;

	private IEnumerable<ILayoutElement2D> ActiveTargetObjects => targetObjects.Where((ILayoutElement2D o) => ((Component)o.RectTransform).gameObject.activeSelf);

	public float CurrentHight { get; private set; }

	public void AddLayoutObject(ILayoutElement2D element)
	{
		targetObjects.Add(element);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(element.OnDestroyObservable, (Action<Unit>)delegate
		{
			targetObjects.Remove(element);
		}), ((Component)this).gameObject);
	}

	private void Awake()
	{
		targetObjects.AddRange(preLoadLayoutElements);
		RectTransform rectTransform = ((Component)this).GetComponent<RectTransform>();
		_sizeSync = ((Component)this).GetComponent<RectSizeSyncVerticalLayoutd2D>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.DistinctUntilChanged<float>(Observable.Select<Unit, float>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, float>)((Unit _) => ActiveTargetObjects.Select(delegate(ILayoutElement2D to)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Rect rect = to.RectTransform.rect;
			return ((Rect)(ref rect)).size;
		}).Sum((Vector2 size) => size.y) + padding * (float)targetObjects.Count))), (Action<float>)delegate(float sumHight)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			Rect rect = rectTransform.rect;
			Vector2 size = ((Rect)(ref rect)).size;
			rectTransform.sizeDelta = new Vector2(size.x, sumHight);
			SetObjectPostion(ActiveTargetObjects);
		}), ((Component)this).gameObject);
	}

	private void SetObjectPostion(IEnumerable<ILayoutElement2D> targetObjects)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		IOrderedEnumerable<ILayoutElement2D> source = targetObjects.OrderBy((ILayoutElement2D o) => ((Component)o.RectTransform).transform.GetSiblingIndex());
		for (int num = 0; num < source.Count(); num++)
		{
			float num2 = source.Take(num).Sum(delegate(ILayoutElement2D ob)
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				//IL_000e: Unknown result type (might be due to invalid IL or missing references)
				Rect rect2 = ob.RectTransform.rect;
				return ((Rect)(ref rect2)).size.y;
			}) + padding * (float)num + marginTop;
			_ = source.ElementAt(num).RectTransform.anchoredPosition;
			if (source.ElementAt(num).LayoutElement2DType == LayoutElement2DType.OBJECT)
			{
				source.ElementAt(num).RectTransform.anchoredPosition = new Vector2(marginLeft, 0f - num2);
			}
			else if (source.ElementAt(num).LayoutElement2DType == LayoutElement2DType.SPRITE_RENDERER)
			{
				RectTransform rectTransform = source.ElementAt(num).RectTransform;
				float num3 = marginLeft;
				float num4 = 0f - num2;
				Rect rect = source.ElementAt(num).RectTransform.rect;
				rectTransform.anchoredPosition = new Vector2(num3, num4 - ((Rect)(ref rect)).size.y / 2f);
			}
		}
		CurrentHight = source.Sum(delegate(ILayoutElement2D ob)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Rect rect2 = ob.RectTransform.rect;
			return ((Rect)(ref rect2)).size.y;
		}) + padding * (float)(source.Count() - 1) + marginTop + marginBottom;
		if ((Object)(object)_sizeSync != (Object)null)
		{
			_sizeSync.HightSet();
		}
	}
}
