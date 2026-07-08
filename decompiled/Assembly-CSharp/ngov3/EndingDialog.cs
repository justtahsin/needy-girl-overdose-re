using System;
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

	public GameObject SubmitButtonObject => ((Component)_submitButton).gameObject;

	public void Awake()
	{
		end = SingletonMonoBehaviour<EventManager>.Instance.nowEnding;
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
		SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(ShortcutInputManager.ControllerMode.Desktop);
	}

	private void OnSubmit()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<EventManager>.Instance.CallEnding();
	}

	private void OnLanguageChanged()
	{
		_notionText.text = NgoEx.ReasonTextFromEDType(end, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		string text = ((SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Ideon) ? NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) : NgoEx.SystemTextFromType(SystemTextType.System_Thankyou, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		text = text.Replace("\r", "").Replace("\n", "");
		((Component)_submitButton).GetComponentInChildren<TMP_Text>().text = text;
	}
}
