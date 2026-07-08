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
		TMP_Text textMesh = GetComponent<TMP_Text>();
		RectTransform rectTransform = GetComponent<RectTransform>();
		(from _ in this.UpdateAsObservable()
			select textMesh.preferredHeight).DistinctUntilChanged().Subscribe(delegate(float textHight)
		{
			rectTransform.sizeDelta = new Vector2(rectTransform.rect.size.x, textHight);
		}).AddTo(base.gameObject);
	}
}
