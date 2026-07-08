using System;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class StartButton : MonoBehaviour
{
	[SerializeField]
	private Button _startButton;

	public Subject<Button> OnStartButton = new Subject<Button>();

	private void Awake()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_startButton), (Action<Unit>)delegate
		{
			OnStartButton.OnNext(_startButton);
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			OnLanguageUpdated();
		}), ((Component)this).gameObject);
	}

	public void OnLanguageUpdated()
	{
		((Component)_startButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Open, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}
}
