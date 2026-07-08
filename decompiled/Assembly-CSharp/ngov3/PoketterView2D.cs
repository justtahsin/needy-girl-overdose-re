using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using Rewired;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class PoketterView2D : MonoBehaviour, IApp2D, IScrollable2D, IClickable, IStorable
{
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
		foreach (TweetData item in SingletonMonoBehaviour<PoketterManager>.Instance.GetNewest())
		{
			MakeTweet(item, 0);
		}
		SingletonMonoBehaviour<PoketterManager>.Instance.OnAddQueue.Subscribe(delegate
		{
			ShowLoading(isShow: true);
			shootTweetAll();
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<PoketterManager>.Instance.OnRemoveQueue.Subscribe(delegate
		{
			ShowLoading(SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count != 0);
		}).AddTo(base.gameObject);
		if (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count > 0)
		{
			ShowLoading(isShow: true);
			shootTweetAll();
		}
		SingletonMonoBehaviour<PoketterManager>.Instance.isBlocked.Where((bool v) => v).Subscribe(delegate
		{
			showBlockMode();
		}).AddTo(base.gameObject);
		SingletonMonoBehaviour<PoketterManager>.Instance.isDeleted.Where((bool v) => v).Subscribe(delegate
		{
			showDeleteMode();
		}).AddTo(base.gameObject);
	}

	public void OnPicked()
	{
		Transform obj = _Waku.transform;
		Vector3 localPosition = obj.localPosition;
		localPosition.y = 0f;
		obj.localPosition = localPosition;
		int num = _tweetCells.Count - SingletonMonoBehaviour<PoketterManager>.Instance.TweetCountOnLoad;
		if (num > 0)
		{
			List<PoketterCell2D> range = _tweetCells.GetRange(0, num);
			_tweetCells.RemoveRange(0, num);
			foreach (PoketterCell2D item in range)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}
		_stopLoading = false;
		if (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count > 0)
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
		_scrollRect.gameObject.SetActive(value: false);
		_Header.gameObject.SetActive(value: true);
		_Desc.gameObject.SetActive(value: true);
	}

	private void showDeleteMode()
	{
		_Header.text = NgoEx.SystemTextFromType(SystemTextType.Poketter_Deleted_Header, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_Desc.text = NgoEx.SystemTextFromType(SystemTextType.Poketter_Deleteded_Description, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_scrollRect.gameObject.SetActive(value: false);
		_Header.gameObject.SetActive(value: true);
		_Desc.gameObject.SetActive(value: true);
	}

	public void MakeTweet(TweetData data, int page)
	{
		TweetDrawable dataStatic = new TweetDrawable(data);
		PoketterCell2D poketterCell2D = UnityEngine.Object.Instantiate(_tweetPrefab, _Waku.transform);
		poketterCell2D.SetDataStatic(dataStatic);
		poketterCell2D.transform.SetAsFirstSibling();
		_loading.transform.SetAsFirstSibling();
		_tweetCells.Add(poketterCell2D);
	}

	public void LoadTweet(int start, int end)
	{
		foreach (TweetData item in SingletonMonoBehaviour<PoketterManager>.Instance.GetHistoryRange(start, end))
		{
			TweetDrawable dataStatic = new TweetDrawable(item);
			PoketterCell2D poketterCell2D = UnityEngine.Object.Instantiate(_tweetPrefab, _Waku.transform);
			poketterCell2D.SetDataStatic(dataStatic);
			poketterCell2D.transform.SetAsLastSibling();
			_tweetCells.Add(poketterCell2D);
		}
	}

	public void shootTweet()
	{
		TweetDrawable data = new TweetDrawable(SingletonMonoBehaviour<PoketterManager>.Instance.AddHistoryFromQueue());
		PoketterCell2D poketterCell2D = UnityEngine.Object.Instantiate(_tweetPrefab, _Waku.transform);
		poketterCell2D.SetData(data);
		poketterCell2D.transform.SetAsFirstSibling();
		_loading.transform.SetAsFirstSibling();
		_tweetCells.Add(poketterCell2D);
		AudioManager.Instance.PlaySeByType(SoundType.SE_tweet_load);
		poketterCell2D.Animate();
	}

	public async UniTask shootTweetOne(TweetData tw)
	{
		PoketterCell2D cell = UnityEngine.Object.Instantiate(_tweetPrefab, _Waku.transform);
		TweetDrawable data = new TweetDrawable(tw);
		Debug.Log($"<color=green>{tw.Type}:{data.BodyJp}</color>");
		await cell.SetData(data);
		cell.transform.SetAsFirstSibling();
		_loading.transform.SetAsFirstSibling();
		_tweetCells.Add(cell);
		AudioManager.Instance.PlaySeByType(SoundType.SE_tweet_load);
		await cell.Animate();
	}

	public async UniTask shootTweetAll(CancellationTokenSource c = null)
	{
		if (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count != 0 && !SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value && !_stopLoading)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value = true;
			ShowLoading(isShow: true);
			SpawnTweetAll().Forget();
		}
	}

	private async UniTask SpawnTweetAll()
	{
		while (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count >= 1)
		{
			await UniTask.WhenAny(UniTask.Delay(Constants.FAST, ignoreTimeScale: false, PlayerLoopTiming.Update, this.GetCancellationTokenOnDestroy()), UniTask.WaitUntil(() => Input.GetMouseButtonDown(0) || Player.GetButtonDown("Click"), PlayerLoopTiming.Update, this.GetCancellationTokenOnDestroy()));
			TweetData tw = SingletonMonoBehaviour<PoketterManager>.Instance.AddHistoryFromQueue();
			if (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count == 0)
			{
				ShowLoading(isShow: false);
			}
			await shootTweetOne(tw);
		}
		SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value = false;
	}

	public void Click()
	{
	}

	public void SetSortOrder(int order)
	{
	}
}
