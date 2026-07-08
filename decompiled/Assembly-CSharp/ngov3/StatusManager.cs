using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class StatusManager : SingletonMonoBehaviour<StatusManager>
{
	public List<Status> statuses = new List<Status>();

	public ReactiveProperty<bool> Moved = new ReactiveProperty<bool>(initialValue: false);

	public bool isTodayGangimari;

	public bool isTodayHaishined;

	private IDisposable token1;

	private IDisposable token2;

	protected override void Awake()
	{
		base.Awake();
		if (!SingletonMonoBehaviour<Settings>.Instance.isBackToLoad)
		{
			NewStatus();
		}
	}

	public void NewStatus()
	{
		statuses = new List<Status>
		{
			new Status(StatusType.Tension, 50, 100),
			new Status(StatusType.Follower, 1, 9999999),
			new Status(StatusType.Wadaisei, 100, 500, 100, dispAsPercent: true),
			new Status(StatusType.Stress, 5, 100),
			new Status(StatusType.Love, 40, 100),
			new Status(StatusType.Yami, 15, 100),
			new Status(StatusType.OkusuriedCounter, 0, 60),
			new Status(StatusType.OirokeCounter, 0, 60),
			new Status(StatusType.RenzokuHaishinCount, 0, 30),
			new Status(StatusType.SNSzizenKokutiBonus, 0, 2),
			new Status(StatusType.GameCountBonus, 0, 60),
			new Status(StatusType.CinePhillCountBonus, 0, 60),
			new Status(StatusType.DougaTVShabekuriCountBonus, 0, 90),
			new Status(StatusType.MadeLoveCounter, 0, 30),
			new Status(StatusType.Harumagedo, 0, 100),
			new Status(StatusType.DayIndex, 1, 30),
			new Status(StatusType.DayPart, 2, 3),
			new Status(StatusType.testAlphaLevel, 1, 5)
		};
	}

	public int GetStatus(StatusType type)
	{
		return statuses.Find((Status status) => status.statusType == type).currentValue.Value;
	}

	public int GetMaxStatus(StatusType type)
	{
		return statuses.Find((Status status) => status.statusType == type).maxValue.Value;
	}

	public int GetMinStatus(StatusType type)
	{
		return statuses.Find((Status status) => status.statusType == type).minValue;
	}

	public ReactiveProperty<int> GetStatusObservable(StatusType type)
	{
		return statuses.Find((Status status) => status.statusType == type).currentValue;
	}

	public async UniTask UpdateStatus(StatusType type, int diffValue)
	{
		Status stat = statuses.Find((Status status) => status.statusType == type);
		int moto = stat.currentValue.Value;
		int value = moto + diffValue;
		stat.currentValue.Value = Mathf.Clamp(value, stat.minValue, stat.maxValue.Value);
		if (type == StatusType.Follower || type == StatusType.Yami || type == StatusType.Love || type == StatusType.Stress)
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_renewal);
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.TaskManager);
			await UniTask.Delay(1250);
			StatusSound(type, stat.currentValue.Value - moto);
		}
	}

	public void UpdateStatusToNumber(StatusType type, int to)
	{
		Status status = statuses.Find((Status status2) => status2.statusType == type);
		if (!statuses.Exists((Status status2) => status2.statusType == type))
		{
			Debug.Log($"stat {type} is null");
		}
		status.currentValue.Value = to;
		Mathf.Clamp(status.currentValue.Value, status.minValue, status.maxValue.Value);
	}

	public void UpdateStatusMaxToNumber(StatusType type, int to)
	{
		statuses.Find((Status status) => status.statusType == type).maxValue.Value = to;
	}

	public void LogAllStatus(List<Status> statuses)
	{
		foreach (Status status in statuses)
		{
			_ = status;
		}
	}

	public List<StatusDiff> Diffs(CmdMaster.Param cmd)
	{
		List<StatusDiff> list = new List<StatusDiff>();
		if (cmd == null)
		{
			return list;
		}
		int diff = cmd.StressDelta;
		if (SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 5) && cmd.ParentAct == "Haishin")
		{
			diff = 0;
		}
		list.Add(new StatusDiff(StatusType.Follower, cmd.FollowerDelta));
		list.Add(new StatusDiff(StatusType.Stress, diff));
		list.Add(new StatusDiff(StatusType.Love, cmd.FavorDelta));
		list.Add(new StatusDiff(StatusType.Yami, cmd.YamiDelta));
		list.Add(new StatusDiff(StatusType.OkusuriedCounter, cmd.OkusuriCount));
		list.Add(new StatusDiff(StatusType.OirokeCounter, cmd.OirokeCount));
		list.Add(new StatusDiff(StatusType.SNSzizenKokutiBonus, cmd.SNS));
		list.Add(new StatusDiff(StatusType.GameCountBonus, cmd.GameCount));
		list.Add(new StatusDiff(StatusType.CinePhillCountBonus, cmd.CinePhillCount));
		list.Add(new StatusDiff(StatusType.DougaTVShabekuriCountBonus, cmd.ShabekuriCount));
		list.Add(new StatusDiff(StatusType.Harumagedo, cmd.Harumagedo));
		return list;
	}

	public List<Status> AddDiffToDelta(CmdMaster.Param cmd)
	{
		ApplyDiffsToDelta(Diffs(cmd), cmd);
		return statuses;
	}

	public List<Status> AddDiffToDelta(StatusDiff diff, CmdMaster.Param c)
	{
		Status status = statuses.Find((Status status2) => status2.statusType == diff.statusType);
		if (diff.statusType == StatusType.Follower)
		{
			status.todaysDelta.Value += Mathf.CeilToInt((float)diff.delta * Math.Min(Mathf.Log10(GetStatus(StatusType.Follower)) * 25f, GetStatus(StatusType.Follower) / 100) * ((c.ParentAct == "Haishin") ? ((float)GetStatus(StatusType.RenzokuHaishinCount) + 1f) : 1f) * ((GetStatus(StatusType.SNSzizenKokutiBonus) != 0) ? 1.2f : 1f) * (c.Id.StartsWith("Game") ? ((float)GetStatus(StatusType.GameCountBonus) / 2f + 1f) : 1f) * ((c.Id.StartsWith("Otakutalk") || c.Id.StartsWith("AnimeTalk")) ? ((float)GetStatus(StatusType.CinePhillCountBonus) / 2f + 1f) : 1f) * ((c.Id.StartsWith("Yamihaishin") || c.Id.StartsWith("Darkness")) ? ((float)GetStatus(StatusType.OkusuriedCounter) / 2f + 1f) : 1f) * ((c.Id.StartsWith("ASMR") || c.Id.StartsWith("Hnahaisin")) ? ((float)GetStatus(StatusType.OirokeCounter) / 2f + 1f) : 1f) * ((c.ParentAct == "Haishin") ? ((float)GetStatus(StatusType.DougaTVShabekuriCountBonus) / 10f + 1f) : 1f) * ((c.ParentAct == "Haishin") ? ((float)(-GetStatus(StatusType.Harumagedo)) / 100f + 1f) : 1f));
		}
		else
		{
			status.todaysDelta.Value += diff.delta;
		}
		return statuses;
	}

	public List<Status> ApplyDiffsToDelta(List<StatusDiff> diffs, CmdMaster.Param cmd)
	{
		foreach (StatusDiff diff in diffs)
		{
			AddDiffToDelta(diff, cmd);
		}
		return statuses;
	}

	public async UniTask DeltaToStatus()
	{
		AudioManager.Instance.PlaySeByType(SoundType.SE_renewal);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.TaskManager);
		await UniTask.Delay(1250);
		foreach (Status status in statuses)
		{
			if (status.todaysDelta.Value != 0)
			{
				status.currentValue.Value = Mathf.Clamp(status.currentValue.Value + status.todaysDelta.Value, status.minValue, status.maxValue.Value);
				await StatusSound(status.statusType, status.todaysDelta.Value);
				status.todaysDelta.Value = 0;
			}
		}
	}

	private async UniTask StatusSound(StatusType type, int diff)
	{
		if (type != StatusType.Follower && type != StatusType.Yami && type != StatusType.Love && type != StatusType.Stress)
		{
			return;
		}
		if (type == StatusType.Follower || type == StatusType.Love)
		{
			if (diff > 0)
			{
				AudioManager.Instance?.PlaySeByType(SoundType.SE_status_up);
			}
			else
			{
				AudioManager.Instance?.PlaySeByType(SoundType.SE_status_down);
			}
		}
		else if (diff > 18)
		{
			AudioManager.Instance?.PlaySeByType(SoundType.SE_stress_up_lv3);
		}
		else if (diff > 10)
		{
			AudioManager.Instance?.PlaySeByType(SoundType.SE_stress_up_lv2);
		}
		else if (diff > 0)
		{
			AudioManager.Instance?.PlaySeByType(SoundType.SE_stress_up_lv1);
		}
		else
		{
			AudioManager.Instance?.PlaySeByType(SoundType.SE_stress_down);
		}
		await UniTask.Delay(800);
	}

	public List<Status> CleanDelta()
	{
		foreach (Status status in statuses)
		{
			status.delta.Value = 0;
		}
		return statuses;
	}

	public void setNewStatusList(List<Status> newStats)
	{
		LogAllStatus(statuses);
		if (statuses.Count == 0)
		{
			NewStatus();
		}
		foreach (Status newStat in newStats)
		{
			UpdateStatusToNumber(newStat.statusType, newStat.currentValue.Value);
			UpdateStatusMaxToNumber(newStat.statusType, newStat.maxValue.Value);
		}
	}

	public void TimeDelta(int pass = 1)
	{
		statuses.Find((Status status) => status.statusType == StatusType.DayPart).delta.Value = pass;
	}

	public async UniTask timePassing(int pass = 1)
	{
		Status DayPart = statuses.Find((Status status) => status.statusType == StatusType.DayPart);
		statuses.Find((Status status) => status.statusType == StatusType.DayIndex);
		Moved.Value = false;
		if (DayPart.currentValue.Value + pass > DayPart.maxValue.Value - 1)
		{
			DayPart.currentValue.Value = DayPart.maxValue.Value + 1;
			timePassingToNextMorning();
		}
		else
		{
			DayPart.currentValue.Value += pass;
			await UniTask.Delay(1800);
		}
		DayPart.delta.Value = 0;
	}

	public void timePassingToNextMorning()
	{
		Moved.Value = false;
		isTodayGangimari = false;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0.2f);
		if (!isTodayHaishined)
		{
			UpdateStatusToNumber(StatusType.RenzokuHaishinCount, 0);
		}
		isTodayHaishined = false;
		UpdateStatusToNumber(StatusType.SNSzizenKokutiBonus, 0);
		SingletonMonoBehaviour<EventManager>.Instance.KituneJien = "";
		bool flag = false;
		if (SingletonMonoBehaviour<EventManager>.Instance.kyuusiCount > 0)
		{
			SingletonMonoBehaviour<EventManager>.Instance.kyuusiCount--;
			if (SingletonMonoBehaviour<EventManager>.Instance.kyuusiCount == 0)
			{
				flag = true;
				SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Event_hukkatu>();
			}
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.inNightBonus)
		{
			flag = false;
			SingletonMonoBehaviour<EventManager>.Instance.inNightBonus = false;
		}
		else
		{
			flag = SingletonMonoBehaviour<EventManager>.Instance.FetchScenarioEvent();
		}
		if (flag)
		{
			if (SingletonMonoBehaviour<EventManager>.Instance.eventQueue.Count == 0)
			{
				if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_None && !SingletonMonoBehaviour<EventManager>.Instance.inNightBonus)
				{
					SingletonMonoBehaviour<NotificationManager>.Instance.AddDayPassingNotifier();
				}
				return;
			}
			token1 = (from v in base.gameObject.ObserveEveryValueChanged((GameObject _) => SingletonMonoBehaviour<EventManager>.Instance.eventQueue.Count)
				where v == 0
				select v).Subscribe(delegate
			{
				if (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count == 0)
				{
					token1.Dispose();
					token2.Dispose();
					if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_None && !SingletonMonoBehaviour<EventManager>.Instance.inNightBonus)
					{
						SingletonMonoBehaviour<NotificationManager>.Instance.AddDayPassingNotifier();
					}
				}
			}).AddTo(base.gameObject);
			token2 = (from v in base.gameObject.ObserveEveryValueChanged((GameObject _) => SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count)
				where v == 0
				select v).Subscribe(delegate
			{
				if (SingletonMonoBehaviour<EventManager>.Instance.eventQueue.Count == 0)
				{
					token1.Dispose();
					token2.Dispose();
					if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_None && !SingletonMonoBehaviour<EventManager>.Instance.inNightBonus)
					{
						SingletonMonoBehaviour<NotificationManager>.Instance.AddDayPassingNotifier();
					}
				}
			}).AddTo(base.gameObject);
		}
		else
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEvent<DayPassing>();
		}
	}

	public void WaitCleanAllNotifierToTomorrow()
	{
		if (SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount == 0 && SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count == 0)
		{
			timePassingToNextMorning();
			return;
		}
		token1 = (from v in base.gameObject.ObserveEveryValueChanged((GameObject _) => SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount)
			where v == 0
			select v).Subscribe(delegate
		{
			if (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count == 0)
			{
				token1.Dispose();
				token2.Dispose();
				timePassingToNextMorning();
			}
		}).AddTo(base.gameObject);
		token2 = (from v in base.gameObject.ObserveEveryValueChanged((GameObject _) => SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count)
			where v == 0
			select v).Subscribe(delegate
		{
			if (SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount == 0)
			{
				token1.Dispose();
				token2.Dispose();
				timePassingToNextMorning();
			}
		}).AddTo(base.gameObject);
	}

	public bool isNight()
	{
		return statuses.Find((Status status) => status.statusType == StatusType.DayPart).currentValue.Value == 2;
	}
}
