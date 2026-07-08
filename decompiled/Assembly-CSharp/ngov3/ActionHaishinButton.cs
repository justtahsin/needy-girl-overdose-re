using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ngov3;

public class ActionHaishinButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private ActionType actionType = ActionType.None;

	[SerializeField]
	private int PassingTime = 1;

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

	private ReactiveProperty<int> _dayPart;

	private ReactiveProperty<int> _dayIndex;

	private bool isHinted;

	private IDisposable token;

	public void Awake()
	{
		_dayIndex = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex);
		_dayPart = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart);
	}

	private void SetLabel()
	{
	}

	private void SetStatus(int v)
	{
		if (token != null)
		{
			token.Dispose();
		}
		if (v == 2)
		{
			SetExecutable();
		}
		else
		{
			SetYada();
		}
	}

	private void SetYada()
	{
		_canvas.alpha = 1f;
		_canvas.interactable = true;
		_canvas.blocksRaycasts = true;
		_button.interactable = false;
	}

	private void SetExecutable()
	{
		_canvas.alpha = 1f;
		_canvas.interactable = true;
		_canvas.blocksRaycasts = true;
		_button.interactable = true;
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
}
