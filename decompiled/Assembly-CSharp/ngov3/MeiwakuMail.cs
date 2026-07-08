using System;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class MeiwakuMail : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _notionText;

	[SerializeField]
	private Button _openButton;

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
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_openButton), (Action<Unit>)delegate
		{
			OnSubmit();
		}), (Component)(object)this);
	}

	private void OnSubmit()
	{
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Event_AyasiiSystem_Crasher>();
	}

	private void OnLanguageChanged()
	{
		_notionText.text = NgoEx.EventTextTypeToText(EventTextType.Event_Ayashii_System001, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}
}
