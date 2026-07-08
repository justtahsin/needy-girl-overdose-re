using System.Collections.Generic;
using UnityEngine;

namespace MasterLoader;

[CreateAssetMenu(menuName = "NGO/Master/BaseMaster")]
public class BaseMaster : ScriptableObject
{
	public List<Base> List;
}
