using System;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class CommandButton : MonoBehaviour
{
	[SerializeField]
	private WindowType windowType = WindowType.None;

	[SerializeField]
	private CommandType commandType = CommandType.None;

	[SerializeField]
	private CommandStatus commandStatus = CommandStatus.Executable;

	[SerializeField]
	private Button _button;

	[SerializeField]
	private Image _buttonImage;

	[SerializeField]
	private CanvasGroup _canvas;

	private string _iyaiyaText;

	[SerializeField]
	private TMP_Text label;

	private CommandManager _manager;

	public void Awake()
	{
		SetLabel();
		SetStatus();
	}

	private void SetLabel()
	{
		label.text = CommandHelper.GetCommandTitle(commandType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	private void SetStatus()
	{
		switch (commandStatus)
		{
		case CommandStatus.Executable:
			SetExecutable();
			break;
		case CommandStatus.Yada:
			SetYada();
			break;
		default:
			SetInvisible();
			break;
		}
	}

	private void SetInvisible()
	{
		_canvas.alpha = 0f;
		_canvas.interactable = false;
		_canvas.blocksRaycasts = false;
	}

	private void SetYada()
	{
		_canvas.alpha = 1f;
		_canvas.interactable = true;
		_canvas.blocksRaycasts = true;
		((Selectable)_button).interactable = false;
	}

	private void SetExecutable()
	{
		_canvas.alpha = 1f;
		_canvas.interactable = true;
		_canvas.blocksRaycasts = true;
		((Selectable)_button).interactable = true;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_button), (Action<Unit>)delegate
		{
			SingletonMonoBehaviour<CommandManager>.Instance.CommandAction(commandType, windowType);
		}), ((Component)this).gameObject);
	}
}
