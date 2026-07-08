using System;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

[Serializable]
public class Window : MoveAndScalableObject, IWindow, IScalable, IOpenable, IClosable, ISwitchableCloseState, IStateSwitchable, IUnityComponent, IStackable, ISwitchableMoveState
{
	[SerializeField]
	private GameObject edges;

	[SerializeField]
	private Button close;

	[SerializeField]
	private Button minimize;

	[SerializeField]
	private Button maximize;

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

	[SerializeField]
	private bool fixPostion;

	private Sequence _runningSequence;

	public WindowState windowState { get; set; }

	public ActiveState activeState { get; set; }

	public string Wname { get; set; } = "default Window";

	public Button _close => close;

	public Button _minimize => minimize;

	public Button _maximize => maximize;

	public AppType appType { get; set; } = AppType.Test;

	public GameObject nakamiApp { get; set; }

	public Transform GameObjectTransform => _transform;

	public GameObject UnityGameObject => ((Component)this).gameObject;

	public int OrderInLayer => _canvas.sortingOrder;

	public void SetStratchAble(bool active)
	{
		edges.SetActive(active);
	}

	public override void Awake()
	{
		base.Awake();
		_wakuImage = ((Component)this).GetComponent<Image>();
		_transform = ((Component)this).transform;
		if (_firstPosx == 0f && _firstPosy == 0f && !fixPostion)
		{
			setRandomPosition();
		}
		if (appType == AppType.MediaPlayer)
		{
			return;
		}
		Button obj = _close;
		if (obj != null)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(obj), (Action<Unit>)delegate
			{
				SingletonMonoBehaviour<WindowManager>.Instance.Close(this);
			}), (Component)(object)_close);
		}
		Button obj2 = _minimize;
		if (obj2 != null)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(obj2), (Action<Unit>)delegate
			{
				SingletonMonoBehaviour<WindowManager>.Instance.Minimize(this);
			}), (Component)(object)_minimize);
		}
		Button obj3 = _maximize;
		if (obj3 != null)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(obj3), (Action<Unit>)delegate
			{
				Maximize();
			}), (Component)(object)_maximize);
		}
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
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		OnLanguageUpdated();
		if (!((Object)(object)rect == (Object)null))
		{
			((Transform)rect).localPosition = new Vector3(a.FirstPosX, a.FirstPosY, 0f);
			firstWidth = a.FirstWidth;
			firstHeight = a.FirstHeight;
			rect.sizeDelta = new Vector2(a.FirstWidth, a.FirstHeight);
			if ((Object)(object)a.InnerContent != (Object)null)
			{
				GameObject val = Object.Instantiate<GameObject>(a.InnerContent, _nakamiParent);
				nakamiApp = val;
			}
		}
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
		Object.Destroy((Object)(object)((Component)this).gameObject);
	}

	public void Minimize()
	{
		windowState = WindowState.minimized;
		EndSequence();
		_runningSequence = ((Component)this).GetComponent<RectTransform>().minimize();
	}

	public void Pop()
	{
		windowState = WindowState.opened;
		EndSequence();
		_runningSequence = ((Component)this).GetComponent<RectTransform>().pop();
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
			_runningSequence = ((Component)this).GetComponent<RectTransform>().maximize();
		}
	}

	public void Born()
	{
		EndSequence();
		_runningSequence = ((Component)this).GetComponent<RectTransform>().born();
	}

	private void EndSequence()
	{
		if (_runningSequence != null)
		{
			TweenExtensions.Complete((Tween)(object)_runningSequence);
		}
	}

	public void Open()
	{
		windowState = WindowState.opened;
	}

	public override void Touched()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.Touched(this);
	}

	public void setActive()
	{
		activeState = ActiveState.Active;
		_wakuImage.sprite = _active;
		((Component)_cover).gameObject.SetActive(false);
		contents.interactable = true;
		SingletonMonoBehaviour<WindowManager>.Instance.SetForeground(this);
	}

	public void setInActive()
	{
		activeState = ActiveState.InActive;
		_wakuImage.sprite = _inActive;
		((Component)_cover).gameObject.SetActive(true);
		contents.interactable = false;
	}

	public void Uncloseable()
	{
		((Selectable)_close).interactable = false;
		((Selectable)_maximize).interactable = false;
		((Selectable)_minimize).interactable = false;
	}

	public void Closeable()
	{
		((Selectable)_close).interactable = true;
		((Selectable)_maximize).interactable = true;
		((Selectable)_minimize).interactable = true;
	}

	public void UnMovable()
	{
		_isMovable = false;
		((Component)_leftBottomPoint).gameObject.SetActive(false);
		((Component)_rightBottomPoint).gameObject.SetActive(false);
		((Component)_rightTopPoint).gameObject.SetActive(false);
		((Component)_leftTopPoint).gameObject.SetActive(false);
		((Component)_BottomEdge).gameObject.SetActive(false);
		((Component)_RightEdge).gameObject.SetActive(false);
		((Component)_LeftEdge).gameObject.SetActive(false);
		((Component)_TopEdge).gameObject.SetActive(false);
	}

	public void Movable()
	{
		_isMovable = true;
		((Component)_leftBottomPoint).gameObject.SetActive(true);
		((Component)_rightBottomPoint).gameObject.SetActive(true);
		((Component)_rightTopPoint).gameObject.SetActive(true);
		((Component)_leftTopPoint).gameObject.SetActive(true);
		((Component)_BottomEdge).gameObject.SetActive(true);
		((Component)_RightEdge).gameObject.SetActive(true);
		((Component)_LeftEdge).gameObject.SetActive(true);
		((Component)_TopEdge).gameObject.SetActive(true);
	}

	public void OnLanguageUpdated()
	{
		string name = NgoEx.SystemTextFromType(data.AppName, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		SetName(name);
	}

	public void SetOrderInLayer(int order)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		_canvas.sortingOrder = order;
		Vector3 position = GameObjectTransform.position;
		position.z = 100 - order;
		GameObjectTransform.position = position;
	}
}
