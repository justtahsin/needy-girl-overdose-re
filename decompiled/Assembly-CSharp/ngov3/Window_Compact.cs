using System;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

[Serializable]
public class Window_Compact : MonoBehaviour, IWindow, IScalable, IOpenable, IClosable, ISwitchableCloseState, IStateSwitchable, IUnityComponent, IStackable, ISwitchableMoveState
{
	[SerializeField]
	private Button close;

	[SerializeField]
	private bool _closable = true;

	[SerializeField]
	private Sprite _active;

	[SerializeField]
	private Sprite _inActive;

	[SerializeField]
	private TMP_Text title;

	private Image _wakuImage;

	private AppTypeToData data;

	private Transform _transform;

	private float firstWidth = 400f;

	private float firstHeight = 400f;

	[SerializeField]
	private Canvas _canvas;

	[SerializeField]
	private Transform _nakamiParent;

	[SerializeField]
	private CanvasGroup contents;

	private Sequence _runningSequence;

	protected float _firstPosx;

	protected float _firstPosy;

	protected RectTransform rect;

	[SerializeField]
	private Button _cover;

	public WindowState windowState { get; set; }

	public ActiveState activeState { get; set; }

	public string Wname { get; set; } = "default Window";

	public Button _close => close;

	public AppType appType { get; set; } = AppType.Test;

	public GameObject nakamiApp { get; set; }

	public Transform GameObjectTransform => _transform;

	public GameObject UnityGameObject => base.gameObject;

	public int OrderInLayer => _canvas.sortingOrder;

	public Button _minimize => null;

	public Button _maximize => null;

	public void Awake()
	{
		rect = GetComponent<RectTransform>();
		_wakuImage = GetComponent<Image>();
		_transform = base.transform;
		if (_firstPosx == 0f && _firstPosy == 0f)
		{
			setRandomPosition();
		}
		if (appType != AppType.MediaPlayer)
		{
			_close.onClick.AddListener(OnCloseClicked);
			_cover.onClick.AddListener(Touched);
		}
	}

	private void OnCloseClicked()
	{
		_close.interactable = false;
		SingletonMonoBehaviour<WindowManager>.Instance.Close(this);
	}

	public void setRandomPosition()
	{
		RectTransform rectTransform = rect.parent.transform as RectTransform;
		_firstPosx = UnityEngine.Random.Range(0f, rectTransform.rect.width - rect.sizeDelta.x);
		_firstPosy = UnityEngine.Random.Range(0f + rect.sizeDelta.y, rectTransform.rect.height);
		rect.localPosition = new Vector2(_firstPosx, _firstPosy);
	}

	public void SetName(string name)
	{
		Wname = name;
		title.text = Wname;
	}

	public void SetApp(AppTypeToData a)
	{
		appType = a.appType;
		data = a;
		SetContent(a);
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
		{
			OnLanguageUpdated();
		}).AddTo(base.gameObject);
	}

	public void SetCachedApp(AppTypeToData a)
	{
		appType = a.appType;
		data = a;
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate
		{
			OnLanguageUpdated();
		}).AddTo(base.gameObject);
	}

	private void SetContent(AppTypeToData a)
	{
		OnLanguageUpdated();
		rect.localPosition = new Vector3(a.FirstPosX, a.FirstPosY, 0f);
		firstWidth = a.FirstWidth;
		firstHeight = a.FirstHeight;
		rect.sizeDelta = new Vector2(a.FirstWidth, a.FirstHeight);
		if (a.InnerContent != null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(a.InnerContent, _nakamiParent);
			nakamiApp = gameObject;
		}
	}

	public void ResetSize()
	{
		rect.sizeDelta = new Vector2(firstWidth, firstHeight);
	}

	public void Close()
	{
		windowState = WindowState.closed;
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, new Vector2(0f, 0f), CursorMode.Auto);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void Minimize()
	{
		windowState = WindowState.minimized;
		EndSequence();
		_runningSequence = GetComponent<RectTransform>().minimize();
	}

	public void Pop()
	{
		windowState = WindowState.opened;
		EndSequence();
		_runningSequence = GetComponent<RectTransform>().pop();
	}

	public void Maximize()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.Touched(this);
		if (windowState == WindowState.maximized)
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_pirodown);
			GetComponent<RectTransform>().sizeDelta = new Vector2(firstWidth, firstHeight);
			windowState = WindowState.opened;
		}
		else
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
			windowState = WindowState.maximized;
			EndSequence();
			_runningSequence = GetComponent<RectTransform>().maximize();
		}
	}

	public void Born()
	{
		EndSequence();
		_runningSequence = GetComponent<RectTransform>().born();
	}

	private void EndSequence()
	{
		if (_runningSequence != null)
		{
			_runningSequence.Complete();
		}
	}

	public void Open()
	{
		windowState = WindowState.opened;
	}

	public void Touched()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.Touched(this);
	}

	public void setActive()
	{
		activeState = ActiveState.Active;
		_wakuImage.sprite = _active;
		_cover.gameObject.SetActive(value: false);
		contents.interactable = true;
		SingletonMonoBehaviour<WindowManager>.Instance.SetForeground(this);
	}

	public void setInActive()
	{
		activeState = ActiveState.InActive;
		_wakuImage.sprite = _inActive;
		_cover.gameObject.SetActive(value: true);
		contents.interactable = false;
	}

	public void Uncloseable()
	{
		_close.interactable = false;
	}

	public void Closeable()
	{
		_close.interactable = true;
	}

	public void UnMovable()
	{
	}

	public void Movable()
	{
	}

	public void OnLanguageUpdated()
	{
		string text = NgoEx.SystemTextFromType(LoadAppData.ReadAppContent(appType).AppName, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		SetName(text);
	}

	public void SetOrderInLayer(int order)
	{
		_canvas.sortingOrder = order;
		Vector3 position = GameObjectTransform.position;
		position.z = 100 - order;
		GameObjectTransform.position = position;
	}

	public void SetStratchAble(bool active)
	{
		throw new NotImplementedException();
	}
}
