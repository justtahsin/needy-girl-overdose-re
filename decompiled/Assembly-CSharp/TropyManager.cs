using UnityEngine;

public class TropyManager : MonoBehaviour
{
	public static TropyManager Instance;

	private int maxPlayerId = 4;

	private int connectedPlayerId = -1;

	private bool hasSetupGamepad;

	private void Awake()
	{
		if (Object.FindObjectsOfType<TropyManager>().Length > 1)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Object.DontDestroyOnLoad(base.gameObject);
		}
	}
}
