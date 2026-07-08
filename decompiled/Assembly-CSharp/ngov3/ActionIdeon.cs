using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ActionIdeon : MonoBehaviour
{
	[SerializeField]
	private Button _button;

	[SerializeField]
	private Image _buttonImage;

	[SerializeField]
	private GameObject _Hint;

	private IDisposable token;

	public void Awake()
	{
		if (token != null)
		{
			token.Dispose();
		}
		SetExecutable();
	}

	private void SetExecutable()
	{
		((Selectable)_button).interactable = true;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(Observable.ThrottleFirst<Unit>(Observable.TakeUntilDestroy<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_button), (Component)(object)this), TimeSpan.FromMilliseconds(2000.0)), (Action<Unit>)delegate
		{
			OnCommand();
		}), (Component)(object)_button);
	}

	public void OnCommand()
	{
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<HaishinStart_Ideon>();
	}
}
