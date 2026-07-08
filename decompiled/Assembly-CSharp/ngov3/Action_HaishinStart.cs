using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ngov3;

public class Action_HaishinStart : NgoEvent
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public CancellationTokenSource cts;

		public Action_HaishinStart _003C_003E4__this;

		internal void _003CstartEvent_003Eb__0(PointerEventData _)
		{
			cts.Cancel();
			_003C_003E4__this.ClickableAllScreen(onoff: false);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Action_HaishinStart _003C_003E4__this;

		public CancellationToken cancellationToken;

		private _003C_003Ec__DisplayClass1_0 _003C_003E8__1;

		private UniTask _003CloadAnimTask_003E5__2;

		private int _003Cseed_003E5__3;

		private Awaiter _003C_003Eu__1;

		private object _003C_003E7__wrap3;

		private int _003C_003E7__wrap4;

		private void MoveNext()
		{
			//IL_07d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_034d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0352: Unknown result type (might be due to invalid IL or missing references)
			//IL_0359: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03da: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_043d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0442: Unknown result type (might be due to invalid IL or missing references)
			//IL_0449: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_050d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0512: Unknown result type (might be due to invalid IL or missing references)
			//IL_0519: Unknown result type (might be due to invalid IL or missing references)
			//IL_0575: Unknown result type (might be due to invalid IL or missing references)
			//IL_057a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0581: Unknown result type (might be due to invalid IL or missing references)
			//IL_05db: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0789: Unknown result type (might be due to invalid IL or missing references)
			//IL_078e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0795: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0755: Unknown result type (might be due to invalid IL or missing references)
			//IL_075a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0399: Unknown result type (might be due to invalid IL or missing references)
			//IL_039e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0401: Unknown result type (might be due to invalid IL or missing references)
			//IL_0406: Unknown result type (might be due to invalid IL or missing references)
			//IL_040a: Unknown result type (might be due to invalid IL or missing references)
			//IL_040f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0469: Unknown result type (might be due to invalid IL or missing references)
			//IL_046e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0472: Unknown result type (might be due to invalid IL or missing references)
			//IL_0477: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04da: Unknown result type (might be due to invalid IL or missing references)
			//IL_04df: Unknown result type (might be due to invalid IL or missing references)
			//IL_0539: Unknown result type (might be due to invalid IL or missing references)
			//IL_053e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0542: Unknown result type (might be due to invalid IL or missing references)
			//IL_0547: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_076f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0770: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0423: Unknown result type (might be due to invalid IL or missing references)
			//IL_0424: Unknown result type (might be due to invalid IL or missing references)
			//IL_048b: Unknown result type (might be due to invalid IL or missing references)
			//IL_048c: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_055b: Unknown result type (might be due to invalid IL or missing references)
			//IL_055c: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0680: Unknown result type (might be due to invalid IL or missing references)
			//IL_0685: Unknown result type (might be due to invalid IL or missing references)
			//IL_068c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0643: Unknown result type (might be due to invalid IL or missing references)
			//IL_0648: Unknown result type (might be due to invalid IL or missing references)
			//IL_064c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0651: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_0311: Unknown result type (might be due to invalid IL or missing references)
			//IL_0316: Unknown result type (might be due to invalid IL or missing references)
			//IL_031a: Unknown result type (might be due to invalid IL or missing references)
			//IL_031f: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0666: Unknown result type (might be due to invalid IL or missing references)
			//IL_0667: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Unknown result type (might be due to invalid IL or missing references)
			//IL_0333: Unknown result type (might be due to invalid IL or missing references)
			//IL_0334: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Action_HaishinStart action_HaishinStart = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					_003C_003E8__1 = new _003C_003Ec__DisplayClass1_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					action_HaishinStart.startEvent(cancellationToken, skipWatchSp: true);
					if (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Yamihaishin)
					{
						SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
						AudioManager.Instance.PlaySeByType(SoundType.SE_takepill_lv1);
						SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim(SingletonMonoBehaviour<EventManager>.Instance.PlatformDiffAnimationMaster.GetAnimationNameFromKey(PlatformDiffAnimationKey.DAYPASS));
						val2 = UniTask.Delay(2200, false, (PlayerLoopTiming)8, default(CancellationToken), false);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
							return;
						}
						goto IL_011c;
					}
					goto IL_0123;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_011c;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02bb;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0368;
				case 3:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_03f0;
				case 4:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0458;
				case 5:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_04c0;
				case 6:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0528;
				case 7:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0590;
				case 8:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_05f6;
				case 9:
				case 10:
				{
					try
					{
						if (num != 9)
						{
							if (num == 10)
							{
								val = _003C_003Eu__1;
								_003C_003Eu__1 = default(Awaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0707;
							}
							AudioManager.Instance.PlayBgmByType(SoundType.BANK_bank);
							val2 = UniTask.Delay(15000, false, (PlayerLoopTiming)8, _003C_003E8__1.cts.Token, false);
							val = ((UniTask)(ref val2)).GetAwaiter();
							if (!((Awaiter)(ref val)).IsCompleted)
							{
								num = (_003C_003E1__state = 9);
								_003C_003Eu__1 = val;
								((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
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
						val = ((UniTask)(ref _003CloadAnimTask_003E5__2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 10);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
							return;
						}
						goto IL_0707;
						IL_0707:
						((Awaiter)(ref val)).GetResult();
						action_HaishinStart.startCast();
					}
					catch (OperationCanceledException ex)
					{
						_003C_003E7__wrap3 = ex;
						_003C_003E7__wrap4 = 1;
					}
					int num2 = _003C_003E7__wrap4;
					if (num2 != 1)
					{
						break;
					}
					_ = (OperationCanceledException)_003C_003E7__wrap3;
					AudioManager.Instance.StopByType(SoundType.BANK_bank);
					val = ((UniTask)(ref _003CloadAnimTask_003E5__2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 11);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_07a4;
				}
				case 11:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_07a4;
					}
					IL_05f6:
					((Awaiter)(ref val)).GetResult();
					action_HaishinStart.startCast();
					goto end_IL_000e;
					IL_0528:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Missingwig_JINE005);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 7);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_0590;
					IL_011c:
					((Awaiter)(ref val)).GetResult();
					goto IL_0123;
					IL_0123:
					SingletonMonoBehaviour<WindowManager>.Instance.CleanOnCommand();
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
					SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Jine);
					SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Poketter);
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.NetaChoose);
					SingletonMonoBehaviour<CommandManager>.Instance.disableAllCommands();
					SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = true;
					SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.Tension).Value = 20;
					_003CloadAnimTask_003E5__2 = HaishinFirstAnimation.LoadHaishinFirstAnimation();
					if (SingletonMonoBehaviour<EventManager>.Instance.alpha != AlphaType.Yamihaishin || SingletonMonoBehaviour<EventManager>.Instance.alphaLevel != 5)
					{
						_003Cseed_003E5__3 = Random.Range(0, 300);
						_003C_003E8__1.cts = new CancellationTokenSource();
						action_HaishinStart.ClickableAllScreen(onoff: true);
						DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(ObservableTriggerExtensions.OnPointerDownAsObservable((UIBehaviour)(object)SingletonMonoBehaviour<EventManager>.Instance.cover), (Action<PointerEventData>)delegate
						{
							_003C_003E8__1.cts.Cancel();
							_003C_003E8__1._003C_003E4__this.ClickableAllScreen(onoff: false);
						}), (ICollection<IDisposable>)action_HaishinStart.compositeDisposable);
						if (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Darkness)
						{
							PostEffectManager.Instance.SetShader(EffectType.Invert);
							PostEffectManager.Instance.SetShaderWeight(1f);
						}
						SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Bank);
						val2 = UniTask.Delay(350, false, (PlayerLoopTiming)8, default(CancellationToken), false);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
							return;
						}
						goto IL_02bb;
					}
					SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Ending_Yami>();
					action_HaishinStart.endEvent();
					goto end_IL_000e;
					IL_0368:
					((Awaiter)(ref val)).GetResult();
					action_HaishinStart.ClickableAllScreen(onoff: false);
					AudioManager.Instance.StopByType(SoundType.BANK_bank);
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Bank);
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Missingwig_JINE001);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_03f0;
					IL_0590:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Jine);
					val = ((UniTask)(ref _003CloadAnimTask_003E5__2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 8);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_05f6;
					IL_07a4:
					((Awaiter)(ref val)).GetResult();
					action_HaishinStart.startCast();
					break;
					IL_03f0:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Missingwig_JINE002);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_0458;
					IL_0458:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Missingwig_JINE003);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_04c0;
					IL_02bb:
					((Awaiter)(ref val)).GetResult();
					if (_003Cseed_003E5__3 == 0 && SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_None && SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Darkness)
					{
						AudioManager.Instance.PlayBgmByType(SoundType.BANK_bank);
						val2 = UniTask.Delay(9000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
							return;
						}
						goto IL_0368;
					}
					_003C_003E7__wrap4 = 0;
					goto case 9;
					IL_04c0:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Missingwig_JINE004);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_0528;
				}
				_003C_003E7__wrap3 = null;
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CloadAnimTask_003E5__2 = default(UniTask);
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CloadAnimTask_003E5__2 = default(UniTask);
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

	protected override void Awake()
	{
		base.Awake();
	}

	[AsyncStateMachine(typeof(_003CstartEvent_003Ed__1))]
	public override UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CstartEvent_003Ed__1 _003CstartEvent_003Ed__2 = default(_003CstartEvent_003Ed__1);
		_003CstartEvent_003Ed__2._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartEvent_003Ed__2._003C_003E4__this = this;
		_003CstartEvent_003Ed__2.cancellationToken = cancellationToken;
		_003CstartEvent_003Ed__2._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__2._003C_003Et__builder)).Start<_003CstartEvent_003Ed__1>(ref _003CstartEvent_003Ed__2);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__2._003C_003Et__builder)).Task;
	}

	private void startCast()
	{
		ClickableAllScreen(onoff: false);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Login);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Bank);
		SoundType soundType = SoundType.BGM_mainloop_kenjo;
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		if (status >= 5000)
		{
			soundType = SoundType.BGM_mainloop_normal;
		}
		if (status >= 10000)
		{
			soundType = SoundType.BGM_mainloop_yami;
		}
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) >= 11)
		{
			soundType = SoundType.BGM_mainloop_middle;
		}
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) >= 20)
		{
			soundType = SoundType.BGM_mainloop_shuban;
		}
		if ((Object)(object)AudioManager.Instance != (Object)null && (AudioManager.Instance.PlayingBgm.Value == null || AudioManager.Instance?.PlayingBgm.Value.Sound.Id != soundType.ToString()))
		{
			AudioManager.Instance.PlayBgmByType(soundType, isLoop: true);
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Darkness)
		{
			PostEffectManager.Instance.ResetShaderCalmly();
		}
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Broadcast);
		SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(AppType.Broadcast);
		SingletonMonoBehaviour<WindowManager>.Instance.UnMovable(AppType.Broadcast);
		endEvent();
	}
}
