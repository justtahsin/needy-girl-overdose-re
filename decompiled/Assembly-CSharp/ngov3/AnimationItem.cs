using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class AnimationItem : MonoBehaviour
{
	[SerializeField]
	private new TMP_Text name;

	[SerializeField]
	private Button button;

	private Action action;

	public void Initialize(Action action, string nameLabelText)
	{
		this.action = action;
		name.text = nameLabelText;
		button.onClick.AddListener(delegate
		{
			this.action();
		});
	}
}
