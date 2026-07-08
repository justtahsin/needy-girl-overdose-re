using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(VerticalGridLayout2D))]
public class RectSizeSyncVerticalLayoutd2D : MonoBehaviour
{
	private RectTransform rectTransform;

	private VerticalGridLayout2D layout2D;

	private void Start()
	{
		rectTransform = ((Component)this).GetComponent<RectTransform>();
		layout2D = ((Component)this).GetComponent<VerticalGridLayout2D>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.DistinctUntilChanged<float>(Observable.Select<Unit, float>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, float>)((Unit _) => layout2D.CurrentHight))), (Action<float>)delegate
		{
			HightSet();
		}), ((Component)this).gameObject);
	}

	[ContextMenu("高さを手動セット")]
	public void HightSet()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		rectTransform.offsetMax = new Vector2(0f, rectTransform.offsetMax.y);
		Vector2 sizeDelta = default(Vector2);
		((Vector2)(ref sizeDelta))._002Ector(rectTransform.sizeDelta.x, layout2D.CurrentHight);
		rectTransform.sizeDelta = sizeDelta;
	}
}
