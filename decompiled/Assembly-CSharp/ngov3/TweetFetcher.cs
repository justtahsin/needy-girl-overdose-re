using System;
using System.Collections.Generic;
using System.Linq;
using NGO;
using UnityEngine;

namespace ngov3;

public static class TweetFetcher
{
	private static List<TweetMaster.Param> _tweetRawList = null;

	private static List<KRepMaster.Param> _KusorepRawList = null;

	private static Dictionary<CommandResult, string> ResultDictionary = new Dictionary<CommandResult, string>
	{
		{
			CommandResult.success,
			"success"
		},
		{
			CommandResult.failure,
			"failure"
		},
		{
			CommandResult.times0,
			"0回目"
		},
		{
			CommandResult.times1,
			"1回目"
		},
		{
			CommandResult.times2,
			"2回目"
		},
		{
			CommandResult.times3,
			"3回目"
		},
		{
			CommandResult.times4,
			"4回目"
		},
		{
			CommandResult.times5,
			"5回目"
		}
	};

	private static List<string> _suteakaIconList = new List<string>
	{
		"icon_kusoripu_black", "icon_kusoripu_blue", "icon_kusoripu_cyan", "icon_kusoripu_orange", "icon_kusoripu_pink", "icon_kusoripu_purple", "icon_kusoripu_yellow", "icon_kusoripu8", "icon_kusoripu9", "icon_kusoripu10",
		"icon_kusoripu11", "icon_kusoripu12", "icon_kusoripu13", "icon_kusoripu14", "icon_kusoripu15", "icon_kusoripu16", "icon_kusoripu17", "icon_kusoripu18", "icon_kusoripu19", "icon_kusoripu20",
		"icon_kusoripu21", "icon_kusoripu22", "icon_kusoripu23", "icon_kusoripu24", "icon_kusoripu25", "icon_kusoripu26", "icon_kusoripu27", "icon_kusoripu28", "icon_kusoripu29", "icon_kusoripu30",
		"icon_kusoripu31", "icon_kusoripu32"
	};

	private static List<TweetMaster.Param> getTweetRawList()
	{
		if (_tweetRawList == null)
		{
			_tweetRawList = Resources.Load<TweetMaster>("Master/Tweet").param;
		}
		return _tweetRawList;
	}

	private static List<KRepMaster.Param> getKusorepRawList()
	{
		if (_KusorepRawList == null)
		{
			_KusorepRawList = Resources.Load<KRepMaster>("Master/KRep").param;
		}
		return _KusorepRawList;
	}

	public static TweetType CommandTweet(CommandType commandType, CommandResult commandResult, WindowType windowType = WindowType.None)
	{
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart);
		return ChooseOne(FilterHistory(SingletonMonoBehaviour<PoketterManager>.Instance.history, FetchAvailable(commandType, commandResult, status, windowType)));
	}

	public static List<TweetType> FetchAvailable(CommandType commandType, CommandResult commandResult, int DayPart = 0, WindowType windowType = WindowType.None)
	{
		List<TweetMaster.Param> list = getTweetRawList().FindAll((TweetMaster.Param t) => IsEqualCommandId(t, commandType) && IsEqualResult(t, commandResult) && IsMatchTime(t, DayPart));
		List<TweetType> list2 = new List<TweetType>();
		foreach (TweetMaster.Param item in list)
		{
			list2.Add(ConvertRawTweetClientToType(item));
		}
		return list2;
	}

	private static TweetType ConvertRawTweetClientToType(TweetMaster.Param t)
	{
		Enum.TryParse<TweetType>(t.Id, out var result);
		return result;
	}

	private static bool IsEqualCommandId(TweetMaster.Param t, CommandType c)
	{
		if (!(t.CommandID != "N/A"))
		{
			return c.ToString() == "None";
		}
		return t.CommandID == c.ToString();
	}

	private static bool IsEqualResult(TweetMaster.Param t, CommandResult r)
	{
		return t.Result == ResultDictionary[r];
	}

	private static bool IsMatchTime(TweetMaster.Param t, int DayPart)
	{
		if (DayPart != 0 && t.isDay)
		{
			return false;
		}
		if (DayPart != 2 && t.isNight)
		{
			return false;
		}
		return true;
	}

	public static List<TweetType> FilterHistory(List<TweetData> tweetHistory, List<TweetType> list)
	{
		List<TweetType> list2 = new List<TweetType>();
		foreach (TweetData item in tweetHistory)
		{
			list2.Add(item.Type);
		}
		return list.Except(list2).ToList();
	}

	public static TweetType ChooseOne(List<TweetType> list)
	{
		if (list.Count == 0)
		{
			return TweetType.None;
		}
		return list[Random.Range(0, list.Count)];
	}

	public static TweetMaster.Param ConvertTypeToTweet(TweetType t)
	{
		return getTweetRawList().Find((TweetMaster.Param tw) => tw.Id == t.ToString());
	}

	public static KRepMaster.Param ConvertTypeToKusorep(KusoRepType t)
	{
		return getKusorepRawList().FirstOrDefault((KRepMaster.Param tw) => tw.Id == t.ToString());
	}

	public static string SuteakaIconId()
	{
		return _suteakaIconList[Random.Range(0, _suteakaIconList.Count)];
	}
}
