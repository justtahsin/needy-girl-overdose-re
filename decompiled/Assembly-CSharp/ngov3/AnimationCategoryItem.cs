using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class AnimationCategoryItem : MonoBehaviour
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private new TMP_Text name;

	private AnimationCategoryVO vo;

	[SerializeField]
	private Button button;

	public void Initialize(AnimationCategoryVO vo, Action<AnimationCategoryVO> action)
	{
		image.sprite = vo.IconSprite;
		name.text = NgoEx.SystemTextFromTypeString(vo.AnimationCategory.ToString(), SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		this.vo = vo;
		button.onClick.AddListener(delegate
		{
			action(this.vo);
		});
	}
}
