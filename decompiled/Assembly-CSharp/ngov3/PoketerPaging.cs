using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class PoketerPaging : MonoBehaviour
{
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
		_thisTrans = base.gameObject.transform;
		_thisTrans.ObserveEveryValueChanged((Transform _thisTrans) => _thisTrans.childCount).Subscribe(delegate
		{
			addNewPost();
		}).AddTo(base.gameObject);
		(from x in _scrollRect.ObserveEveryValueChanged((ScrollRect _scrollRect) => _scrollRect.verticalNormalizedPosition).DistinctUntilChanged()
			where x <= 0.01f
			select x).Subscribe(async delegate
		{
			await pagingNext();
		}).AddTo(_scrollRect);
		(from x in _scrollRect.ObserveEveryValueChanged((ScrollRect _scrollRect) => _scrollRect.verticalNormalizedPosition).DistinctUntilChanged()
			where x >= 0.99f
			select x).Subscribe(async delegate
		{
			await pagingPrev();
		}).AddTo(_scrollRect);
	}

	private async UniTask pagingNext()
	{
		if (_thisTrans.childCount <= MAXPOSTS || !isBacking)
		{
			return;
		}
		if (showingNewestIndex >= _thisTrans.childCount - 1)
		{
			isBacking = false;
		}
		else if (!isloading)
		{
			isloading = true;
			GameObject loading = UnityEngine.Object.Instantiate(loadingPrefab, _thisTrans);
			loading.transform.SetAsLastSibling();
			int needLoad = Math.Min(PAGINGPOSTS, showingNewestIndex + PAGINGPOSTS - (_thisTrans.childCount - 1));
			showingNewestIndex = Math.Min(showingNewestIndex + PAGINGPOSTS, _thisTrans.childCount - 1);
			showingOldestIndex = Math.Max(showingNewestIndex - MAXPOSTS, 0);
			await UniTask.Delay(20);
			UnityEngine.Object.Destroy(loading);
			ShowRange(showingOldestIndex, showingNewestIndex);
			if (needLoad > 0)
			{
				_scrollRect.verticalNormalizedPosition += 0.01f * (float)needLoad;
			}
			loadAtLast = false;
			isloading = false;
		}
	}

	private async UniTask pagingPrev()
	{
		if (_thisTrans.childCount > MAXPOSTS && !isloading && !loadAtLast)
		{
			isloading = true;
			GameObject loading = UnityEngine.Object.Instantiate(loadingPrefab, _thisTrans);
			loading.transform.SetAsFirstSibling();
			isBacking = true;
			int needLoad = showingOldestIndex - PAGINGPOSTS;
			if (needLoad < 0)
			{
				showingOldestIndex = 0;
			}
			else
			{
				showingOldestIndex -= PAGINGPOSTS;
			}
			showingNewestIndex = Math.Min(showingOldestIndex + MAXPOSTS, _thisTrans.childCount - 1);
			await UniTask.Delay(20);
			UnityEngine.Object.Destroy(loading);
			ShowRange(showingOldestIndex, showingNewestIndex);
			if (needLoad > 0)
			{
				_scrollRect.verticalNormalizedPosition -= 0.01f * (float)Math.Min(needLoad, PAGINGPOSTS);
			}
			if (needLoad < 0)
			{
				_poketter.LoadTweet(_thisTrans.childCount, _thisTrans.childCount - needLoad);
				loadAtLast = true;
			}
			isloading = false;
		}
	}

	private void ShowRange(int oldIndex, int newIndex)
	{
		if (_thisTrans.childCount <= newIndex)
		{
			newIndex = _thisTrans.childCount - 1;
		}
		for (int num = oldIndex; num >= 0; num--)
		{
			_thisTrans.GetChild(num).gameObject.SetActive(value: false);
		}
		for (int i = oldIndex; i <= newIndex; i++)
		{
			_thisTrans.GetChild(i).gameObject.SetActive(value: true);
		}
		for (int j = newIndex; j <= _thisTrans.childCount - 1; j++)
		{
			_thisTrans.GetChild(j).gameObject.SetActive(value: false);
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
			_thisTrans.GetChild(_thisTrans.childCount - 1).gameObject.SetActive(value: false);
			return;
		}
		showingNewestIndex++;
		showingOldestIndex = showingNewestIndex - MAXPOSTS;
		for (int i = 0; i < _thisTrans.childCount - MAXPOSTS; i++)
		{
			_thisTrans.GetChild(i).gameObject.SetActive(value: false);
		}
	}
}
