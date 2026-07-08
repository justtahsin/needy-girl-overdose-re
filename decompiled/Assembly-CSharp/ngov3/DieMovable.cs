using NGO;
using TMPro;
using UnityEngine;

namespace ngov3;

public class DieMovable : MonoBehaviour
{
	[SerializeField]
	private TMP_Text die;

	public void Awake()
	{
		die.text = NgoEx.SystemTextFromType(SystemTextType.Die, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	public void setRandomPosition()
	{
		RectTransform rectTransform = base.gameObject.transform as RectTransform;
		RectTransform rectTransform2 = rectTransform.parent.transform as RectTransform;
		float x = Random.Range(0f, rectTransform2.rect.width - rectTransform.sizeDelta.x);
		float y = Random.Range(0f + rectTransform.sizeDelta.y, rectTransform2.rect.height);
		rectTransform.localPosition = new Vector2(x, y);
	}
}
