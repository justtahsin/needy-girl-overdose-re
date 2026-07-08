using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class JineCell : MonoBehaviour
{
	[SerializeField]
	private ResourceLocalMaster _resourceMaster;

	[SerializeField]
	private TMP_Text honbun;

	[SerializeField]
	private TMP_Text day;

	[SerializeField]
	private TMP_Text _kidoku;

	[SerializeField]
	private Image stampWaku;

	[SerializeField]
	private Image _image;

	[SerializeField]
	private GameObject balloon;

	[SerializeField]
	private CanvasGroup ameIcon;

	[SerializeField]
	private CanvasGroup cellalpha;

	private bool langChangeSetted;

	public int _kidokuMilliSecondRange = 1000;

	public void setDay(int Day)
	{
		changeDay(Day);
		cellalpha.DOFade(1f, 0.2f).Play();
		setDayLang(Day);
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
			}).AddTo(base.gameObject);
			langChangeSetted = true;
		}
	}

	public void setDayPart(int DayPart)
	{
		changeDayPart(DayPart);
		cellalpha.DOFade(1f, 0.2f).Play();
		setDaypartLang(DayPart);
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
			}).AddTo(base.gameObject);
			langChangeSetted = true;
		}
	}

	public async UniTask setData(JineDrawable nakami, int kidokMilliSecond = 100)
	{
		cellalpha.alpha = 0f;
		SetStamp(nakami);
		if (nakami.ImageId.IsNotEmpty())
		{
			_image.gameObject.SetActive(value: true);
			ResourceLocal resource = _resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == nakami.ImageId);
			SingletonMonoBehaviour<Settings>.Instance.addImage(nakami.ImageId);
			if (resource == null)
			{
				Debug.LogError("存在しない画像を探してるよ" + nakami.ImageId);
			}
			else
			{
				Image image = _image;
				image.sprite = await LoadPictures.LoadPictureAsync(resource.FileName, LoadPictures.PictureType.JINE);
				Button component = _image.gameObject.GetComponent<Button>();
				component.OnClickAsObservable().Subscribe(delegate
				{
					ImageViewerHelper.OpenImageViewer(resource.FileName);
				}).AddTo(component.gameObject);
			}
		}
		SetBody(nakami);
		SetLocalize(nakami);
		if (nakami.JineUserType == JineUserType.pi && kidokMilliSecond == 1)
		{
			OnKidoku();
		}
		await cellalpha.DOFade(1f, 0.4f).Play();
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
			SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
			{
				OnLanguageUpdated(nakami);
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
			switch (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)
			{
			case LanguageType.JP:
				honbun.text = nakami.BodyJp;
				break;
			case LanguageType.CN:
				honbun.text = nakami.BodyCn;
				break;
			case LanguageType.KO:
				honbun.text = nakami.BodyKo;
				break;
			case LanguageType.TW:
				honbun.text = nakami.BodyTw;
				break;
			case LanguageType.VN:
				honbun.text = nakami.BodyVn;
				break;
			case LanguageType.FR:
				honbun.text = nakami.BodyFr;
				break;
			case LanguageType.IT:
				honbun.text = nakami.BodyIt;
				break;
			case LanguageType.GE:
				honbun.text = nakami.BodyGe;
				break;
			case LanguageType.SP:
				honbun.text = nakami.BodySp;
				break;
			case LanguageType.RU:
				honbun.text = nakami.BodyRu;
				break;
			default:
				honbun.text = nakami.BodyEn;
				break;
			}
			if (nakami.JineUserType == JineUserType.ame || nakami.JineUserType == JineUserType.pi)
			{
				GetComponentInChildren<JineWrapper>().Wrap();
			}
		}
	}

	public void OnKidoku(int milliSecond = 1000)
	{
		_kidoku.text = NgoEx.SystemTextFromType(SystemTextType.JINE_Kidoku, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_kidoku.gameObject.GetComponent<CanvasGroup>().alpha = 1f;
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
}
