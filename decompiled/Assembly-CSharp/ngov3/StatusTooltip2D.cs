using System.Collections.Generic;
using NGO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class StatusTooltip2D : Tooltip2D
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
	private VerticalLayoutGroup _layout;

	[SerializeField]
	private StatusDiffComponent2D _diffPrefab;

	[SerializeField]
	private MainStatusDiffComponent2D _diffMainPrefab;

	[SerializeField]
	private FollowerDiffComponent2D _followerDiffPrefab;

	[SerializeField]
	private Transform _diffParent;

	private List<StatusDiffComponent2D> _diffInstances = new List<StatusDiffComponent2D>();

	private List<MainStatusDiffComponent2D> _diffMainInstances = new List<MainStatusDiffComponent2D>();

	private FollowerDiffComponent2D _followerDiffInstance;

	private float _posX;

	private RectTransform _rectTr;

	public void SlidePosition()
	{
		if (_rectTr == null)
		{
			_rectTr = base.gameObject.GetComponent<RectTransform>();
			_posX = _rectTr.position.x;
		}
		if (Input.mousePosition.x > (float)(Screen.width / 2))
		{
			_rectTr.position = new Vector3(_posX * -1f, _rectTr.position.y, _rectTr.position.z);
		}
		else
		{
			_rectTr.position = new Vector3(_posX, _rectTr.position.y, _rectTr.position.z);
		}
	}

	public void SetActionName(ActMaster.Param a, LanguageType l)
	{
		_actionName.text = NgoEx.GetActionName(a, l);
	}

	public void SetCommandName(CmdMaster.Param c, LanguageType l)
	{
		_commandName.text = NgoEx.GetCommandName(c, l);
	}

	public void SetCommandDesc(CmdMaster.Param c, LanguageType l)
	{
		_commandDescription.text = NgoEx.GetCommandDesc(c, l);
	}

	public void SetBonusLine(bool visible, LanguageType lang)
	{
		_BonusLine.gameObject.SetActive(visible);
		if (visible)
		{
			_BonusLine.text = NgoEx.SystemTextFromType(SystemTextType.System_HaishinBonus, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_BonusLine.gameObject.transform.SetAsLastSibling();
		}
	}

	public void SetStatusDiff(List<StatusDiff> diffs)
	{
		int num = 0;
		int count = _diffInstances.Count;
		foreach (StatusDiff diff in diffs)
		{
			if (diff.statusType != StatusType.Follower && diff.statusType != StatusType.Stress && diff.statusType != StatusType.Yami && diff.statusType != StatusType.Love && diff.delta != 0)
			{
				StatusDiffComponent2D statusDiffComponent2D = null;
				if (num < count)
				{
					statusDiffComponent2D = _diffInstances[num];
					statusDiffComponent2D.gameObject.SetActive(value: true);
					statusDiffComponent2D.gameObject.transform.SetAsLastSibling();
				}
				else
				{
					statusDiffComponent2D = Object.Instantiate(_diffPrefab, _diffParent);
					_diffInstances.Add(statusDiffComponent2D);
				}
				statusDiffComponent2D.SetData(diff);
				num++;
			}
		}
	}

	public void SetMainStatusDiff(List<StatusDiff> diffs)
	{
		int num = 0;
		int count = _diffMainInstances.Count;
		foreach (StatusDiff diff in diffs)
		{
			if ((diff.statusType == StatusType.Stress || diff.statusType == StatusType.Yami || diff.statusType == StatusType.Love) && diff.delta != 0)
			{
				MainStatusDiffComponent2D mainStatusDiffComponent2D = null;
				if (num < count)
				{
					mainStatusDiffComponent2D = _diffMainInstances[num];
					mainStatusDiffComponent2D.gameObject.SetActive(value: true);
					mainStatusDiffComponent2D.gameObject.transform.SetAsLastSibling();
				}
				else
				{
					mainStatusDiffComponent2D = Object.Instantiate(_diffMainPrefab, _diffParent);
					_diffMainInstances.Add(mainStatusDiffComponent2D);
				}
				mainStatusDiffComponent2D.SetData(diff);
				num++;
			}
		}
	}

	public void SetFollowerDiff(CmdMaster.Param c)
	{
		FollowerDiffComponent2D followerDiffComponent2D = null;
		if (_followerDiffInstance == null)
		{
			_followerDiffInstance = Object.Instantiate(_followerDiffPrefab, _diffParent);
		}
		else
		{
			_followerDiffInstance.gameObject.SetActive(value: true);
		}
		followerDiffComponent2D = _followerDiffInstance;
		followerDiffComponent2D.SetData(c.FollowerDelta);
		if (c.ParentAct == "Haishin")
		{
			followerDiffComponent2D.SetBonus(c);
		}
	}

	public void SetLayout()
	{
		_layout.SetLayoutVertical();
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

	public void OnHide()
	{
		foreach (StatusDiffComponent2D diffInstance in _diffInstances)
		{
			diffInstance.gameObject.SetActive(value: false);
		}
		foreach (MainStatusDiffComponent2D diffMainInstance in _diffMainInstances)
		{
			diffMainInstance.gameObject.SetActive(value: false);
		}
		if (_followerDiffInstance != null)
		{
			_followerDiffInstance.gameObject.SetActive(value: false);
		}
	}
}
