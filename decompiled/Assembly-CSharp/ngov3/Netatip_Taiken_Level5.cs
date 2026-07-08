using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;

namespace ngov3;

public class Netatip_Taiken_Level5 : LiveScenario
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartScenario_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Netatip_Taiken_Level5 _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Netatip_Taiken_Level5 netatip_Taiken_Level = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					AudioManager.Instance.PlayBgmByType(SoundType.BGM_endng_normal, isLoop: true);
					UniTask val = ((LiveScenario)netatip_Taiken_Level).StartScenario();
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
				netatip_Taiken_Level._Live.EndHaishin();
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
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Taiken5_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan1", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan2", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan3", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan4", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou015", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan5", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso036", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso038", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou020", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan4", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou021", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan6", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso039", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso040", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso041", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso042", _lang)));
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
