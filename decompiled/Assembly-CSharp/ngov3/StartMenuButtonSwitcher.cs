using System;
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

	private Color _pinkWhite = Color32.op_Implicit(new Color32(byte.MaxValue, (byte)248, byte.MaxValue, byte.MaxValue));

	private Color _blueBlack = Color32.op_Implicit(new Color32((byte)77, (byte)35, (byte)207, byte.MaxValue));

	private void Awake()
	{
		_buttonBg = ((Component)this).GetComponent<Image>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(((Component)this).GetComponent<Button>()), (Action<Unit>)delegate
		{
			OnSubmitted();
		}), ((Component)this).gameObject);
	}

	private void OnSubmitted()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		_buttonBg.sprite = _highlightedSprite;
		((Graphic)_label).color = _pinkWhite;
	}

	public void OnPointerEnter(PointerEventData e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		_buttonBg.sprite = _highlightedSprite;
		((Graphic)_label).color = _pinkWhite;
	}

	public void OnPointerExit(PointerEventData e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		_buttonBg.sprite = _defaultSprite;
		((Graphic)_label).color = _blueBlack;
	}
}
