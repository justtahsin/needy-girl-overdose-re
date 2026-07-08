using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(BoxCollider2D))]
public class ScrolllOverHungObject : MonoBehaviour
{
	[SerializeField]
	private RectTransform thisRect;

	[SerializeField]
	private BoxCollider2D boxCollider;

	public void SetParentRect(RectTransform parentRect)
	{
		Vector3[] _worldCorners = new Vector3[4];
		Vector3[] _thisWorldCorners = new Vector3[4];
		Vector2 defaultBoxCliderSize = boxCollider.size;
		Vector2 parentTopScreenPostion;
		Vector2 thisTopScreenPostion;
		Vector2 parentBottomScreenPostion;
		Vector2 thisBottomScreenPostion;
		(from _ in this.UpdateAsObservable()
			where base.gameObject.activeSelf
			select base.transform.position).DistinctUntilChanged().Subscribe(delegate
		{
			parentRect.GetWorldCorners(_worldCorners);
			thisRect.GetWorldCorners(_thisWorldCorners);
			parentTopScreenPostion = parentRect.transform.InverseTransformPoint(_worldCorners[1]);
			thisTopScreenPostion = parentRect.transform.InverseTransformPoint(_thisWorldCorners[1]);
			parentBottomScreenPostion = parentRect.transform.InverseTransformPoint(_worldCorners[0]);
			thisBottomScreenPostion = parentRect.transform.InverseTransformPoint(_thisWorldCorners[0]);
			float num = parentTopScreenPostion.y - thisTopScreenPostion.y;
			float num2 = parentBottomScreenPostion.y - thisBottomScreenPostion.y;
			if (num < 0f)
			{
				float num3 = ((defaultBoxCliderSize.y + num < 0f) ? 0f : (defaultBoxCliderSize.y + num));
				boxCollider.size = new Vector2(boxCollider.size.x, num3);
				float y = (num3 - defaultBoxCliderSize.y) / 2f;
				boxCollider.offset = new Vector2(0f, y);
			}
			if (num2 > 0f)
			{
				float num4 = ((defaultBoxCliderSize.y - num2 < 0f) ? 0f : (defaultBoxCliderSize.y - num2));
				boxCollider.size = new Vector2(boxCollider.size.x, num4);
				float num5 = (num4 - defaultBoxCliderSize.y) / 2f;
				boxCollider.offset = new Vector2(0f, 0f - num5);
			}
		}).AddTo(base.gameObject);
	}
}
