using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public sealed class DayView : MonoBehaviour
{
	[SerializeField]
	private Button _calenderButton;

	[SerializeField]
	private TMP_Text _dayText;

	[SerializeField]
	private Image _dayIcon;

	[SerializeField]
	private Sprite _icon0;

	[SerializeField]
	private Sprite _icon1;

	[SerializeField]
	private Sprite _icon2;

	public Subject<Unit> OnCalenderButton = new Subject<Unit>();

	private Status dayIndex;

	private Status dayPart;

	public Button CalenderButton => _calenderButton;

	private void Start()
	{
		dayIndex = SingletonMonoBehaviour<StatusManager>.Instance.statuses.Find((Status s) => s.statusType == StatusType.DayIndex);
		dayPart = SingletonMonoBehaviour<StatusManager>.Instance.statuses.Find((Status s) => s.statusType == StatusType.DayPart);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)dayIndex.currentValue, (Action<int>)delegate(int d)
		{
			UpdateDay(d);
		}), (Component)(object)this);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)dayPart.currentValue, (Action<int>)delegate(int p)
		{
			UpdateIcon(p);
		}), (Component)(object)this);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			OnLanguageUpdated();
		}), (Component)(object)this);
		UpdateDay(dayIndex.currentValue.Value);
		UpdateIcon(dayPart.currentValue.Value);
	}

	private void UpdateDay(int index)
	{
		if (index > 30)
		{
			_dayText.text = "????";
		}
		else
		{
			string text = (_dayText.text = NgoEx.DayText(index, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		}
	}

	private void UpdateIcon(int index)
	{
		switch (index)
		{
		case 0:
			_dayIcon.sprite = _icon0;
			break;
		case 1:
			_dayIcon.sprite = _icon1;
			break;
		default:
			_dayIcon.sprite = _icon2;
			break;
		}
	}

	public void OnLanguageUpdated()
	{
		UpdateDay(dayIndex.currentValue.Value);
	}
}
