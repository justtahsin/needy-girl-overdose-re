using System.Linq;
using Cysharp.Threading.Tasks;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class KusoRepViewStatic2D : MonoBehaviour
{
	[SerializeField]
	private KusoRepType kRepType;

	[SerializeField]
	protected ResourceLocalMaster _resourceMaster;

	[SerializeField]
	protected SpriteRenderer _userIcon;

	[SerializeField]
	protected SpriteRenderer _userImage;

	[SerializeField]
	protected TMP_Text _userName;

	[SerializeField]
	protected TMP_Text _bodyText;

	[SerializeField]
	protected Fader2D _fader;

	private KusoRepDrawable nakami;

	private string _imageFileName = "N/A";

	[Header("Layout Components")]
	[SerializeField]
	protected LayoutElement _kusorepElement;

	[SerializeField]
	private RectTransform Rect;

	[SerializeField]
	protected LayoutElement _bodyElement;

	[SerializeField]
	protected VerticalLayoutGroup _bodyLayoutGroup;

	[SerializeField]
	protected RectTransform _bodyRectTr;

	[SerializeField]
	protected LayoutElement _userNameElement;

	[SerializeField]
	protected LayoutElement _bodyTextElement;

	[SerializeField]
	protected LayoutElement _userImageElement;

	[SerializeField]
	protected LayoutElement _dateElement;

	private bool _userNameExist;

	private bool _bodyTextExist;

	private bool _userImageExist;

	private float _kusorepHeight = 104f;

	private readonly Vector2 IMAGE_SIZE = new Vector2(550f, 550f);

	public void Awake()
	{
		SetData(new KusoRepDrawable(kRepType));
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate(LanguageType t)
		{
			OnLanguageUpdated(t);
		}).AddTo(base.gameObject);
	}

	public async UniTask<bool> SetData(KusoRepDrawable content)
	{
		nakami = content;
		SetUserName();
		await SetUserImage();
		SetBody();
		SetUserIcon();
		SetLayout(_userNameExist, _bodyTextExist, _userImageExist);
		return true;
	}

	protected virtual bool SetUserName()
	{
		if (nakami.UserId != "N/A")
		{
			_userName.text = "from " + nakami.UserId;
			_userNameExist = true;
		}
		else
		{
			_userName.gameObject.SetActive(value: false);
		}
		return !string.IsNullOrEmpty(_userName.text);
	}

	protected virtual bool SetBody()
	{
		(string, bool) kusoRepBody = NgoEx_Temp.GetKusoRepBody(nakami);
		_bodyText.text = kusoRepBody.Item1;
		if (nakami.BodyJp == "N/A")
		{
			_bodyText.gameObject.SetActive(value: false);
		}
		else
		{
			_bodyTextExist = true;
		}
		return kusoRepBody.Item2;
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
			SpriteRenderer userImage = _userImage;
			userImage.sprite = await LoadPictures.LoadPictureAsync(resource.FileName, LoadPictures.PictureType.Poketter);
			_userImageExist = true;
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

	protected virtual void SetLayout(bool userNameExist, bool bodyTextExist, bool userImageExist)
	{
		_userImageElement.minHeight = _userImage.size.y;
		_bodyTextElement.minHeight = _bodyText.preferredHeight;
		float num = 0f;
		float num2 = 6f;
		if (userNameExist)
		{
			num += _userNameElement.minHeight + num2;
		}
		if (bodyTextExist)
		{
			num += _bodyTextElement.minHeight + num2;
		}
		if (userImageExist)
		{
			num += _userImageElement.minHeight + num2;
		}
		num = Mathf.Max(num, _userIcon.size.y);
		_bodyElement.minHeight = num;
		_bodyRectTr.sizeDelta = new Vector2(_bodyRectTr.sizeDelta.x, _bodyElement.minHeight);
		_kusorepHeight = num;
		_kusorepElement.minHeight = num;
	}

	public void OnLanguageUpdated(LanguageType type)
	{
		SetBody();
	}

	private void OnDestroy()
	{
		if (_imageFileName != "N/A")
		{
			LoadPictures.DeleteCache(_imageFileName, LoadPictures.PictureType.Poketter);
		}
	}
}
