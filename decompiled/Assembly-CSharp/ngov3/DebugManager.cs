using UnityEngine;

namespace ngov3;

public class DebugManager : MonoBehaviour
{
	[SerializeField]
	private bool isDebugBuild;

	private void Awake()
	{
		DebugMode.IsDebugMode = isDebugBuild;
		if (DebugMode.IsDebugMode)
		{
			Debug.Log("/////////// DEBUG BUILD ///////////");
		}
	}
}
