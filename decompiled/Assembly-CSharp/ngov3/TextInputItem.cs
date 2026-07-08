using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
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

	public int Index => ((Component)this).transform.GetSiblingIndex();

	public bool IsSelected => isSelected;

	public void SetSelected(bool isSelected)
	{
		this.isSelected = isSelected;
		SetSelectDisplay(isSelected);
	}

	private async void Start()
	{
		defaultSize = ((Component)this).GetComponent<RectTransform>().sizeDelta;
		prevSize = defaultSize;
		_inputPlaceHolderText.text = NgoEx.SystemTextFromType(SystemTextType.live_gen_text_limt, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<string>((IObservable<string>)AnimationKey, (Action<string>)delegate(string value)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			if (value == "")
			{
				((Graphic)animationKeyButtonImage).color = nonSelectedAnimationKeyColor;
			}
			else
			{
				((Graphic)animationKeyButtonImage).color = selectedColor;
			}
		}), ((Component)this).gameObject);
		((UnityEvent<string>)(object)_input.onValueChanged).AddListener((UnityAction<string>)async delegate(string text)
		{
			if (text.Contains(Environment.NewLine) || text.Contains("\r") || text.Contains("\n"))
			{
				RemoveNewLine();
			}
			SetSizeFromTextSize();
		});
		((UnityEvent<string>)(object)_input.onSelect).AddListener((UnityAction<string>)delegate
		{
			SetSelected(isSelected: true);
		});
		((UnityEvent<string>)(object)_input.onEndEdit).AddListener((UnityAction<string>)delegate(string t)
		{
			SetSelected(isSelected: false);
			_input.text = t.Replace(Environment.NewLine, "");
		});
	}

	public async void DeleatItem()
	{
		Transform child = ((Component)this).transform.parent.GetChild(Index - 1);
		if ((Object)(object)child != (Object)null)
		{
			TextInputItem upperTextInput = ((Component)child).GetComponent<TextInputItem>();
			parentLiveGen.RemoveTextInput(this);
			Object.Destroy((Object)(object)((Component)this).gameObject);
			await UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
			((Selectable)upperTextInput.Input).Select();
			upperTextInput.SetSelected(isSelected: true);
		}
	}

	public void CreateChildItem()
	{
		TextInputItem textInputItem = CreateNewTextInput("", ((Component)this).transform.GetSiblingIndex() + 1);
		((Selectable)textInputItem.Input).Select();
		textInputItem.SetSelected(isSelected: true);
	}

	private void RemoveNewLine()
	{
		string text = _input.text.Replace("\r", "").Replace("\n", "");
		_input.text = text;
	}

	private TextInputItem CreateNewTextInput(string text, int index)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		TextInputItem textInputItem = PrefabFolder.InstantiateTo<TextInputItem>((MonoBehaviour)(object)textInputItemPrefab, ((Component)this).transform.parent);
		((Object)((Component)textInputItem).gameObject).name = "input";
		textInputItem.SetText(text);
		((Component)textInputItem).GetComponent<RectTransform>().sizeDelta = defaultSize;
		((Component)textInputItem).transform.SetSiblingIndex(index);
		textInputItem.Initialize(parentLiveGen);
		textInputItem.AnimationKey.Value = "";
		SetSelected(isSelected: false);
		parentLiveGen.AddTextInput(textInputItem);
		return textInputItem;
	}

	private void SetSelectDisplay(bool onSelect)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		((Graphic)backImage).color = (onSelect ? selectedColor : nonSelectedColor);
	}

	private void SetSizeFromTextSize()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		RectTransform component = ((Component)this).GetComponent<RectTransform>();
		Vector2 preferredValues = ((TMP_Text)box_name).GetPreferredValues();
		Debug.Log((object)("textHight=" + preferredValues.y));
		component.sizeDelta = new Vector2(component.sizeDelta.x, preferredValues.y + (float)paddingHight);
		if (prevSize.y != component.sizeDelta.y)
		{
			parentLiveGen.FixTextGridLayout();
		}
		prevSize = component.sizeDelta;
		((Component)box_name).GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
	}

	public void SetText(string text)
	{
		_input.text = text;
	}

	public void Initialize(Live_gen parentLiveGen)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		this.parentLiveGen = parentLiveGen;
		((UnityEvent)_openAnimationCategory.onClick).AddListener((UnityAction)delegate
		{
			SetSelectDisplay(onSelect: true);
			this.parentLiveGen.ShowCategoryParent();
			this.parentLiveGen.SetSelectedTextInput(this);
		});
	}
}
