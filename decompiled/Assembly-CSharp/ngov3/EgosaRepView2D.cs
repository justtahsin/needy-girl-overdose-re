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

public class EgosaRepView2D : MonoBehaviour, ILayoutElement2D
{
	[SerializeField]
	protected ResourceLocalMaster _resourceMaster;

	[SerializeField]
	protected SpriteRenderer _userIcon;

	[SerializeField]
	protected SpriteRenderer _userImage;

	[SerializeField]
	protected TextMeshPro _userName;

	[SerializeField]
	protected TextMeshPro _bodyText;

	[SerializeField]
	private Fader2D fader;

	private RectTransform Rect;

	private KusoRepDrawable nakami;

	private Subject<Unit> onDestroySubject = new Subject<Unit>();

	[SerializeField]
	private RectTransform hightSyncObject;

	[SerializeField]
	private float minHight = 51f;

	public LayoutElement2DType LayoutElement2DType => LayoutElement2DType.OBJECT;

	public RectTransform RectTransform => Rect;

	public IObservable<Unit> OnDestroyObservable => onDestroySubject;

	public void Awake()
	{
		fader.SetAlpha(0f);
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
		SetBody(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		SetUserIcon();
		return true;
	}

	public async UniTask Show()
	{
		base.transform.SetAsFirstSibling();
		float duration = 0.6f;
		try
		{
			await Rect.DOScaleY(1f, duration).Play();
			await fader.DOFade(1f, 1f, this.GetCancellationTokenOnDestroy());
		}
		catch (OperationCanceledException)
		{
			Rect.localScale = new Vector3(1f, 1f, 1f);
			fader.SetAlpha(1f);
		}
	}

	public void ShowPosted()
	{
		base.transform.SetAsFirstSibling();
		Rect.localScale = new Vector3(1f, 1f, 1f);
		fader.SetAlpha(1f);
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
		_bodyText.text = NgoEx.GetKusoRepBody(nakami, lang);
		float y = Mathf.Max(minHight, _bodyText.preferredHeight);
		Rect.sizeDelta = new Vector2(Rect.sizeDelta.x, y);
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
			SpriteRenderer userImage = _userImage;
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
