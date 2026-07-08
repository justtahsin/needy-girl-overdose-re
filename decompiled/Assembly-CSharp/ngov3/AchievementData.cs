using System;
using UnityEngine;

namespace ngov3;

[Serializable]
public class AchievementData
{
	[SerializeField]
	private string steamAchievementID;

	[SerializeField]
	private int playStationTrophyID;

	public string SteamAchievementID => steamAchievementID;

	public int PlayStationTrophyID => playStationTrophyID;
}
