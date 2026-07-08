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
		_rend = GetComponent<SpriteRenderer>();
		_matInstance = new Material(_stencilMaskMaterial);
		_rend.material = _matInstance;
		SetStencilID(_stencilId);
		RectTransform rectTr = GetComponent<RectTransform>();
		(from _ in this.UpdateAsObservable()
			select rectTr.rect).DistinctUntilChanged().Subscribe(delegate(Rect rect)
		{
			_rend.size = new Vector2(rect.width, rect.height);
		});
	}

	public void SetStencilID(int id)
	{
		_stencilId = id;
		_rend.material.SetFloat("_Stencil", _stencilId);
	}
}
