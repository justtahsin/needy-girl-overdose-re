using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class Test_ShowAllJine : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Test_ShowAllJine _003C_003E4__this;

		private List<JineType> _003Cjines_003E5__2;

		private int _003Cindex_003E5__3;

		private List<JineType>.Enumerator _003C_003E7__wrap3;

		private JineType _003CValue_003E5__5;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Test_ShowAllJine test_ShowAllJine = _003C_003E4__this;
			try
			{
				if (num != 0)
				{
					Debug.Log((object)"Test_ShowAllJine");
					JineView2D jineView2D = null;
					DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<long>(Observable.Interval(TimeSpan.FromMilliseconds(1000.0)), (Action<long>)delegate
					{
						if ((Object)(object)jineView2D == (Object)null)
						{
							jineView2D = Object.FindObjectOfType<JineView2D>();
						}
						jineView2D?.OnPicked();
					}), (Component)(object)SingletonMonoBehaviour<JineManager>.Instance);
					_003Cjines_003E5__2 = new List<JineType>();
					IEnumerator enumerator = Enum.GetValues(typeof(JineType)).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							JineType item = (JineType)enumerator.Current;
							_003Cjines_003E5__2.Add(item);
						}
					}
					finally
					{
						if (num < 0 && enumerator is IDisposable disposable)
						{
							disposable.Dispose();
						}
					}
					_003Cjines_003E5__2 = _003Cjines_003E5__2.OrderBy((JineType j) => j.ToString()).ToList();
					_003Cindex_003E5__3 = 0;
					_003C_003E7__wrap3 = _003Cjines_003E5__2.GetEnumerator();
				}
				try
				{
					if (num != 0)
					{
						goto IL_0260;
					}
					Awaiter val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01ee;
					IL_01ee:
					((Awaiter)(ref val)).GetResult();
					Debug.Log((object)(_003Cindex_003E5__3 + "/" + _003Cjines_003E5__2.Count + "/" + _003CValue_003E5__5));
					_003Cindex_003E5__3++;
					goto IL_0260;
					IL_0260:
					if (_003C_003E7__wrap3.MoveNext())
					{
						_003CValue_003E5__5 = _003C_003E7__wrap3.Current;
						if (_003Cindex_003E5__3 % 10 == 0)
						{
							SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(_003Cindex_003E5__3 + "/" + Enum.GetValues(typeof(JineType)).Length);
						}
						Debug.Log((object)("作成開始：" + _003CValue_003E5__5));
						UniTask val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(_003CValue_003E5__5);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
							return;
						}
						goto IL_01ee;
					}
				}
				finally
				{
					if (num < 0)
					{
						((IDisposable)_003C_003E7__wrap3/*cast due to constrained. prefix*/).Dispose();
					}
				}
				_003C_003E7__wrap3 = default(List<JineType>.Enumerator);
				SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator("AllJineList End");
				SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
				test_ShowAllJine.endEvent();
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cjines_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cjines_003E5__2 = null;
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
	}

	[AsyncStateMachine(typeof(_003CstartEvent_003Ed__1))]
	public override UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CstartEvent_003Ed__1 _003CstartEvent_003Ed__2 = default(_003CstartEvent_003Ed__1);
		_003CstartEvent_003Ed__2._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartEvent_003Ed__2._003C_003E4__this = this;
		_003CstartEvent_003Ed__2._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__2._003C_003Et__builder)).Start<_003CstartEvent_003Ed__1>(ref _003CstartEvent_003Ed__2);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__2._003C_003Et__builder)).Task;
	}
}
