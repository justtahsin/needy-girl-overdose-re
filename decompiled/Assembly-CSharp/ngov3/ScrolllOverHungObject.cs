using System;
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
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		Vector3[] _worldCorners = (Vector3[])(object)new Vector3[4];
		Vector3[] _thisWorldCorners = (Vector3[])(object)new Vector3[4];
		Vector2 defaultBoxCliderSize = boxCollider.size;
		Vector2 parentTopScreenPostion;
		Vector2 thisTopScreenPostion;
		Vector2 parentBottomScreenPostion;
		Vector2 thisBottomScreenPostion;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.DistinctUntilChanged<Vector3>(Observable.Select<Unit, Vector3>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => ((Component)this).gameObject.activeSelf)), (Func<Unit, Vector3>)((Unit _) => ((Component)this).transform.position))), (Action<Vector3>)delegate
		{
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			parentRect.GetWorldCorners(_worldCorners);
			thisRect.GetWorldCorners(_thisWorldCorners);
			parentTopScreenPostion = Vector2.op_Implicit(((Component)parentRect).transform.InverseTransformPoint(_worldCorners[1]));
			thisTopScreenPostion = Vector2.op_Implicit(((Component)parentRect).transform.InverseTransformPoint(_thisWorldCorners[1]));
			parentBottomScreenPostion = Vector2.op_Implicit(((Component)parentRect).transform.InverseTransformPoint(_worldCorners[0]));
			thisBottomScreenPostion = Vector2.op_Implicit(((Component)parentRect).transform.InverseTransformPoint(_thisWorldCorners[0]));
			float num = parentTopScreenPostion.y - thisTopScreenPostion.y;
			float num2 = parentBottomScreenPostion.y - thisBottomScreenPostion.y;
			if (num < 0f)
			{
				float num3 = ((defaultBoxCliderSize.y + num < 0f) ? 0f : (defaultBoxCliderSize.y + num));
				boxCollider.size = new Vector2(boxCollider.size.x, num3);
				float num4 = (num3 - defaultBoxCliderSize.y) / 2f;
				((Collider2D)boxCollider).offset = new Vector2(0f, num4);
			}
			if (num2 > 0f)
			{
				float num5 = ((defaultBoxCliderSize.y - num2 < 0f) ? 0f : (defaultBoxCliderSize.y - num2));
				boxCollider.size = new Vector2(boxCollider.size.x, num5);
				float num6 = (num5 - defaultBoxCliderSize.y) / 2f;
				((Collider2D)boxCollider).offset = new Vector2(0f, 0f - num6);
			}
		}), ((Component)this).gameObject);
	}
}
