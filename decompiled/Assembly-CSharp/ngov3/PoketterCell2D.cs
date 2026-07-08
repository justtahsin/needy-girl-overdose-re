using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace ngov3;

public class PoketterCell2D : MonoBehaviour
{
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
	private KusoRepView2D _kusoRepPrefab;

	[SerializeField]
	[Header("\ufffdc\ufffdC\ufffd[\ufffdg\ufffd\ufffd\ufffdo\ufffd\ufffd\ufffd\ufffd\ufffd\ufffdƂ\ufffd\ufffdɃX\ufffdN\ufffd\ufffd\ufffd[\ufffd\ufffd\ufffd\ufffd\ufffd鎞\ufffd\ufffd")]
	private int _scrollMillisecond = 1000;

	[Header("\ufffdc\ufffdC\ufffd[\ufffdg\ufffd\ufffd\ufffdt\ufffdF\ufffd[\ufffdh\ufffdC\ufffd\ufffd\ufffd\ufffd\ufffd鎞\ufffd\ufffd")]
	[SerializeField]
	private int _fadeMillisecond = 300;

	[SerializeField]
	[Header("\ufffdo\ufffdY\ufffd\ufffdp\ufffd\ufffd\ufffd[\ufffd\ufffd\ufffde\ufffd\ufffd\ufffde\ufffd\ufffd\ufffd\ufffd\ufffd鎞\ufffd\ufffd")]
	private int _buzzMillisecond = 1000;

	private TweetDrawable tweetDrawable;

	[SerializeField]
	private Fader2D fader;

	[SerializeField]
	private Button2D imageButton;

	private List<KusoRepView2D> _kusoreps = new List<KusoRepView2D>();

	private string _imageFileName = "N/A";

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
	protected RectTransform _userTextRectTr;

	[SerializeField]
	protected LayoutElement _bodyTextElement;

	[SerializeField]
	protected RectTransform _bodyTextRectTr;

	[SerializeField]
	protected LayoutElement _imageElement;

	[SerializeField]
	protected RectTransform _imageRectTr;

	[SerializeField]
	protected LayoutElement _buzzElement;

	[SerializeField]
	protected RectTransform _buzzRectTr;

	[SerializeField]
	protected LayoutElement _datetElement;

	[SerializeField]
	protected RectTransform _dateRectTr;

	[SerializeField]
	protected VerticalLayoutGroup _kusorepParentGroup;

	private bool _imageExist;

	[SerializeField]
	private ScrolllOverHungObject imageOverHungObject;

