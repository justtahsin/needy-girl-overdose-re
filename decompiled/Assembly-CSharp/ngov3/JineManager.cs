using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class JineManager : SingletonMonoBehaviour<JineManager>
{
	public enum WaitStatusType
	{
		Stamp,
		Option,
		FreeForm,
		ChooseAction,
		Uncontrolable
	}

	private LanguageType _lang;

	private ReactiveCollection<JineData> _history = new ReactiveCollection<JineData>();

	[SerializeField]
	public List<JineData> history = new List<JineData>();

	private readonly ReactiveCollection<JineData> _options = new ReactiveCollection<JineData>();

	public Subject<string> Message = new Subject<string>();

	public ReactiveProperty<WaitStatusType> waitStatus = new ReactiveProperty<WaitStatusType>(WaitStatusType.Stamp);

	[SerializeField]
	private Button _forTest;

	private bool isJinedThisTime;

	private int JINECOUNT_ONLOAD = 25;

	public IObservable<CollectionAddEvent<JineData>> OnChangeHistory => _history.ObserveAdd();

	public List<JineData> options => _options.ToList();

	public IObservable<CollectionAddEvent<JineData>> OnStartOptions => _options.ObserveAdd();

	public int JineCountOnLoad => JINECOUNT_ONLOAD;

	public void Start()
	{
		if (_forTest != null)
		{
			_forTest.OnClickAsObservable().Subscribe(delegate
			{
				AddJineHistoryFromType(JineDataConverter.RandomEnumValue<JineType>());
			}).AddTo(_forTest);
		}
		_lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex).Subscribe(delegate(int day)
		{
			addDaySeparator(day);
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart).Subscribe(delegate
		{
			isJinedThisTime = false;
		}).AddTo(base.gameObject);
		OnChangeHistory.Subscribe(delegate(CollectionAddEvent<JineData> value)
		{
			history.Add(value.Value);
		}).AddTo(this);
	}

	private void addDaySeparator(int day)
	{
		JineData item = new JineData(JineType.None, JineUserType.separator, day);
		_history.Add(item);
	}

	public void addTimeSeparator(int DayPart)
	{
		_history.Add(new JineData(JineType.None, JineUserType.timeSeparator, DayPart));
	}

	public void addEventSeparator(string separation)
	{
		_history.Add(new JineData(JineUserType.eventSeparator, JineType.None, ResponseType.Freeform, StampType.None, separation));
	}

	public void addEventSeparator(JineType type)
	{
		_history.Add(new JineData(JineUserType.eventSeparator, type));
	}

	public async UniTask AddJineHistory(JineData l)
	{
		if (!isJinedThisTime)
		{
			addTimeSeparator(SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart));
			isJinedThisTime = true;
		}
		if (l.user == JineUserType.ame && l.responseType == ResponseType.Stamp)
		{
			GetComponent<Event_WebCamSumaho>().StartLooking();
		}
		else
		{
			AudioManager.Instance?.PlaySeByType(SoundType.SE_jine_send_stamp);
		}
		_history.Add(l);
		if (l.user == JineUserType.ame && l.responseType == ResponseType.IdMessage)
		{
			switch (_lang)
			{
			case LanguageType.JP:
				await NgoEvent.DelaySkippable(JineDataConverter.convertJineDataToDrawable(l).BodyJp.Length * 180);
				break;
			case LanguageType.CN:
			case LanguageType.KO:
			case LanguageType.TW:
				await NgoEvent.DelaySkippable(JineDataConverter.convertJineDataToDrawable(l).BodyCn.Length * 200);
				break;
			default:
				await NgoEvent.DelaySkippable(JineDataConverter.convertJineDataToDrawable(l).BodyEn.Length * 120);
				break;
			}
		}
		GetComponent<Event_WebCamSumaho>().OnBlur();
	}

	public async UniTask AddJineHistoryFromString(string s, bool isAme = true)
	{
		JineUserType user = ((!isAme) ? JineUserType.pi : JineUserType.ame);
		await AddJineHistory(new JineData(user, JineType.None, ResponseType.Freeform, StampType.None, s));
	}

	public async UniTask AddJineHistory(JineType t)
	{
		await AddJineHistoryFromType(t);
	}

	public async UniTask AddJineHistoryFromType(JineType t)
	{
		JineData l = new JineData(t);
		await AddJineHistory(l);
	}

	public void Uncontrolable()
	{
		waitStatus.Value = WaitStatusType.Uncontrolable;
	}

	public void StartStamp()
	{
		waitStatus.Value = WaitStatusType.Stamp;
	}

	public void StartOption(List<JineType> l)
	{
		foreach (JineType item2 in l)
		{
			JineData item = new JineData(item2, JineUserType.pi);
			_options.Add(item);
		}
		if (SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.Jine))
		{
			SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Jine));
		}
		waitStatus.Value = WaitStatusType.Option;
	}

	public void StartOption(List<string> l)
	{
		foreach (string item2 in l)
		{
			JineData item = new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, item2);
			_options.Add(item);
		}
		if (SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.Jine))
		{
			SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Jine));
		}
		waitStatus.Value = WaitStatusType.Option;
	}

	public void EndOption()
	{
		_options.Clear();
	}

	public void StartMessage()
	{
		if (SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.Jine))
		{
			SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Jine));
		}
		waitStatus.Value = WaitStatusType.FreeForm;
	}

	public void EndMessage(string msg)
	{
		waitStatus.Value = WaitStatusType.Stamp;
		Message.OnNext(msg);
	}

	public List<JineData> GetHistoryRange(int start, int end)
	{
		if (start >= history.Count || history.Count == 0 || start > end)
		{
			return new List<JineData>();
		}
		if (end >= history.Count)
		{
			return history.GetRange(start, history.Count - start);
		}
		int count = end - start;
		return history.GetRange(start, count);
	}

	public List<JineData> GetNewest()
	{
		int num = Math.Max(0, history.Count - JINECOUNT_ONLOAD);
		if (num != 0)
		{
			return history.GetRange(num, JINECOUNT_ONLOAD);
		}
		return history.GetRange(num, history.Count);
	}
}
