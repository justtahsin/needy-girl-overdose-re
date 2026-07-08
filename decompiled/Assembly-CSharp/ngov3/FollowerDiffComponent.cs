using TMPro;
using UnityEngine;

namespace ngov3;

public class FollowerDiffComponent : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _statusName;

	[SerializeField]
	private TMP_Text _arrows;

	[SerializeField]
	private BonusComponent _bonusPrefab;

	[SerializeField]
	private Transform _diffParent;

	public void Awake()
	{
		_statusName.text = NgoEx.StatusLabelFromType(StatusType.Follower, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	public void SetData(int diff)
	{
		int num = diff / 4 + 1;
		string text = "";
		for (int i = 1; i < num && i <= 6; i++)
		{
			text += "↑";
		}
		_arrows.text = text;
	}

	public void SetBonus(CmdMaster.Param c)
	{
		LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		Object.Instantiate(_bonusPrefab, _diffParent).SetData(NgoEx.StatusLabelFromType(StatusType.RenzokuHaishinCount, value), SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.RenzokuHaishinCount) + 1);
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.SNSzizenKokutiBonus) != 0)
		{
			Object.Instantiate(_bonusPrefab, _diffParent).SetData(NgoEx.StatusLabelFromType(StatusType.SNSzizenKokutiBonus, value), 1.2f);
		}
		if (c.Id.StartsWith("Game"))
		{
			Object.Instantiate(_bonusPrefab, _diffParent).SetData(NgoEx.StatusLabelFromType(StatusType.GameCountBonus, value), (float)SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.GameCountBonus) / 2f + 1f);
		}
		if (c.Id.StartsWith("Otakutalk") || c.Id.StartsWith("AnimeTalk"))
		{
			Object.Instantiate(_bonusPrefab, _diffParent).SetData(NgoEx.StatusLabelFromType(StatusType.CinePhillCountBonus, value), (float)SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.CinePhillCountBonus) / 2f + 1f);
		}
		if (c.Id.StartsWith("Yamihaishin") || c.Id.StartsWith("Darkness"))
		{
			Object.Instantiate(_bonusPrefab, _diffParent).SetData(NgoEx.StatusLabelFromType(StatusType.OkusuriedCounter, value), (float)SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.OkusuriedCounter) / 2f + 1f);
		}
		if (c.Id.StartsWith("ASMR") || c.Id.StartsWith("Hnahaisin"))
		{
			Object.Instantiate(_bonusPrefab, _diffParent).SetData(NgoEx.StatusLabelFromType(StatusType.OirokeCounter, value), (float)SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.OirokeCounter) / 2f + 1f);
		}
		Object.Instantiate(_bonusPrefab, _diffParent).SetData(NgoEx.StatusLabelFromType(StatusType.DougaTVShabekuriCountBonus, value), (float)SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DougaTVShabekuriCountBonus) / 10f + 1f);
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Harumagedo) > 0)
		{
			Object.Instantiate(_bonusPrefab, _diffParent).SetData(NgoEx.StatusLabelFromType(StatusType.Harumagedo, value), (float)(-SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Harumagedo)) / 100f + 1f);
		}
	}
}
