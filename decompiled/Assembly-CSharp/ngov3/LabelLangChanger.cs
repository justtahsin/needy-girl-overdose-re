using System;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;

namespace ngov3;

public class LabelLangChanger : MonoBehaviour
{
	public SystemTextType type;

	[SerializeField]
	private TMP_Text label;

	public void Start()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			AddLabel();
		}), ((Component)this).gameObject);
		AddLabel();
	}

	private void AddLabel()
	{
		if (!((Object)(object)label == (Object)null))
		{
			label.text = NgoEx.SystemTextFromType(type, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
	}
}
