using System.Collections.Generic;
using UnityEngine;

namespace ngov3;

[CreateAssetMenu(menuName = "ngo/Create StatusData")]
public class StatusTypeToDataAsset : ScriptableObject
{
	public List<StatusTypeToData> StatusList = new List<StatusTypeToData>();
}
