using System;
using System.Collections.Generic;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class HakkyoDialog : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _notionText;

	[SerializeField]
	private Button _submitButton;

	[SerializeField]
	private Button _dismissButton;

	public List<GameObject> SelectableObjects => new List<GameObject>
	{
		((Component)_submitButton).gameObject,
		((Component)_dismissButton).gameObject
	};

	public void Awake()
	{
	}

	public void Start()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			OnLanguageChanged();
		}), (Component)(object)this);
		OnLanguageChanged();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_submitButton), (Action<Unit>)delegate
		{
			OnSubmit();
		}), (Component)(object)this);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_dismissButton), (Action<Unit>)delegate
		{
			OnSubmit();
		}), (Component)(object)this);
	}

	private void OnSubmit()
	{
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Scenario_horror_day4_day_hakkyoed>();
	}

	private void OnLanguageChanged()
	{
		_notionText.text = "Gjhf.";
		((Component)_submitButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		((Component)_dismissButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_Cancell, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}
}
