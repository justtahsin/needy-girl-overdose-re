using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using Rewired;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class NgoEvent
{
	public NGO.EventType type;

	public string eventName = "";

	private IDisposable token1;

	private IDisposable token2;

	public bool isStarted;

	public CursorMode cursorMode;

	public Vector2 hotSpot = Vector2.zero;

	public CompositeDisposable compositeDisposable = new CompositeDisposable();

	private static Player _player;

	private static Player Player
	{
		get
		{
			if (_player == null)
			{
				_player = ReInput.players.GetPlayer(0);
			}
			return _player;
		}
	}

	protected virtual void Awake()
	{
	}

	public void ObiActive(bool onoff)
	{
		SingletonMonoBehaviour<EventManager>.Instance.ObiActive(onoff);
	}

	public static async UniTask DelaySkippable(int delay_ms)
	{
		CancellationTokenSource cts = new CancellationTokenSource();
		await UniTask.WhenAny(UniTask.Delay(delay_ms, ignoreTimeScale: false, PlayerLoopTiming.Update, cts.Token), UniTask.WaitUntil(() => Input.GetMouseButtonDown(0) || Player.GetButtonDown("Click"), PlayerLoopTiming.Update, cts.Token));
		cts.Cancel();
	}

	public virtual async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!isStarted)
		{
			cancellationToken.ThrowIfCancellationRequested();
			SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
			SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
			isStarted = true;
		}
	}

	public virtual async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken), bool skipWatchSp = false)
	{
		if (!isStarted)
		{
			cancellationToken.ThrowIfCancellationRequested();
			SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
			if (!skipWatchSp)
			{
				SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
			}
			isStarted = true;
		}
	}

	public void endEvent()
	{
		SingletonMonoBehaviour<JineManager>.Instance.EndOption();
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		if (eventName != "")
		{
			SingletonMonoBehaviour<EventManager>.Instance.eventsHistory.Add(eventName);
		}
		compositeDisposable.Clear();
		SingletonMonoBehaviour<EventManager>.Instance.EndEvent(eventName);
	}

	public void OnDestroy()
	{
		SingletonMonoBehaviour<JineManager>.Instance.EndOption();
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		if (eventName != "")
		{
			SingletonMonoBehaviour<EventManager>.Instance.eventsHistory.Add(eventName);
		}
		SingletonMonoBehaviour<EventManager>.Instance.EndEvent(eventName);
	}

	public void ClickableAllScreen(bool onoff)
	{
		SingletonMonoBehaviour<EventManager>.Instance.cover.interactable = onoff;
		SingletonMonoBehaviour<EventManager>.Instance.cover.gameObject.GetComponent<Text>().raycastTarget = onoff;
	}

	protected async UniTask GoOut()
	{
		SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
		AudioManager.Instance.PlaySeByType(SoundType.SE_Odekake_zazaza);
		SingletonMonoBehaviour<WebCamManager>.Instance.GoOut();
		await DelaySkippable(2000);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.GoOut);
		AppType TrainTime;
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ginga)
		{
			TrainTime = AppType.Train_Ginga;
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(TrainTime).Uncloseable();
			AudioManager.Instance.PlayBgmByType(SoundType.BGM_Train);
			await UniTask.Delay(13000);
			SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(TrainTime);
			return;
		}
		TrainTime = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) switch
		{
			0 => AppType.Train, 
			1 => AppType.Train_twilight, 
			_ => AppType.Train_night, 
		};
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(TrainTime);
		CancellationTokenSource cts = new CancellationTokenSource();
		ClickableAllScreen(onoff: true);
		SingletonMonoBehaviour<EventManager>.Instance.cover.OnPointerDownAsObservable().Subscribe(delegate
		{
			cts.Cancel();
		}).AddTo(compositeDisposable);
		try
		{
			AudioManager.Instance.PlayBgmByType(SoundType.BGM_Train);
			await UniTask.Delay(13000, ignoreTimeScale: false, PlayerLoopTiming.Update, cts.Token);
			cts.Cancel();
			ClickableAllScreen(onoff: false);
			SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(TrainTime);
		}
		catch (OperationCanceledException)
		{
			AudioManager.Instance.StopByType(SoundType.BGM_Train);
			ClickableAllScreen(onoff: false);
			SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(TrainTime);
		}
		SoundType soundType = SoundType.BGM_mainloop_kenjo;
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		if (status >= 10000)
		{
			soundType = SoundType.BGM_mainloop_normal;
		}
		if (status >= 100000)
		{
			soundType = SoundType.BGM_mainloop_yami;
		}
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) >= 11)
		{
			soundType = SoundType.BGM_mainloop_middle;
		}
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) >= 20)
		{
			soundType = SoundType.BGM_mainloop_shuban;
		}
		if (AudioManager.Instance != null && (AudioManager.Instance.PlayingBgm.Value == null || AudioManager.Instance?.PlayingBgm.Value.Sound.Id != soundType.ToString()))
		{
			AudioManager.Instance?.PlayBgmByType(soundType, isLoop: true);
		}
	}

	protected async UniTask BackFromOdekake()
	{
		switch (UnityEngine.Random.Range(0, 5))
		{
		case 0:
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.HangOut_LINE002);
			break;
		case 1:
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.HangOut_LINE003);
			break;
		case 2:
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.HangOut_LINE004);
			break;
		case 3:
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.HangOut_LINE005);
			break;
		default:
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.HangOut_LINE001);
			break;
		}
		await DelaySkippable(Constants.MIDDLE);
	}

	protected async UniTask NadeNade(Action eventAfter, bool isActiveAppJine = true)
	{
		if (isActiveAppJine)
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Jine);
		}
		await DelaySkippable(Constants.FAST);
		SingletonMonoBehaviour<TooltipManager>.Instance.Show(TooltipType.Tooltip_nadenade);
		IWindow ame = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		ame.Uncloseable();
		ReactiveProperty<int> nadeCount = SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Webcam).GetComponent<App_Webcam>().AmeHead.GetComponent<Amehead>().NadeCount;
		int firstValue = nadeCount.Value;
		nadeCount.Where((int v) => v == firstValue + 1).Subscribe(delegate
		{
			SingletonMonoBehaviour<TooltipManager>.Instance.Show(TooltipType.Tooltip_more);
		}).AddTo(compositeDisposable);
		nadeCount.Where((int v) => v >= firstValue + 3).Take(1).Subscribe(delegate
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_nadenade_2);
			SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
			ame.Closeable();
			eventAfter();
		})
			.AddTo(compositeDisposable);
	}

	protected void tweetFromTip(AlphaType alpha = AlphaType.none, int level = 0)
	{
		if (alpha == AlphaType.Zatudan && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Zatudan1);
		}
		if (alpha == AlphaType.Zatudan && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Zatudan2_1);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Zatudan2_2);
		}
		if (alpha == AlphaType.Zatudan && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Zatudan3);
		}
		if (alpha == AlphaType.Zatudan && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Zatudan4);
		}
		if (alpha == AlphaType.Zatudan && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Zatudan5);
		}
		if (alpha == AlphaType.ASMR && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_ASMR1);
		}
		if (alpha == AlphaType.ASMR && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_ASMR2);
		}
		if (alpha == AlphaType.ASMR && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_ASMR3);
		}
		if (alpha == AlphaType.ASMR && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_ASMR4);
		}
		if (alpha == AlphaType.ASMR && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_ASMR5);
		}
		if (alpha == AlphaType.Kaisetu && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaisetu1);
		}
		if (alpha == AlphaType.Kaisetu && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaisetu2);
		}
		if (alpha == AlphaType.Kaisetu && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaisetu3);
		}
		if (alpha == AlphaType.Kaisetu && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaisetu4);
		}
		if (alpha == AlphaType.Kaisetu && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaisetu5);
		}
		if (alpha == AlphaType.Hnahaisin && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Hnahaisin1_1);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Hnahaisin1_2);
		}
		if (alpha == AlphaType.Hnahaisin && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Hnahaisin2);
		}
		if (alpha == AlphaType.Hnahaisin && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Hnahaisin3);
		}
		if (alpha == AlphaType.Hnahaisin && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Hnahaisin4);
		}
		if (alpha == AlphaType.Yamihaishin && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Yamihaisin1);
		}
		if (alpha == AlphaType.Yamihaishin && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Yamihaisin2);
		}
		if (alpha == AlphaType.Yamihaishin && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Yamihaisin3);
		}
		if (alpha == AlphaType.Yamihaishin && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Yamihaisin4);
		}
		if (alpha == AlphaType.Yamihaishin)
		{
			_ = 5;
		}
		if (alpha == AlphaType.Gamejikkyou && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Gamejikkyou1);
		}
		if (alpha == AlphaType.Gamejikkyou && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Gamejikkyou2);
		}
		if (alpha == AlphaType.Gamejikkyou && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Gamejikkyou3);
		}
		if (alpha == AlphaType.Gamejikkyou && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Gamejikkyou4);
		}
		if (alpha == AlphaType.Gamejikkyou && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Gamejikkyou5);
		}
		if (alpha == AlphaType.Imbouron && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Imbouron1);
		}
		if (alpha == AlphaType.Imbouron && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Imbouron2);
		}
		if (alpha == AlphaType.Imbouron && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Imbouron3);
		}
		if (alpha == AlphaType.Imbouron && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Imbouron4);
		}
		if (alpha == AlphaType.Imbouron && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Imbouron5);
		}
		if (alpha == AlphaType.Kaidan && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaidan1);
		}
		if (alpha == AlphaType.Kaidan && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaidan2);
		}
		if (alpha == AlphaType.Kaidan && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaidan3);
		}
		if (alpha == AlphaType.Kaidan && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaidan4);
		}
		if (alpha == AlphaType.Kaidan && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaidan5);
		}
		if (alpha == AlphaType.Taiken && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Taiken1);
		}
		if (alpha == AlphaType.Taiken && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Taiken2);
		}
		if (alpha == AlphaType.Taiken && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Taiken3);
		}
		if (alpha == AlphaType.Taiken && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Taiken4);
		}
		if (alpha == AlphaType.Taiken && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Taiken5);
		}
		if (alpha == AlphaType.PR && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_PR1);
		}
		if (alpha == AlphaType.PR && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_PR2);
		}
		if (alpha == AlphaType.PR && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_PR3);
		}
		if (alpha == AlphaType.PR && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_PR4);
		}
		if (alpha == AlphaType.PR && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_PR5);
		}
		if (alpha == AlphaType.Otakutalk && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Otakutalk1);
		}
		if (alpha == AlphaType.Otakutalk && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Otakutalk2);
		}
		if (alpha == AlphaType.Otakutalk && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Otakutalk3_1);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Otakutalk3_2);
		}
		if (alpha == AlphaType.Otakutalk && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Otakutalk4);
		}
		if (alpha == AlphaType.Otakutalk && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Otakutalk5);
		}
		if (alpha == AlphaType.Darkness && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Darkness1);
		}
		if (alpha == AlphaType.Darkness && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Darkness2);
		}
		if (alpha == AlphaType.Angel && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Angel1);
		}
		if (alpha == AlphaType.Angel && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Angel2);
		}
		if (alpha == AlphaType.Angel && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Angel3);
		}
		if (alpha == AlphaType.Angel && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Angel4);
		}
		if (alpha == AlphaType.Angel && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Angel5);
		}
		if (alpha == AlphaType.Angel && level == 6)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Angel6);
		}
	}
}
