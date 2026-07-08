using System.Collections.Generic;
using NGO;
using UnityEngine;

namespace ngov3;

public static class SaveRelayer
{
	private static readonly string PlayStationSettingLoadKey = "PlayStationSettingKey";

	public static string EXTENTION => ".es3";

	public static SlotData LoadSlotData(string fileName)
	{
		return LoadSlotByES3(fileName);
	}

	public static void SaveSlotData(string fileName, SlotData slotData)
	{
		SaveSlotByES3(fileName, slotData);
	}

	public static SettingData LoadSettings()
	{
		return LoadSettingsByES3();
	}

	public static void SaveSettings(SettingData data)
	{
		SaveSettingsByES3(data);
	}

	public static bool IsSlotDataExists(string fileName)
	{
		return ES3.FileExists(fileName);
	}

	public static bool IsSettingDataExists()
	{
		return ES3.FileExists("Settings" + EXTENTION);
	}

	public static void DeleteData(string fileName)
	{
		ES3.DeleteFile(fileName);
	}

	public static void DeleteDatas(List<string> fileNames)
	{
		foreach (string fileName in fileNames)
		{
			ES3.DeleteFile(fileName);
		}
	}

	private static SlotData LoadSlotByPlayStation(string fileName)
	{
		string text = PlayerPrefs.GetString(fileName, "");
		if (string.IsNullOrEmpty(text))
		{
			return new SlotData();
		}
		return JsonUtility.FromJson<SlotData>(text);
	}

	private static void SaveSlotByPlayStation(string fileName, SlotData data)
	{
		string text = JsonUtility.ToJson((object)data);
		PlayerPrefs.SetString(fileName, text);
		PlayerPrefs.Save();
	}

	private static SettingData LoadSettingsByPlayStation()
	{
		string text = PlayerPrefs.GetString(PlayStationSettingLoadKey, "");
		if (string.IsNullOrEmpty(text))
		{
			return new SettingData();
		}
		return JsonUtility.FromJson<SettingData>(text);
	}

	private static void SaveSettingsByPlayStation(SettingData data)
	{
		string text = JsonUtility.ToJson((object)data);
		PlayerPrefs.SetString(PlayStationSettingLoadKey, text);
		PlayerPrefs.Save();
	}

	private static SlotData LoadSlotByES3(string fileName)
	{
		return new SlotData
		{
			jineHistory = ES3.Load<List<JineData>>("JINEHISTORY", fileName),
			poketterHistory = ES3.Load<List<TweetData>>("POKETTERHISTORY", fileName),
			eventsHistory = ES3.Load<List<string>>("EVENTHISTORY", fileName),
			dayActionHistory = ES3.Load("DAYACTIONHISTORY", fileName, new List<string>()),
			loop = (int)ES3.Load("LOOPCOUNT", fileName),
			midokumushi = (int)ES3.Load("MIDOKUCOUNT", fileName),
			psycheCount = ES3.Load("PSYCHECOUNT", fileName, 0),
			havingNetas = ES3.Load<List<AlphaLevel>>("HAVINGNETAS", fileName),
			usedNetas = ES3.Load<List<AlphaLevel>>("USEDNETAS", fileName),
			isJuncho = ES3.Load<bool>("ISJUNCHO", fileName),
			isHearTrauma = ES3.Load<bool>("ISHEARTRAUMA", fileName),
			trauma = ES3.Load<JineType>("TRAUMA", fileName),
			firstDate = ES3.Load("FIRSTDATE", fileName, CmdType.None),
			isHappaOK = ES3.Load<bool>("ISHAPPAOK", fileName),
			isHorror = ES3.Load<bool>("ISHORROR", fileName),
			isGedatsu = ES3.Load<bool>("ISGEDATSU", fileName),
			beforeWristCut = ES3.Load("BEFOREWRISTCUT", fileName, defaultValue: false),
			isWristCut = ES3.Load("ISWRISTCUT", fileName, defaultValue: false),
			isHakkyo = ES3.Load("ISHAKKYO", fileName, defaultValue: false),
			wishlist = ES3.Load("WISHLIST", fileName, 0),
			loveDiary = ES3.Load("LOVEDIARY", fileName, 0),
			isShurokued = ES3.Load("ISSHUROKUED", fileName, defaultValue: false),
			kyuusiCount = ES3.Load("KYUUSICOUNT", fileName, 0),
			isOpenGinga = ES3.Load("ISOPENGINGA", fileName, defaultValue: false),
			is150mil = ES3.Load("IS150MIL", fileName, defaultValue: false),
			is300mil = ES3.Load("IS300MIL", fileName, defaultValue: false),
			is500mil = ES3.Load("IS500MIL", fileName, defaultValue: false),
			stats = ES3.Load<List<Status>>("STATUS", fileName)
		};
	}

