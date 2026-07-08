using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(RectTransform))]
public class WindowStencilMask : MonoBehaviour
{
	[SerializeField]
	private int _stencilId;

	[SerializeField]
	private Material _stencilMaskMaterial;

	private SpriteRenderer _rend;

	private Material _matInstance;

	private void Awake()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		_rend = ((Component)this).GetComponent<SpriteRenderer>();
		_matInstance = new Material(_stencilMaskMaterial);
		((Renderer)_rend).material = _matInstance;
		SetStencilID(_stencilId);
		RectTransform rectTr = ((Component)this).GetComponent<RectTransform>();
		ObservableExtensions.Subscribe<Rect>(Observable.DistinctUntilChanged<Rect>(Observable.Select<Unit, Rect>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, Rect>)((Unit _) => rectTr.rect))), (Action<Rect>)delegate(Rect rect)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			_rend.size = new Vector2(((Rect)(ref rect)).width, ((Rect)(ref rect)).height);
		});
	}

	public void SetStencilID(int id)
	{
		_stencilId = id;
		((Renderer)_rend).material.SetFloat("_Stencil", (float)_stencilId);
	}
}
