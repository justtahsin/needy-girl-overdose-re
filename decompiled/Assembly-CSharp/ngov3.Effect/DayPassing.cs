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
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace ngov3.Effect;

public class DayPassing : MonoBehaviour, IDayPassing
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<int, bool> _003C_003E9__11_0;

		public static TweenCallback _003C_003E9__14_1;

		internal bool _003CStart_003Eb__11_0(int d)
		{
			return d < 31;
		}

		internal void _003CdayPass_003Eb__14_1()
		{
			SingletonMonoBehaviour<Poem>.Instance.CleanPoem();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CUnloadAssets_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					LoadWebcamData.DeleteAllCache();
					UniTask val = UnityAsyncExtensions.ToUniTask(Resources.UnloadUnusedAssets(), (IProgress<float>)null, (PlayerLoopTiming)8, default(CancellationToken), false);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CUnloadAssets_003Ed__17>(ref val2, ref this);
						return;
					}
				}
				else
				{
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val2)).GetResult();
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
	private struct _003CyearsPass_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public DayPassing _003C_003E4__this;

		public bool isBackObi;

		private TweenAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Expected O, but got Unknown
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			DayPassing dayPassing = _003C_003E4__this;
			try
			{
				TweenAwaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_019a;
				}
				DayPassing dayPassing2 = _003C_003E4__this;
				bool isBackObi = this.isBackObi;
				AudioManager.Instance.PlaySeByType(SoundType.SE_renewal);
				if (!dayPassing.playingAnimation)
				{
					dayPassing.playingAnimation = true;
					dayPassing.ypsequence = TweenSettingsExtensions.Join(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Append(TweenSettingsExtensions.Join(TweenSettingsExtensions.Append(TweenSettingsExtensions.Append(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
					{
						dayPassing2.DayPassingCanvas.alpha = 0.5f;
						dayPassing2.DayPassingCanvas.interactable = true;
						dayPassing2.DayPassingCanvas.blocksRaycasts = true;
						dayPassing2.Noise.weight = 0.02f;
						dayPassing2.DayView.text = NgoEx.DayText(dayPassing2._dayIndex.Value - 1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
						((Component)dayPassing2.CalendarScroll).gameObject.SetActive(false);
					}), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(dayPassing.DayPassingCanvas, 1f, 0.01f), (Ease)2)), (Tween)(object)ShortcutExtensionsTMPText.DOText(dayPassing.DayView, "????", 4f, false, (ScrambleMode)4, (string)null)), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => dayPassing2.Noise.weight), (DOSetter<float>)delegate(float x)
					{
						dayPassing2.Noise.weight = x;
					}, 1f, 0.2f), (Ease)17)), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(dayPassing.DayPassingCanvas, 0f, 0.4f), (Ease)2)), (TweenCallback)delegate
					{
						dayPassing2.endAnimationNotbackShortcuts(isBackObi);
						SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.DayIndex, 100);
					}), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => dayPassing2.Noise.weight), (DOSetter<float>)delegate(float x)
					{
						dayPassing2.Noise.weight = x;
					}, 0f, 0.2f), (Ease)18));
					val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<Sequence>(dayPassing.ypsequence));
					if (!((TweenAwaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CyearsPass_003Ed__13>(ref val, ref this);
						return;
					}
					goto IL_019a;
				}
				goto end_IL_000e;
				IL_019a:
				((TweenAwaiter)(ref val)).GetResult();
				end_IL_000e:;
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
	public CanvasGroup DayPassingCanvas;

	[SerializeField]
	private Button ClickToSkip;

	[SerializeField]
	private RectTransform ArrowImageRect;

	[SerializeField]
	private RectTransform CalendarScroll;

	[SerializeField]
	private TMP_Text DayView;

	private ReactiveProperty<int> _dayIndex;

	private ReactiveProperty<int> _dayPart;

	[SerializeField]
	private Volume Noise;

	private Sequence sequence;

	private Sequence ypsequence;

	private bool playingAnimation;

	private void Start()
	{
		_dayIndex = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex);
		_dayPart = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>((IObservable<int>)_dayIndex, (Func<int, bool>)((int d) => d < 31)), (Action<int>)delegate
		{
			dayPass(_dayIndex.Value, 0, 0);
		}), ((Component)this).gameObject);
		DayPassingCanvas.alpha = 0f;
		DayPassingCanvas.interactable = false;
		DayPassingCanvas.blocksRaycasts = false;
		Noise.weight = 0f;
	}

	private void SkipDayPass()
	{
		if (playingAnimation)
		{
			TweenExtensions.Kill((Tween)(object)sequence, true);
			endAnimation();
		}
	}

	[AsyncStateMachine(typeof(_003CyearsPass_003Ed__13))]
	public UniTask yearsPass(bool isBackObi = true)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CyearsPass_003Ed__13 _003CyearsPass_003Ed__14 = default(_003CyearsPass_003Ed__13);
		_003CyearsPass_003Ed__14._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CyearsPass_003Ed__14._003C_003E4__this = this;
		_003CyearsPass_003Ed__14.isBackObi = isBackObi;
		_003CyearsPass_003Ed__14._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CyearsPass_003Ed__14._003C_003Et__builder)).Start<_003CyearsPass_003Ed__13>(ref _003CyearsPass_003Ed__14);
		return ((AsyncUniTaskMethodBuilder)(ref _003CyearsPass_003Ed__14._003C_003Et__builder)).Task;
	}

	private void dayPass(int dayIndex, int dayPart, int previousDayPart)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		if (playingAnimation)
		{
			return;
		}
		playingAnimation = true;
		int previousDay = ((dayPart == 0) ? (dayIndex - 1) : dayIndex);
		Sequence obj = TweenSettingsExtensions.Append(TweenSettingsExtensions.Append(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
		{
			DayPassingCanvas.alpha = 1f;
			DayPassingCanvas.interactable = true;
			DayPassingCanvas.blocksRaycasts = true;
			Noise.weight = 0.02f;
			DayView.text = NgoEx.DayText(previousDay, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			AudioManager.Instance.PlaySeByType(SoundType.SE_piyo);
		}), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveX((Transform)(object)CalendarScroll, -188f * (float)previousDay - 48f * (float)previousDayPart - 75.200005f, 0.0001f, true), (Ease)2)), (Tween)(object)TweenSettingsExtensions.SetRelative<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)ArrowImageRect, -28f, 0.4f, true), true));
		object obj2 = _003C_003Ec._003C_003E9__14_1;
		if (obj2 == null)
		{
			TweenCallback val = delegate
			{
				SingletonMonoBehaviour<Poem>.Instance.CleanPoem();
			};
			_003C_003Ec._003C_003E9__14_1 = val;
			obj2 = (object)val;
		}
		sequence = TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Append(TweenSettingsExtensions.Join(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(obj, (TweenCallback)obj2), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveX((Transform)(object)CalendarScroll, -188f * (float)dayIndex - 48f * (float)dayPart - 75.200005f, 0.4f, true), (Ease)4)), (TweenCallback)delegate
		{
			DayView.text = NgoEx.DayText(dayIndex, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			AudioManager.Instance.PlaySeByType(SoundType.SE_Notification);
		}), (TweenCallback)delegate
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			UniTaskExtensions.Forget(UnloadAssets());
		}), 0.9f), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => Noise.weight), (DOSetter<float>)delegate(float x)
		{
			Noise.weight = x;
		}, 1f, 0.2f), (Ease)17)), (Tween)(object)TweenSettingsExtensions.SetRelative<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)ArrowImageRect, 28f, 0.4f, true), (Ease)10), true)), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(DayPassingCanvas, 0f, 0.4f), (Ease)2)), (TweenCallback)delegate
		{
			endAnimation();
		}), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => Noise.weight), (DOSetter<float>)delegate(float x)
		{
			Noise.weight = x;
		}, 0f, 0.2f), (Ease)18)));
	}

	private void endAnimation(bool isBackObi = true)
	{
		playingAnimation = false;
		DayPassingCanvas.interactable = false;
		DayPassingCanvas.blocksRaycasts = false;
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) != 1)
		{
			SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: true);
		}
	}

	private void endAnimationNotbackShortcuts(bool isBackObi = true)
	{
		playingAnimation = false;
		DayPassingCanvas.interactable = false;
		DayPassingCanvas.blocksRaycasts = false;
	}

	[AsyncStateMachine(typeof(_003CUnloadAssets_003Ed__17))]
	private UniTask UnloadAssets()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_003CUnloadAssets_003Ed__17 _003CUnloadAssets_003Ed__18 = default(_003CUnloadAssets_003Ed__17);
		_003CUnloadAssets_003Ed__18._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CUnloadAssets_003Ed__18._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CUnloadAssets_003Ed__18._003C_003Et__builder)).Start<_003CUnloadAssets_003Ed__17>(ref _003CUnloadAssets_003Ed__18);
		return ((AsyncUniTaskMethodBuilder)(ref _003CUnloadAssets_003Ed__18._003C_003Et__builder)).Task;
	}
}
