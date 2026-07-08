using System;
using UnityEngine;

namespace ngov3;

[Serializable]
public class AnimationKeyVO
{
	[SerializeField]
	private string id;

	[SerializeField]
	private string key;

	[SerializeField]
	private AnimationCategoryEnum animationCategory;

	public string Id => id;

	public AnimationCategoryEnum AnimationCategory => animationCategory;

	public void UpdateAnimationCategoryFromKeyString()
	{
		try
		{
			if (!string.IsNullOrEmpty(key))
			{
				animationCategory = (AnimationCategoryEnum)Enum.Parse(typeof(AnimationCategoryEnum), key);
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("Exception!:" + ex);
		}
	}
}
