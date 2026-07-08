using System;
using System.Collections.Generic;
using NGO;
using UnityEngine;

namespace ngov3;

public static class JineDataConverter
{
	private static List<LineMaster.Param> JineRawList = null;

	public static Random _R = new Random();

	public static List<LineMaster.Param> getJineRawList()
	{
		if (JineRawList == null)
		{
			JineRawList = Resources.Load<LineMaster>("Master/Line")?.param;
		}
		return JineRawList;
	}

	public static T RandomEnumValue<T>()
	{
		Array values = Enum.GetValues(typeof(T));
		return (T)values.GetValue(_R.Next(values.Length));
	}

	public static LineMaster.Param getJineFromTypeId(JineType t)
	{
		return getJineRawList().Find((LineMaster.Param j) => j.Id == t.ToString());
	}

	public static string GetJineTextFromTypeId(JineType t)
	{
		return SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value switch
		{
			LanguageType.JP => getJineFromTypeId(t).BodyJp, 
			LanguageType.CN => getJineFromTypeId(t).BodyCn, 
			LanguageType.KO => getJineFromTypeId(t).BodyKo, 
			LanguageType.TW => getJineFromTypeId(t).BodyTw, 
			LanguageType.VN => getJineFromTypeId(t).BodyVn, 
			LanguageType.FR => getJineFromTypeId(t).BodyFr, 
			LanguageType.IT => getJineFromTypeId(t).BodyIt, 
			LanguageType.GE => getJineFromTypeId(t).BodyGe, 
			LanguageType.SP => getJineFromTypeId(t).BodySp, 
			LanguageType.RU => getJineFromTypeId(t).BodyRu, 
			_ => getJineFromTypeId(t).BodyEn, 
		};
	}

	public static JineDrawable convertJineDataToDrawable(JineData raw, bool isAmeHead = false)
	{
		if (raw.user == JineUserType.separator || raw.user == JineUserType.timeSeparator)
		{
			return new JineDrawable(raw.user, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, StampType.None, isAmeHead: false, raw.day);
		}
		if (raw.user == JineUserType.eventSeparator)
		{
			if (raw.responseType == ResponseType.IdMessage)
			{
				LineMaster.Param jineFromTypeId = getJineFromTypeId(raw.id);
				if (jineFromTypeId == null)
				{
					Debug.LogError((object)("Jineのデータが見つかりませんでした:ID:" + raw.id));
					return new JineDrawable(JineUserType.ame, "", "", "", "", "", "", "", "", "", "", "", "", StampType.None);
				}
				return new JineDrawable(raw.user, jineFromTypeId.BodyJp, jineFromTypeId.BodyEn, jineFromTypeId.BodyCn, jineFromTypeId.BodyKo, jineFromTypeId.BodyTw, jineFromTypeId.BodyVn, jineFromTypeId.BodyFr, jineFromTypeId.BodyIt, jineFromTypeId.BodyGe, jineFromTypeId.BodySp, jineFromTypeId.BodyRu, string.Empty, StampType.None);
			}
			return new JineDrawable(raw.user, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, string.Empty, StampType.None);
		}
		if (raw.responseType == ResponseType.Freeform)
		{
			return new JineDrawable(raw.user, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, raw.freeMessage, string.Empty, StampType.None);
		}
		if (raw.responseType == ResponseType.Stamp)
		{
			return new JineDrawable(raw.user, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, raw.stampType, isAmeHead);
		}
		LineMaster.Param jineFromTypeId2 = getJineFromTypeId(raw.id);
		if (jineFromTypeId2 == null)
		{
			Debug.LogError((object)("Jineのデータが見つかりませんでした:ID:" + raw.id));
			return new JineDrawable(JineUserType.ame, "", "", "", "", "", "", "", "", "", "", "", "", StampType.None);
		}
		int kidokumillisecond = 1000;
		if (raw.id == JineType.Ending_Futaride_JINE005_Option004 || raw.id == JineType.Ending_Futaride_JINE005_Option005 || raw.id == JineType.Ending_Futaride_JINE005_Option006)
		{
			kidokumillisecond = 3000;
		}
		if (raw.id == JineType.Ending_Futaride_JINE005_Option007 || raw.id == JineType.Ending_Futaride_JINE005_Option008 || raw.id == JineType.Ending_Futaride_JINE005_Option009)
		{
			kidokumillisecond = 300000;
		}
		return new JineDrawable((!(jineFromTypeId2.Speaker == "ame")) ? JineUserType.pi : JineUserType.ame, string.Format(jineFromTypeId2.BodyJp, raw.freeMessage), string.Format(jineFromTypeId2.BodyEn, raw.freeMessage), string.Format(jineFromTypeId2.BodyCn, raw.freeMessage), string.Format(jineFromTypeId2.BodyKo, raw.freeMessage), string.Format(jineFromTypeId2.BodyTw, raw.freeMessage), string.Format(jineFromTypeId2.BodyVn, raw.freeMessage), string.Format(jineFromTypeId2.BodyFr, raw.freeMessage), string.Format(jineFromTypeId2.BodyIt, raw.freeMessage), string.Format(jineFromTypeId2.BodyGe, raw.freeMessage), string.Format(jineFromTypeId2.BodySp, raw.freeMessage), string.Format(jineFromTypeId2.BodyRu, raw.freeMessage), jineFromTypeId2.ImageId, StampType.None, isAmeHead, 0, kidokumillisecond);
	}
}
