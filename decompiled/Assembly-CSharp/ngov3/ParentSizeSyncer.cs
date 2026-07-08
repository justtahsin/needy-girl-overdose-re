using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

public class ParentSizeSyncer : MonoBehaviour
{
	[SerializeField]
	private RectTransform targetSyncParent;

	private void Start()
	{
		Vector2 defaultParentSize = targetSyncParent.rect.size;
		Vector3 defaultScale = base.transform.localScale;
		(from _ in this.UpdateAsObservable()
			select targetSyncParent.rect.size).DistinctUntilChanged().Subscribe(delegate(Vector2 size)
		{
			float num = size.x / defaultParentSize.x;
			float num2 = size.y / defaultParentSize.y;
			base.transform.localScale = new Vector2(defaultScale.x * num, defaultScale.y * num2);
		}).AddTo(base.gameObject);
	}
}
