using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace ngov3;

public class Netatip_Gamejikkyou_Level4 : LiveScenario
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartScenario_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Netatip_Gamejikkyou_Level4 _003C_003E4__this;

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
			Netatip_Gamejikkyou_Level4 netatip_Gamejikkyou_Level = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					UniTask val = ((LiveScenario)netatip_Gamejikkyou_Level).StartScenario();
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartScenario_003Ed__1>(ref val2, ref this);
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
				netatip_Gamejikkyou_Level._Live.EndHaishin();
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
		title = NgoEx.TenTalk("Gamejikkyou4_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_twilight1"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_twilight2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Gamejikkyou4_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_twilight3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso031", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou4_Chou016", _lang), "stream_cho_game_twilight8", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_twilight4"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_twilight5", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso025", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou4_Chou013", _lang), "stream_cho_game_twilight3"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_twilight6", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso030", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou4_Chou015", _lang), "stream_cho_game_twilight7", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso028", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou4_Chou014", _lang), "stream_cho_game_twilight3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso029", _lang)));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
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
