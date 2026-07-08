using System;
using System.Collections.Generic;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ngov3;

public class Shortcut : MonoBehaviour
{
	private ReactiveProperty<int> _dayPart;

	protected Button _shortcut;

	public AppType appType;

	public List<ActionType> actionList;

	private TooltipCaller _tooltip;

	private SystemTextType tooltipTextType;

	[SerializeField]
	private TMP_Text label;

	[SerializeField]
	private GameObject Hint;

	public void Awake()
	{
		_shortcut = ((Component)this).GetComponent<Button>();
		_tooltip = ((Component)this).GetComponent<TooltipCaller>();
	}

	public void Start()
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		if ((Object)(object)SingletonMonoBehaviour<StatusManager>.Instance != (Object)null)
		{
			_dayPart = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart);
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)_dayPart, (Action<int>)delegate
			{
				AddHint();
			}), ((Component)this).gameObject);
			AddHint();
		}
		if (appType == AppType.NetaChoose)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)_dayPart, (Action<int>)delegate(int v)
			{
				if (SingletonMonoBehaviour<EventManager>.Instance.isTestScene)
				{
					((Selectable)_shortcut).interactable = true;
					_tooltip.isShowTooltip = false;
				}
				else if (SingletonMonoBehaviour<EventManager>.Instance.kyuusiCount > 0)
				{
					((Selectable)_shortcut).interactable = false;
					_tooltip.isShowTooltip = true;
					_tooltip.type = TooltipType.tooltip_kyuusi;
				}
				else if (v == 2)
				{
					((Selectable)_shortcut).interactable = true;
					_tooltip.isShowTooltip = false;
				}
				else
				{
					((Selectable)_shortcut).interactable = false;
					_tooltip.isShowTooltip = true;
					tooltipTextType = SystemTextType.System_CollectNeta;
					SetTooltipText(tooltipTextType);
				}
			}), ((Component)this).gameObject);
		}
		if (appType == AppType.None)
		{
			return;
		}
		((UnityEventBase)_shortcut.onClick).RemoveAllListeners();
		((UnityEvent)_shortcut.onClick).AddListener((UnityAction)delegate
		{
			if (appType == AppType.Pills)
			{
				if (SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 5))
				{
					((Selectable)_shortcut).interactable = false;
					_tooltip.isShowTooltip = true;
					_tooltip.type = TooltipType.Tooltip_Angel;
				}
				else
				{
					openPillWindows();
				}
			}
			else if (appType != AppType.TextEditor || SingletonMonoBehaviour<EventManager>.Instance.isTestScene || SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Completed)
			{
				if (appType == AppType.NetaChoose && SingletonMonoBehaviour<EventManager>.Instance.isGedatsu)
				{
					SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Action_HaishinStart>();
				}
				else
				{
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(appType);
				}
			}
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			AddLabel();
			SetTooltipText(tooltipTextType);
		}), (Component)(object)_shortcut);
		AddLabel();
	}

	private void AddLabel()
	{
		if (appType != AppType.None && !((Object)(object)label == (Object)null))
		{
			_ = LoadAppData.ReadAppContent(appType).AppName;
			label.text = NgoEx.SystemTextFromType(LoadAppData.ReadAppContent(appType).AppName, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			if (label.text == "")
			{
				label.text = NgoEx.SystemTextFromType(LoadAppData.ReadAppContent(appType).AppName, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
		}
	}

	private void AddHint()
	{
		if ((Object)(object)Hint == (Object)null)
		{
			return;
		}
		Hint.SetActive(false);
		_tooltip.isShowTooltip = false;
		if (appType == AppType.Pills)
		{
			setPillsActionList();
		}
		foreach (ActionType action in actionList)
		{
			if (SingletonMonoBehaviour<CommandManager>.Instance.isHinted(action))
			{
				Hint.SetActive(true);
				_tooltip.isShowTooltip = true;
				tooltipTextType = SystemTextType.System_NewNeta;
				SetTooltipText(tooltipTextType);
				break;
			}
		}
	}

	private void SetTooltipText(SystemTextType textType)
	{
		if ((Object)(object)_tooltip != (Object)null)
		{
			_tooltip.textNakami = NgoEx.SystemTextFromType(tooltipTextType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
	}

	private void setPillsActionList()
	{
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami);
		actionList = new List<ActionType>
		{
			ActionType.OkusuriDaypassModerate,
			ActionType.OkusuriDaypassOverdose
		};
		if (status >= 20)
		{
			actionList = new List<ActionType>
			{
				ActionType.OkusuriDaypassModerate,
				ActionType.OkusuriDaypassOverdose,
				ActionType.OkusuriPuronModerate,
				ActionType.OkusuriPuronOverdose
			};
		}
		if (status >= 40)
		{
			actionList = new List<ActionType>
			{
				ActionType.OkusuriDaypassModerate,
				ActionType.OkusuriDaypassOverdose,
				ActionType.OkusuriPuronModerate,
				ActionType.OkusuriPuronOverdose,
				ActionType.OkusuriHipuronModerate,
				ActionType.OkusuriHiPuronOverdose
			};
		}
		if (status >= 60)
		{
			actionList = new List<ActionType>
			{
				ActionType.OkusuriDaypassModerate,
				ActionType.OkusuriDaypassOverdose,
				ActionType.OkusuriPuronModerate,
				ActionType.OkusuriPuronOverdose,
				ActionType.OkusuriHipuronModerate,
				ActionType.OkusuriHiPuronOverdose,
				ActionType.OkusuriHappa
			};
		}
		if (status >= 80)
		{
			actionList = new List<ActionType>
			{
				ActionType.OkusuriDaypassModerate,
				ActionType.OkusuriDaypassOverdose,
				ActionType.OkusuriPuronModerate,
				ActionType.OkusuriPuronOverdose,
				ActionType.OkusuriHipuronModerate,
				ActionType.OkusuriHiPuronOverdose,
				ActionType.OkusuriHappa,
				ActionType.OkusuriPsyche
			};
		}
	}

	private void openPillWindows()
	{
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.PillDypass);
		if (status >= 20)
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.PillPuron);
		}
		if (status >= 40)
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.PillHipron);
		}
		if (status >= 60)
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.PillHappa);
		}
		if (status >= 80)
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.PillPsyche);
		}
	}
}
