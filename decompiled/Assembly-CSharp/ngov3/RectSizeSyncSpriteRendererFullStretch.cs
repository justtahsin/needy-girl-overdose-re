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
		_rectTr = GetComponent<RectTransform>();
		_rend = GetComponent<SpriteRenderer>();
		(from _ in this.UpdateAsObservable()
			select _rectTr.rect).DistinctUntilChanged().Subscribe(delegate(Rect rect)
		{
			_rend.size = new Vector2(rect.width, rect.height);
		});
	}
}
