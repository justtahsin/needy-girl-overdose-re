using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

public class BoxClider2DMask : MonoBehaviour, IRectMaskableObject
{
	[SerializeField]
	private List<BoxCollider2D> collider2D;

	private readonly Vector3[] s_Corners = new Vector3[4];

	public void SetUpMask(RectTransform targetMaskRect)
	{
		RectTransform self = GetComponent<RectTransform>();
		(from _ in this.UpdateAsObservable()
			select base.transform.position).DistinctUntilChanged().Subscribe(delegate
		{
			bool _enabled = Contains(self, targetMaskRect);
			collider2D.ForEach(delegate(BoxCollider2D c)
			{
				c.enabled = _enabled;
			});
		}).AddTo(base.gameObject);
	}

	private bool Contains(RectTransform self, RectTransform target)
	{
		Bounds bounds = GetBounds(self);
		Bounds bounds2 = GetBounds(target);
		if (!bounds.Contains(new Vector3(bounds2.min.x, bounds2.min.y, 0f)) && !bounds.Contains(new Vector3(bounds2.max.x, bounds2.max.y, 0f)) && !bounds.Contains(new Vector3(bounds2.min.x, bounds2.max.y, 0f)))
		{
			return !bounds.Contains(new Vector3(bounds2.max.x, bounds2.min.y, 0f));
		}
		return false;
	}

	private Bounds GetBounds(RectTransform self)
	{
		Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
		Vector3 vector2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
		self.GetWorldCorners(s_Corners);
		for (int i = 0; i < 4; i++)
		{
			vector = Vector3.Min(s_Corners[i], vector);
			vector2 = Vector3.Max(s_Corners[i], vector2);
		}
		vector2.z = 0f;
		vector.z = 0f;
		Bounds result = new Bounds(vector, Vector3.zero);
		result.Encapsulate(vector2);
		return result;
	}
}
