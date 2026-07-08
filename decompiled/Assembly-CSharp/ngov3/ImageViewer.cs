using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ImageViewer : MonoBehaviour
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private RectMask2D _mask;

	[SerializeField]
	private Sprite medama;

	[SerializeField]
	private Sprite medama2;

	[SerializeField]
	private Sprite medama3;

	[SerializeField]
	private Sprite medama4;

	[SerializeField]
	private Text kowai;

	[SerializeField]
	private Image bg;

	private string _imageAddress = "N/A";

	public string ImageAddress => _imageAddress;

	public void Awake()
	{
		float height = _mask.transform.parent.GetComponent<RectTransform>().rect.height;
		_mask.padding = new Vector4(0f, height, 0f, 0f);
	}

	public async UniTaskVoid SetData(string address)
	{
		Image image = _image;
		image.sprite = await LoadPictures.LoadPictureAsync(address, LoadPictures.PictureType.ImageViewer);
		_imageAddress = address;
		Show();
	}

	public void setMedama(int number)
	{
		bg.color = new Color(0f, 0f, 0f);
		_image.sprite = medama;
		Blink(NgoEx.SystemTextFromTypeString("KowaiInternet" + number, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
	}

	private void Blink(string nakami)
	{
		DOTween.Sequence().Append(DOTween.To(() => _mask.padding, delegate(Vector4 x)
		{
			_mask.padding = x;
		}, new Vector4(0f, 0f, 0f, 0f), 1.2f)).AppendInterval(0.15f)
			.AppendCallback(delegate
			{
				_image.sprite = medama2;
			})
			.AppendInterval(0.15f)
			.AppendCallback(delegate
			{
				_image.sprite = medama3;
			})
			.AppendInterval(0.15f)
			.AppendCallback(delegate
			{
				_image.sprite = medama4;
			})
			.AppendInterval(0.5f)
			.AppendCallback(delegate
			{
				_image.sprite = medama3;
			})
			.AppendInterval(0.15f)
			.AppendCallback(delegate
			{
				_image.sprite = medama;
			})
			.AppendInterval(0.1f)
			.AppendCallback(delegate
			{
				_image.gameObject.SetActive(value: false);
			})
			.AppendCallback(delegate
			{
				kowai.text = nakami;
				if (nakami.Length > 30)
				{
					RectTransform rectTransform = kowai.rectTransform;
					Vector2 offsetMax = (rectTransform.offsetMin = new Vector2(0f, 0f));
					rectTransform.offsetMax = offsetMax;
				}
				else
				{
					RectTransform rectTransform2 = kowai.rectTransform;
					Vector2 vector2 = (rectTransform2.offsetMin = new Vector2(20f, 20f));
					rectTransform2.offsetMax = vector2 * -1f;
				}
			})
			.OnComplete(delegate
			{
				kowai.gameObject.transform.DOShakePosition(1f, 1f, 10, 30f, snapping: true, fadeOut: false).SetLoops(-1, LoopType.Yoyo).SetRelative(isRelative: true)
					.Play();
			})
			.SetEase(Ease.OutCubic)
			.Play();
	}

	private void Show()
	{
		DOTween.To(() => _mask.padding, delegate(Vector4 x)
		{
			_mask.padding = x;
		}, new Vector4(0f, 0f, 0f, 0f), 1f).SetEase(Ease.InCubic).Play();
	}

	private void OnDestroy()
	{
		if (_imageAddress != "N/A")
		{
			LoadPictures.DeleteCache(_imageAddress, LoadPictures.PictureType.ImageViewer);
		}
	}

	public async void CashedSetUp(int number)
	{
		float height = _mask.transform.parent.GetComponent<RectTransform>().rect.height;
		_mask.padding = new Vector4(0f, height, 0f, 0f);
		bg.color = new Color(0f, 0f, 0f);
		_image.sprite = medama;
		Blink(NgoEx.SystemTextFromTypeString("KowaiInternet" + number, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		kowai.text = "";
		await UniTask.Delay(1100);
		Show();
	}
}
