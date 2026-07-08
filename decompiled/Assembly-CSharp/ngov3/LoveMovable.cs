using NGO;
using TMPro;
using UnityEngine;

namespace ngov3;

public class LoveMovable : MonoBehaviour
{
	[SerializeField]
	protected TMP_Text love;

	public void Awake()
	{
		love.text = NgoEx.StatusTextFromType(StatusTextType.Status_Affection80, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
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
