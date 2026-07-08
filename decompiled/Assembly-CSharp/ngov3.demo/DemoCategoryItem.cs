using System;
using UnityEngine;
using UnityEngine.Events;
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
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		image.sprite = vo.IconSprite;
		this.vo = vo;
		((UnityEvent)button.onClick).AddListener((UnityAction)delegate
		{
			action(this.vo);
		});
	}
}
