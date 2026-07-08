using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ngov3;

public class PoketterManager : SingletonMonoBehaviour<PoketterManager>
{
	private int KUSOREPPROBABILITY = 50;

	private int TWEETCOUNT_ONLOAD = 25;

	private readonly ReactiveCollection<TweetData> _history = new ReactiveCollection<TweetData>();

	public List<TweetData> history = new List<TweetData>();

	public ReactiveCollection<TweetData> _tweetQueue = new ReactiveCollection<TweetData>();

	public ReactiveProperty<bool> isDeleted = new ReactiveProperty<bool>(initialValue: false);

	public ReactiveProperty<bool> isBlocked = new ReactiveProperty<bool>(initialValue: false);

	public ReactiveProperty<bool> isShootRunning = new ReactiveProperty<bool>(initialValue: false);

	public int TweetCountOnLoad => TWEETCOUNT_ONLOAD;

	public IObservable<CollectionAddEvent<TweetData>> OnAddHistory => _history.ObserveAdd();

	public IObservable<CollectionAddEvent<TweetData>> OnAddQueue => _tweetQueue.ObserveAdd();

	public IObservable<CollectionRemoveEvent<TweetData>> OnRemoveQueue => _tweetQueue.ObserveRemove();

	protected override void Awake()
	{
		base.Awake();
		OnAddHistory.Subscribe(delegate(CollectionAddEvent<TweetData> value)
		{
			history.Add(value.Value);
		}).AddTo(this);
	}

	public void AddHistory(TweetData t)
	{
		_history.Add(t);
	}

	public TweetData AddHistoryFromQueue()
	{
		TweetData tweetData = _tweetQueue[0];
		_tweetQueue.Remove(tweetData);
		AddHistory(tweetData);
		return tweetData;
	}

	public void AddHistoryFromQueueAll()
	{
		foreach (TweetData item in _tweetQueue)
		{
			AddHistory(item);
		}
		_tweetQueue.Clear();
	}

	public void AddTweet(TweetData data)
	{
		_tweetQueue.Add(data);
	}

