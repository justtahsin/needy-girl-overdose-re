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
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		_rend = ((Component)this).GetComponent<SpriteRenderer>();
		_matInstance = new Material(_stencilMaskedMaterial);
		((Renderer)_rend).material = _matInstance;
		((Renderer)_rend).material.SetFloat("_Stencil", (float)_stencil);
	}

	private void OnDestroy()
	{
		Object.Destroy((Object)(object)_matInstance);
	}
}
