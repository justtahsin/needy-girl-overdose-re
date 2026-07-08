using System;
using System.Collections.Generic;
using System.Linq;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class CommandManager : SingletonMonoBehaviour<CommandManager>
{
	public ReactiveProperty<Dictionary<ActionType, ActionStatus>> commandStatus = new ReactiveProperty<Dictionary<ActionType, ActionStatus>>();

	private Dictionary<ActionType, ActionStatus> abledStatus = new Dictionary<ActionType, ActionStatus>();

	private Dictionary<ActionType, ActionStatus> disabledStatus = new Dictionary<ActionType, ActionStatus>();

	private List<Tuple<ActionType, AlphaLevel>> hints = new List<Tuple<ActionType, AlphaLevel>>();

	protected override void Awake()
	{
		base.Awake();
		for (int i = 0; i < Enum.GetNames(typeof(ActionType)).Length; i++)
		{
			abledStatus.Add((ActionType)Enum.ToObject(typeof(ActionType), i), ActionStatus.Executable);
			disabledStatus.Add((ActionType)Enum.ToObject(typeof(ActionType), i), ActionStatus.Yada);
		}
		commandStatus.Value = abledStatus;
	}

	public void ExecuteCommand(CommandType c, CommandResult r = CommandResult.success, WindowType w = WindowType.None)
	{
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(c, r, w));
	}

	public void CommandAction(CommandType c, WindowType w = WindowType.None)
	{
		ExecuteCommand(c);
	}

	public void CommandAction(ActionType a)
	{
		AudioManager.Instance?.PlaySeByType(SoundType.SE_command_execute);
		SingletonMonoBehaviour<EventManager>.Instance.ExecuteAction(a, ChooseCommand(a));
	}

	public void OnActionHovered(ActionType a)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		CmdMaster.Param c = NgoEx.CmdFromType(ChooseCommand(a));
		if (a != ActionType.Haishin)
		{
			SingletonMonoBehaviour<TooltipManager>.Instance.ShowAction(a, c);
		}
	}

	public void OnActionHovered(AlphaType alpha, int level)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		CmdMaster.Param c = NgoEx.CmdFromType(ChooseCommand(alpha, level));
		SingletonMonoBehaviour<TooltipManager>.Instance.ShowAction(ActionType.Haishin, c);
	}

	public CmdType ChooseCommand(AlphaType alpha, int level)
	{
		return (CmdType)Enum.Parse(typeof(CmdType), alpha.ToString() + "_" + level);
	}

	public CmdType ChooseCommand(ActionType a)
	{
		switch (a)
		{
		case ActionType.Haishin:
		{
			int result = 0;
			if (int.TryParse(SingletonMonoBehaviour<EventManager>.Instance.alpha.ToString(), out result))
			{
				Debug.Log((object)"コマンドタイプに数値が指定されてます");
				return CmdType.Error;
			}
			return (CmdType)Enum.Parse(typeof(CmdType), SingletonMonoBehaviour<EventManager>.Instance.alpha.ToString() + "_" + SingletonMonoBehaviour<EventManager>.Instance.alphaLevel);
		}
		case ActionType.SleepToTwilight:
			return CmdType.SleepToTwilight1;
		case ActionType.SleepToNight:
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) == 0)
			{
				return CmdType.SleepToNight2;
			}
			return CmdType.SleepToNight1;
		case ActionType.SleepToTomorrow:
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) == 0)
			{
				return CmdType.SleepToTomorrow3;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) == 1)
			{
				return CmdType.SleepToTomorrow2;
			}
			return CmdType.SleepToTomorrow1;
		case ActionType.OdekakeNakano:
			return CmdType.OdekakeNakano;
		case ActionType.OdekakeHarajuku:
			return CmdType.OdekakeHarajuku;
		case ActionType.OdekakeAkihabara:
			return CmdType.OdekakeAkihabara;
		case ActionType.OdekakeShibuya:
			return CmdType.OdekakeShibuya;
		case ActionType.OdekakeIkebukuro:
			return CmdType.OdekakeIkebukuro;
		case ActionType.OdekakeUeno:
			return CmdType.OdekakeUeno;
		case ActionType.OdekakeJinbocho:
			return CmdType.OdekakeJinbocho;
		case ActionType.OdekakeShimokitazawa:
			return CmdType.OdekakeShimokitazawa;
		case ActionType.OdekakeKichijoji:
			return CmdType.OdekakeKichijoji;
		case ActionType.OdekakeGisneyland:
			return CmdType.OdekakeGisneyland;
		case ActionType.OdekakeHikarigaokaPark:
			return CmdType.OdekakeHikarigaokaPark;
		case ActionType.OdekakeAsakusa:
			return CmdType.OdekakeAsakusa;
		case ActionType.OdekakeShinjuku:
			return CmdType.OdekakeShinjuku;
		case ActionType.OdekakeToyosu:
			return CmdType.OdekakeToyosu;
		case ActionType.OdekakeOdaiba:
			return CmdType.OdekakeOdaiba;
		case ActionType.OdekakeIchigaya:
			return CmdType.OdekakeIchigaya;
		case ActionType.OdekakeZikka:
			return CmdType.OdekakeZikka;
		case ActionType.OdekakeHospital:
			return CmdType.OdekakeHospital;
		case ActionType.OdekakeGinga:
			return CmdType.OdekakeGinga;
		case ActionType.PlayIchatuku:
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love) < 40)
			{
				return CmdType.PlayIchatukuTalk;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love) >= 80)
			{
				return CmdType.PlayIchatukuKizu;
			}
			return CmdType.PlayIchatukuIchatuku;
		case ActionType.PlayMakeLove:
			if (SingletonMonoBehaviour<StatusManager>.Instance.isTodayGangimari)
			{
				return CmdType.PlayKimeLove;
			}
			return CmdType.PlayMakeLove;
		case ActionType.OkusuriDaypassModerate:
			return CmdType.OkusuriDaypassModerate;
		case ActionType.OkusuriDaypassOverdose:
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) < 20)
			{
				return CmdType.OkusuriDaypassOverdoseY1;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) < 40)
			{
				return CmdType.OkusuriDaypassOverdoseY2;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) < 60)
			{
				return CmdType.OkusuriDaypassOverdoseY3;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) < 80)
			{
				return CmdType.OkusuriDaypassOverdoseY4;
			}
			return CmdType.OkusuriDaypassOverdoseY5;
		case ActionType.OkusuriPuronModerate:
			return CmdType.OkusuriPuronModerate;
		case ActionType.OkusuriPuronOverdose:
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) < 40)
			{
				return CmdType.OkusuriPuronOverdoseY2;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) < 60)
			{
				return CmdType.OkusuriPuronOverdoseY3;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) < 80)
			{
				return CmdType.OkusuriPuronOverdoseY4;
			}
			return CmdType.OkusuriPuronOverdoseY5;
		case ActionType.OkusuriHipuronModerate:
			return CmdType.OkusuriHipuronModerate;
		case ActionType.OkusuriHiPuronOverdose:
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) < 60)
			{
				return CmdType.OkusuriHiPuronOverdoseY3;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) < 80)
			{
				return CmdType.OkusuriHiPuronOverdoseY4;
			}
			return CmdType.OkusuriHiPuronOverdoseY5;
		case ActionType.OkusuriHappa:
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) < 80)
			{
				return CmdType.OkusuriHappaY4;
			}
			return CmdType.OkusuriHappaY5;
		case ActionType.OkusuriPsyche:
			return CmdType.OkusuriPsyche;
		case ActionType.Darkness:
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) < 120)
			{
				return CmdType.DarknessS1;
			}
			return CmdType.DarknessS2;
		case ActionType.EntameGame:
			return CmdType.EntameGame;
		case ActionType.EntameMoviezzzzz:
		case ActionType.EntameTVzzzzz:
		case ActionType.InternetYoutube:
			return CmdType.InternetYoutube;
		case ActionType.InternetPoketter:
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower) >= 100000)
			{
				return CmdType.InternetPoketterPoem;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower) >= 10000)
			{
				if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) >= 60)
				{
					return CmdType.InternetPoketterF1Y45;
				}
				if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) >= 40)
				{
					return CmdType.InternetPoketterF0Y45;
				}
				return CmdType.InternetPoketterF1Y12;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) >= 20)
			{
				return CmdType.InternetPoketterF0Y45;
			}
			return CmdType.InternetPoketterF0Y12;
		case ActionType.InternetPoketterEgosa:
			return CmdType.InternetPoketterF0Y3;
		case ActionType.Internet2ch:
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) >= 60)
			{
				return CmdType.Internet2chY45;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) < 40)
			{
				return CmdType.Internet2chY12;
			}
			return CmdType.Internet2chY3;
		case ActionType.InternetDeai:
			return CmdType.InternetDeai2;
		default:
			return CmdType.Error;
		}
	}

	public void OnBlur()
	{
		SingletonMonoBehaviour<StatusManager>.Instance.CleanDelta();
	}

	public void AddHint(List<Tuple<ActionType, AlphaLevel>> hints)
	{
		this.hints = hints;
	}

	public bool isHinted(ActionType a)
	{
		return hints.Any((Tuple<ActionType, AlphaLevel> item) => item.Item1 == a);
	}

	public void disableAllCommands()
	{
		commandStatus.Value = disabledStatus;
	}

	public void restoreCommands()
	{
		commandStatus.Value = abledStatus;
	}
}
