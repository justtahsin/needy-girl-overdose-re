using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using UnityEngine;

namespace ngov3;

public static class NgoEx
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		[StructLayout(LayoutKind.Auto)]
		private struct _003C_003CDelayNGO_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass6_0 _003C_003E4__this;

			private Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_006d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0072: Unknown result type (might be due to invalid IL or missing references)
				//IL_0079: Unknown result type (might be due to invalid IL or missing references)
				//IL_001b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0035: Unknown result type (might be due to invalid IL or missing references)
				//IL_003a: Unknown result type (might be due to invalid IL or missing references)
				//IL_003d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0042: Unknown result type (might be due to invalid IL or missing references)
				//IL_0099: Unknown result type (might be due to invalid IL or missing references)
				//IL_0056: Unknown result type (might be due to invalid IL or missing references)
				//IL_0057: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				_003C_003Ec__DisplayClass6_0 _003C_003Ec__DisplayClass6_1 = _003C_003E4__this;
				try
				{
					Awaiter val2;
					if (num != 0)
					{
						SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(_LOADING_CURSOR, Vector2.zero, (CursorMode)0);
						UniTask val = UniTask.Delay(_003C_003Ec__DisplayClass6_1.milliseconds, false, (PlayerLoopTiming)8, _003C_003Ec__DisplayClass6_1.token, false);
						val2 = ((UniTask)(ref val)).GetAwaiter();
						if (!((Awaiter)(ref val2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val2;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003C_003CDelayNGO_003Eb__0_003Ed>(ref val2, ref this);
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
					SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(_DEFAULT_CURSOR, Vector2.zero, (CursorMode)0);
					_IS_DELAYING = false;
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

		public int milliseconds;

		public CancellationToken token;

		[AsyncStateMachine(typeof(_003C_003CDelayNGO_003Eb__0_003Ed))]
		internal UniTask _003CDelayNGO_003Eb__0()
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CDelayNGO_003Eb__0_003Ed _003C_003CDelayNGO_003Eb__0_003Ed2 = default(_003C_003CDelayNGO_003Eb__0_003Ed);
			_003C_003CDelayNGO_003Eb__0_003Ed2._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
			_003C_003CDelayNGO_003Eb__0_003Ed2._003C_003E4__this = this;
			_003C_003CDelayNGO_003Eb__0_003Ed2._003C_003E1__state = -1;
			((AsyncUniTaskMethodBuilder)(ref _003C_003CDelayNGO_003Eb__0_003Ed2._003C_003Et__builder)).Start<_003C_003CDelayNGO_003Eb__0_003Ed>(ref _003C_003CDelayNGO_003Eb__0_003Ed2);
			return ((AsyncUniTaskMethodBuilder)(ref _003C_003CDelayNGO_003Eb__0_003Ed2._003C_003Et__builder)).Task;
		}
	}

	private static Texture2D _DEFAULT_CURSOR = null;

	private static Texture2D _LOADING_CURSOR = null;

	private static Texture2D _DENIED_CURSOR = null;

	private static bool _IS_DELAYING = false;

	public static Random _R = new Random();

	private static List<SystemTextMaster.Param> systemTexts = null;

	private static List<ActMaster.Param> Actions = null;

	private static List<CmdMaster.Param> Cmds = null;

	private static List<EndingMaster.Param> Endings = null;

	private static List<TenCommentMaster.Param> TenComments = null;

	private static List<KusoCommentMaster.Param> Kusokomes = null;

	private static List<KituneMaster.Param> Kitunes = null;

	private static List<KituneSuretaiMaster.Param> Suretais = null;

	private static List<EgosaMaster.Param> Egosas = null;

	private static List<yakujoMaster.Param> yakujos = null;

	private static List<EventTextMaster.Param> eventTexts = null;

	private static List<TooltipMaster.Param> Tooltips = null;

	private static MobCommentMaster MobData = null;

	public static List<KusoRepType> smallKusoreps = new List<KusoRepType>
	{
		KusoRepType.KusoRep001,
		KusoRepType.KusoRep002,
		KusoRepType.KusoRep003,
		KusoRepType.KusoRep004,
		KusoRepType.KusoRep005,
		KusoRepType.KusoRep007,
		KusoRepType.KusoRep008,
		KusoRepType.KusoRep009,
		KusoRepType.KusoRep010,
		KusoRepType.KusoRep011,
		KusoRepType.KusoRep012,
		KusoRepType.KusoRep013,
		KusoRepType.KusoRep014,
		KusoRepType.KusoRep017,
		KusoRepType.KusoRep018,
		KusoRepType.KusoRep019,
		KusoRepType.KusoRep020,
		KusoRepType.KusoRep021,
		KusoRepType.KusoRep022,
		KusoRepType.KusoRep023,
		KusoRepType.KusoRep025,
		KusoRepType.KusoRep026,
		KusoRepType.KusoRep027,
		KusoRepType.KusoRep028,
		KusoRepType.KusoRep030,
		KusoRepType.KusoRep031,
		KusoRepType.KusoRep032,
		KusoRepType.KusoRep033,
		KusoRepType.KusoRep034,
		KusoRepType.KusoRep035,
		KusoRepType.KusoRep036,
		KusoRepType.KusoRep037,
		KusoRepType.KusoRep039,
		KusoRepType.KusoRep040,
		KusoRepType.KusoRep041,
		KusoRepType.KusoRep042,
		KusoRepType.KusoRep043,
		KusoRepType.KusoRep044,
		KusoRepType.KusoRep045,
		KusoRepType.Kusorep_small1,
		KusoRepType.Kusorep_small2,
		KusoRepType.Kusorep_small3,
		KusoRepType.Kusorep_small4,
		KusoRepType.Kusorep_small5,
		KusoRepType.Kusorep_small6,
		KusoRepType.Kusorep_small7,
		KusoRepType.Kusorep_small8,
		KusoRepType.Kusorep_small9,
		KusoRepType.Kusorep_small10,
		KusoRepType.Krep101,
		KusoRepType.Krep102,
		KusoRepType.Krep103,
		KusoRepType.Krep104,
		KusoRepType.Krep105,
		KusoRepType.Krep106,
		KusoRepType.Krep107,
		KusoRepType.Krep108,
		KusoRepType.Krep109,
		KusoRepType.Krep110,
		KusoRepType.Krep111,
		KusoRepType.Krep112,
		KusoRepType.Krep113,
		KusoRepType.Krep114,
		KusoRepType.Krep115,
		KusoRepType.Krep116,
		KusoRepType.Krep117,
		KusoRepType.Krep118,
		KusoRepType.Krep119,
		KusoRepType.Krep120,
		KusoRepType.Krep121,
		KusoRepType.Krep122,
		KusoRepType.Krep123,
		KusoRepType.Krep124,
		KusoRepType.Krep125,
		KusoRepType.Krep126,
		KusoRepType.Krep127,
		KusoRepType.Krep128,
		KusoRepType.Krep129,
		KusoRepType.Krep130,
		KusoRepType.Krep131,
		KusoRepType.Krep132,
		KusoRepType.Krep133,
		KusoRepType.Krep134,
		KusoRepType.Krep135,
		KusoRepType.Krep136,
		KusoRepType.Krep137,
		KusoRepType.Krep138,
		KusoRepType.Krep139,
		KusoRepType.Krep140,
		KusoRepType.Krep141,
		KusoRepType.Krep142,
		KusoRepType.Krep143,
		KusoRepType.Krep144,
		KusoRepType.Krep145,
		KusoRepType.Krep146,
		KusoRepType.Krep147,
		KusoRepType.Krep148,
		KusoRepType.Krep149,
		KusoRepType.Krep150,
		KusoRepType.Krep151,
		KusoRepType.Krep152,
		KusoRepType.Krep153,
		KusoRepType.Krep154,
		KusoRepType.Krep155,
		KusoRepType.Krep156,
		KusoRepType.Krep157,
		KusoRepType.Krep158,
		KusoRepType.Krep159,
		KusoRepType.Krep160,
		KusoRepType.Krep161,
		KusoRepType.Krep162,
		KusoRepType.Krep163,
		KusoRepType.Krep164,
		KusoRepType.Krep165,
		KusoRepType.Krep166,
		KusoRepType.Krep167,
		KusoRepType.Krep168,
		KusoRepType.Krep169,
		KusoRepType.Krep170,
		KusoRepType.Krep171,
		KusoRepType.Krep172,
		KusoRepType.Krep173,
		KusoRepType.Krep174,
		KusoRepType.Krep175,
		KusoRepType.Krep176,
		KusoRepType.Krep177,
		KusoRepType.Krep178,
		KusoRepType.Krep179,
		KusoRepType.Krep180
	};

	public static List<KusoRepType> middleKusoreps = new List<KusoRepType>
	{
		KusoRepType.KusoRep001,
		KusoRepType.KusoRep002,
		KusoRepType.KusoRep003,
		KusoRepType.KusoRep004,
		KusoRepType.KusoRep005,
		KusoRepType.KusoRep007,
		KusoRepType.KusoRep008,
		KusoRepType.KusoRep009,
		KusoRepType.KusoRep010,
		KusoRepType.KusoRep011,
		KusoRepType.KusoRep012,
		KusoRepType.KusoRep013,
		KusoRepType.KusoRep014,
		KusoRepType.KusoRep017,
		KusoRepType.KusoRep018,
		KusoRepType.KusoRep019,
		KusoRepType.KusoRep020,
		KusoRepType.KusoRep021,
		KusoRepType.KusoRep022,
		KusoRepType.KusoRep023,
		KusoRepType.KusoRep025,
		KusoRepType.KusoRep026,
		KusoRepType.KusoRep027,
		KusoRepType.KusoRep028,
		KusoRepType.KusoRep030,
		KusoRepType.KusoRep031,
		KusoRepType.KusoRep032,
		KusoRepType.KusoRep033,
		KusoRepType.KusoRep034,
		KusoRepType.KusoRep035,
		KusoRepType.KusoRep036,
		KusoRepType.KusoRep037,
		KusoRepType.KusoRep038,
		KusoRepType.KusoRep039,
		KusoRepType.KusoRep040,
		KusoRepType.KusoRep041,
		KusoRepType.KusoRep042,
		KusoRepType.KusoRep043,
		KusoRepType.KusoRep044,
		KusoRepType.KusoRep045,
		KusoRepType.Kusorep_middle1,
		KusoRepType.Kusorep_middle2,
		KusoRepType.Kusorep_middle3,
		KusoRepType.Kusorep_middle4,
		KusoRepType.Kusorep_middle6,
		KusoRepType.Kusorep_middle7,
		KusoRepType.Kusorep_middle10,
		KusoRepType.Kusorep_middle11,
		KusoRepType.Kusorep_middle12,
		KusoRepType.Kusorep_middle13,
		KusoRepType.Kusorep_middle14,
		KusoRepType.Kusorep_middle15,
		KusoRepType.Krep101,
		KusoRepType.Krep102,
		KusoRepType.Krep103,
		KusoRepType.Krep104,
		KusoRepType.Krep105,
		KusoRepType.Krep106,
		KusoRepType.Krep107,
		KusoRepType.Krep108,
		KusoRepType.Krep109,
		KusoRepType.Krep110,
		KusoRepType.Krep111,
		KusoRepType.Krep112,
		KusoRepType.Krep113,
		KusoRepType.Krep114,
		KusoRepType.Krep115,
		KusoRepType.Krep116,
		KusoRepType.Krep117,
		KusoRepType.Krep118,
		KusoRepType.Krep119,
		KusoRepType.Krep120,
		KusoRepType.Krep121,
		KusoRepType.Krep122,
		KusoRepType.Krep123,
		KusoRepType.Krep124,
		KusoRepType.Krep125,
		KusoRepType.Krep126,
		KusoRepType.Krep127,
		KusoRepType.Krep128,
		KusoRepType.Krep129,
		KusoRepType.Krep130,
		KusoRepType.Krep131,
		KusoRepType.Krep132,
		KusoRepType.Krep133,
		KusoRepType.Krep134,
		KusoRepType.Krep135,
		KusoRepType.Krep136,
		KusoRepType.Krep137,
		KusoRepType.Krep138,
		KusoRepType.Krep139,
		KusoRepType.Krep140,
		KusoRepType.Krep141,
		KusoRepType.Krep142,
		KusoRepType.Krep143,
		KusoRepType.Krep144,
		KusoRepType.Krep145,
		KusoRepType.Krep146,
		KusoRepType.Krep147,
		KusoRepType.Krep148,
		KusoRepType.Krep149,
		KusoRepType.Krep150,
		KusoRepType.Krep151,
		KusoRepType.Krep152,
		KusoRepType.Krep153,
		KusoRepType.Krep154,
		KusoRepType.Krep155,
		KusoRepType.Krep156,
		KusoRepType.Krep157,
		KusoRepType.Krep158,
		KusoRepType.Krep159,
		KusoRepType.Krep160,
		KusoRepType.Krep161,
		KusoRepType.Krep162,
		KusoRepType.Krep163,
		KusoRepType.Krep164,
		KusoRepType.Krep165,
		KusoRepType.Krep166,
		KusoRepType.Krep167,
		KusoRepType.Krep168,
		KusoRepType.Krep169,
		KusoRepType.Krep170,
		KusoRepType.Krep171,
		KusoRepType.Krep172,
		KusoRepType.Krep173,
		KusoRepType.Krep174,
		KusoRepType.Krep175,
		KusoRepType.Krep176,
		KusoRepType.Krep177,
		KusoRepType.Krep178,
		KusoRepType.Krep179,
		KusoRepType.Krep180
	};

	public static List<KusoRepType> largeKusoreps = new List<KusoRepType>
	{
		KusoRepType.KusoRep001,
		KusoRepType.KusoRep002,
		KusoRepType.KusoRep003,
		KusoRepType.KusoRep004,
		KusoRepType.KusoRep005,
		KusoRepType.KusoRep007,
		KusoRepType.KusoRep008,
		KusoRepType.KusoRep009,
		KusoRepType.KusoRep010,
		KusoRepType.KusoRep011,
		KusoRepType.KusoRep012,
		KusoRepType.KusoRep013,
		KusoRepType.KusoRep014,
		KusoRepType.KusoRep017,
		KusoRepType.KusoRep018,
		KusoRepType.KusoRep019,
		KusoRepType.KusoRep020,
		KusoRepType.KusoRep021,
		KusoRepType.KusoRep022,
		KusoRepType.KusoRep023,
		KusoRepType.KusoRep025,
		KusoRepType.KusoRep026,
		KusoRepType.KusoRep027,
		KusoRepType.KusoRep028,
		KusoRepType.KusoRep030,
		KusoRepType.KusoRep031,
		KusoRepType.KusoRep032,
		KusoRepType.KusoRep033,
		KusoRepType.KusoRep034,
		KusoRepType.KusoRep035,
		KusoRepType.KusoRep036,
		KusoRepType.KusoRep037,
		KusoRepType.KusoRep038,
		KusoRepType.KusoRep039,
		KusoRepType.KusoRep040,
		KusoRepType.KusoRep041,
		KusoRepType.KusoRep042,
		KusoRepType.KusoRep043,
		KusoRepType.KusoRep044,
		KusoRepType.KusoRep045,
		KusoRepType.Kusorep_large1,
		KusoRepType.Kusorep_large2,
		KusoRepType.Kusorep_large3,
		KusoRepType.Kusorep_large4,
		KusoRepType.Kusorep_large5,
		KusoRepType.Kusorep_large6,
		KusoRepType.Kusorep_large8,
		KusoRepType.Kusorep_large9,
		KusoRepType.Kusorep_large10,
		KusoRepType.Kusorep_large11,
		KusoRepType.Kusorep_large12,
		KusoRepType.Kusorep_large13,
		KusoRepType.Kusorep_large14,
		KusoRepType.Kusorep_large15,
		KusoRepType.Kusorep_large16,
		KusoRepType.Kusorep_large17,
		KusoRepType.Kusorep_large18,
		KusoRepType.Kusorep_large19,
		KusoRepType.Kusorep_large20,
		KusoRepType.Krep101,
		KusoRepType.Krep102,
		KusoRepType.Krep103,
		KusoRepType.Krep104,
		KusoRepType.Krep105,
		KusoRepType.Krep106,
		KusoRepType.Krep107,
		KusoRepType.Krep108,
		KusoRepType.Krep109,
		KusoRepType.Krep110,
		KusoRepType.Krep111,
		KusoRepType.Krep112,
		KusoRepType.Krep113,
		KusoRepType.Krep114,
		KusoRepType.Krep115,
		KusoRepType.Krep116,
		KusoRepType.Krep117,
		KusoRepType.Krep118,
		KusoRepType.Krep119,
		KusoRepType.Krep120,
		KusoRepType.Krep121,
		KusoRepType.Krep122,
		KusoRepType.Krep123,
		KusoRepType.Krep124,
		KusoRepType.Krep125,
		KusoRepType.Krep126,
		KusoRepType.Krep127,
		KusoRepType.Krep128,
		KusoRepType.Krep129,
		KusoRepType.Krep130,
		KusoRepType.Krep131,
		KusoRepType.Krep132,
		KusoRepType.Krep133,
		KusoRepType.Krep134,
		KusoRepType.Krep135,
		KusoRepType.Krep136,
		KusoRepType.Krep137,
		KusoRepType.Krep138,
		KusoRepType.Krep139,
		KusoRepType.Krep140,
		KusoRepType.Krep141,
		KusoRepType.Krep142,
		KusoRepType.Krep143,
		KusoRepType.Krep144,
		KusoRepType.Krep145,
		KusoRepType.Krep146,
		KusoRepType.Krep147,
		KusoRepType.Krep148,
		KusoRepType.Krep149,
		KusoRepType.Krep150,
		KusoRepType.Krep151,
		KusoRepType.Krep152,
		KusoRepType.Krep153,
		KusoRepType.Krep154,
		KusoRepType.Krep155,
		KusoRepType.Krep156,
		KusoRepType.Krep157,
		KusoRepType.Krep158,
		KusoRepType.Krep159,
		KusoRepType.Krep160,
		KusoRepType.Krep161,
		KusoRepType.Krep162,
		KusoRepType.Krep163,
		KusoRepType.Krep164,
		KusoRepType.Krep165,
		KusoRepType.Krep166,
		KusoRepType.Krep167,
		KusoRepType.Krep168,
		KusoRepType.Krep169,
		KusoRepType.Krep170,
		KusoRepType.Krep171,
		KusoRepType.Krep172,
		KusoRepType.Krep173,
		KusoRepType.Krep174,
		KusoRepType.Krep175,
		KusoRepType.Krep176,
		KusoRepType.Krep177,
		KusoRepType.Krep178,
		KusoRepType.Krep179,
		KusoRepType.Krep180
	};

	public static List<KusoRepType> AngelKusoreps = new List<KusoRepType>
	{
		KusoRepType.FanRep001,
		KusoRepType.FanRep002,
		KusoRepType.FanRep003,
		KusoRepType.BoshuuRep001,
		KusoRepType.BoshuuRep002,
		KusoRepType.BoshuuRep003,
		KusoRepType.BoshuuRep004,
		KusoRepType.BoshuuRep005,
		KusoRepType.BoshuuRep006,
		KusoRepType.BoshuuRep007,
		KusoRepType.BoshuuRep012,
		KusoRepType.BoshuuRep013,
		KusoRepType.BoshuuRep014,
		KusoRepType.BoshuuRep015,
		KusoRepType.BoshuuRep016,
		KusoRepType.BoshuuRep017,
		KusoRepType.BoshuuRep018,
		KusoRepType.BoshuuRep019,
		KusoRepType.BoshuuRep020,
		KusoRepType.BoshuuRep021,
		KusoRepType.BoshuuRep022,
		KusoRepType.BoshuuRep023,
		KusoRepType.BoshuuRep024,
		KusoRepType.BoshuuRep025,
		KusoRepType.BoshuuRep026,
		KusoRepType.BoshuuRep027,
		KusoRepType.BoshuuRep028,
		KusoRepType.BoshuuRep029,
		KusoRepType.BoshuuRep030,
		KusoRepType.BoshuuRep031,
		KusoRepType.BoshuuRep032,
		KusoRepType.BoshuuRep034,
		KusoRepType.BoshuuRep035,
		KusoRepType.BoshuuRep036,
		KusoRepType.BoshuuRep037,
		KusoRepType.BoshuuRep038,
		KusoRepType.BoshuuRep039,
		KusoRepType.BoshuuRep040,
		KusoRepType.BoshuuRep041,
		KusoRepType.BoshuuRep044,
		KusoRepType.BoshuuRep045,
		KusoRepType.BoshuuRep046,
		KusoRepType.BoshuuRep047,
		KusoRepType.BoshuuRep048,
		KusoRepType.BoshuuRep049,
		KusoRepType.BoshuuRep050,
		KusoRepType.BoshuuRep052,
		KusoRepType.BoshuuRep053,
		KusoRepType.BoshuuRep054,
		KusoRepType.BoshuuRep055,
		KusoRepType.BoshuuRep056,
		KusoRepType.BoshuuRep057,
		KusoRepType.BoshuuRep058,
		KusoRepType.BoshuuRep059,
		KusoRepType.BoshuuRep061,
		KusoRepType.BoshuuRep062,
		KusoRepType.BoshuuRep064,
		KusoRepType.BoshuuRep066,
		KusoRepType.BoshuuRep067,
		KusoRepType.BoshuuRep068,
		KusoRepType.BoshuuRep069,
		KusoRepType.BoshuuRep070,
		KusoRepType.BoshuuRep071,
		KusoRepType.BoshuuRep072,
		KusoRepType.BoshuuRep073,
		KusoRepType.BoshuuRep074,
		KusoRepType.BoshuuRep075,
		KusoRepType.BoshuuRep076,
		KusoRepType.BoshuuRep077,
		KusoRepType.BoshuuRep078,
		KusoRepType.BoshuuRep079,
		KusoRepType.BoshuuRep081,
		KusoRepType.BoshuuRep083,
		KusoRepType.BoshuuRep084,
		KusoRepType.BoshuuRep085,
		KusoRepType.BoshuuRep086,
		KusoRepType.BoshuuRep087,
		KusoRepType.BoshuuRep088,
		KusoRepType.BoshuuRep091,
		KusoRepType.BoshuuRep092,
		KusoRepType.BoshuuRep093,
		KusoRepType.BoshuuRep096,
		KusoRepType.BoshuuRep097,
		KusoRepType.BoshuuRep099,
		KusoRepType.BoshuuRep100,
		KusoRepType.BoshuuRep101,
		KusoRepType.BoshuuRep102,
		KusoRepType.BoshuuRep103,
		KusoRepType.BoshuuRep104,
		KusoRepType.BoshuuRep105,
		KusoRepType.BoshuuRep106,
		KusoRepType.BoshuuRep107,
		KusoRepType.BoshuuRep109,
		KusoRepType.BoshuuRep110,
		KusoRepType.BoshuuRep111,
		KusoRepType.BoshuuRep113,
		KusoRepType.BoshuuRep114,
		KusoRepType.BoshuuRep115,
		KusoRepType.BoshuuRep116,
		KusoRepType.BoshuuRep117,
		KusoRepType.BoshuuRep119,
		KusoRepType.BoshuuRep120,
		KusoRepType.BoshuuRep121,
		KusoRepType.BoshuuRep122,
		KusoRepType.BoshuuRep124,
		KusoRepType.BoshuuRep125,
		KusoRepType.BoshuuRep126,
		KusoRepType.BoshuuRep127,
		KusoRepType.BoshuuRep128,
		KusoRepType.BoshuuRep129,
		KusoRepType.BoshuuRep130,
		KusoRepType.BoshuuRep131,
		KusoRepType.BoshuuRep132,
		KusoRepType.BoshuuRep133,
		KusoRepType.BoshuuRep134,
		KusoRepType.BoshuuRep135,
		KusoRepType.BoshuuRep136,
		KusoRepType.BoshuuRep137,
		KusoRepType.BoshuuRep138,
		KusoRepType.BoshuuRep139,
		KusoRepType.BoshuuRep141,
		KusoRepType.BoshuuRep143,
		KusoRepType.BoshuuRep144,
		KusoRepType.BoshuuRep145,
		KusoRepType.BoshuuRep146,
		KusoRepType.BoshuuRep147,
		KusoRepType.BoshuuRep148,
		KusoRepType.BoshuuRep149,
		KusoRepType.BoshuuRep151,
		KusoRepType.BoshuuRep153,
		KusoRepType.BoshuuRep154,
		KusoRepType.BoshuuRep155,
		KusoRepType.BoshuuRep156,
		KusoRepType.BoshuuRep157,
		KusoRepType.BoshuuRep158,
		KusoRepType.BoshuuRep159,
		KusoRepType.BoshuuRep160,
		KusoRepType.BoshuuRep161,
		KusoRepType.BoshuuRep162,
		KusoRepType.BoshuuRep163,
		KusoRepType.BoshuuRep164,
		KusoRepType.BoshuuRep166,
		KusoRepType.BoshuuRep167,
		KusoRepType.BoshuuRep168,
		KusoRepType.BoshuuRep169,
		KusoRepType.BoshuuRep171,
		KusoRepType.BoshuuRep173,
		KusoRepType.BoshuuRep174,
		KusoRepType.BoshuuRep175,
		KusoRepType.BoshuuRep176,
		KusoRepType.BoshuuRep177,
		KusoRepType.BoshuuRep178,
		KusoRepType.BoshuuRep180,
		KusoRepType.BoshuuRep181,
		KusoRepType.BoshuuRep182,
		KusoRepType.BoshuuRep183,
		KusoRepType.BoshuuRep184,
		KusoRepType.BoshuuRep186,
		KusoRepType.BoshuuRep187,
		KusoRepType.BoshuuRep189,
		KusoRepType.BoshuuRep190,
		KusoRepType.BoshuuRep191,
		KusoRepType.BoshuuRep193,
		KusoRepType.BoshuuRep194,
		KusoRepType.BoshuuRep195,
		KusoRepType.BoshuuRep196,
		KusoRepType.BoshuuRep197,
		KusoRepType.BoshuuRep198,
		KusoRepType.BoshuuRep199,
		KusoRepType.BoshuuRep200,
		KusoRepType.BoshuuRep201,
		KusoRepType.BoshuuRep202,
		KusoRepType.BoshuuRep203,
		KusoRepType.BoshuuRep204,
		KusoRepType.BoshuuRep205,
		KusoRepType.BoshuuRep206,
		KusoRepType.BoshuuRep207,
		KusoRepType.BoshuuRep208,
		KusoRepType.BoshuuRep209,
		KusoRepType.BoshuuRep210,
		KusoRepType.BoshuuRep211
	};

	private static readonly string _RANDOM_CHARACTERS = "0123456789aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";

	public static void ChangeCursor(bool isLoading)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)_DEFAULT_CURSOR == (Object)null)
		{
			_DEFAULT_CURSOR = Resources.Load<Texture2D>("Cursor/cursor");
		}
		if ((Object)(object)_LOADING_CURSOR == (Object)null)
		{
			_LOADING_CURSOR = Resources.Load<Texture2D>("Cursor/cursor_hourglass");
		}
		if (isLoading)
		{
			SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(_LOADING_CURSOR, Vector2.zero, (CursorMode)0);
		}
		else
		{
			SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(_DEFAULT_CURSOR, Vector2.zero, (CursorMode)0);
		}
	}

	public static void DenyCursor()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)_DENIED_CURSOR == (Object)null)
		{
			_DENIED_CURSOR = Resources.Load<Texture2D>("Cursor/cursor_prohibition");
		}
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(_DENIED_CURSOR, Vector2.zero, (CursorMode)0);
	}

	public static UniTask DelayNGO(int milliseconds, CancellationToken token = default(CancellationToken))
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals4.milliseconds = milliseconds;
		CS_0024_003C_003E8__locals4.token = token;
		if (_IS_DELAYING)
		{
			return UniTask.NextFrame(CS_0024_003C_003E8__locals4.token, false);
		}
		_IS_DELAYING = true;
		if ((Object)(object)_DEFAULT_CURSOR == (Object)null)
		{
			_DEFAULT_CURSOR = Resources.Load<Texture2D>("Cursor/cursor");
		}
		if ((Object)(object)_LOADING_CURSOR == (Object)null)
		{
			_LOADING_CURSOR = Resources.Load<Texture2D>("Cursor/cursor_hourglass");
		}
		return UniTask.Create((Func<UniTask>)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass6_0._003C_003CDelayNGO_003Eb__0_003Ed))] () =>
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass6_0._003C_003CDelayNGO_003Eb__0_003Ed _003C_003CDelayNGO_003Eb__0_003Ed = default(_003C_003Ec__DisplayClass6_0._003C_003CDelayNGO_003Eb__0_003Ed);
			_003C_003CDelayNGO_003Eb__0_003Ed._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
			_003C_003CDelayNGO_003Eb__0_003Ed._003C_003E4__this = CS_0024_003C_003E8__locals4;
			_003C_003CDelayNGO_003Eb__0_003Ed._003C_003E1__state = -1;
			((AsyncUniTaskMethodBuilder)(ref _003C_003CDelayNGO_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass6_0._003C_003CDelayNGO_003Eb__0_003Ed>(ref _003C_003CDelayNGO_003Eb__0_003Ed);
			return ((AsyncUniTaskMethodBuilder)(ref _003C_003CDelayNGO_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}));
	}

	public static T RandomEnumValue<T>()
	{
		Array values = Enum.GetValues(typeof(T));
		return (T)values.GetValue(_R.Next(values.Length));
	}

	public static Sequence DoSperchatMove(this RectTransform ui, Action onCompleted = null)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		RectTransform parentRect = ((Component)((Component)ui).gameObject.transform.parent).gameObject.GetComponent<RectTransform>();
		Sequence obj = TweenSettingsExtensions.Append(TweenSettingsExtensions.Append(TweenSettingsExtensions.Join(TweenSettingsExtensions.Append(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			ui.anchoredPosition = spawnVec();
		}), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)ui, 60f, 0.2f, false), (Ease)6)), (Tween)(object)ShortcutExtensions.DOScale((Transform)(object)ui, 0.5f, 0.4f)), (Tween)(object)ShortcutExtensions.DOShakeRotation((Transform)(object)ui, 2f, new Vector3(0f, 0f, 20f), 10, 90f, true)), (Tween)(object)ShortcutExtensions.DOScale((Transform)(object)ui, -1f, 0.4f));
		RectTransform obj2 = ui;
		Rect rect = parentRect.rect;
		return TweenExtensions.Play<Sequence>(TweenSettingsExtensions.SetRelative<Sequence>(TweenSettingsExtensions.Join(obj, (Tween)(object)TweenSettingsExtensions.OnComplete<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)obj2, 0f - ((Rect)(ref rect)).height, 0.4f, false), (Ease)5), (TweenCallback)delegate
		{
			onCompleted?.Invoke();
		}))));
		Vector2 spawnVec()
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			Rect rect2 = parentRect.rect;
			float num = (0f - ((Rect)(ref rect2)).width) / 2f;
			rect2 = parentRect.rect;
			float num2 = Random.Range(num, ((Rect)(ref rect2)).width / 2f);
			rect2 = parentRect.rect;
			float num3 = (0f - ((Rect)(ref rect2)).height) / 2f;
			rect2 = parentRect.rect;
			float num4 = Random.Range(num3, ((Rect)(ref rect2)).height / 2f);
			return new Vector2(num2, num4);
		}
	}

	public static string DayText(int index, LanguageType lang, bool isLive = false)
	{
		if (lang == LanguageType.CN || lang == LanguageType.TW)
		{
			return SystemTextFromType(SystemTextType.Day, lang).Replace("N", index.ToString());
		}
		return $"{SystemTextFromType(isLive ? SystemTextType.Day_Live : SystemTextType.Day, lang)} {index}";
	}

	public static string TimeText(int index, LanguageType lang)
	{
		return index switch
		{
			0 => SystemTextFromType(SystemTextType.System_Daypart0, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), 
			1 => SystemTextFromType(SystemTextType.System_Daypart1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), 
			2 => SystemTextFromType(SystemTextType.System_Daypart2, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), 
			_ => SystemTextFromType(SystemTextType.System_Daypart3, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), 
		};
	}

	public static bool IsNotEmpty(this string value)
	{
		if (value != "N/A")
		{
			return !string.IsNullOrEmpty(value);
		}
		return false;
	}

	public static List<SystemTextMaster.Param> getSystemTexts()
	{
		if (systemTexts == null)
		{
			systemTexts = Resources.Load<SystemTextMaster>("Master/SystemText").param;
		}
		return systemTexts;
	}

	public static string SystemTextFromType(SystemTextType type, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type.ToString()).BodyJp, 
			LanguageType.CN => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type.ToString()).BodyCn, 
			LanguageType.KO => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type.ToString()).BodyKo, 
			LanguageType.TW => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type.ToString()).BodyTw, 
			LanguageType.VN => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type.ToString()).BodyVn, 
			LanguageType.FR => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type.ToString()).BodyFr, 
			LanguageType.IT => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type.ToString()).BodyIt, 
			LanguageType.GE => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type.ToString()).BodyGe, 
			LanguageType.SP => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type.ToString()).BodySp, 
			LanguageType.RU => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type.ToString()).BodyRu, 
			_ => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type.ToString()).BodyEn, 
		};
	}

	public static string SystemTextFromTypeString(string type, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type).BodyJp, 
			LanguageType.CN => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type).BodyCn, 
			LanguageType.KO => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type).BodyKo, 
			LanguageType.TW => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type).BodyTw, 
			LanguageType.VN => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type).BodyVn, 
			LanguageType.FR => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type).BodyFr, 
			LanguageType.IT => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type).BodyIt, 
			LanguageType.GE => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type).BodyGe, 
			LanguageType.SP => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type).BodySp, 
			LanguageType.RU => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type).BodyRu, 
			_ => getSystemTexts().FirstOrDefault((SystemTextMaster.Param x) => x.Id == type).BodyEn, 
		};
	}

	public static string StatusTextFromType(StatusTextType type, LanguageType lang)
	{
		return SystemTextFromTypeString(type.ToString(), lang);
	}

	public static string StatusLabelFromType(StatusType type, LanguageType lang)
	{
		return type switch
		{
			StatusType.DayIndex => "Day", 
			StatusType.MadeLoveCounter => "sxx Counter", 
			StatusType.testAlphaLevel => "netaLevel", 
			_ => SystemTextFromTypeString(type.ToString(), lang), 
		};
	}

	public static string EndingTextFromType(EndingTextType type, LanguageType lang)
	{
		return SystemTextFromTypeString(type.ToString(), lang);
	}

	public static List<ActMaster.Param> getActions()
	{
		if (Actions == null)
		{
			Actions = Resources.Load<ActMaster>("Master/Act").param;
		}
		return Actions;
	}

	public static ActMaster.Param ActFromType(ActionType type)
	{
		return getActions().FirstOrDefault((ActMaster.Param x) => x.Id == type.ToString());
	}

	public static string ActNameFromType(ActionType type, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => getActions().FirstOrDefault((ActMaster.Param x) => x.Id == type.ToString()).TitleJp, 
			LanguageType.CN => getActions().FirstOrDefault((ActMaster.Param x) => x.Id == type.ToString()).TitleCn, 
			LanguageType.KO => getActions().FirstOrDefault((ActMaster.Param x) => x.Id == type.ToString()).TitleKo, 
			LanguageType.TW => getActions().FirstOrDefault((ActMaster.Param x) => x.Id == type.ToString()).TitleTw, 
			LanguageType.VN => getActions().FirstOrDefault((ActMaster.Param x) => x.Id == type.ToString()).TitleVn, 
			LanguageType.FR => getActions().FirstOrDefault((ActMaster.Param x) => x.Id == type.ToString()).TitleFr, 
			LanguageType.IT => getActions().FirstOrDefault((ActMaster.Param x) => x.Id == type.ToString()).TitleIt, 
			LanguageType.GE => getActions().FirstOrDefault((ActMaster.Param x) => x.Id == type.ToString()).TitleGe, 
			LanguageType.SP => getActions().FirstOrDefault((ActMaster.Param x) => x.Id == type.ToString()).TitleSp, 
			LanguageType.RU => getActions().FirstOrDefault((ActMaster.Param x) => x.Id == type.ToString()).TitleRu, 
			_ => getActions().FirstOrDefault((ActMaster.Param x) => x.Id == type.ToString()).TitleEn, 
		};
	}

	public static void SetEndingTextByLanguage(EndingMaster.Param ending, out string endName, out string endJisseki)
	{
		switch (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)
		{
		case LanguageType.JP:
			endName = ending.EndingNameJp;
			endJisseki = ending.JissekiJp;
			break;
		case LanguageType.CN:
			endName = ending.EndingNameCn;
			endJisseki = ending.JissekiCn;
			break;
		case LanguageType.TW:
			endName = ending.EndingNameTw;
			endJisseki = ending.JissekiTw;
			break;
		case LanguageType.KO:
			endName = ending.EndingNameKo;
			endJisseki = ending.JissekiKo;
			break;
		case LanguageType.VN:
			endName = ending.EndingNameVn;
			endJisseki = ending.JissekiVn;
			break;
		case LanguageType.FR:
			endName = ending.EndingNameFr;
			endJisseki = ending.JissekiFr;
			break;
		case LanguageType.IT:
			endName = ending.EndingNameIt;
			endJisseki = ending.JissekiIt;
			break;
		case LanguageType.GE:
			endName = ending.EndingNameGe;
			endJisseki = ending.JissekiGe;
			break;
		case LanguageType.SP:
			endName = ending.EndingNameSp;
			endJisseki = ending.JissekiSp;
			break;
		case LanguageType.RU:
			endName = ending.EndingNameRu;
			endJisseki = ending.JissekiRu;
			break;
		default:
			endName = ending.EndingNameEn;
			endJisseki = ending.JissekiEn;
			break;
		}
	}

	public static List<CmdMaster.Param> getCmds()
	{
		if (Cmds == null)
		{
			Cmds = Resources.Load<CmdMaster>("Master/Cmd").param;
		}
		return Cmds;
	}

	public static CmdMaster.Param CmdFromType(CmdType type)
	{
		return getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type.ToString());
	}

	public static CmdMaster.Param CmdFromString(string type)
	{
		return getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type);
	}

	public static string CmdName(CmdType type, LanguageType lang)
	{
		if (type == CmdType.None)
		{
			return "";
		}
		return lang switch
		{
			LanguageType.JP => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type.ToString()).LabelJp, 
			LanguageType.CN => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type.ToString()).LabelCn, 
			LanguageType.KO => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type.ToString()).LabelKo, 
			LanguageType.TW => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type.ToString()).LabelTw, 
			LanguageType.VN => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type.ToString()).LabelVn, 
			LanguageType.FR => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type.ToString()).LabelFr, 
			LanguageType.IT => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type.ToString()).LabelIt, 
			LanguageType.GE => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type.ToString()).LabelGe, 
			LanguageType.SP => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type.ToString()).LabelSp, 
			LanguageType.RU => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type.ToString()).LabelRu, 
			_ => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type.ToString()).LabelEn, 
		};
	}

	public static string CmdName(string type, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type).LabelJp, 
			LanguageType.CN => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type).LabelCn, 
			LanguageType.KO => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type).LabelKo, 
			LanguageType.TW => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type).LabelTw, 
			LanguageType.VN => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type).LabelVn, 
			LanguageType.FR => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type).LabelFr, 
			LanguageType.IT => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type).LabelIt, 
			LanguageType.GE => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type).LabelGe, 
			LanguageType.SP => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type).LabelSp, 
			LanguageType.RU => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type).LabelRu, 
			_ => getCmds().FirstOrDefault((CmdMaster.Param x) => x.Id == type).LabelEn, 
		};
	}

	public static List<EndingMaster.Param> getEndings()
	{
		if (Endings == null)
		{
			Endings = Resources.Load<EndingMaster>("Master/Ending").param;
		}
		return Endings;
	}

	public static EndingMaster.Param EndingFromType(EndingType type)
	{
		return getEndings().FirstOrDefault((EndingMaster.Param x) => x.Id == type.ToString());
	}

	public static string ReasonTextFromEDType(EndingType type, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => EndingFromType(type).ReasonJp, 
			LanguageType.CN => EndingFromType(type).ReasonCn, 
			LanguageType.KO => EndingFromType(type).ReasonKo, 
			LanguageType.TW => EndingFromType(type).ReasonTw, 
			LanguageType.VN => EndingFromType(type).ReasonVn, 
			LanguageType.FR => EndingFromType(type).ReasonFr, 
			LanguageType.IT => EndingFromType(type).ReasonIt, 
			LanguageType.GE => EndingFromType(type).ReasonGe, 
			LanguageType.SP => EndingFromType(type).ReasonSp, 
			LanguageType.RU => EndingFromType(type).ReasonRu, 
			_ => EndingFromType(type).ReasonEn, 
		};
	}

	public static List<TenCommentMaster.Param> getTenComments()
	{
		if (TenComments == null)
		{
			TenComments = Resources.Load<TenCommentMaster>("Master/TenComment").param;
		}
		return TenComments;
	}

	public static string TenTalk(TenCommentType type, LanguageType lang)
	{
		return TenTalk(type.ToString(), lang);
	}

	public static string TenTalk(string id, LanguageType lang)
	{
		if (id == "None")
		{
			return "";
		}
		return lang switch
		{
			LanguageType.JP => getTenComments().FirstOrDefault((TenCommentMaster.Param x) => x.Id == id).BodyJP, 
			LanguageType.CN => getTenComments().FirstOrDefault((TenCommentMaster.Param x) => x.Id == id).BodyCn, 
			LanguageType.KO => getTenComments().FirstOrDefault((TenCommentMaster.Param x) => x.Id == id).BodyKo, 
			LanguageType.TW => getTenComments().FirstOrDefault((TenCommentMaster.Param x) => x.Id == id).BodyTw, 
			LanguageType.VN => getTenComments().FirstOrDefault((TenCommentMaster.Param x) => x.Id == id).BodyVn, 
			LanguageType.FR => getTenComments().FirstOrDefault((TenCommentMaster.Param x) => x.Id == id).BodyFr, 
			LanguageType.IT => getTenComments().FirstOrDefault((TenCommentMaster.Param x) => x.Id == id).BodyIt, 
			LanguageType.GE => getTenComments().FirstOrDefault((TenCommentMaster.Param x) => x.Id == id).BodyGe, 
			LanguageType.SP => getTenComments().FirstOrDefault((TenCommentMaster.Param x) => x.Id == id).BodySp, 
			LanguageType.RU => getTenComments().FirstOrDefault((TenCommentMaster.Param x) => x.Id == id).BodyRu, 
			_ => getTenComments().FirstOrDefault((TenCommentMaster.Param x) => x.Id == id).BodyEn, 
		};
	}

	public static List<KusoCommentMaster.Param> getKusoComments()
	{
		if (Kusokomes == null)
		{
			Kusokomes = Resources.Load<KusoCommentMaster>("Master/KusoComment").param;
		}
		return Kusokomes;
	}

	public static string Kome(string id, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => getKusoComments().FirstOrDefault((KusoCommentMaster.Param x) => x.Id == id).BodyJP, 
			LanguageType.CN => getKusoComments().FirstOrDefault((KusoCommentMaster.Param x) => x.Id == id).BodyCn, 
			LanguageType.KO => getKusoComments().FirstOrDefault((KusoCommentMaster.Param x) => x.Id == id).BodyKo, 
			LanguageType.TW => getKusoComments().FirstOrDefault((KusoCommentMaster.Param x) => x.Id == id).BodyTw, 
			LanguageType.VN => getKusoComments().FirstOrDefault((KusoCommentMaster.Param x) => x.Id == id).BodyVN, 
			LanguageType.FR => getKusoComments().FirstOrDefault((KusoCommentMaster.Param x) => x.Id == id).BodyFr, 
			LanguageType.IT => getKusoComments().FirstOrDefault((KusoCommentMaster.Param x) => x.Id == id).BodyIt, 
			LanguageType.GE => getKusoComments().FirstOrDefault((KusoCommentMaster.Param x) => x.Id == id).BodyGe, 
			LanguageType.SP => getKusoComments().FirstOrDefault((KusoCommentMaster.Param x) => x.Id == id).BodySp, 
			LanguageType.RU => getKusoComments().FirstOrDefault((KusoCommentMaster.Param x) => x.Id == id).BodyRu, 
			_ => getKusoComments().FirstOrDefault((KusoCommentMaster.Param x) => x.Id == id).BodyEn, 
		};
	}

	public static List<KituneMaster.Param> getKitunes()
	{
		if (Kitunes == null)
		{
			Kitunes = Resources.Load<KituneMaster>("Master/Kitune").param;
		}
		return Kitunes;
	}

	public static string KituneFromType(string type, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => getKitunes().FirstOrDefault((KituneMaster.Param x) => x.Id == type).BodyJp, 
			LanguageType.CN => getKitunes().FirstOrDefault((KituneMaster.Param x) => x.Id == type).BodyCn, 
			LanguageType.KO => getKitunes().FirstOrDefault((KituneMaster.Param x) => x.Id == type).BodyKo, 
			LanguageType.TW => getKitunes().FirstOrDefault((KituneMaster.Param x) => x.Id == type).BodyTw, 
			LanguageType.VN => getKitunes().FirstOrDefault((KituneMaster.Param x) => x.Id == type).BodyVn, 
			LanguageType.FR => getKitunes().FirstOrDefault((KituneMaster.Param x) => x.Id == type).BodyFr, 
			LanguageType.IT => getKitunes().FirstOrDefault((KituneMaster.Param x) => x.Id == type).BodyIt, 
			LanguageType.GE => getKitunes().FirstOrDefault((KituneMaster.Param x) => x.Id == type).BodyGe, 
			LanguageType.SP => getKitunes().FirstOrDefault((KituneMaster.Param x) => x.Id == type).BodySp, 
			LanguageType.RU => getKitunes().FirstOrDefault((KituneMaster.Param x) => x.Id == type).BodyRu, 
			_ => getKitunes().FirstOrDefault((KituneMaster.Param x) => x.Id == type).BodyEn, 
		};
	}

	public static List<KituneMaster.Param> KituneFromRank(string rank)
	{
		return (from x in getKitunes()
			where x.FollowerRank == rank
			select x).ToList();
	}

	public static List<KituneSuretaiMaster.Param> getSuretais()
	{
		if (Suretais == null)
		{
			Suretais = Resources.Load<KituneSuretaiMaster>("Master/KituneSuretai").param;
		}
		return Suretais;
	}

	public static string SuretaiFromType(string type, LanguageType lang)
	{
		return SystemTextFromTypeString(type, lang);
	}

	public static List<EgosaMaster.Param> getEgosas()
	{
		if (Egosas == null)
		{
			Egosas = Resources.Load<EgosaMaster>("Master/Egosa").param;
		}
		return Egosas;
	}

	public static string EgosaString(LanguageType lang, int order)
	{
		EgosaMaster.Param param = getEgosas().ToList()[order];
		return lang switch
		{
			LanguageType.JP => param.BodyJp, 
			LanguageType.CN => param.BodyCn, 
			LanguageType.KO => param.BodyKo, 
			LanguageType.TW => param.BodyTw, 
			LanguageType.VN => param.BodyVn, 
			LanguageType.FR => param.BodyFr, 
			LanguageType.IT => param.BodyIt, 
			LanguageType.GE => param.BodyGe, 
			LanguageType.SP => param.BodySp, 
			LanguageType.RU => param.BodyRu, 
			_ => param.BodyEn, 
		};
	}

	public static string EgosaString(LanguageType lang, string type = "random", string jouken = "random")
	{
		List<EgosaMaster.Param> list = (from x in getEgosas()
			where x.Type == type && x.Jouken == jouken
			select x).ToList();
		if (list.Count <= 0)
		{
			return "";
		}
		EgosaMaster.Param param = list[Random.Range(0, list.Count)];
		return lang switch
		{
			LanguageType.JP => param.BodyJp, 
			LanguageType.CN => param.BodyCn, 
			LanguageType.KO => param.BodyKo, 
			LanguageType.TW => param.BodyTw, 
			LanguageType.VN => param.BodyVn, 
			LanguageType.FR => param.BodyFr, 
			LanguageType.IT => param.BodyIt, 
			LanguageType.GE => param.BodyGe, 
			LanguageType.SP => param.BodySp, 
			LanguageType.RU => param.BodyRu, 
			_ => param.BodyEn, 
		};
	}

	public static string EgosaString(LanguageType lang, int order, string type = "random", string jouken = "random")
	{
		List<EgosaMaster.Param> list = (from x in getEgosas()
			where x.Type == type && x.Jouken == jouken
			select x).ToList();
		if (list.Count <= 0)
		{
			return "";
		}
		EgosaMaster.Param param = list[order];
		return lang switch
		{
			LanguageType.JP => param.BodyJp, 
			LanguageType.CN => param.BodyCn, 
			LanguageType.KO => param.BodyKo, 
			LanguageType.TW => param.BodyTw, 
			LanguageType.VN => param.BodyVn, 
			LanguageType.FR => param.BodyFr, 
			LanguageType.IT => param.BodyIt, 
			LanguageType.GE => param.BodyGe, 
			LanguageType.SP => param.BodySp, 
			LanguageType.RU => param.BodyRu, 
			_ => param.BodyEn, 
		};
	}

	public static List<yakujoMaster.Param> getyakujos()
	{
		if (yakujos == null)
		{
			yakujos = Resources.Load<yakujoMaster>("Master/yakujo").param;
		}
		return yakujos;
	}

	public static string yakujo(string type, string content, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => getyakujos().FirstOrDefault((yakujoMaster.Param x) => x.Type == type && x.Content == content).BodyJp, 
			LanguageType.CN => getyakujos().FirstOrDefault((yakujoMaster.Param x) => x.Type == type && x.Content == content).BodyCn, 
			LanguageType.KO => getyakujos().FirstOrDefault((yakujoMaster.Param x) => x.Type == type && x.Content == content).BodyKo, 
			LanguageType.TW => getyakujos().FirstOrDefault((yakujoMaster.Param x) => x.Type == type && x.Content == content).BodyTw, 
			LanguageType.VN => getyakujos().FirstOrDefault((yakujoMaster.Param x) => x.Type == type && x.Content == content).BodyVn, 
			LanguageType.FR => getyakujos().FirstOrDefault((yakujoMaster.Param x) => x.Type == type && x.Content == content).BodyFr, 
			LanguageType.IT => getyakujos().FirstOrDefault((yakujoMaster.Param x) => x.Type == type && x.Content == content).BodyIt, 
			LanguageType.GE => getyakujos().FirstOrDefault((yakujoMaster.Param x) => x.Type == type && x.Content == content).BodyGe, 
			LanguageType.SP => getyakujos().FirstOrDefault((yakujoMaster.Param x) => x.Type == type && x.Content == content).BodySp, 
			LanguageType.RU => getyakujos().FirstOrDefault((yakujoMaster.Param x) => x.Type == type && x.Content == content).BodyRu, 
			_ => getyakujos().FirstOrDefault((yakujoMaster.Param x) => x.Type == type && x.Content == content).BodyEn, 
		};
	}

	public static string GetJineHonbun(JineDrawable nakami, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => nakami.BodyJp, 
			LanguageType.CN => nakami.BodyCn, 
			LanguageType.KO => nakami.BodyKo, 
			LanguageType.TW => nakami.BodyTw, 
			LanguageType.VN => nakami.BodyVn, 
			LanguageType.FR => nakami.BodyFr, 
			LanguageType.IT => nakami.BodyIt, 
			LanguageType.GE => nakami.BodyGe, 
			LanguageType.SP => nakami.BodySp, 
			LanguageType.RU => nakami.BodyRu, 
			_ => nakami.BodyEn, 
		};
	}

	public static string GetJineNotificationText(JineData jineData, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => JineDataConverter.convertJineDataToDrawable(jineData).BodyJp, 
			LanguageType.CN => JineDataConverter.convertJineDataToDrawable(jineData).BodyCn, 
			LanguageType.KO => JineDataConverter.convertJineDataToDrawable(jineData).BodyKo, 
			LanguageType.TW => JineDataConverter.convertJineDataToDrawable(jineData).BodyTw, 
			LanguageType.VN => JineDataConverter.convertJineDataToDrawable(jineData).BodyVn, 
			LanguageType.FR => JineDataConverter.convertJineDataToDrawable(jineData).BodyFr, 
			LanguageType.IT => JineDataConverter.convertJineDataToDrawable(jineData).BodyIt, 
			LanguageType.GE => JineDataConverter.convertJineDataToDrawable(jineData).BodyGe, 
			LanguageType.SP => JineDataConverter.convertJineDataToDrawable(jineData).BodySp, 
			LanguageType.RU => JineDataConverter.convertJineDataToDrawable(jineData).BodyRu, 
			_ => JineDataConverter.convertJineDataToDrawable(jineData).BodyEn, 
		};
	}

	public static string GetToolTipText(TooltipMaster.Param param, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => param.BodyJp, 
			LanguageType.CN => param.BodyCn, 
			LanguageType.KO => param.BodyKo, 
			LanguageType.TW => param.BodyTw, 
			LanguageType.VN => param.BodyVn, 
			LanguageType.FR => param.BodyFr, 
			LanguageType.IT => param.BodyIt, 
			LanguageType.GE => param.BodyGe, 
			LanguageType.SP => param.BodySp, 
			LanguageType.RU => param.BodyRu, 
			LanguageType.EN => param.BodyEn, 
			_ => param.BodyEn, 
		};
	}

	public static string GetTweetBody(TweetDrawable param, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => param.BodyJp, 
			LanguageType.CN => param.BodyCn, 
			LanguageType.KO => param.BodyKo, 
			LanguageType.TW => param.BodyTw, 
			LanguageType.VN => param.BodyVn, 
			LanguageType.FR => param.BodyFr, 
			LanguageType.IT => param.BodyIt, 
			LanguageType.GE => param.BodyGe, 
			LanguageType.SP => param.BodySp, 
			LanguageType.RU => param.BodyRu, 
			LanguageType.EN => param.BodyEn, 
			_ => param.BodyEn, 
		};
	}

	public static string GetKusoRepBody(KusoRepDrawable param, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => param.BodyJp, 
			LanguageType.CN => param.BodyCn, 
			LanguageType.KO => param.BodyKo, 
			LanguageType.TW => param.BodyTw, 
			LanguageType.VN => param.BodyVn, 
			LanguageType.FR => param.BodyFr, 
			LanguageType.IT => param.BodyIt, 
			LanguageType.GE => param.BodyGe, 
			LanguageType.SP => param.BodySp, 
			LanguageType.RU => param.BodyRu, 
			LanguageType.EN => param.BodyEn, 
			_ => param.BodyEn, 
		};
	}

	public static string GetActionName(ActMaster.Param param, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => param.TitleJp, 
			LanguageType.CN => param.TitleCn, 
			LanguageType.KO => param.TitleKo, 
			LanguageType.TW => param.TitleTw, 
			LanguageType.VN => param.TitleVn, 
			LanguageType.FR => param.TitleFr, 
			LanguageType.IT => param.TitleIt, 
			LanguageType.GE => param.TitleGe, 
			LanguageType.SP => param.TitleSp, 
			LanguageType.RU => param.TitleRu, 
			LanguageType.EN => param.TitleEn, 
			_ => param.TitleEn, 
		};
	}

	public static string GetCommandName(CmdMaster.Param param, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => param.LabelJp, 
			LanguageType.CN => param.LabelCn, 
			LanguageType.KO => param.LabelKo, 
			LanguageType.TW => param.LabelTw, 
			LanguageType.VN => param.LabelVn, 
			LanguageType.FR => param.LabelFr, 
			LanguageType.IT => param.LabelIt, 
			LanguageType.GE => param.LabelGe, 
			LanguageType.SP => param.LabelSp, 
			LanguageType.RU => param.LabelRu, 
			LanguageType.EN => param.LabelEn, 
			_ => param.LabelEn, 
		};
	}

	public static string GetCommandDesc(CmdMaster.Param param, LanguageType lang)
	{
		return lang switch
		{
			LanguageType.JP => param.DescJp, 
			LanguageType.CN => param.DescCn, 
			LanguageType.KO => param.DescKo, 
			LanguageType.TW => param.DescTw, 
			LanguageType.VN => param.DescVn, 
			LanguageType.FR => param.DescFr, 
			LanguageType.IT => param.DescIt, 
			LanguageType.GE => param.DescGe, 
			LanguageType.SP => param.DescSp, 
			LanguageType.RU => param.DescRu, 
			LanguageType.EN => param.DescEn, 
			_ => param.DescEn, 
		};
	}

	public static List<EventTextMaster.Param> geteventTexts()
	{
		if (eventTexts == null)
		{
			eventTexts = Resources.Load<EventTextMaster>("Master/EventText").param;
		}
		return eventTexts;
	}

	public static string EventTextTypeToText(EventTextType type, LanguageType lang)
	{
		return SystemTextFromTypeString(type.ToString(), lang);
	}

	public static string TextTypeToText(TextType type, LanguageType lang)
	{
		return SystemTextFromTypeString(type.ToString(), lang);
	}

	public static List<TooltipMaster.Param> getTooltips()
	{
		if (Tooltips == null)
		{
			Tooltips = Resources.Load<TooltipMaster>("Master/Tooltip").param;
		}
		return Tooltips;
	}

	public static TooltipMaster.Param getToolTip(TooltipType type)
	{
		return getTooltips().FirstOrDefault((TooltipMaster.Param x) => x.Id == type.ToString());
	}

	public static MobCommentMaster getMobs()
	{
		if ((Object)(object)MobData == (Object)null)
		{
			MobData = Resources.Load<MobCommentMaster>("Master/MobComment");
		}
		return MobData;
	}

	public static T RandomizedElement<T>(this List<T> list)
	{
		if (list.Count < 1)
		{
			return list.FirstOrDefault();
		}
		int index = Random.Range(0, list.Count());
		return list.ElementAtOrDefault(index);
	}

	public static string GenerateRandomCharacters(int length)
	{
		StringBuilder stringBuilder = new StringBuilder(length);
		Random random = new Random();
		for (int i = 0; i < length; i++)
		{
			int index = random.Next(_RANDOM_CHARACTERS.Length);
			char value = _RANDOM_CHARACTERS[index];
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}
}
