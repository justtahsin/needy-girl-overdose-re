using System.Collections.Generic;
using UnityEngine;

namespace ngov3;

[CreateAssetMenu(menuName = "ngo/Create BetaNetaData")]
public class BetaTypeToDataAsset : ScriptableObject
{
	public List<BetaTypeToData> NetaList = new List<BetaTypeToData>();
}
