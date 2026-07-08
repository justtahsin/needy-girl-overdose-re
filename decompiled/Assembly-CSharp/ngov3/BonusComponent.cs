using TMPro;
using UnityEngine;

namespace ngov3;

public class BonusComponent : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _statusName;

	[SerializeField]
	private TMP_Text _newStatus;

	public void Awake()
	{
	}

	public void SetData(string name, float ritu)
	{
		_statusName.text = name + NgoEx.StatusLabelFromType(StatusType.Bonus, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_newStatus.text = "×" + ritu;
	}
}
