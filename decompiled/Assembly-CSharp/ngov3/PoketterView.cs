using System;
using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class PoketterView : MonoBehaviour
{
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
		logo.text = ((SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN) ? "Tweeter" : "Poketter");
		_gamen.gameObject.GetComponent<Text>().raycastTarget = false;
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
		PoketterCell poketterCell = UnityEngine.Object.Instantiate(_tweetPrefab, _Waku.transform);
		poketterCell.SetDataStatic(dataStatic);
		poketterCell.transform.SetAsFirstSibling();
		_loading.transform.SetAsFirstSibling();
	}

	public void LoadTweet(int start, int end)
	{
		foreach (TweetData item in SingletonMonoBehaviour<PoketterManager>.Instance.GetHistoryRange(start, end))
		{
			TweetDrawable dataStatic = new TweetDrawable(item);
			PoketterCell poketterCell = UnityEngine.Object.Instantiate(_tweetPrefab, _Waku.transform);
			poketterCell.SetDataStatic(dataStatic);
			poketterCell.transform.SetAsLastSibling();
		}
	}

	public void shootTweet()
	{
		PoketterCell poketterCell = UnityEngine.Object.Instantiate(_tweetPrefab, _Waku.transform);
		TweetDrawable data = new TweetDrawable(SingletonMonoBehaviour<PoketterManager>.Instance.AddHistoryFromQueue());
		poketterCell.SetData(data);
		poketterCell.transform.SetAsFirstSibling();
		_loading.transform.SetAsFirstSibling();
		AudioManager.Instance.PlaySeByType(SoundType.SE_tweet_load);
		poketterCell.Animate();
	}

	public void shootTweetOne(TweetData tw)
	{
		PoketterCell poketterCell = UnityEngine.Object.Instantiate(_tweetPrefab, _Waku.transform);
		poketterCell.SetData(new TweetDrawable(tw));
		poketterCell.transform.SetAsFirstSibling();
		_loading.transform.SetAsFirstSibling();
		AudioManager.Instance.PlaySeByType(SoundType.SE_tweet_load);
		poketterCell.Animate();
	}

	private void ShootTweetImmediate(CancellationTokenSource cts = null)
	{
		while (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count >= 1)
		{
			TweetData tw = SingletonMonoBehaviour<PoketterManager>.Instance.AddHistoryFromQueue();
			shootTweetOne(tw);
		}
		if (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count == 0)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value = false;
			_gamen.gameObject.GetComponent<Text>().raycastTarget = false;
			cts?.Cancel();
		}
	}

	public async UniTask shootTweetAll(CancellationTokenSource c = null)
	{
		if (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count != 0)
		{
			await UniTask.Delay(Constants.FAST);
			_gamen.gameObject.GetComponent<Text>().raycastTarget = true;
			disposable = _gamen.OnClickAsObservable().Subscribe(delegate
			{
				disposable.Dispose();
				StopCoroutine("SpawnTweetAll");
				ShootTweetImmediate(c);
				_loading.SetActive(value: false);
				SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value = false;
			}).AddTo(base.gameObject);
			StartCoroutine("SpawnTweetAll");
		}
	}

	private IEnumerator SpawnTweetAll()
	{
		SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value = true;
		while (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count >= 1)
		{
			TweetData tw = SingletonMonoBehaviour<PoketterManager>.Instance.AddHistoryFromQueue();
			shootTweetOne(tw);
			if (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count == 0)
			{
				SingletonMonoBehaviour<PoketterManager>.Instance.isShootRunning.Value = false;
				_loading.SetActive(value: false);
				_gamen.gameObject.GetComponent<Text>().raycastTarget = false;
				break;
			}
			yield return new WaitForSeconds((float)Constants.SLOW / 1000f);
		}
	}
}
