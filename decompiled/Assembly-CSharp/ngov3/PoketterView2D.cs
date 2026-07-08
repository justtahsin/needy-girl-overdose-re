using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using Rewired;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class PoketterView2D : MonoBehaviour, IApp2D, IScrollable2D, IClickable, IStorable
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSpawnTweetAll_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterView2D _003C_003E4__this;

		private Awaiter<int> _003C_003Eu__1;

		private Awaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterView2D poketterView2D = _003C_003E4__this;
			try
			{
				Awaiter val;
				if (num != 0)
				{
					if (num != 1)
					{
						goto IL_0155;
					}
					val = _003C_003Eu__2;
					_003C_003Eu__2 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_014e;
				}
				Awaiter<int> val2 = _003C_003Eu__1;
				_003C_003Eu__1 = default(Awaiter<int>);
				num = (_003C_003E1__state = -1);
				goto IL_00ca;
				IL_014e:
				((Awaiter)(ref val)).GetResult();
				goto IL_0155;
				IL_0155:
				if (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count >= 1)
				{
					val2 = UniTask.WhenAny((UniTask[])(object)new UniTask[2]
					{
						UniTask.Delay(Constants.FAST, false, (PlayerLoopTiming)8, UniTaskCancellationExtensions.GetCancellationTokenOnDestroy((MonoBehaviour)(object)poketterView2D), false),
						UniTask.WaitUntil((Func<bool>)(() => Input.GetMouseButtonDown(0) || Player.GetButtonDown("Click")), (PlayerLoopTiming)8, UniTaskCancellationExtensions.GetCancellationTokenOnDestroy((MonoBehaviour)(object)poketterView2D), false)
					}).GetAwaiter();
					if (!val2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<int>, _003CSpawnTweetAll_003Ed__32>(ref val2, ref this);
						return;
					}
					goto IL_00ca;
				}
				SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value = false;
				goto end_IL_000e;
				IL_00ca:
				val2.GetResult();
				TweetData tw = SingletonMonoBehaviour<PoketterManager>.Instance.AddHistoryFromQueue();
				if (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count == 0)
				{
					poketterView2D.ShowLoading(isShow: false);
				}
				UniTask val3 = poketterView2D.shootTweetOne(tw);
				val = ((UniTask)(ref val3)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CSpawnTweetAll_003Ed__32>(ref val, ref this);
					return;
				}
				goto IL_014e;
				end_IL_000e:;
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CshootTweetAll_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterView2D _003C_003E4__this;

		private void MoveNext()
		{
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			PoketterView2D poketterView2D = _003C_003E4__this;
			try
			{
				if (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count != 0 && !SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value && !poketterView2D._stopLoading)
				{
					SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value = true;
					poketterView2D.ShowLoading(isShow: true);
					UniTaskExtensions.Forget(poketterView2D.SpawnTweetAll());
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CshootTweetOne_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterView2D _003C_003E4__this;

		public TweetData tw;

		private PoketterCell2D _003Ccell_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterView2D poketterView2D = _003C_003E4__this;
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
						goto IL_0167;
					}
					_003Ccell_003E5__2 = Object.Instantiate<PoketterCell2D>(poketterView2D._tweetPrefab, ((Component)poketterView2D._Waku).transform);
					TweetDrawable data = new TweetDrawable(tw);
					Debug.Log((object)$"<color=green>{tw.Type}:{data.BodyJp}</color>");
					val2 = _003Ccell_003E5__2.SetData(data);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CshootTweetOne_003Ed__30>(ref val, ref this);
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
				((Component)_003Ccell_003E5__2).transform.SetAsFirstSibling();
				poketterView2D._loading.transform.SetAsFirstSibling();
				poketterView2D._tweetCells.Add(_003Ccell_003E5__2);
				AudioManager.Instance.PlaySeByType(SoundType.SE_tweet_load);
				val2 = _003Ccell_003E5__2.Animate();
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CshootTweetOne_003Ed__30>(ref val, ref this);
					return;
				}
				goto IL_0167;
				IL_0167:
				((Awaiter)(ref val)).GetResult();
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Ccell_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Ccell_003E5__2 = null;
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
	private TMP_Text logo;

	[SerializeField]
	private PoketterCell2D _tweetPrefab;

	[SerializeField]
	private RectTransform _Waku;

	[SerializeField]
	private GameObject _loading;

	[SerializeField]
	private Button _newTweets;

	[SerializeField]
	private TMP_Text _newTweetsText;

	[SerializeField]
	private ScrollRect _scrollRect;

	[SerializeField]
	private TMP_Text _Header;

	[SerializeField]
	private TMP_Text _Desc;

	private IDisposable disposable;

	private CancellationTokenSource c = new CancellationTokenSource();

	[SerializeField]
	private RewiredScrollReceiver rewiredScrollReceiver;

	private List<PoketterCell2D> _tweetCells = new List<PoketterCell2D>();

	private bool _stopLoading = true;

	private static Player _player;

	public ScrollRect ScrollRect => _scrollRect;

	public RewiredScrollReceiver RewiredScrollReceiver => rewiredScrollReceiver;

	private static Player Player
	{
		get
		{
			if (_player == null)
			{
				_player = ReInput.players.GetPlayer(0);
			}
			return _player;
		}
	}

	public void Start()
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		foreach (TweetData item in SingletonMonoBehaviour<PoketterManager>.Instance.GetNewest())
		{
			MakeTweet(item, 0);
		}
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<TweetData>>(SingletonMonoBehaviour<PoketterManager>.Instance.OnAddQueue, (Action<CollectionAddEvent<TweetData>>)delegate
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			ShowLoading(isShow: true);
			shootTweetAll();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionRemoveEvent<TweetData>>(SingletonMonoBehaviour<PoketterManager>.Instance.OnRemoveQueue, (Action<CollectionRemoveEvent<TweetData>>)delegate
		{
			ShowLoading(((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count != 0);
		}), ((Component)this).gameObject);
		if (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count > 0)
		{
			ShowLoading(isShow: true);
			shootTweetAll();
		}
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(Observable.Where<bool>((IObservable<bool>)SingletonMonoBehaviour<PoketterManager>.Instance.isBlocked, (Func<bool, bool>)((bool v) => v)), (Action<bool>)delegate
		{
			showBlockMode();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(Observable.Where<bool>((IObservable<bool>)SingletonMonoBehaviour<PoketterManager>.Instance.isDeleted, (Func<bool, bool>)((bool v) => v)), (Action<bool>)delegate
		{
			showDeleteMode();
		}), ((Component)this).gameObject);
	}

	public void OnPicked()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = ((Component)_Waku).transform;
		Vector3 localPosition = transform.localPosition;
		localPosition.y = 0f;
		transform.localPosition = localPosition;
		int num = _tweetCells.Count - SingletonMonoBehaviour<PoketterManager>.Instance.TweetCountOnLoad;
		if (num > 0)
		{
			List<PoketterCell2D> range = _tweetCells.GetRange(0, num);
			_tweetCells.RemoveRange(0, num);
			foreach (PoketterCell2D item in range)
			{
				Object.Destroy((Object)(object)((Component)item).gameObject);
			}
		}
		_stopLoading = false;
		if (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count > 0)
		{
			ShowLoading(isShow: true);
			shootTweetAll();
		}
	}

	public void OnStored()
	{
		_stopLoading = true;
	}

	private void ShowLoading(bool isShow)
	{
		_loading.SetActive(isShow);
	}

	private void showBlockMode()
	{
		_Header.text = NgoEx.SystemTextFromType(SystemTextType.Poketter_Blocked_Header, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_Desc.text = NgoEx.SystemTextFromType(SystemTextType.Poketter_Blocked_Description, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		((Component)_scrollRect).gameObject.SetActive(false);
		((Component)_Header).gameObject.SetActive(true);
		((Component)_Desc).gameObject.SetActive(true);
	}

	private void showDeleteMode()
	{
		_Header.text = NgoEx.SystemTextFromType(SystemTextType.Poketter_Deleted_Header, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_Desc.text = NgoEx.SystemTextFromType(SystemTextType.Poketter_Deleteded_Description, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		((Component)_scrollRect).gameObject.SetActive(false);
		((Component)_Header).gameObject.SetActive(true);
		((Component)_Desc).gameObject.SetActive(true);
	}

	public void MakeTweet(TweetData data, int page)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		TweetDrawable dataStatic = new TweetDrawable(data);
		PoketterCell2D poketterCell2D = Object.Instantiate<PoketterCell2D>(_tweetPrefab, ((Component)_Waku).transform);
		poketterCell2D.SetDataStatic(dataStatic);
		((Component)poketterCell2D).transform.SetAsFirstSibling();
		_loading.transform.SetAsFirstSibling();
		_tweetCells.Add(poketterCell2D);
	}

	public void LoadTweet(int start, int end)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		foreach (TweetData item in SingletonMonoBehaviour<PoketterManager>.Instance.GetHistoryRange(start, end))
		{
			TweetDrawable dataStatic = new TweetDrawable(item);
			PoketterCell2D poketterCell2D = Object.Instantiate<PoketterCell2D>(_tweetPrefab, ((Component)_Waku).transform);
			poketterCell2D.SetDataStatic(dataStatic);
			((Component)poketterCell2D).transform.SetAsLastSibling();
			_tweetCells.Add(poketterCell2D);
		}
	}

	public void shootTweet()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		TweetDrawable data = new TweetDrawable(SingletonMonoBehaviour<PoketterManager>.Instance.AddHistoryFromQueue());
		PoketterCell2D poketterCell2D = Object.Instantiate<PoketterCell2D>(_tweetPrefab, ((Component)_Waku).transform);
		poketterCell2D.SetData(data);
		((Component)poketterCell2D).transform.SetAsFirstSibling();
		_loading.transform.SetAsFirstSibling();
		_tweetCells.Add(poketterCell2D);
		AudioManager.Instance.PlaySeByType(SoundType.SE_tweet_load);
		poketterCell2D.Animate();
	}

	[AsyncStateMachine(typeof(_003CshootTweetOne_003Ed__30))]
	public UniTask shootTweetOne(TweetData tw)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CshootTweetOne_003Ed__30 _003CshootTweetOne_003Ed__31 = default(_003CshootTweetOne_003Ed__30);
		_003CshootTweetOne_003Ed__31._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CshootTweetOne_003Ed__31._003C_003E4__this = this;
		_003CshootTweetOne_003Ed__31.tw = tw;
		_003CshootTweetOne_003Ed__31._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CshootTweetOne_003Ed__31._003C_003Et__builder)).Start<_003CshootTweetOne_003Ed__30>(ref _003CshootTweetOne_003Ed__31);
		return ((AsyncUniTaskMethodBuilder)(ref _003CshootTweetOne_003Ed__31._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CshootTweetAll_003Ed__31))]
	public UniTask shootTweetAll(CancellationTokenSource c = null)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CshootTweetAll_003Ed__31 _003CshootTweetAll_003Ed__32 = default(_003CshootTweetAll_003Ed__31);
		_003CshootTweetAll_003Ed__32._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CshootTweetAll_003Ed__32._003C_003E4__this = this;
		_003CshootTweetAll_003Ed__32._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CshootTweetAll_003Ed__32._003C_003Et__builder)).Start<_003CshootTweetAll_003Ed__31>(ref _003CshootTweetAll_003Ed__32);
		return ((AsyncUniTaskMethodBuilder)(ref _003CshootTweetAll_003Ed__32._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSpawnTweetAll_003Ed__32))]
	private UniTask SpawnTweetAll()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CSpawnTweetAll_003Ed__32 _003CSpawnTweetAll_003Ed__33 = default(_003CSpawnTweetAll_003Ed__32);
		_003CSpawnTweetAll_003Ed__33._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CSpawnTweetAll_003Ed__33._003C_003E4__this = this;
		_003CSpawnTweetAll_003Ed__33._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CSpawnTweetAll_003Ed__33._003C_003Et__builder)).Start<_003CSpawnTweetAll_003Ed__32>(ref _003CSpawnTweetAll_003Ed__33);
		return ((AsyncUniTaskMethodBuilder)(ref _003CSpawnTweetAll_003Ed__33._003C_003Et__builder)).Task;
	}

	public void Click()
	{
	}

	public void SetSortOrder(int order)
	{
	}
}
