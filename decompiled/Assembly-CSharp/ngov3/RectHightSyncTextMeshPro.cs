using System;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(TMP_Text))]
public class RectHightSyncTextMeshPro : MonoBehaviour
{
	private void Start()
	{
		TMP_Text textMesh = ((Component)this).GetComponent<TMP_Text>();
		RectTransform rectTransform = ((Component)this).GetComponent<RectTransform>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.DistinctUntilChanged<float>(Observable.Select<Unit, float>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, float>)((Unit _) => textMesh.preferredHeight))), (Action<float>)delegate(float textHight)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			RectTransform obj = rectTransform;
			Rect rect = rectTransform.rect;
			obj.sizeDelta = new Vector2(((Rect)(ref rect)).size.x, textHight);
		}), ((Component)this).gameObject);
	}
}