	private static void SaveSlotByES3(string fileName, SlotData data)
	{
		ES3.Save("JINEHISTORY", data.jineHistory, fileName);
		ES3.Save("POKETTERHISTORY", data.poketterHistory, fileName);
		ES3.Save("EVENTHISTORY", data.eventsHistory, fileName);
		ES3.Save("DAYACTIONHISTORY", data.dayActionHistory, fileName);
		ES3.Save("LOOPCOUNT", data.loop, fileName);
		ES3.Save("MIDOKUCOUNT", data.midokumushi, fileName);
		ES3.Save("PSYCHECOUNT", data.psycheCount, fileName);
		ES3.Save("STATUS", data.stats, fileName);
		ES3.Save("HAVINGNETAS", data.havingNetas, fileName);
		ES3.Save("USEDNETAS", data.usedNetas, fileName);
		ES3.Save("ISJUNCHO", data.isJuncho, fileName);
		ES3.Save("ISHEARTRAUMA", data.isHearTrauma, fileName);
		ES3.Save("TRAUMA", data.trauma, fileName);
		ES3.Save("FIRSTDATE", data.firstDate, fileName);
		ES3.Save("ISHAPPAOK", data.isHappaOK, fileName);
		ES3.Save("ISHORROR", data.isHorror, fileName);
		ES3.Save("ISGEDATSU", data.isGedatsu, fileName);
		ES3.Save("WISHLIST", data.wishlist, fileName);
		ES3.Save("ISWRISTCUT", data.isWristCut, fileName);
		ES3.Save("ISHAKKYO", data.isHakkyo, fileName);
		ES3.Save("BEFOREWRISTCUT", data.beforeWristCut, fileName);
		ES3.Save("ISSHUROKUED", data.isShurokued, fileName);
		ES3.Save("KYUUSICOUNT", data.kyuusiCount, fileName);
		ES3.Save("LOVEDIARY", data.loveDiary, fileName);
		ES3.Save("ISOPENGINGA", data.isOpenGinga, fileName);
		ES3.Save("IS150MIL", data.is150mil, fileName);
		ES3.Save("IS300MIL", data.is300mil, fileName);
		ES3.Save("IS500MIL", data.is500mil, fileName);
	}

	private static SettingData LoadSettingsByES3()
	{
		SettingData settingData = new SettingData();
		string filePath = "Settings.es3";
		settingData.languageType = ES3.Load<LanguageType>("LANG", filePath);
		settingData.bgmVolume = ES3.Load<float>("BGM", filePath);
		settingData.seVolume = ES3.Load<float>("SE", filePath);
		settingData.haishinSpeed = ES3.Load("HAISHINSPEED", filePath, 0);
		settingData.mitaEnd = ES3.Load<List<EndingType>>("ENDINGS", filePath);
		settingData.imageHistory = ES3.Load("IMAGEHISTORY", filePath, new List<string>());
		settingData.animationKeyHistory = ES3.Load("ANIMATIONKETHISTORY", filePath, new List<string>());
		settingData.unLockedZip = ES3.Load("UNLOCKEDZIP", filePath, new List<int>());
		settingData.resolution = ES3.Load("RESOLUTION", filePath, ResolutionType.Toubai);
		return settingData;
	}

	private static void SaveSettingsByES3(SettingData data)
	{
		string filePath = "Settings.es3";
		ES3.Save("LANG", data.languageType, filePath);
		ES3.Save("BGM", data.bgmVolume, filePath);
		ES3.Save("SE", data.seVolume, filePath);
		ES3.Save("HAISHINSPEED", data.haishinSpeed, filePath);
		ES3.Save("ENDINGS", data.mitaEnd, filePath);
		ES3.Save("IMAGEHISTORY", data.imageHistory, filePath);
		ES3.Save("ANIMATIONKETHISTORY", data.animationKeyHistory, filePath);
		ES3.Save("UNLOCKEDZIP", data.unLockedZip, filePath);
		ES3.Save("RESOLUTION", data.resolution, filePath);
	}

	private static SlotData LoadSlotForSwitch(string fileName)
	{
		return new SlotData();
	}

	private static void SaveSlotForSwitch(string fileName, SlotData data)
	{
	}

	private static SettingData LoadSettingsForSwitch()
	{
		return new SettingData();
	}

	private static void SaveSettingsForSwitch(SettingData data)
	{
	}
}
