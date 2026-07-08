using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;

namespace ngov3;

public class Netatip_Angel_Level3 : LiveScenario
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartScenario_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Netatip_Angel_Level3 _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Netatip_Angel_Level3 netatip_Angel_Level = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
					UniTask val = ((LiveScenario)netatip_Angel_Level).StartScenario();
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
				netatip_Angel_Level._Live.EndHaishin();
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
		title = NgoEx.TenTalk("Angel3_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_fever"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pray"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou015", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso036", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou018", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso038", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso039", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso040", _lang)));
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
