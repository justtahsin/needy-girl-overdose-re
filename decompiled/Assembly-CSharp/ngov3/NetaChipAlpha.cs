using System;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ngov3;

public class NetaChipAlpha : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private TMP_Text genre;

	[SerializeField]
	private TMP_Text label;

	[SerializeField]
	private Image bg;

	[SerializeField]
	private Sprite graybg;

	[SerializeField]
	public Button button;

	[SerializeField]
	private bool isDiscovered;

	public AlphaType type = AlphaType.none;

	public int alphaLevel;

	private NetachipChooser Chooser;

	[SerializeField]
	public TooltipCaller _tooltip;

	[SerializeField]
	private Sprite _l1;

	[SerializeField]
	private Sprite _l2;

	[SerializeField]
	private Sprite _l3;

	[SerializeField]
	private Sprite _l4;

	[SerializeField]
	private Sprite _l5;

	private Color BlueBlack = new Color(0.3019608f, 7f / 51f, 69f / 85f, 1f);

	private Color Gray = new Color(0.4862745f, 0.4862745f, 0.4862745f, 1f);

	public bool IsChoosable
	{
		get
		{
			if (isDiscovered)
			{
				return button.interactable;
			}
			return false;
		}
	}

	public void ShowType(AlphaType type, int alphaLevel = 0, bool isDiscovered = false)
	{
		this.type = type;
		this.alphaLevel = alphaLevel;
		this.isDiscovered = isDiscovered;
		Show();
	}

	public void SetType(AlphaType type, int alphaLevel = 0, bool isDiscovered = false)
	{
		this.type = type;
		this.alphaLevel = alphaLevel;
		this.isDiscovered = isDiscovered;
		Show();
		SetChooseable();
	}

	public void SetData(int Id, int alphaLevel = 0, bool isUsed = false)
	{
		type = (AlphaType)Enum.ToObject(typeof(AlphaType), Id);
		this.alphaLevel = alphaLevel;
		isDiscovered = alphaLevel != 0;
		_tooltip.isShowTooltip = !isDiscovered;
		Show(isUsed);
		button.interactable = !isUsed;
		SetChooseable();
	}

	public void Discovered()
	{
		isDiscovered = true;
	}

	public void SetChooseable()
	{
		if (isDiscovered && type != AlphaType.none && alphaLevel != 0)
		{
			Chooser = base.gameObject.transform.parent.transform.parent.transform.parent.GetComponent<NetachipChooser>();
			_tooltip.isShowTooltip = true;
			button.OnClickAsObservable().Subscribe(delegate
			{
				_tooltip.Hide();
				Chooser.Choosed(type, alphaLevel);
			}).AddTo(button);
		}
	}

	private void Show(bool isUsed = false)
	{
		if (isDiscovered)
		{
			bg.sprite = GetLevelSprite(alphaLevel, type == AlphaType.Angel);
			genre.DOColor(BlueBlack, 0.2f).Play();
			label.DOColor(BlueBlack, 0.2f).Play();
			if (isUsed)
			{
				bg.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
			}
			AlphaTypeToData alphaTypeToData = LoadNetaData.ReadNetaContent(type, alphaLevel);
			LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
			genre.text = NgoEx.CmdName(alphaTypeToData.netaGenre, value);
			label.text = NgoEx.TenTalk(alphaTypeToData.netaName, value);
		}
		else
		{
			bg.sprite = graybg;
			genre.DOColor(Gray, 0.2f).Play();
			label.DOColor(Gray, 0.2f).Play();
			genre.text = "";
			label.text = "???";
		}
	}

	private Sprite GetLevelSprite(int level, bool angel = false)
	{
		if (angel)
		{
			return _l5;
		}
		return level switch
		{
			1 => _l1, 
			2 => _l2, 
			3 => _l3, 
			4 => _l4, 
			5 => _l5, 
			_ => _l1, 
		};
	}

	public void OnPointerEnter(PointerEventData e)
	{
		if (isDiscovered && _tooltip.isShowTooltip)
		{
			SingletonMonoBehaviour<CommandManager>.Instance.OnActionHovered(type, alphaLevel);
		}
	}

	public void OnPointerExit(PointerEventData e)
	{
		SingletonMonoBehaviour<CommandManager>.Instance.OnBlur();
	}
}
