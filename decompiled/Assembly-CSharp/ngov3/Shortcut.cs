using System.Collections.Generic;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
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
		_shortcut = GetComponent<Button>();
		_tooltip = GetComponent<TooltipCaller>();
	}

	public void Start()
	{
		if (SingletonMonoBehaviour<StatusManager>.Instance != null)
		{
			_dayPart = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart);
			_dayPart.Subscribe(delegate
			{
				AddHint();
			}).AddTo(base.gameObject);
			AddHint();
		}
		if (appType == AppType.NetaChoose)
		{
			_dayPart.Subscribe(delegate(int v)
			{
				if (SingletonMonoBehaviour<EventManager>.Instance.isTestScene)
				{
					_shortcut.interactable = true;
					_tooltip.isShowTooltip = false;
				}
				else if (SingletonMonoBehaviour<EventManager>.Instance.kyuusiCount > 0)
				{
					_shortcut.interactable = false;
					_tooltip.isShowTooltip = true;
					_tooltip.type = TooltipType.tooltip_kyuusi;
				}
				else if (v == 2)
				{
					_shortcut.interactable = true;
					_tooltip.isShowTooltip = false;
				}
				else
				{
					_shortcut.interactable = false;
					_tooltip.isShowTooltip = true;
					tooltipTextType = SystemTextType.System_CollectNeta;
					SetTooltipText(tooltipTextType);
				}
			}).AddTo(base.gameObject);
		}
		if (appType == AppType.None)
		{
			return;
		}
		_shortcut.onClick.RemoveAllListeners();
		_shortcut.onClick.AddListener(delegate
		{
			if (appType == AppType.Pills)
			{
				if (SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 5))
				{
					_shortcut.interactable = false;
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
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
		{
			AddLabel();
			SetTooltipText(tooltipTextType);
		}).AddTo(_shortcut);
		AddLabel();
	}

	private void AddLabel()
	{
		if (appType != AppType.None && !(label == null))
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
		if (Hint == null)
		{
			return;
		}
		Hint.SetActive(value: false);
		_tooltip.isShowTooltip = false;
		if (appType == AppType.Pills)
		{
			setPillsActionList();
		}
		foreach (ActionType action in actionList)
		{
			if (SingletonMonoBehaviour<CommandManager>.Instance.isHinted(action))
			{
				Hint.SetActive(value: true);
				_tooltip.isShowTooltip = true;
				tooltipTextType = SystemTextType.System_NewNeta;
				SetTooltipText(tooltipTextType);
				break;
			}
		}
	}

	private void SetTooltipText(SystemTextType textType)
	{
		if (_tooltip != null)
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
