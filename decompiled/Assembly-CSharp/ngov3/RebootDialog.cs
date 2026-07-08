using System;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ngov3;

public class RebootDialog : MonoBehaviour
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
			Close();
		}), (Component)(object)this);
	}

	private void Close()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.Close(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.RebootDialog));
	}

	private void OnSubmit()
	{
		AudioManager.Instance?.StopBgm();
		SingletonMonoBehaviour<EventManager>.Instance.ClearEventQueue();
		PostEffectManager.Instance.ResetShader();
		SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
		SingletonMonoBehaviour<Settings>.Instance.saveNumber = 0;
		SingletonMonoBehaviour<Settings>.Instance.nowSaveFile = "";
		SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = false;
		SceneManager.LoadScene("BiosToLoad");
	}

	private void OnLanguageChanged()
	{
		_notionText.text = NgoEx.SystemTextFromType(SystemTextType.System_Reboot, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		((Component)_submitButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		((Component)_dismissButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dialog_Cancell, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}
}
