using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ngov3;

public class ScrollableInputField : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField _targetInputField;

	[SerializeField]
	private Button _guardButton;

	private void Start()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		((UnityEvent)_guardButton.onClick).AddListener((UnityAction)delegate
		{
			_targetInputField.ActivateInputField();
		});
	}
}
