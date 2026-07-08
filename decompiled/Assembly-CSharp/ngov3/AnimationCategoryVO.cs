using System;
using UnityEngine;

namespace ngov3;

[Serializable]
public class AnimationCategoryVO
{
	[SerializeField]
	private string id;

	[SerializeField]
	private Sprite iconSprite;

	[SerializeField]
	private AnimationCategoryEnum animationCategory;

	public string Id => id;

	public Sprite IconSprite => iconSprite;

	public AnimationCategoryEnum AnimationCategory => animationCategory;

	public void UpdateAnimationCategoryFromKeyString()
	{
		try
		{
			if (!string.IsNullOrEmpty(id))
			{
				animationCategory = (AnimationCategoryEnum)Enum.Parse(typeof(AnimationCategoryEnum), id);
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("Exception!:" + ex);
		}
	}

	public void SetSprite(Sprite iconSprite)
	{
		this.iconSprite = iconSprite;
	}
}
