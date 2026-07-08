using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class App_BankView : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CAwake_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public App_BankView _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			App_BankView app_BankView = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
					string text = "BankAnimation";
					if (value == LanguageType.CN || value == LanguageType.TW)
					{
						text = "BankAnimation_Chn";
					}
					switch (value)
					{
					case LanguageType.KO:
						text = "BankAnimation_Kor";
						break;
					case LanguageType.EN:
					case LanguageType.VN:
					case LanguageType.FR:
					case LanguageType.IT:
					case LanguageType.GE:
					case LanguageType.SP:
					case LanguageType.RU:
						text = "BankAnimation_Eng";
						break;
					}
					if ((SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Angel && SingletonMonoBehaviour<EventManager>.Instance.alphaLevel == 6) || SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_DarkAngel)
					{
						text += "_B";
					}
					app_BankView._anim.Play(text);
					YieldAwaitable val = UniTask.Yield();
					val2 = ((YieldAwaitable)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAwake_003Ed__7>(ref val2, ref this);
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

	[SerializeField]
	private Button cover;

	[SerializeField]
	private Animator _anim;

	private const string _animJp = "BankAnimation";

	private const string _animEn = "BankAnimation_Eng";

	private const string _animCn = "BankAnimation_Chn";

	private const string _animKo = "BankAnimation_Kor";

	private const string _black = "_B";

	[AsyncStateMachine(typeof(_003CAwake_003Ed__7))]
	public UniTask Awake()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CAwake_003Ed__7 _003CAwake_003Ed__8 = default(_003CAwake_003Ed__7);
		_003CAwake_003Ed__8._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CAwake_003Ed__8._003C_003E4__this = this;
		_003CAwake_003Ed__8._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CAwake_003Ed__8._003C_003Et__builder)).Start<_003CAwake_003Ed__7>(ref _003CAwake_003Ed__8);
		return ((AsyncUniTaskMethodBuilder)(ref _003CAwake_003Ed__8._003C_003Et__builder)).Task;
	}
}
