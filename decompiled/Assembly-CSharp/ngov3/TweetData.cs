using System;
using System.Collections.Generic;
using UnityEngine;

namespace ngov3;

[Serializable]
public struct TweetData
{
	public TweetType Type;

	public int day;

	public string honbun;

	public bool IsOmote;

	public int FavNumber;

	public int RtNumber;

	public List<KusoRepType> kusoReps;

	public List<string> kusoRepString;

	public CmdType cmdType;

	public TweetData(TweetType t, bool isOmote, int follower = 1, int day = 0, CmdType cmd = CmdType.None)
	{
		Type = t;
		honbun = "";
		IsOmote = isOmote;
		this.day = day;
		kusoReps = new List<KusoRepType>();
		kusoRepString = new List<string>();
		cmdType = cmd;
		if (isOmote)
		{
			if (follower > 100000)
			{
				FavNumber = (int)((double)follower * 0.13555 - 5555.0 + (double)(TweetFetcher.ConvertTypeToTweet(t).BuzzPowerFav * UnityEngine.Random.Range(1, 10)));
				RtNumber = (int)((double)follower * 0.00888 + 1111.0 + (double)(TweetFetcher.ConvertTypeToTweet(t).BuzzPowerRT * UnityEngine.Random.Range(1, 10)));
			}
			else if (follower > 10000)
			{
				FavNumber = (int)((double)follower * 0.066 + 1333.0 + (double)(TweetFetcher.ConvertTypeToTweet(t).BuzzPowerFav * UnityEngine.Random.Range(1, 10)));
				RtNumber = (int)((double)follower * 0.018 + 166.0 + (double)(TweetFetcher.ConvertTypeToTweet(t).BuzzPowerRT * UnityEngine.Random.Range(1, 10)));
			}
			else if (follower > 1000)
			{
				FavNumber = (int)((double)follower * 0.88 + 111.0 + (double)(TweetFetcher.ConvertTypeToTweet(t).BuzzPowerFav * UnityEngine.Random.Range(0, 1)));
				RtNumber = (int)((double)follower * 0.034 + 5.0 + (double)(TweetFetcher.ConvertTypeToTweet(t).BuzzPowerRT * UnityEngine.Random.Range(0, 1)));
			}
			else
			{
				FavNumber = (int)(Mathf.Max(Mathf.Log10(follower), 0.5f) * (float)TweetFetcher.ConvertTypeToTweet(t).BuzzPowerFav * 2f) + UnityEngine.Random.Range(1, 10);
				RtNumber = (int)(Mathf.Max(Mathf.Log10(follower), 1f) * (float)TweetFetcher.ConvertTypeToTweet(t).BuzzPowerRT) + UnityEngine.Random.Range(1, 10);
			}
		}
		else
		{
			FavNumber = 0;
			RtNumber = 0;
		}
	}

	public TweetData(string tweethonbun, bool isOmote = true, int follower = 1, int day = 0, CmdType cmd = CmdType.None)
	{
		Type = TweetType.None;
		honbun = tweethonbun;
		this.day = day;
		IsOmote = isOmote;
		kusoReps = new List<KusoRepType>();
		kusoRepString = new List<string>();
		cmdType = cmd;
		if (isOmote)
		{
			if (follower > 100000)
			{
				FavNumber = (int)((double)follower * 0.13555 - 5555.0);
				RtNumber = (int)((double)follower * 0.00888 + 1111.0);
			}
			else if (follower > 10000)
			{
				FavNumber = (int)((double)follower * 0.066 + 1333.0);
				RtNumber = (int)((double)follower * 0.018 + 166.0);
			}
			else if (follower > 1000)
			{
				FavNumber = (int)((double)follower * 0.88 + 111.0);
				RtNumber = (int)((double)follower * 0.034 + 5.0);
			}
			else
			{
				FavNumber = (int)Mathf.Max(Mathf.Log10(follower), 0.5f);
				RtNumber = (int)Mathf.Max(Mathf.Log10(follower), 1f);
			}
		}
		else
		{
			FavNumber = 0;
			RtNumber = 0;
		}
	}
}
