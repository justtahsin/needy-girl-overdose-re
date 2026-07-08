using System;
using UnityEngine;

namespace ngov3;

[Serializable]
public class PlatformDiffAnimationEntity
{
	[SerializeField]
	private PlatformDiffAnimationKey platformDiffAnimationKey;

	[SerializeField]
	private string steamAnimationName;

	[SerializeField]
	private string ceroDAnimationName;

	public PlatformDiffAnimationKey PlatformDiffAnimationKey => platformDiffAnimationKey;

	public string SteamAnimationName => steamAnimationName;

	public string CERO_DAnimationName => ceroDAnimationName;
}
