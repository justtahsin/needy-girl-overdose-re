using System.Linq;
using UnityEngine;

namespace ngov3;

public class ChachedWindowParent : MonoBehaviour, IChachedWindowParent
{
	[SerializeField]
	private ChachedWindowObject[] chachedWindowObjects;

	[SerializeField]
	private ChachedWindowType chachedWindowType;

	public ChachedWindowType ChachedWindowType => chachedWindowType;

	public ChachedWindowObject Pop()
	{
		if (chachedWindowObjects.Where((ChachedWindowObject w) => !w.IsOpend).Count() == 0)
		{
			Debug.Log((object)"PopできるWindowがありません");
			return null;
		}
		return chachedWindowObjects.FirstOrDefault((ChachedWindowObject w) => !w.IsOpend);
	}
}
