using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(SpriteRenderer))]
public class RectSizeSyncSpriteRendererFullStretch : MonoBehaviour
{
	private SpriteRenderer _rend;

	private RectTransform _rectTr;

	private void Start()
	{
		_rectTr = ((Component)this).GetComponent<RectTransform>();
		_rend = ((Component)this).GetComponent<SpriteRenderer>();
		ObservableExtensions.Subscribe<Rect>(Observable.DistinctUntilChanged<Rect>(Observable.Select<Unit, Rect>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, Rect>)((Unit _) => _rectTr.rect))), (Action<Rect>)delegate(Rect rect)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			_rend.size = new Vector2(((Rect)(ref rect)).width, ((Rect)(ref rect)).height);
		});
	}
}
