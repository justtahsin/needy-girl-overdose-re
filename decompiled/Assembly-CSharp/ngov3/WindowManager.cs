using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ngov3;

public class WindowManager : SingletonMonoBehaviour<WindowManager>
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Predicate<IWindow> _003C_003E9__34_0;

		public static UnityAction _003C_003E9__34_1;

		internal bool _003CNewWindow_003Eb__34_0(IWindow l)
		{
			return l.appType == AppType.MediaPlayer;
		}

		internal void _003CNewWindow_003Eb__34_1()
		{
			AudioManager.Instance?.PlayBgmById("BGM_OP_PV");
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CCleanWindowCalmly_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public WindowManager _003C_003E4__this;

		private List<IWindow>.Enumerator _003C_003E7__wrap1;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			WindowManager windowManager = _003C_003E4__this;
			try
			{
				if (num != 0)
				{
					_003C_003E7__wrap1 = windowManager.WindowList.GetEnumerator();
				}
				try
				{
					if (num != 0)
					{
						goto IL_00b8;
					}
					Awaiter val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b1;
					IL_00b1:
					((Awaiter)(ref val)).GetResult();
					goto IL_00b8;
					IL_00b8:
					if (_003C_003E7__wrap1.MoveNext())
					{
						Window window = (Window)_003C_003E7__wrap1.Current;
						if (window.appType != AppType.Webcam)
						{
							windowManager.Close(window);
						}
						UniTask val2 = UniTask.Delay(120, false, (PlayerLoopTiming)8, default(CancellationToken), false);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CCleanWindowCalmly_003Ed__30>(ref val, ref this);
							return;
						}
						goto IL_00b1;
					}
				}
				finally
				{
					if (num < 0)
					{
						((IDisposable)_003C_003E7__wrap1/*cast due to constrained. prefix*/).Dispose();
					}
				}
				_003C_003E7__wrap1 = default(List<IWindow>.Enumerator);
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CDieOut_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public WindowManager _003C_003E4__this;

		private int _003Ci_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			WindowManager windowManager = _003C_003E4__this;
			try
			{
				if (num != 0)
				{
					_003Ci_003E5__2 = 0;
					goto IL_00ae;
				}
				Awaiter val = _003C_003Eu__1;
				_003C_003Eu__1 = default(Awaiter);
				num = (_003C_003E1__state = -1);
				goto IL_0095;
				IL_0095:
				((Awaiter)(ref val)).GetResult();
				_003Ci_003E5__2++;
				goto IL_00ae;
				IL_00ae:
				if (_003Ci_003E5__2 < 40)
				{
					Object.Instantiate<DieMovable>(windowManager._die, windowManager._windowparent).setRandomPosition();
					UniTask val2 = UniTask.Delay(20, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CDieOut_003Ed__38>(ref val, ref this);
						return;
					}
					goto IL_0095;
				}
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CLoveOut_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public WindowManager _003C_003E4__this;

		private Transform _003Cpanel_003E5__2;

		private int _003Ci_003E5__3;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			WindowManager windowManager = _003C_003E4__this;
			try
			{
				if (num != 0)
				{
					_003Cpanel_003E5__2 = GameObject.Find("CoverForGamen").transform;
					_003Ci_003E5__3 = 0;
					goto IL_00d3;
				}
				Awaiter val = _003C_003Eu__1;
				_003C_003Eu__1 = default(Awaiter);
				num = (_003C_003E1__state = -1);
				goto IL_00ba;
				IL_00ba:
				((Awaiter)(ref val)).GetResult();
				_003Ci_003E5__3++;
				goto IL_00d3;
				IL_00d3:
				if (_003Ci_003E5__3 < 200)
				{
					Object.Instantiate<LoveMovable>(windowManager._Love, _003Cpanel_003E5__2).setRandomPosition();
					UniTask val2 = UniTask.Delay(41 - _003Ci_003E5__3 / 10, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CLoveOut_003Ed__39>(ref val, ref this);
						return;
					}
					goto IL_00ba;
				}
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cpanel_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cpanel_003E5__2 = null;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

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

	public List<IWindow> WindowList => ((IEnumerable<IWindow>)_windowList).ToList();

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
		if (!((Object)(object)SingletonMonoBehaviour<StatusManager>.Instance == (Object)null))
		{
			StatusManager statusManager = SingletonMonoBehaviour<StatusManager>.Instance;
			if (statusManager == null || statusManager.GetStatus(StatusType.DayIndex) != 1)
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

	[AsyncStateMachine(typeof(_003CCleanWindowCalmly_003Ed__30))]
	public UniTask CleanWindowCalmly()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CCleanWindowCalmly_003Ed__30 _003CCleanWindowCalmly_003Ed__31 = default(_003CCleanWindowCalmly_003Ed__30);
		_003CCleanWindowCalmly_003Ed__31._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CCleanWindowCalmly_003Ed__31._003C_003E4__this = this;
		_003CCleanWindowCalmly_003Ed__31._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CCleanWindowCalmly_003Ed__31._003C_003Et__builder)).Start<_003CCleanWindowCalmly_003Ed__30>(ref _003CCleanWindowCalmly_003Ed__31);
		return ((AsyncUniTaskMethodBuilder)(ref _003CCleanWindowCalmly_003Ed__31._003C_003Et__builder)).Task;
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
			IWindow window = Object.Instantiate<Window>(_windowBase, parent);
			window2 = window;
		}
		else
		{
			IWindow window = Object.Instantiate<Window2D>(_windowBase2D, parent);
			window2 = window;
		}
		IWindow window3 = window2;
		window3.SetApp(appTypeToData);
		window3.windowState = WindowState.opened;
		((Collection<IWindow>)(object)_windowList).Add(window3);
		TaskButton taskButton = Object.Instantiate<TaskButton>(_taskButtonBase, _taskbarparent.transform);
		taskButton.setWindow(window3);
		_taskBarList.Add(taskButton);
		return window3;
	}

	public IWindow NewWindow(AppType appType, bool playSe = true)
	{
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		if (appType == AppType.MediaPlayer)
		{
			IWindow window = WindowList.Find((IWindow l) => l.appType == AppType.MediaPlayer);
			if (window != null)
			{
				Touched(window);
				return window;
			}
			Window window2 = Object.Instantiate<Window>(_mediaPlayer, _windowparent);
			window2.windowState = WindowState.opened;
			((Collection<IWindow>)(object)_windowList).Add((IWindow)window2);
			TaskButton taskButton = Object.Instantiate<TaskButton>(_taskButtonBase, _taskbarparent.transform);
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
		if ((Object)(object)_window2DStorage != (Object)null && _window2DStorage.IsTargetWindow(appdata))
		{
			window4 = _window2DStorage.PickWindowFromStorage(((Object)appdata.InnerContent).name);
			window4.GameObjectTransform.parent = _windowparent2D;
		}
		else
		{
			IWindow window6;
			if (!appdata.is2DWindow)
			{
				IWindow window5 = Object.Instantiate<Window>(_windowBase, _windowparent);
				window6 = window5;
			}
			else
			{
				IWindow window5 = Object.Instantiate<Window2D>(_windowBase2D, _windowparent2D);
				window6 = window5;
			}
			window4 = window6;
		}
		if (appType == AppType.ManualHaishin)
		{
			((Component)window4._minimize).gameObject.SetActive(false);
			((Component)window4._maximize).gameObject.SetActive(false);
			window4.SetStratchAble(active: false);
			window4.UnMovable();
			ButtonClickedEvent onClick = window4._close.onClick;
			object obj = _003C_003Ec._003C_003E9__34_1;
			if (obj == null)
			{
				UnityAction val = delegate
				{
					AudioManager.Instance?.PlayBgmById("BGM_OP_PV");
				};
				_003C_003Ec._003C_003E9__34_1 = val;
				obj = (object)val;
			}
			((UnityEvent)onClick).AddListener((UnityAction)obj);
			window4.UnityGameObject.GetComponent<RectTransform>().maximizeLiveGen();
		}
		window4.SetApp(appdata);
		window4.windowState = WindowState.opened;
		((Collection<IWindow>)(object)_windowList).Add(window4);
		TaskButton taskButton2 = Object.Instantiate<TaskButton>(_taskButtonBase, _taskbarparent.transform);
		taskButton2.setWindow(window4);
		_taskBarList.Add(taskButton2);
		if (playSe)
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
		}
		ActivateFirst();
		if (appType == AppType.Webcam)
		{
			((Component)window4._close).gameObject.AddComponent<Event_WebCamAngry>();
			((Component)window4._minimize).gameObject.AddComponent<Event_WebCamAngry>();
			((Component)taskButton2).gameObject.AddComponent<Event_WebCamAngry>();
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
		IWindow window2 = Object.Instantiate<Window_NoInteractive>(_windowBase_noInteractive, _windowparent);
		window2.SetApp(appdata);
		window2.windowState = WindowState.opened;
		((Collection<IWindow>)(object)_windowList).Add(window2);
		TaskButton taskButton = Object.Instantiate<TaskButton>(_taskButtonBase, _taskbarparent.transform);
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
		window2 = Object.Instantiate<Window_Compact>(_windowBase_Compact, _windowparent);
		window2.SetApp(appdata);
		window2.windowState = WindowState.opened;
		((Collection<IWindow>)(object)_windowList).Add(window2);
		if (makeTaskButton)
		{
			TaskButton taskButton = Object.Instantiate<TaskButton>(_taskButtonBase, _taskbarparent.transform);
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
			((Component)window2._close).gameObject.AddComponent<Event_WebCamAngry>();
		}
		return window2;
	}

	public void MakeTaskButton(IWindow newWindow)
	{
		TaskButton taskButton = Object.Instantiate<TaskButton>(_taskButtonBase, _taskbarparent.transform);
		taskButton.setWindow(newWindow);
		_taskBarList.Add(taskButton);
	}

	[AsyncStateMachine(typeof(_003CDieOut_003Ed__38))]
	public UniTask DieOut()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CDieOut_003Ed__38 _003CDieOut_003Ed__39 = default(_003CDieOut_003Ed__38);
		_003CDieOut_003Ed__39._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CDieOut_003Ed__39._003C_003E4__this = this;
		_003CDieOut_003Ed__39._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CDieOut_003Ed__39._003C_003Et__builder)).Start<_003CDieOut_003Ed__38>(ref _003CDieOut_003Ed__39);
		return ((AsyncUniTaskMethodBuilder)(ref _003CDieOut_003Ed__39._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoveOut_003Ed__39))]
	public UniTask LoveOut()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CLoveOut_003Ed__39 _003CLoveOut_003Ed__40 = default(_003CLoveOut_003Ed__39);
		_003CLoveOut_003Ed__40._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CLoveOut_003Ed__40._003C_003E4__this = this;
		_003CLoveOut_003Ed__40._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CLoveOut_003Ed__40._003C_003Et__builder)).Start<_003CLoveOut_003Ed__39>(ref _003CLoveOut_003Ed__40);
		return ((AsyncUniTaskMethodBuilder)(ref _003CLoveOut_003Ed__40._003C_003Et__builder)).Task;
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
			Debug.Log((object)(app.ToString() + "のウィンドウがなかった"));
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
		Window window2 = Object.Instantiate<Window>(_windowBase, _windowparent);
		window2.SetName(name);
		((Collection<IWindow>)(object)_windowList).Add((IWindow)window2);
		window2.setRandomPosition();
		TaskButton taskButton = Object.Instantiate<TaskButton>(_taskButtonBase, _taskbarparent.transform);
		taskButton.setWindow(window2);
		_taskBarList.Add(taskButton);
		ActivateFirst();
	}

	public void RegistPresetWindow(IWindow window)
	{
		((Collection<IWindow>)(object)_windowList).Add(window);
		window.setRandomPosition();
		TaskButton taskButton = Object.Instantiate<TaskButton>(_taskButtonBase, _taskbarparent.transform);
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
		if (((Collection<IWindow>)(object)_windowList).Contains(w) && (!isAppOpen(AppType.EndingDialog) || w.appType == AppType.EndingDialog))
		{
			if (w.windowState == WindowState.minimized)
			{
				Pop(w);
			}
			if (((Collection<IWindow>)(object)_windowList).Remove(w))
			{
				((Collection<IWindow>)(object)_windowList).Add(w);
				SetForeground(w);
			}
			ActivateFirst();
		}
	}

	public void SetForeground(IWindow w)
	{
		int orderInLayer = w.OrderInLayer;
		foreach (IWindow item in (Collection<IWindow>)(object)_windowList)
		{
			if (item.OrderInLayer >= orderInLayer)
			{
				item.SetOrderInLayer(Mathf.Clamp(item.OrderInLayer - 1, 1, 30));
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
		((Collection<IWindow>)(object)_windowList).Remove(w);
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
		if (!((Object)(object)taskbarByWindow == (Object)null))
		{
			taskbarByWindow.Minimize();
			AudioManager.Instance.PlaySeByType(SoundType.SE_pirodown);
		}
	}

	public void Pop(IWindow w)
	{
		w.Pop();
		TaskButton taskbarByWindow = getTaskbarByWindow(_taskBarList, w);
		if (!((Object)(object)taskbarByWindow == (Object)null))
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
