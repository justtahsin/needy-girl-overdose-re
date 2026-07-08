using UnityEngine;

namespace ngov3;

public static class LoadStatusData
{
	private static StatusTypeToDataAsset statusData;

	public static StatusTypeToData ReadstatusContent(StatusType statusType)
	{
		if ((Object)(object)statusData == (Object)null)
		{
			statusData = Resources.Load<StatusTypeToDataAsset>("statuses");
		}
		if (Object.op_Implicit((Object)(object)statusData))
		{
			return statusData.StatusList.Find((StatusTypeToData status) => status.StatusType == statusType);
		}
		return null;
	}
}
