using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class EndingDialog : MonoBehaviour
{
	private EndingType end;

	[SerializeField]
	private TMP_Text _notionText;

	[SerializeField]
	private Button _submitButton;

	public GameObject SubmitButtonObject => _submitButton.gameObject;

	public void Awake()
	{
		end = SingletonMonoBehaviour<EventManager>.Instance.nowEnding;
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
		SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(ShortcutInputManager.ControllerMode.Desktop);
	}

	private void OnSubmit()
	{
		SingletonMonoBehaviour<EventManager>.Instance.CallEnding();
	}

	private void OnLanguageChanged()
	{
		_notionText.text = NgoEx.ReasonTextFromEDType(end, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		string text = ((SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Ideon) ? NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) : NgoEx.SystemTextFromType(SystemTextType.System_Thankyou, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		text = text.Replace("\r", "").Replace("\n", "");
		_submitButton.GetComponentInChildren<TMP_Text>().text = text;
	}
}
