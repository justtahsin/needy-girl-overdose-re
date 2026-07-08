using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class FollowerDiffComponent2D : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _statusName;

	[SerializeField]
	private TMP_Text _arrows;

	[SerializeField]
	private VerticalLayoutGroup _layout;

	[SerializeField]
	private BonusComponent2D _bonusPrefab;

	[SerializeField]
	private Transform _diffParent;

	private List<BonusComponent2D> _bonusInstances = new List<BonusComponent2D>();

	public void SetData(int diff)
	{
		_statusName.text = NgoEx.StatusLabelFromType(StatusType.Follower, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
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
		int num = 0;
		BonusComponent2D bonusInstance = GetBonusInstance(num);
		num++;
		bonusInstance.SetData(NgoEx.StatusLabelFromType(StatusType.RenzokuHaishinCount, value), SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.RenzokuHaishinCount) + 1);
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.SNSzizenKokutiBonus) != 0)
		{
			BonusComponent2D bonusInstance2 = GetBonusInstance(num);
			num++;
			bonusInstance2.SetData(NgoEx.StatusLabelFromType(StatusType.SNSzizenKokutiBonus, value), 1.2f);
		}
		if (c.Id.StartsWith("Game"))
		{
			BonusComponent2D bonusInstance3 = GetBonusInstance(num);
			num++;
			bonusInstance3.SetData(NgoEx.StatusLabelFromType(StatusType.GameCountBonus, value), (float)SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.GameCountBonus) / 2f + 1f);
		}
		if (c.Id.StartsWith("Otakutalk") || c.Id.StartsWith("AnimeTalk"))
		{
			BonusComponent2D bonusInstance4 = GetBonusInstance(num);
			num++;
			bonusInstance4.SetData(NgoEx.StatusLabelFromType(StatusType.CinePhillCountBonus, value), (float)SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.CinePhillCountBonus) / 2f + 1f);
		}
		if (c.Id.StartsWith("Yamihaishin") || c.Id.StartsWith("Darkness"))
		{
			BonusComponent2D bonusInstance5 = GetBonusInstance(num);
			num++;
			bonusInstance5.SetData(NgoEx.StatusLabelFromType(StatusType.OkusuriedCounter, value), (float)SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.OkusuriedCounter) / 2f + 1f);
		}
		if (c.Id.StartsWith("ASMR") || c.Id.StartsWith("Hnahaisin"))
		{
			BonusComponent2D bonusInstance6 = GetBonusInstance(num);
			num++;
			bonusInstance6.SetData(NgoEx.StatusLabelFromType(StatusType.OirokeCounter, value), (float)SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.OirokeCounter) / 2f + 1f);
		}
		BonusComponent2D bonusInstance7 = GetBonusInstance(num);
		num++;
		bonusInstance7.SetData(NgoEx.StatusLabelFromType(StatusType.DougaTVShabekuriCountBonus, value), (float)SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DougaTVShabekuriCountBonus) / 10f + 1f);
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Harumagedo) > 0)
		{
			BonusComponent2D bonusInstance8 = GetBonusInstance(num);
			num++;
			bonusInstance8.SetData(NgoEx.StatusLabelFromType(StatusType.Harumagedo, value), (float)(-SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Harumagedo)) / 100f + 1f);
		}
		_layout.SetLayoutVertical();
	}

	private BonusComponent2D GetBonusInstance(int bonusNum)
	{
		BonusComponent2D bonusComponent2D = null;
		if (bonusNum < _bonusInstances.Count)
		{
			bonusComponent2D = _bonusInstances[bonusNum];
			bonusComponent2D.gameObject.SetActive(value: true);
		}
		else
		{
			bonusComponent2D = Object.Instantiate(_bonusPrefab, _diffParent);
			_bonusInstances.Add(bonusComponent2D);
		}
		return bonusComponent2D;
	}

	private void OnDisable()
	{
		foreach (BonusComponent2D bonusInstance in _bonusInstances)
		{
			bonusInstance.gameObject.SetActive(value: false);
		}
	}
}
