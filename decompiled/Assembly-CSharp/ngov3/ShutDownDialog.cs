using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ShutDownDialog : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _notionText;

	[SerializeField]
	private Button _submitButton;

	[SerializeField]
	private Button _dismissButton;

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
		SingletonMonoBehaviour<WindowManager>.Instance.Close(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.ShutDownDialog));
	}

	private void OnSubmit()
	{
		Application.Quit();
	}

	private void OnLanguageChanged()
	{
		_notionText.text = NgoEx.SystemTextFromType(SystemTextType.Start_Alert_ShutDown, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_submitButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_dismissButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_Cancell, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}
}
