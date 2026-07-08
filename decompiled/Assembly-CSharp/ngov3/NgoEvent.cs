using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using Rewired;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ngov3;

public class NgoEvent
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public CancellationTokenSource cts;

		internal void _003CGoOut_003Eb__0(PointerEventData _)
		{
			cts.Cancel();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public int firstValue;

		public IWindow ame;

		public Action eventAfter;

		internal bool _003CNadeNade_003Eb__0(int v)
		{
			return v == firstValue + 1;
		}

		internal bool _003CNadeNade_003Eb__2(int v)
		{
			return v >= firstValue + 3;
		}

		internal void _003CNadeNade_003Eb__3(int _)
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_nadenade_2);
			SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
			ame.Closeable();
			eventAfter();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CBackFromOdekake_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					switch (Random.Range(0, 5))
					{
					case 0:
						break;
					case 1:
						goto IL_00b8;
					case 2:
						goto IL_0124;
					case 3:
						goto IL_0190;
					default:
						goto IL_01f9;
					}
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.HangOut_LINE002);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CBackFromOdekake_003Ed__21>(ref val, ref this);
						return;
					}
					goto IL_00ac;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00ac;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0118;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0184;
				case 3:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01f0;
				case 4:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0259;
				case 5:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_01f9:
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.HangOut_LINE001);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CBackFromOdekake_003Ed__21>(ref val, ref this);
						return;
					}
					goto IL_0259;
					IL_0260:
					val2 = DelaySkippable(Constants.MIDDLE);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CBackFromOdekake_003Ed__21>(ref val, ref this);
						return;
					}
					break;
					IL_0259:
					((Awaiter)(ref val)).GetResult();
					goto IL_0260;
					IL_0190:
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.HangOut_LINE005);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CBackFromOdekake_003Ed__21>(ref val, ref this);
						return;
					}
					goto IL_01f0;
					IL_0118:
					((Awaiter)(ref val)).GetResult();
					goto IL_0260;
					IL_01f0:
					((Awaiter)(ref val)).GetResult();
					goto IL_0260;
					IL_0124:
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.HangOut_LINE004);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CBackFromOdekake_003Ed__21>(ref val, ref this);
						return;
					}
					goto IL_0184;
					IL_00ac:
					((Awaiter)(ref val)).GetResult();
					goto IL_0260;
					IL_0184:
					((Awaiter)(ref val)).GetResult();
					goto IL_0260;
					IL_00b8:
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.HangOut_LINE003);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CBackFromOdekake_003Ed__21>(ref val, ref this);
						return;
					}
					goto IL_0118;
				}
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
	private struct _003CDelaySkippable_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public int delay_ms;

		private CancellationTokenSource _003Ccts_003E5__2;

		private Awaiter<int> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				Awaiter<int> val;
				if (num != 0)
				{
					_003Ccts_003E5__2 = new CancellationTokenSource();
					val = UniTask.WhenAny((UniTask[])(object)new UniTask[2]
					{
						UniTask.Delay(delay_ms, false, (PlayerLoopTiming)8, _003Ccts_003E5__2.Token, false),
						UniTask.WaitUntil((Func<bool>)(() => Input.GetMouseButtonDown(0) || Player.GetButtonDown("Click")), (PlayerLoopTiming)8, _003Ccts_003E5__2.Token, false)
					}).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<int>, _003CDelaySkippable_003Ed__14>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<int>);
					num = (_003C_003E1__state = -1);
				}
				val.GetResult();
				_003Ccts_003E5__2.Cancel();
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Ccts_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Ccts_003E5__2 = null;
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
	private struct _003CGoOut_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		private _003C_003Ec__DisplayClass20_0 _003C_003E8__1;

		public NgoEvent _003C_003E4__this;

		private AppType _003CTrainTime_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Unknown result type (might be due to invalid IL or missing references)
			//IL_0258: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			NgoEvent ngoEvent = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					_003C_003E8__1 = new _003C_003Ec__DisplayClass20_0();
					SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
					AudioManager.Instance.PlaySeByType(SoundType.SE_Odekake_zazaza);
					SingletonMonoBehaviour<WebCamManager>.Instance.GoOut();
					val2 = DelaySkippable(2000);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGoOut_003Ed__20>(ref val, ref this);
						return;
					}
					goto IL_00a9;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00a9;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0175;
				case 2:
					break;
					IL_0175:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(_003CTrainTime_003E5__2);
					goto end_IL_000e;
					IL_00a9:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.GoOut);
					_003CTrainTime_003E5__2 = AppType.Train;
					if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ginga)
					{
						_003CTrainTime_003E5__2 = AppType.Train_Ginga;
						SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(_003CTrainTime_003E5__2).Uncloseable();
						AudioManager.Instance.PlayBgmByType(SoundType.BGM_Train);
						val2 = UniTask.Delay(13000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGoOut_003Ed__20>(ref val, ref this);
							return;
						}
						goto IL_0175;
					}
					switch (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart))
					{
					case 0:
						_003CTrainTime_003E5__2 = AppType.Train;
						break;
					case 1:
						_003CTrainTime_003E5__2 = AppType.Train_twilight;
						break;
					default:
						_003CTrainTime_003E5__2 = AppType.Train_night;
						break;
					}
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(_003CTrainTime_003E5__2);
					_003C_003E8__1.cts = new CancellationTokenSource();
					ngoEvent.ClickableAllScreen(onoff: true);
					DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(ObservableTriggerExtensions.OnPointerDownAsObservable((UIBehaviour)(object)SingletonMonoBehaviour<EventManager>.Instance.cover), (Action<PointerEventData>)delegate
					{
						_003C_003E8__1.cts.Cancel();
					}), (ICollection<IDisposable>)ngoEvent.compositeDisposable);
					break;
				}
				try
				{
					if (num != 2)
					{
						AudioManager.Instance.PlayBgmByType(SoundType.BGM_Train);
						val2 = UniTask.Delay(13000, false, (PlayerLoopTiming)8, _003C_003E8__1.cts.Token, false);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGoOut_003Ed__20>(ref val, ref this);
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
					_003C_003E8__1.cts.Cancel();
					ngoEvent.ClickableAllScreen(onoff: false);
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(_003CTrainTime_003E5__2);
				}
				catch (OperationCanceledException)
				{
					AudioManager.Instance.StopByType(SoundType.BGM_Train);
					ngoEvent.ClickableAllScreen(onoff: false);
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(_003CTrainTime_003E5__2);
				}
				SoundType type = SoundType.BGM_mainloop_kenjo;
				int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
				if (status >= 10000)
				{
					type = SoundType.BGM_mainloop_normal;
				}
				if (status >= 100000)
				{
					type = SoundType.BGM_mainloop_yami;
				}
				if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) >= 11)
				{
					type = SoundType.BGM_mainloop_middle;
				}
				if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) >= 20)
				{
					type = SoundType.BGM_mainloop_shuban;
				}
				if ((Object)(object)AudioManager.Instance != (Object)null && (AudioManager.Instance.PlayingBgm.Value == null || AudioManager.Instance?.PlayingBgm.Value.Sound.Id != type.ToString()))
				{
					AudioManager.Instance?.PlayBgmByType(type, isLoop: true);
				}
				end_IL_000e:;
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
	private struct _003CNadeNade_003Ed__22 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Action eventAfter;

		public bool isActiveAppJine;

		private _003C_003Ec__DisplayClass22_0 _003C_003E8__1;

		public NgoEvent _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			NgoEvent ngoEvent = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass22_0();
					_003C_003E8__1.eventAfter = eventAfter;
					if (isActiveAppJine)
					{
						SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Jine);
					}
					UniTask val = DelaySkippable(Constants.FAST);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CNadeNade_003Ed__22>(ref val2, ref this);
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
				SingletonMonoBehaviour<TooltipManager>.Instance.Show(TooltipType.Tooltip_nadenade);
				_003C_003E8__1.ame = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
				_003C_003E8__1.ame.Uncloseable();
				ReactiveProperty<int> nadeCount = ((Component)SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Webcam).GetComponent<App_Webcam>().AmeHead).GetComponent<Amehead>().NadeCount;
				_003C_003E8__1.firstValue = nadeCount.Value;
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>((IObservable<int>)nadeCount, (Func<int, bool>)((int v) => v == _003C_003E8__1.firstValue + 1)), (Action<int>)delegate
				{
					SingletonMonoBehaviour<TooltipManager>.Instance.Show(TooltipType.Tooltip_more);
				}), (ICollection<IDisposable>)ngoEvent.compositeDisposable);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Take<int>(Observable.Where<int>((IObservable<int>)nadeCount, (Func<int, bool>)((int v) => v >= _003C_003E8__1.firstValue + 3)), 1), (Action<int>)delegate
				{
					AudioManager.Instance.PlaySeByType(SoundType.SE_nadenade_2);
					SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
					_003C_003E8__1.ame.Closeable();
					_003C_003E8__1.eventAfter();
				}), (ICollection<IDisposable>)ngoEvent.compositeDisposable);
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
	private struct _003CstartEvent_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public NgoEvent _003C_003E4__this;

		public CancellationToken cancellationToken;

		private void MoveNext()
		{
			NgoEvent ngoEvent = _003C_003E4__this;
			try
			{
				if (!ngoEvent.isStarted)
				{
					cancellationToken.ThrowIfCancellationRequested();
					SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
					SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
					ngoEvent.isStarted = true;
				}
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
	private struct _003CstartEvent_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public NgoEvent _003C_003E4__this;

		public CancellationToken cancellationToken;

		public bool skipWatchSp;

		private void MoveNext()
		{
			NgoEvent ngoEvent = _003C_003E4__this;
			try
			{
				if (!ngoEvent.isStarted)
				{
					cancellationToken.ThrowIfCancellationRequested();
					SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
					if (!skipWatchSp)
					{
						SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
					}
					ngoEvent.isStarted = true;
				}
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

	public EventType type;

	public string eventName = "";

	private IDisposable token1;

	private IDisposable token2;

	public bool isStarted;

	public CursorMode cursorMode;

	public Vector2 hotSpot = Vector2.zero;

	public CompositeDisposable compositeDisposable = new CompositeDisposable();

	private static Player _player;

	private static Player Player
	{
		get
		{
			if (_player == null)
			{
				_player = ReInput.players.GetPlayer(0);
			}
			return _player;
		}
	}

	protected virtual void Awake()
	{
	}

	public void ObiActive(bool onoff)
	{
		SingletonMonoBehaviour<EventManager>.Instance.ObiActive(onoff);
	}

	[AsyncStateMachine(typeof(_003CDelaySkippable_003Ed__14))]
	public static UniTask DelaySkippable(int delay_ms)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CDelaySkippable_003Ed__14 _003CDelaySkippable_003Ed__15 = default(_003CDelaySkippable_003Ed__14);
		_003CDelaySkippable_003Ed__15._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CDelaySkippable_003Ed__15.delay_ms = delay_ms;
		_003CDelaySkippable_003Ed__15._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CDelaySkippable_003Ed__15._003C_003Et__builder)).Start<_003CDelaySkippable_003Ed__14>(ref _003CDelaySkippable_003Ed__15);
		return ((AsyncUniTaskMethodBuilder)(ref _003CDelaySkippable_003Ed__15._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CstartEvent_003Ed__15))]
	public virtual UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CstartEvent_003Ed__15 _003CstartEvent_003Ed__17 = default(_003CstartEvent_003Ed__15);
		_003CstartEvent_003Ed__17._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartEvent_003Ed__17._003C_003E4__this = this;
		_003CstartEvent_003Ed__17.cancellationToken = cancellationToken;
		_003CstartEvent_003Ed__17._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__17._003C_003Et__builder)).Start<_003CstartEvent_003Ed__15>(ref _003CstartEvent_003Ed__17);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__17._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CstartEvent_003Ed__16))]
	public virtual UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken), bool skipWatchSp = false)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CstartEvent_003Ed__16 _003CstartEvent_003Ed__17 = default(_003CstartEvent_003Ed__16);
		_003CstartEvent_003Ed__17._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartEvent_003Ed__17._003C_003E4__this = this;
		_003CstartEvent_003Ed__17.cancellationToken = cancellationToken;
		_003CstartEvent_003Ed__17.skipWatchSp = skipWatchSp;
		_003CstartEvent_003Ed__17._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__17._003C_003Et__builder)).Start<_003CstartEvent_003Ed__16>(ref _003CstartEvent_003Ed__17);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__17._003C_003Et__builder)).Task;
	}

	public void endEvent()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<JineManager>.Instance.EndOption();
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		if (eventName != "")
		{
			SingletonMonoBehaviour<EventManager>.Instance.eventsHistory.Add(eventName);
		}
		compositeDisposable.Clear();
		SingletonMonoBehaviour<EventManager>.Instance.EndEvent(eventName);
	}

	public void OnDestroy()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<JineManager>.Instance.EndOption();
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		if (eventName != "")
		{
			SingletonMonoBehaviour<EventManager>.Instance.eventsHistory.Add(eventName);
		}
		SingletonMonoBehaviour<EventManager>.Instance.EndEvent(eventName);
	}

	public void ClickableAllScreen(bool onoff)
	{
		((Selectable)SingletonMonoBehaviour<EventManager>.Instance.cover).interactable = onoff;
		((Graphic)((Component)SingletonMonoBehaviour<EventManager>.Instance.cover).gameObject.GetComponent<Text>()).raycastTarget = onoff;
	}

	[AsyncStateMachine(typeof(_003CGoOut_003Ed__20))]
	protected UniTask GoOut()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CGoOut_003Ed__20 _003CGoOut_003Ed__21 = default(_003CGoOut_003Ed__20);
		_003CGoOut_003Ed__21._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CGoOut_003Ed__21._003C_003E4__this = this;
		_003CGoOut_003Ed__21._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CGoOut_003Ed__21._003C_003Et__builder)).Start<_003CGoOut_003Ed__20>(ref _003CGoOut_003Ed__21);
		return ((AsyncUniTaskMethodBuilder)(ref _003CGoOut_003Ed__21._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CBackFromOdekake_003Ed__21))]
	protected UniTask BackFromOdekake()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_003CBackFromOdekake_003Ed__21 _003CBackFromOdekake_003Ed__22 = default(_003CBackFromOdekake_003Ed__21);
		_003CBackFromOdekake_003Ed__22._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CBackFromOdekake_003Ed__22._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CBackFromOdekake_003Ed__22._003C_003Et__builder)).Start<_003CBackFromOdekake_003Ed__21>(ref _003CBackFromOdekake_003Ed__22);
		return ((AsyncUniTaskMethodBuilder)(ref _003CBackFromOdekake_003Ed__22._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNadeNade_003Ed__22))]
	protected UniTask NadeNade(Action eventAfter, bool isActiveAppJine = true)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CNadeNade_003Ed__22 _003CNadeNade_003Ed__23 = default(_003CNadeNade_003Ed__22);
		_003CNadeNade_003Ed__23._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CNadeNade_003Ed__23._003C_003E4__this = this;
		_003CNadeNade_003Ed__23.eventAfter = eventAfter;
		_003CNadeNade_003Ed__23.isActiveAppJine = isActiveAppJine;
		_003CNadeNade_003Ed__23._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CNadeNade_003Ed__23._003C_003Et__builder)).Start<_003CNadeNade_003Ed__22>(ref _003CNadeNade_003Ed__23);
		return ((AsyncUniTaskMethodBuilder)(ref _003CNadeNade_003Ed__23._003C_003Et__builder)).Task;
	}

	protected void tweetFromTip(AlphaType alpha = AlphaType.none, int level = 0)
	{
		if (alpha == AlphaType.Zatudan && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Zatudan1);
		}
		if (alpha == AlphaType.Zatudan && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Zatudan2_1);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Zatudan2_2);
		}
		if (alpha == AlphaType.Zatudan && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Zatudan3);
		}
		if (alpha == AlphaType.Zatudan && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Zatudan4);
		}
		if (alpha == AlphaType.Zatudan && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Zatudan5);
		}
		if (alpha == AlphaType.ASMR && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_ASMR1);
		}
		if (alpha == AlphaType.ASMR && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_ASMR2);
		}
		if (alpha == AlphaType.ASMR && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_ASMR3);
		}
		if (alpha == AlphaType.ASMR && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_ASMR4);
		}
		if (alpha == AlphaType.ASMR && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_ASMR5);
		}
		if (alpha == AlphaType.Kaisetu && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaisetu1);
		}
		if (alpha == AlphaType.Kaisetu && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaisetu2);
		}
		if (alpha == AlphaType.Kaisetu && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaisetu3);
		}
		if (alpha == AlphaType.Kaisetu && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaisetu4);
		}
		if (alpha == AlphaType.Kaisetu && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaisetu5);
		}
		if (alpha == AlphaType.Hnahaisin && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Hnahaisin1_1);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Hnahaisin1_2);
		}
		if (alpha == AlphaType.Hnahaisin && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Hnahaisin2);
		}
		if (alpha == AlphaType.Hnahaisin && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Hnahaisin3);
		}
		if (alpha == AlphaType.Hnahaisin && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Hnahaisin4);
		}
		if (alpha == AlphaType.Yamihaishin && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Yamihaisin1);
		}
		if (alpha == AlphaType.Yamihaishin && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Yamihaisin2);
		}
		if (alpha == AlphaType.Yamihaishin && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Yamihaisin3);
		}
		if (alpha == AlphaType.Yamihaishin && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Yamihaisin4);
		}
		if (alpha == AlphaType.Yamihaishin)
		{
			_ = 5;
		}
		if (alpha == AlphaType.Gamejikkyou && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Gamejikkyou1);
		}
		if (alpha == AlphaType.Gamejikkyou && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Gamejikkyou2);
		}
		if (alpha == AlphaType.Gamejikkyou && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Gamejikkyou3);
		}
		if (alpha == AlphaType.Gamejikkyou && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Gamejikkyou4);
		}
		if (alpha == AlphaType.Gamejikkyou && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Gamejikkyou5);
		}
		if (alpha == AlphaType.Imbouron && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Imbouron1);
		}
		if (alpha == AlphaType.Imbouron && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Imbouron2);
		}
		if (alpha == AlphaType.Imbouron && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Imbouron3);
		}
		if (alpha == AlphaType.Imbouron && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Imbouron4);
		}
		if (alpha == AlphaType.Imbouron && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Imbouron5);
		}
		if (alpha == AlphaType.Kaidan && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaidan1);
		}
		if (alpha == AlphaType.Kaidan && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaidan2);
		}
		if (alpha == AlphaType.Kaidan && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaidan3);
		}
		if (alpha == AlphaType.Kaidan && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaidan4);
		}
		if (alpha == AlphaType.Kaidan && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Kaidan5);
		}
		if (alpha == AlphaType.Taiken && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Taiken1);
		}
		if (alpha == AlphaType.Taiken && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Taiken2);
		}
		if (alpha == AlphaType.Taiken && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Taiken3);
		}
		if (alpha == AlphaType.Taiken && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Taiken4);
		}
		if (alpha == AlphaType.Taiken && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Taiken5);
		}
		if (alpha == AlphaType.PR && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_PR1);
		}
		if (alpha == AlphaType.PR && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_PR2);
		}
		if (alpha == AlphaType.PR && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_PR3);
		}
		if (alpha == AlphaType.PR && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_PR4);
		}
		if (alpha == AlphaType.PR && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_PR5);
		}
		if (alpha == AlphaType.Otakutalk && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Otakutalk1);
		}
		if (alpha == AlphaType.Otakutalk && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Otakutalk2);
		}
		if (alpha == AlphaType.Otakutalk && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Otakutalk3_1);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Otakutalk3_2);
		}
		if (alpha == AlphaType.Otakutalk && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Otakutalk4);
		}
		if (alpha == AlphaType.Otakutalk && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Otakutalk5);
		}
		if (alpha == AlphaType.Darkness && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Darkness1);
		}
		if (alpha == AlphaType.Darkness && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Darkness2);
		}
		if (alpha == AlphaType.Angel && level == 1)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Angel1);
		}
		if (alpha == AlphaType.Angel && level == 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Angel2);
		}
		if (alpha == AlphaType.Angel && level == 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Angel3);
		}
		if (alpha == AlphaType.Angel && level == 4)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Angel4);
		}
		if (alpha == AlphaType.Angel && level == 5)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Angel5);
		}
		if (alpha == AlphaType.Angel && level == 6)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Angel6);
		}
	}
}
