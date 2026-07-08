using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteStencilSetter : MonoBehaviour
{
	[SerializeField]
	private int _stencil;

	[SerializeField]
	private Material _stencilMaskedMaterial;

	private SpriteRenderer _rend;

	private Material _matInstance;

	private void Awake()
	{
		_rend = GetComponent<SpriteRenderer>();
		_matInstance = new Material(_stencilMaskedMaterial);
		_rend.material = _matInstance;
		_rend.material.SetFloat("_Stencil", _stencil);
	}

	private void OnDestroy()
	{
		Object.Destroy(_matInstance);
	}
}
