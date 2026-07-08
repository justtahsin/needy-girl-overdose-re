using System;
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
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		Rect rect = targetSyncParent.rect;
		Vector2 defaultParentSize = ((Rect)(ref rect)).size;
		Vector3 defaultScale = ((Component)this).transform.localScale;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector2>(Observable.DistinctUntilChanged<Vector2>(Observable.Select<Unit, Vector2>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, Vector2>)delegate
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			Rect rect2 = targetSyncParent.rect;
			return ((Rect)(ref rect2)).size;
		})), (Action<Vector2>)delegate(Vector2 size)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			float num = size.x / defaultParentSize.x;
			float num2 = size.y / defaultParentSize.y;
			((Component)this).transform.localScale = Vector2.op_Implicit(new Vector2(defaultScale.x * num, defaultScale.y * num2));
		}), ((Component)this).gameObject);
	}
}
