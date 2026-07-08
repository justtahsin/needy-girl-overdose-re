using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class KusoRepView : MonoBehaviour, ILayoutElement2D
{
	[SerializeField]
	protected ResourceLocalMaster _resourceMaster;

	[SerializeField]
	protected Image _userIcon;

	[SerializeField]
	protected Image _userImage;

	[SerializeField]
	protected Text _userName;

	[SerializeField]
	protected Text _bodyText;

	private CanvasGroup canvas;

	private RectTransform Rect;

	private KusoRepDrawable nakami;

	private Subject<Unit> onDestroySubject = new Subject<Unit>();

	[SerializeField]
	private RectTransform hightSyncObject;

	[SerializeField]
	private float minHight = 40f;

	public LayoutElement2DType LayoutElement2DType => LayoutElement2DType.OBJECT;

	public RectTransform RectTransform => Rect;

	public IObservable<Unit> OnDestroyObservable => onDestroySubject;

	public void Awake()
	{
		(from _ in this.UpdateAsObservable()
			select hightSyncObject.sizeDelta.y).DistinctUntilChanged().Subscribe(delegate(float targetHight)
		{
			targetHight = ((minHight > targetHight) ? minHight : targetHight);
			Rect.sizeDelta = new Vector2(Rect.sizeDelta.x, targetHight);
		}).AddTo(base.gameObject);
		canvas = GetComponent<CanvasGroup>();
		canvas.alpha = 0f;
		Rect = GetComponent<RectTransform>();
		Rect.localScale = new Vector3(1f, 0f, 1f);
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate(LanguageType t)
		{
			OnLanguageUpdated(t);
		}).AddTo(base.gameObject);
	}

	public bool SetData(KusoRepDrawable content)
	{
		nakami = content;
		SetUserName();
		SetUserImage();
		SetBody(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		SetUserIcon();
		return true;
	}

	public async UniTask Show()
	{
		base.transform.SetAsFirstSibling();
		float duration = 0.6f;
		float fade = 0.3f;
		AudioManager.Instance?.PlaySeByType(SoundType.SE_tweet_kusorep);
		try
		{
			await Rect.DOScaleY(1f, duration).Play();
			await canvas.DOFade(1f, fade).Play();
		}
		catch (OperationCanceledException)
		{
			Rect.localScale = new Vector3(1f, 1f, 1f);
			canvas.alpha = 1f;
		}
	}

	public void ShowPosted()
	{
		base.transform.SetAsFirstSibling();
		Rect.localScale = new Vector3(1f, 1f, 1f);
		canvas.alpha = 1f;
	}

	protected virtual bool SetUserName()
	{
		if (nakami.UserId != "N/A" && nakami.UserId != "")
		{
			_userName.text = "from " + nakami.UserId;
		}
		else
		{
			_userName.gameObject.SetActive(value: false);
		}
		return !string.IsNullOrEmpty(_userName.text);
	}

	protected virtual bool SetBody(LanguageType lang)
	{
		switch (lang)
		{
		case LanguageType.JP:
			_bodyText.text = nakami.BodyJp;
			break;
		case LanguageType.CN:
			_bodyText.text = nakami.BodyCn;
			break;
		case LanguageType.KO:
			_bodyText.text = nakami.BodyKo;
			break;
		case LanguageType.TW:
			_bodyText.text = nakami.BodyTw;
			break;
		case LanguageType.VN:
			_bodyText.text = nakami.BodyVn;
			break;
		case LanguageType.FR:
			_bodyText.text = nakami.BodyFr;
			break;
		case LanguageType.IT:
			_bodyText.text = nakami.BodyIt;
			break;
		case LanguageType.GE:
			_bodyText.text = nakami.BodyGe;
			break;
		case LanguageType.SP:
			_bodyText.text = nakami.BodySp;
			break;
		case LanguageType.RU:
			_bodyText.text = nakami.BodyRu;
			break;
		default:
			_bodyText.text = nakami.BodyEn;
			break;
		}
		if (nakami.BodyJp == "N/A")
		{
			_bodyText.gameObject.SetActive(value: false);
		}
		return _bodyText.text != string.Empty;
	}

	protected virtual async UniTask<bool> SetUserImage()
	{
		if (nakami.ImageId != "N/A")
		{
			ResourceLocal resource = _resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == nakami.ImageId);
			if (resource == null)
			{
				return false;
			}
			SingletonMonoBehaviour<Settings>.Instance.addImage(nakami.ImageId);
			Image userImage = _userImage;
			userImage.sprite = await LoadPictures.LoadPictureAsync(resource.FileName, LoadPictures.PictureType.Poketter);
			_userImage.gameObject.SetActive(value: true);
			Button component = _userImage.gameObject.GetComponent<Button>();
			component.OnClickAsObservable().Subscribe(delegate
			{
				ImageViewerHelper.OpenImageViewer(resource.FileName);
			}).AddTo(component.gameObject);
			return _userImage.sprite != null;
		}
		return false;
	}

	private void OnDestroy()
	{
		onDestroySubject.OnNext(Unit.Default);
		onDestroySubject.OnCompleted();
	}

	protected virtual bool SetUserIcon()
	{
		if (nakami.UserIconId.IsNotEmpty())
		{
			_userIcon.sprite = Resources.Load<Sprite>("icons/" + nakami.UserIconId);
			return _userIcon.sprite != null;
		}
		return false;
	}

	public void OnLanguageUpdated(LanguageType type)
	{
		SetBody(type);
	}
}
