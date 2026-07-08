using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ngov3;

public class StartMenuButtonSwitcher : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private TMP_Text _label;

	private Image _buttonBg;

	[SerializeField]
	private Sprite _defaultSprite;

	[SerializeField]
	private Sprite _highlightedSprite;

	private Color _pinkWhite = new Color32(byte.MaxValue, 248, byte.MaxValue, byte.MaxValue);

	private Color _blueBlack = new Color32(77, 35, 207, byte.MaxValue);

	private void Awake()
	{
		_buttonBg = GetComponent<Image>();
		GetComponent<Button>().OnClickAsObservable().Subscribe(delegate
		{
			OnSubmitted();
		}).AddTo(base.gameObject);
	}

	private void OnSubmitted()
	{
		_buttonBg.sprite = _highlightedSprite;
		_label.color = _pinkWhite;
	}

	public void OnPointerEnter(PointerEventData e)
	{
		_buttonBg.sprite = _highlightedSprite;
		_label.color = _pinkWhite;
	}

	public void OnPointerExit(PointerEventData e)
	{
		_buttonBg.sprite = _defaultSprite;
		_label.color = _blueBlack;
	}
}
