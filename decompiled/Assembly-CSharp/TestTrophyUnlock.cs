using UnityEngine;

public class TestTrophyUnlock : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			TryUnlockTrophy(0);
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			TryUnlockTrophy(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			TryUnlockTrophy(2);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			TryUnlockTrophy(3);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			TryUnlockTrophy(4);
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			TryUnlockTrophy(5);
		}
		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			TryUnlockTrophy(6);
		}
		if (Input.GetKeyDown(KeyCode.Alpha7))
		{
			TryUnlockTrophy(7);
		}
		if (Input.GetKeyDown(KeyCode.Alpha8))
		{
			TryUnlockTrophy(8);
		}
		if (Input.GetKeyDown(KeyCode.Alpha9))
		{
			TryUnlockTrophy(9);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			TryUnlockTrophy(10);
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			TryUnlockTrophy(11);
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			TryUnlockTrophy(12);
		}
	}

	private void TryUnlockTrophy(int trophyId)
	{
		Debug.LogError("TryUnlock " + trophyId);
	}
}
