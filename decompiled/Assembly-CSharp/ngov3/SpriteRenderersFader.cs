using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ngov3;

public class SpriteRenderersFader : MonoBehaviour
{
	[SerializeField]
	private List<SpriteRenderer> _renderers = new List<SpriteRenderer>();

	[Range(0f, 1f)]
	[SerializeField]
	private float _alpha = 1f;

	public float Alpha
	{
		get
		{
			return _alpha;
		}
		set
		{
			_alpha = value;
			foreach (SpriteRenderer renderer in _renderers)
			{
				Color color = renderer.color;
				color.a = _alpha;
				renderer.color = color;
			}
		}
	}

	private async UniTask OnChangeAlpha()
	{
		await UniTask.WaitForEndOfFrame();
		foreach (SpriteRenderer renderer in _renderers)
		{
			Color color = renderer.color;
			color.a = _alpha;
			renderer.color = color;
		}
	}
}
