using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(BoxCollider2D))]
public class RectSizeSyncBoxCollider2D : MonoBehaviour
{
	private void Start()
	{
		RectTransform rectTransform = ((Component)this).GetComponent<RectTransform>();
		BoxCollider2D collider = ((Component)this).GetComponent<BoxCollider2D>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Rect>(Observable.DistinctUntilChanged<Rect>(Observable.Select<Unit, Rect>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, Rect>)((Unit _) => rectTransform.rect))), (Action<Rect>)delegate(Rect _rect)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			collider.size = new Vector2(((Rect)(ref _rect)).width, ((Rect)(ref _rect)).height);
		}), ((Component)this).gameObject);
	}
}
