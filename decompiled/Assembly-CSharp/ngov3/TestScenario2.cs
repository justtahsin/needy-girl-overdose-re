using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace ngov3;

public class TestScenario2 : LiveScenario
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartScenario_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public TestScenario2 _003C_003E4__this;

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
			TestScenario2 testScenario = _003C_003E4__this;
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
		playing.Add(new Playing(isJimaku: true, "ジェルばんは！"));
		playing.Add(new Playing(isJimaku: false, "ジェルばんは！"));
		playing.Add(new Playing(isJimaku: false, "初見です", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "かわいい"));
		playing.Add(new Playing(isJimaku: false, "良い感じじゃん", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: true, "今日はいつもより一段と超絶可愛いでしょ？でしょ？？"));
		playing.Add(new Playing(isJimaku: false, "待ってたよ！"));
		playing.Add(new Playing(isJimaku: false, "今日も顔が良い"));
		playing.Add(new Playing(isJimaku: false, "私の天使さま。。。"));
		playing.Add(new Playing(isJimaku: false, "は？なんて？", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "いい感じ〜〜"));
		playing.Add(new Playing(isJimaku: false, "こんな可愛い顔初めて…"));
		playing.Add(new Playing(isJimaku: false, "感動で泣けてきた"));
		playing.Add(new Playing(isJimaku: false, "どうせ整形", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "顔良すぎない？"));
		playing.Add(new Playing(isJimaku: false, "ガチの天使じゃん"));
		playing.Add(new Playing(isJimaku: false, "チャンネル登録しました", StatusType.Tension, 5));
		playing.Add(new Playing(isJimaku: true, "今日もあたいの顔面でゆっくりしていってね"));
		playing.Add(new Playing(isJimaku: false, "1日の疲れが吹っ飛んだ", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: false, "そうだね、筋肉だね", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "降臨してくれてありがとう！！"));
		playing.Add(new Playing(isJimaku: false, "どこまでもついていくよ"));
		playing.Add(new Playing(isJimaku: false, "まぶしくて画面見えない"));
		playing.Add(new Playing(isJimaku: false, "チャンネル登録しました", StatusType.Tension, 5));
		playing.Add(new Playing(isJimaku: false, "ぶっさコミュ抜けるわ", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "生きててくれてありがとう；；私も生きるね"));
		playing.Add(new Playing(isJimaku: true, "今日もありがと！†昇天†"));
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
