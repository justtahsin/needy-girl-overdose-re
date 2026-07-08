using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace ngov3;

public class TestScenario3 : LiveScenario
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartScenario_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public TestScenario3 _003C_003E4__this;

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
			TestScenario3 testScenario = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					UniTask val = ((LiveScenario)testScenario).StartScenario();
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
				testScenario._Live.EndHaishin();
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
		playing.Add(new Playing(isJimaku: true, "ジェルばんは..."));
		playing.Add(new Playing(isJimaku: false, "ジェルばんは！"));
		playing.Add(new Playing(isJimaku: false, "ジェルばん〜", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "どうしたの？"));
		playing.Add(new Playing(isJimaku: false, "元気無いね", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: true, "闇闇闇闇闇誰もみるな闇病み"));
		playing.Add(new Playing(isJimaku: false, "何があったの！？"));
		playing.Add(new Playing(isJimaku: false, "それでも顔は良い"));
		playing.Add(new Playing(isJimaku: false, "可哀想な天使様。。"));
		playing.Add(new Playing(isJimaku: false, "かまってちゃんだな", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "泣きそう"));
		playing.Add(new Playing(isJimaku: false, "慰めてあげたい"));
		playing.Add(new Playing(isJimaku: false, "可哀想で泣けてきた"));
		playing.Add(new Playing(isJimaku: false, "どうせ嘘", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "病んでも顔良すぎない？"));
		playing.Add(new Playing(isJimaku: false, "堕天使じゃん"));
		playing.Add(new Playing(isJimaku: false, "チャンネル登録しました", StatusType.Tension, 5));
		playing.Add(new Playing(isJimaku: true, "みるなみるなみるなみるなみるな"));
		playing.Add(new Playing(isJimaku: false, "そんなこと言わないで", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: false, "筋トレしよう", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "降臨してくれてありがとう！！"));
		playing.Add(new Playing(isJimaku: false, "どこまでもついていくよ"));
		playing.Add(new Playing(isJimaku: false, "涙で画面見えない"));
		playing.Add(new Playing(isJimaku: false, "チャンネル登録しました", StatusType.Tension, 5));
		playing.Add(new Playing(isJimaku: false, "キモ。コミュ抜けるわ", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "私も生きるから頑張ろう；；"));
		playing.Add(new Playing(isJimaku: true, "堕天するわ……†昇天†"));
		playing.Add(new Playing(isJimaku: false, "†昇天†", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "†昇天†", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "†昇天†", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "†昇天†", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "†昇天†", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "†昇天†", StatusType.Tension, 0));
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
