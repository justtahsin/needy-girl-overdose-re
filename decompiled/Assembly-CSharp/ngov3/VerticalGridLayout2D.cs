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

	private IEnumerable<ILayoutElement2D> ActiveTargetObjects => targetObjects.Where((ILayoutElement2D o) => o.RectTransform.gameObject.activeSelf);

	public float CurrentHight { get; private set; }

	public void AddLayoutObject(ILayoutElement2D element)
	{
		targetObjects.Add(element);
		element.OnDestroyObservable.Subscribe(delegate
		{
			targetObjects.Remove(element);
		}).AddTo(base.gameObject);
	}

	private void Awake()
	{
		targetObjects.AddRange(preLoadLayoutElements);
		RectTransform rectTransform = GetComponent<RectTransform>();
		_sizeSync = GetComponent<RectSizeSyncVerticalLayoutd2D>();
		(from _ in this.UpdateAsObservable()
			select ActiveTargetObjects.Select((ILayoutElement2D to) => to.RectTransform.rect.size).Sum((Vector2 size) => size.y) + padding * (float)targetObjects.Count).DistinctUntilChanged().Subscribe(delegate(float sumHight)
		{
			Vector2 size = rectTransform.rect.size;
			rectTransform.sizeDelta = new Vector2(size.x, sumHight);
			SetObjectPostion(ActiveTargetObjects);
		}).AddTo(base.gameObject);
	}

	private void SetObjectPostion(IEnumerable<ILayoutElement2D> targetObjects)
	{
		IOrderedEnumerable<ILayoutElement2D> source = targetObjects.OrderBy((ILayoutElement2D o) => o.RectTransform.transform.GetSiblingIndex());
		for (int num = 0; num < source.Count(); num++)
		{
			float num2 = source.Take(num).Sum((ILayoutElement2D ob) => ob.RectTransform.rect.size.y) + padding * (float)num + marginTop;
			_ = source.ElementAt(num).RectTransform.anchoredPosition;
			if (source.ElementAt(num).LayoutElement2DType == LayoutElement2DType.OBJECT)
			{
				source.ElementAt(num).RectTransform.anchoredPosition = new Vector2(marginLeft, 0f - num2);
			}
			else if (source.ElementAt(num).LayoutElement2DType == LayoutElement2DType.SPRITE_RENDERER)
			{
				source.ElementAt(num).RectTransform.anchoredPosition = new Vector2(marginLeft, 0f - num2 - source.ElementAt(num).RectTransform.rect.size.y / 2f);
			}
		}
		CurrentHight = source.Sum((ILayoutElement2D ob) => ob.RectTransform.rect.size.y) + padding * (float)(source.Count() - 1) + marginTop + marginBottom;
		if (_sizeSync != null)
		{
			_sizeSync.HightSet();
		}
	}
}
