using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace ngov3;

public class Haishin_Day0 : LiveScenario
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartScenario_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Haishin_Day0 _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Haishin_Day0 haishin_Day = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.turorial_beforeHaishin2);
					val2 = NgoEvent.DelaySkippable(Constants.SLOW * 3);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartScenario_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_008e;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_008e;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00f7;
				case 2:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00f7:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tutorial_afterHaishin);
					val2 = NgoEvent.DelaySkippable(Constants.SLOW * 2);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartScenario_003Ed__1>(ref val, ref this);
						return;
					}
					break;
					IL_008e:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
					val2 = ((LiveScenario)haishin_Day).StartScenario();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartScenario_003Ed__1>(ref val, ref this);
						return;
					}
					goto IL_00f7;
				}
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
				haishin_Day._Live.HaishinClean();
				SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Scenario_loop1_day0_night_AfterHaisin>();
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
		title = NgoEx.TenTalk("Haisin_Day0_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Day0haisin_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_angel"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso013", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Haisin_Day0_Chou013", _lang), "stream_cho_nyo", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Day0haisin_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso016", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Haisin_Day0_Chou014", _lang), "stream_cho_dokuzetsu_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Day0haisin_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Day0haisin_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso027", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso029", _lang)));
	}

	[AsyncStateMachine(typeof(_003CStartScenario_003Ed__1))]
	public override UniTask StartScenario()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CStartScenario_003Ed__1 _003CStartScenario_003Ed__2 = default(_003CStartScenario_003Ed__1);
		_003CStartScenario_003Ed__2._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CStartScenario_003Ed__2._003C_003E4__this = this;
		_003CStartScenario_003Ed__2._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CStartScenario_003Ed__2._003C_003Et__builder)).Start<_003CStartScenario_003Ed__1>(ref _003CStartScenario_003Ed__2);
		return ((AsyncUniTaskMethodBuilder)(ref _003CStartScenario_003Ed__2._003C_003Et__builder)).Task;
	}
}
