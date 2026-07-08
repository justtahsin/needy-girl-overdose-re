using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class Scenario_horror_day1_day : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Scenario_horror_day1_day _003C_003E4__this;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_025e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Unknown result type (might be due to invalid IL or missing references)
			//IL_028c: Unknown result type (might be due to invalid IL or missing references)
			//IL_028f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Scenario_horror_day1_day CS_0024_003C_003E8__locals3 = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					((NgoEvent)CS_0024_003C_003E8__locals3).startEvent(cancellationToken);
					SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
					SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.TaskManager);
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE001);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_00c0;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c0;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0127;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_018e;
				case 3:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01f0;
				case 4:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0279;
				case 5:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_018e:
					((Awaiter)(ref val)).GetResult();
					val2 = NgoEvent.DelaySkippable(Constants.MIDDLE);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_01f0;
					IL_00c0:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE002);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_0127;
					IL_0279:
					((Awaiter)(ref val)).GetResult();
					val2 = NgoEvent.DelaySkippable(Constants.SLOW * 2);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					break;
					IL_0127:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE003);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_018e;
					IL_01f0:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.EgosaResult);
					val2 = UniTask.Delay(Constants.SLOW * 2, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_0279;
				}
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_KowaiInternet_Day1_Tweet001);
				SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_KowaiInternet_Day1_Tweet002);
				SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_KowaiInternet_Day1_Tweet003);
				SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_KowaiInternet_Day1_Tweet004);
				SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_KowaiInternet_Day1_Tweet005);
				SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Take<int>(Observable.Where<int>(ObserveExtensions.ObserveEveryValueChanged<PoketterManager, int>(SingletonMonoBehaviour<PoketterManager>.Instance, (Func<PoketterManager, int>)((PoketterManager pktr) => ((Collection<TweetData>)(object)pktr._tweetQueue).Count), (FrameCountType)0, false), (Func<int, bool>)((int count) => count == 0)), 1), (Action<int>)async delegate
				{
					await NgoEvent.DelaySkippable(Constants.MIDDLE);
					await NgoEvent.DelaySkippable(Constants.MIDDLE);
					await CS_0024_003C_003E8__locals3.takePill();
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals3.compositeDisposable);
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
	private struct _003CtakePill_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Scenario_horror_day1_day _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_031b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0320: Unknown result type (might be due to invalid IL or missing references)
			//IL_0327: Unknown result type (might be due to invalid IL or missing references)
			//IL_0382: Unknown result type (might be due to invalid IL or missing references)
			//IL_0387: Unknown result type (might be due to invalid IL or missing references)
			//IL_038e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0347: Unknown result type (might be due to invalid IL or missing references)
			//IL_034c: Unknown result type (might be due to invalid IL or missing references)
			//IL_034f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0354: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_029b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_0302: Unknown result type (might be due to invalid IL or missing references)
			//IL_0368: Unknown result type (might be due to invalid IL or missing references)
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Scenario_horror_day1_day CS_0024_003C_003E8__locals2 = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
					SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim(SingletonMonoBehaviour<EventManager>.Instance.PlatformDiffAnimationMaster.GetAnimationNameFromKey(PlatformDiffAnimationKey.DAYPASS));
					AudioManager.Instance.PlaySeByType(SoundType.SE_takepill_lv1);
					val2 = NgoEvent.DelaySkippable(Constants.MIDDLE);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CtakePill_003Ed__2>(ref val, ref this);
						return;
					}
					goto IL_00c4;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c4;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_019d;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0201;
				case 3:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0268;
				case 4:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02cf;
				case 5:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0336;
				case 6:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_039d;
				case 7:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0201:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE004);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CtakePill_003Ed__2>(ref val, ref this);
						return;
					}
					goto IL_0268;
					IL_00c4:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
					SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_KowaiInternet_Day1_Tweet006, new List<KusoRepType>
					{
						KusoRepType.Ending_KowaiInternet_Day1_KusoRep001,
						KusoRepType.Ending_KowaiInternet_Day1_KusoRep002,
						KusoRepType.Ending_KowaiInternet_Day1_KusoRep003,
						KusoRepType.Ending_KowaiInternet_Day1_KusoRep004
					});
					if ((Object)(object)SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter) != (Object)null)
					{
						SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
					}
					val2 = NgoEvent.DelaySkippable(Constants.SLOW * 4);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CtakePill_003Ed__2>(ref val, ref this);
						return;
					}
					goto IL_019d;
					IL_0268:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE006);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CtakePill_003Ed__2>(ref val, ref this);
						return;
					}
					goto IL_02cf;
					IL_039d:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE009);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 7);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CtakePill_003Ed__2>(ref val, ref this);
						return;
					}
					break;
					IL_0336:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE008);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CtakePill_003Ed__2>(ref val, ref this);
						return;
					}
					goto IL_039d;
					IL_019d:
					((Awaiter)(ref val)).GetResult();
					val2 = NgoEvent.DelaySkippable(Constants.SLOW * 4);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CtakePill_003Ed__2>(ref val, ref this);
						return;
					}
					goto IL_0201;
					IL_02cf:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE007);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CtakePill_003Ed__2>(ref val, ref this);
						return;
					}
					goto IL_0336;
				}
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day1_LINE009_pi });
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day1_LINE009_pi)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE010);
					CS_0024_003C_003E8__locals2.eventContinue1();
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals2.compositeDisposable);
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

	[AsyncStateMachine(typeof(_003CtakePill_003Ed__2))]
	private UniTask takePill()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CtakePill_003Ed__2 _003CtakePill_003Ed__3 = default(_003CtakePill_003Ed__2);
		_003CtakePill_003Ed__3._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CtakePill_003Ed__3._003C_003E4__this = this;
		_003CtakePill_003Ed__3._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CtakePill_003Ed__3._003C_003Et__builder)).Start<_003CtakePill_003Ed__2>(ref _003CtakePill_003Ed__3);
		return ((AsyncUniTaskMethodBuilder)(ref _003CtakePill_003Ed__3._003C_003Et__builder)).Task;
	}

	private async void eventContinue1()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day1_LINE011);
		await NgoEvent.DelaySkippable(2000);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim(SingletonMonoBehaviour<EventManager>.Instance.PlatformDiffAnimationMaster.GetAnimationNameFromKey(PlatformDiffAnimationKey.HIPURON));
		AudioManager.Instance.PlaySeByType(SoundType.SE_takepill_lv3);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		float weight = 0f;
		PostEffectManager.Instance.SetShader(EffectType.OD3);
		TweenAwaiter val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => weight), (DOSetter<float>)delegate(float x)
		{
			PostEffectManager.Instance.SetShaderWeight(x);
		}, 0.2f, 1.2f), (Ease)17)));
		if (!((TweenAwaiter)(ref val)).IsCompleted)
		{
			await val;
			TweenAwaiter val2 = default(TweenAwaiter);
			val = val2;
		}
		((TweenAwaiter)(ref val)).GetResult();
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		PostEffectManager.Instance.ResetShaderCalmly();
		SingletonMonoBehaviour<StatusManager>.Instance.timePassing(2);
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Action_HaishinStart>();
		endEvent();
	}
}
