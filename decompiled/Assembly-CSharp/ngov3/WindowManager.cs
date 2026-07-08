using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class WindowManager : SingletonMonoBehaviour<WindowManager>
{
	protected readonly ReactiveCollection<IWindow> _windowList = new ReactiveCollection<IWindow>();

	[SerializeField]
	protected Transform _windowparent;

	[SerializeField]
	protected Transform _windowparent2D;

	[SerializeField]
	protected Canvas _mainCanvas;

	[SerializeField]
	protected TaskButton _taskButtonBase;

	[SerializeField]
	protected GameObject _taskbarparent;

	[SerializeField]
	protected Window _windowBase;

	[SerializeField]
	protected Window_NoInteractive _windowBase_noInteractive;

	[SerializeField]
	protected Window_Compact _windowBase_Compact;

	[SerializeField]
	protected Window2D _windowBase2D;

	[SerializeField]
	protected Window _mediaPlayer;

	[SerializeField]
	protected DieMovable _die;

	[SerializeField]
	protected LoveMovable _Love;

	[SerializeField]
	protected List<TaskButton> _taskBarList = new List<TaskButton>();

	[SerializeField]
	private Window2DStorage _window2DStorage;

	private const int MAX_WINDOW_ORDER = 30;

	private const int FOREGROUND_ORDER = 40;

	private const int MIN_WINDOW_ORDER = 1;

	public List<IWindow> WindowList => _windowList.ToList();

	public IObservable<CollectionAddEvent<IWindow>> OnAdd => _windowList.ObserveAdd();

	public List<TaskButton> TaskBarList => _taskBarList.ToList();

	public Canvas MainCanvas => _mainCanvas;

	public Window2DStorage Storage2D => _window2DStorage;

	protected override void Awake()
	{
		base.Awake();
	}

	public void Start()
	{
		if (!(SingletonMonoBehaviour<StatusManager>.Instance == null))
		{
			StatusManager statusManager = SingletonMonoBehaviour<StatusManager>.Instance;
			if ((object)statusManager == null || statusManager.GetStatus(StatusType.DayIndex) != 1)
			{
				OpenBasicWindow();
			}
		}
	}

	public void OpenBasicWindow()
	{
		if (!SingletonMonoBehaviour<EventManager>.Instance.isHorror)
		{
			NewWindow(AppType.TaskManager, playSe: false);
		}
		NewWindow(AppType.Webcam, playSe: false);
	}

	public void Clean()
	{
		MinifyApp(AppType.Poketter);
		if (!isAppOpen(AppType.WebcamMini))
		{
			NewWindow(AppType.Webcam);
		}
	}

	public void CleanOnCommand(bool is2ch = false, bool isDeai = false)
	{
		foreach (IWindow window in WindowList)
		{
			if (window.appType != AppType.Webcam && window.appType != AppType.TaskManager && window.appType != AppType.MediaPlayer && (!is2ch || window.appType != AppType.Keijiban) && (!isDeai || window.appType != AppType.Dinder))
			{
				Close(window);
			}
		}
	}

	public async UniTask CleanWindowCalmly()
	{
		foreach (Window window in WindowList)
		{
			if (window.appType != AppType.Webcam)
			{
				Close(window);
			}
			await UniTask.Delay(120);
		}
	}

	public void CleanOnLoad()
	{
		CleanAll();
		OpenBasicWindow();
	}

	public void CleanAll()
	{
		foreach (IWindow window in WindowList)
		{
			Close(window);
		}
	}

	public IWindow NewWindow(AppType appType, Transform parent)
	{
		AppTypeToData appTypeToData = LoadAppData.ReadAppContent(appType);
		IWindow window2;
		if (!appTypeToData.is2DWindow)
		{
			IWindow window = UnityEngine.Object.Instantiate(_windowBase, parent);
			window2 = window;
		}
		else
		{
			IWindow window = UnityEngine.Object.Instantiate(_windowBase2D, parent);
			window2 = window;
		}
		IWindow window3 = window2;
		window3.SetApp(appTypeToData);
		window3.windowState = WindowState.opened;
		_windowList.Add(window3);
		TaskButton taskButton = UnityEngine.Object.Instantiate(_taskButtonBase, _taskbarparent.transform);
		taskButton.setWindow(window3);
		_taskBarList.Add(taskButton);
		return window3;
	}

	public IWindow NewWindow(AppType appType, bool playSe = true)
	{
		if (appType == AppType.MediaPlayer)
		{
			IWindow window = WindowList.Find((IWindow l) => l.appType == AppType.MediaPlayer);
			if (window != null)
			{
				Touched(window);
				return window;
			}
			Window window2 = UnityEngine.Object.Instantiate(_mediaPlayer, _windowparent);
			window2.windowState = WindowState.opened;
			_windowList.Add(window2);
			TaskButton taskButton = UnityEngine.Object.Instantiate(_taskButtonBase, _taskbarparent.transform);
			taskButton.setWindow(window2);
			_taskBarList.Add(taskButton);
			ActivateFirst();
			return window2;
		}
		AppTypeToData appdata = LoadAppData.ReadAppContent(appType);
		if (appdata.isOnly)
		{
			IWindow window3 = WindowList.Find((IWindow l) => l.appType == appdata.appType);
			if (window3 != null)
			{
				Touched(window3);
				return window3;
			}
		}
		IWindow window4 = null;
		if (_window2DStorage != null && _window2DStorage.IsTargetWindow(appdata))
		{
			window4 = _window2DStorage.PickWindowFromStorage(appdata.InnerContent.name);
			window4.GameObjectTransform.parent = _windowparent2D;
		}
		else
		{
			IWindow window6;
			if (!appdata.is2DWindow)
			{
				IWindow window5 = UnityEngine.Object.Instantiate(_windowBase, _windowparent);
				window6 = window5;
			}
			else
			{
				IWindow window5 = UnityEngine.Object.Instantiate(_windowBase2D, _windowparent2D);
				window6 = window5;
			}
			window4 = window6;
		}
		if (appType == AppType.ManualHaishin)
		{
			window4._minimize.gameObject.SetActive(value: false);
			window4._maximize.gameObject.SetActive(value: false);
			window4.SetStratchAble(active: false);
			window4.UnMovable();
			window4._close.onClick.AddListener(delegate
			{
				AudioManager.Instance?.PlayBgmById("BGM_OP_PV");
			});
			window4.UnityGameObject.GetComponent<RectTransform>().maximizeLiveGen();
		}
		window4.SetApp(appdata);
		window4.windowState = WindowState.opened;
		_windowList.Add(window4);
		TaskButton taskButton2 = UnityEngine.Object.Instantiate(_taskButtonBase, _taskbarparent.transform);
		taskButton2.setWindow(window4);
		_taskBarList.Add(taskButton2);
		if (playSe)
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
		}
		ActivateFirst();
		if (appType == AppType.Webcam)
		{
			window4._close.gameObject.AddComponent<Event_WebCamAngry>();
			window4._minimize.gameObject.AddComponent<Event_WebCamAngry>();
			taskButton2.gameObject.AddComponent<Event_WebCamAngry>();
		}
		return window4;
	}

	public IWindow NewWindow_NoInteractive(AppType appType)
	{
		AppTypeToData appdata = LoadAppData.ReadAppContent(appType);
		if (appdata.isOnly)
		{
			IWindow window = WindowList.Find((IWindow l) => l.appType == appdata.appType);
			if (window != null)
			{
				Touched(window);
				return window;
			}
		}
		IWindow window2 = UnityEngine.Object.Instantiate(_windowBase_noInteractive, _windowparent);
		window2.SetApp(appdata);
		window2.windowState = WindowState.opened;
		_windowList.Add(window2);
		TaskButton taskButton = UnityEngine.Object.Instantiate(_taskButtonBase, _taskbarparent.transform);
		taskButton.setWindow(window2);
		_taskBarList.Add(taskButton);
		AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
		ActivateFirst();
		return window2;
	}

	public IWindow NewWindow_Compact(AppType appType, bool playSe = true, bool makeTaskButton = true)
	{
		AppTypeToData appdata = LoadAppData.ReadAppContent(appType);
		if (appdata.isOnly)
		{
			IWindow window = WindowList.Find((IWindow l) => l.appType == appdata.appType);
			if (window != null)
			{
				Touched(window);
				return window;
			}
		}
		IWindow window2 = null;
		window2 = UnityEngine.Object.Instantiate(_windowBase_Compact, _windowparent);
		window2.SetApp(appdata);
		window2.windowState = WindowState.opened;
		_windowList.Add(window2);
		if (makeTaskButton)
		{
			TaskButton taskButton = UnityEngine.Object.Instantiate(_taskButtonBase, _taskbarparent.transform);
			taskButton.setWindow(window2);
			_taskBarList.Add(taskButton);
		}
		if (playSe)
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
		}
		ActivateFirst();
		if (appType == AppType.Webcam)
		{
			window2._close.gameObject.AddComponent<Event_WebCamAngry>();
		}
		return window2;
	}

	public void MakeTaskButton(IWindow newWindow)
	{
		TaskButton taskButton = UnityEngine.Object.Instantiate(_taskButtonBase, _taskbarparent.transform);
		taskButton.setWindow(newWindow);
		_taskBarList.Add(taskButton);
	}

	public async UniTask DieOut()
	{
		for (int i = 0; i < 40; i++)
		{
			UnityEngine.Object.Instantiate(_die, _windowparent).setRandomPosition();
			await UniTask.Delay(20);
		}
	}

	public async UniTask LoveOut()
	{
		Transform panel = GameObject.Find("CoverForGamen").transform;
		for (int i = 0; i < 200; i++)
		{
			UnityEngine.Object.Instantiate(_Love, panel).setRandomPosition();
			await UniTask.Delay(41 - i / 10);
		}
	}

	public IWindow GetWindowFromApp(AppType app)
	{
		return WindowList.Find((IWindow l) => l.appType == app);
	}

	public GameObject GetNakamiFromApp(AppType app)
	{
		IWindow window = WindowList.Find((IWindow l) => l.appType == app);
		if (window == null)
		{
			Debug.Log(app.ToString() + "のウィンドウがなかった");
			return null;
		}
		return window.nakamiApp;
	}

	public bool isAppOpen(AppType app)
	{
		IWindow window = WindowList.Find((IWindow l) => l.appType == app);
		if (window == null)
		{
			return false;
		}
		if (window.windowState == WindowState.minimized || window.windowState == WindowState.closed)
		{
			return false;
		}
		return true;
	}

	public bool isAppActive(AppType app)
	{
		if (!isAppOpen(app))
		{
			return false;
		}
		if (WindowList.Find((IWindow l) => l.appType == app).activeState == ActiveState.Active)
		{
			return true;
		}
		return false;
	}

	public void NewWindow(string name)
	{
		IWindow window = WindowList.Find((IWindow l) => l.Wname == name);
		if (window != null)
		{
			Touched(window);
			return;
		}
		Window window2 = UnityEngine.Object.Instantiate(_windowBase, _windowparent);
		window2.SetName(name);
		_windowList.Add(window2);
		window2.setRandomPosition();
		TaskButton taskButton = UnityEngine.Object.Instantiate(_taskButtonBase, _taskbarparent.transform);
		taskButton.setWindow(window2);
		_taskBarList.Add(taskButton);
		ActivateFirst();
	}

	public void RegistPresetWindow(IWindow window)
	{
		_windowList.Add(window);
		window.setRandomPosition();
		TaskButton taskButton = UnityEngine.Object.Instantiate(_taskButtonBase, _taskbarparent.transform);
		taskButton.setWindow(window);
		_taskBarList.Add(taskButton);
		ActivateFirst();
	}

	public int Count()
	{
		return WindowList.Count;
	}

	public void ActivateFirst()
	{
		if (Count() > 0)
		{
			for (int num = Count() - 1; num >= 0; num--)
			{
				WindowList[num].setInActive();
			}
			WindowList.Last().setActive();
		}
	}

	public void Touched(IWindow w)
	{
		if (_windowList.Contains(w) && (!isAppOpen(AppType.EndingDialog) || w.appType == AppType.EndingDialog))
		{
			if (w.windowState == WindowState.minimized)
			{
				Pop(w);
			}
			if (_windowList.Remove(w))
			{
				_windowList.Add(w);
				SetForeground(w);
			}
			ActivateFirst();
		}
	}

	public void SetForeground(IWindow w)
	{
		int orderInLayer = w.OrderInLayer;
		foreach (IWindow window in _windowList)
		{
			if (window.OrderInLayer >= orderInLayer)
			{
				window.SetOrderInLayer(Mathf.Clamp(window.OrderInLayer - 1, 1, 30));
			}
		}
		w.SetOrderInLayer(40);
	}

	public void CloseApp(AppType app)
	{
		if (isAppOpen(app))
		{
			Close(GetWindowFromApp(app));
		}
	}

	public void MinifyApp(AppType app)
	{
		if (isAppOpen(app))
		{
			Minimize(GetWindowFromApp(app));
		}
	}

	public void Close(IWindow w)
	{
		w.Close();
		_windowList.Remove(w);
		TaskButton taskbarByWindow = getTaskbarByWindow(_taskBarList, w);
		_taskBarList.Remove(taskbarByWindow);
		taskbarByWindow.Close();
		AudioManager.Instance.PlaySeByType(SoundType.SE_window_close);
		ActivateFirst();
	}

	public TaskButton getTaskbarByWindow(List<TaskButton> list, IWindow w)
	{
		return list.Find((TaskButton t) => t.window.Wname == w.Wname);
	}

	public void Minimize(IWindow w)
	{
		w.Minimize();
		TaskButton taskbarByWindow = getTaskbarByWindow(_taskBarList, w);
		if (!(taskbarByWindow == null))
		{
			taskbarByWindow.Minimize();
			AudioManager.Instance.PlaySeByType(SoundType.SE_pirodown);
		}
	}

	public void Pop(IWindow w)
	{
		w.Pop();
		TaskButton taskbarByWindow = getTaskbarByWindow(_taskBarList, w);
		if (!(taskbarByWindow == null))
		{
			taskbarByWindow.Pop();
			Touched(w);
			AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
		}
	}

	public void Uncloseable(IWindow w)
	{
		w.Uncloseable();
	}

	public void UnMovable(IWindow w)
	{
		w.UnMovable();
	}

	public void Uncloseable(AppType a)
	{
		IWindow windowFromApp = GetWindowFromApp(a);
		Uncloseable(windowFromApp);
	}

	public void Closeable(AppType a)
	{
		GetWindowFromApp(a).Closeable();
	}

	public void UnMovable(AppType a)
	{
		IWindow windowFromApp = GetWindowFromApp(a);
		UnMovable(windowFromApp);
	}
}
