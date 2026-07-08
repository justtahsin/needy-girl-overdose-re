using System;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3.demo;

public class DemoCategoryItem : MonoBehaviour
{
	[SerializeField]
	private Image image;

	private AnimationCategoryVO vo;

	[SerializeField]
	private Button button;

	public void Initialize(AnimationCategoryVO vo, Action<AnimationCategoryVO> action)
	{
		image.sprite = vo.IconSprite;
		this.vo = vo;
		button.onClick.AddListener(delegate
		{
			action(this.vo);
		});
	}
}
