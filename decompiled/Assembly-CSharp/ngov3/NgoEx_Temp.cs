using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ngov3;

public static class NgoEx_Temp
{
	public static List<string> GetOdekakeResponseList()
	{
		CmdType firstDate = SingletonMonoBehaviour<EventManager>.Instance.FirstDate;
		string item = NgoEx.CmdName(firstDate, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		List<string> list = new List<string>();
		List<CmdMaster.Param> list2 = (from c in NgoEx.getCmds()
			where c.Id.StartsWith("Odekake")
			select c).ToList();
		list2.Remove(NgoEx.CmdFromType(firstDate));
		for (int num = 0; num < 3; num++)
		{
			CmdMaster.Param param = list2[Random.Range(0, list2.Count)];
			string text = "";
			list.Add(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value switch
			{
				LanguageType.JP => param.LabelJp, 
				LanguageType.CN => param.LabelCn, 
				LanguageType.TW => param.LabelTw, 
				LanguageType.KO => param.LabelKo, 
				LanguageType.VN => param.LabelVn, 
				LanguageType.FR => param.LabelFr, 
				LanguageType.IT => param.LabelIt, 
				LanguageType.GE => param.LabelGe, 
				LanguageType.SP => param.LabelSp, 
				LanguageType.RU => param.LabelRu, 
				_ => param.LabelEn, 
			});
			list2.Remove(param);
		}
		if (firstDate != CmdType.None)
		{
			list.Add(item);
		}
		list.Sort();
		return list;
	}

	public static (string, bool) GetKusoRepBody(KusoRepDrawable nakami)
	{
		string text = "";
		text = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value switch
		{
			LanguageType.JP => nakami.BodyJp, 
			LanguageType.CN => nakami.BodyCn, 
			LanguageType.KO => nakami.BodyKo, 
			LanguageType.TW => nakami.BodyTw, 
			LanguageType.VN => nakami.BodyVn, 
			LanguageType.FR => nakami.BodyFr, 
			LanguageType.IT => nakami.BodyIt, 
			LanguageType.GE => nakami.BodyGe, 
			LanguageType.SP => nakami.BodySp, 
			LanguageType.RU => nakami.BodyRu, 
			_ => nakami.BodyEn, 
		};
		return (text, text != string.Empty);
	}

	public static string FetchTweetBody(TweetDrawable tweetDrawable)
	{
		string text = "";
		return SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value switch
		{
			LanguageType.JP => tweetDrawable.BodyJp, 
			LanguageType.CN => tweetDrawable.BodyCn, 
			LanguageType.KO => tweetDrawable.BodyKo, 
			LanguageType.TW => tweetDrawable.BodyTw, 
			LanguageType.VN => tweetDrawable.BodyVn, 
			LanguageType.FR => tweetDrawable.BodyFr, 
			LanguageType.IT => tweetDrawable.BodyIt, 
			LanguageType.GE => tweetDrawable.BodyGe, 
			LanguageType.SP => tweetDrawable.BodySp, 
			LanguageType.RU => tweetDrawable.BodyRu, 
			_ => tweetDrawable.BodyEn, 
		};
	}
}
