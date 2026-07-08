using System.Collections.Generic;
using UnityEngine;

namespace ngov3;

[CreateAssetMenu]
public class AchievementDataStore : ScriptableObject
{
	[SerializeField]
	private List<AchievementData> achievementDatas;

	public IReadOnlyList<AchievementData> AchievementDatas => achievementDatas;
}
