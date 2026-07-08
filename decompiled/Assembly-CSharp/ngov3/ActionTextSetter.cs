using TMPro;
using UnityEngine;

namespace ngov3;

public class ActionTextSetter : MonoBehaviour
{
	[SerializeField]
	private ActionType actionType = ActionType.None;

	[SerializeField]
	private TMP_Text label;

	private void Start()
	{
		label.text = CommandHelper.GetCommandTitle(actionType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}
}
