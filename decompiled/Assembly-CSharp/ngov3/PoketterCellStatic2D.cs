using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class PoketterCellStatic2D : MonoBehaviour
{
	[SerializeField]
	private TweetType tweetType = TweetType.None;

	[SerializeField]
	protected ResourceLocalMaster _resourceMaster;

	[SerializeField]
	protected SpriteRenderer _userIcon;

	[SerializeField]
	protected TMP_Text _userText;

	[SerializeField]
	protected TMP_Text _bodyText;

	[SerializeField]
	protected TMP_Text _dateText;

	[SerializeField]
	protected SpriteRenderer _image;

	[SerializeField]
	protected Sprite _omoteIcon;

	[SerializeField]
	protected Sprite _uraIcon;

	[SerializeField]
	protected TMP_Text _rtText;

	[SerializeField]
	protected TMP_Text _favText;

	[SerializeField]
	private RectTransform _kusoRepRoot;

	[SerializeField]
	private KusoRepView _kusoRepPrefab;

	[Header("ツイートが出現するときにスクロールする時間")]
	[SerializeField]
	private int _scrollMillisecond = 1000;

	[Header("ツイートがフェードインする時間")]
	[SerializeField]
	private int _fadeMillisecond = 300;

	[SerializeField]
	[Header("バズりパワーがテロテロする時間")]
	private int _buzzMillisecond = 1000;

	private TweetDrawable tweetDrawable;

	[SerializeField]
	private Fader2D fader;

	[Header("Layout Components")]
	[SerializeField]
	protected LayoutElement _postElement;

	[SerializeField]
	protected RectTransform _postRectTr;

	[SerializeField]
	protected LayoutElement _bodyElement;

	[SerializeField]
	protected RectTransform _bodyRectTr;

	[SerializeField]
	protected LayoutElement _userTextElement;

	[SerializeField]
	protected LayoutElement _bodyTextElement;

	[SerializeField]
	protected RectTransform _bodyTextRectTr;

	[SerializeField]
	protected LayoutElement _imageElement;

	[SerializeField]
	protected LayoutElement _buzzElement;

	[SerializeField]
	protected LayoutElement _datetElement;

	private bool _imageExist;

	[SerializeField]
	private ScrolllOverHungObject imageOverHungObject;

	public void Awake()
	{
		imageOverHungObject.SetParentRect(base.transform.parent.parent.GetComponent<RectTransform>());
		SetData(new TweetDrawable(new TweetData(tweetType, isOmote: true)));
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
		{
			OnLanguageUpdated();
		}).AddTo(base.gameObject);
	}

	public async UniTask SetData(TweetDrawable nakami)
	{
		tweetDrawable = nakami;
		SetUserIcon();
		SetUserName();
		FetchBody();
		_imageExist = await FetchTweetImage();
		SetLayout(_imageExist);
	}

	public void SetDataStatic(TweetDrawable nakami)
	{
		tweetDrawable = nakami;
		SetUserIcon();
		SetUserName();
		FetchBody();
		_dateText.text = NgoEx.DayText(tweetDrawable.Day, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) + " " + NgoEx.CmdName(nakami.cmdType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		FetchTweetImage();
		_rtText.text = ConvertGigaNumber(nakami.RtNumber);
		_favText.text = ConvertGigaNumber(nakami.FavNumber);
	}

	public void Animate()
	{
		Show();
		FavRtMove();
		ShowKusoReps();
	}

	protected virtual bool SetUserIcon()
	{
		_userIcon.sprite = (tweetDrawable.IsOmote ? _omoteIcon : _uraIcon);
		return _userIcon.sprite != null;
	}

	protected virtual bool SetUserName()
	{
		_userText.text = (tweetDrawable.IsOmote ? NgoEx.SystemTextFromType(SystemTextType.Account_Omote, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) : NgoEx.SystemTextFromType(SystemTextType.Account_Ura_Name, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		return !string.IsNullOrEmpty(_userText.text);
	}

	private void FetchBody()
	{
		_bodyText.text = NgoEx_Temp.FetchTweetBody(tweetDrawable);
	}

	private async UniTask<bool> FetchTweetImage()
	{
		bool hasImage = tweetDrawable.ImageId.IsNotEmpty();
		_image.gameObject.SetActive(hasImage);
		if (hasImage)
		{
			string imageId = tweetDrawable.ImageId;
			ResourceLocal resource = _resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == imageId);
			SingletonMonoBehaviour<Settings>.Instance.addImage(imageId);
			if (resource == null)
			{
				Debug.LogError("TWEET MASTER: " + imageId + " の 画像Id がなかったよ " + imageId);
				return false;
			}
			SpriteRenderer image = _image;
			image.sprite = await LoadPictures.LoadPictureAsync(resource.FileName, LoadPictures.PictureType.Poketter);
			Button component = _image.gameObject.GetComponent<Button>();
			component.OnClickAsObservable().Subscribe(delegate
			{
				ImageViewerHelper.OpenImageViewer(resource.FileName);
			}).AddTo(component.gameObject);
		}
		return hasImage;
	}

	private async UniTask Show()
	{
		fader.SetAlpha(0f);
		float duration = (float)_fadeMillisecond / 1000f;
		await fader.DOFade(duration, 1f);
	}

	private string ConvertGigaNumber(int number)
	{
		if (number > 1000000000)
		{
			return $"{number / 100000000}G";
		}
		if (number > 1000000)
		{
			return $"{number / 100000}M";
		}
		if (number > 10000)
		{
			return $"{number / 1000}K";
		}
		return number.ToString();
	}

	private void FavRtMove()
	{
		if (!tweetDrawable.IsOmote)
		{
			return;
		}
		float duration = (float)_buzzMillisecond / 1000f;
		if (tweetDrawable.RtNumber > 0)
		{
			_rtText.DOCounter(0, tweetDrawable.RtNumber, duration).OnComplete(delegate
			{
				_rtText.text = ConvertGigaNumber(tweetDrawable.RtNumber);
			}).Play();
		}
		if (tweetDrawable.FavNumber > 0)
		{
			_favText.DOCounter(0, tweetDrawable.FavNumber, duration).OnComplete(delegate
			{
				_favText.text = ConvertGigaNumber(tweetDrawable.FavNumber);
			}).Play();
		}
	}

	private async void ShowKusoReps()
	{
		for (int i = 0; i < _kusoRepRoot.childCount; i++)
		{
			await _kusoRepRoot.GetChild(i).GetComponent<KusoRepView>().Show();
		}
	}

	private async void SetLayout(bool imageExist)
	{
		await UniTask.DelayFrame(2);
		_bodyTextElement.minHeight = _bodyText.preferredHeight;
		float num = 0f;
		float num2 = 6f;
		num += _userTextElement.minHeight + num2;
		num += _bodyTextElement.minHeight + num2;
		if (imageExist)
		{
			num += _imageElement.minHeight + num2;
		}
		num += _buzzElement.minHeight + num2;
		num += _datetElement.minHeight;
		_bodyElement.minHeight = num;
		_postElement.minHeight = num;
		_bodyRectTr.sizeDelta = new Vector2(_bodyRectTr.sizeDelta.x, num);
		_postRectTr.sizeDelta = new Vector2(_postRectTr.sizeDelta.x, num);
	}

	public void OnLanguageUpdated()
	{
		SetUserName();
		FetchBody();
	}
}
