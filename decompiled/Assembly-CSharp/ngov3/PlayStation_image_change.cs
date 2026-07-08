using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class PlayStation_image_change : MonoBehaviour
{
	[SerializeField]
	[Header("Default Image")]
	private Sprite defaultImage;

	[Header("PS4 Image")]
	[SerializeField]
	private Sprite ps4Image;

	[Header("Image Component to Switch")]
	[SerializeField]
	private Image[] targetImageController;

	private void Start()
	{
		Sprite sprite = ((Application.platform == RuntimePlatform.PS4) ? ps4Image : defaultImage);
		for (int i = 0; i < targetImageController.Length; i++)
		{
			targetImageController[i].sprite = sprite;
		}
	}
}
