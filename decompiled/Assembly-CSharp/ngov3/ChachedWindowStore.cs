using System.Linq;
using UnityEngine;

namespace ngov3;

public class ChachedWindowStore : SingletonMonoBehaviour<ChachedWindowStore>
{
	[SerializeField]
	private ChachedWindowParent[] chachedWindowParents;

	public IChachedWindowParent GetChachedWindowParent(ChachedWindowType chachedWindowType)
	{
		return chachedWindowParents.FirstOrDefault((ChachedWindowParent cwp) => cwp.ChachedWindowType == chachedWindowType);
	}
}
