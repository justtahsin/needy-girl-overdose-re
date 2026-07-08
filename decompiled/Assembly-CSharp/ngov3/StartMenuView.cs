using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ngov3;

public class StartMenuView : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003COnHide_003Ed__27 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public StartMenuView _003C_003E4__this;

		private TweenAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			StartMenuView startMenuView = _003C_003E4__this;
			try
			{
				float num2 = default(float);
				if (num != 0)
				{
					((Graphic)((Component)startMenuView._startMenuParent).gameObject.GetComponent<Image>()).raycastTarget = false;
					startMenuView._canvasGroup.interactable = false;
					num2 = (float)startMenuView._tweenMillisecond / 1000f;
					ShortcutExtensions.DOKill((Component)(object)startMenuView._rect, false);
				}
				try
				{
					TweenAwaiter val;
					if (num != 0)
					{
						val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)startMenuView._rect, startMenuView._fromHeight, num2, false), startMenuView._easeType)));
						if (!((TweenAwaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003COnHide_003Ed__27>(ref val, ref this);
							return;
						}
					}
					else
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(TweenAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TweenAwaiter)(ref val)).GetResult();
				}
				catch (OperationCanceledException)
				{
					throw;
				}
				catch (NullReferenceException)
				{
					throw;
				}
				catch (MissingReferenceException)
				{
					throw;
				}
				startMenuView._isShowing = false;
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
	private struct _003COnShow_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public StartMenuView _003C_003E4__this;

		private TweenAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			StartMenuView CS_0024_003C_003E8__locals13 = _003C_003E4__this;
			try
			{
				float num2 = default(float);
				float num3 = default(float);
				if (num != 0)
				{
					CS_0024_003C_003E8__locals13.ResetPosition();
					CS_0024_003C_003E8__locals13._logo.text = NgoEx.SystemTextFromType(SystemTextType.Common_NGO, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
					CS_0024_003C_003E8__locals13._canvasGroup.interactable = true;
					num2 = (float)CS_0024_003C_003E8__locals13._tweenMillisecond / 1000f;
					num3 = CS_0024_003C_003E8__locals13._rect.sizeDelta.y + 48f;
					CS_0024_003C_003E8__locals13._isShowing = true;
					ShortcutExtensions.DOKill((Component)(object)CS_0024_003C_003E8__locals13._rect, false);
				}
				try
				{
					TweenAwaiter val;
					if (num != 0)
					{
						val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetRelative<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)CS_0024_003C_003E8__locals13._rect, num3, num2, false)), CS_0024_003C_003E8__locals13._easeType)));
						if (!((TweenAwaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003COnShow_003Ed__26>(ref val, ref this);
							return;
						}
					}
					else
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(TweenAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TweenAwaiter)(ref val)).GetResult();
				}
				catch (OperationCanceledException)
				{
					throw;
				}
				catch (NullReferenceException)
				{
					throw;
				}
				catch (MissingReferenceException)
				{
					throw;
				}
				((Graphic)((Component)CS_0024_003C_003E8__locals13._startMenuParent).gameObject.GetComponent<Image>()).raycastTarget = true;
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals13._startMenuParent), (Action<Unit>)async delegate
				{
					await CS_0024_003C_003E8__locals13.OnHide();
				}), ((Component)CS_0024_003C_003E8__locals13._startMenuParent).gameObject);
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

	[SerializeField]
	private RectTransform _rect;

	[SerializeField]
	private StartButton _startButton;

	[SerializeField]
	private Button _startMenuParent;

	[SerializeField]
	private TMP_Text _logo;

	[SerializeField]
	private TMP_Text _newGameText;

	[SerializeField]
	private Button _newGameButton;

	[SerializeField]
	private Button _loadGameButton;

	[SerializeField]
	private Button _controllerGuideButton;

	[SerializeField]
	private Button _myPictureButton;

	[SerializeField]
	private Button _controllPanelButton;

	[SerializeField]
	private Button _rebootButton;

	[SerializeField]
	private Button _shutDownButton;

	private CanvasGroup _canvasGroup;

	[SerializeField]
	private int _tweenMillisecond = 100;

	private float _fromHeight;

	[SerializeField]
	private Ease _easeType;

	private bool _isShowing;

	private bool _hasSaveData;

	private Vector3 _defaultPosition;

	public bool IsShowIng => _isShowing;

	public StartButton StartButton => _startButton;

	private void Start()
	{
	}

	private void Awake()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		((Component)_shutDownButton).gameObject.SetActive(true);
		((Component)_controllerGuideButton).gameObject.SetActive(false);
		((Component)_newGameButton).gameObject.SetActive(true);
		((Component)_loadGameButton).gameObject.SetActive(true);
		_defaultPosition = ((Transform)_rect).localPosition;
		_fromHeight = ((Transform)_rect).localPosition.y;
		_canvasGroup = ((Component)this).GetComponent<CanvasGroup>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Button>((IObservable<Button>)_startButton.OnStartButton, (Action<Button>)delegate
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			if (_isShowing)
			{
				UniTaskExtensions.Forget(OnHide());
			}
			else
			{
				UniTaskExtensions.Forget(OnShow());
			}
		}), ((Component)this).gameObject);
		OnLanguageUpdated();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			OnLanguageUpdated();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_newGameButton), (Action<Unit>)delegate
		{
			OnNewGame();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_loadGameButton), (Action<Unit>)delegate
		{
			OnStartGame();
		}), ((Component)this).gameObject);
		if ((Object)(object)_controllerGuideButton != (Object)null)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_controllerGuideButton), (Action<Unit>)delegate
			{
				OnControllerGuide();
			}), ((Component)this).gameObject);
		}
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_myPictureButton), (Action<Unit>)delegate
		{
			OnShowMyPicture();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_controllPanelButton), (Action<Unit>)delegate
		{
			OnControllPanel();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_rebootButton), (Action<Unit>)delegate
		{
			OnReboot();
		}), ((Component)this).gameObject);
		if ((Object)(object)_shutDownButton != (Object)null)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_shutDownButton), (Action<Unit>)delegate
			{
				OnShutDown();
			}), ((Component)this).gameObject);
		}
		ResetPosition();
	}

	private void OnTitle()
	{
	}

	[AsyncStateMachine(typeof(_003COnShow_003Ed__26))]
	public UniTask OnShow()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003COnShow_003Ed__26 _003COnShow_003Ed__27 = default(_003COnShow_003Ed__26);
		_003COnShow_003Ed__27._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003COnShow_003Ed__27._003C_003E4__this = this;
		_003COnShow_003Ed__27._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003COnShow_003Ed__27._003C_003Et__builder)).Start<_003COnShow_003Ed__26>(ref _003COnShow_003Ed__27);
		return ((AsyncUniTaskMethodBuilder)(ref _003COnShow_003Ed__27._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COnHide_003Ed__27))]
	public UniTask OnHide()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003COnHide_003Ed__27 _003COnHide_003Ed__28 = default(_003COnHide_003Ed__27);
		_003COnHide_003Ed__28._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003COnHide_003Ed__28._003C_003E4__this = this;
		_003COnHide_003Ed__28._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003COnHide_003Ed__28._003C_003Et__builder)).Start<_003COnHide_003Ed__27>(ref _003COnHide_003Ed__28);
		return ((AsyncUniTaskMethodBuilder)(ref _003COnHide_003Ed__28._003C_003Et__builder)).Task;
	}

	private async void OnNewGame()
	{
		AudioManager.Instance.StopBgm();
		PostEffectManager.Instance.ResetShader();
		SingletonMonoBehaviour<Settings>.Instance.nowSaveFile = "";
		SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = false;
		AudioManager.Instance.PlaySeByType(SoundType.SE_command_execute);
		await UnityAsyncExtensions.ToUniTask(Resources.UnloadUnusedAssets(), (IProgress<float>)null, (PlayerLoopTiming)8, default(CancellationToken), false);
		SceneManager.LoadScene("WindowUITestScene");
	}

	private void OnStartGame()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.LoadData);
		UniTaskExtensions.Forget(OnHide());
	}

	private void OnControllPanel()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.ControlPanel);
		UniTaskExtensions.Forget(OnHide());
	}

	private void OnShowMyPicture()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.MyPicture);
		UniTaskExtensions.Forget(OnHide());
	}

	private async void OnReboot()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.RebootDialog);
		UniTaskExtensions.Forget(OnHide());
	}

	private void OnControllerGuide()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<ControllerGuideManager>.Instance.ForceShowGuide();
		UniTaskExtensions.Forget(OnHide());
	}

	private async void OnShutDown()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.ShutDownDialog);
		UniTaskExtensions.Forget(OnHide());
	}

	public void OnLanguageUpdated()
	{
		_newGameText.text = (_hasSaveData ? NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Newgame01, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) : NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Newgame00, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		((Component)_loadGameButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Continue, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		((Component)_myPictureButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_MyPicture, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		((Component)_controllPanelButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Config, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		((Component)_rebootButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Restart, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		((Component)_shutDownButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Shutdown, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	private void ResetPosition()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.localPosition = _defaultPosition;
	}
}
