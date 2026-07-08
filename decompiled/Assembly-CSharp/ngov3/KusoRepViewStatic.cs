using System.Linq;
using Cysharp.Threading.Tasks;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class KusoRepViewStatic : MonoBehaviour
{
	[SerializeField]
	private KusoRepType kRepType;

	[SerializeField]
	protected ResourceLocalMaster _resourceMaster;

	[SerializeField]
	protected Image _userIcon;

	[SerializeField]
	protected Image _userImage;

	[SerializeField]
	protected TMP_Text _userName;

	[SerializeField]
	protected TMP_Text _bodyText;

	private CanvasGroup canvas;

	private RectTransform Rect;

	private KusoRepDrawable nakami;

	public void Awake()
	{
		SetData(new KusoRepDrawable(kRepType));
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
		SetBody();
		SetUserIcon();
		return true;
	}

	protected virtual bool SetUserName()
	{
		if (nakami.UserId != "N/A")
		{
			_userName.text = "from " + nakami.UserId;
		}
		else
		{
			_userName.gameObject.SetActive(value: false);
		}
		return !string.IsNullOrEmpty(_userName.text);
	}

	protected virtual bool SetBody()
	{
		switch (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)
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
			Image userImage = _userImage;
			userImage.sprite = await LoadPictures.LoadPictureAsync(resource.FileName, LoadPictures.PictureType.Poketter);
			Button component = _userImage.gameObject.GetComponent<Button>();
			component.OnClickAsObservable().Subscribe(delegate
			{
				ImageViewerHelper.OpenImageViewer(resource.FileName);
			}).AddTo(component.gameObject);
			return _userImage.sprite != null;
		}
		return false;
	}

	protected virtual bool SetUserIcon()
	{
		if (nakami.UserIconId != "N/A")
		{
			_userIcon.sprite = Resources.Load<Sprite>("icons/" + nakami.UserIconId);
			return _userIcon.sprite != null;
		}
		return false;
	}

	public void OnLanguageUpdated(LanguageType type)
	{
		SetBody();
	}
}
