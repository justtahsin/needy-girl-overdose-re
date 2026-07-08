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

public class KusoRepView2D : MonoBehaviour
{
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

	[SerializeField]
	private ScrolllOverHungObject imageOverHungObject;

	private bool _userNameExist;

	private bool _bodyTextExist;

	private bool _userImageExist;

	private float _kusorepHeight = 104f;

	private KusoRepDrawable nakami;

	private readonly Vector2 IMAGE_SIZE = new Vector2(550f, 550f);

	public void Awake()
	{
		_fader.SetAlpha(0f);
		_kusorepElement.minHeight = 0f;
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
		SetBody(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		SetUserIcon();
		SetLayout(_userNameExist, _bodyTextExist, _userImageExist);
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
			await DOTween.To(() => _kusorepElement.minHeight, delegate(float x)
			{
				_kusorepElement.minHeight = x;
			}, _kusorepHeight, duration).Play();
			await _fader.DOFade(fade, 1f);
		}
		catch (OperationCanceledException)
		{
			_kusorepElement.minHeight = _kusorepHeight;
			_fader.SetAlpha(1f);
		}
	}

	public void ShowPosted()
	{
		base.transform.SetAsFirstSibling();
		_kusorepElement.minHeight = _kusorepHeight;
		_fader.SetAlpha(1f);
	}

	protected virtual bool SetUserName()
	{
		if (nakami.UserId != "N/A" && nakami.UserId != "" && nakami.UserId != null)
		{
			_userName.text = NgoEx.SystemTextFromType(SystemTextType.From, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) + " " + nakami.UserId;
			_userNameExist = true;
			_userName.gameObject.SetActive(value: true);
		}
		else
		{
			_userName.gameObject.SetActive(value: false);
		}
		return !string.IsNullOrEmpty(_userName.text);
	}

	protected virtual bool SetBody(LanguageType lang)
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
			SingletonMonoBehaviour<Settings>.Instance.addImage(nakami.ImageId);
			Sprite sprite = await LoadPictures.LoadPictureAsync(resource.FileName, LoadPictures.PictureType.Poketter);
			_userImage.sprite = sprite;
			_imageFileName = resource.FileName;
			Vector2 vector = new Vector2(sprite.texture.width, sprite.texture.height);
			Vector2 size = vector;
			if (vector.x >= vector.y)
			{
				size.x = IMAGE_SIZE.x;
				size.y = vector.y * (IMAGE_SIZE.x / vector.x);
			}
			else
			{
				size.y = IMAGE_SIZE.y;
				size.x = vector.x * (IMAGE_SIZE.y / vector.y);
			}
			_userImage.size = size;
			_userImageElement.minWidth = size.x;
			_userImageElement.minHeight = size.y;
			_userImage.GetComponent<BoxCollider2D>().size = size;
			_userImage.gameObject.SetActive(value: true);
			_userImageExist = true;
			Button component = _userImage.gameObject.GetComponent<Button>();
			component.OnClickAsObservable().Subscribe(delegate
			{
				ImageViewerHelper.OpenImageViewer(resource.FileName);
			}).AddTo(component.gameObject);
			if (imageOverHungObject != null)
			{
				imageOverHungObject.SetParentRect(base.transform.parent.parent.parent.parent.GetComponent<RectTransform>());
			}
			return _userImage.sprite != null;
		}
		return false;
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

	protected virtual void SetLayout(bool userNameExist, bool bodyTextExist, bool userImageExist)
	{
		_userImageElement.minHeight = _userImage.size.y;
		_bodyTextElement.minHeight = 0f;
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
	}

	private void OnDestroy()
	{
		if (_imageFileName != "N/A")
		{
			LoadPictures.DeleteCache(_imageFileName, LoadPictures.PictureType.Poketter);
		}
	}

	public void OnLanguageUpdated(LanguageType type)
	{
		SetUserName();
		SetBody(type);
		SetLayout(_userNameExist, _bodyTextExist, _userImageExist);
	}
}
