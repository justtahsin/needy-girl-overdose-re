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
		_startButton.OnClickAsObservable().Subscribe(delegate
		{
			OnStartButton.OnNext(_startButton);
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
		{
			OnLanguageUpdated();
		}).AddTo(base.gameObject);
	}

	public void OnLanguageUpdated()
	{
		_startButton.GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Open, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}
}
