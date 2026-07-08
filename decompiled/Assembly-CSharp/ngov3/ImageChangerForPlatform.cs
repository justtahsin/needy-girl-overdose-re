using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ImageChangerForPlatform : MonoBehaviour
{
	[SerializeField]
	private Sprite imageDiffForCERO_D;

	[SerializeField]
	private Sprite imageDiffForSteam;

	[SerializeField]
	private Image targetImage;

	private void Start()
	{
		Sprite sprite = imageDiffForSteam;
		targetImage.sprite = sprite;
	}
}
