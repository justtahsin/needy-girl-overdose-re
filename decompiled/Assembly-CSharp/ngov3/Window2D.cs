using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace ngov3;

public class Window2D : ScalableObject2D, IWindow, IScalable, IOpenable, IClosable, ISwitchableCloseState, IStateSwitchable, IUnityComponent, IStackable, ISwitchableMoveState
{
	private float firstWidth = 400f;

	private float firstHeight = 400f;

	protected float _firstPosx;

	protected float _firstPosy;

	[SerializeField]
	private TMP_Text title;

	[SerializeField]
	private Button2D close;

	[SerializeField]
	private Button2D minimize;

	[SerializeField]
	private Button2D maximize;

	[SerializeField]
	private bool _closable = true;

	[SerializeField]
	private Transform nakami_parent;

	[SerializeField]
	private Sprite _active;

	[SerializeField]
	private Sprite _inActive;

	[SerializeField]
	private SpriteRenderer _wakuRend;

	[SerializeField]
	private GameObject _nakamiApp;

	private IApp2D app2D;

	private AppTypeToData data;

	private Transform _transform;

	[SerializeField]
	private SortingGroup _sortingGroup;

	[SerializeField]
	private WindowCover2D windowCover2D;

	private float scrollSpeed = 3f;

	private Sequence _runningSequence;

	[SerializeField]
	private GameObject edges;

	public Button _close => close;

	public Button _minimize => minimize;

	public Button _maximize => maximize;

	public AppType appType { get; set; } = AppType.Test;

	public WindowState windowState { get; set; }

	public GameObject nakamiApp => _nakamiApp;

	public ActiveState activeState { get; set; }

	public string Wname { get; set; } = "default Window";

	public Transform GameObjectTransform => _transform;

	public GameObject UnityGameObject => base.gameObject;

	public int OrderInLayer => _sortingGroup.sortingOrder;

	protected override void Awake()
	{
		base.Awake();
		_transform = base.transform;
		_close.onClick.AddListener(delegate
		{
			SingletonMonoBehaviour<WindowManager>.Instance.Close(this);
		});
		_minimize.onClick.AddListener(delegate
		{
			SingletonMonoBehaviour<WindowManager>.Instance.Minimize(this);
		});
		_maximize.onClick.AddListener(delegate
		{
			Maximize();
		});
		Vector3 prevCursorPos = default(Vector3);
		windowCover2D.DraggableHandle.OnEndDragAsObservable2D.Subscribe(delegate
		{
			prevCursorPos = default(Vector3);
		}).AddTo(base.gameObject);
		(from _ in windowCover2D.DraggableHandle.OnBeginDragAsObservable2D.SelectMany(windowCover2D.DraggableHandle.OnDragAsObservable2D).TakeUntil(windowCover2D.DraggableHandle.OnEndDragAsObservable2D).TakeWhile((PointerEventData e) => windowCover2D)
			select SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition).RepeatUntilDestroy(this).Subscribe(delegate(Vector3 pointer)
		{
			if (app2D == null)
			{
				app2D = nakamiApp.GetComponent<IApp2D>();
			}
			if (prevCursorPos != default(Vector3) && app2D != null)
			{
				Vector3 vector = pointer - prevCursorPos;
				_ = vector * scrollSpeed;
				Vector2 anchoredPosition = app2D.ScrollRect.content.anchoredPosition;
				app2D.ScrollRect.content.anchoredPosition = new Vector2(anchoredPosition.x, anchoredPosition.y + vector.y);
			}
			prevCursorPos = pointer;
		}).AddTo(base.gameObject);
	}

	public void Born()
	{
		_runningSequence = GetComponent<RectTransform>().born();
	}

	public void ResetSize()
	{
		rect.sizeDelta = new Vector2(firstWidth, firstHeight);
	}

	public void Close()
	{
		windowState = WindowState.closed;
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, new Vector2(0f, 0f), CursorMode.Auto);
		Window2DStorage storage2D = SingletonMonoBehaviour<WindowManager>.Instance.Storage2D;
		if (storage2D.IsTargetWindow(this))
		{
			storage2D.StoreWindowInStorage(this);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void Closeable()
	{
		_close.interactable = true;
		_maximize.interactable = true;
		_minimize.interactable = true;
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
			_runningSequence = GetComponent<RectTransform>().maximizeWindow2D();
		}
	}

	public void Minimize()
	{
		windowState = WindowState.minimized;
		EndSequence();
		_runningSequence = GetComponent<RectTransform>().minimize();
	}

	public void Open()
	{
		windowState = WindowState.opened;
	}

	public void Pop()
	{
		windowState = WindowState.opened;
		EndSequence();
		_runningSequence = GetComponent<RectTransform>().pop();
	}

	private void EndSequence()
	{
		if (_runningSequence != null)
		{
			_runningSequence.Complete();
		}
	}

