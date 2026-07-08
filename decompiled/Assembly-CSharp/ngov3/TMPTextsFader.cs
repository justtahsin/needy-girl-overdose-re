using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class TMPTextsFader : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003COnChangeAlpha_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public TMPTextsFader _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			TMPTextsFader tMPTextsFader = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					YieldAwaitable val = UniTask.WaitForEndOfFrame();
					val2 = ((YieldAwaitable)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnChangeAlpha_003Ed__5>(ref val2, ref this);
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
				List<TMP_Text>.Enumerator enumerator = tMPTextsFader._tmpTexts.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						TMP_Text current = enumerator.Current;
						Color color = ((Graphic)current).color;
						color.a = tMPTextsFader._alpha;
						((Graphic)current).color = color;
					}
				}
				finally
				{
					if (num < 0)
					{
						((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
					}
				}
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
	private List<TMP_Text> _tmpTexts = new List<TMP_Text>();

	[Range(0f, 1f)]
	[SerializeField]
	private float _alpha = 1f;

	public float Alpha
	{
		get
		{
			return _alpha;
		}
		set
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			_alpha = value;
			foreach (TMP_Text tmpText in _tmpTexts)
			{
				Color color = ((Graphic)tmpText).color;
				color.a = _alpha;
				((Graphic)tmpText).color = color;
			}
		}
	}

	[AsyncStateMachine(typeof(_003COnChangeAlpha_003Ed__5))]
	private UniTask OnChangeAlpha()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003COnChangeAlpha_003Ed__5 _003COnChangeAlpha_003Ed__6 = default(_003COnChangeAlpha_003Ed__5);
		_003COnChangeAlpha_003Ed__6._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003COnChangeAlpha_003Ed__6._003C_003E4__this = this;
		_003COnChangeAlpha_003Ed__6._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003COnChangeAlpha_003Ed__6._003C_003Et__builder)).Start<_003COnChangeAlpha_003Ed__5>(ref _003COnChangeAlpha_003Ed__6);
		return ((AsyncUniTaskMethodBuilder)(ref _003COnChangeAlpha_003Ed__6._003C_003Et__builder)).Task;
	}
}
