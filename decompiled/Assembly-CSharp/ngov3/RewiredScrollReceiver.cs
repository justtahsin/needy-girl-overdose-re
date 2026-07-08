using System;
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
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<float>(Observable.Where<float>(Observable.Select<Unit, float>(Observable.Where<Unit>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => active)), (Func<Unit, float>)((Unit _) => _player.GetAxis("Scroll Vertical") * SCROLL_SPEED * Time.deltaTime)), (Func<float, bool>)((float value) => value != 0f)), (Action<float>)delegate(float verticalPostion)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			Vector3 localPosition = ((Transform)scrollContent).localPosition;
			((Transform)scrollContent).localPosition = Vector2.op_Implicit(new Vector2(localPosition.x, localPosition.y - verticalPostion));
		}), ((Component)this).gameObject);
	}
}
