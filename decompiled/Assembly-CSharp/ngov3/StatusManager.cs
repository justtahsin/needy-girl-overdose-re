using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class StatusManager : SingletonMonoBehaviour<StatusManager>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public StatusType type;

		internal bool _003CUpdateStatus_003Eb__0(Status status)
		{
			return status.statusType == type;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CDeltaToStatus_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public StatusManager _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private List<Status>.Enumerator _003C_003E7__wrap1;

		private Status _003Cstatus_003E5__3;

		private void MoveNext()
		{
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			StatusManager statusManager = _003C_003E4__this;
			try
			{
				UniTask val;
				Awaiter val2;
				if (num != 0)
				{
					if (num == 1)
					{
						goto IL_00b5;
					}
					AudioManager.Instance.PlaySeByType(SoundType.SE_renewal);
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.TaskManager);
					val = UniTask.Delay(1250, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CDeltaToStatus_003Ed__20>(ref val2, ref this);
						return;
					}
				}
				else
				{
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val2)).GetResult();
				_003C_003E7__wrap1 = statusManager.statuses.GetEnumerator();
				goto IL_00b5;
				IL_00b5:
				try
				{
					if (num != 1)
					{
						goto IL_01cf;
					}
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01ab;
					IL_01ab:
					((Awaiter)(ref val2)).GetResult();
					_003Cstatus_003E5__3.todaysDelta.Value = 0;
					_003Cstatus_003E5__3 = default(Status);
					goto IL_01cf;
					IL_01cf:
					while (_003C_003E7__wrap1.MoveNext())
					{
						_003Cstatus_003E5__3 = _003C_003E7__wrap1.Current;
						if (_003Cstatus_003E5__3.todaysDelta.Value == 0)
						{
							continue;
						}
						_003Cstatus_003E5__3.currentValue.Value = Mathf.Clamp(_003Cstatus_003E5__3.currentValue.Value + _003Cstatus_003E5__3.todaysDelta.Value, _003Cstatus_003E5__3.minValue, _003Cstatus_003E5__3.maxValue.Value);
						val = statusManager.StatusSound(_003Cstatus_003E5__3.statusType, _003Cstatus_003E5__3.todaysDelta.Value);
						val2 = ((UniTask)(ref val)).GetAwaiter();
						if (!((Awaiter)(ref val2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = val2;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CDeltaToStatus_003Ed__20>(ref val2, ref this);
							return;
						}
						goto IL_01ab;
					}
				}
				finally
				{
					if (num < 0)
					{
						((IDisposable)_003C_003E7__wrap1/*cast due to constrained. prefix*/).Dispose();
					}
				}
				_003C_003E7__wrap1 = default(List<Status>.Enumerator);
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStatusSound_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public StatusType type;

		public int diff;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_015d;
				}
				if (type == StatusType.Follower || type == StatusType.Yami || type == StatusType.Love || type == StatusType.Stress)
				{
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
					UniTask val2 = UniTask.Delay(800, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStatusSound_003Ed__21>(ref val, ref this);
						return;
					}
					goto IL_015d;
				}
				goto end_IL_0007;
				IL_015d:
				((Awaiter)(ref val)).GetResult();
				end_IL_0007:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CUpdateStatus_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public StatusType type;

		public StatusManager _003C_003E4__this;

		public int diffValue;

		private _003C_003Ec__DisplayClass12_0 _003C_003E8__1;

		private Status _003Cstat_003E5__2;

		private int _003Cmoto_003E5__3;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			StatusManager statusManager = _003C_003E4__this;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0167;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass12_0();
				_003C_003E8__1.type = type;
				_003Cstat_003E5__2 = statusManager.statuses.Find((Status status) => status.statusType == _003C_003E8__1.type);
				_003Cmoto_003E5__3 = _003Cstat_003E5__2.currentValue.Value;
				int num2 = _003Cmoto_003E5__3 + diffValue;
				_003Cstat_003E5__2.currentValue.Value = Mathf.Clamp(num2, _003Cstat_003E5__2.minValue, _003Cstat_003E5__2.maxValue.Value);
				if (_003C_003E8__1.type == StatusType.Follower || _003C_003E8__1.type == StatusType.Yami || _003C_003E8__1.type == StatusType.Love || _003C_003E8__1.type == StatusType.Stress)
				{
					AudioManager.Instance.PlaySeByType(SoundType.SE_renewal);
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.TaskManager);
					UniTask val2 = UniTask.Delay(1250, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CUpdateStatus_003Ed__12>(ref val, ref this);
						return;
					}
					goto IL_0167;
				}
				goto end_IL_000e;
				IL_0167:
				((Awaiter)(ref val)).GetResult();
				statusManager.StatusSound(_003C_003E8__1.type, _003Cstat_003E5__2.currentValue.Value - _003Cmoto_003E5__3);
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cstat_003E5__2 = default(Status);
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cstat_003E5__2 = default(Status);
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CtimePassing_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public StatusManager _003C_003E4__this;

		public int pass;

		private Status _003CDayPart_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			StatusManager statusManager = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					_003CDayPart_003E5__2 = statusManager.statuses.Find((Status status) => status.statusType == StatusType.DayPart);
					statusManager.statuses.Find((Status status) => status.statusType == StatusType.DayIndex);
					statusManager.Moved.Value = false;
					if (_003CDayPart_003E5__2.currentValue.Value + pass > _003CDayPart_003E5__2.maxValue.Value - 1)
					{
						_003CDayPart_003E5__2.currentValue.Value = _003CDayPart_003E5__2.maxValue.Value + 1;
						statusManager.timePassingToNextMorning();
						goto IL_015c;
					}
					ReactiveProperty<int> currentValue = _003CDayPart_003E5__2.currentValue;
					currentValue.Value += pass;
					UniTask val = UniTask.Delay(1800, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CtimePassing_003Ed__25>(ref val2, ref this);
						return;
					}
				}
				else
				{
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val2)).GetResult();
				goto IL_015c;
				IL_015c:
				_003CDayPart_003E5__2.delta.Value = 0;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003CDayPart_003E5__2 = default(Status);
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CDayPart_003E5__2 = default(Status);
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public List<Status> statuses = new List<Status>();

	public ReactiveProperty<bool> Moved = new ReactiveProperty<bool>(false);

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

	[AsyncStateMachine(typeof(_003CUpdateStatus_003Ed__12))]
	public UniTask UpdateStatus(StatusType type, int diffValue)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CUpdateStatus_003Ed__12 _003CUpdateStatus_003Ed__13 = default(_003CUpdateStatus_003Ed__12);
		_003CUpdateStatus_003Ed__13._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CUpdateStatus_003Ed__13._003C_003E4__this = this;
		_003CUpdateStatus_003Ed__13.type = type;
		_003CUpdateStatus_003Ed__13.diffValue = diffValue;
		_003CUpdateStatus_003Ed__13._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CUpdateStatus_003Ed__13._003C_003Et__builder)).Start<_003CUpdateStatus_003Ed__12>(ref _003CUpdateStatus_003Ed__13);
		return ((AsyncUniTaskMethodBuilder)(ref _003CUpdateStatus_003Ed__13._003C_003Et__builder)).Task;
	}

	public void UpdateStatusToNumber(StatusType type, int to)
	{
		Status status = statuses.Find((Status status2) => status2.statusType == type);
		if (!statuses.Exists((Status status2) => status2.statusType == type))
		{
			Debug.Log((object)$"stat {type} is null");
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
			ReactiveProperty<int> todaysDelta = status.todaysDelta;
			todaysDelta.Value += Mathf.CeilToInt((float)diff.delta * Math.Min(Mathf.Log10((float)GetStatus(StatusType.Follower)) * 25f, GetStatus(StatusType.Follower) / 100) * ((c.ParentAct == "Haishin") ? ((float)GetStatus(StatusType.RenzokuHaishinCount) + 1f) : 1f) * ((GetStatus(StatusType.SNSzizenKokutiBonus) != 0) ? 1.2f : 1f) * (c.Id.StartsWith("Game") ? ((float)GetStatus(StatusType.GameCountBonus) / 2f + 1f) : 1f) * ((c.Id.StartsWith("Otakutalk") || c.Id.StartsWith("AnimeTalk")) ? ((float)GetStatus(StatusType.CinePhillCountBonus) / 2f + 1f) : 1f) * ((c.Id.StartsWith("Yamihaishin") || c.Id.StartsWith("Darkness")) ? ((float)GetStatus(StatusType.OkusuriedCounter) / 2f + 1f) : 1f) * ((c.Id.StartsWith("ASMR") || c.Id.StartsWith("Hnahaisin")) ? ((float)GetStatus(StatusType.OirokeCounter) / 2f + 1f) : 1f) * ((c.ParentAct == "Haishin") ? ((float)GetStatus(StatusType.DougaTVShabekuriCountBonus) / 10f + 1f) : 1f) * ((c.ParentAct == "Haishin") ? ((float)(-GetStatus(StatusType.Harumagedo)) / 100f + 1f) : 1f));
		}
		else
		{
			ReactiveProperty<int> todaysDelta2 = status.todaysDelta;
			todaysDelta2.Value += diff.delta;
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

	[AsyncStateMachine(typeof(_003CDeltaToStatus_003Ed__20))]
	public UniTask DeltaToStatus()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CDeltaToStatus_003Ed__20 _003CDeltaToStatus_003Ed__21 = default(_003CDeltaToStatus_003Ed__20);
		_003CDeltaToStatus_003Ed__21._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CDeltaToStatus_003Ed__21._003C_003E4__this = this;
		_003CDeltaToStatus_003Ed__21._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CDeltaToStatus_003Ed__21._003C_003Et__builder)).Start<_003CDeltaToStatus_003Ed__20>(ref _003CDeltaToStatus_003Ed__21);
		return ((AsyncUniTaskMethodBuilder)(ref _003CDeltaToStatus_003Ed__21._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CStatusSound_003Ed__21))]
	private UniTask StatusSound(StatusType type, int diff)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CStatusSound_003Ed__21 _003CStatusSound_003Ed__22 = default(_003CStatusSound_003Ed__21);
		_003CStatusSound_003Ed__22._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CStatusSound_003Ed__22.type = type;
		_003CStatusSound_003Ed__22.diff = diff;
		_003CStatusSound_003Ed__22._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CStatusSound_003Ed__22._003C_003Et__builder)).Start<_003CStatusSound_003Ed__21>(ref _003CStatusSound_003Ed__22);
		return ((AsyncUniTaskMethodBuilder)(ref _003CStatusSound_003Ed__22._003C_003Et__builder)).Task;
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

	[AsyncStateMachine(typeof(_003CtimePassing_003Ed__25))]
	public UniTask timePassing(int pass = 1)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CtimePassing_003Ed__25 _003CtimePassing_003Ed__26 = default(_003CtimePassing_003Ed__25);
		_003CtimePassing_003Ed__26._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CtimePassing_003Ed__26._003C_003E4__this = this;
		_003CtimePassing_003Ed__26.pass = pass;
		_003CtimePassing_003Ed__26._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CtimePassing_003Ed__26._003C_003Et__builder)).Start<_003CtimePassing_003Ed__25>(ref _003CtimePassing_003Ed__26);
		return ((AsyncUniTaskMethodBuilder)(ref _003CtimePassing_003Ed__26._003C_003Et__builder)).Task;
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
			token1 = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>(ObserveExtensions.ObserveEveryValueChanged<GameObject, int>(((Component)this).gameObject, (Func<GameObject, int>)((GameObject _) => SingletonMonoBehaviour<EventManager>.Instance.eventQueue.Count), (FrameCountType)0, false), (Func<int, bool>)((int v) => v == 0)), (Action<int>)delegate
			{
				if (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count == 0)
				{
					token1.Dispose();
					token2.Dispose();
					if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_None && !SingletonMonoBehaviour<EventManager>.Instance.inNightBonus)
					{
						SingletonMonoBehaviour<NotificationManager>.Instance.AddDayPassingNotifier();
					}
				}
			}), ((Component)this).gameObject);
			token2 = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>(ObserveExtensions.ObserveEveryValueChanged<GameObject, int>(((Component)this).gameObject, (Func<GameObject, int>)((GameObject _) => ((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count), (FrameCountType)0, false), (Func<int, bool>)((int v) => v == 0)), (Action<int>)delegate
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
			}), ((Component)this).gameObject);
		}
		else
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEvent<DayPassing>();
		}
	}

	public void WaitCleanAllNotifierToTomorrow()
	{
		if (((Transform)SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent).childCount == 0 && ((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count == 0)
		{
			timePassingToNextMorning();
			return;
		}
		token1 = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>(ObserveExtensions.ObserveEveryValueChanged<GameObject, int>(((Component)this).gameObject, (Func<GameObject, int>)((GameObject _) => ((Transform)SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent).childCount), (FrameCountType)0, false), (Func<int, bool>)((int v) => v == 0)), (Action<int>)delegate
		{
			if (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count == 0)
			{
				token1.Dispose();
				token2.Dispose();
				timePassingToNextMorning();
			}
		}), ((Component)this).gameObject);
		token2 = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>(ObserveExtensions.ObserveEveryValueChanged<GameObject, int>(((Component)this).gameObject, (Func<GameObject, int>)((GameObject _) => ((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count), (FrameCountType)0, false), (Func<int, bool>)((int v) => v == 0)), (Action<int>)delegate
		{
			if (((Transform)SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent).childCount == 0)
			{
				token1.Dispose();
				token2.Dispose();
				timePassingToNextMorning();
			}
		}), ((Component)this).gameObject);
	}

	public bool isNight()
	{
		return statuses.Find((Status status) => status.statusType == StatusType.DayPart).currentValue.Value == 2;
	}
}
