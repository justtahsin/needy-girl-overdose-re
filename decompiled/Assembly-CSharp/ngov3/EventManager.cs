using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class EventManager : SingletonMonoBehaviour<EventManager>
{
	public Button StartTest;

	[SerializeField]
	private Texture2D Waiting;

	[SerializeField]
	public Texture2D handCursor;

	[SerializeField]
	public ChipGetCover chipget;

	[SerializeField]
	public Button cover;

	[SerializeField]
	public Queue<NgoEvent> eventQueue = new Queue<NgoEvent>();

	[SerializeField]
	public List<string> eventsHistory = new List<string>();

	[SerializeField]
	public List<string> dayActionHistory = new List<string>();

	[SerializeField]
	public int loop;

	[SerializeField]
	public bool isTestScene;

	[SerializeField]
	public GameObject endingBlue;

	[SerializeField]
	private GameObject PsycheNikki1;

	[SerializeField]
	private GameObject PsycheNikki2;

	[SerializeField]
	private GameObject PsycheNikki3;

	[SerializeField]
	private GameObject PsycheNikki4;

	[SerializeField]
	private GameObject LoveNikki1;

	[SerializeField]
	private GameObject LoveNikki2;

	[SerializeField]
	private GameObject LoveNikki3;

	[SerializeField]
	private GameObject LoveNikki4;

	public AlphaType alpha;

	public int alphaLevel;

	public BetaType beta;

	public int midokumushi;

	public int psycheCount;

	public string nowEvent = "";

	public EndingType nowEnding = EndingType.Ending_None;

	public List<Tuple<ActionType, AlphaLevel>> nextActionHint = new List<Tuple<ActionType, AlphaLevel>>();

	public string KituneJien = "";

	public bool inNightBonus;

	[SerializeField]
	private bool isEventing;

	[SerializeField]
	public bool isWristCut;

	[SerializeField]
	public bool isHakkyo;

	[SerializeField]
	private bool isJuncho;

	[SerializeField]
	private bool isHearTrauma;

	[SerializeField]
	public CmdType FirstDate = CmdType.None;

	[SerializeField]
	public JineType Trauma = JineType.None;

	[SerializeField]
	public bool isHappaOK;

	[SerializeField]
	public bool isGedatsu;

	[SerializeField]
	public bool isHorror;

	[SerializeField]
	public bool beforeWristCut;

	[SerializeField]
	public int wishlist;

	[SerializeField]
	public int loveDiary;

	[SerializeField]
	public bool isShurokued;

	[SerializeField]
	public int kyuusiCount;

	[SerializeField]
	public bool isOpenGinga;

	[SerializeField]
	public bool is150mil;

	[SerializeField]
	public bool is300mil;

	[SerializeField]
	public bool is500mil;

	[SerializeField]
	private PlatformDiffAnimationMaster platformDiffAnimationMaster;

	public ReactiveProperty<string> Aim = new ReactiveProperty<string>();

	public GameObject obi;

	public AlphaLevel gotChipAlpha;

	private IDisposable CancelToken = new SingleAssignmentDisposable();

	private IDisposable token1 = new SingleAssignmentDisposable();

	private IDisposable token2 = new SingleAssignmentDisposable();

	private IDisposable token3 = new SingleAssignmentDisposable();

	public CmdType executingAction;

	private ReactiveProperty<bool> isCleaned = new ReactiveProperty<bool>(initialValue: true);

	public ReactiveProperty<bool> isResulting = new ReactiveProperty<bool>(initialValue: false);

	public ReactiveProperty<bool> isChipGetting = new ReactiveProperty<bool>(initialValue: false);

	public bool isThisTurnMidokuMushi;

	private CanvasGroup shortcuts;

	public List<Transform> hakkyoRotationObjectTr = new List<Transform>();

	private CancellationTokenSource eventCtsSource;

	private CancellationToken eventCts;

	public PlatformDiffAnimationMaster PlatformDiffAnimationMaster => platformDiffAnimationMaster;

	protected override void Awake()
	{
		base.Awake();
		eventCtsSource = new CancellationTokenSource();
		eventCts = eventCtsSource.Token;
		if (GameObject.Find("ShortCutParent") != null)
		{
			shortcuts = GameObject.Find("ShortCutParent").GetComponent<CanvasGroup>();
		}
		if (isTestScene)
		{
			_ = SteamManager.Initialized;
		}
		if (!isTestScene)
		{
			if (SingletonMonoBehaviour<Settings>.Instance.isBackToLoad)
			{
				Load();
			}
			else
			{
				StartOver();
			}
		}
		else if (StartTest != null)
		{
			StartTest.OnClickAsObservable().Subscribe(delegate
			{
				AddEvent<Event_Manicure>();
			}).AddTo(StartTest);
		}
	}

	private void Start()
	{
		UniTask.Delay(20);
		(from d in SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex)
			where d < 31
			select d).DistinctUntilChanged().Subscribe(async delegate(int day)
		{
			SingletonMonoBehaviour<CursorManager>.Instance.DisableLiveCursorMode();
			if (SingletonMonoBehaviour<Settings>.Instance.isBackToLoad)
			{
				SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = false;
			}
			else
			{
				Save(day);
			}
			AwakePsycheDiary();
			AwakeLoveDiary();
			AddEventQueue<Event_CheckBGM>();
			await FetchDayEvent();
		}).AddTo(base.gameObject);
		(from part in SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart).DistinctUntilChanged()
			where part == 1
			select part).Subscribe(delegate
		{
			FetchUzagarami();
		}).AddTo(base.gameObject);
		(from part in SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart).DistinctUntilChanged()
			where part == 2
			select part).Subscribe(delegate
		{
			FetchNightEvent();
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart).DistinctUntilChanged().Subscribe(delegate
		{
			fetchNextActionHint();
		})
			.AddTo(base.gameObject);
	}

	public async void AddEvent<EventT>() where EventT : NgoEvent, new()
	{
		AddEventQueue<EventT>();
		await UniTask.Delay(1);
		await StartEvent();
	}

	public async void AddEvent(string EventName)
	{
		AddEventQueue(EventName);
		await UniTask.Delay(1);
		await StartEvent();
	}

	public void AddEventQueue<EventT>() where EventT : NgoEvent, new()
	{
		eventQueue.Enqueue(new EventT());
	}

	public void AddEventQueue(string EventName)
	{
		Type type = Type.GetType("ngov3." + EventName);
		if (type == null)
		{
			Debug.Log("No event " + EventName);
			return;
		}
		NgoEvent item = Activator.CreateInstance(type) as NgoEvent;
		eventQueue.Enqueue(item);
	}

	public void StartHaishin(AlphaType alpha, int level, BetaType beta)
	{
		if (!SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value)
		{
			SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = true;
			this.alpha = alpha;
			alphaLevel = level;
			this.beta = beta;
			SingletonMonoBehaviour<NetaManager>.Instance.Haishined(alpha, level);
			if (this.alpha == AlphaType.Hnahaisin && alphaLevel == 5)
			{
				AddEvent<Ending_Av>();
				return;
			}
			if (this.alpha == AlphaType.Yamihaishin && alphaLevel == 5)
			{
				AddEvent<Ending_Yami>();
				return;
			}
			isThisTurnMidokuMushi = !checkTuutiCleaned();
			SingletonMonoBehaviour<NotificationManager>.Instance.Clean();
			isEventForcePushed();
			SetShortcutState(isEnable: false, 0.2f);
			AddEvent<Action_HaishinStart>();
		}
	}

	public void EndHaishin()
	{
		AddEvent<Action_HaishinEnd>();
		SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = false;
		if (isThisTurnMidokuMushi)
		{
			midokumushi++;
			MidokuMushiTweet();
			isThisTurnMidokuMushi = false;
		}
	}

	public void HaishinClean()
	{
		AddEvent<Action_HaishinClean>();
		if (isThisTurnMidokuMushi)
		{
			midokumushi++;
			MidokuMushiTweet();
			isThisTurnMidokuMushi = false;
		}
	}

	public async UniTask StartEvent()
	{
		if (isEventing)
		{
			Debug.Log("現在他Event実行中です");
		}
		if (eventQueue.Count > 0 && !isEventing)
		{
			isEventing = true;
			try
			{
				NgoEvent ngoEvent = eventQueue.Dequeue();
				Debug.Log("Event開始：" + ngoEvent.eventName);
				await ngoEvent.startEvent(eventCts);
			}
			catch (OperationCanceledException)
			{
				Debug.Log("end Event");
			}
		}
	}

	public async UniTask EndEvent(NGO.EventType type)
	{
		eventsHistory.Add(type.ToString());
		await EndEvent();
	}

	public async UniTask EndEvent(string eventName)
	{
		await EndEvent();
	}

	public void setActionHistory(string actionName)
	{
		SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = true;
		dayActionHistory.Add(actionName);
	}

	public async UniTask EndEvent()
	{
		isEventing = false;
		await UniTask.Delay(1);
		await StartEvent();
	}

	public void ForceEventFlagOff()
	{
		isEventing = false;
	}

	public void ClearEventQueue()
	{
		eventQueue.Clear();
		eventCtsSource.Cancel();
		SingletonMonoBehaviour<JineManager>.Instance.EndOption();
	}

	private bool isEventForcePushed()
	{
		if (isEventing)
		{
			ClearEventQueue();
			isEventing = false;
			return true;
		}
		return false;
	}

	public async void ExecuteAction(ActionType ac, CmdType a)
	{
		if (!SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value)
		{
			if (inNightBonus || ac == ActionType.Haishin || NgoEx.CmdFromType(a).PassingTime + SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) <= 2)
			{
				await ExecuteActionConfirmed(ac, a);
				return;
			}
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.TimePassDialog);
			SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.TimePassDialog).GetComponent<TimePassDialog>().setType(ac, a);
		}
	}

	public async UniTask ExecuteActionConfirmed(ActionType ac, CmdType a, bool isEventCommand = false)
	{
		if (a.ToString().StartsWith("Odekake") && FirstDate == CmdType.None)
		{
			FirstDate = a;
		}
		SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = true;
		await NgoEvent.DelaySkippable(20);
		await NgoEvent.DelaySkippable(20);
		isCleaned.Value = false;
		executingAction = a;
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(Waiting, Vector2.zero, CursorMode.Auto);
		SingletonMonoBehaviour<CommandManager>.Instance.disableAllCommands();
		SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
		SetShortcutState(isEnable: false);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<WindowManager>.Instance.CleanOnCommand(ac == ActionType.Internet2ch, ac == ActionType.InternetDeai);
		dayActionHistory.Add(a.ToString());
		isThisTurnMidokuMushi = !checkTuutiCleaned() && !isEventCommand;
		isEventForcePushed();
		SingletonMonoBehaviour<NotificationManager>.Instance.Clean();
		AddEvent("Action_" + a);
		await NgoEvent.DelaySkippable(20);
		CancellationTokenSource cts = new CancellationTokenSource();
		token1 = (from v in base.gameObject.ObserveEveryValueChanged((GameObject _) => isEventing)
			where !v
			select v).Take(1).Subscribe(async delegate
		{
			ApplyStatus(a);
			if (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count > 0)
			{
				SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
				await NgoEvent.DelaySkippable(Constants.MIDDLE);
				SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Result).GetComponent<PoketterView2D>().shootTweetAll(cts);
				await NgoEvent.DelaySkippable(SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count * Constants.SLOW + Constants.MIDDLE);
			}
			SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.TaskManager));
			SingletonMonoBehaviour<StatusManager>.Instance.TimeDelta(NgoEx.CmdFromType(executingAction).PassingTime);
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) == 0 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) == 2)
			{
				SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tooltip_param);
				await NgoEvent.DelaySkippable(Constants.MIDDLE);
			}
			await SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
			SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
			if (isThisTurnMidokuMushi)
			{
				midokumushi++;
				await MidokuMushiTweet();
				if (midokumushi >= 5)
				{
					return;
				}
			}
			isThisTurnMidokuMushi = false;
			if (nowEnding != EndingType.Ending_Lust)
			{
				await getHintedChip(ac);
				await StartEvent();
			}
			SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, Vector2.zero, CursorMode.Auto);
			await NgoEvent.DelaySkippable(Constants.FAST);
			TimePass();
			SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = false;
		}).AddTo(base.gameObject);
	}

	private bool checkTuutiCleaned()
	{
		return SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount == 0;
	}

	private bool checkCleaned()
	{
		if (SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount == 0 && SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count == 0)
		{
			return eventQueue.Count == 0;
		}
		return false;
	}

	public void ApplyStatus(CmdType a)
	{
		SingletonMonoBehaviour<StatusManager>.Instance.CleanDelta();
		CmdMaster.Param cmd = NgoEx.CmdFromType(a);
		SingletonMonoBehaviour<StatusManager>.Instance.AddDiffToDelta(cmd);
	}

	private async UniTask MidokuMushiTweet()
	{
		if (nowEnding != EndingType.Ending_None)
		{
			return;
		}
		await NgoEvent.DelaySkippable(Constants.FAST);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 4);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Love, -5);
		switch (SingletonMonoBehaviour<EventManager>.Instance.midokumushi)
		{
		default:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Tweet_Midokumushi001);
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
			break;
		case 2:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Tweet_Midokumushi002);
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
			break;
		case 3:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Tweet_Midokumushi003);
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
			break;
		case 4:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Tweet_Midokumushi004);
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
			break;
		case 5:
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Tweet_Midokumushi005);
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
			ClearEventQueue();
			SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Jine;
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Result).GetComponent<PoketterView2D>().shootTweetAll();
			(from count in SingletonMonoBehaviour<PoketterManager>.Instance.ObserveEveryValueChanged((PoketterManager pktr) => pktr._tweetQueue.Count)
				where count == 0
				select count).Subscribe(async delegate
			{
				await NgoEvent.DelaySkippable(Constants.SLOW);
				SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
				SingletonMonoBehaviour<WebCamManager>.Instance.GoOut();
				await NgoEvent.DelaySkippable(Constants.MIDDLE);
				AchievementStatsUpdater.UpdateStats("Ending_Jine");
				SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
				await UniTask.Delay(500000);
			}).AddTo(base.gameObject);
			break;
		}
	}

	private void setSticky()
	{
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart);
		int status3 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		if (status < 5 && status > 0)
		{
			if (status2 < 2)
			{
				Aim.Value = NgoEx.SystemTextFromType(SystemTextType.System_CollectNeta, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
			else
			{
				Aim.Value = NgoEx.SystemTextFromType(SystemTextType.System_NightHint, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
		}
		else if (status <= 10)
		{
			Aim.Value = NgoEx.SystemTextFromType(SystemTextType.Sticky_aim10, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else if (status <= 20)
		{
			Aim.Value = NgoEx.SystemTextFromType(SystemTextType.Sticky_aim20, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else if (status <= 30)
		{
			if (status3 >= 1000000)
			{
				Aim.Value = NgoEx.SystemTextFromType(SystemTextType.Sticky_life, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
			else
			{
				Aim.Value = NgoEx.SystemTextFromType(SystemTextType.Sticky_aim30, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
		}
	}

	public async UniTask FetchDayEvent()
	{
		setSticky();
		int day = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
		if (isGedatsu && day != 30)
		{
			return;
		}
		await UniTask.Delay(2700);
		if (!isTestScene && day == 1)
		{
			return;
		}
		if (nowEnding == EndingType.Ending_Completed && day != 1)
		{
			string eventName = $"Ending_Completed_Day{day}";
			AddEvent(eventName);
			return;
		}
		if (SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 6))
		{
			AddEvent<Ending_DarkAngel>();
			return;
		}
		switch (day)
		{
		case 3:
			AddEvent<Scenario_Yachin>();
			return;
		case 5:
			AddEvent<Event_Wishlist_day1>();
			return;
		case 6:
			if (wishlist != 0)
			{
				switch (wishlist)
				{
				case 1:
					AddEvent<Event_Wishlist_day2_1>();
					break;
				case 2:
					AddEvent<Event_Wishlist_day2_2>();
					break;
				case 3:
					AddEvent<Event_Wishlist_day2_3>();
					break;
				default:
					AddEvent<Event_Wishlist_day2_4>();
					break;
				}
				return;
			}
			break;
		}
		if (day == 16 && isHearTrauma)
		{
			AddEvent<YamiHi_SukiHi_3>();
			return;
		}
		switch (day)
		{
		case 20:
			AddEvent<Event_Day20>();
			return;
		case 24:
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love) >= 80)
			{
				await ExecuteActionConfirmed(ActionType.OdekakeZikka, CmdType.OdekakeZikka, isEventCommand: true);
				return;
			}
			break;
		}
		if (!isHorror && day == 27 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower) >= 500000)
		{
			isShurokued = true;
			AddEvent<Event_MV_shuroku>();
			return;
		}
		if (day == 29 && isShurokued)
		{
			AddEvent<Event_MV_koukai>();
			return;
		}
		if (day == 30)
		{
			chooseMaturo();
			return;
		}
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) >= 80 && !isWristCut && beforeWristCut)
		{
			isWristCut = true;
			AddEvent<Status_Stress1_Day>();
			return;
		}
		if (!isWristCut && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) >= 80 && SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Stress) == 100)
		{
			beforeWristCut = true;
		}
		else
		{
			beforeWristCut = false;
		}
		if (isWristCut && !isHakkyo && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) == 100)
		{
			isHakkyo = true;
			SetShortcutState(isEnable: false);
			SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
			AddEvent<Status_Stress2_Day>();
			return;
		}
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress);
		if (day == 25 && isHakkyo && status >= 80)
		{
			AddEvent<Scenario_horror_day1_day>();
			isHorror = true;
			return;
		}
		if (day == 26 && isHorror)
		{
			AddEvent<Scenario_horror_day2_day>();
			return;
		}
		if (day == 27 && isHorror)
		{
			AddEvent<Scenario_horror_day3_day>();
			return;
		}
		if (day == 28 && isHorror)
		{
			AddEvent<Scenario_horror_day4_day>();
			return;
		}
		if (day == 29 && isHorror)
		{
			AddEvent<Scenario_horror_day5_day>();
			return;
		}
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		if (status2 >= 10000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 1))
		{
			AddEvent<Scenario_Angel1>();
		}
		else if (status2 >= 30000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.PR && al.level == 1))
		{
			AddEvent<Scenario_PR1>();
		}
		else if (status2 >= 100000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 2))
		{
			AddEvent<Scenario_Angel2>();
		}
		else if (status2 >= 250000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 3))
		{
			AddEvent<Scenario_Angel3>();
		}
		else if (status2 >= 500000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 4))
		{
			AddEvent<Scenario_Angel4>();
		}
		else if (status2 >= 1000000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 5) && !SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 6) && !isHakkyo)
		{
			AddEvent<Scenario_Angel5>();
		}
		else if (status2 >= 1000000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 6) && !SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 5) && isHakkyo)
		{
			AddEvent<Scenario_Angel6>();
		}
		else if (!isTestScene && day == 2)
		{
			string eventName2 = $"Scenario_loop1_day{day - 1}_day";
			AddEvent(eventName2);
		}
		else
		{
			FetchDialog();
		}
	}

	public void FetchNightEvent()
	{
		if (isHorror || nowEnding == EndingType.Ending_Completed || nowEnding != EndingType.Ending_None)
		{
			return;
		}
		setSticky();
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
		if (!isTestScene && status == 1)
		{
			AddEvent<Scenario_loop1_day0_night>();
		}
		else if (isWristCut && beforeWristCut)
		{
			SetShortcutState(isEnable: false);
			beforeWristCut = false;
			AddEvent<Status_Stress1_Night>();
		}
		else if (isHakkyo && SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Stress) == 100)
		{
			shortcuts.interactable = false;
			shortcuts.blocksRaycasts = false;
			shortcuts.alpha = 0.4f;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusMaxToNumber(StatusType.Stress, 120);
			AddEvent<Status_Stress2_Night>();
		}
		else
		{
			if (isHorror)
			{
				return;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) >= 120)
			{
				AddEvent<Ending_Stressful>();
				return;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) == 0)
			{
				AddEvent<Ending_Healthy>();
				return;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love) == SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Love))
			{
				AddEvent<Ending_Sukisuki>();
				return;
			}
			if ((SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) == SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Yami) && UnityEngine.Random.Range(0, 100) == 66) || (SingletonMonoBehaviour<Settings>.Instance.mitaEnd.Distinct().ToList().Count >= 16 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) == SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Yami) && UnityEngine.Random.Range(0, 20) == 6))
			{
				AddEvent<Ending_Megaten>();
				return;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love) == 0)
			{
				AddEvent<Ending_Ntr>();
				return;
			}
			if (psycheCount >= 5 && !isGedatsu)
			{
				nowEnding = EndingType.Ending_Meta;
				AddEvent<Ending_Meta>();
				return;
			}
			FetchUzagarami();
			if (!isTestScene && status == 2)
			{
				AddEvent<Scenario_loop1_day1_night>();
			}
		}
	}

	private void FetchDialog()
	{
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) >= 80)
		{
			AddEvent<Event_CheckBGM>();
		}
		else
		{
			AddEvent<Event_Uzagarami_Kaiwa>();
		}
	}

	private void FetchUzagarami()
	{
		if (!isGedatsu && nowEnding != EndingType.Ending_Completed)
		{
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) >= 80)
			{
				AddEvent<Event_CheckBGM>();
			}
			else
			{
				AddEvent<Event_Uzagarami_Dokuhaku>();
			}
		}
	}

	public bool FetchScenarioEvent()
	{
		if (isHorror)
		{
			return false;
		}
		if (nowEnding == EndingType.Ending_Completed)
		{
			return false;
		}
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		int status3 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love);
		SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Love);
		int status4 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami);
		SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Yami);
		SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Stress);
		if (status == 8 && status2 < 10000)
		{
			AddEvent<Scenario_Yachin_Aseri>();
			return true;
		}
		switch (status)
		{
		case 10:
			if (status2 >= 10000)
			{
				AddEventQueue<NightKaiwaSeparator>();
				AddEvent<Scenario_Achieved_Aim>();
			}
			else
			{
				AddEvent<Ending_Jikka>();
			}
			return true;
		case 14:
			if (status2 >= 100000)
			{
				AddEvent<Scenario_start_follower_high>();
				isJuncho = true;
			}
			else
			{
				AddEvent<Scenario_start_follower_low>();
				isJuncho = false;
			}
			break;
		}
		if (status == 15)
		{
			if (status3 >= 60 && status4 >= 60)
			{
				isHearTrauma = true;
				AddEvent<Event_LongLine>();
				AddEvent<Scenario_trauma_bimyou>();
			}
			else
			{
				isHearTrauma = false;
				AddEvent<Event_Dialog>();
			}
		}
		switch (status)
		{
		case 17:
			if (status2 > 250000)
			{
				isJuncho = true;
			}
			if (status4 >= 60)
			{
				isHappaOK = true;
				if (isJuncho)
				{
					if (status3 >= 60)
					{
						AddEventQueue<NightKaiwaSeparator>();
						AddEvent<Scenario_happa_yamitoraikeike>();
					}
					else
					{
						AddEventQueue<NightKaiwaSeparator>();
						AddEvent<Scenario_happa_yamihateikeike>();
					}
				}
				else if (status3 >= 60)
				{
					AddEventQueue<NightKaiwaSeparator>();
					AddEvent<Scenario_happa_yamitora>();
				}
				else
				{
					AddEventQueue<NightKaiwaSeparator>();
					AddEvent<Scenario_happa_yamihate>();
				}
			}
			else
			{
				isHappaOK = false;
				if (isJuncho)
				{
					if (status3 >= 60)
					{
						AddEventQueue<NightKaiwaSeparator>();
						AddEvent<Scenario_happa_kentoraikeike>();
					}
					else
					{
						AddEventQueue<NightKaiwaSeparator>();
						AddEvent<Scenario_happa_kenhateikeike>();
					}
				}
				else if (status3 >= 60)
				{
					AddEventQueue<NightKaiwaSeparator>();
					AddEvent<Scenario_happa_kentora>();
				}
				else
				{
					AddEventQueue<NightKaiwaSeparator>();
					AddEvent<Scenario_happa_kenhate>();
				}
			}
			return true;
		case 22:
			if (status2 >= 250000)
			{
				AddEventQueue<NightKaiwaSeparator>();
				AddEvent<Scenario_topstreamer_yadakenjoikeike>();
			}
			else if (status4 >= 60)
			{
				AddEventQueue<NightKaiwaSeparator>();
				AddEvent<Scenario_topstreamer_trahappa>();
			}
			else
			{
				AddEventQueue<NightKaiwaSeparator>();
				AddEvent<Scenario_topstreamer_trakenjo>();
			}
			return true;
		case 23:
			setLoveDiaryId(status3);
			break;
		}
		if (status == 23 && status3 >= 80)
		{
			AddEvent<Scenario_jikka>();
			return true;
		}
		if (status == 27)
		{
			if (status2 >= 1000000)
			{
				if (status3 >= 80)
				{
					if (status4 >= 60)
					{
						if (isJuncho)
						{
							AddEventQueue<NightKaiwaSeparator>();
							AddEvent<Scenario_topstreamer_trahappaikeike>();
						}
						else
						{
							AddEventQueue<NightKaiwaSeparator>();
							AddEvent<Scenario_topstreamer_trahappaikeikeatonobi>();
						}
					}
					else if (isJuncho)
					{
						AddEventQueue<NightKaiwaSeparator>();
						AddEvent<Scenario_topstreamer_trakenjoikeike>();
					}
					else
					{
						AddEventQueue<NightKaiwaSeparator>();
						AddEvent<Scenario_topstreamer_trakenjoikeikeatonobi>();
					}
				}
				else if (isJuncho)
				{
					AddEventQueue<NightKaiwaSeparator>();
					AddEvent<Scenario_topstreamer_yadahappakeike>();
				}
				else
				{
					AddEventQueue<NightKaiwaSeparator>();
					AddEvent<Scenario_topstreamer_yadahappakeikeatonobi>();
				}
				return true;
			}
			if (status2 >= 500000)
			{
				AddEventQueue<NightKaiwaSeparator>();
				AddEvent<Scenario_topstreamer_yadahappa>();
				return true;
			}
			AddEventQueue<NightKaiwaSeparator>();
			AddEvent<Scenario_topstreamer_yadakenjo>();
			return true;
		}
		if (!isOpenGinga && SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Kaidan && al.level == 5))
		{
			AddEventQueue<NightKaiwaSeparator>();
			AddEvent<Event_OpenGinga>();
			return true;
		}
		if (status2 >= 1500000 && !is150mil)
		{
			AddEvent<Event_150mil>();
			is150mil = true;
			return true;
		}
		if (status2 >= 3000000 && !is300mil)
		{
			AddEvent<Event_300mil>();
			is300mil = true;
			return true;
		}
		if (status2 >= 5000000 && !is500mil)
		{
			AddEvent<Event_500mil>();
			is500mil = true;
			return true;
		}
		if (status2 >= 9999999)
		{
			AddEvent<Ending_Ideon>();
			return true;
		}
		if (isHorror)
		{
			return false;
		}
		switch (UnityEngine.Random.Range(0, 100))
		{
		case 0:
			AddEvent<Event_jinsei0>();
			return true;
		case 1:
			AddEvent<Event_jinsei1>();
			return true;
		case 2:
			AddEvent<Event_jinsei2>();
			return true;
		case 3:
			AddEvent<Event_jinsei3>();
			return true;
		case 4:
			AddEvent<Event_jinsei4>();
			return true;
		case 5:
			if (!SingletonMonoBehaviour<StatusManager>.Instance.isTodayHaishined)
			{
				AddEvent<Event_Nerarenai_Night>();
				return true;
			}
			break;
		}
		return false;
	}

	private void chooseMaturo()
	{
		SetShortcutState(isEnable: false);
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love);
		int status3 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami);
		AddEventQueue<EndingSeparator>();
		if (isGedatsu)
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.DayPart, 3);
			AddEvent<Ending_Kyouso>();
		}
		else if (status >= 1000000 && status3 >= 80 && status2 >= 80 && SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 5))
		{
			AddEvent<Ending_Grand>();
		}
		else if (status >= 1000000 && status2 >= 80)
		{
			AddEvent<Ending_Happy>();
		}
		else if (status >= 500000 && status2 >= 80)
		{
			AddEvent<Ending_Normal>();
		}
		else if (status >= 500000)
		{
			AddEvent<Ending_Yarisute>();
		}
		else if (status3 >= 60 && status2 >= 60)
		{
			AddEvent<Ending_Needy>();
		}
		else if (status3 >= 60)
		{
			AddEvent<Ending_Sucide>();
		}
		else if (status2 >= 60)
		{
			AddEvent<Ending_Work>();
		}
		else
		{
			AddEvent<Ending_Bad>();
		}
	}

	public async UniTask CallEnding()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursorShowHide(show: false);
		UnityEngine.Object.Instantiate(endingBlue, GameObject.Find("MainPanel").transform);
	}

	public void ObiActive(bool onoff)
	{
		obi.SetActive(onoff);
	}

	public void fetchNextActionHint()
	{
		nextActionHint = SingletonMonoBehaviour<NetaManager>.Instance.fetchNextActionHint();
		SingletonMonoBehaviour<CommandManager>.Instance.AddHint(nextActionHint);
	}

	public async UniTask getHintedChip(ActionType a)
	{
		Tuple<ActionType, AlphaLevel> gotAct = nextActionHint.Find((Tuple<ActionType, AlphaLevel> hint) => hint.Item1 == a);
		if (gotAct == null)
		{
			isChipGetting.Value = false;
			return;
		}
		Aim.Value = NgoEx.SystemTextFromType(SystemTextType.System_FindNeta, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		AudioManager.Instance?.PlaySeByType(SoundType.SE_tweet_change_top);
		isChipGetting.Value = true;
		gotChipAlpha = gotAct.Item2;
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Jine);
		await UniTask.Delay(Constants.FAST);
		SingletonMonoBehaviour<NetaManager>.Instance.GetChip(gotChipAlpha.alphaType, gotChipAlpha.level);
		nextActionHint.Remove(gotAct);
		CallNetaGet();
	}

	public async UniTask CallNetaGet()
	{
		AddEventQueue<SetJineSeparator>();
		AddEventQueue("ChipGet_" + gotChipAlpha.alphaType.ToString() + "_" + gotChipAlpha.level);
		AddEventQueue<ChipGet_Show>();
		await StartEvent();
	}

	public async UniTask getChip(AlphaType type, int level)
	{
		gotChipAlpha = new AlphaLevel(type, level);
		SingletonMonoBehaviour<NetaManager>.Instance.GetChip(gotChipAlpha.alphaType, gotChipAlpha.level);
		AddEventQueue<SetJineSeparator>();
		AddEventQueue("ChipGet_" + gotChipAlpha.alphaType.ToString() + "_" + gotChipAlpha.level);
		AddEventQueue<ChipGet_Show>();
		AddEventQueue<BlurWatchingSp>();
	}

	private void AwakePsycheDiary()
	{
		if (psycheCount != 0)
		{
			if (psycheCount >= 1)
			{
				PsycheNikki1.SetActive(value: true);
			}
			if (psycheCount >= 2)
			{
				PsycheNikki2.SetActive(value: true);
			}
			if (psycheCount >= 3)
			{
				PsycheNikki3.SetActive(value: true);
			}
			if (psycheCount >= 4)
			{
				PsycheNikki4.SetActive(value: true);
			}
		}
	}

	private void setLoveDiaryId(int love)
	{
		if (love < 20)
		{
			loveDiary = 1;
		}
		else if (love < 40)
		{
			loveDiary = 2;
		}
		else if (love < 80)
		{
			loveDiary = 3;
		}
		else
		{
			loveDiary = 4;
		}
	}

	private void AwakeLoveDiary()
	{
		if (loveDiary != 0)
		{
			if (loveDiary == 1)
			{
				LoveNikki4.SetActive(value: true);
			}
			else if (loveDiary == 2)
			{
				LoveNikki3.SetActive(value: true);
			}
			else if (loveDiary == 3)
			{
				LoveNikki2.SetActive(value: true);
			}
			else if (loveDiary == 4)
			{
				LoveNikki1.SetActive(value: true);
			}
		}
	}

	public void TimePass()
	{
		if (nowEnding != EndingType.Ending_None)
		{
			return;
		}
		if (inNightBonus)
		{
			GameObject.Find("Live").GetComponent<CanvasGroup>().interactable = true;
			GameObject.Find("neru").GetComponent<CanvasGroup>().interactable = true;
			GameObject.Find("Odekake").GetComponent<CanvasGroup>().interactable = true;
		}
		if (executingAction == CmdType.Error)
		{
			SingletonMonoBehaviour<NotificationManager>.Instance.AddTimePassingNotifier();
			return;
		}
		if (!isChipGetting.Value)
		{
			SingletonMonoBehaviour<NotificationManager>.Instance.AddTimePassingNotifier(NgoEx.CmdFromType(executingAction).PassingTime);
			return;
		}
		isChipGetting.Where((bool v) => !v).Take(1).Subscribe(delegate
		{
			SingletonMonoBehaviour<NotificationManager>.Instance.AddTimePassingNotifier(NgoEx.CmdFromType(executingAction).PassingTime);
		})
			.AddTo(base.gameObject);
	}

	public void Save(int day)
	{
		string text = $"Data{SingletonMonoBehaviour<Settings>.Instance.saveNumber}_Day{day}{SaveRelayer.EXTENTION}";
		SlotData slotData = new SlotData();
		slotData.jineHistory = SingletonMonoBehaviour<JineManager>.Instance.history;
		slotData.poketterHistory = SingletonMonoBehaviour<PoketterManager>.Instance.history;
		slotData.eventsHistory = eventsHistory;
		slotData.dayActionHistory = dayActionHistory;
		slotData.loop = loop;
		slotData.midokumushi = midokumushi;
		slotData.psycheCount = psycheCount;
		slotData.stats = SingletonMonoBehaviour<StatusManager>.Instance.statuses;
		slotData.havingNetas = SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha;
		slotData.usedNetas = SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha;
		slotData.isJuncho = isJuncho;
		slotData.isHearTrauma = isHearTrauma;
		slotData.trauma = Trauma;
		slotData.firstDate = FirstDate;
		slotData.isHappaOK = isHappaOK;
		slotData.isHorror = isHorror;
		slotData.isGedatsu = isGedatsu;
		slotData.wishlist = wishlist;
		slotData.isWristCut = isWristCut;
		slotData.isHakkyo = isHakkyo;
		slotData.beforeWristCut = beforeWristCut;
		slotData.isShurokued = isShurokued;
		slotData.kyuusiCount = kyuusiCount;
		slotData.loveDiary = loveDiary;
		slotData.isOpenGinga = isOpenGinga;
		slotData.is150mil = is150mil;
		slotData.is300mil = is300mil;
		slotData.is500mil = is500mil;
		SaveRelayer.SaveSlotData(text, slotData);
		Debug.Log("スロットデータ：" + text + "のセーブが完了しました。");
		CleanPassingSaveData(text);
	}

	public void StartOver()
	{
		ClearEventQueue();
		SingletonMonoBehaviour<NotificationManager>.Instance.Clean();
		SingletonMonoBehaviour<JineManager>.Instance.history = new List<JineData>();
		SingletonMonoBehaviour<PoketterManager>.Instance.history = new List<TweetData>();
		eventsHistory = new List<string>();
		dayActionHistory = new List<string>();
		loop = 1;
		midokumushi = 0;
		psycheCount = 0;
		SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha = new List<AlphaLevel>
		{
			new AlphaLevel(AlphaType.Zatudan, 1)
		};
		SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha = new List<AlphaLevel>();
		isJuncho = false;
		isHearTrauma = false;
		Trauma = JineType.None;
		FirstDate = CmdType.None;
		isHappaOK = false;
		isHorror = false;
		isGedatsu = false;
		beforeWristCut = false;
		isWristCut = false;
		isHakkyo = false;
		isShurokued = false;
		isOpenGinga = false;
		wishlist = 0;
		loveDiary = 0;
		kyuusiCount = 0;
		isOpenGinga = false;
		is150mil = false;
		is300mil = false;
		is500mil = false;
		SingletonMonoBehaviour<StatusManager>.Instance.NewStatus();
		fetchNextActionHint();
		if (SingletonMonoBehaviour<Settings>.Instance.saveNumber == 0)
		{
			nowEnding = EndingType.Ending_Completed;
			AddEvent<Ending_Completed>();
		}
	}

	public void Load()
	{
		string nowSaveFile = SingletonMonoBehaviour<Settings>.Instance.nowSaveFile;
		ClearEventQueue();
		SingletonMonoBehaviour<NotificationManager>.Instance.Clean();
		SlotData slotData = SaveRelayer.LoadSlotData(nowSaveFile);
		SingletonMonoBehaviour<JineManager>.Instance.history = slotData.jineHistory;
		SingletonMonoBehaviour<PoketterManager>.Instance.history = slotData.poketterHistory;
		eventsHistory = slotData.eventsHistory;
		dayActionHistory = slotData.dayActionHistory;
		loop = slotData.loop;
		midokumushi = slotData.midokumushi;
		psycheCount = slotData.psycheCount;
		SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha = slotData.havingNetas;
		SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha = slotData.usedNetas;
		isJuncho = slotData.isJuncho;
		isHearTrauma = slotData.isHearTrauma;
		Trauma = slotData.trauma;
		FirstDate = slotData.firstDate;
		isHappaOK = slotData.isHappaOK;
		isHorror = slotData.isHorror;
		isGedatsu = slotData.isGedatsu;
		beforeWristCut = slotData.beforeWristCut;
		isWristCut = slotData.isWristCut;
		isHakkyo = slotData.isHakkyo;
		wishlist = slotData.wishlist;
		loveDiary = slotData.loveDiary;
		isShurokued = slotData.isShurokued;
		kyuusiCount = slotData.kyuusiCount;
		isOpenGinga = slotData.isOpenGinga;
		is150mil = slotData.is150mil;
		is300mil = slotData.is300mil;
		is500mil = slotData.is500mil;
		List<Status> stats = slotData.stats;
		SingletonMonoBehaviour<StatusManager>.Instance.setNewStatusList(stats);
		if (nowSaveFile == "Data0_Day30" + SaveRelayer.EXTENTION)
		{
			AddEvent<Ending_Completed_Day30_afterOut>();
		}
		SingletonMonoBehaviour<WindowManager>.Instance.CleanOnLoad();
		fetchNextActionHint();
		Debug.Log("スロットデータ：" + nowSaveFile + "のロードが完了しました。");
	}

	private void CleanPassingSaveData(string savefile)
	{
		Match match = Regex.Match(savefile, "(?<=Data)\\d+");
		Match match2 = Regex.Match(savefile, "(?<=Day)\\d+");
		List<string> list = new List<string>();
		for (int i = int.Parse(match2.Value) + 1; i <= 30; i++)
		{
			string text = $"Data{match.Value}_Day{i}{SaveRelayer.EXTENTION}";
			if (!SaveRelayer.IsSlotDataExists(text))
			{
				break;
			}
			list.Add(text);
		}
		SaveRelayer.DeleteDatas(list);
	}

	public void SetShortcutState(bool isEnable, float disabledAlpha = 0.4f)
	{
		if (isEnable)
		{
			shortcuts.interactable = true;
			shortcuts.blocksRaycasts = true;
			shortcuts.alpha = 1f;
			if (SingletonMonoBehaviour<ControllerGuideManager>.Instance != null)
			{
				SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = true;
			}
		}
		else
		{
			shortcuts.interactable = false;
			shortcuts.blocksRaycasts = false;
			shortcuts.alpha = disabledAlpha;
			if (SingletonMonoBehaviour<ControllerGuideManager>.Instance != null)
			{
				SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = false;
			}
		}
	}

	public void HideShortcut()
	{
		shortcuts.gameObject.SetActive(value: false);
		if (SingletonMonoBehaviour<ControllerGuideManager>.Instance != null)
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = false;
		}
	}
}
