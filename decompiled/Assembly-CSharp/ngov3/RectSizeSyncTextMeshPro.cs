using System;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(TMP_Text))]
public class RectSizeSyncTextMeshPro : MonoBehaviour
{
	private void Start()
	{
		TMP_Text textMesh = ((Component)this).GetComponent<TMP_Text>();
		RectTransform rectTransform = ((Component)this).GetComponent<RectTransform>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector2>(Observable.DistinctUntilChanged<Vector2>(Observable.Select<Unit, Vector2>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, Vector2>)((Unit _) => textMesh.GetPreferredValues()))), (Action<Vector2>)delegate(Vector2 size)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			rectTransform.sizeDelta = new Vector2(size.x, size.y);
		}), ((Component)this).gameObject);
	}
}