	public void Awake()
	{
		_kusorepParentGroup.enabled = false;
		imageOverHungObject.SetParentRect(base.transform.parent.parent.GetComponent<RectTransform>());
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
		{
			OnLanguageUpdated();
		}).AddTo(base.gameObject);
	}

	public async UniTask SetData(TweetDrawable nakami)
	{
		fader.SetAlpha(0f);
		tweetDrawable = nakami;
		SetUserIcon();
		SetUserName();
		FetchBody();
		if (tweetDrawable.Day >= 30)
		{
			_dateText.text = "????";
		}
		else
		{
			_dateText.text = NgoEx.DayText(tweetDrawable.Day, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) + " " + NgoEx.CmdName(tweetDrawable.cmdType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		_imageExist = await FetchTweetImage();
		SetLayout(_imageExist);
		if (_imageExist)
		{
			await UniTask.DelayFrame(1);
		}
		if (!_imageExist && _bodyText.text == "\"")
		{
			Debug.Log("ここで本文・Imageともに空だった場合はTweetを破棄する");
			base.gameObject.SetActive(value: false);
		}
		if (_bodyText.text == "" || _bodyText.text == "N/A" || _bodyText.text == "”")
		{
			Debug.Log("bodyTextがN/Aか空文字だった場合はTweetを破棄する");
			base.gameObject.SetActive(value: false);
		}
	}

	public async UniTask SetDataStatic(TweetDrawable nakami)
	{
		tweetDrawable = nakami;
		SetUserIcon();
		SetUserName();
		FetchBody();
		if (tweetDrawable.Day >= 30)
		{
			_dateText.text = "????";
		}
		else
		{
			_dateText.text = NgoEx.DayText(tweetDrawable.Day, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) + " " + NgoEx.CmdName(tweetDrawable.cmdType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		_imageExist = await FetchTweetImage();
		SetLayout(_imageExist);
		SetKusoRepStatic().Forget();
		_rtText.text = ConvertGigaNumber(nakami.RtNumber);
		_favText.text = ConvertGigaNumber(nakami.FavNumber);
		Debug.Log("描画判定");
		if (!_imageExist && _bodyText.text == "")
		{
			Debug.Log("ここで本文・Imageともに空だった場合はTweetを破棄する");
			base.gameObject.SetActive(value: false);
		}
	}

	public async UniTask Animate()
	{
		await Show();
		FavRtMove();
		ShowKusoReps().Forget();
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
		_bodyText.text = NgoEx.GetTweetBody(tweetDrawable, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	private async UniTask<bool> FetchTweetImage()
	{
		bool hasImage = tweetDrawable.ImageId.IsNotEmpty();
		_image.gameObject.SetActive(hasImage);
		if (hasImage)
		{
			string imageId = tweetDrawable.ImageId;
			ResourceLocal resource = _resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == imageId);
			if (resource == null)
			{
				Debug.Log("TWEET MASTERリソースがないよ！:" + imageId);
				_image.gameObject.SetActive(value: false);
				return false;
			}
			SingletonMonoBehaviour<Settings>.Instance.addImage(imageId);
			Sprite sprite = await LoadPictures.LoadPictureAsync(resource.FileName, LoadPictures.PictureType.Poketter);
			_image.sprite = sprite;
			_imageFileName = resource.FileName;
			if (imageId == "MV_thumbnail")
			{
				imageButton.onClick.AddListener(async delegate
				{
					await PlayMV();
				});
				return true;
			}
			imageButton.onClick.AddListener(delegate
			{
				ImageViewerHelper.OpenImageViewer(resource.FileName);
			});
		}
		return hasImage;
	}

	private async UniTask PlayMV()
	{
		imageButton.enabled = false;
		SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(ShortcutInputManager.ControllerMode.MV_Playing);
		VideoPlayer videoViewer = GameObject.Find("Main Camera").GetComponent<VideoPlayer>();
		videoViewer.clip = Resources.Load<VideoClip>("Videos/INTERNETOVERDOSE");
		videoViewer.Prepare();
		await UniTask.WaitUntil(() => videoViewer.isPrepared, PlayerLoopTiming.Update, this.GetCancellationTokenOnDestroy());
		videoViewer.aspectRatio = VideoAspectRatio.FitInside;
		videoViewer.SetDirectAudioVolume(0, SingletonMonoBehaviour<Settings>.Instance.BgmVolume);
		AudioManager.Instance.StopBgm();
		videoViewer.targetCameraAlpha = 1f;
		videoViewer.Play();
		await NgoEvent.DelaySkippable(2000);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_InternetOverdose);
		await UniTask.WhenAny(NgoEvent.DelaySkippable(224000), UniTask.WaitUntil(() => SingletonMonoBehaviour<ShortcutInputManager>.Instance.Player.GetButtonDown("StopPlaying")));
		videoViewer.targetCameraAlpha = 0f;
		videoViewer.Stop();
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_InternetOverdose8bit, isLoop: true);
		videoViewer.aspectRatio = VideoAspectRatio.FitHorizontally;
		imageButton.enabled = true;
		SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(ShortcutInputManager.ControllerMode.Desktop);
	}

	[ContextMenu("\ufffdt\ufffdF\ufffd[\ufffd_\ufffd[\ufffdA\ufffdj\ufffd\ufffd\ufffd\u030e\ufffd\ufffds")]
	private async UniTask Show()
	{
		fader.SetAlpha(0f);
		RectTransform component = GetComponent<RectTransform>();
		component.localScale = new Vector3(1f, 0f, 1f);
		float duration = (float)_scrollMillisecond / 1000f;
		await component.DOScaleY(1f, duration).Play();
		await fader.DOFade(1f, 1f);
		await NgoEvent.DelaySkippable(_bodyText.text.Length * 10);
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

	private async UniTask SetKusoRepStatic()
	{
		if (tweetDrawable.kusoReps.Count > 0)
		{
			_kusorepParentGroup.enabled = true;
		}
		foreach (KusoRepDrawable kusoRep in tweetDrawable.kusoReps)
		{
			KusoRepView2D kusorep = Object.Instantiate(_kusoRepPrefab, _kusoRepRoot.transform);
			_kusoreps.Add(kusorep);
			await kusorep.SetData(kusoRep);
			kusorep.ShowPosted();
		}
	}

	private async UniTask ShowKusoReps()
	{
		if (tweetDrawable.kusoReps.Count > 0)
		{
			_kusorepParentGroup.enabled = true;
		}
		foreach (KusoRepDrawable kusoRep in tweetDrawable.kusoReps)
		{
			KusoRepView2D kusoRepView2D = Object.Instantiate(_kusoRepPrefab, _kusoRepRoot.transform);
			_kusoreps.Add(kusoRepView2D);
			await kusoRepView2D.SetData(kusoRep);
		}
		if (_kusoRepRoot.childCount != 0)
		{
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
		}
		for (int i = 0; i < _kusoRepRoot.childCount; i++)
		{
			await _kusoRepRoot.GetChild(i).GetComponent<KusoRepView2D>().Show();
		}
	}

	private async void SetLayout(bool imageExist)
	{
		await UniTask.DelayFrame(2);
		_bodyTextElement.minHeight = _bodyText.preferredHeight;
		_bodyTextRectTr.sizeDelta = new Vector2(_bodyTextRectTr.sizeDelta.x, _bodyTextElement.minHeight);
		float num = 0f;
		float num2 = 6f;
		float num3 = 0f;
		num += _userTextElement.minHeight + num2;
		num3 -= _userTextElement.minHeight / 2f;
		_userTextRectTr.anchoredPosition = new Vector2(_userTextRectTr.anchoredPosition.x, num3);
		num3 -= _userTextElement.minHeight / 2f;
		num3 -= num2;
		num += _bodyTextElement.minHeight + num2;
		num3 -= _bodyTextElement.minHeight / 2f;
		_bodyTextRectTr.anchoredPosition = new Vector2(_bodyTextRectTr.anchoredPosition.x, num3);
		num3 -= _bodyTextElement.minHeight / 2f;
		num3 -= num2;
		if (imageExist)
		{
			num += _imageElement.minHeight + num2;
			num3 -= _imageElement.minHeight / 2f;
			_imageRectTr.anchoredPosition = new Vector2(_imageRectTr.anchoredPosition.x, num3);
			num3 -= _imageElement.minHeight / 2f;
			num3 -= num2;
		}
		num += _buzzElement.minHeight + num2;
		num3 -= _buzzElement.minHeight / 2f;
		_buzzRectTr.anchoredPosition = new Vector2(_buzzRectTr.anchoredPosition.x, num3);
		num3 -= _buzzElement.minHeight / 2f;
		num3 -= num2;
		num += _datetElement.minHeight;
		num3 -= _datetElement.minHeight / 2f;
		_dateRectTr.anchoredPosition = new Vector2(_dateRectTr.anchoredPosition.x, num3);
		_bodyElement.minHeight = num;
		_postElement.minHeight = num;
		_bodyRectTr.sizeDelta = new Vector2(_bodyRectTr.sizeDelta.x, num);
		_postRectTr.sizeDelta = new Vector2(_postRectTr.sizeDelta.x, num);
	}

	private void OnDestroy()
	{
		if (_imageFileName != "N/A")
		{
			LoadPictures.DeleteCache(_imageFileName, LoadPictures.PictureType.Poketter);
		}
	}

	public void OnLanguageUpdated()
	{
		SetUserName();
		FetchBody();
		if (tweetDrawable.Day >= 30)
		{
			_dateText.text = "????";
		}
		else
		{
			_dateText.text = NgoEx.DayText(tweetDrawable.Day, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) + " " + NgoEx.CmdName(tweetDrawable.cmdType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		SetLayout(_imageExist);
	}
}
