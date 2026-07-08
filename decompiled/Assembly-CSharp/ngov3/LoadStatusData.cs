using UnityEngine;

namespace ngov3;

public static class LoadStatusData
{
	private static StatusTypeToDataAsset statusData;

	public static StatusTypeToData ReadstatusContent(StatusType statusType)
	{
		if (statusData == null)
		{
			statusData = Resources.Load<StatusTypeToDataAsset>("statuses");
		}
		if ((bool)statusData)
		{
			return statusData.StatusList.Find((StatusTypeToData status) => status.StatusType == statusType);
		}
		return null;
	}
}
