using System.Collections.Generic;

namespace ngov3;

public struct TweetDrawable
{
	public int Day;

	public CmdType cmdType;

	public bool IsOmote;

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

	public int FavNumber;

	public int RtNumber;

	public List<KusoRepDrawable> kusoReps;

	public TweetDrawable(TweetData data)
	{
		Day = data.day;
		IsOmote = data.IsOmote;
		FavNumber = data.FavNumber;
		RtNumber = data.RtNumber;
		cmdType = data.cmdType;
		TweetMaster.Param param = TweetFetcher.ConvertTypeToTweet(data.Type);
		if (data.Type == TweetType.None || param == null)
		{
			BodyJp = data.honbun;
			BodyEn = data.honbun;
			BodyCn = data.honbun;
			BodyKo = data.honbun;
			BodyTw = data.honbun;
			BodyVn = data.honbun;
			BodyFr = data.honbun;
			BodyIt = data.honbun;
			BodyGe = data.honbun;
			BodySp = data.honbun;
			BodyRu = data.honbun;
			ImageId = "N/A";
		}
		else if (data.IsOmote)
		{
			BodyJp = param.OmoteBodyJp;
			BodyEn = param.OmoteBodyEn;
			BodyCn = param.OmoteBodyCn;
			BodyKo = param.OtomeBodyKo;
			BodyTw = param.OmoteBodyTw;
			BodyVn = param.OmoteBodyVn;
			BodyFr = param.OmoteBodyFr;
			BodyIt = param.OmoteBodyIt;
			BodyGe = param.OmoteBodyGe;
			BodySp = param.OmoteBodySp;
			BodyRu = param.OmoteBodyRu;
			ImageId = param.OmoteImageId;
		}
		else
		{
			BodyJp = param.UraBodyJp;
			BodyEn = param.UraBodyEn;
			BodyCn = param.UraBodyCn;
			BodyKo = param.UraBodyKo;
			BodyTw = param.UraBodyTw;
			BodyVn = param.UraBodyVn;
			BodyFr = param.UraBodyFr;
			BodyIt = param.UraBodyIt;
			BodyGe = param.UraBodyGe;
			BodySp = param.UraBodySp;
			BodyRu = param.UraBodyRu;
			ImageId = param.UraImageId;
		}
		kusoReps = new List<KusoRepDrawable>();
		foreach (KusoRepType kusoRep in data.kusoReps)
		{
			kusoReps.Add(new KusoRepDrawable(kusoRep));
		}
		if (data.kusoRepString == null)
		{
			return;
		}
		foreach (string item in data.kusoRepString)
		{
			kusoReps.Add(new KusoRepDrawable(item));
		}
	}
}
