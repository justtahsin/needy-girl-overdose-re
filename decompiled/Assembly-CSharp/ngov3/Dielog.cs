using System.Collections.Generic;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Dielog : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _notionText;

	[SerializeField]
	private Button _submitButton;

	[SerializeField]
	private Button _dismissButton;

	public List<GameObject> SelectableObejcts => new List<GameObject> { _submitButton.gameObject, _dismissButton.gameObject };

	public void Start()
	{
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
		{
			OnLanguageChanged();
		}).AddTo(this);
		OnLanguageChanged();
		_submitButton.OnClickAsObservable().Subscribe(delegate
		{
			OnSubmit();
		}).AddTo(this);
		_dismissButton.OnClickAsObservable().Subscribe(delegate
		{
			OnSubmit();
		}).AddTo(this);
	}

	private void OnSubmit()
	{
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Scenario_horror_day3_day_AfterSine>();
	}

	private void OnLanguageChanged()
	{
		_notionText.text = NgoEx.TenTalk("Ending_KowaiInternet_Day3_Title", SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_submitButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_dismissButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}
}
