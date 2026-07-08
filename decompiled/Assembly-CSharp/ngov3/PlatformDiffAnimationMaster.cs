using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ngov3;

public class PlatformDiffAnimationMaster : ScriptableObject
{
	[SerializeField]
	private List<PlatformDiffAnimationEntity> platformDiffAnimationEntities;

	public string GetAnimationNameFromKey(PlatformDiffAnimationKey key)
	{
		return platformDiffAnimationEntities.FirstOrDefault((PlatformDiffAnimationEntity e) => e.PlatformDiffAnimationKey == key).SteamAnimationName;
	}
}
