using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class MyPictureContentView : MonoBehaviour
{
	[SerializeField]
	private MyPictureContent _content;

	[SerializeField]
	private Button _picture;

	[SerializeField]
	private TMP_Text _title;

	public async UniTaskVoid SetContent(MyPictureContent content)
	{
		_content = content;
		_title.text = _content.Title;
		Image image = _picture.image;
		image.sprite = await LoadPictures.LoadPictureAsync(_content?.FileName, LoadPictures.PictureType.MyPicture);
		_picture.OnClickAsObservable().Subscribe(delegate
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.ImageViewer).nakamiApp.GetComponent<ImageViewer>().SetData(_content.FileName);
		}).AddTo(base.gameObject);
	}

	public async UniTask SetContentStatic(MyPictureContent content)
	{
		_content = content;
		_title.text = _content.Title;
		Image image = _picture.image;
		image.sprite = await LoadPictures.LoadPictureAsync(_content?.FileName, LoadPictures.PictureType.MyPicture);
	}
}
