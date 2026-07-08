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
		_button.interactable = true;
		_button.OnClickAsObservable().TakeUntilDestroy(this).ThrottleFirst(TimeSpan.FromMilliseconds(2000.0))
			.Subscribe(delegate
			{
				OnCommand();
			})
			.AddTo(_button);
	}

	public void OnCommand()
	{
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<HaishinStart_Ideon>();
	}
}
