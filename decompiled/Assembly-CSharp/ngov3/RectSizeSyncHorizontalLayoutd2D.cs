using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(HorizontalGridLayout2D))]
public class RectSizeSyncHorizontalLayoutd2D : MonoBehaviour
{
	private RectTransform rectTransform;

	private HorizontalGridLayout2D layout2D;

	private void Start()
	{
		rectTransform = ((Component)this).GetComponent<RectTransform>();
		layout2D = ((Component)this).GetComponent<HorizontalGridLayout2D>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.DistinctUntilChanged<float>(Observable.Select<Unit, float>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, float>)((Unit _) => layout2D.CurrentWidth))), (Action<float>)delegate
		{
			WidthSet();
		}), ((Component)this).gameObject);
	}

	private void WidthSet()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		Vector2 sizeDelta = default(Vector2);
		((Vector2)(ref sizeDelta))._002Ector(layout2D.CurrentWidth, rectTransform.sizeDelta.y);
		rectTransform.sizeDelta = sizeDelta;
	}
}
