using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;

namespace ngov3;

public class Ending_Completed_Day23 : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Completed_Day23 _003C_003E4__this;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_024c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0342: Unknown result type (might be due to invalid IL or missing references)
			//IL_0347: Unknown result type (might be due to invalid IL or missing references)
			//IL_034e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_042d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0432: Unknown result type (might be due to invalid IL or missing references)
			//IL_0439: Unknown result type (might be due to invalid IL or missing references)
			//IL_049d: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0527: Unknown result type (might be due to invalid IL or missing references)
			//IL_052c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0533: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_062b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0630: Unknown result type (might be due to invalid IL or missing references)
			//IL_0637: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0718: Unknown result type (might be due to invalid IL or missing references)
			//IL_071d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0724: Unknown result type (might be due to invalid IL or missing references)
			//IL_0789: Unknown result type (might be due to invalid IL or missing references)
			//IL_078e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0795: Unknown result type (might be due to invalid IL or missing references)
			//IL_080a: Unknown result type (might be due to invalid IL or missing references)
			//IL_080f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0816: Unknown result type (might be due to invalid IL or missing references)
			//IL_0889: Unknown result type (might be due to invalid IL or missing references)
			//IL_088e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0895: Unknown result type (might be due to invalid IL or missing references)
			//IL_0944: Unknown result type (might be due to invalid IL or missing references)
			//IL_0949: Unknown result type (might be due to invalid IL or missing references)
			//IL_0950: Unknown result type (might be due to invalid IL or missing references)
			//IL_09d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_09da: Unknown result type (might be due to invalid IL or missing references)
			//IL_09e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a43: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a48: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a4f: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_028f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_0306: Unknown result type (might be due to invalid IL or missing references)
			//IL_030b: Unknown result type (might be due to invalid IL or missing references)
			//IL_030f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0314: Unknown result type (might be due to invalid IL or missing references)
			//IL_0382: Unknown result type (might be due to invalid IL or missing references)
			//IL_038d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0392: Unknown result type (might be due to invalid IL or missing references)
			//IL_0396: Unknown result type (might be due to invalid IL or missing references)
			//IL_039b: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0461: Unknown result type (might be due to invalid IL or missing references)
			//IL_0466: Unknown result type (might be due to invalid IL or missing references)
			//IL_046a: Unknown result type (might be due to invalid IL or missing references)
			//IL_046f: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0571: Unknown result type (might be due to invalid IL or missing references)
			//IL_0576: Unknown result type (might be due to invalid IL or missing references)
			//IL_057a: Unknown result type (might be due to invalid IL or missing references)
			//IL_057f: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_066b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0676: Unknown result type (might be due to invalid IL or missing references)
			//IL_067b: Unknown result type (might be due to invalid IL or missing references)
			//IL_067f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0684: Unknown result type (might be due to invalid IL or missing references)
			//IL_06db: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_074c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0751: Unknown result type (might be due to invalid IL or missing references)
			//IL_0755: Unknown result type (might be due to invalid IL or missing references)
			//IL_075a: Unknown result type (might be due to invalid IL or missing references)
			//IL_07cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_07d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_07d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_07db: Unknown result type (might be due to invalid IL or missing references)
			//IL_084c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0851: Unknown result type (might be due to invalid IL or missing references)
			//IL_0855: Unknown result type (might be due to invalid IL or missing references)
			//IL_085a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0907: Unknown result type (might be due to invalid IL or missing references)
			//IL_090c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0910: Unknown result type (might be due to invalid IL or missing references)
			//IL_0915: Unknown result type (might be due to invalid IL or missing references)
			//IL_0977: Unknown result type (might be due to invalid IL or missing references)
			//IL_0998: Unknown result type (might be due to invalid IL or missing references)
			//IL_099d: Unknown result type (might be due to invalid IL or missing references)
			//IL_09a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_09a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a09: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a0e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a12: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a17: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0328: Unknown result type (might be due to invalid IL or missing references)
			//IL_0329: Unknown result type (might be due to invalid IL or missing references)
			//IL_03af: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0413: Unknown result type (might be due to invalid IL or missing references)
			//IL_0414: Unknown result type (might be due to invalid IL or missing references)
			//IL_0483: Unknown result type (might be due to invalid IL or missing references)
			//IL_0484: Unknown result type (might be due to invalid IL or missing references)
			//IL_050d: Unknown result type (might be due to invalid IL or missing references)
			//IL_050e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0594: Unknown result type (might be due to invalid IL or missing references)
			//IL_0595: Unknown result type (might be due to invalid IL or missing references)
			//IL_0611: Unknown result type (might be due to invalid IL or missing references)
			//IL_0612: Unknown result type (might be due to invalid IL or missing references)
			//IL_0699: Unknown result type (might be due to invalid IL or missing references)
			//IL_069a: Unknown result type (might be due to invalid IL or missing references)
			//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_076f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0770: Unknown result type (might be due to invalid IL or missing references)
			//IL_07f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_07f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_086f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0870: Unknown result type (might be due to invalid IL or missing references)
			//IL_092a: Unknown result type (might be due to invalid IL or missing references)
			//IL_092b: Unknown result type (might be due to invalid IL or missing references)
			//IL_09bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_09bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a2c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a2d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Completed_Day23 ending_Completed_Day = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				CmdType a;
				switch (num)
				{
				default:
					((NgoEvent)ending_Completed_Day).startEvent(cancellationToken);
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_00da;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00da;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0157;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01d5;
				case 3:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_025b;
				case 4:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02e1;
				case 5:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_035d;
				case 6:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_03e4;
				case 7:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0448;
				case 8:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_04b8;
				case 9:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0542;
				case 10:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_05c9;
				case 11:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0646;
				case 12:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_06ce;
				case 13:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0733;
				case 14:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_07a4;
				case 15:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0825;
				case 16:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_08a4;
				case 17:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_095f;
				case 18:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_09f0;
				case 19:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0542:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Tweet_eigyou, CommandResult.success));
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 10);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_05c9;
					IL_00da:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Internet);
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_0157;
					IL_07a4:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.CleanOnCommand();
					SingletonMonoBehaviour<EventManager>.Instance.alpha = AlphaType.Kaidan;
					SingletonMonoBehaviour<EventManager>.Instance.alphaLevel = 1;
					val2 = HaishinFirstAnimation.LoadHaishinFirstAnimation();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 15);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_0825;
					IL_0157:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Keijiban);
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_01d5;
					IL_05c9:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<EventManager>.Instance.ApplyStatus(CmdType.InternetPoketterF1Y12);
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 11);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_0646;
					IL_01d5:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Keijiban).GetComponent<KitsuneView>().Jien();
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_025b;
					IL_09f0:
					((Awaiter)(ref val)).GetResult();
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 19);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					break;
					IL_025b:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Kitsune_jien, CommandResult.success));
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_02e1;
					IL_0646:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
					SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
					val2 = SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 12);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_06ce;
					IL_02e1:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<EventManager>.Instance.ApplyStatus(CmdType.Internet2chY12);
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_035d;
					IL_0825:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Broadcast);
					val2 = UniTask.Delay(6000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 16);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_08a4;
					IL_035d:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
					SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
					val2 = SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_03e4;
					IL_06ce:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<StatusManager>.Instance.timePassing();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 13);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_0733;
					IL_03e4:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<StatusManager>.Instance.timePassing();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 7);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_0448;
					IL_095f:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
					SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.TaskManager));
					val2 = SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 18);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_09f0;
					IL_0448:
					((Awaiter)(ref val)).GetResult();
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 8);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_04b8;
					IL_0733:
					((Awaiter)(ref val)).GetResult();
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 14);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_07a4;
					IL_04b8:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.CleanOnCommand();
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Internet);
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 9);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_0542;
					IL_08a4:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Broadcast);
					a = SingletonMonoBehaviour<CommandManager>.Instance.ChooseCommand(ActionType.Haishin);
					SingletonMonoBehaviour<EventManager>.Instance.ApplyStatus(a);
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
					ending_Completed_Day.tweetFromTip(SingletonMonoBehaviour<EventManager>.Instance.alpha, SingletonMonoBehaviour<EventManager>.Instance.alphaLevel);
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
					val2 = NgoEvent.DelaySkippable(Constants.MIDDLE);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 17);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_095f;
				}
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<EventManager>.Instance.AddEvent<DayPassing>();
				ending_Completed_Day.endEvent();
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
}
