using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class AnimationKeyItem : MonoBehaviour
{
	[SerializeField]
	public TMP_Text text;

	[SerializeField]
	private Button button;

	private AnimationKeyVO vo;

	public void Initialize(AnimationKeyVO vo, Action<AnimationKeyVO> action)
	{
		text.text = vo.Id;
		this.vo = vo;
		button.onClick.AddListener(delegate
		{
			action(this.vo);
		});
	}

	private void Start()
	{
	}
}
