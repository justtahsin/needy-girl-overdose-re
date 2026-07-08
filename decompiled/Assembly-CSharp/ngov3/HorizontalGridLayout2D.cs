using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

public class HorizontalGridLayout2D : MonoBehaviour
{
	[SerializeField]
	private PreLoadLayoutElement2D[] preLoadLayoutElements;

	private List<ILayoutElement2D> targetObjects = new List<ILayoutElement2D>();

	[SerializeField]
	private float padding = 5f;

	[SerializeField]
	private float marginTop;

	[SerializeField]
	private float marginLeft;

	[SerializeField]
	private float marginRight;

	private IEnumerable<ILayoutElement2D> ActiveTargetObjects => targetObjects.Where((ILayoutElement2D o) => o.RectTransform.gameObject.activeSelf);

	public float CurrentWidth { get; private set; }

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
		(from _ in this.UpdateAsObservable()
			select ActiveTargetObjects.Select((ILayoutElement2D to) => to.RectTransform.rect.size).Sum((Vector2 size) => size.x) + padding * (float)targetObjects.Count).DistinctUntilChanged().Subscribe(delegate
		{
			Vector2 size = rectTransform.rect.size;
			rectTransform.sizeDelta = new Vector2(size.x, size.y);
			SetObjectPostion(ActiveTargetObjects);
		}).AddTo(base.gameObject);
	}

	private void SetObjectPostion(IEnumerable<ILayoutElement2D> targetObjects)
	{
		IOrderedEnumerable<ILayoutElement2D> source = targetObjects.OrderBy((ILayoutElement2D o) => o.RectTransform.transform.GetSiblingIndex());
		for (int num = 0; num < source.Count(); num++)
		{
			float num2 = source.Take(num).Sum((ILayoutElement2D ob) => ob.RectTransform.rect.size.x) + padding * (float)num + marginLeft;
			_ = source.ElementAt(num).RectTransform.anchoredPosition;
			source.ElementAt(num).RectTransform.anchoredPosition = new Vector2(num2 + source.ElementAt(num).RectTransform.rect.size.x / 2f, marginTop);
		}
		CurrentWidth = source.Sum((ILayoutElement2D ob) => ob.RectTransform.rect.size.x) + padding * (float)(source.Count() - 1) + marginLeft + marginRight;
	}
}
