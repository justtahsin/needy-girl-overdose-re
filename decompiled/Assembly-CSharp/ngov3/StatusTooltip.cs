using System.Collections.Generic;
using NGO;
using TMPro;
using UnityEngine;

namespace ngov3;

public class StatusTooltip : Tooltip
{
	[SerializeField]
	private TMP_Text _actionName;

	[SerializeField]
	private TMP_Text _commandName;

	[SerializeField]
	private TMP_Text _commandDescription;

	[SerializeField]
	private TMP_Text _passingForecast;

	[SerializeField]
	private TMP_Text _BonusLine;

	[SerializeField]
	private TMP_Text _Before;

	[SerializeField]
	private TMP_Text _After;

	[SerializeField]
	private TMP_Text _Arrows;

	[SerializeField]
	private StatusDiffComponent _diffPrefab;

	[SerializeField]
	private MainStatusDiffComponent _diffMainPrefab;

	[SerializeField]
	private FollowerDiffComponent _followerDiffPrefab;

	[SerializeField]
	private Transform _diffParent;

	public void SlideToLeft()
	{
		base.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(640f, 100f, 0f);
	}

	public void SetActionName(ActMaster.Param a, LanguageType l)
	{
		switch (l)
		{
		case LanguageType.JP:
			_actionName.text = a.TitleJp;
			break;
		case LanguageType.CN:
			_actionName.text = a.TitleCn;
			break;
		case LanguageType.KO:
			_actionName.text = a.TitleKo;
			break;
		case LanguageType.TW:
			_actionName.text = a.TitleTw;
			break;
		case LanguageType.VN:
			_actionName.text = a.TitleVn;
			break;
		case LanguageType.FR:
			_actionName.text = a.TitleFr;
			break;
		case LanguageType.IT:
			_actionName.text = a.TitleIt;
			break;
		case LanguageType.GE:
			_actionName.text = a.TitleGe;
			break;
		case LanguageType.SP:
			_actionName.text = a.TitleSp;
			break;
		case LanguageType.RU:
			_actionName.text = a.TitleRu;
			break;
		default:
			_actionName.text = a.TitleEn;
			break;
		}
	}

	public void SetCommandName(CmdMaster.Param c, LanguageType l)
	{
		switch (l)
		{
		case LanguageType.JP:
			_commandName.text = c.LabelJp;
			break;
		case LanguageType.CN:
			_commandName.text = c.LabelCn;
			break;
		case LanguageType.KO:
			_commandName.text = c.LabelKo;
			break;
		case LanguageType.TW:
			_commandName.text = c.LabelTw;
			break;
		case LanguageType.VN:
			_commandName.text = c.LabelVn;
			break;
		case LanguageType.FR:
			_commandName.text = c.LabelFr;
			break;
		case LanguageType.IT:
			_commandName.text = c.LabelIt;
			break;
		case LanguageType.GE:
			_commandName.text = c.LabelGe;
			break;
		case LanguageType.SP:
			_commandName.text = c.LabelSp;
			break;
		case LanguageType.RU:
			_commandName.text = c.LabelRu;
			break;
		default:
			_commandName.text = c.LabelEn;
			break;
		}
	}

	public void SetCommandDesc(CmdMaster.Param c, LanguageType l)
	{
		switch (l)
		{
		case LanguageType.JP:
			_commandDescription.text = c.DescJp;
			break;
		case LanguageType.CN:
			_commandDescription.text = c.DescCn;
			break;
		case LanguageType.KO:
			_commandDescription.text = c.DescKo;
			break;
		case LanguageType.TW:
			_commandDescription.text = c.DescTw;
			break;
		case LanguageType.VN:
			_commandDescription.text = c.DescVn;
			break;
		case LanguageType.FR:
			_commandDescription.text = c.DescFr;
			break;
		case LanguageType.IT:
			_commandDescription.text = c.DescIt;
			break;
		case LanguageType.GE:
			_commandDescription.text = c.DescGe;
			break;
		case LanguageType.SP:
			_commandDescription.text = c.DescSp;
			break;
		case LanguageType.RU:
			_commandDescription.text = c.DescRu;
			break;
		default:
			_commandDescription.text = c.DescEn;
			break;
		}
	}

	public void SetBonusLine(LanguageType lang)
	{
		_BonusLine.gameObject.SetActive(value: true);
		_BonusLine.text = NgoEx.SystemTextFromType(SystemTextType.System_HaishinBonus, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_BonusLine.gameObject.transform.SetAsLastSibling();
	}

	public void SetStatusDiff(List<StatusDiff> diffs)
	{
		foreach (StatusDiff diff in diffs)
		{
			if (diff.statusType != StatusType.Follower && diff.statusType != StatusType.Stress && diff.statusType != StatusType.Yami && diff.statusType != StatusType.Love && diff.delta != 0)
			{
				Object.Instantiate(_diffPrefab, _diffParent).SetData(diff);
			}
		}
	}

	public void SetMainStatusDiff(List<StatusDiff> diffs)
	{
		foreach (StatusDiff diff in diffs)
		{
			if ((diff.statusType == StatusType.Stress || diff.statusType == StatusType.Yami || diff.statusType == StatusType.Love) && diff.delta != 0)
			{
				Object.Instantiate(_diffMainPrefab, _diffParent).SetData(diff);
			}
		}
	}

	public void SetFollowerDiff(CmdMaster.Param c)
	{
		FollowerDiffComponent followerDiffComponent = Object.Instantiate(_followerDiffPrefab, _diffParent);
		followerDiffComponent.SetData(c.FollowerDelta);
		if (c.ParentAct == "Haishin")
		{
			followerDiffComponent.SetBonus(c);
		}
	}

	public void SetPassingTime(int goTime, int komasuu, int beforeTime)
	{
		switch (komasuu)
		{
		case 0:
			_Arrows.text = "";
			break;
		case 1:
			_Arrows.text = "▶";
			break;
		case 2:
			_Arrows.text = "▶▶";
			break;
		default:
			_Arrows.text = "▶▶▶";
			break;
		}
		switch (beforeTime)
		{
		case 0:
			_Before.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart0, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		case 1:
			_Before.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		case 2:
			_Before.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart2, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		default:
			_Before.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart4, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		}
		switch (goTime)
		{
		case 0:
			_After.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart0, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		case 1:
			_After.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		case 2:
			_After.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart2, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		default:
			_After.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart4, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		}
		switch (goTime)
		{
		case 1:
			_passingForecast.text = NgoEx.SystemTextFromType(SystemTextType.System_AttentionDaypart1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		case 2:
			_passingForecast.text = NgoEx.SystemTextFromType(SystemTextType.System_AttentionDaypart2, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		default:
			_passingForecast.text = NgoEx.SystemTextFromType(SystemTextType.System_AttentionNextDay, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		}
	}
}
