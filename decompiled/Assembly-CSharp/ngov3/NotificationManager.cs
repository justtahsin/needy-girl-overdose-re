using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class NotificationManager : SingletonMonoBehaviour<NotificationManager>
{
	public RectTransform _notiferParent;

	[SerializeField]
	private Notification _notiferPrefab;

	public RectTransform NotiferParent => _notiferParent;

	protected override void Awake()
	{
		base.Awake();
		_notiferParent = base.gameObject.transform as RectTransform;
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Subscribe(delegate(CollectionAddEvent<JineData> JineData)
		{
			if (JineData.Value.user != JineUserType.pi && JineData.Value.user != JineUserType.separator && JineData.Value.user != JineUserType.timeSeparator && JineData.Value.user != JineUserType.eventSeparator)
			{
				NotifierSound(AppType.Jine);
				if (!SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.Jine) || SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Jine).windowState == WindowState.minimized)
				{
					AddNotifier(AppType.Jine, NgoEx.GetJineNotificationText(JineData.Value, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
				}
				SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Jine));
			}
		}).AddTo(base.gameObject);
		(from _ in SingletonMonoBehaviour<PoketterManager>.Instance.OnAddQueue
			where SingletonMonoBehaviour<EventManager>.Instance.executingAction == CmdType.None
			where SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Yarisute
			where SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Av
			where SingletonMonoBehaviour<EventManager>.Instance.isTestScene || SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) != 1
			select _).Subscribe(async delegate
		{
			if (!SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.Poketter) || !SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.Result))
			{
				string nakami = NgoEx.SystemTextFromType(SystemTextType.New_Tweet_Button, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value).Replace("X", SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count.ToString());
				ReplacePoketterNotifier(AppType.Poketter, nakami);
				await UniTask.Delay(1200);
			}
			else
			{
				SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Poketter));
				await UniTask.Delay(1200);
				SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll()
					.Forget();
			}
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<PoketterManager>.Instance.OnRemoveQueue.Subscribe(delegate
		{
			if (GetSameAppNotification(AppType.Poketter) != null)
			{
				UnityEngine.Object.Destroy(GetSameAppNotification(AppType.Poketter).gameObject);
			}
		}).AddTo(base.gameObject);
	}

	private string getDestTimeString(int destTime, LanguageType lang)
	{
		return destTime switch
		{
			1 => NgoEx.SystemTextFromType(SystemTextType.System_GO_Daypart1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), 
			2 => NgoEx.SystemTextFromType(SystemTextType.System_GO_Daypart2, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), 
			_ => NgoEx.SystemTextFromType(SystemTextType.System_GO_NextDay, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), 
		};
	}

	public void AddMaturoNotifier()
	{
		Notification notifier = UnityEngine.Object.Instantiate(_notiferPrefab, _notiferParent);
		AudioManager.Instance.PlaySeByType(SoundType.SE_piyo);
		int num = 3;
		AppType appType = AppType.None;
		appType = num switch
		{
			1 => AppType.Daypart1, 
			2 => AppType.Daypart2, 
			3 => AppType.Daypart3, 
			_ => AppType.Daypart0, 
		};
		string text = "";
		LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		notifier.SetData(appType, value switch
		{
			LanguageType.JP => "そして……", 
			LanguageType.CN => "然后", 
			_ => "...", 
		});
		notifier.transform.GetChild(0).GetComponent<Image>().DOColor(new Color(83f / 85f, 0.8901961f, 0.99607843f, 1f), 0.2f)
			.SetLoops(-1, LoopType.Yoyo)
			.Play();
		Notification notification = notifier;
		notification.clickedAction = (Notification.ClickedAction)Delegate.Combine(notification.clickedAction, (Notification.ClickedAction)delegate
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.DayPart, 3);
			UnityEngine.Object.Destroy(notifier.gameObject);
		});
		notifier.button.OnPointerDownAsObservable().Subscribe(delegate
		{
			notifier.clickedAction();
		}).AddTo(notifier);
		notifier.Show();
	}

	public void AddTimePassingNotifier(int time = 1)
	{
		Notification notifier = UnityEngine.Object.Instantiate(_notiferPrefab, _notiferParent);
		AudioManager.Instance.PlaySeByType(SoundType.SE_piyo);
		int num = time + SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart);
		AppType appType = AppType.None;
		notifier.SetData(num switch
		{
			1 => AppType.Daypart1, 
			2 => AppType.Daypart2, 
			3 => AppType.Daypart3, 
			_ => AppType.Daypart0, 
		}, getDestTimeString(num, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		notifier.transform.GetChild(0).GetComponent<Image>().DOColor(new Color(83f / 85f, 0.8901961f, 0.99607843f, 1f), 0.2f)
			.SetLoops(-1, LoopType.Yoyo)
			.Play();
		Notification notification = notifier;
		notification.clickedAction = (Notification.ClickedAction)Delegate.Combine(notification.clickedAction, (Notification.ClickedAction)delegate
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEvent($"TimePassing{time}");
			Clean();
			UnityEngine.Object.Destroy(notifier.gameObject);
		});
		notifier.button.OnPointerDownAsObservable().Subscribe(delegate
		{
			notifier.clickedAction();
		}).AddTo(notifier);
		SingletonMonoBehaviour<EventManager>.Instance.ClearEventQueue();
		notifier.Show();
	}

	public void AddDayPassingNotifier()
	{
		Notification notifier = UnityEngine.Object.Instantiate(_notiferPrefab, _notiferParent);
		AudioManager.Instance.PlaySeByType(SoundType.SE_piyo);
		int destTime = 3;
		AppType app = AppType.Daypart0;
		notifier.SetData(app, getDestTimeString(destTime, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		SingletonMonoBehaviour<EventManager>.Instance.ClearEventQueue();
		notifier.transform.GetChild(0).GetComponent<Image>().DOColor(new Color(83f / 85f, 0.8901961f, 0.99607843f, 1f), 0.2f)
			.SetLoops(-1, LoopType.Yoyo)
			.Play();
		Notification notification = notifier;
		notification.clickedAction = (Notification.ClickedAction)Delegate.Combine(notification.clickedAction, (Notification.ClickedAction)delegate
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEvent<DayPassing>();
			Clean();
			UnityEngine.Object.Destroy(notifier.gameObject);
		});
		notifier.button.OnPointerDownAsObservable().Subscribe(delegate
		{
			notifier.clickedAction();
		}).AddTo(notifier);
		notifier.Show();
	}

	public void osimai()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.EndingDialog).Uncloseable();
	}

	private Notification AddNotifier(AppType app, string nakami)
	{
		Notification notifier = UnityEngine.Object.Instantiate(_notiferPrefab, _notiferParent);
		notifier.SetData(app, nakami);
		SingletonMonoBehaviour<WindowManager>.Instance.OnAdd.Where((CollectionAddEvent<IWindow> w) => w.Value.appType == app).Subscribe(delegate
		{
			UnityEngine.Object.Destroy(notifier.gameObject);
		}).AddTo(notifier);
		Notification notification = notifier;
		notification.clickedAction = (Notification.ClickedAction)Delegate.Combine(notification.clickedAction, (Notification.ClickedAction)delegate
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(app);
		});
		notifier.button.OnPointerDownAsObservable().Subscribe(delegate
		{
			notifier.clickedAction();
		}).AddTo(notifier);
		notifier.Show();
		return notifier;
	}

	public void AddUrauraNotifier(string nakami)
	{
		Notification notifier = UnityEngine.Object.Instantiate(_notiferPrefab, _notiferParent);
		notifier.SetData(AppType.None, nakami);
		Notification notification = notifier;
		notification.clickedAction = (Notification.ClickedAction)Delegate.Combine(notification.clickedAction, (Notification.ClickedAction)delegate
		{
			IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Uratter);
			window.Maximize();
			window.Uncloseable();
			AudioManager.Instance.StopBgm();
			UnityEngine.Object.Destroy(notifier.gameObject);
		});
		notifier.button.OnPointerDownAsObservable().Subscribe(delegate
		{
			notifier.clickedAction();
		}).AddTo(notifier);
		NotifierSound();
		notifier.Show();
	}

	private void ChipNotifier(string nakami, AlphaLevel chip)
	{
		Notification notifier = UnityEngine.Object.Instantiate(_notiferPrefab, _notiferParent);
		notifier.SetData(AppType.NetaChoose, nakami);
		Notification notification = notifier;
		notification.clickedAction = (Notification.ClickedAction)Delegate.Combine(notification.clickedAction, (Notification.ClickedAction)delegate
		{
			SingletonMonoBehaviour<NetaManager>.Instance.ShowingGettingChip(chip.alphaType, chip.level);
			UnityEngine.Object.Destroy(notifier.gameObject, 2f);
		});
		notifier.button.OnPointerDownAsObservable().Subscribe(delegate
		{
			notifier.clickedAction();
		}).AddTo(notifier);
		NotifierSound(AppType.NetaChoose);
		notifier.Show();
	}

	public void Clean()
	{
		for (int num = _notiferParent.childCount - 1; num >= 0; num--)
		{
			UnityEngine.Object.Destroy(_notiferParent.GetChild(num).gameObject);
		}
	}

	private void ReplacePoketterNotifier(AppType app, string nakami)
	{
		Notification sameAppNotification = GetSameAppNotification(app);
		Notification n;
		if (sameAppNotification == null)
		{
			n = AddNotifier(app, nakami);
		}
		else
		{
			n = sameAppNotification;
			sameAppNotification.SetData(app, nakami);
		}
		Notification notification = n;
		notification.clickedAction = (Notification.ClickedAction)Delegate.Combine(notification.clickedAction, (Notification.ClickedAction)delegate
		{
			SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
		});
		n.button.OnPointerDownAsObservable().Subscribe(async delegate
		{
			n.clickedAction();
		}).AddTo(this);
	}

	private Notification GetSameAppNotification(AppType app)
	{
		for (int i = 0; i < _notiferParent.childCount; i++)
		{
			Notification component = _notiferParent.GetChild(i).GetComponent<Notification>();
			if (component.app == app)
			{
				return component;
			}
		}
		return null;
	}

	private void NotifierSound(AppType app = AppType.None)
	{
		switch (app)
		{
		case AppType.Jine:
			AudioManager.Instance?.PlaySeByType(SoundType.SE_jine_recieve);
			break;
		case AppType.Poketter:
			AudioManager.Instance?.PlaySeByType(SoundType.SE_result_start);
			break;
		default:
			AudioManager.Instance?.PlaySeByType(SoundType.SE_piyo);
			break;
		}
	}
}
