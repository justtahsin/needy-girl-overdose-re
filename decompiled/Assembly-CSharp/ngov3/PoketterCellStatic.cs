using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class PoketterCellStatic : MonoBehaviour
{
	[SerializeField]
	private TweetType tweetType = TweetType.None;

	[SerializeField]
	protected ResourceLocalMaster _resourceMaster;

	[SerializeField]
	protected Image _userIcon;

	[SerializeField]
	protected TMP_Text _userText;

	[SerializeField]
	protected TMP_Text _bodyText;

	[SerializeField]
	protected TMP_Text _dateText;

	[SerializeField]
	protected Image _image;

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

	[Header("バズりパワーがテロテロする時間")]
	[SerializeField]
	private int _buzzMillisecond = 1000;

	private TweetDrawable tweetDrawable;

	private CanvasGroup _baseCanvasGroup;

	public void Awake()
	{
		SetData(new TweetDrawable(new TweetData(tweetType, isOmote: true)));
		_baseCanvasGroup = GetComponent<CanvasGroup>();
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
		{
			OnLanguageUpdated();
		}).AddTo(base.gameObject);
	}

	public void SetData(TweetDrawable nakami)
	{
		tweetDrawable = nakami;
		SetUserIcon();
		SetUserName();
		FetchBody();
		FetchTweetImage();
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
		switch (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)
		{
		case LanguageType.JP:
			_bodyText.text = tweetDrawable.BodyJp;
			break;
		case LanguageType.CN:
			_bodyText.text = tweetDrawable.BodyCn;
			break;
		case LanguageType.KO:
			_bodyText.text = tweetDrawable.BodyKo;
			break;
		case LanguageType.TW:
			_bodyText.text = tweetDrawable.BodyTw;
			break;
		case LanguageType.VN:
			_bodyText.text = tweetDrawable.BodyVn;
			break;
		case LanguageType.FR:
			_bodyText.text = tweetDrawable.BodyFr;
			break;
		case LanguageType.IT:
			_bodyText.text = tweetDrawable.BodyIt;
			break;
		case LanguageType.GE:
			_bodyText.text = tweetDrawable.BodyGe;
			break;
		case LanguageType.SP:
			_bodyText.text = tweetDrawable.BodySp;
			break;
		case LanguageType.RU:
			_bodyText.text = tweetDrawable.BodyRu;
			break;
		default:
			_bodyText.text = tweetDrawable.BodyEn;
			break;
		}
	}

	private async UniTaskVoid FetchTweetImage()
	{
		bool flag = tweetDrawable.ImageId.IsNotEmpty();
		_image.gameObject.SetActive(flag);
		if (flag)
		{
			string imageId = tweetDrawable.ImageId;
			ResourceLocal resource = _resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == imageId);
			SingletonMonoBehaviour<Settings>.Instance.addImage(imageId);
			if (resource == null)
			{
				Debug.LogError("TWEET MASTER: " + imageId + " の 画像Id がなかったよ " + imageId);
			}
			Image image = _image;
			image.sprite = await LoadPictures.LoadPictureAsync(resource.FileName, LoadPictures.PictureType.Poketter);
			Button component = _image.gameObject.GetComponent<Button>();
			component.OnClickAsObservable().Subscribe(delegate
			{
				ImageViewerHelper.OpenImageViewer(resource.FileName);
			}).AddTo(component.gameObject);
		}
	}

	private void Show()
	{
		_baseCanvasGroup.alpha = 0f;
		_ = (float)_scrollMillisecond / 1000f;
		float duration = (float)_fadeMillisecond / 1000f;
		CancellationToken cancellationTokenOnDestroy = base.gameObject.GetCancellationTokenOnDestroy();
		_baseCanvasGroup.DOFade(1f, duration).Play().WithCancellation(cancellationTokenOnDestroy);
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

	private void SetKusoRep()
	{
		foreach (KusoRepDrawable kusoRep in tweetDrawable.kusoReps)
		{
			Object.Instantiate(_kusoRepPrefab, _kusoRepRoot.transform).SetData(kusoRep);
		}
	}

	private void SetKusoRepStatic()
	{
		foreach (KusoRepDrawable kusoRep in tweetDrawable.kusoReps)
		{
			KusoRepView kusoRepView = Object.Instantiate(_kusoRepPrefab, _kusoRepRoot.transform);
			kusoRepView.SetData(kusoRep);
			kusoRepView.ShowPosted();
		}
	}

	private async void ShowKusoReps()
	{
		for (int i = 0; i < _kusoRepRoot.childCount; i++)
		{
			await _kusoRepRoot.GetChild(i).GetComponent<KusoRepView>().Show();
		}
	}

	public void OnLanguageUpdated()
	{
		SetUserName();
		FetchBody();
	}
}
