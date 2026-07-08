using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace ngov3;

public class Test_ShowAllPoketter : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		PoketterView2D pketterView2D = null;
		Observable.Interval(TimeSpan.FromMilliseconds(1000.0)).Subscribe(delegate
		{
			if (pketterView2D == null)
			{
				pketterView2D = UnityEngine.Object.FindObjectOfType<PoketterView2D>();
			}
			pketterView2D?.OnPicked();
		}).AddTo(SingletonMonoBehaviour<PoketterManager>.Instance);
		List<TweetType> tweetList = new List<TweetType>();
		foreach (TweetType value in Enum.GetValues(typeof(TweetType)))
		{
			tweetList.Add(value);
		}
		tweetList = tweetList.OrderBy((TweetType t) => t.ToString()).ToList();
		int index = 0;
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet("AllTweet Start");
		foreach (TweetType item in tweetList)
		{
			if (item != TweetType.None)
			{
				if (index % 5 == 0)
				{
					SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(index + "/" + tweetList.Count);
				}
				Debug.Log("AddTweet:" + index + "/" + tweetList.Count);
				try
				{
					SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(item);
				}
				catch (Exception ex)
				{
					Debug.LogError("Error発生" + ex.ToString());
				}
				index++;
				await UniTask.Delay(Constants.MIDDLE);
			}
		}
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet("AllTweet End");
		endEvent();
	}
}
