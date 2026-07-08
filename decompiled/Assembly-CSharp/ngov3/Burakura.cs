using System.Collections.Generic;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Burakura : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _headerText;

	[SerializeField]
	private TMP_Text _nakamiText;

	[SerializeField]
	private TMP_Text _buttonText;

	[SerializeField]
	private Button _openButton;

	[SerializeField]
	private List<Sprite> sprites;

	public void Awake()
	{
	}

	public void Start()
	{
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
		{
			OnLanguageChanged();
		}).AddTo(this);
		OnLanguageChanged();
		_openButton.OnClickAsObservable().Subscribe(delegate
		{
			OnSubmit();
		}).AddTo(this);
	}

	private void OnSubmit()
	{
		GameObject.Find("MainPanel").GetComponent<Image>().sprite = sprites.RandomizedElement();
	}

	private void OnLanguageChanged()
	{
		_headerText.text = NgoEx.EventTextTypeToText(EventTextType.Event_Ayashii_System002, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_nakamiText.text = NgoEx.EventTextTypeToText(EventTextType.Event_Ayashii_System003, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_buttonText.text = NgoEx.EventTextTypeToText(EventTextType.Event_Ayashii_System004, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}
}
