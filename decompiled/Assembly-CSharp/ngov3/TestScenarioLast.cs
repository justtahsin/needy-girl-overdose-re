using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace ngov3;

public class TestScenarioLast : LiveScenario
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartScenario_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public TestScenarioLast _003C_003E4__this;

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
			TestScenarioLast testScenarioLast = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					UniTask val = ((LiveScenario)testScenarioLast).StartScenario();
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
				testScenarioLast._Live.EndHaishin();
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
		playing.Add(new Playing(isJimaku: true, "プチ裏技紹介しちゃおうかな"));
		playing.Add(new Playing(isJimaku: false, "えっっマジで？", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "ワクワクテカテカ"));
		playing.Add(new Playing(isJimaku: false, "裏技なんてあったのか", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "教えてほしーー", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: false, "どうせ何も無いだろ", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "めっちゃやり込んでる！", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: true, "伝説の木の下であるコマンドを押すと…"));
		playing.Add(new Playing(isJimaku: false, "何なに！？", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "知りたいよ〜〜！", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: false, "ドキドキドキ……", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "もったいぶるなカス", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "それ攻略本にも載ってないやつ？", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: true, "親友の妹隠しルートが出るんだよ"));
		playing.Add(new Playing(isJimaku: false, "マ？"));
		playing.Add(new Playing(isJimaku: false, "ほんと！？", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "これは良いこと聞いた", StatusType.Tension, 4));
		playing.Add(new Playing(isJimaku: false, "いやお前ら騙されんなよ", StatusType.Tension, -10));
		playing.Add(new Playing(isJimaku: false, "SUGEEEEEEEEEE", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: false, "それは知らなかった", StatusType.Tension, 2));
		playing.Add(new Playing(isJimaku: false, "親友の妹キメさせてぇ〜〜", StatusType.Tension, 5));
		playing.Add(new Playing(isJimaku: false, "さすが超てんちゃん！！", StatusType.Tension, 3));
		playing.Add(new Playing(isJimaku: true, "それじゃ今日はこの辺で！†昇天†"));
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
