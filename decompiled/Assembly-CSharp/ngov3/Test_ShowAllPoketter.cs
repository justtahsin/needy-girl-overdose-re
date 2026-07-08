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
using UniRx;
using UnityEngine;

namespace ngov3;

public class Test_ShowAllPoketter : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Test_ShowAllPoketter _003C_003E4__this;

		private List<TweetType> _003CtweetList_003E5__2;

		private int _003Cindex_003E5__3;

		private List<TweetType>.Enumerator _003C_003E7__wrap3;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Test_ShowAllPoketter test_ShowAllPoketter = _003C_003E4__this;
			try
			{
				if (num != 0)
				{
					PoketterView2D pketterView2D = null;
					DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<long>(Observable.Interval(TimeSpan.FromMilliseconds(1000.0)), (Action<long>)delegate
					{
						if ((Object)(object)pketterView2D == (Object)null)
						{
							pketterView2D = Object.FindObjectOfType<PoketterView2D>();
						}
						pketterView2D?.OnPicked();
					}), (Component)(object)SingletonMonoBehaviour<PoketterManager>.Instance);
					_003CtweetList_003E5__2 = new List<TweetType>();
					IEnumerator enumerator = Enum.GetValues(typeof(TweetType)).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							TweetType item = (TweetType)enumerator.Current;
							_003CtweetList_003E5__2.Add(item);
						}
					}
					finally
					{
						if (num < 0 && enumerator is IDisposable disposable)
						{
							disposable.Dispose();
						}
					}
					_003CtweetList_003E5__2 = _003CtweetList_003E5__2.OrderBy((TweetType t) => t.ToString()).ToList();
					_003Cindex_003E5__3 = 0;
					SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet("AllTweet Start");
					_003C_003E7__wrap3 = _003CtweetList_003E5__2.GetEnumerator();
				}
				try
				{
					if (num != 0)
					{
						goto IL_024e;
					}
					Awaiter val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0247;
					IL_0247:
					((Awaiter)(ref val)).GetResult();
					goto IL_024e;
					IL_024e:
					while (_003C_003E7__wrap3.MoveNext())
					{
						TweetType current = _003C_003E7__wrap3.Current;
						if (current == TweetType.None)
						{
							continue;
						}
						if (_003Cindex_003E5__3 % 5 == 0)
						{
							SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(_003Cindex_003E5__3 + "/" + _003CtweetList_003E5__2.Count);
						}
						Debug.Log((object)("AddTweet:" + _003Cindex_003E5__3 + "/" + _003CtweetList_003E5__2.Count));
						try
						{
							SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(current);
						}
						catch (Exception ex)
						{
							Debug.LogError((object)("Error発生" + ex.ToString()));
						}
						_003Cindex_003E5__3++;
						UniTask val2 = UniTask.Delay(Constants.MIDDLE, false, (PlayerLoopTiming)8, default(CancellationToken), false);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__1>(ref val, ref this);
							return;
						}
						goto IL_0247;
					}
				}
				finally
				{
					if (num < 0)
					{
						((IDisposable)_003C_003E7__wrap3/*cast due to constrained. prefix*/).Dispose();
					}
				}
				_003C_003E7__wrap3 = default(List<TweetType>.Enumerator);
				SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet("AllTweet End");
				test_ShowAllPoketter.endEvent();
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003CtweetList_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CtweetList_003E5__2 = null;
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
