using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ngov3;

public class AnimationCategoryItem : MonoBehaviour
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private TMP_Text name;

	private AnimationCategoryVO vo;

	[SerializeField]
	private Button button;

	public void Initialize(AnimationCategoryVO vo, Action<AnimationCategoryVO> action)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		image.sprite = vo.IconSprite;
		name.text = NgoEx.SystemTextFromTypeString(vo.AnimationCategory.ToString(), SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		this.vo = vo;
		((UnityEvent)button.onClick).AddListener((UnityAction)delegate
		{
			action(this.vo);
		});
	}
}
