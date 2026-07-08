using UnityEngine;

namespace ngov3;

public class DebugButton : MonoBehaviour
{
	private void Awake()
	{
		if (!DebugMode.IsDebugMode)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
