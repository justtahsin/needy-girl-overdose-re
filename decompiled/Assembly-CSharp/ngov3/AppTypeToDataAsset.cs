using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ngov3;

[CreateAssetMenu(menuName = "ngo/Create WindowData")]
public class AppTypeToDataAsset : ScriptableObject
{
	[SerializeField]
	private List<AppTypeToData> AppList = new List<AppTypeToData>();

	[SerializeField]
	private List<AppTypeToData> AppDiffForCERO_D = new List<AppTypeToData>();

	[SerializeField]
	private List<AppTypeToData> AppDiffForSteam = new List<AppTypeToData>();

	private IEnumerable<AppTypeToData> mergedApps;

	public List<AppTypeToData> Apps
	{
		get
		{
			if (mergedApps != null)
			{
				return mergedApps.ToList();
			}
			mergedApps = AppList.Concat(AppDiffForSteam);
			return mergedApps.ToList();
		}
	}
}
