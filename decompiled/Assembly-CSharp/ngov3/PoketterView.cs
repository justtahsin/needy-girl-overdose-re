using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class PoketterView : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public PoketterView _003C_003E4__this;

		public CancellationTokenSource c;

		internal void _003CshootTweetAll_003Eb__0(Unit _)
		{
			_003C_003E4__this.disposable.Dispose();
			((MonoBehaviour)_003C_003E4__this).StopCoroutine("SpawnTweetAll");
			_003C_003E4__this.ShootTweetImmediate(c);
			_003C_003E4__this._loading.SetActive(false);
			SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value = false;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CshootTweetAll_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterView _003C_003E4__this;

		public CancellationTokenSource c;

		private _003C_003Ec__DisplayClass21_0 _003C_003E8__1;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterView poketterView = _003C_003E4__this;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00bf;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass21_0();
				_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				_003C_003E8__1.c = c;
				if (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count != 0)
				{
					UniTask val2 = UniTask.Delay(Constants.FAST, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CshootTweetAll_003Ed__21>(ref val, ref this);
						return;
					}
					goto IL_00bf;
				}
				goto end_IL_000e;
				IL_00bf:
				((Awaiter)(ref val)).GetResult();
				((Graphic)((Component)poketterView._gamen).gameObject.GetComponent<Text>()).raycastTarget = true;
				poketterView.disposable = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(poketterView._gamen), (Action<Unit>)delegate
				{
					_003C_003E8__1._003C_003E4__this.disposable.Dispose();
					((MonoBehaviour)_003C_003E8__1._003C_003E4__this).StopCoroutine("SpawnTweetAll");
					_003C_003E8__1._003C_003E4__this.ShootTweetImmediate(_003C_003E8__1.c);
					_003C_003E8__1._003C_003E4__this._loading.SetActive(false);
					SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value = false;
				}), ((Component)poketterView).gameObject);
				((MonoBehaviour)poketterView).StartCoroutine("SpawnTweetAll");
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
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
	private PoketterCell _tweetPrefab;

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

	[SerializeField]
	private Button _gamen;

	private CancellationTokenSource c = new CancellationTokenSource();

	public void Awake()
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		logo.text = ((SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN) ? "Tweeter" : "Poketter");
		((Graphic)((Component)_gamen).gameObject.GetComponent<Text>()).raycastTarget = false;
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
		TweetDrawable dataStatic = new TweetDrawable(data);
		PoketterCell poketterCell = Object.Instantiate<PoketterCell>(_tweetPrefab, ((Component)_Waku).transform);
		poketterCell.SetDataStatic(dataStatic);
		((Component)poketterCell).transform.SetAsFirstSibling();
		_loading.transform.SetAsFirstSibling();
	}

	public void LoadTweet(int start, int end)
	{
		foreach (TweetData item in SingletonMonoBehaviour<PoketterManager>.Instance.GetHistoryRange(start, end))
		{
			TweetDrawable dataStatic = new TweetDrawable(item);
			PoketterCell poketterCell = Object.Instantiate<PoketterCell>(_tweetPrefab, ((Component)_Waku).transform);
			poketterCell.SetDataStatic(dataStatic);
			((Component)poketterCell).transform.SetAsLastSibling();
		}
	}

	public void shootTweet()
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		PoketterCell poketterCell = Object.Instantiate<PoketterCell>(_tweetPrefab, ((Component)_Waku).transform);
		TweetDrawable data = new TweetDrawable(SingletonMonoBehaviour<PoketterManager>.Instance.AddHistoryFromQueue());
		poketterCell.SetData(data);
		((Component)poketterCell).transform.SetAsFirstSibling();
		_loading.transform.SetAsFirstSibling();
		AudioManager.Instance.PlaySeByType(SoundType.SE_tweet_load);
		poketterCell.Animate();
	}

	public void shootTweetOne(TweetData tw)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		PoketterCell poketterCell = Object.Instantiate<PoketterCell>(_tweetPrefab, ((Component)_Waku).transform);
		poketterCell.SetData(new TweetDrawable(tw));
		((Component)poketterCell).transform.SetAsFirstSibling();
		_loading.transform.SetAsFirstSibling();
		AudioManager.Instance.PlaySeByType(SoundType.SE_tweet_load);
		poketterCell.Animate();
	}

	private void ShootTweetImmediate(CancellationTokenSource cts = null)
	{
		while (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count >= 1)
		{
			TweetData tw = SingletonMonoBehaviour<PoketterManager>.Instance.AddHistoryFromQueue();
			shootTweetOne(tw);
		}
		if (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count == 0)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value = false;
			((Graphic)((Component)_gamen).gameObject.GetComponent<Text>()).raycastTarget = false;
			cts?.Cancel();
		}
	}

	[AsyncStateMachine(typeof(_003CshootTweetAll_003Ed__21))]
	public UniTask shootTweetAll(CancellationTokenSource c = null)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CshootTweetAll_003Ed__21 _003CshootTweetAll_003Ed__22 = default(_003CshootTweetAll_003Ed__21);
		_003CshootTweetAll_003Ed__22._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CshootTweetAll_003Ed__22._003C_003E4__this = this;
		_003CshootTweetAll_003Ed__22.c = c;
		_003CshootTweetAll_003Ed__22._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CshootTweetAll_003Ed__22._003C_003Et__builder)).Start<_003CshootTweetAll_003Ed__21>(ref _003CshootTweetAll_003Ed__22);
		return ((AsyncUniTaskMethodBuilder)(ref _003CshootTweetAll_003Ed__22._003C_003Et__builder)).Task;
	}

	private IEnumerator SpawnTweetAll()
	{
		SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value = true;
		while (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count >= 1)
		{
			TweetData tw = SingletonMonoBehaviour<PoketterManager>.Instance.AddHistoryFromQueue();
			shootTweetOne(tw);
			if (((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count == 0)
			{
				SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value = false;
				_loading.SetActive(false);
				((Graphic)((Component)_gamen).gameObject.GetComponent<Text>()).raycastTarget = false;
				break;
			}
			yield return (object)new WaitForSeconds((float)Constants.SLOW / 1000f);
		}
	}
}
