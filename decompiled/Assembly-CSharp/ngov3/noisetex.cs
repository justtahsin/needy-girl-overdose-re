using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class noisetex : MonoBehaviour
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private Sprite[] _sprites;

	private int number;

	private void Update()
	{
		number = Time.frameCount / 4 % _sprites.Length;
		_image.sprite = _sprites[number];
	}
}
