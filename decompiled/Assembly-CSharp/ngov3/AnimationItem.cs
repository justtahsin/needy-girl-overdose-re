using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ngov3;

public class AnimationItem : MonoBehaviour
{
	[SerializeField]
	private TMP_Text name;

	[SerializeField]
	private Button button;

	private Action action;

	public void Initialize(Action action, string nameLabelText)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		this.action = action;
		name.text = nameLabelText;
		((UnityEvent)button.onClick).AddListener((UnityAction)delegate
		{
			this.action();
		});
	}
}
