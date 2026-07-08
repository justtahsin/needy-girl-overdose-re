using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public sealed class PicturePreview : MonoBehaviour
{
	private MyPictureContent _content;

	[SerializeField]
	private Image _Image;

	private void Close()
	{
		_content = null;
		_Image.sprite = null;
	}

	public async UniTaskVoid SetContent(MyPictureContent content)
	{
		AspectRatioFitter fitter = _Image.GetComponent<AspectRatioFitter>();
		_content = content;
		Image image = _Image;
		image.sprite = await LoadPictures.LoadPictureAsync(content.FileName, LoadPictures.PictureType.MyPicture);
		float num = _Image.sprite.texture.width;
		float num2 = _Image.sprite.texture.height;
		bool flag = num > num2;
		fitter.aspectMode = (flag ? AspectRatioFitter.AspectMode.WidthControlsHeight : AspectRatioFitter.AspectMode.HeightControlsWidth);
		fitter.aspectRatio = (flag ? (num / num2) : (num2 / num));
	}
}
