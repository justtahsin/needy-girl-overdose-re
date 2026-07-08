using System;
using System.Collections.ObjectModel;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
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
		Transform transform = ((Component)this).gameObject.transform;
		_notiferParent = (RectTransform)(object)((transform is RectTransform) ? transform : null);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Action<CollectionAddEvent<JineData>>)delegate(CollectionAddEvent<JineData> JineData)
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
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<TweetData>>(Observable.Where<CollectionAddEvent<TweetData>>(Observable.Where<CollectionAddEvent<TweetData>>(Observable.Where<CollectionAddEvent<TweetData>>(Observable.Where<CollectionAddEvent<TweetData>>(SingletonMonoBehaviour<PoketterManager>.Instance.OnAddQueue, (Func<CollectionAddEvent<TweetData>, bool>)((CollectionAddEvent<TweetData> _) => SingletonMonoBehaviour<EventManager>.Instance.executingAction == CmdType.None)), (Func<CollectionAddEvent<TweetData>, bool>)((CollectionAddEvent<TweetData> _) => SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Yarisute)), (Func<CollectionAddEvent<TweetData>, bool>)((CollectionAddEvent<TweetData> _) => SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Av)), (Func<CollectionAddEvent<TweetData>, bool>)((CollectionAddEvent<TweetData> _) => SingletonMonoBehaviour<EventManager>.Instance.isTestScene || SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) != 1)), (Action<CollectionAddEvent<TweetData>>)async delegate
		{
			if (!SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.Poketter) || !SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.Result))
			{
				string nakami = NgoEx.SystemTextFromType(SystemTextType.New_Tweet_Button, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value).Replace("X", ((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count.ToString());
				ReplacePoketterNotifier(AppType.Poketter, nakami);
				await UniTask.Delay(1200, false, (PlayerLoopTiming)8, default(CancellationToken), false);
			}
			else
			{
				SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Poketter));
				await UniTask.Delay(1200, false, (PlayerLoopTiming)8, default(CancellationToken), false);
				UniTaskExtensions.Forget(SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll());
			}
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionRemoveEvent<TweetData>>(SingletonMonoBehaviour<PoketterManager>.Instance.OnRemoveQueue, (Action<CollectionRemoveEvent<TweetData>>)delegate
		{
			if ((Object)(object)GetSameAppNotification(AppType.Poketter) != (Object)null)
			{
				Object.Destroy((Object)(object)((Component)GetSameAppNotification(AppType.Poketter)).gameObject);
			}
		}), ((Component)this).gameObject);
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
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		Notification notifier = Object.Instantiate<Notification>(_notiferPrefab, (Transform)(object)_notiferParent);
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
		TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(TweenSettingsExtensions.SetLoops<TweenerCore<Color, Color, ColorOptions>>(DOTweenModuleUI.DOColor(((Component)((Component)notifier).transform.GetChild(0)).GetComponent<Image>(), new Color(83f / 85f, 0.8901961f, 0.99607843f, 1f), 0.2f), -1, (LoopType)1));
		Notification notification = notifier;
		notification.clickedAction = (Notification.ClickedAction)Delegate.Combine(notification.clickedAction, (Notification.ClickedAction)delegate
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.DayPart, 3);
			Object.Destroy((Object)(object)((Component)notifier).gameObject);
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(ObservableTriggerExtensions.OnPointerDownAsObservable((UIBehaviour)(object)notifier.button), (Action<PointerEventData>)delegate
		{
			notifier.clickedAction();
		}), (Component)(object)notifier);
		notifier.Show();
	}

	public void AddTimePassingNotifier(int time = 1)
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		Notification notifier = Object.Instantiate<Notification>(_notiferPrefab, (Transform)(object)_notiferParent);
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
		TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(TweenSettingsExtensions.SetLoops<TweenerCore<Color, Color, ColorOptions>>(DOTweenModuleUI.DOColor(((Component)((Component)notifier).transform.GetChild(0)).GetComponent<Image>(), new Color(83f / 85f, 0.8901961f, 0.99607843f, 1f), 0.2f), -1, (LoopType)1));
		Notification notification = notifier;
		notification.clickedAction = (Notification.ClickedAction)Delegate.Combine(notification.clickedAction, (Notification.ClickedAction)delegate
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEvent($"TimePassing{time}");
			Clean();
			Object.Destroy((Object)(object)((Component)notifier).gameObject);
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(ObservableTriggerExtensions.OnPointerDownAsObservable((UIBehaviour)(object)notifier.button), (Action<PointerEventData>)delegate
		{
			notifier.clickedAction();
		}), (Component)(object)notifier);
		SingletonMonoBehaviour<EventManager>.Instance.ClearEventQueue();
		notifier.Show();
	}

	public void AddDayPassingNotifier()
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		Notification notifier = Object.Instantiate<Notification>(_notiferPrefab, (Transform)(object)_notiferParent);
		AudioManager.Instance.PlaySeByType(SoundType.SE_piyo);
		int destTime = 3;
		AppType app = AppType.Daypart0;
		notifier.SetData(app, getDestTimeString(destTime, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		SingletonMonoBehaviour<EventManager>.Instance.ClearEventQueue();
		TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(TweenSettingsExtensions.SetLoops<TweenerCore<Color, Color, ColorOptions>>(DOTweenModuleUI.DOColor(((Component)((Component)notifier).transform.GetChild(0)).GetComponent<Image>(), new Color(83f / 85f, 0.8901961f, 0.99607843f, 1f), 0.2f), -1, (LoopType)1));
		Notification notification = notifier;
		notification.clickedAction = (Notification.ClickedAction)Delegate.Combine(notification.clickedAction, (Notification.ClickedAction)delegate
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEvent<DayPassing>();
			Clean();
			Object.Destroy((Object)(object)((Component)notifier).gameObject);
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(ObservableTriggerExtensions.OnPointerDownAsObservable((UIBehaviour)(object)notifier.button), (Action<PointerEventData>)delegate
		{
			notifier.clickedAction();
		}), (Component)(object)notifier);
		notifier.Show();
	}

	public void osimai()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.EndingDialog).Uncloseable();
	}

	private Notification AddNotifier(AppType app, string nakami)
	{
		Notification notifier = Object.Instantiate<Notification>(_notiferPrefab, (Transform)(object)_notiferParent);
		notifier.SetData(app, nakami);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<IWindow>>(Observable.Where<CollectionAddEvent<IWindow>>(SingletonMonoBehaviour<WindowManager>.Instance.OnAdd, (Func<CollectionAddEvent<IWindow>, bool>)((CollectionAddEvent<IWindow> w) => w.Value.appType == app)), (Action<CollectionAddEvent<IWindow>>)delegate
		{
			Object.Destroy((Object)(object)((Component)notifier).gameObject);
		}), (Component)(object)notifier);
		Notification notification = notifier;
		notification.clickedAction = (Notification.ClickedAction)Delegate.Combine(notification.clickedAction, (Notification.ClickedAction)delegate
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(app);
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(ObservableTriggerExtensions.OnPointerDownAsObservable((UIBehaviour)(object)notifier.button), (Action<PointerEventData>)delegate
		{
			notifier.clickedAction();
		}), (Component)(object)notifier);
		notifier.Show();
		return notifier;
	}

	public void AddUrauraNotifier(string nakami)
	{
		Notification notifier = Object.Instantiate<Notification>(_notiferPrefab, (Transform)(object)_notiferParent);
		notifier.SetData(AppType.None, nakami);
		Notification notification = notifier;
		notification.clickedAction = (Notification.ClickedAction)Delegate.Combine(notification.clickedAction, (Notification.ClickedAction)delegate
		{
			IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Uratter);
			window.Maximize();
			window.Uncloseable();
			AudioManager.Instance.StopBgm();
			Object.Destroy((Object)(object)((Component)notifier).gameObject);
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(ObservableTriggerExtensions.OnPointerDownAsObservable((UIBehaviour)(object)notifier.button), (Action<PointerEventData>)delegate
		{
			notifier.clickedAction();
		}), (Component)(object)notifier);
		NotifierSound();
		notifier.Show();
	}

	private void ChipNotifier(string nakami, AlphaLevel chip)
	{
		Notification notifier = Object.Instantiate<Notification>(_notiferPrefab, (Transform)(object)_notiferParent);
		notifier.SetData(AppType.NetaChoose, nakami);
		Notification notification = notifier;
		notification.clickedAction = (Notification.ClickedAction)Delegate.Combine(notification.clickedAction, (Notification.ClickedAction)delegate
		{
			SingletonMonoBehaviour<NetaManager>.Instance.ShowingGettingChip(chip.alphaType, chip.level);
			Object.Destroy((Object)(object)((Component)notifier).gameObject, 2f);
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(ObservableTriggerExtensions.OnPointerDownAsObservable((UIBehaviour)(object)notifier.button), (Action<PointerEventData>)delegate
		{
			notifier.clickedAction();
		}), (Component)(object)notifier);
		NotifierSound(AppType.NetaChoose);
		notifier.Show();
	}

	public void Clean()
	{
		for (int num = ((Transform)_notiferParent).childCount - 1; num >= 0; num--)
		{
			Object.Destroy((Object)(object)((Component)((Transform)_notiferParent).GetChild(num)).gameObject);
		}
	}

	private void ReplacePoketterNotifier(AppType app, string nakami)
	{
		Notification sameAppNotification = GetSameAppNotification(app);
		Notification n;
		if ((Object)(object)sameAppNotification == (Object)null)
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
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(ObservableTriggerExtensions.OnPointerDownAsObservable((UIBehaviour)(object)n.button), (Action<PointerEventData>)async delegate
		{
			n.clickedAction();
		}), (Component)(object)this);
	}

	private Notification GetSameAppNotification(AppType app)
	{
		for (int i = 0; i < ((Transform)_notiferParent).childCount; i++)
		{
			Notification component = ((Component)((Transform)_notiferParent).GetChild(i)).GetComponent<Notification>();
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
