using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class EventManager : SingletonMonoBehaviour<EventManager>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass85_0
	{
		public EventManager _003C_003E4__this;

		public CmdType a;

		public CancellationTokenSource cts;

		public ActionType ac;

		internal bool _003CExecuteActionConfirmed_003Eb__0(GameObject _)
		{
			return _003C_003E4__this.isEventing;
		}

		internal async void _003CExecuteActionConfirmed_003Eb__2(bool _)
		{
			_003C_003E4__this.ApplyStatus(a);
			if (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count > 0)
			{
				SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
				await NgoEvent.DelaySkippable(Constants.MIDDLE);
				SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Result).GetComponent<PoketterView2D>().shootTweetAll(cts);
				await NgoEvent.DelaySkippable(((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count * Constants.SLOW + Constants.MIDDLE);
			}
			SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.TaskManager));
			SingletonMonoBehaviour<StatusManager>.Instance.TimeDelta(NgoEx.CmdFromType(_003C_003E4__this.executingAction).PassingTime);
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) == 0 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) == 2)
			{
				SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tooltip_param);
				await NgoEvent.DelaySkippable(Constants.MIDDLE);
			}
			await SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
			SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
			if (_003C_003E4__this.isThisTurnMidokuMushi)
			{
				_003C_003E4__this.midokumushi++;
				await _003C_003E4__this.MidokuMushiTweet();
				if (_003C_003E4__this.midokumushi >= 5)
				{
					return;
				}
			}
			_003C_003E4__this.isThisTurnMidokuMushi = false;
			if (_003C_003E4__this.nowEnding != EndingType.Ending_Lust)
			{
				await _003C_003E4__this.getHintedChip(ac);
				await _003C_003E4__this.StartEvent();
			}
			SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, Vector2.zero, (CursorMode)0);
			await NgoEvent.DelaySkippable(Constants.FAST);
			_003C_003E4__this.TimePass();
			SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = false;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CCallEnding_003Ed__97 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EventManager _003C_003E4__this;

		private void MoveNext()
		{
			EventManager eventManager = _003C_003E4__this;
			try
			{
				SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
				SingletonMonoBehaviour<CursorManager>.Instance.SetCursorShowHide(show: false);
				Object.Instantiate<GameObject>(eventManager.endingBlue, GameObject.Find("MainPanel").transform);
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
	private struct _003CCallNetaGet_003Ed__101 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EventManager _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			EventManager eventManager = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					eventManager.AddEventQueue<SetJineSeparator>();
					eventManager.AddEventQueue("ChipGet_" + eventManager.gotChipAlpha.alphaType.ToString() + "_" + eventManager.gotChipAlpha.level);
					eventManager.AddEventQueue<ChipGet_Show>();
					UniTask val = eventManager.StartEvent();
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CCallNetaGet_003Ed__101>(ref val2, ref this);
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
	private struct _003CEndEvent_003Ed__77 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EventManager _003C_003E4__this;

		public EventType type;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			EventManager eventManager = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					eventManager.eventsHistory.Add(type.ToString());
					UniTask val = eventManager.EndEvent();
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CEndEvent_003Ed__77>(ref val2, ref this);
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
	private struct _003CEndEvent_003Ed__78 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EventManager _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			EventManager eventManager = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					UniTask val = eventManager.EndEvent();
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CEndEvent_003Ed__78>(ref val2, ref this);
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
	private struct _003CEndEvent_003Ed__80 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EventManager _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			EventManager eventManager = _003C_003E4__this;
			try
			{
				Awaiter val;
				UniTask val2;
				if (num != 0)
				{
					if (num == 1)
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00df;
					}
					eventManager.isEventing = false;
					val2 = UniTask.Delay(1, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CEndEvent_003Ed__80>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val)).GetResult();
				val2 = eventManager.StartEvent();
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CEndEvent_003Ed__80>(ref val, ref this);
					return;
				}
				goto IL_00df;
				IL_00df:
				((Awaiter)(ref val)).GetResult();
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
	private struct _003CExecuteActionConfirmed_003Ed__85 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EventManager _003C_003E4__this;

		public CmdType a;

		public ActionType ac;

		private _003C_003Ec__DisplayClass85_0 _003C_003E8__1;

		public bool isEventCommand;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			EventManager eventManager = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					_003C_003E8__1 = new _003C_003Ec__DisplayClass85_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.a = a;
					_003C_003E8__1.ac = ac;
					if (_003C_003E8__1.a.ToString().StartsWith("Odekake") && eventManager.FirstDate == CmdType.None)
					{
						eventManager.FirstDate = _003C_003E8__1.a;
					}
					SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = true;
					val2 = NgoEvent.DelaySkippable(20);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CExecuteActionConfirmed_003Ed__85>(ref val, ref this);
						return;
					}
					goto IL_0106;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0106;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0165;
				case 2:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0165:
					((Awaiter)(ref val)).GetResult();
					eventManager.isCleaned.Value = false;
					eventManager.executingAction = _003C_003E8__1.a;
					SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(eventManager.Waiting, Vector2.zero, (CursorMode)0);
					SingletonMonoBehaviour<CommandManager>.Instance.disableAllCommands();
					SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
					eventManager.SetShortcutState(isEnable: false);
					SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
					SingletonMonoBehaviour<WindowManager>.Instance.CleanOnCommand(_003C_003E8__1.ac == ActionType.Internet2ch, _003C_003E8__1.ac == ActionType.InternetDeai);
					eventManager.dayActionHistory.Add(_003C_003E8__1.a.ToString());
					eventManager.isThisTurnMidokuMushi = !eventManager.checkTuutiCleaned() && !isEventCommand;
					eventManager.isEventForcePushed();
					SingletonMonoBehaviour<NotificationManager>.Instance.Clean();
					eventManager.AddEvent("Action_" + _003C_003E8__1.a);
					val2 = NgoEvent.DelaySkippable(20);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CExecuteActionConfirmed_003Ed__85>(ref val, ref this);
						return;
					}
					break;
					IL_0106:
					((Awaiter)(ref val)).GetResult();
					val2 = NgoEvent.DelaySkippable(20);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CExecuteActionConfirmed_003Ed__85>(ref val, ref this);
						return;
					}
					goto IL_0165;
				}
				((Awaiter)(ref val)).GetResult();
				_003C_003E8__1.cts = new CancellationTokenSource();
				eventManager.token1 = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(Observable.Take<bool>(Observable.Where<bool>(ObserveExtensions.ObserveEveryValueChanged<GameObject, bool>(((Component)eventManager).gameObject, (Func<GameObject, bool>)((GameObject _) => _003C_003E8__1._003C_003E4__this.isEventing), (FrameCountType)0, false), (Func<bool, bool>)((bool v) => !v)), 1), (Action<bool>)async delegate
				{
					_003C_003E8__1._003C_003E4__this.ApplyStatus(_003C_003E8__1.a);
					if (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count > 0)
					{
						SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
						await NgoEvent.DelaySkippable(Constants.MIDDLE);
						SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Result).GetComponent<PoketterView2D>().shootTweetAll(_003C_003E8__1.cts);
						await NgoEvent.DelaySkippable(((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count * Constants.SLOW + Constants.MIDDLE);
					}
					SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.TaskManager));
					SingletonMonoBehaviour<StatusManager>.Instance.TimeDelta(NgoEx.CmdFromType(_003C_003E8__1._003C_003E4__this.executingAction).PassingTime);
					if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) == 0 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) == 2)
					{
						SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tooltip_param);
						await NgoEvent.DelaySkippable(Constants.MIDDLE);
					}
					await SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
					SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
					if (_003C_003E8__1._003C_003E4__this.isThisTurnMidokuMushi)
					{
						_003C_003E8__1._003C_003E4__this.midokumushi = _003C_003E8__1._003C_003E4__this.midokumushi + 1;
						await _003C_003E8__1._003C_003E4__this.MidokuMushiTweet();
						if (_003C_003E8__1._003C_003E4__this.midokumushi >= 5)
						{
							return;
						}
					}
					_003C_003E8__1._003C_003E4__this.isThisTurnMidokuMushi = false;
					if (_003C_003E8__1._003C_003E4__this.nowEnding != EndingType.Ending_Lust)
					{
						await _003C_003E8__1._003C_003E4__this.getHintedChip(_003C_003E8__1.ac);
						await _003C_003E8__1._003C_003E4__this.StartEvent();
					}
					SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, Vector2.zero, (CursorMode)0);
					await NgoEvent.DelaySkippable(Constants.FAST);
					_003C_003E8__1._003C_003E4__this.TimePass();
					SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = false;
				}), ((Component)eventManager).gameObject);
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
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
	private struct _003CFetchDayEvent_003Ed__91 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EventManager _003C_003E4__this;

		private int _003Cday_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_024c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			EventManager eventManager = _003C_003E4__this;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b5;
				}
				if (num == 1)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0268;
				}
				eventManager.setSticky();
				_003Cday_003E5__2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
				UniTask val2;
				if (!eventManager.isGedatsu || _003Cday_003E5__2 == 30)
				{
					val2 = UniTask.Delay(2700, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CFetchDayEvent_003Ed__91>(ref val, ref this);
						return;
					}
					goto IL_00b5;
				}
				goto end_IL_000e;
				IL_0268:
				((Awaiter)(ref val)).GetResult();
				goto end_IL_000e;
				IL_00b5:
				((Awaiter)(ref val)).GetResult();
				if (eventManager.isTestScene || _003Cday_003E5__2 != 1)
				{
					if (eventManager.nowEnding == EndingType.Ending_Completed && _003Cday_003E5__2 != 1)
					{
						string eventName = $"Ending_Completed_Day{_003Cday_003E5__2}";
						eventManager.AddEvent(eventName);
					}
					else if (SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 6))
					{
						eventManager.AddEvent<Ending_DarkAngel>();
					}
					else if (_003Cday_003E5__2 == 3)
					{
						eventManager.AddEvent<Scenario_Yachin>();
					}
					else if (_003Cday_003E5__2 == 5)
					{
						eventManager.AddEvent<Event_Wishlist_day1>();
					}
					else if (_003Cday_003E5__2 == 6 && eventManager.wishlist != 0)
					{
						switch (eventManager.wishlist)
						{
						case 1:
							eventManager.AddEvent<Event_Wishlist_day2_1>();
							break;
						case 2:
							eventManager.AddEvent<Event_Wishlist_day2_2>();
							break;
						case 3:
							eventManager.AddEvent<Event_Wishlist_day2_3>();
							break;
						default:
							eventManager.AddEvent<Event_Wishlist_day2_4>();
							break;
						}
					}
					else if (_003Cday_003E5__2 == 16 && eventManager.isHearTrauma)
					{
						eventManager.AddEvent<YamiHi_SukiHi_3>();
					}
					else if (_003Cday_003E5__2 == 20)
					{
						eventManager.AddEvent<Event_Day20>();
					}
					else
					{
						if (_003Cday_003E5__2 == 24 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love) >= 80)
						{
							val2 = eventManager.ExecuteActionConfirmed(ActionType.OdekakeZikka, CmdType.OdekakeZikka, isEventCommand: true);
							val = ((UniTask)(ref val2)).GetAwaiter();
							if (!((Awaiter)(ref val)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = val;
								((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CFetchDayEvent_003Ed__91>(ref val, ref this);
								return;
							}
							goto IL_0268;
						}
						if (!eventManager.isHorror && _003Cday_003E5__2 == 27 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower) >= 500000)
						{
							eventManager.isShurokued = true;
							eventManager.AddEvent<Event_MV_shuroku>();
						}
						else if (_003Cday_003E5__2 == 29 && eventManager.isShurokued)
						{
							eventManager.AddEvent<Event_MV_koukai>();
						}
						else if (_003Cday_003E5__2 == 30)
						{
							eventManager.chooseMaturo();
						}
						else if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) >= 80 && !eventManager.isWristCut && eventManager.beforeWristCut)
						{
							eventManager.isWristCut = true;
							eventManager.AddEvent<Status_Stress1_Day>();
						}
						else
						{
							if (!eventManager.isWristCut && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) >= 80 && SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Stress) == 100)
							{
								eventManager.beforeWristCut = true;
							}
							else
							{
								eventManager.beforeWristCut = false;
							}
							if (eventManager.isWristCut && !eventManager.isHakkyo && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) == 100)
							{
								eventManager.isHakkyo = true;
								eventManager.SetShortcutState(isEnable: false);
								SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
								eventManager.AddEvent<Status_Stress2_Day>();
							}
							else
							{
								int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress);
								if (_003Cday_003E5__2 == 25 && eventManager.isHakkyo && status >= 80)
								{
									eventManager.AddEvent<Scenario_horror_day1_day>();
									eventManager.isHorror = true;
								}
								else if (_003Cday_003E5__2 == 26 && eventManager.isHorror)
								{
									eventManager.AddEvent<Scenario_horror_day2_day>();
								}
								else if (_003Cday_003E5__2 == 27 && eventManager.isHorror)
								{
									eventManager.AddEvent<Scenario_horror_day3_day>();
								}
								else if (_003Cday_003E5__2 == 28 && eventManager.isHorror)
								{
									eventManager.AddEvent<Scenario_horror_day4_day>();
								}
								else if (_003Cday_003E5__2 == 29 && eventManager.isHorror)
								{
									eventManager.AddEvent<Scenario_horror_day5_day>();
								}
								else
								{
									int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
									if (status2 >= 10000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 1))
									{
										eventManager.AddEvent<Scenario_Angel1>();
									}
									else if (status2 >= 30000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.PR && al.level == 1))
									{
										eventManager.AddEvent<Scenario_PR1>();
									}
									else if (status2 >= 100000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 2))
									{
										eventManager.AddEvent<Scenario_Angel2>();
									}
									else if (status2 >= 250000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 3))
									{
										eventManager.AddEvent<Scenario_Angel3>();
									}
									else if (status2 >= 500000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 4))
									{
										eventManager.AddEvent<Scenario_Angel4>();
									}
									else if (status2 >= 1000000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 5) && !SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 6) && !eventManager.isHakkyo)
									{
										eventManager.AddEvent<Scenario_Angel5>();
									}
									else if (status2 >= 1000000 && !SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 6) && !SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 5) && eventManager.isHakkyo)
									{
										eventManager.AddEvent<Scenario_Angel6>();
									}
									else if (!eventManager.isTestScene && _003Cday_003E5__2 == 2)
									{
										string eventName2 = $"Scenario_loop1_day{_003Cday_003E5__2 - 1}_day";
										eventManager.AddEvent(eventName2);
									}
									else
									{
										eventManager.FetchDialog();
									}
								}
							}
						}
					}
				}
				end_IL_000e:;
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
	private struct _003CMidokuMushiTweet_003Ed__89 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EventManager _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			EventManager eventManager = _003C_003E4__this;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0085;
				}
				if (num == 1)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01fa;
				}
				UniTask val2;
				if (eventManager.nowEnding == EndingType.Ending_None)
				{
					val2 = NgoEvent.DelaySkippable(Constants.FAST);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CMidokuMushiTweet_003Ed__89>(ref val, ref this);
						return;
					}
					goto IL_0085;
				}
				goto end_IL_000e;
				IL_01fa:
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Result).GetComponent<PoketterView2D>().shootTweetAll();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>(ObserveExtensions.ObserveEveryValueChanged<PoketterManager, int>(SingletonMonoBehaviour<PoketterManager>.Instance, (Func<PoketterManager, int>)((PoketterManager pktr) => ((Collection<TweetData>)(object)pktr._tweetQueue).Count), (FrameCountType)0, false), (Func<int, bool>)((int count) => count == 0)), (Action<int>)async delegate
				{
					await NgoEvent.DelaySkippable(Constants.SLOW);
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
					SingletonMonoBehaviour<WebCamManager>.Instance.GoOut();
					await NgoEvent.DelaySkippable(Constants.MIDDLE);
					AchievementStatsUpdater.UpdateStats("Ending_Jine");
					SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
					await UniTask.Delay(500000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
				}), ((Component)eventManager).gameObject);
				goto end_IL_000e;
				IL_0085:
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 4);
				SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Love, -5);
				switch (SingletonMonoBehaviour<EventManager>.Instance.midokumushi)
				{
				default:
					SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Tweet_Midokumushi001);
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
					goto end_IL_000e;
				case 2:
					SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Tweet_Midokumushi002);
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
					goto end_IL_000e;
				case 3:
					SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Tweet_Midokumushi003);
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
					goto end_IL_000e;
				case 4:
					SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Tweet_Midokumushi004);
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
					goto end_IL_000e;
				case 5:
					SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Tweet_Midokumushi005);
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
					eventManager.ClearEventQueue();
					SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Jine;
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
					val2 = NgoEvent.DelaySkippable(Constants.MIDDLE);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CMidokuMushiTweet_003Ed__89>(ref val, ref this);
						return;
					}
					break;
				}
				goto IL_01fa;
				end_IL_000e:;
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
	private struct _003CStartEvent_003Ed__76 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EventManager _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			EventManager eventManager = _003C_003E4__this;
			try
			{
				if (num == 0)
				{
					goto IL_0047;
				}
				if (eventManager.isEventing)
				{
					Debug.Log((object)"現在他Event実行中です");
				}
				if (eventManager.eventQueue.Count > 0 && !eventManager.isEventing)
				{
					eventManager.isEventing = true;
					goto IL_0047;
				}
				goto end_IL_000e;
				IL_0047:
				try
				{
					Awaiter val2;
					if (num != 0)
					{
						NgoEvent ngoEvent = eventManager.eventQueue.Dequeue();
						Debug.Log((object)("Event開始：" + ngoEvent.eventName));
						UniTask val = ngoEvent.startEvent(eventManager.eventCts);
						val2 = ((UniTask)(ref val)).GetAwaiter();
						if (!((Awaiter)(ref val2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val2;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartEvent_003Ed__76>(ref val2, ref this);
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
				}
				catch (OperationCanceledException)
				{
					Debug.Log((object)"end Event");
				}
				end_IL_000e:;
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
	private struct _003CgetChip_003Ed__102 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EventManager _003C_003E4__this;

		public AlphaType type;

		public int level;

		private void MoveNext()
		{
			EventManager eventManager = _003C_003E4__this;
			try
			{
				eventManager.gotChipAlpha = new AlphaLevel(type, level);
				SingletonMonoBehaviour<NetaManager>.Instance.GetChip(eventManager.gotChipAlpha.alphaType, eventManager.gotChipAlpha.level);
				eventManager.AddEventQueue<SetJineSeparator>();
				eventManager.AddEventQueue("ChipGet_" + eventManager.gotChipAlpha.alphaType.ToString() + "_" + eventManager.gotChipAlpha.level);
				eventManager.AddEventQueue<ChipGet_Show>();
				eventManager.AddEventQueue<BlurWatchingSp>();
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
	private struct _003CgetHintedChip_003Ed__100 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public ActionType a;

		public EventManager _003C_003E4__this;

		private Tuple<ActionType, AlphaLevel> _003CgotAct_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			EventManager eventManager = _003C_003E4__this;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0124;
				}
				ActionType a = this.a;
				_003CgotAct_003E5__2 = eventManager.nextActionHint.Find((Tuple<ActionType, AlphaLevel> hint) => hint.Item1 == a);
				if (_003CgotAct_003E5__2 != null)
				{
					eventManager.Aim.Value = NgoEx.SystemTextFromType(SystemTextType.System_FindNeta, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
					AudioManager.Instance?.PlaySeByType(SoundType.SE_tweet_change_top);
					eventManager.isChipGetting.Value = true;
					eventManager.gotChipAlpha = _003CgotAct_003E5__2.Item2;
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Jine);
					UniTask val2 = UniTask.Delay(Constants.FAST, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CgetHintedChip_003Ed__100>(ref val, ref this);
						return;
					}
					goto IL_0124;
				}
				eventManager.isChipGetting.Value = false;
				goto end_IL_000e;
				IL_0124:
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<NetaManager>.Instance.GetChip(eventManager.gotChipAlpha.alphaType, eventManager.gotChipAlpha.level);
				eventManager.nextActionHint.Remove(_003CgotAct_003E5__2);
				eventManager.CallNetaGet();
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003CgotAct_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CgotAct_003E5__2 = null;
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

	public Button StartTest;

	[SerializeField]
	private Texture2D Waiting;

	[SerializeField]
	public Texture2D handCursor;

	[SerializeField]
	public ChipGetCover chipget;

	[SerializeField]
	public Button cover;

	[SerializeField]
	public Queue<NgoEvent> eventQueue = new Queue<NgoEvent>();

	[SerializeField]
	public List<string> eventsHistory = new List<string>();

	[SerializeField]
	public List<string> dayActionHistory = new List<string>();

	[SerializeField]
	public int loop;

	[SerializeField]
	public bool isTestScene;

	[SerializeField]
	public GameObject endingBlue;

	[SerializeField]
	private GameObject PsycheNikki1;

	[SerializeField]
	private GameObject PsycheNikki2;

	[SerializeField]
	private GameObject PsycheNikki3;

	[SerializeField]
	private GameObject PsycheNikki4;

	[SerializeField]
	private GameObject LoveNikki1;

	[SerializeField]
	private GameObject LoveNikki2;

	[SerializeField]
	private GameObject LoveNikki3;

	[SerializeField]
	private GameObject LoveNikki4;

	public AlphaType alpha;

	public int alphaLevel;

	public BetaType beta;

	public int midokumushi;

	public int psycheCount;

	public string nowEvent = "";

	public EndingType nowEnding = EndingType.Ending_None;

	public List<Tuple<ActionType, AlphaLevel>> nextActionHint = new List<Tuple<ActionType, AlphaLevel>>();

	public string KituneJien = "";

	public bool inNightBonus;

	[SerializeField]
	private bool isEventing;

	[SerializeField]
	public bool isWristCut;

	[SerializeField]
	public bool isHakkyo;

	[SerializeField]
	private bool isJuncho;

	[SerializeField]
	private bool isHearTrauma;

	[SerializeField]
	public CmdType FirstDate = CmdType.None;

	[SerializeField]
	public JineType Trauma = JineType.None;

	[SerializeField]
	public bool isHappaOK;

	[SerializeField]
	public bool isGedatsu;

	[SerializeField]
	public bool isHorror;

	[SerializeField]
	public bool beforeWristCut;

	[SerializeField]
	public int wishlist;

	[SerializeField]
	public int loveDiary;

	[SerializeField]
	public bool isShurokued;

	[SerializeField]
	public int kyuusiCount;

	[SerializeField]
	public bool isOpenGinga;

	[SerializeField]
	public bool is150mil;

	[SerializeField]
	public bool is300mil;

	[SerializeField]
	public bool is500mil;

	[SerializeField]
	private PlatformDiffAnimationMaster platformDiffAnimationMaster;

	public ReactiveProperty<string> Aim = new ReactiveProperty<string>();

	public GameObject obi;

	public AlphaLevel gotChipAlpha;

	private IDisposable CancelToken = (IDisposable)new SingleAssignmentDisposable();

	private IDisposable token1 = (IDisposable)new SingleAssignmentDisposable();

	private IDisposable token2 = (IDisposable)new SingleAssignmentDisposable();

	private IDisposable token3 = (IDisposable)new SingleAssignmentDisposable();

	public CmdType executingAction;

	private ReactiveProperty<bool> isCleaned = new ReactiveProperty<bool>(true);

	public ReactiveProperty<bool> isResulting = new ReactiveProperty<bool>(false);

	public ReactiveProperty<bool> isChipGetting = new ReactiveProperty<bool>(false);

	public bool isThisTurnMidokuMushi;

	private CanvasGroup shortcuts;

	public List<Transform> hakkyoRotationObjectTr = new List<Transform>();

	private CancellationTokenSource eventCtsSource;

	private CancellationToken eventCts;

	public PlatformDiffAnimationMaster PlatformDiffAnimationMaster => platformDiffAnimationMaster;

	protected override void Awake()
	{
		base.Awake();
		eventCtsSource = new CancellationTokenSource();
		eventCts = eventCtsSource.Token;
		if ((Object)(object)GameObject.Find("ShortCutParent") != (Object)null)
		{
			shortcuts = GameObject.Find("ShortCutParent").GetComponent<CanvasGroup>();
		}
		if (isTestScene)
		{
			_ = SteamManager.Initialized;
		}
		if (!isTestScene)
		{
			if (SingletonMonoBehaviour<Settings>.Instance.isBackToLoad)
			{
				Load();
			}
			else
			{
				StartOver();
			}
		}
		else if ((Object)(object)StartTest != (Object)null)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(StartTest), (Action<Unit>)delegate
			{
				AddEvent<Event_Manicure>();
			}), (Component)(object)StartTest);
		}
	}

	private void Start()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		UniTask.Delay(20, false, (PlayerLoopTiming)8, default(CancellationToken), false);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.DistinctUntilChanged<int>(Observable.Where<int>((IObservable<int>)SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex), (Func<int, bool>)((int d) => d < 31))), (Action<int>)async delegate(int day)
		{
			SingletonMonoBehaviour<CursorManager>.Instance.DisableLiveCursorMode();
			if (SingletonMonoBehaviour<Settings>.Instance.isBackToLoad)
			{
				SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = false;
			}
			else
			{
				Save(day);
			}
			AwakePsycheDiary();
			AwakeLoveDiary();
			AddEventQueue<Event_CheckBGM>();
			await FetchDayEvent();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>(Observable.DistinctUntilChanged<int>((IObservable<int>)SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart)), (Func<int, bool>)((int part) => part == 1)), (Action<int>)delegate
		{
			FetchUzagarami();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>(Observable.DistinctUntilChanged<int>((IObservable<int>)SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart)), (Func<int, bool>)((int part) => part == 2)), (Action<int>)delegate
		{
			FetchNightEvent();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.DistinctUntilChanged<int>((IObservable<int>)SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart)), (Action<int>)delegate
		{
			fetchNextActionHint();
		}), ((Component)this).gameObject);
	}

	public async void AddEvent<EventT>() where EventT : NgoEvent, new()
	{
		AddEventQueue<EventT>();
		await UniTask.Delay(1, false, (PlayerLoopTiming)8, default(CancellationToken), false);
		await StartEvent();
	}

	public async void AddEvent(string EventName)
	{
		AddEventQueue(EventName);
		await UniTask.Delay(1, false, (PlayerLoopTiming)8, default(CancellationToken), false);
		await StartEvent();
	}

	public void AddEventQueue<EventT>() where EventT : NgoEvent, new()
	{
		eventQueue.Enqueue(new EventT());
	}

	public void AddEventQueue(string EventName)
	{
		Type type = Type.GetType("ngov3." + EventName);
		if (type == null)
		{
			Debug.Log((object)("No event " + EventName));
			return;
		}
		NgoEvent item = Activator.CreateInstance(type) as NgoEvent;
		eventQueue.Enqueue(item);
	}

	public void StartHaishin(AlphaType alpha, int level, BetaType beta)
	{
		if (!SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value)
		{
			SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = true;
			this.alpha = alpha;
			alphaLevel = level;
			this.beta = beta;
			SingletonMonoBehaviour<NetaManager>.Instance.Haishined(alpha, level);
			if (this.alpha == AlphaType.Hnahaisin && alphaLevel == 5)
			{
				AddEvent<Ending_Av>();
				return;
			}
			if (this.alpha == AlphaType.Yamihaishin && alphaLevel == 5)
			{
				AddEvent<Ending_Yami>();
				return;
			}
			isThisTurnMidokuMushi = !checkTuutiCleaned();
			SingletonMonoBehaviour<NotificationManager>.Instance.Clean();
			isEventForcePushed();
			SetShortcutState(isEnable: false, 0.2f);
			AddEvent<Action_HaishinStart>();
		}
	}

	public void EndHaishin()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		AddEvent<Action_HaishinEnd>();
		SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = false;
		if (isThisTurnMidokuMushi)
		{
			midokumushi++;
			MidokuMushiTweet();
			isThisTurnMidokuMushi = false;
		}
	}

	public void HaishinClean()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		AddEvent<Action_HaishinClean>();
		if (isThisTurnMidokuMushi)
		{
			midokumushi++;
			MidokuMushiTweet();
			isThisTurnMidokuMushi = false;
		}
	}

	[AsyncStateMachine(typeof(_003CStartEvent_003Ed__76))]
	public UniTask StartEvent()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CStartEvent_003Ed__76 _003CStartEvent_003Ed__77 = default(_003CStartEvent_003Ed__76);
		_003CStartEvent_003Ed__77._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CStartEvent_003Ed__77._003C_003E4__this = this;
		_003CStartEvent_003Ed__77._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CStartEvent_003Ed__77._003C_003Et__builder)).Start<_003CStartEvent_003Ed__76>(ref _003CStartEvent_003Ed__77);
		return ((AsyncUniTaskMethodBuilder)(ref _003CStartEvent_003Ed__77._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CEndEvent_003Ed__77))]
	public UniTask EndEvent(EventType type)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CEndEvent_003Ed__77 _003CEndEvent_003Ed__81 = default(_003CEndEvent_003Ed__77);
		_003CEndEvent_003Ed__81._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CEndEvent_003Ed__81._003C_003E4__this = this;
		_003CEndEvent_003Ed__81.type = type;
		_003CEndEvent_003Ed__81._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CEndEvent_003Ed__81._003C_003Et__builder)).Start<_003CEndEvent_003Ed__77>(ref _003CEndEvent_003Ed__81);
		return ((AsyncUniTaskMethodBuilder)(ref _003CEndEvent_003Ed__81._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CEndEvent_003Ed__78))]
	public UniTask EndEvent(string eventName)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CEndEvent_003Ed__78 _003CEndEvent_003Ed__81 = default(_003CEndEvent_003Ed__78);
		_003CEndEvent_003Ed__81._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CEndEvent_003Ed__81._003C_003E4__this = this;
		_003CEndEvent_003Ed__81._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CEndEvent_003Ed__81._003C_003Et__builder)).Start<_003CEndEvent_003Ed__78>(ref _003CEndEvent_003Ed__81);
		return ((AsyncUniTaskMethodBuilder)(ref _003CEndEvent_003Ed__81._003C_003Et__builder)).Task;
	}

	public void setActionHistory(string actionName)
	{
		SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = true;
		dayActionHistory.Add(actionName);
	}

	[AsyncStateMachine(typeof(_003CEndEvent_003Ed__80))]
	public UniTask EndEvent()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CEndEvent_003Ed__80 _003CEndEvent_003Ed__81 = default(_003CEndEvent_003Ed__80);
		_003CEndEvent_003Ed__81._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CEndEvent_003Ed__81._003C_003E4__this = this;
		_003CEndEvent_003Ed__81._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CEndEvent_003Ed__81._003C_003Et__builder)).Start<_003CEndEvent_003Ed__80>(ref _003CEndEvent_003Ed__81);
		return ((AsyncUniTaskMethodBuilder)(ref _003CEndEvent_003Ed__81._003C_003Et__builder)).Task;
	}

	public void ForceEventFlagOff()
	{
		isEventing = false;
	}

	public void ClearEventQueue()
	{
		eventQueue.Clear();
		eventCtsSource.Cancel();
		SingletonMonoBehaviour<JineManager>.Instance.EndOption();
	}

	private bool isEventForcePushed()
	{
		if (isEventing)
		{
			ClearEventQueue();
			isEventing = false;
			return true;
		}
		return false;
	}

	public async void ExecuteAction(ActionType ac, CmdType a)
	{
		if (!SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value)
		{
			if (inNightBonus || ac == ActionType.Haishin || NgoEx.CmdFromType(a).PassingTime + SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) <= 2)
			{
				await ExecuteActionConfirmed(ac, a);
				return;
			}
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.TimePassDialog);
			SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.TimePassDialog).GetComponent<TimePassDialog>().setType(ac, a);
		}
	}

	[AsyncStateMachine(typeof(_003CExecuteActionConfirmed_003Ed__85))]
	public UniTask ExecuteActionConfirmed(ActionType ac, CmdType a, bool isEventCommand = false)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		_003CExecuteActionConfirmed_003Ed__85 _003CExecuteActionConfirmed_003Ed__86 = default(_003CExecuteActionConfirmed_003Ed__85);
		_003CExecuteActionConfirmed_003Ed__86._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CExecuteActionConfirmed_003Ed__86._003C_003E4__this = this;
		_003CExecuteActionConfirmed_003Ed__86.ac = ac;
		_003CExecuteActionConfirmed_003Ed__86.a = a;
		_003CExecuteActionConfirmed_003Ed__86.isEventCommand = isEventCommand;
		_003CExecuteActionConfirmed_003Ed__86._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CExecuteActionConfirmed_003Ed__86._003C_003Et__builder)).Start<_003CExecuteActionConfirmed_003Ed__85>(ref _003CExecuteActionConfirmed_003Ed__86);
		return ((AsyncUniTaskMethodBuilder)(ref _003CExecuteActionConfirmed_003Ed__86._003C_003Et__builder)).Task;
	}

	private bool checkTuutiCleaned()
	{
		return ((Transform)SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent).childCount == 0;
	}

	private bool checkCleaned()
	{
		if (((Transform)SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent).childCount == 0 && ((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count == 0)
		{
			return eventQueue.Count == 0;
		}
		return false;
	}

	public void ApplyStatus(CmdType a)
	{
		SingletonMonoBehaviour<StatusManager>.Instance.CleanDelta();
		CmdMaster.Param cmd = NgoEx.CmdFromType(a);
		SingletonMonoBehaviour<StatusManager>.Instance.AddDiffToDelta(cmd);
	}

	[AsyncStateMachine(typeof(_003CMidokuMushiTweet_003Ed__89))]
	private UniTask MidokuMushiTweet()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CMidokuMushiTweet_003Ed__89 _003CMidokuMushiTweet_003Ed__90 = default(_003CMidokuMushiTweet_003Ed__89);
		_003CMidokuMushiTweet_003Ed__90._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CMidokuMushiTweet_003Ed__90._003C_003E4__this = this;
		_003CMidokuMushiTweet_003Ed__90._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CMidokuMushiTweet_003Ed__90._003C_003Et__builder)).Start<_003CMidokuMushiTweet_003Ed__89>(ref _003CMidokuMushiTweet_003Ed__90);
		return ((AsyncUniTaskMethodBuilder)(ref _003CMidokuMushiTweet_003Ed__90._003C_003Et__builder)).Task;
	}

	private void setSticky()
	{
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart);
		int status3 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		if (status < 5 && status > 0)
		{
			if (status2 < 2)
			{
				Aim.Value = NgoEx.SystemTextFromType(SystemTextType.System_CollectNeta, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
			else
			{
				Aim.Value = NgoEx.SystemTextFromType(SystemTextType.System_NightHint, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
		}
		else if (status <= 10)
		{
			Aim.Value = NgoEx.SystemTextFromType(SystemTextType.Sticky_aim10, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else if (status <= 20)
		{
			Aim.Value = NgoEx.SystemTextFromType(SystemTextType.Sticky_aim20, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else if (status <= 30)
		{
			if (status3 >= 1000000)
			{
				Aim.Value = NgoEx.SystemTextFromType(SystemTextType.Sticky_life, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
			else
			{
				Aim.Value = NgoEx.SystemTextFromType(SystemTextType.Sticky_aim30, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
		}
	}

	[AsyncStateMachine(typeof(_003CFetchDayEvent_003Ed__91))]
	public UniTask FetchDayEvent()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CFetchDayEvent_003Ed__91 _003CFetchDayEvent_003Ed__92 = default(_003CFetchDayEvent_003Ed__91);
		_003CFetchDayEvent_003Ed__92._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CFetchDayEvent_003Ed__92._003C_003E4__this = this;
		_003CFetchDayEvent_003Ed__92._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CFetchDayEvent_003Ed__92._003C_003Et__builder)).Start<_003CFetchDayEvent_003Ed__91>(ref _003CFetchDayEvent_003Ed__92);
		return ((AsyncUniTaskMethodBuilder)(ref _003CFetchDayEvent_003Ed__92._003C_003Et__builder)).Task;
	}

	public void FetchNightEvent()
	{
		if (isHorror || nowEnding == EndingType.Ending_Completed || nowEnding != EndingType.Ending_None)
		{
			return;
		}
		setSticky();
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
		if (!isTestScene && status == 1)
		{
			AddEvent<Scenario_loop1_day0_night>();
		}
		else if (isWristCut && beforeWristCut)
		{
			SetShortcutState(isEnable: false);
			beforeWristCut = false;
			AddEvent<Status_Stress1_Night>();
		}
		else if (isHakkyo && SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Stress) == 100)
		{
			shortcuts.interactable = false;
			shortcuts.blocksRaycasts = false;
			shortcuts.alpha = 0.4f;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusMaxToNumber(StatusType.Stress, 120);
			AddEvent<Status_Stress2_Night>();
		}
		else
		{
			if (isHorror)
			{
				return;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) >= 120)
			{
				AddEvent<Ending_Stressful>();
				return;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) == 0)
			{
				AddEvent<Ending_Healthy>();
				return;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love) == SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Love))
			{
				AddEvent<Ending_Sukisuki>();
				return;
			}
			if ((SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) == SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Yami) && Random.Range(0, 100) == 66) || (SingletonMonoBehaviour<Settings>.Instance.mitaEnd.Distinct().ToList().Count >= 16 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami) == SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Yami) && Random.Range(0, 20) == 6))
			{
				AddEvent<Ending_Megaten>();
				return;
			}
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love) == 0)
			{
				AddEvent<Ending_Ntr>();
				return;
			}
			if (psycheCount >= 5 && !isGedatsu)
			{
				nowEnding = EndingType.Ending_Meta;
				AddEvent<Ending_Meta>();
				return;
			}
			FetchUzagarami();
			if (!isTestScene && status == 2)
			{
				AddEvent<Scenario_loop1_day1_night>();
			}
		}
	}

	private void FetchDialog()
	{
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) >= 80)
		{
			AddEvent<Event_CheckBGM>();
		}
		else
		{
			AddEvent<Event_Uzagarami_Kaiwa>();
		}
	}

	private void FetchUzagarami()
	{
		if (!isGedatsu && nowEnding != EndingType.Ending_Completed)
		{
			if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) >= 80)
			{
				AddEvent<Event_CheckBGM>();
			}
			else
			{
				AddEvent<Event_Uzagarami_Dokuhaku>();
			}
		}
	}

	public bool FetchScenarioEvent()
	{
		if (isHorror)
		{
			return false;
		}
		if (nowEnding == EndingType.Ending_Completed)
		{
			return false;
		}
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		int status3 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love);
		SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Love);
		int status4 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami);
		SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Yami);
		SingletonMonoBehaviour<StatusManager>.Instance.GetMaxStatus(StatusType.Stress);
		if (status == 8 && status2 < 10000)
		{
			AddEvent<Scenario_Yachin_Aseri>();
			return true;
		}
		switch (status)
		{
		case 10:
			if (status2 >= 10000)
			{
				AddEventQueue<NightKaiwaSeparator>();
				AddEvent<Scenario_Achieved_Aim>();
			}
			else
			{
				AddEvent<Ending_Jikka>();
			}
			return true;
		case 14:
			if (status2 >= 100000)
			{
				AddEvent<Scenario_start_follower_high>();
				isJuncho = true;
			}
			else
			{
				AddEvent<Scenario_start_follower_low>();
				isJuncho = false;
			}
			break;
		}
		if (status == 15)
		{
			if (status3 >= 60 && status4 >= 60)
			{
				isHearTrauma = true;
				AddEvent<Event_LongLine>();
				AddEvent<Scenario_trauma_bimyou>();
			}
			else
			{
				isHearTrauma = false;
				AddEvent<Event_Dialog>();
			}
		}
		switch (status)
		{
		case 17:
			if (status2 > 250000)
			{
				isJuncho = true;
			}
			if (status4 >= 60)
			{
				isHappaOK = true;
				if (isJuncho)
				{
					if (status3 >= 60)
					{
						AddEventQueue<NightKaiwaSeparator>();
						AddEvent<Scenario_happa_yamitoraikeike>();
					}
					else
					{
						AddEventQueue<NightKaiwaSeparator>();
						AddEvent<Scenario_happa_yamihateikeike>();
					}
				}
				else if (status3 >= 60)
				{
					AddEventQueue<NightKaiwaSeparator>();
					AddEvent<Scenario_happa_yamitora>();
				}
				else
				{
					AddEventQueue<NightKaiwaSeparator>();
					AddEvent<Scenario_happa_yamihate>();
				}
			}
			else
			{
				isHappaOK = false;
				if (isJuncho)
				{
					if (status3 >= 60)
					{
						AddEventQueue<NightKaiwaSeparator>();
						AddEvent<Scenario_happa_kentoraikeike>();
					}
					else
					{
						AddEventQueue<NightKaiwaSeparator>();
						AddEvent<Scenario_happa_kenhateikeike>();
					}
				}
				else if (status3 >= 60)
				{
					AddEventQueue<NightKaiwaSeparator>();
					AddEvent<Scenario_happa_kentora>();
				}
				else
				{
					AddEventQueue<NightKaiwaSeparator>();
					AddEvent<Scenario_happa_kenhate>();
				}
			}
			return true;
		case 22:
			if (status2 >= 250000)
			{
				AddEventQueue<NightKaiwaSeparator>();
				AddEvent<Scenario_topstreamer_yadakenjoikeike>();
			}
			else if (status4 >= 60)
			{
				AddEventQueue<NightKaiwaSeparator>();
				AddEvent<Scenario_topstreamer_trahappa>();
			}
			else
			{
				AddEventQueue<NightKaiwaSeparator>();
				AddEvent<Scenario_topstreamer_trakenjo>();
			}
			return true;
		case 23:
			setLoveDiaryId(status3);
			break;
		}
		if (status == 23 && status3 >= 80)
		{
			AddEvent<Scenario_jikka>();
			return true;
		}
		if (status == 27)
		{
			if (status2 >= 1000000)
			{
				if (status3 >= 80)
				{
					if (status4 >= 60)
					{
						if (isJuncho)
						{
							AddEventQueue<NightKaiwaSeparator>();
							AddEvent<Scenario_topstreamer_trahappaikeike>();
						}
						else
						{
							AddEventQueue<NightKaiwaSeparator>();
							AddEvent<Scenario_topstreamer_trahappaikeikeatonobi>();
						}
					}
					else if (isJuncho)
					{
						AddEventQueue<NightKaiwaSeparator>();
						AddEvent<Scenario_topstreamer_trakenjoikeike>();
					}
					else
					{
						AddEventQueue<NightKaiwaSeparator>();
						AddEvent<Scenario_topstreamer_trakenjoikeikeatonobi>();
					}
				}
				else if (isJuncho)
				{
					AddEventQueue<NightKaiwaSeparator>();
					AddEvent<Scenario_topstreamer_yadahappakeike>();
				}
				else
				{
					AddEventQueue<NightKaiwaSeparator>();
					AddEvent<Scenario_topstreamer_yadahappakeikeatonobi>();
				}
				return true;
			}
			if (status2 >= 500000)
			{
				AddEventQueue<NightKaiwaSeparator>();
				AddEvent<Scenario_topstreamer_yadahappa>();
				return true;
			}
			AddEventQueue<NightKaiwaSeparator>();
			AddEvent<Scenario_topstreamer_yadakenjo>();
			return true;
		}
		if (!isOpenGinga && SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Kaidan && al.level == 5))
		{
			AddEventQueue<NightKaiwaSeparator>();
			AddEvent<Event_OpenGinga>();
			return true;
		}
		if (status2 >= 1500000 && !is150mil)
		{
			AddEvent<Event_150mil>();
			is150mil = true;
			return true;
		}
		if (status2 >= 3000000 && !is300mil)
		{
			AddEvent<Event_300mil>();
			is300mil = true;
			return true;
		}
		if (status2 >= 5000000 && !is500mil)
		{
			AddEvent<Event_500mil>();
			is500mil = true;
			return true;
		}
		if (status2 >= 9999999)
		{
			AddEvent<Ending_Ideon>();
			return true;
		}
		if (isHorror)
		{
			return false;
		}
		switch (Random.Range(0, 100))
		{
		case 0:
			AddEvent<Event_jinsei0>();
			return true;
		case 1:
			AddEvent<Event_jinsei1>();
			return true;
		case 2:
			AddEvent<Event_jinsei2>();
			return true;
		case 3:
			AddEvent<Event_jinsei3>();
			return true;
		case 4:
			AddEvent<Event_jinsei4>();
			return true;
		case 5:
			if (!SingletonMonoBehaviour<StatusManager>.Instance.isTodayHaishined)
			{
				AddEvent<Event_Nerarenai_Night>();
				return true;
			}
			break;
		}
		return false;
	}

	private void chooseMaturo()
	{
		SetShortcutState(isEnable: false);
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Love);
		int status3 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Yami);
		AddEventQueue<EndingSeparator>();
		if (isGedatsu)
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.DayPart, 3);
			AddEvent<Ending_Kyouso>();
		}
		else if (status >= 1000000 && status3 >= 80 && status2 >= 80 && SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Angel && al.level == 5))
		{
			AddEvent<Ending_Grand>();
		}
		else if (status >= 1000000 && status2 >= 80)
		{
			AddEvent<Ending_Happy>();
		}
		else if (status >= 500000 && status2 >= 80)
		{
			AddEvent<Ending_Normal>();
		}
		else if (status >= 500000)
		{
			AddEvent<Ending_Yarisute>();
		}
		else if (status3 >= 60 && status2 >= 60)
		{
			AddEvent<Ending_Needy>();
		}
		else if (status3 >= 60)
		{
			AddEvent<Ending_Sucide>();
		}
		else if (status2 >= 60)
		{
			AddEvent<Ending_Work>();
		}
		else
		{
			AddEvent<Ending_Bad>();
		}
	}

	[AsyncStateMachine(typeof(_003CCallEnding_003Ed__97))]
	public UniTask CallEnding()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CCallEnding_003Ed__97 _003CCallEnding_003Ed__98 = default(_003CCallEnding_003Ed__97);
		_003CCallEnding_003Ed__98._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CCallEnding_003Ed__98._003C_003E4__this = this;
		_003CCallEnding_003Ed__98._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CCallEnding_003Ed__98._003C_003Et__builder)).Start<_003CCallEnding_003Ed__97>(ref _003CCallEnding_003Ed__98);
		return ((AsyncUniTaskMethodBuilder)(ref _003CCallEnding_003Ed__98._003C_003Et__builder)).Task;
	}

	public void ObiActive(bool onoff)
	{
		obi.SetActive(onoff);
	}

	public void fetchNextActionHint()
	{
		nextActionHint = SingletonMonoBehaviour<NetaManager>.Instance.fetchNextActionHint();
		SingletonMonoBehaviour<CommandManager>.Instance.AddHint(nextActionHint);
	}

	[AsyncStateMachine(typeof(_003CgetHintedChip_003Ed__100))]
	public UniTask getHintedChip(ActionType a)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CgetHintedChip_003Ed__100 _003CgetHintedChip_003Ed__101 = default(_003CgetHintedChip_003Ed__100);
		_003CgetHintedChip_003Ed__101._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CgetHintedChip_003Ed__101._003C_003E4__this = this;
		_003CgetHintedChip_003Ed__101.a = a;
		_003CgetHintedChip_003Ed__101._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CgetHintedChip_003Ed__101._003C_003Et__builder)).Start<_003CgetHintedChip_003Ed__100>(ref _003CgetHintedChip_003Ed__101);
		return ((AsyncUniTaskMethodBuilder)(ref _003CgetHintedChip_003Ed__101._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCallNetaGet_003Ed__101))]
	public UniTask CallNetaGet()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CCallNetaGet_003Ed__101 _003CCallNetaGet_003Ed__102 = default(_003CCallNetaGet_003Ed__101);
		_003CCallNetaGet_003Ed__102._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CCallNetaGet_003Ed__102._003C_003E4__this = this;
		_003CCallNetaGet_003Ed__102._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CCallNetaGet_003Ed__102._003C_003Et__builder)).Start<_003CCallNetaGet_003Ed__101>(ref _003CCallNetaGet_003Ed__102);
		return ((AsyncUniTaskMethodBuilder)(ref _003CCallNetaGet_003Ed__102._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CgetChip_003Ed__102))]
	public UniTask getChip(AlphaType type, int level)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CgetChip_003Ed__102 _003CgetChip_003Ed__103 = default(_003CgetChip_003Ed__102);
		_003CgetChip_003Ed__103._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CgetChip_003Ed__103._003C_003E4__this = this;
		_003CgetChip_003Ed__103.type = type;
		_003CgetChip_003Ed__103.level = level;
		_003CgetChip_003Ed__103._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CgetChip_003Ed__103._003C_003Et__builder)).Start<_003CgetChip_003Ed__102>(ref _003CgetChip_003Ed__103);
		return ((AsyncUniTaskMethodBuilder)(ref _003CgetChip_003Ed__103._003C_003Et__builder)).Task;
	}

	private void AwakePsycheDiary()
	{
		if (psycheCount != 0)
		{
			if (psycheCount >= 1)
			{
				PsycheNikki1.SetActive(true);
			}
			if (psycheCount >= 2)
			{
				PsycheNikki2.SetActive(true);
			}
			if (psycheCount >= 3)
			{
				PsycheNikki3.SetActive(true);
			}
			if (psycheCount >= 4)
			{
				PsycheNikki4.SetActive(true);
			}
		}
	}

	private void setLoveDiaryId(int love)
	{
		if (love < 20)
		{
			loveDiary = 1;
		}
		else if (love < 40)
		{
			loveDiary = 2;
		}
		else if (love < 80)
		{
			loveDiary = 3;
		}
		else
		{
			loveDiary = 4;
		}
	}

	private void AwakeLoveDiary()
	{
		if (loveDiary != 0)
		{
			if (loveDiary == 1)
			{
				LoveNikki4.SetActive(true);
			}
			else if (loveDiary == 2)
			{
				LoveNikki3.SetActive(true);
			}
			else if (loveDiary == 3)
			{
				LoveNikki2.SetActive(true);
			}
			else if (loveDiary == 4)
			{
				LoveNikki1.SetActive(true);
			}
		}
	}

	public void TimePass()
	{
		if (nowEnding != EndingType.Ending_None)
		{
			return;
		}
		if (inNightBonus)
		{
			GameObject.Find("Live").GetComponent<CanvasGroup>().interactable = true;
			GameObject.Find("neru").GetComponent<CanvasGroup>().interactable = true;
			GameObject.Find("Odekake").GetComponent<CanvasGroup>().interactable = true;
		}
		if (executingAction == CmdType.Error)
		{
			SingletonMonoBehaviour<NotificationManager>.Instance.AddTimePassingNotifier();
			return;
		}
		if (!isChipGetting.Value)
		{
			SingletonMonoBehaviour<NotificationManager>.Instance.AddTimePassingNotifier(NgoEx.CmdFromType(executingAction).PassingTime);
			return;
		}
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(Observable.Take<bool>(Observable.Where<bool>((IObservable<bool>)isChipGetting, (Func<bool, bool>)((bool v) => !v)), 1), (Action<bool>)delegate
		{
			SingletonMonoBehaviour<NotificationManager>.Instance.AddTimePassingNotifier(NgoEx.CmdFromType(executingAction).PassingTime);
		}), ((Component)this).gameObject);
	}

	public void Save(int day)
	{
		string text = $"Data{SingletonMonoBehaviour<Settings>.Instance.saveNumber}_Day{day}{SaveRelayer.EXTENTION}";
		SlotData slotData = new SlotData();
		slotData.jineHistory = SingletonMonoBehaviour<JineManager>.Instance.history;
		slotData.poketterHistory = SingletonMonoBehaviour<PoketterManager>.Instance.history;
		slotData.eventsHistory = eventsHistory;
		slotData.dayActionHistory = dayActionHistory;
		slotData.loop = loop;
		slotData.midokumushi = midokumushi;
		slotData.psycheCount = psycheCount;
		slotData.stats = SingletonMonoBehaviour<StatusManager>.Instance.statuses;
		slotData.havingNetas = SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha;
		slotData.usedNetas = SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha;
		slotData.isJuncho = isJuncho;
		slotData.isHearTrauma = isHearTrauma;
		slotData.trauma = Trauma;
		slotData.firstDate = FirstDate;
		slotData.isHappaOK = isHappaOK;
		slotData.isHorror = isHorror;
		slotData.isGedatsu = isGedatsu;
		slotData.wishlist = wishlist;
		slotData.isWristCut = isWristCut;
		slotData.isHakkyo = isHakkyo;
		slotData.beforeWristCut = beforeWristCut;
		slotData.isShurokued = isShurokued;
		slotData.kyuusiCount = kyuusiCount;
		slotData.loveDiary = loveDiary;
		slotData.isOpenGinga = isOpenGinga;
		slotData.is150mil = is150mil;
		slotData.is300mil = is300mil;
		slotData.is500mil = is500mil;
		SaveRelayer.SaveSlotData(text, slotData);
		Debug.Log((object)("スロットデータ：" + text + "のセーブが完了しました。"));
		CleanPassingSaveData(text);
	}

	public void StartOver()
	{
		ClearEventQueue();
		SingletonMonoBehaviour<NotificationManager>.Instance.Clean();
		SingletonMonoBehaviour<JineManager>.Instance.history = new List<JineData>();
		SingletonMonoBehaviour<PoketterManager>.Instance.history = new List<TweetData>();
		eventsHistory = new List<string>();
		dayActionHistory = new List<string>();
		loop = 1;
		midokumushi = 0;
		psycheCount = 0;
		SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha = new List<AlphaLevel>
		{
			new AlphaLevel(AlphaType.Zatudan, 1)
		};
		SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha = new List<AlphaLevel>();
		isJuncho = false;
		isHearTrauma = false;
		Trauma = JineType.None;
		FirstDate = CmdType.None;
		isHappaOK = false;
		isHorror = false;
		isGedatsu = false;
		beforeWristCut = false;
		isWristCut = false;
		isHakkyo = false;
		isShurokued = false;
		isOpenGinga = false;
		wishlist = 0;
		loveDiary = 0;
		kyuusiCount = 0;
		isOpenGinga = false;
		is150mil = false;
		is300mil = false;
		is500mil = false;
		SingletonMonoBehaviour<StatusManager>.Instance.NewStatus();
		fetchNextActionHint();
		if (SingletonMonoBehaviour<Settings>.Instance.saveNumber == 0)
		{
			nowEnding = EndingType.Ending_Completed;
			AddEvent<Ending_Completed>();
		}
	}

	public void Load()
	{
		string nowSaveFile = SingletonMonoBehaviour<Settings>.Instance.nowSaveFile;
		ClearEventQueue();
		SingletonMonoBehaviour<NotificationManager>.Instance.Clean();
		SlotData slotData = SaveRelayer.LoadSlotData(nowSaveFile);
		SingletonMonoBehaviour<JineManager>.Instance.history = slotData.jineHistory;
		SingletonMonoBehaviour<PoketterManager>.Instance.history = slotData.poketterHistory;
		eventsHistory = slotData.eventsHistory;
		dayActionHistory = slotData.dayActionHistory;
		loop = slotData.loop;
		midokumushi = slotData.midokumushi;
		psycheCount = slotData.psycheCount;
		SingletonMonoBehaviour<NetaManager>.Instance.GotAlpha = slotData.havingNetas;
		SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha = slotData.usedNetas;
		isJuncho = slotData.isJuncho;
		isHearTrauma = slotData.isHearTrauma;
		Trauma = slotData.trauma;
		FirstDate = slotData.firstDate;
		isHappaOK = slotData.isHappaOK;
		isHorror = slotData.isHorror;
		isGedatsu = slotData.isGedatsu;
		beforeWristCut = slotData.beforeWristCut;
		isWristCut = slotData.isWristCut;
		isHakkyo = slotData.isHakkyo;
		wishlist = slotData.wishlist;
		loveDiary = slotData.loveDiary;
		isShurokued = slotData.isShurokued;
		kyuusiCount = slotData.kyuusiCount;
		isOpenGinga = slotData.isOpenGinga;
		is150mil = slotData.is150mil;
		is300mil = slotData.is300mil;
		is500mil = slotData.is500mil;
		List<Status> stats = slotData.stats;
		SingletonMonoBehaviour<StatusManager>.Instance.setNewStatusList(stats);
		if (nowSaveFile == "Data0_Day30" + SaveRelayer.EXTENTION)
		{
			AddEvent<Ending_Completed_Day30_afterOut>();
		}
		SingletonMonoBehaviour<WindowManager>.Instance.CleanOnLoad();
		fetchNextActionHint();
		Debug.Log((object)("スロットデータ：" + nowSaveFile + "のロードが完了しました。"));
	}

	private void CleanPassingSaveData(string savefile)
	{
		Match match = Regex.Match(savefile, "(?<=Data)\\d+");
		Match match2 = Regex.Match(savefile, "(?<=Day)\\d+");
		List<string> list = new List<string>();
		for (int i = int.Parse(match2.Value) + 1; i <= 30; i++)
		{
			string text = $"Data{match.Value}_Day{i}{SaveRelayer.EXTENTION}";
			if (!SaveRelayer.IsSlotDataExists(text))
			{
				break;
			}
			list.Add(text);
		}
		SaveRelayer.DeleteDatas(list);
	}

	public void SetShortcutState(bool isEnable, float disabledAlpha = 0.4f)
	{
		if (isEnable)
		{
			shortcuts.interactable = true;
			shortcuts.blocksRaycasts = true;
			shortcuts.alpha = 1f;
			if ((Object)(object)SingletonMonoBehaviour<ControllerGuideManager>.Instance != (Object)null)
			{
				SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = true;
			}
		}
		else
		{
			shortcuts.interactable = false;
			shortcuts.blocksRaycasts = false;
			shortcuts.alpha = disabledAlpha;
			if ((Object)(object)SingletonMonoBehaviour<ControllerGuideManager>.Instance != (Object)null)
			{
				SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = false;
			}
		}
	}

	public void HideShortcut()
	{
		((Component)shortcuts).gameObject.SetActive(false);
		if ((Object)(object)SingletonMonoBehaviour<ControllerGuideManager>.Instance != (Object)null)
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = false;
		}
	}
}