	public void AddTweet(string nakami, bool isOmote = true)
	{
		AddTweet(new TweetData(nakami, isOmote, SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower), SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex), SingletonMonoBehaviour<EventManager>.Instance.executingAction));
	}

	public void AddTweet(TweetType t, bool isOmote = true)
	{
		TweetData tweetData = new TweetData(t, isOmote, SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower), SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex), SingletonMonoBehaviour<EventManager>.Instance.executingAction);
		if (isValidTweetData(tweetData))
		{
			AddTweet(tweetData);
		}
	}

	public void AddTweet(TweetType t)
	{
		TweetData tweetData = new TweetData(t, isOmote: true, SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower), SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex), SingletonMonoBehaviour<EventManager>.Instance.executingAction);
		TweetData tweetData2 = new TweetData(t, isOmote: false, SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower), SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex), SingletonMonoBehaviour<EventManager>.Instance.executingAction);
		if (isValidTweetData(tweetData))
		{
			AddTweet(tweetData);
		}
		if (isValidTweetData(tweetData2))
		{
			AddTweet(tweetData2);
		}
	}

	private void AddKusorepToTweet(TweetData tw, KusoRepType k)
	{
		if (tw.IsOmote && !k.ToString().StartsWith("Ending_") && !k.ToString().StartsWith("horror") && !k.ToString().StartsWith("None"))
		{
			tw.kusoReps.Add(k);
		}
	}

	private void AddKusorepToTweet(TweetData tw, string kusorepNakami)
	{
		if (tw.IsOmote)
		{
			tw.kusoRepString.Add(kusorepNakami);
		}
	}

	public void AddQueueWithKusoreps(TweetType t, List<KusoRepType> kusoType = null, List<string> kusoString = null)
	{
		if (t == TweetType.None)
		{
			return;
		}
		TweetData tweetData = new TweetData(t, isOmote: true, SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower), SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex), SingletonMonoBehaviour<EventManager>.Instance.executingAction);
		TweetData tweetData2 = new TweetData(t, isOmote: false, SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower), SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex), SingletonMonoBehaviour<EventManager>.Instance.executingAction);
		bool flag = isValidTweetData(tweetData);
		bool flag2 = isValidTweetData(tweetData2);
		if (kusoType != null)
		{
			foreach (KusoRepType item in kusoType)
			{
				tweetData.kusoReps.Add(item);
			}
		}
		if (kusoString != null)
		{
			foreach (string item2 in kusoString)
			{
				AddKusorepToTweet(tweetData, item2);
			}
		}
		if (kusoType == null)
		{
			int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
			if (t == TweetType.AfterTweet_Angel1 || t == TweetType.AfterTweet_Angel2 || t == TweetType.AfterTweet_Angel3 || t == TweetType.AfterTweet_Angel4 || t == TweetType.AfterTweet_Angel5)
			{
				AddKusorepToTweet(tweetData, NgoEx.AngelKusoreps.RandomizedElement());
			}
			else if (status < 10000)
			{
				if (UnityEngine.Random.Range(0, 100) < KUSOREPPROBABILITY)
				{
					AddKusorepToTweet(tweetData, NgoEx.smallKusoreps.RandomizedElement());
				}
			}
			else if (status < 100000)
			{
				KusoRepType kusoRepType = NgoEx.middleKusoreps.RandomizedElement();
				KusoRepType kusoRepType2 = NgoEx.middleKusoreps.RandomizedElement();
				if (UnityEngine.Random.Range(0, 100) < KUSOREPPROBABILITY)
				{
					AddKusorepToTweet(tweetData, kusoRepType);
				}
				if (UnityEngine.Random.Range(0, 100) < KUSOREPPROBABILITY && kusoRepType2 != kusoRepType)
				{
					AddKusorepToTweet(tweetData, kusoRepType2);
				}
			}
			else
			{
				KusoRepType kusoRepType3 = NgoEx.largeKusoreps.RandomizedElement();
				KusoRepType kusoRepType4 = NgoEx.largeKusoreps.RandomizedElement();
				KusoRepType kusoRepType5 = NgoEx.largeKusoreps.RandomizedElement();
				if (UnityEngine.Random.Range(0, 100) < KUSOREPPROBABILITY)
				{
					AddKusorepToTweet(tweetData, kusoRepType3);
				}
				if (UnityEngine.Random.Range(0, 100) < KUSOREPPROBABILITY && kusoRepType4 != kusoRepType3)
				{
					AddKusorepToTweet(tweetData, kusoRepType4);
				}
				if (UnityEngine.Random.Range(0, 100) < KUSOREPPROBABILITY && kusoRepType5 != kusoRepType3 && kusoRepType5 != kusoRepType4)
				{
					AddKusorepToTweet(tweetData, kusoRepType5);
				}
			}
		}
		if (flag)
		{
			AddTweet(tweetData);
		}
		if (flag2)
		{
			AddTweet(tweetData2);
		}
	}

	public void AddQueueWithKusoreps(string nakami, bool isOmote = true, List<KusoRepType> kusoType = null, List<string> kusoString = null)
	{
		TweetData tweetData = new TweetData(nakami, isOmote, SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower), SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex), SingletonMonoBehaviour<EventManager>.Instance.executingAction);
		isValidTweetData(tweetData);
		if (isOmote)
		{
			if (kusoType != null)
			{
				foreach (KusoRepType item in kusoType)
				{
					try
					{
						AddKusorepToTweet(tweetData, item);
					}
					catch
					{
					}
				}
			}
			if (kusoString != null)
			{
				foreach (string item2 in kusoString)
				{
					AddKusorepToTweet(tweetData, item2);
				}
			}
			if (UnityEngine.Random.Range(0, 100) < KUSOREPPROBABILITY)
			{
				AddKusorepToTweet(tweetData, NgoEx.RandomEnumValue<KusoRepType>());
			}
		}
		AddTweet(tweetData);
	}

	private bool isValidTweetData(TweetData tw)
	{
		if (tw.Type == TweetType.None)
		{
			return false;
		}
		if (tw.IsOmote)
		{
			if (!TweetFetcher.ConvertTypeToTweet(tw.Type).OmoteBodyJp.IsNotEmpty())
			{
				return TweetFetcher.ConvertTypeToTweet(tw.Type).OmoteImageId.IsNotEmpty();
			}
			return true;
		}
		return TweetFetcher.ConvertTypeToTweet(tw.Type).UraBodyJp.IsNotEmpty();
	}

	public List<TweetData> GetHistoryRange(int start, int end)
	{
		if (start >= history.Count || history.Count == 0 || start > end)
		{
			return new List<TweetData>();
		}
		if (end >= history.Count)
		{
			return history.GetRange(start, history.Count - start);
		}
		int count = end - start;
		return history.GetRange(start, count);
	}

	public List<TweetData> GetNewest()
	{
		int num = Math.Max(0, history.Count - TWEETCOUNT_ONLOAD);
		if (num != 0)
		{
			return history.GetRange(num, TWEETCOUNT_ONLOAD);
		}
		return history.GetRange(num, history.Count);
	}
}
