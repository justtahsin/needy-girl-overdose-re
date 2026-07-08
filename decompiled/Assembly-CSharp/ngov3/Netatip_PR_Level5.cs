using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;

namespace ngov3;

public class Netatip_PR_Level5 : LiveScenario
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartScenario_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Netatip_PR_Level5 _003C_003E4__this;

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
			Netatip_PR_Level5 netatip_PR_Level = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_kenjo, isLoop: true);
					UniTask val = ((LiveScenario)netatip_PR_Level).StartScenario();
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
				netatip_PR_Level._Live.EndHaishin();
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
		title = NgoEx.TenTalk("PR5_Chou001", _lang);
		_Live.isOiwai = true;
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business1"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business4"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business5"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business6"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business7"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business8"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business9"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business10"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou013", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou014", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_superchat"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou015", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing"));
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
