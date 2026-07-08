using UnityEngine;

namespace ngov3;

public static class LoadStampData
{
	private static StampTypeToDataAsset StampData;

	public static Sprite ReadStampContent(StampType type, LanguageType lang)
	{
		if (StampData == null)
		{
			StampData = Resources.Load<StampTypeToDataAsset>("StampTypeToData");
		}
		if (StampData != null)
		{
			return lang switch
			{
				LanguageType.JP => StampData.stampTypeToData.Find((StampTypeToDataAsset.StampTypeToData stamp) => stamp.type == type).JpImage, 
				LanguageType.CN => StampData.stampTypeToData.Find((StampTypeToDataAsset.StampTypeToData stamp) => stamp.type == type).CnImage, 
				LanguageType.KO => StampData.stampTypeToData.Find((StampTypeToDataAsset.StampTypeToData stamp) => stamp.type == type).KoImage, 
				LanguageType.TW => StampData.stampTypeToData.Find((StampTypeToDataAsset.StampTypeToData stamp) => stamp.type == type).TwImage, 
				LanguageType.VN => StampData.stampTypeToData.Find((StampTypeToDataAsset.StampTypeToData stamp) => stamp.type == type).VnImage, 
				LanguageType.FR => StampData.stampTypeToData.Find((StampTypeToDataAsset.StampTypeToData stamp) => stamp.type == type).FrImage, 
				LanguageType.IT => StampData.stampTypeToData.Find((StampTypeToDataAsset.StampTypeToData stamp) => stamp.type == type).ItImage, 
				LanguageType.GE => StampData.stampTypeToData.Find((StampTypeToDataAsset.StampTypeToData stamp) => stamp.type == type).GeImage, 
				LanguageType.SP => StampData.stampTypeToData.Find((StampTypeToDataAsset.StampTypeToData stamp) => stamp.type == type).SpImage, 
				LanguageType.RU => StampData.stampTypeToData.Find((StampTypeToDataAsset.StampTypeToData stamp) => stamp.type == type).RuImage, 
				_ => StampData.stampTypeToData.Find((StampTypeToDataAsset.StampTypeToData stamp) => stamp.type == type).EnImage, 
			};
		}
		return null;
	}
}
