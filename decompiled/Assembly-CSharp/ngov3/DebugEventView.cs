using UnityEngine;

namespace ngov3;

public class DebugEventView : MonoBehaviour
{
	private bool IsDebug => false;

	private void Awake()
	{
		base.gameObject.SetActive(IsDebug);
	}
}
