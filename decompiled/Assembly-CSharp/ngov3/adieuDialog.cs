using System.Collections.Generic;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ngov3;

public class adieuDialog : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _notionText;

	[SerializeField]
	private Button _submitButton;

	[SerializeField]
	private Button _dismissButton;

	public List<GameObject> SelectableObjects => new List<GameObject> { _dismissButton.gameObject, _submitButton.gameObject };

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
		_submitButton.OnClickAsObservable().Subscribe(delegate
		{
			OnSubmit();
		}).AddTo(this);
		_dismissButton.OnClickAsObservable().Subscribe(delegate
		{
			Close();
		}).AddTo(this);
	}

	private void Close()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.Close(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.LastEnd));
	}

	private void OnSubmit()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
		SingletonMonoBehaviour<Settings>.Instance.saveNumber = 0;
		SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = false;
		SceneManager.LoadScene("WindowUITestScene");
	}

	private void OnLanguageChanged()
	{
		string text = NgoEx.SystemTextFromType(SystemTextType.adieuDialog, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_notionText.text = text;
		_submitButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_dismissButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_Cancell, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}
}
