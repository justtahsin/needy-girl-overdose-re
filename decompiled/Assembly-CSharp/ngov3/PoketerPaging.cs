using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class PoketerPaging : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CpagingNext_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketerPaging _003C_003E4__this;

		private GameObject _003Cloading_003E5__2;

		private int _003CneedLoad_003E5__3;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketerPaging poketerPaging = _003C_003E4__this;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0164;
				}
				if (poketerPaging._thisTrans.childCount > poketerPaging.MAXPOSTS && poketerPaging.isBacking)
				{
					if (poketerPaging.showingNewestIndex >= poketerPaging._thisTrans.childCount - 1)
					{
						poketerPaging.isBacking = false;
					}
					else if (!poketerPaging.isloading)
					{
						poketerPaging.isloading = true;
						_003Cloading_003E5__2 = Object.Instantiate<GameObject>(poketerPaging.loadingPrefab, poketerPaging._thisTrans);
						_003Cloading_003E5__2.transform.SetAsLastSibling();
						_003CneedLoad_003E5__3 = Math.Min(poketerPaging.PAGINGPOSTS, poketerPaging.showingNewestIndex + poketerPaging.PAGINGPOSTS - (poketerPaging._thisTrans.childCount - 1));
						poketerPaging.showingNewestIndex = Math.Min(poketerPaging.showingNewestIndex + poketerPaging.PAGINGPOSTS, poketerPaging._thisTrans.childCount - 1);
						poketerPaging.showingOldestIndex = Math.Max(poketerPaging.showingNewestIndex - poketerPaging.MAXPOSTS, 0);
						UniTask val2 = UniTask.Delay(20, false, (PlayerLoopTiming)8, default(CancellationToken), false);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CpagingNext_003Ed__12>(ref val, ref this);
							return;
						}
						goto IL_0164;
					}
				}
				goto end_IL_000e;
				IL_0164:
				((Awaiter)(ref val)).GetResult();
				Object.Destroy((Object)(object)_003Cloading_003E5__2);
				poketerPaging.ShowRange(poketerPaging.showingOldestIndex, poketerPaging.showingNewestIndex);
				if (_003CneedLoad_003E5__3 > 0)
				{
					ScrollRect scrollRect = poketerPaging._scrollRect;
					scrollRect.verticalNormalizedPosition += 0.01f * (float)_003CneedLoad_003E5__3;
				}
				poketerPaging.loadAtLast = false;
				poketerPaging.isloading = false;
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cloading_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cloading_003E5__2 = null;
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CpagingPrev_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketerPaging _003C_003E4__this;

		private GameObject _003Cloading_003E5__2;

		private int _003CneedLoad_003E5__3;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketerPaging poketerPaging = _003C_003E4__this;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_013d;
				}
				if (poketerPaging._thisTrans.childCount > poketerPaging.MAXPOSTS && !poketerPaging.isloading && !poketerPaging.loadAtLast)
				{
					poketerPaging.isloading = true;
					_003Cloading_003E5__2 = Object.Instantiate<GameObject>(poketerPaging.loadingPrefab, poketerPaging._thisTrans);
					_003Cloading_003E5__2.transform.SetAsFirstSibling();
					poketerPaging.isBacking = true;
					_003CneedLoad_003E5__3 = poketerPaging.showingOldestIndex - poketerPaging.PAGINGPOSTS;
					if (_003CneedLoad_003E5__3 < 0)
					{
						poketerPaging.showingOldestIndex = 0;
					}
					else
					{
						poketerPaging.showingOldestIndex -= poketerPaging.PAGINGPOSTS;
					}
					poketerPaging.showingNewestIndex = Math.Min(poketerPaging.showingOldestIndex + poketerPaging.MAXPOSTS, poketerPaging._thisTrans.childCount - 1);
					UniTask val2 = UniTask.Delay(20, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CpagingPrev_003Ed__13>(ref val, ref this);
						return;
					}
					goto IL_013d;
				}
				goto end_IL_000e;
				IL_013d:
				((Awaiter)(ref val)).GetResult();
				Object.Destroy((Object)(object)_003Cloading_003E5__2);
				poketerPaging.ShowRange(poketerPaging.showingOldestIndex, poketerPaging.showingNewestIndex);
				if (_003CneedLoad_003E5__3 > 0)
				{
					ScrollRect scrollRect = poketerPaging._scrollRect;
					scrollRect.verticalNormalizedPosition -= 0.01f * (float)Math.Min(_003CneedLoad_003E5__3, poketerPaging.PAGINGPOSTS);
				}
				if (_003CneedLoad_003E5__3 < 0)
				{
					poketerPaging._poketter.LoadTweet(poketerPaging._thisTrans.childCount, poketerPaging._thisTrans.childCount - _003CneedLoad_003E5__3);
					poketerPaging.loadAtLast = true;
				}
				poketerPaging.isloading = false;
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cloading_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cloading_003E5__2 = null;
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

	private int MAXPOSTS = 50;

	private int PAGINGPOSTS = 10;

	[SerializeField]
	private ScrollRect _scrollRect;

	private Transform _thisTrans;

	[SerializeField]
	private PoketterView _poketter;

	[SerializeField]
	private int showingNewestIndex;

	[SerializeField]
	private int showingOldestIndex;

	[SerializeField]
	private bool isBacking;

	[SerializeField]
	private GameObject loadingPrefab;

	[SerializeField]
	private bool isloading;

	private bool loadAtLast;

	public void Awake()
	{
		showingNewestIndex = MAXPOSTS;
		_thisTrans = ((Component)this).gameObject.transform;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(ObserveExtensions.ObserveEveryValueChanged<Transform, int>(_thisTrans, (Func<Transform, int>)((Transform _thisTrans) => _thisTrans.childCount), (FrameCountType)0, false), (Action<int>)delegate
		{
			addNewPost();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.Where<float>(Observable.DistinctUntilChanged<float>(ObserveExtensions.ObserveEveryValueChanged<ScrollRect, float>(_scrollRect, (Func<ScrollRect, float>)((ScrollRect _scrollRect) => _scrollRect.verticalNormalizedPosition), (FrameCountType)0, false)), (Func<float, bool>)((float x) => x <= 0.01f)), (Action<float>)async delegate
		{
			await pagingNext();
		}), (Component)(object)_scrollRect);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.Where<float>(Observable.DistinctUntilChanged<float>(ObserveExtensions.ObserveEveryValueChanged<ScrollRect, float>(_scrollRect, (Func<ScrollRect, float>)((ScrollRect _scrollRect) => _scrollRect.verticalNormalizedPosition), (FrameCountType)0, false)), (Func<float, bool>)((float x) => x >= 0.99f)), (Action<float>)async delegate
		{
			await pagingPrev();
		}), (Component)(object)_scrollRect);
	}

	[AsyncStateMachine(typeof(_003CpagingNext_003Ed__12))]
	private UniTask pagingNext()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CpagingNext_003Ed__12 _003CpagingNext_003Ed__13 = default(_003CpagingNext_003Ed__12);
		_003CpagingNext_003Ed__13._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CpagingNext_003Ed__13._003C_003E4__this = this;
		_003CpagingNext_003Ed__13._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CpagingNext_003Ed__13._003C_003Et__builder)).Start<_003CpagingNext_003Ed__12>(ref _003CpagingNext_003Ed__13);
		return ((AsyncUniTaskMethodBuilder)(ref _003CpagingNext_003Ed__13._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CpagingPrev_003Ed__13))]
	private UniTask pagingPrev()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CpagingPrev_003Ed__13 _003CpagingPrev_003Ed__14 = default(_003CpagingPrev_003Ed__13);
		_003CpagingPrev_003Ed__14._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CpagingPrev_003Ed__14._003C_003E4__this = this;
		_003CpagingPrev_003Ed__14._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CpagingPrev_003Ed__14._003C_003Et__builder)).Start<_003CpagingPrev_003Ed__13>(ref _003CpagingPrev_003Ed__14);
		return ((AsyncUniTaskMethodBuilder)(ref _003CpagingPrev_003Ed__14._003C_003Et__builder)).Task;
	}

	private void ShowRange(int oldIndex, int newIndex)
	{
		if (_thisTrans.childCount <= newIndex)
		{
			newIndex = _thisTrans.childCount - 1;
		}
		for (int num = oldIndex; num >= 0; num--)
		{
			((Component)_thisTrans.GetChild(num)).gameObject.SetActive(false);
		}
		for (int i = oldIndex; i <= newIndex; i++)
		{
			((Component)_thisTrans.GetChild(i)).gameObject.SetActive(true);
		}
		for (int j = newIndex; j <= _thisTrans.childCount - 1; j++)
		{
			((Component)_thisTrans.GetChild(j)).gameObject.SetActive(false);
		}
	}

	private void addNewPost()
	{
		if (_thisTrans.childCount <= MAXPOSTS)
		{
			return;
		}
		if (isBacking)
		{
			((Component)_thisTrans.GetChild(_thisTrans.childCount - 1)).gameObject.SetActive(false);
			return;
		}
		showingNewestIndex++;
		showingOldestIndex = showingNewestIndex - MAXPOSTS;
		for (int i = 0; i < _thisTrans.childCount - MAXPOSTS; i++)
		{
			((Component)_thisTrans.GetChild(i)).gameObject.SetActive(false);
		}
	}
}
