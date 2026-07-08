using System;
using System.Collections.Generic;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ngov3;

public class ActionButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private ActionType actionType = ActionType.None;

	[SerializeField]
	private TooltipCaller _tooltip;

	[SerializeField]
	private ActionStatus actionStatus = ActionStatus.Executable;

	[SerializeField]
	private Button _button;

	[SerializeField]
	private Image _buttonImage;

	[SerializeField]
	private GameObject _Hint;

	[SerializeField]
	private CanvasGroup _canvas;

	[SerializeField]
	private TMP_Text label;

	public bool isNeedDoubleClick;

	private ReactiveProperty<int> _dayPart;

	private ReactiveProperty<int> _dayIndex;

	private bool isHinted;

	private IDisposable token;

	public void Awake()
	{
		_dayIndex = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex);
		_dayPart = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart);
		SetLabel();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Dictionary<ActionType, ActionStatus>>((IObservable<Dictionary<ActionType, ActionStatus>>)SingletonMonoBehaviour<CommandManager>.Instance.commandStatus, (Action<Dictionary<ActionType, ActionStatus>>)delegate(Dictionary<ActionType, ActionStatus> s)
		{
			SetStatus(s[actionType]);
		}), (Component)(object)this);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)_dayPart, (Action<int>)delegate
		{
			SetStatus();
		}), (Component)(object)this);
	}

	public void Start()
	{
	}

	private void SetLabel()
	{
		label.text = CommandHelper.GetCommandTitle(actionType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	private void SetStatus(ActionStatus a = ActionStatus.Executable)
	{
		isHinted = SingletonMonoBehaviour<CommandManager>.Instance.isHinted(actionType);
		_Hint.SetActive(isHinted);
		if ((Object)(object)_tooltip != (Object)null)
		{
			_tooltip.isShowTooltip = isHinted;
		}
		if (isHinted && (Object)(object)_tooltip != (Object)null)
		{
			_tooltip.textNakami = NgoEx.SystemTextFromType(SystemTextType.System_NewNeta, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		actionStatus = a;
		if (actionType == ActionType.SleepToTwilight && _dayPart.Value > 0)
		{
			actionStatus = ActionStatus.Invisible;
		}
		if (actionType == ActionType.SleepToNight && _dayPart.Value > 1)
		{
			actionStatus = ActionStatus.Invisible;
		}
		if (token != null)
		{
			token.Dispose();
		}
		switch (actionStatus)
		{
		case ActionStatus.Executable:
			SetExecutable();
			break;
		case ActionStatus.Yada:
			SetYada();
			break;
		default:
			SetInvisible();
			break;
		}
	}

	private void SetInvisible()
	{
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
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(Observable.ThrottleFirst<Unit>(Observable.TakeUntilDestroy<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_button), (Component)(object)this), TimeSpan.FromMilliseconds(2000.0)), (Action<Unit>)delegate
		{
			OnCommand();
		}), (Component)(object)_button);
	}

	public void OnCommand()
	{
		SingletonMonoBehaviour<CommandManager>.Instance.CommandAction(actionType);
	}

	public void OnPointerEnter(PointerEventData e)
	{
		if (actionStatus == ActionStatus.Executable)
		{
			SingletonMonoBehaviour<CommandManager>.Instance.OnActionHovered(actionType);
		}
	}

	public void OnPointerExit(PointerEventData e)
	{
		SingletonMonoBehaviour<CommandManager>.Instance.OnBlur();
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		OnPointerEnter(null);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		OnPointerExit(null);
	}
}
