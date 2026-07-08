using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace ngov3;

public class TestScenarioMiddle : LiveScenario
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartScenario_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public TestScenarioMiddle _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			TestScenarioMiddle testScenarioMiddle = _003C_003E4__this;
			try
			{
				Awaiter val;
				UniTask val2;
				if (num != 0)
				{
					if (num == 1)
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00e0;
					}
					val2 = ((LiveScenario)testScenarioMiddle).StartScenario();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartScenario_003Ed__1>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val)).GetResult();
				testScenarioMiddle._Live.SetScenario<TestScenarioLast>();
				val2 = testScenarioMiddle._Live.NowPlaying.StartScenario();
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartScenario_003Ed__1>(ref val, ref this);
					return;
				}
				goto IL_00e0;
				IL_00e0:
				((Awaiter)(ref val)).GetResult();
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
		playing.Add(new Playing(isJimaku: true, "もっと盛り上げていこう"));
		playing.Add(new Playing(isJimaku: false, "可愛いよ超てんちゃん！", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "うおおおおおおおお", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "もっとサービスしろよ", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "キメキメ誰派？"));
		playing.Add(new Playing(isJimaku: true, "やっぱ生徒会長ルートだよね"));
		playing.Add(new Playing(isJimaku: false, "すご！", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "あの激ムズルート！？"));
		playing.Add(new Playing(isJimaku: false, "超マニアックなのもイイ！", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "嘘に決まってんじゃん", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "やるじゃん！"));
		playing.Add(new Playing(isJimaku: false, "え？どんなゲーム？", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "キメキメやってみたい〜"));
		playing.Add(new Playing(isJimaku: false, "生徒会長キメさせるのはやばい", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: true, "後輩ちゃんのストーリーも好きだよ"));
		playing.Add(new Playing(isJimaku: false, "わかる〜〜"));
		playing.Add(new Playing(isJimaku: false, "筋トレの話は？", StatusType.Tension, 0));
		playing.Add(new Playing(isJimaku: false, "きた！俺の推し！"));
		playing.Add(new Playing(isJimaku: false, "ニワカじゃん", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "漏れは弓道部の先輩派"));
		playing.Add(new Playing(isJimaku: false, "超てんちゃんと趣味合いそう"));
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
