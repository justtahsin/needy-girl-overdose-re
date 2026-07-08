using System.Linq;
using Steamworks;
using UnityEngine;

namespace ngov3;

public static class AchievementStatsUpdater
{
	public static void UpdateStats(string pchName)
	{
		Debug.LogError("AchievementStatsUpdater:" + pchName);
		if (SteamManager.Initialized)
		{
			SteamUserStats.SetAchievement(pchName);
			SteamUserStats.StoreStats();
		}
		AchievementData achievementData = Resources.Load<AchievementDataStore>("AchievementDataStore/AchievementDataStore").AchievementDatas.FirstOrDefault((AchievementData ad) => ad.SteamAchievementID == pchName);
		Debug.LogError("GetData");
		if (achievementData == null)
		{
			Debug.LogError("No Exist AchivementData");
		}
		else
		{
			_ = achievementData.PlayStationTrophyID;
		}
	}
}
