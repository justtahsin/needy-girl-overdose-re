using System;
using Cysharp.Threading.Tasks;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class TextInputItem : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField _input;

	[SerializeField]
	private TMP_Text _inputPlaceHolderText;

	[SerializeField]
	private Button _openAnimationCategory;

	[SerializeField]
	private TextInputItem textInputItemPrefab;

	[SerializeField]
	private TextMeshProUGUI box_name;

	private Live_gen parentLiveGen;

	private Vector2 defaultSize;

	private Vector2 prevSize;

	[SerializeField]
	private Image backImage;

	[SerializeField]
	private Color selectedColor;

	[SerializeField]
	private Color nonSelectedColor;

	[SerializeField]
	private Color nonSelectedAnimationKeyColor;

	[SerializeField]
	private Image animationKeyButtonImage;

	[SerializeField]
	private bool isSelected;

	public ReactiveProperty<string> AnimationKey;

	[SerializeField]
	private int paddingHight = 15;

	public TMP_InputField Input => _input;

	public int Index => base.transform.GetSiblingIndex();

	public bool IsSelected => isSelected;

	public void SetSelected(bool isSelected)
	{
		this.isSelected = isSelected;
		SetSelectDisplay(isSelected);
	}

	private async void Start()
	{
		defaultSize = GetComponent<RectTransform>().sizeDelta;
		prevSize = defaultSize;
		_inputPlaceHolderText.text = NgoEx.SystemTextFromType(SystemTextType.live_gen_text_limt, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		AnimationKey.Subscribe(delegate(string value)
		{
			if (value == "")
			{
				animationKeyButtonImage.color = nonSelectedAnimationKeyColor;
			}
			else
			{
				animationKeyButtonImage.color = selectedColor;
			}
		}).AddTo(base.gameObject);
		_input.onValueChanged.AddListener(async delegate(string text)
		{
			if (text.Contains(Environment.NewLine) || text.Contains("\r") || text.Contains("\n"))
			{
				RemoveNewLine();
			}
			SetSizeFromTextSize();
		});
		_input.onSelect.AddListener(delegate
		{
			SetSelected(isSelected: true);
		});
		_input.onEndEdit.AddListener(delegate(string t)
		{
			SetSelected(isSelected: false);
			_input.text = t.Replace(Environment.NewLine, "");
		});
	}

	public async void DeleatItem()
	{
		Transform child = base.transform.parent.GetChild(Index - 1);
		if (child != null)
		{
			TextInputItem upperTextInput = child.GetComponent<TextInputItem>();
			parentLiveGen.RemoveTextInput(this);
			UnityEngine.Object.Destroy(base.gameObject);
			await UniTask.Delay(1000);
			upperTextInput.Input.Select();
			upperTextInput.SetSelected(isSelected: true);
		}
	}

	public void CreateChildItem()
	{
		TextInputItem textInputItem = CreateNewTextInput("", base.transform.GetSiblingIndex() + 1);
		textInputItem.Input.Select();
		textInputItem.SetSelected(isSelected: true);
	}

	private void RemoveNewLine()
	{
		string text = _input.text.Replace("\r", "").Replace("\n", "");
		_input.text = text;
	}

	private TextInputItem CreateNewTextInput(string text, int index)
	{
		TextInputItem textInputItem = PrefabFolder.InstantiateTo<TextInputItem>(textInputItemPrefab, base.transform.parent);
		textInputItem.gameObject.name = "input";
		textInputItem.SetText(text);
		textInputItem.GetComponent<RectTransform>().sizeDelta = defaultSize;
		textInputItem.transform.SetSiblingIndex(index);
		textInputItem.Initialize(parentLiveGen);
		textInputItem.AnimationKey.Value = "";
		SetSelected(isSelected: false);
		parentLiveGen.AddTextInput(textInputItem);
		return textInputItem;
	}

	private void SetSelectDisplay(bool onSelect)
	{
		backImage.color = (onSelect ? selectedColor : nonSelectedColor);
	}

	private void SetSizeFromTextSize()
	{
		RectTransform component = GetComponent<RectTransform>();
		Vector2 preferredValues = box_name.GetPreferredValues();
		Debug.Log("textHight=" + preferredValues.y);
		component.sizeDelta = new Vector2(component.sizeDelta.x, preferredValues.y + (float)paddingHight);
		if (prevSize.y != component.sizeDelta.y)
		{
			parentLiveGen.FixTextGridLayout();
		}
		prevSize = component.sizeDelta;
		box_name.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
	}

	public void SetText(string text)
	{
		_input.text = text;
	}

	public void Initialize(Live_gen parentLiveGen)
	{
		this.parentLiveGen = parentLiveGen;
		_openAnimationCategory.onClick.AddListener(delegate
		{
			SetSelectDisplay(onSelect: true);
			this.parentLiveGen.ShowCategoryParent();
			this.parentLiveGen.SetSelectedTextInput(this);
		});
	}
}
