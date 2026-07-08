using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		text.text = vo.Id;
		this.vo = vo;
		((UnityEvent)button.onClick).AddListener((UnityAction)delegate
		{
			action(this.vo);
		});
	}

	private void Start()
	{
	}
}
