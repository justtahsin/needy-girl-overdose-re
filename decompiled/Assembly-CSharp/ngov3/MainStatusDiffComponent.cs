using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class MainStatusDiffComponent : MonoBehaviour
{
	[SerializeField]
	private Image _statusIcon;

	[SerializeField]
	private TMP_Text _statusName;

	[SerializeField]
	private TMP_Text _statusCurrent;

	[SerializeField]
	private TMP_Text _statusdiff;

	[SerializeField]
	private TMP_Text _newStatus;

	public void Awake()
	{
	}

	public void SetData(StatusDiff diff)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		string text = NgoEx.StatusLabelFromType(diff.statusType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		if (text.Length >= 6)
		{
			_statusName.fontSize = 20f;
		}
		_statusName.text = text;
		_statusIcon.sprite = LoadStatusData.ReadstatusContent(diff.statusType).StatusIcon;
		_statusCurrent.text = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(diff.statusType).ToString();
		string text2 = "";
		if (diff.delta > 0)
		{
			((Graphic)_statusdiff).color = new Color(0.36444443f, 0.5511111f, 1.0266666f, 1f);
			int num = diff.delta / 2 + 1;
			for (int i = 1; i <= num && i <= 6; i++)
			{
				text2 += "↑";
			}
		}
		else
		{
			int num2 = -(diff.delta / 2) + 1;
			for (int j = 1; j <= num2 && j <= 6; j++)
			{
				text2 += "↓";
			}
		}
		_statusdiff.text = text2;
		int num3 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(diff.statusType) + diff.delta;
		_newStatus.text = Mathf.Clamp(num3, SingletonMonoBehaviour<StatusManager>.Instance.GetMinStatus(diff.statusType), SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(diff.statusType)).ToString();
	}
}
