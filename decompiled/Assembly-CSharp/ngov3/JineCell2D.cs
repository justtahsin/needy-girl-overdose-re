using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class JineCell2D : MonoBehaviour, ILayoutElement2D, IRectMaskableObject
{
	[SerializeField]
	private ResourceLocalMaster _resourceMaster;

	[SerializeField]
	private TMP_Text honbun;

	[SerializeField]
	private TMP_Text _kidoku;

	[SerializeField]
	private SpriteRenderer stampWaku;

	[SerializeField]
	private SpriteRenderer _image;

	[SerializeField]
	private GameObject balloon;

	[SerializeField]
	private SpriteRenderer _balloonRend;

	[SerializeField]
	private SpriteRenderer _tailRend;

	[SerializeField]
	private Fader2D cellalpha;

	private bool langChangeSetted;

	public int _kidokuMilliSecondRange = 1000;

	[SerializeField]
	private RectTransform rectTransform;

	private LayoutElement2DType layoutElement2DType;

	private Subject<Unit> onDestroySubject = new Subject<Unit>();

	private string _imageFileName = "N/A";

	[SerializeField]
	private ScrolllOverHungObject imageOverHungObject;

	private JineDrawable nakami;

	[Header("Layout Component")]
	[SerializeField]
	private LayoutElement cellElement;

	[SerializeField]
	private LayoutElement nakamiElement;

	[SerializeField]
	private LayoutElement balloonElement;

	[SerializeField]
	private LayoutElement honbunElement;

	[SerializeField]
	private LayoutElement stampElement;

	[SerializeField]
	private LayoutElement imageElement;

	[SerializeField]
	private float balloonHightOffset;

	public LayoutElement2DType LayoutElement2DType => layoutElement2DType;

	public RectTransform RectTransform => rectTransform;

	public SpriteRenderer BalloonRend => _balloonRend;

	public SpriteRenderer TailRend => _tailRend;

	public IObservable<Unit> OnDestroyObservable => onDestroySubject;

	private void Start()
	{
		if (imageOverHungObject != null)
		{
			imageOverHungObject.SetParentRect(base.transform.parent.parent.GetComponent<RectTransform>());
		}
		rectTransform.offsetMin = new Vector2(0f, rectTransform.offsetMin.y);
		rectTransform.offsetMax = new Vector2(0f, rectTransform.offsetMax.y);
		cellalpha.SetAlpha(0f);
	}

	private void OnDestroy()
	{
		onDestroySubject.OnNext(Unit.Default);
		onDestroySubject.OnCompleted();
		if (_imageFileName != "N/A")
		{
			LoadPictures.DeleteCache(_imageFileName, LoadPictures.PictureType.JINE);
		}
	}

	public void setDay(int Day)
	{
		changeDay(Day);
		cellalpha.DOFade(0.2f, 1f, this.GetCancellationTokenOnDestroy()).Forget();
		setDayLang(Day);
		SetLayoutSeparator();
	}

	private void changeDay(int Day)
	{
		honbun.text = NgoEx.DayText(Day, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	private void setDayLang(int Day)
	{
		if (!langChangeSetted)
		{
			SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
			{
				changeDay(Day);
				SetLayoutSeparator();
			}).AddTo(base.gameObject);
			langChangeSetted = true;
		}
	}

	public void setDayPart(int DayPart)
	{
		changeDayPart(DayPart);
		cellalpha.DOFade(0.2f, 1f, this.GetCancellationTokenOnDestroy()).Forget();
		setDaypartLang(DayPart);
		SetLayoutSeparator();
	}

	private void changeDayPart(int DayPart)
	{
		switch (DayPart)
		{
		case -1:
			honbun.text = "---";
			break;
		case 0:
			honbun.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart0, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		case 1:
			honbun.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		case 2:
			honbun.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart2, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		default:
			honbun.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart3, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		}
	}

	private void setDaypartLang(int DayPart)
	{
		if (!langChangeSetted)
		{
			SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
			{
				changeDayPart(DayPart);
				SetLayoutSeparator();
			}).AddTo(base.gameObject);
			langChangeSetted = true;
		}
	}

	public async UniTask setData(JineDrawable nakami, int kidokMilliSecond = 100)
	{
		this.nakami = nakami;
		cellalpha.SetAlpha(0f);
		SetStamp(nakami);
		if (nakami.ImageId.IsNotEmpty())
		{
			_image.gameObject.SetActive(value: true);
			ResourceLocal resource = _resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == nakami.ImageId);
			if (resource == null)
			{
				Debug.Log("ImageIDが見つからず" + nakami.ImageId);
				_image.gameObject.SetActive(value: false);
			}
			else
			{
				Debug.Log("ImageID=" + nakami.ImageId);
				SingletonMonoBehaviour<Settings>.Instance.addImage(nakami.ImageId);
				SpriteRenderer image = _image;
				image.sprite = await LoadPictures.LoadPictureAsync(resource.FileName, LoadPictures.PictureType.JINE);
				_imageFileName = resource.FileName;
				Vector2 size = _image.GetComponent<RectTransform>().rect.size;
				_image.size = size;
				_image.GetComponent<BoxCollider2D>().size = size;
				Button component = _image.gameObject.GetComponent<Button>();
				component.OnClickAsObservable().Subscribe(delegate
				{
					ImageViewerHelper.OpenImageViewer(resource.FileName);
				}).AddTo(component.gameObject);
				if (imageOverHungObject != null)
				{
					imageOverHungObject.SetParentRect(base.transform.parent.parent.GetComponent<RectTransform>());
				}
			}
		}
		SetBody(nakami);
		SetLocalize(nakami);
		if (nakami.JineUserType == JineUserType.pi && kidokMilliSecond == 1)
		{
			OnKidoku();
		}
		SetLayout(nakami);
		await cellalpha.DOFade(0.4f, 1f);
		if (nakami.JineUserType == JineUserType.pi && kidokMilliSecond > 1)
		{
			Observable.Timer(TimeSpan.FromSeconds(nakami.kidokumillisecond / 1000)).Subscribe(delegate
			{
				OnKidoku();
			}).AddTo(this);
		}
	}

	private void SetLocalize(JineDrawable nakami)
	{
		if (!langChangeSetted)
		{
			SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(async delegate
			{
				await UniTask.DelayFrame(1);
				OnLanguageUpdated(nakami);
				SetLayout(nakami);
			}).AddTo(base.gameObject);
			langChangeSetted = true;
		}
	}

	private void SetStamp(JineDrawable nakami)
	{
		if (nakami.StampType != StampType.None)
		{
			stampWaku.gameObject.SetActive(value: true);
			balloon.gameObject.SetActive(value: false);
			_image.gameObject.SetActive(value: false);
			stampWaku.sprite = LoadStampData.ReadStampContent(nakami.StampType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
	}

	private void SetBody(JineDrawable nakami)
	{
		if (!(nakami.BodyJp == ""))
		{
			honbun.text = NgoEx.GetJineHonbun(nakami, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			if (nakami.JineUserType == JineUserType.ame || nakami.JineUserType == JineUserType.pi)
			{
				GetComponentInChildren<JineWrapper>().Wrap();
			}
		}
	}

	public void OnKidoku(int milliSecond = 1000)
	{
		_kidoku.text = NgoEx.SystemTextFromType(SystemTextType.JINE_Kidoku, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_kidoku.color = Color.white;
	}

	public void OnLanguageUpdated(JineDrawable nakami)
	{
		SetStamp(nakami);
		SetBody(nakami);
		if (_kidoku != null && _kidoku.text != "")
		{
			_kidoku.text = NgoEx.SystemTextFromType(SystemTextType.JINE_Kidoku, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
	}

	public void SetUpMask(RectTransform targetMaskRect)
	{
	}

	private void SetLayout(JineDrawable nakami)
	{
		switch (nakami.JineUserType)
		{
		case JineUserType.ame:
			SetLayoutAme();
			break;
		case JineUserType.pi:
			SetLayoutPi();
			break;
		case JineUserType.separator:
			SetLayoutSeparator();
			break;
		case JineUserType.timeSeparator:
			SetLayoutSeparator();
			break;
		case JineUserType.eventSeparator:
			SetLayoutSeparator();
			break;
		}
	}

	[ContextMenu("\ufffd\ufffd\ufffdC\ufffdA\ufffdE\ufffdg\ufffdm\ufffdF(Ame)")]
	private void SetLayoutAme()
	{
		float num = 10f;
		if (honbunElement.gameObject.activeInHierarchy)
		{
			float num2 = 450f;
			RectTransform component = honbunElement.GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(num2, 0f);
			honbunElement.minWidth = Mathf.Min(honbun.preferredWidth, num2);
			component.sizeDelta = new Vector2(honbunElement.minWidth, 0f);
			honbunElement.minHeight = honbun.preferredHeight;
			component.sizeDelta = new Vector2(honbunElement.minWidth, honbunElement.minHeight);
		}
		if (balloonElement.gameObject.activeInHierarchy)
		{
			RectTransform component2 = balloonElement.GetComponent<RectTransform>();
			balloonElement.minWidth = honbunElement.minWidth;
			balloonElement.minHeight = honbunElement.minHeight;
			component2.sizeDelta = new Vector2(balloonElement.minWidth, balloonElement.minHeight);
			component2.anchoredPosition = new Vector2(component2.sizeDelta.x / 2f, (0f - component2.sizeDelta.y) / 2f);
		}
		if (imageElement.gameObject.activeInHierarchy)
		{
			RectTransform component3 = imageElement.GetComponent<RectTransform>();
			if (balloonElement.gameObject.activeInHierarchy)
			{
				component3.anchoredPosition = new Vector2(component3.sizeDelta.x / 2f, 0f - (balloonElement.minHeight + num + component3.sizeDelta.y / 2f));
			}
			else
			{
				component3.anchoredPosition = new Vector2(component3.sizeDelta.x / 2f, (0f - component3.sizeDelta.y) / 2f);
			}
		}
		RectTransform component4 = nakamiElement.GetComponent<RectTransform>();
		float num3 = 0f;
		float num4 = 0f;
		if (balloonElement.gameObject.activeInHierarchy)
		{
			num3 = Mathf.Max(num3, balloonElement.minWidth);
			num4 += balloonElement.minHeight;
		}
		if (imageElement.gameObject.activeInHierarchy)
		{
			num3 = Mathf.Max(num3, imageElement.minWidth);
			num4 += imageElement.minHeight;
			if (balloonElement.gameObject.activeInHierarchy)
			{
				num4 += num;
			}
		}
		if (stampElement.gameObject.activeInHierarchy)
		{
			num3 = Mathf.Max(num3, stampElement.minWidth);
			num4 += stampElement.minHeight;
		}
		nakamiElement.minWidth = num3;
		nakamiElement.minHeight = num4;
		component4.sizeDelta = new Vector2(nakamiElement.minWidth, nakamiElement.minHeight);
		RectTransform component5 = GetComponent<RectTransform>();
		cellElement.minHeight = Mathf.Max(nakamiElement.minHeight, 50f);
		Vector2 sizeDelta = component5.sizeDelta;
		sizeDelta.y = cellElement.minHeight;
		component5.sizeDelta = sizeDelta;
		Debug.Log(honbunElement.minWidth);
		Debug.Log(balloonElement.minWidth);
		Debug.Log(nakamiElement.minWidth);
	}

	[ContextMenu("\ufffd\ufffd\ufffdC\ufffdA\ufffdE\ufffdg\ufffdm\ufffdF(Pi)")]
	private void SetLayoutPi()
	{
		if (honbunElement.gameObject.activeInHierarchy)
		{
			RectTransform component = honbunElement.GetComponent<RectTransform>();
			honbunElement.minWidth = honbun.preferredWidth;
			honbunElement.minHeight = honbun.preferredHeight;
			component.sizeDelta = new Vector2(honbunElement.minWidth, honbunElement.minHeight + balloonHightOffset);
		}
		if (balloonElement.gameObject.activeInHierarchy)
		{
			RectTransform component2 = balloonElement.GetComponent<RectTransform>();
			balloonElement.minWidth = honbunElement.minWidth;
			balloonElement.minHeight = honbunElement.minHeight;
			component2.sizeDelta = new Vector2(balloonElement.minWidth, balloonElement.minHeight + balloonHightOffset);
			component2.anchoredPosition = new Vector2((0f - component2.sizeDelta.x) / 2f, (0f - component2.sizeDelta.y) / 2f);
		}
		RectTransform component3 = GetComponent<RectTransform>();
		if (balloonElement.gameObject.activeInHierarchy)
		{
			cellElement.minHeight = balloonElement.minHeight;
		}
		else
		{
			cellElement.minHeight = stampElement.minHeight;
		}
		Vector2 sizeDelta = component3.sizeDelta;
		sizeDelta.y = cellElement.minHeight;
		component3.sizeDelta = sizeDelta;
		RectTransform component4 = _kidoku.GetComponent<RectTransform>();
		if (balloonElement.gameObject.activeInHierarchy)
		{
			component4.anchoredPosition = new Vector2(0f - (balloonElement.minWidth - 40f), component4.anchoredPosition.y);
		}
		else
		{
			component4.anchoredPosition = new Vector2(0f - (stampElement.minWidth - 40f), component4.anchoredPosition.y);
		}
	}

	[ContextMenu("\ufffd\ufffd\ufffdC\ufffdA\ufffdE\ufffdg\ufffdm\ufffdF(Separator)")]
	private void SetLayoutSeparator()
	{
		float min = 160f;
		float num = 450f;
		RectTransform component = honbunElement.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(num, 0f);
		honbunElement.minWidth = Mathf.Clamp(honbun.preferredWidth, min, num);
		component.sizeDelta = new Vector2(honbunElement.minWidth, 0f);
		honbunElement.minHeight = honbun.preferredHeight;
		component.sizeDelta = new Vector2(honbunElement.minWidth, honbunElement.minHeight);
		RectTransform component2 = balloonElement.GetComponent<RectTransform>();
		balloonElement.minWidth = honbunElement.minWidth;
		balloonElement.minHeight = honbunElement.minHeight;
		component2.sizeDelta = new Vector2(balloonElement.minWidth, balloonElement.minHeight);
	}
}
