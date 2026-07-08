using TMPro;
using UnityEngine;
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
		_guardButton.onClick.AddListener(delegate
		{
			_targetInputField.ActivateInputField();
		});
	}
}
