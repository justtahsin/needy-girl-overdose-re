using System;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
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

	public Button _close => (Button)(object)close;

	public Button _minimize => (Button)(object)minimize;

	public Button _maximize => (Button)(object)maximize;

	public AppType appType { get; set; } = AppType.Test;

	public WindowState windowState { get; set; }

	public GameObject nakamiApp => _nakamiApp;

	public ActiveState activeState { get; set; }

	public string Wname { get; set; } = "default Window";

	public Transform GameObjectTransform => _transform;

	public GameObject UnityGameObject => ((Component)this).gameObject;

	public int OrderInLayer => _sortingGroup.sortingOrder;

	protected override void Awake()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		base.Awake();
		_transform = ((Component)this).transform;
		((UnityEvent)_close.onClick).AddListener((UnityAction)delegate
		{
			SingletonMonoBehaviour<WindowManager>.Instance.Close(this);
		});
		((UnityEvent)_minimize.onClick).AddListener((UnityAction)delegate
		{
			SingletonMonoBehaviour<WindowManager>.Instance.Minimize(this);
		});
		((UnityEvent)_maximize.onClick).AddListener((UnityAction)delegate
		{
			Maximize();
		});
		Vector3 prevCursorPos = default(Vector3);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(windowCover2D.DraggableHandle.OnEndDragAsObservable2D, (Action<PointerEventData>)delegate
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			prevCursorPos = default(Vector3);
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Vector3>(Observable.RepeatUntilDestroy<Vector3>(Observable.Select<PointerEventData, Vector3>(Observable.TakeWhile<PointerEventData>(Observable.TakeUntil<PointerEventData, PointerEventData>(Observable.SelectMany<PointerEventData, PointerEventData>(windowCover2D.DraggableHandle.OnBeginDragAsObservable2D, windowCover2D.DraggableHandle.OnDragAsObservable2D), windowCover2D.DraggableHandle.OnEndDragAsObservable2D), (Func<PointerEventData, bool>)((PointerEventData e) => Object.op_Implicit((Object)(object)windowCover2D))), (Func<PointerEventData, Vector3>)((PointerEventData _) => SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition)), (Component)(object)this), (Action<Vector3>)delegate(Vector3 pointer)
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			if (app2D == null)
			{
				app2D = nakamiApp.GetComponent<IApp2D>();
			}
			if (prevCursorPos != default(Vector3) && app2D != null)
			{
				Vector3 val = pointer - prevCursorPos;
				_ = val * scrollSpeed;
				Vector2 anchoredPosition = app2D.ScrollRect.content.anchoredPosition;
				app2D.ScrollRect.content.anchoredPosition = new Vector2(anchoredPosition.x, anchoredPosition.y + val.y);
			}
			prevCursorPos = pointer;
		}), ((Component)this).gameObject);
	}

	public void Born()
	{
		_runningSequence = ((Component)this).GetComponent<RectTransform>().born();
	}

	public void ResetSize()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		rect.sizeDelta = new Vector2(firstWidth, firstHeight);
	}

	public void Close()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		windowState = WindowState.closed;
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, new Vector2(0f, 0f), (CursorMode)0);
		Window2DStorage storage2D = SingletonMonoBehaviour<WindowManager>.Instance.Storage2D;
		if (storage2D.IsTargetWindow(this))
		{
			storage2D.StoreWindowInStorage(this);
		}
		else
		{
			Object.Destroy((Object)(object)((Component)this).gameObject);
		}
	}

	public void Closeable()
	{
		((Selectable)_close).interactable = true;
		((Selectable)_maximize).interactable = true;
		((Selectable)_minimize).interactable = true;
	}

	public void Maximize()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<WindowManager>.Instance.Touched(this);
		if (windowState == WindowState.maximized)
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_pirodown);
			((Component)this).GetComponent<RectTransform>().sizeDelta = new Vector2(firstWidth, firstHeight);
			windowState = WindowState.opened;
		}
		else
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
			windowState = WindowState.maximized;
			EndSequence();
			_runningSequence = ((Component)this).GetComponent<RectTransform>().maximizeWindow2D();
		}
	}

	public void Minimize()
	{
		windowState = WindowState.minimized;
		EndSequence();
		_runningSequence = ((Component)this).GetComponent<RectTransform>().minimize();
	}

	public void Open()
	{
		windowState = WindowState.opened;
	}

	public void Pop()
	{
		windowState = WindowState.opened;
		EndSequence();
		_runningSequence = ((Component)this).GetComponent<RectTransform>().pop();
	}

	private void EndSequence()
	{
		if (_runningSequence != null)
		{
			TweenExtensions.Complete((Tween)(object)_runningSequence);
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
		((Component)windowCover2D).gameObject.SetActive(true);
	}

	public void SetApp(AppTypeToData a)
	{
		appType = a.appType;
		data = a;
		SetContent(a);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			OnLanguageUpdated();
		}), ((Component)this).gameObject);
	}

	public void SetCachedApp(AppTypeToData a)
	{
		appType = a.appType;
		data = a;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			OnLanguageUpdated();
		}), ((Component)this).gameObject);
	}

	private void SetContent(AppTypeToData a)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		OnLanguageUpdated();
		((Component)this).GetComponent<RectSizeSyncSpriteRendererSizeExtensions>().SetRectSizeSyncPivot(RectSizeSyncPivot.CENTER);
		firstWidth = a.FirstWidth;
		firstHeight = a.FirstHeight;
		rect.sizeDelta = new Vector2(a.FirstWidth, a.FirstHeight);
		((Transform)rect).localPosition = new Vector3(a.FirstPosX, a.FirstPosY, 0f);
		if (!((Object)(object)a.InnerContent != (Object)null))
		{
			return;
		}
		if ((Object)(object)_nakamiApp == (Object)null)
		{
			GameObject val = Object.Instantiate<GameObject>(a.InnerContent, nakami_parent);
			_nakamiApp = val;
		}
		app2D = _nakamiApp.GetComponent<IApp2D>();
		if (app2D != null)
		{
			app2D.SetSortOrder(_sortingGroup.sortingOrder);
			((UnityEvent)((Button)windowCover2D.Button2D).onClick).AddListener((UnityAction)delegate
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = ((Component)((Transform)rect).parent).transform;
		RectTransform val = (RectTransform)(object)((transform is RectTransform) ? transform : null);
		Rect val2 = val.rect;
		_firstPosx = Random.Range(0f, ((Rect)(ref val2)).width - rect.sizeDelta.x);
		float num = 0f + rect.sizeDelta.y;
		val2 = val.rect;
		_firstPosy = Random.Range(num, ((Rect)(ref val2)).height);
		((Transform)rect).localPosition = Vector2.op_Implicit(new Vector2(_firstPosx, _firstPosy));
	}

	public override void Touched()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.Touched(this);
	}

	public void Uncloseable()
	{
		((Selectable)_close).interactable = false;
		((Selectable)_maximize).interactable = false;
		((Selectable)_minimize).interactable = false;
	}

	public void UnMovable()
	{
		((Behaviour)_MovableGrabber).enabled = false;
		((Behaviour)_leftBottomPoint).enabled = false;
		((Behaviour)_rightBottomPoint).enabled = false;
		((Behaviour)_rightTopPoint).enabled = false;
		((Behaviour)_leftTopPoint).enabled = false;
		((Behaviour)_BottomEdge).enabled = false;
		((Behaviour)_RightEdge).enabled = false;
		((Behaviour)_LeftEdge).enabled = false;
		((Behaviour)_TopEdge).enabled = false;
		((Behaviour)((Component)_leftBottomPoint).GetComponent<MouseCursor>()).enabled = false;
		((Behaviour)((Component)_rightBottomPoint).GetComponent<MouseCursor>()).enabled = false;
		((Behaviour)((Component)_rightTopPoint).GetComponent<MouseCursor>()).enabled = false;
		((Behaviour)((Component)_leftTopPoint).GetComponent<MouseCursor>()).enabled = false;
		((Behaviour)((Component)_BottomEdge).GetComponent<MouseCursor>()).enabled = false;
		((Behaviour)((Component)_RightEdge).GetComponent<MouseCursor>()).enabled = false;
		((Behaviour)((Component)_LeftEdge).GetComponent<MouseCursor>()).enabled = false;
		((Behaviour)((Component)_TopEdge).GetComponent<MouseCursor>()).enabled = false;
	}

	public void Movable()
	{
		((Behaviour)_MovableGrabber).enabled = true;
		((Behaviour)_leftBottomPoint).enabled = true;
		((Behaviour)_rightBottomPoint).enabled = true;
		((Behaviour)_rightTopPoint).enabled = true;
		((Behaviour)_leftTopPoint).enabled = true;
		((Behaviour)_BottomEdge).enabled = true;
		((Behaviour)_RightEdge).enabled = true;
		((Behaviour)_LeftEdge).enabled = true;
		((Behaviour)_TopEdge).enabled = true;
		((Behaviour)((Component)_leftBottomPoint).GetComponent<MouseCursor>()).enabled = true;
		((Behaviour)((Component)_rightBottomPoint).GetComponent<MouseCursor>()).enabled = true;
		((Behaviour)((Component)_rightTopPoint).GetComponent<MouseCursor>()).enabled = true;
		((Behaviour)((Component)_leftTopPoint).GetComponent<MouseCursor>()).enabled = true;
		((Behaviour)((Component)_BottomEdge).GetComponent<MouseCursor>()).enabled = true;
		((Behaviour)((Component)_RightEdge).GetComponent<MouseCursor>()).enabled = true;
		((Behaviour)((Component)_LeftEdge).GetComponent<MouseCursor>()).enabled = true;
		((Behaviour)((Component)_TopEdge).GetComponent<MouseCursor>()).enabled = true;
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
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
