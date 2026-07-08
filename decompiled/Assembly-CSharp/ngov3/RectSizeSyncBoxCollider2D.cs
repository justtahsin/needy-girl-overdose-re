using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(BoxCollider2D))]
public class RectSizeSyncBoxCollider2D : MonoBehaviour
{
	private void Start()
	{
		RectTransform rectTransform = GetComponent<RectTransform>();
		BoxCollider2D collider = GetComponent<BoxCollider2D>();
		(from _ in this.UpdateAsObservable()
			select rectTransform.rect).DistinctUntilChanged().Subscribe(delegate(Rect _rect)
		{
			collider.size = new Vector2(_rect.width, _rect.height);
		}).AddTo(base.gameObject);
	}
}
