using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class TimePassDialog : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _notionText;

	[SerializeField]
	private Button _submitButton;

	[SerializeField]
	private Button _dismissButton;

	private ActionType actionType;

	private CmdType cmdType;

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

	public void setType(ActionType ac, CmdType a)
	{
		actionType = ac;
		cmdType = a;
	}

	private void Close()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.Close(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.TimePassDialog));
	}

	private async void OnSubmit()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.Close(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.TimePassDialog));
		await SingletonMonoBehaviour<EventManager>.Instance.ExecuteActionConfirmed(actionType, cmdType);
	}

	private void OnLanguageChanged()
	{
		_notionText.text = NgoEx.SystemTextFromType(SystemTextType.System_AlertHaishin, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_submitButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_dismissButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_Cancell, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}
}