	public void setActive()
	{
		activeState = ActiveState.Active;
		if (app2D != null)
		{
			app2D.RewiredScrollReceiver.SetActive(active: true);
		}
		_wakuRend.sprite = _active;
		SingletonMonoBehaviour<WindowManager>.Instance.SetForeground(this);
		windowCover2D.gameObject.SetActive(value: true);
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
		GetComponent<RectSizeSyncSpriteRendererSizeExtensions>().SetRectSizeSyncPivot(RectSizeSyncPivot.CENTER);
		firstWidth = a.FirstWidth;
		firstHeight = a.FirstHeight;
		rect.sizeDelta = new Vector2(a.FirstWidth, a.FirstHeight);
		rect.localPosition = new Vector3(a.FirstPosX, a.FirstPosY, 0f);
		if (!(a.InnerContent != null))
		{
			return;
		}
		if (_nakamiApp == null)
		{
			GameObject gameObject = Object.Instantiate(a.InnerContent, nakami_parent);
			_nakamiApp = gameObject;
		}
		app2D = _nakamiApp.GetComponent<IApp2D>();
		if (app2D != null)
		{
			app2D.SetSortOrder(_sortingGroup.sortingOrder);
			windowCover2D.Button2D.onClick.AddListener(delegate
			{
				app2D?.Click();
			});
		}
	}

	public void setInActive()
	{
		activeState = ActiveState.InActive;
		if (app2D != null)
		{
			app2D.RewiredScrollReceiver.SetActive(active: false);
		}
		_wakuRend.sprite = _inActive;
	}

	public void SetName(string name)
	{
		Wname = name;
		title.text = Wname;
	}

	public void setRandomPosition()
	{
		RectTransform rectTransform = rect.parent.transform as RectTransform;
		_firstPosx = Random.Range(0f, rectTransform.rect.width - rect.sizeDelta.x);
		_firstPosy = Random.Range(0f + rect.sizeDelta.y, rectTransform.rect.height);
		rect.localPosition = new Vector2(_firstPosx, _firstPosy);
	}

	public override void Touched()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.Touched(this);
	}

	public void Uncloseable()
	{
		_close.interactable = false;
		_maximize.interactable = false;
		_minimize.interactable = false;
	}

	public void UnMovable()
	{
		_MovableGrabber.enabled = false;
		_leftBottomPoint.enabled = false;
		_rightBottomPoint.enabled = false;
		_rightTopPoint.enabled = false;
		_leftTopPoint.enabled = false;
		_BottomEdge.enabled = false;
		_RightEdge.enabled = false;
		_LeftEdge.enabled = false;
		_TopEdge.enabled = false;
		_leftBottomPoint.GetComponent<MouseCursor>().enabled = false;
		_rightBottomPoint.GetComponent<MouseCursor>().enabled = false;
		_rightTopPoint.GetComponent<MouseCursor>().enabled = false;
		_leftTopPoint.GetComponent<MouseCursor>().enabled = false;
		_BottomEdge.GetComponent<MouseCursor>().enabled = false;
		_RightEdge.GetComponent<MouseCursor>().enabled = false;
		_LeftEdge.GetComponent<MouseCursor>().enabled = false;
		_TopEdge.GetComponent<MouseCursor>().enabled = false;
	}

	public void Movable()
	{
		_MovableGrabber.enabled = true;
		_leftBottomPoint.enabled = true;
		_rightBottomPoint.enabled = true;
		_rightTopPoint.enabled = true;
		_leftTopPoint.enabled = true;
		_BottomEdge.enabled = true;
		_RightEdge.enabled = true;
		_LeftEdge.enabled = true;
		_TopEdge.enabled = true;
		_leftBottomPoint.GetComponent<MouseCursor>().enabled = true;
		_rightBottomPoint.GetComponent<MouseCursor>().enabled = true;
		_rightTopPoint.GetComponent<MouseCursor>().enabled = true;
		_leftTopPoint.GetComponent<MouseCursor>().enabled = true;
		_BottomEdge.GetComponent<MouseCursor>().enabled = true;
		_RightEdge.GetComponent<MouseCursor>().enabled = true;
		_LeftEdge.GetComponent<MouseCursor>().enabled = true;
		_TopEdge.GetComponent<MouseCursor>().enabled = true;
	}

	public void OnLanguageUpdated()
	{
		string text = "";
		text = NgoEx.SystemTextFromType(data.AppName, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		if (text == "")
		{
			text = NgoEx.SystemTextFromType(LoadAppData.ReadAppContent(appType).AppName, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		SetName(text);
	}

	public void SetOrderInLayer(int order)
	{
		_sortingGroup.sortingOrder = order;
		Vector3 position = GameObjectTransform.position;
		position.z = 100 - order;
		GameObjectTransform.position = position;
	}

	public void SetStratchAble(bool active)
	{
		edges.SetActive(active);
	}
}
