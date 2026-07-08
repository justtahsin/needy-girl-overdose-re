using Rewired;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

public class RewiredScrollReceiver : MonoBehaviour
{
	[SerializeField]
	private RectTransform scrollContent;

	private Player _player;

	[SerializeField]
	private bool active = true;

	[SerializeField]
	private float SCROLL_SPEED = 600f;

	public void SetActive(bool active)
	{
		this.active = active;
	}

	private void Awake()
	{
		_player = ReInput.players.GetPlayer(0);
		(from _ in this.UpdateAsObservable()
			where active
			select _player.GetAxis("Scroll Vertical") * SCROLL_SPEED * Time.deltaTime into value
			where value != 0f
			select value).Subscribe(delegate(float verticalPostion)
		{
			Vector3 localPosition = scrollContent.localPosition;
			scrollContent.localPosition = new Vector2(localPosition.x, localPosition.y - verticalPostion);
		}).AddTo(base.gameObject);
	}
}
