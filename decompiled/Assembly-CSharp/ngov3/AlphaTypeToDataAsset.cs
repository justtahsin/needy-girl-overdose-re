using System.Collections.Generic;
using UnityEngine;

namespace ngov3;

[CreateAssetMenu(menuName = "ngo/Create AlphaNetaData")]
public class AlphaTypeToDataAsset : ScriptableObject
{
	public List<AlphaTypeToData> NetaList = new List<AlphaTypeToData>();
}
