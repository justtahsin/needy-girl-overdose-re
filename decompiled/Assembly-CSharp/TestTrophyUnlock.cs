using UnityEngine;

public class TestTrophyUnlock : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown((KeyCode)48))
		{
			TryUnlockTrophy(0);
		}
		if (Input.GetKeyDown((KeyCode)49))
		{
			TryUnlockTrophy(1);
		}
		if (Input.GetKeyDown((KeyCode)50))
		{
			TryUnlockTrophy(2);
		}
		if (Input.GetKeyDown((KeyCode)51))
		{
			TryUnlockTrophy(3);
		}
		if (Input.GetKeyDown((KeyCode)52))
		{
			TryUnlockTrophy(4);
		}
		if (Input.GetKeyDown((KeyCode)53))
		{
			TryUnlockTrophy(5);
		}
		if (Input.GetKeyDown((KeyCode)54))
		{
			TryUnlockTrophy(6);
		}
		if (Input.GetKeyDown((KeyCode)55))
		{
			TryUnlockTrophy(7);
		}
		if (Input.GetKeyDown((KeyCode)56))
		{
			TryUnlockTrophy(8);
		}
		if (Input.GetKeyDown((KeyCode)57))
		{
			TryUnlockTrophy(9);
		}
		if (Input.GetKeyDown((KeyCode)97))
		{
			TryUnlockTrophy(10);
		}
		if (Input.GetKeyDown((KeyCode)98))
		{
			TryUnlockTrophy(11);
		}
		if (Input.GetKeyDown((KeyCode)99))
		{
			TryUnlockTrophy(12);
		}
	}

	private void TryUnlockTrophy(int trophyId)
	{
		Debug.LogError((object)("TryUnlock " + trophyId));
	}
}
