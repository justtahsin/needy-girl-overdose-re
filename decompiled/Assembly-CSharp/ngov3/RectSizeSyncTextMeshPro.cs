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
		TMP_Text textMesh = GetComponent<TMP_Text>();
		RectTransform rectTransform = GetComponent<RectTransform>();
		(from _ in this.UpdateAsObservable()
			select textMesh.GetPreferredValues()).DistinctUntilChanged().Subscribe(delegate(Vector2 size)
		{
			rectTransform.sizeDelta = new Vector2(size.x, size.y);
		}).AddTo(base.gameObject);
	}
}
