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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		Sprite sprite = (((int)Application.platform == 25) ? ps4Image : defaultImage);
		for (int i = 0; i < targetImageController.Length; i++)
		{
			targetImageController[i].sprite = sprite;
		}
	}
}
