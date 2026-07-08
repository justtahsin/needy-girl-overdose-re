using System;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

public class BoxClider2DMask : MonoBehaviour, IRectMaskableObject
{
	[SerializeField]
	private List<BoxCollider2D> collider2D;

	private readonly Vector3[] s_Corners = (Vector3[])(object)new Vector3[4];

	public void SetUpMask(RectTransform targetMaskRect)
	{
		RectTransform self = ((Component)this).GetComponent<RectTransform>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.DistinctUntilChanged<Vector3>(Observable.Select<Unit, Vector3>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, Vector3>)((Unit _) => ((Component)this).transform.position))), (Action<Vector3>)delegate
		{
			bool _enabled = Contains(self, targetMaskRect);
			collider2D.ForEach(delegate(BoxCollider2D c)
			{
				((Behaviour)c).enabled = _enabled;
			});
		}), ((Component)this).gameObject);
	}

	private bool Contains(RectTransform self, RectTransform target)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		Bounds bounds = GetBounds(self);
		Bounds bounds2 = GetBounds(target);
		if (!((Bounds)(ref bounds)).Contains(new Vector3(((Bounds)(ref bounds2)).min.x, ((Bounds)(ref bounds2)).min.y, 0f)) && !((Bounds)(ref bounds)).Contains(new Vector3(((Bounds)(ref bounds2)).max.x, ((Bounds)(ref bounds2)).max.y, 0f)) && !((Bounds)(ref bounds)).Contains(new Vector3(((Bounds)(ref bounds2)).min.x, ((Bounds)(ref bounds2)).max.y, 0f)))
		{
			return !((Bounds)(ref bounds)).Contains(new Vector3(((Bounds)(ref bounds2)).max.x, ((Bounds)(ref bounds2)).min.y, 0f));
		}
		return false;
	}

	private Bounds GetBounds(RectTransform self)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = default(Vector3);
		((Vector3)(ref val))._002Ector(float.MaxValue, float.MaxValue, float.MaxValue);
		Vector3 val2 = default(Vector3);
		((Vector3)(ref val2))._002Ector(float.MinValue, float.MinValue, float.MinValue);
		self.GetWorldCorners(s_Corners);
		for (int i = 0; i < 4; i++)
		{
			val = Vector3.Min(s_Corners[i], val);
			val2 = Vector3.Max(s_Corners[i], val2);
		}
		val2.z = 0f;
		val.z = 0f;
		Bounds result = default(Bounds);
		((Bounds)(ref result))._002Ector(val, Vector3.zero);
		((Bounds)(ref result)).Encapsulate(val2);
		return result;
	}
}
