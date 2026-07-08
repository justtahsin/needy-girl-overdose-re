using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

public class VerticalContentsSizeFitter2D : MonoBehaviour
{
	[SerializeField]
	private RectTransform thisRect;

	[SerializeField]
	private List<RectTransform> childObjects;

	private void Start()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.DistinctUntilChanged<float>(Observable.Select<Unit, float>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, float>)((Unit _) => childObjects.Where((RectTransform to) => ((Component)to).gameObject.activeSelf).Select(delegate(RectTransform to)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			Rect rect = to.rect;
			return ((Rect)(ref rect)).size;
		}).Sum((Vector2 size) => size.y)))), (Action<float>)delegate(float currentHight)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			Vector2 sizeDelta = default(Vector2);
			((Vector2)(ref sizeDelta))._002Ector(thisRect.sizeDelta.x, currentHight);
			thisRect.sizeDelta = sizeDelta;
		}), ((Component)this).gameObject);
	}
}
