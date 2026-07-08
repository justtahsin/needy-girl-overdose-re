using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Live : MonoBehaviour
{
	[SerializeField]
	public Button _HaisinSpeed;

	[SerializeField]
	public Button _HaisinSkip;

	[SerializeField]
	public TMP_Text _Speedlabel;

	public int Speed;

	private string nowSpeedLabel = "はいしんスピード\u3000ふつう";

	[SerializeField]
	public Texture2D Countdown1;

	public Vector2 hotSpot = Vector2.zero;

	public CursorMode cursorMode;

	private const int ACTIONCOOLER = 0;

	private const int MAXVIEWABLECOMMENT = 7;

	private int cooltime;

	public bool isUncontrollable;

	public bool isOiwai;

	public bool isStartRead;

	[SerializeField]
	public bool isGuideEnable;

	[SerializeField]
	private TMP_Text jimakuShowing;

	[SerializeField]
	private VerticalLayoutGroup jimakuLayout;

	[SerializeField]
	private TMP_Text haisinTitle;

	[SerializeField]
	private TMP_Text haisinDetail;

	[SerializeField]
	public TMP_Text CommentLabel;

	[SerializeField]
	public RectTransform CommentParent;

	[SerializeField]
	public Image CommentBg;

	[SerializeField]
	private RectTransform ScenarioParent;

	[SerializeField]
	private GameObject ScenarioPrefab;

	[SerializeField]
	private LiveComment CommentPrefab;

	[SerializeField]
	private Slider slider;

	[SerializeField]
	public TenchanView Tenchan;

	[SerializeField]
	public Image TenchanBg;

	[SerializeField]
	public GameObject GrandBg;

	private string todaysTenchan = "stream_cho_akaruku";

	private List<StatusDiff> statusDiffs;

	public LiveScenario NowPlaying;

	private int watcher;

	public bool isHayakuti;

	private int commentCounter;

	private int scenarioLength = 1;

	private LanguageType _lang;

	private static string[] separator = new string[1] { "___" };

	[SerializeField]
	private Transform ReadCommentParent;

	[SerializeField]
	public ScrollRect CommentScroll;

	private bool isSpeaking;

	private Tweener Jimaku;

	private bool _lockSpeed;

	[SerializeField]
	private TMP_Text AntiText;

	[SerializeField]
	private GameObject AntiBalloon;

	private List<LiveComment> _selectableComments = new List<LiveComment>();

	private List<string> ReadingSerihu = new List<string> { "StartRead_001", "StartRead_002", "StartRead_003", "StartRead_004", "StartRead_005", "StartRead_006", "StartRead_007", "StartRead_008", "StartRead_009" };

	public List<LiveComment> SelectableComments => _selectableComments;

	public LiveComment SelectingComment { get; set; }

	public async UniTask Awake()
	{
		SingletonMonoBehaviour<CursorManager>.Instance.EnableLiveCursorMode();
		_lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		Speed = SingletonMonoBehaviour<Settings>.Instance.haishinSpeed;
		statusDiffs = new List<StatusDiff>();
		chotenView(SingletonMonoBehaviour<EventManager>.Instance.alpha, SingletonMonoBehaviour<EventManager>.Instance.beta);
		SetScenario();
		bgView();
		haisinTitle.text = GetTitle();
		watcher = Math.Max(SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower) / 5, 192);
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_DarkAngel)
		{
			watcher = 1000422;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ideon)
		{
			watcher = 100000000;
		}
		UpdateDetail();
		setSpeed();
		RefreshYomuCommentLabel();
		_HaisinSpeed.OnClickAsObservable().Subscribe(delegate
		{
			ToggleSpeed();
		}).AddTo(base.gameObject);
		NowPlaying.isGensoku.ObserveEveryValueChanged((ReactiveProperty<bool> v) => v.Value).Subscribe(delegate(bool v)
		{
			if (v)
			{
				_Speedlabel.text = NgoEx.SystemTextFromType(SystemTextType.System_ChoosingComment, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
			else
			{
				_Speedlabel.text = nowSpeedLabel;
			}
		}).AddTo(base.gameObject);
		_HaisinSkip.OnClickAsObservable().Subscribe(delegate
		{
			NowPlaying.SkipScenario();
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(ShortcutInputManager.ControllerMode.Haishin);
		if (isGuideEnable)
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = true;
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.SetActiveLiveApp(this);
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Sucide)
		{
			IWindow component = base.transform.parent.parent.parent.GetComponent<IWindow>();
			if (component != null)
			{
				component.Uncloseable();
				component.UnMovable();
			}
		}
	}

	private void RefreshYomuCommentLabel()
	{
		if (isUncontrollable || isOiwai)
		{
			CommentLabel.text = NgoEx.SystemTextFromType(SystemTextType.Sysyem_NotReadComment, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			CommentBg.color = new Color(0.8f, 0.8f, 0.8f, 1f);
			ReadCommentParent.gameObject.SetActive(value: false);
		}
		else if (isStartRead)
		{
			CommentLabel.text = NgoEx.SystemTextFromType(SystemTextType.Sysyem_StartRead, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			CommentBg.color = new Color(0.8f, 0.8f, 0.8f, 1f);
		}
		else
		{
			CommentLabel.text = NgoEx.SystemTextFromType(SystemTextType.Sysyem_ReadComment, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
	}

	public void ToggleSpeed()
	{
		if (!_lockSpeed)
		{
			Speed++;
			Speed %= 3;
			setSpeed();
		}
	}

	public void DownSpeed()
	{
		if (!_lockSpeed)
		{
			Speed--;
			Speed %= 3;
			setSpeed();
		}
	}

	public void SetSpeedLock(bool isLock)
	{
		_lockSpeed = isLock;
	}

	public void setSpeed(int speed)
	{
		Speed = speed;
		setSpeed();
	}

	public void setAnti(string anticomment, bool onoff)
	{
		if (!(AntiBalloon == null))
		{
			AntiBalloon.SetActive(onoff);
			AntiText.text = anticomment;
			if (onoff)
			{
				AudioManager.Instance.PlaySeByType(SoundType.SE_tweet_kusorep);
			}
		}
	}

	private void setSpeed()
	{
		AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
		switch (Speed)
		{
		case 0:
			nowSpeedLabel = NgoEx.SystemTextFromType(SystemTextType.HaishinSpeed_1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			NowPlaying.STARTSPEED = NowPlaying.TOGGLEDBASESPEED;
			isHayakuti = false;
			break;
		case 1:
			nowSpeedLabel = NgoEx.SystemTextFromType(SystemTextType.HaishinSpeed_2, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			NowPlaying.STARTSPEED = NowPlaying.TOGGLEDBASESPEED / 3;
			isHayakuti = true;
			break;
		default:
			nowSpeedLabel = NgoEx.SystemTextFromType(SystemTextType.HaishinSpeed_3, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			NowPlaying.STARTSPEED = NowPlaying.TOGGLEDBASESPEED / 10;
			isHayakuti = true;
			break;
		case 3:
			nowSpeedLabel = NgoEx.SystemTextFromType(SystemTextType.HaishinSpeed_1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			NowPlaying.STARTSPEED = Mathf.CeilToInt((float)NowPlaying.TOGGLEDBASESPEED / 1.1f);
			isHayakuti = true;
			break;
		}
		_Speedlabel.text = nowSpeedLabel;
		SingletonMonoBehaviour<Settings>.Instance.haishinSpeed = Speed;
	}

	private void UpdateDetail()
	{
		watcher += UnityEngine.Random.Range(-1, 2);
		haisinDetail.text = $"{watcher} {NgoEx.SystemTextFromType(SystemTextType.Haisin_Watching_Number, _lang)} ・ {NgoEx.SystemTextFromType(SystemTextType.Haisin_Started_Day, _lang)} {NgoEx.DayText(SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex), _lang, isLive: true)}";
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Meta)
		{
			haisinDetail.text = "0 " + NgoEx.SystemTextFromType(SystemTextType.Haisin_Watching_Number, _lang) + " ・ " + NgoEx.SystemTextFromType(SystemTextType.Haisin_Started_Day, _lang) + " " + NgoEx.DayText(SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex), _lang);
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Meta)
		{
			slider.value = 1f - (float)NowPlaying.playing.Count / (float)scenarioLength;
		}
	}

	public LiveScenario SetScenario()
	{
		SingletonMonoBehaviour<StatusManager>.Instance.isTodayHaishined = true;
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.RenzokuHaishinCount, 1);
		if (SingletonMonoBehaviour<EventManager>.Instance.loop == 1 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) == 1)
		{
			return SetScenario($"Haishin_Day{SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) - 1}");
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Meta)
		{
			return SetScenario<Ending_Meta_haishin>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Happy)
		{
			return SetScenario<Haishin_Happyend>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ntr)
		{
			return SetScenario<Ending_Ntr_Haishin>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Kyouso)
		{
			return SetScenario<Ending_kyouso_haishin>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Sucide)
		{
			return SetScenario<Ending_Sucide_haishin>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Grand)
		{
			return SetScenario<Ending_Grand_haishin>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_DarkAngel)
		{
			return SetScenario<Ending_DarkAngel_haishin>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ginga)
		{
			return SetScenario<Ending_Ginga_haishin>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ideon)
		{
			return SetScenario<Ending_Ideon_haishin>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.isGedatsu)
		{
			SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Kyouso;
			return SetScenario<Ending_kyouso_haishin>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.isHorror && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) == 25)
		{
			return SetScenario<haishin_horror_day1>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.isHorror && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) == 26)
		{
			return SetScenario<haishin_horror_day2>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.isHorror && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) == 27)
		{
			return SetScenario<haishin_horror_day3>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.isHorror && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) == 28)
		{
			return SetScenario<haishin_horror_day4>();
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.isHorror && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) == 29)
		{
			return SetScenario<haishin_horror_day5>();
		}
		string text = $"Netatip_{SingletonMonoBehaviour<EventManager>.Instance.alpha}_Level{SingletonMonoBehaviour<EventManager>.Instance.alphaLevel}";
		if (isExistScenario(text))
		{
			return SetScenario(text);
		}
		return SetScenario<TestScenario>();
	}

	public LiveScenario SetScenario<T>() where T : LiveScenario
	{
		T val = (T)(NowPlaying = UnityEngine.Object.Instantiate(ScenarioPrefab, ScenarioParent).AddComponent<T>());
		scenarioLength = NowPlaying.playing.Count;
		val.StartScenario();
		return val;
	}

	private bool isExistScenario(string scenarioClass)
	{
		if (Type.GetType("ngov3." + scenarioClass) == null)
		{
			return false;
		}
		return true;
	}

	public LiveScenario SetScenario(string scenarioClass)
	{
		if (!isExistScenario(scenarioClass))
		{
			return new LiveScenario();
		}
		Type type = Type.GetType("ngov3." + scenarioClass);
		LiveScenario liveScenario = (NowPlaying = UnityEngine.Object.Instantiate(ScenarioPrefab, ScenarioParent).AddComponent(type) as LiveScenario);
		scenarioLength = NowPlaying.playing.Count;
		liveScenario.StartScenario();
		return liveScenario;
	}

	public int AddMob(string haisinPoint)
	{
		if (haisinPoint == "rainbow")
		{
			NowPlaying.playing.Insert(1, new Playing(isJimaku: false, "", StatusType.Tension, 1, 0, "a", "", "", isLoopAnim: true, SuperchatType.Blue));
			NowPlaying.playing.Insert(2, new Playing(isJimaku: false, "", StatusType.Tension, 1, 0, "a", "", "", isLoopAnim: true, SuperchatType.Cyan));
			NowPlaying.playing.Insert(3, new Playing(isJimaku: false, "", StatusType.Tension, 1, 0, "a", "", "", isLoopAnim: true, SuperchatType.LightGreen));
			NowPlaying.playing.Insert(4, new Playing(isJimaku: false, "", StatusType.Tension, 1, 0, "a", "", "", isLoopAnim: true, SuperchatType.Yellow));
			NowPlaying.playing.Insert(5, new Playing(isJimaku: false, "", StatusType.Tension, 1, 0, "a", "", "", isLoopAnim: true, SuperchatType.Orange));
			NowPlaying.playing.Insert(6, new Playing(isJimaku: false, "", StatusType.Tension, 1, 0, "a", "", "", isLoopAnim: true, SuperchatType.Magenta));
			NowPlaying.playing.Insert(7, new Playing(isJimaku: false, "", StatusType.Tension, 1, 0, "a", "", "", isLoopAnim: true, SuperchatType.Red));
			return 1;
		}
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		int alphaLevel = SingletonMonoBehaviour<EventManager>.Instance.alphaLevel;
		int num = (int)Math.Max(1.0, Math.Log10(status) * (double)alphaLevel / 2.0);
		for (int i = 0; i < num; i++)
		{
			string nakami = FetchComment(SingletonMonoBehaviour<EventManager>.Instance.alpha, BetaType.akaruku, haisinPoint, status, alphaLevel);
			Playing item = new Playing(isJimaku: false, nakami);
			NowPlaying.playing.Insert(i + 1, item);
		}
		return 1;
	}

	private static List<MobCommentMaster.Param> GetMobCommentList(string haishinPos, int follower)
	{
		MobCommentMaster mobs = NgoEx.getMobs();
		int rank = 1;
		if (follower > 100000)
		{
			rank = 3;
		}
		else if (follower > 10000)
		{
			rank = 2;
		}
		if ((bool)mobs)
		{
			return mobs.param.Where((MobCommentMaster.Param c) => (c.Rank == rank && c.timing == haishinPos) || (c.Rank == 0 && c.timing == haishinPos)).ToList();
		}
		return null;
	}

	private string FetchComment(AlphaType alpha, BetaType beta, string haisinPos, int follower, int tension)
	{
		List<MobCommentMaster.Param> mobCommentList = GetMobCommentList(haisinPos, follower);
		int index = UnityEngine.Random.Range(0, mobCommentList.Count - 1);
		return _lang switch
		{
			LanguageType.JP => mobCommentList[index].BodyJP, 
			LanguageType.CN => mobCommentList[index].BodyCh, 
			LanguageType.KO => mobCommentList[index].BodyKo, 
			LanguageType.TW => mobCommentList[index].BodyTw, 
			LanguageType.VN => mobCommentList[index].BodyVn, 
			LanguageType.FR => mobCommentList[index].BodyFr, 
			LanguageType.IT => mobCommentList[index].BodyIt, 
			LanguageType.GE => mobCommentList[index].BodyGe, 
			LanguageType.SP => mobCommentList[index].BodySp, 
			LanguageType.RU => mobCommentList[index].BodyRu, 
			_ => mobCommentList[index].BodyEn, 
		};
	}

	private void bgView()
	{
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
		if (status > 100000 && status2 > 14)
		{
			Tenchan._backGround.sprite = Tenchan.background_silver_shield;
		}
		if (status > 1000000 && status2 > 27)
		{
			Tenchan._backGround.sprite = Tenchan.background_gold_shield;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Angel)
		{
			switch (SingletonMonoBehaviour<EventManager>.Instance.alphaLevel)
			{
			case 1:
				Tenchan._backGround.sprite = Tenchan.background_kinen1;
				break;
			case 2:
				Tenchan._backGround.sprite = Tenchan.background_kinen2;
				break;
			case 3:
				Tenchan._backGround.sprite = Tenchan.background_kinen3;
				break;
			case 4:
				Tenchan._backGround.sprite = Tenchan.background_kinen4;
				break;
			default:
				Tenchan._backGround.sprite = Tenchan.background_kinen5;
				break;
			}
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Kyouso)
		{
			Tenchan._backGround.sprite = Tenchan._background_kyouso;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.isHorror && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) >= 28)
		{
			Tenchan._backGround.sprite = Tenchan._background_horror;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Happy)
		{
			Tenchan._backGround.sprite = Tenchan._background_happy;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ntr)
		{
			Tenchan._backGround.sprite = Tenchan._background_ntr;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Sucide)
		{
			Tenchan._backGround.sprite = Tenchan._background_sayonara1;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Grand)
		{
			Tenchan._backGround.color = new Color(0f, 0f, 0f, 0f);
			GrandBg.SetActive(value: true);
		}
	}

	private string GetTitle()
	{
		return NowPlaying.title;
	}

	public void chotenView(AlphaType alpha, BetaType beta = BetaType.akaruku, int alphaLevel = 1)
	{
		if (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Angel && SingletonMonoBehaviour<EventManager>.Instance.alphaLevel == 6)
		{
			todaysTenchan = "stream_cho_b_angle";
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ginga)
		{
			todaysTenchan = "stream_cho_g_express1";
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_DarkAngel)
		{
			todaysTenchan = "stream_cho_b_idle2_1";
		}
	}

	public void ChotenAnimation(string animationName, bool isloop)
	{
		Tenchan.PlayAnim(animationName);
	}

	public string SuperChattedChotenAnim()
	{
		return todaysTenchan + "_superchat";
	}

	public void hirowareta(Playing cm)
	{
		if (NowPlaying.playing.Count != 0)
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_kirarin);
			if (ReadCommentParent.childCount >= 2)
			{
				UnityEngine.Object.Destroy(ReadCommentParent.GetChild(0).gameObject);
			}
			UnityEngine.Object.Instantiate(CommentPrefab, ReadCommentParent).SetContent(cm, isRead: true);
		}
	}

	private string getReadAnimationFromHaishin(AlphaType alpha, int level)
	{
		if (level == 5)
		{
			return "";
		}
		switch (alpha)
		{
		case AlphaType.Zatudan:
			return "stream_cho_reaction1";
		case AlphaType.ASMR:
			if (level == 1)
			{
				return "";
			}
			break;
		}
		if (alpha == AlphaType.ASMR && level == 2)
		{
			return "stream_cho_reaction_asmr1";
		}
		if (alpha == AlphaType.ASMR && level == 3)
		{
			return "";
		}
		if (alpha == AlphaType.ASMR && level == 4)
		{
			return "stream_cho_reaction_asmr2";
		}
		switch (alpha)
		{
		case AlphaType.Kaisetu:
			return "stream_cho_reaction_yukkuri1";
		case AlphaType.Hnahaisin:
			if (level == 1)
			{
				return "stream_cho_reaction1";
			}
			break;
		}
		if (alpha == AlphaType.Hnahaisin && level == 2)
		{
			return "stream_cho_reaction_porori";
		}
		if (alpha == AlphaType.Hnahaisin && level == 3)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Hnahaisin && level == 4)
		{
			return "";
		}
		if (alpha == AlphaType.Yamihaishin && level == 1)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Yamihaishin && level == 2)
		{
			return "stream_cho_reaction2";
		}
		if (alpha == AlphaType.Yamihaishin && level == 3)
		{
			return "stream_cho_reaction2";
		}
		if (alpha == AlphaType.Yamihaishin && level == 4)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Gamejikkyou && level == 1)
		{
			return "stream_cho_reaction2";
		}
		if (alpha == AlphaType.Gamejikkyou && level == 2)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Gamejikkyou && level == 3)
		{
			return "stream_cho_reaction_ape";
		}
		if (alpha == AlphaType.Gamejikkyou && level == 4)
		{
			return "stream_cho_reaction_twilight";
		}
		if (alpha == AlphaType.Imbouron && level == 1)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Imbouron && level == 2)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Imbouron && level == 3)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Imbouron && level == 4)
		{
			return "stream_cho_reaction_grgr";
		}
		if (alpha == AlphaType.Kaidan && level == 1)
		{
			return "";
		}
		if (alpha == AlphaType.Kaidan && level == 2)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Kaidan && level == 3)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Kaidan && level == 4)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Taiken && level == 1)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Taiken && level == 2)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Taiken && level == 3)
		{
			return "stream_cho_reaction2";
		}
		if (alpha == AlphaType.Taiken && level == 4)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Otakutalk && level == 1)
		{
			return "stream_cho_reaction_otaku";
		}
		if (alpha == AlphaType.Otakutalk && level == 2)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Otakutalk && level == 3)
		{
			return "stream_cho_reaction1";
		}
		if (alpha == AlphaType.Otakutalk && level == 4)
		{
			return "stream_cho_reaction2";
		}
		if (alpha == AlphaType.Darkness && level == 1)
		{
			return "";
		}
		if (alpha == AlphaType.Darkness && level == 2)
		{
			return "";
		}
		switch (alpha)
		{
		case AlphaType.Angel:
			return "";
		case AlphaType.PR:
			if (level == 1)
			{
				return "stream_cho_reaction_juice";
			}
			break;
		}
		if (alpha == AlphaType.PR && level == 2)
		{
			return "stream_cho_reaction_make";
		}
		if (alpha == AlphaType.PR && level == 3)
		{
			return "stream_cho_reaction_game";
		}
		if (alpha == AlphaType.PR && level == 4)
		{
			return "stream_cho_reaction2";
		}
		return "stream_cho_reaction1";
	}

	private bool isYomiReactionExist(AlphaType alpha, int level)
	{
		if (alpha == AlphaType.Angel)
		{
			return false;
		}
		if (level == 5)
		{
			return false;
		}
		if (alpha == AlphaType.ASMR && level == 1)
		{
			return false;
		}
		if (alpha == AlphaType.ASMR && level == 3)
		{
			return false;
		}
		if (alpha == AlphaType.ASMR && level == 4)
		{
			return false;
		}
		return true;
	}

	public void ReadComment()
	{
		isStartRead = true;
		NowPlaying.isGensoku.Value = false;
		RefreshYomuCommentLabel();
		if (ReadCommentParent.childCount == 0)
		{
			return;
		}
		List<Playing> list = new List<Playing>();
		if (isYomiReactionExist(SingletonMonoBehaviour<EventManager>.Instance.alpha, SingletonMonoBehaviour<EventManager>.Instance.alphaLevel))
		{
			string readAnimationFromHaishin = getReadAnimationFromHaishin(SingletonMonoBehaviour<EventManager>.Instance.alpha, SingletonMonoBehaviour<EventManager>.Instance.alphaLevel);
			if (readAnimationFromHaishin != "")
			{
				list.Add(new Playing(isJimaku: true, NgoEx.TenTalk(ReadingSerihu[UnityEngine.Random.Range(0, ReadingSerihu.Count)], SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), StatusType.Tension, 1, 0, "", "", readAnimationFromHaishin));
			}
			else
			{
				list.Add(new Playing(isJimaku: true, NgoEx.TenTalk(ReadingSerihu[UnityEngine.Random.Range(0, ReadingSerihu.Count)], SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)));
			}
		}
		for (int i = 1; i <= ReadCommentParent.childCount; i++)
		{
			Playing playing = ReadCommentParent.GetChild(i - 1).GetComponent<LiveComment>().playing;
			string text = ((SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN) ? "“" : "「");
			string text2 = ((SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN) ? "”" : "」");
			list.Add(new Playing(isJimaku: true, text + playing.nakami + text2, StatusType.Tension, playing.additionalTension));
			if (playing.henji != "")
			{
				SuperChattedChotenAnim();
				_ = playing.henjiAnim != "";
				string[] array = playing.henji.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				string[] array2 = playing.henjiAnim.Split(separator, StringSplitOptions.None);
				for (int j = 0; j < array.Length; j++)
				{
					list.Add(new Playing(isJimaku: true, array[j], StatusType.Tension, 1, 0, "", "", array2[Math.Max(0, Math.Min(j, array2.Length - 1))], playing.isLoopAnim));
				}
			}
		}
		NowPlaying.playing.InsertRange(1, list);
	}

	public async UniTask ShowJimaku(Playing playing)
	{
		float num = (isHayakuti ? 0.02f : 0.05f);
		if (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN || SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.FR || SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.IT || SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.GE || SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.SP || SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.RU)
		{
			Canvas.ForceUpdateCanvases();
			jimakuLayout.SetLayoutVertical();
			jimakuLayout.SetLayoutHorizontal();
			SetJimakuPostion(jimakuLayout.gameObject, jimakuShowing.text);
		}
		jimakuShowing.text = "";
		string endValue = playing.nakami.Replace("<br>", "\n");
		Jimaku = jimakuShowing.DOText(endValue, (float)playing.nakami.Length * num).SetEase(Ease.Linear);
		isSpeaking = true;
		await Jimaku.Play();
		await UniTask.Delay(Constants.FAST / 8);
		isSpeaking = false;
	}

	private void SetJimakuPostion(GameObject jimakuTransform, string showText)
	{
		showText = Regex.Replace(showText, "<br\\s*/*>", "\n", RegexOptions.IgnoreCase);
		showText = showText.Replace("\r\n", "\n");
		int num = showText.Count((char c) => c == '\n') + 1;
		RectTransform component = jimakuTransform.GetComponent<RectTransform>();
		switch (num)
		{
		case 4:
			component.anchoredPosition = new Vector3(0f, 75f, 0f);
			break;
		case 5:
			component.anchoredPosition = new Vector3(0f, 95f, 0f);
			break;
		case 6:
			component.anchoredPosition = new Vector3(0f, 115f, 0f);
			break;
		default:
			component.anchoredPosition = new Vector3(0f, 55f, 0f);
			break;
		}
	}

	private void NextSerihu()
	{
		if (isSpeaking)
		{
			Jimaku.Kill(complete: true);
		}
		else
		{
			NowPlaying.PlayScenarioToNextSerihu();
		}
	}

	public void NewComment(Playing playing)
	{
		LiveComment component = CommentParent.GetChild(commentCounter).GetComponent<LiveComment>();
		_selectableComments.Add(component);
		component.gameObject.SetActive(value: true);
		component.SetContent(playing);
		UpdateDetail();
		CommentScroll.verticalNormalizedPosition = 0f;
		commentCounter++;
	}

	public void CommentScrollToLatest()
	{
		CommentScroll.verticalNormalizedPosition = 0f;
	}

	public void CommentScrollToTarget(LiveComment targetComment)
	{
		RectTransform component = targetComment.GetComponent<RectTransform>();
		Vector2 anchoredPosition = component.anchoredPosition;
		float y = component.sizeDelta.y;
		Vector2 anchoredPosition2 = CommentParent.anchoredPosition;
		CommentParent.anchoredPosition = new Vector2(anchoredPosition2.x, anchoredPosition.y * -1f - y);
	}

	public bool isActiveReaction()
	{
		if (isUncontrollable || isStartRead || isOiwai)
		{
			setCursor(1);
			NowPlaying.isGensoku.Value = false;
			return false;
		}
		return true;
	}

	public void Actioned()
	{
		cooltime = 0;
		if (isUncontrollable || isStartRead || isOiwai)
		{
			setCursor(1);
		}
	}

	private void setCursor(int time)
	{
		if (time >= 0)
		{
			if (time == 1)
			{
				SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(Countdown1, hotSpot, cursorMode);
			}
			else
			{
				SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, hotSpot, cursorMode);
			}
		}
	}

	public void EndHaishin()
	{
		NowPlaying.isGensoku.Value = false;
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, hotSpot, cursorMode);
		if (isGuideEnable)
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.RemoveActiveLiveApp();
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = false;
		}
		SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(ShortcutInputManager.ControllerMode.Desktop);
		statusDiffs.Clear();
		SingletonMonoBehaviour<EventManager>.Instance.EndHaishin();
		SingletonMonoBehaviour<CursorManager>.Instance.DisableLiveCursorMode();
	}

	public void HaishinClean()
	{
		NowPlaying.isGensoku.Value = false;
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, hotSpot, cursorMode);
		if (isGuideEnable)
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.RemoveActiveLiveApp();
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = false;
		}
		SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(ShortcutInputManager.ControllerMode.Desktop);
		statusDiffs.Clear();
		SingletonMonoBehaviour<EventManager>.Instance.HaishinClean();
	}
}
