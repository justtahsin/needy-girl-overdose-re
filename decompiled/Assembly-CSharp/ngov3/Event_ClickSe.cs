using NGO;
using Rewired;
using UnityEngine;

namespace ngov3;

public class Event_ClickSe : MonoBehaviour
{
	private Player _player;

	private void Awake()
	{
		_player = ReInput.players.GetPlayer(0);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) || _player.GetButtonDown("Click"))
		{
			AudioManager.Instance?.PlaySeByType(SoundType.SE_poko);
		}
	}
}
