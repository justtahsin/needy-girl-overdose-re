using UnityEngine;

namespace ngov3;

public static class LoadNetaData
{
	private static AlphaTypeToDataAsset NetaData;

	public static AlphaTypeToData ReadNetaContent(AlphaType NetaType, int level = 0)
	{
		string path = "AlphaNetas";
		if (NetaData == null)
		{
			NetaData = Resources.Load<AlphaTypeToDataAsset>(path);
		}
		if ((bool)NetaData)
		{
			return NetaData.NetaList.Find((AlphaTypeToData Neta) => Neta.NetaType == NetaType && Neta.level == level);
		}
		return null;
	}
}
