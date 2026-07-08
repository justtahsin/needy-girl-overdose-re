using UnityEngine;

namespace ngov3;

public static class LoadNetaData
{
	private static AlphaTypeToDataAsset NetaData;

	public static AlphaTypeToData ReadNetaContent(AlphaType NetaType, int level = 0)
	{
		string text = "AlphaNetas";
		if ((Object)(object)NetaData == (Object)null)
		{
			NetaData = Resources.Load<AlphaTypeToDataAsset>(text);
		}
		if (Object.op_Implicit((Object)(object)NetaData))
		{
			return NetaData.NetaList.Find((AlphaTypeToData Neta) => Neta.NetaType == NetaType && Neta.level == level);
		}
		return null;
	}
}
