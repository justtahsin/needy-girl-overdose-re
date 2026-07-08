using UnityEngine;

namespace ngov3;

public struct KusoRepDrawable
{
	public string UserId;

	public string BodyJp;

	public string BodyEn;

	public string BodyCn;

	public string BodyKo;

	public string BodyTw;

	public string BodyVn;

	public string BodyFr;

	public string BodyIt;

	public string BodyGe;

	public string BodySp;

	public string BodyRu;

	public string ImageId;

	public string UserIconId;

	public KusoRepDrawable(KusoRepType t)
	{
		KRepMaster.Param param = TweetFetcher.ConvertTypeToKusorep(t);
		if (param == null)
		{
			Debug.LogError(t.ToString() + "has error");
		}
		UserId = param.UserId;
		UserIconId = param.IconId;
		BodyJp = param.BodyJp;
		BodyEn = param.BodyEn;
		BodyCn = param.BodyCn;
		BodyKo = param.BodyKo;
		BodyTw = param.BodyTw;
		BodyVn = param.BodyVn;
		BodyFr = param.BodyFr;
		BodyIt = param.BodyIt;
		BodyGe = param.BodyGe;
		BodySp = param.BodySp;
		BodyRu = param.BodyRu;
		ImageId = param.ImageId;
		if (param.IconId.IsNotEmpty())
		{
			UserIconId = param.IconId;
		}
		else
		{
			UserIconId = TweetFetcher.SuteakaIconId();
		}
	}

	public KusoRepDrawable(string t)
	{
		string userId = "@" + NgoEx.GenerateRandomCharacters(16);
		UserId = userId;
		UserIconId = TweetFetcher.SuteakaIconId();
		BodyJp = t;
		BodyEn = t;
		BodyCn = t;
		BodyKo = t;
		BodyTw = t;
		BodyVn = t;
		BodyFr = t;
		BodyIt = t;
		BodyGe = t;
		BodySp = t;
		BodyRu = t;
		ImageId = "";
	}
}
