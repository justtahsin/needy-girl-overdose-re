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

namespace ngov3.Effect;

public class DayPassing2D : MonoBehaviour, IDayPassing
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<int, bool> _003C_003E9__13_0;

		public static TweenCallback _003C_003E9__16_1;

		internal bool _003CStart_003Eb__13_0(int d)
		{
			return d < 31;
		}

		internal void _003CdayPass_003Eb__16_1()
		{
			SingletonMonoBehaviour<Poem>.Instance.CleanPoem();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStart_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public DayPassing2D _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			DayPassing2D CS_0024_003C_003E8__locals13 = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					CS_0024_003C_003E8__locals13._dayIndex = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex);
					CS_0024_003C_003E8__locals13._dayPart = SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart);
					((Component)CS_0024_003C_003E8__locals13._heartSprite).gameObject.SetActive(false);
					CS_0024_003C_003E8__locals13._spriteFader.Alpha = 1f;
					CS_0024_003C_003E8__locals13._tmpFader.Alpha = 0f;
					CS_0024_003C_003E8__locals13.Noise.weight = 0f;
					CS_0024_003C_003E8__locals13._raycastBlocker.SetActive(true);
					UniTask val = UniTask.DelayFrame(5, (PlayerLoopTiming)8, default(CancellationToken), false);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStart_003Ed__13>(ref val2, ref this);
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
				CS_0024_003C_003E8__locals13._tmpFader.Alpha = 1f;
				((Component)CS_0024_003C_003E8__locals13._heartSprite).gameObject.SetActive(true);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>((IObservable<int>)CS_0024_003C_003E8__locals13._dayIndex, (Func<int, bool>)((int d) => d < 31)), (Action<int>)delegate
				{
					CS_0024_003C_003E8__locals13.dayPass(CS_0024_003C_003E8__locals13._dayIndex.Value, 0, 0);
				}), ((Component)CS_0024_003C_003E8__locals13).gameObject);
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
	private struct _003CyearsPass_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public DayPassing2D _003C_003E4__this;

		public bool isBackObi;

		private TweenAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Expected O, but got Unknown
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			DayPassing2D dayPassing2D = _003C_003E4__this;
			try
			{
				TweenAwaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0222;
				}
				DayPassing2D dayPassing2D2 = _003C_003E4__this;
				bool isBackObi = this.isBackObi;
				AudioManager.Instance.PlaySeByType(SoundType.SE_renewal);
				if (!dayPassing2D.playingAnimation)
				{
					dayPassing2D.playingAnimation = true;
					dayPassing2D.ypsequence = TweenSettingsExtensions.Join(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Join(TweenSettingsExtensions.Append(TweenSettingsExtensions.Join(TweenSettingsExtensions.Append(TweenSettingsExtensions.Join(TweenSettingsExtensions.Append(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
					{
						dayPassing2D2._spriteFader.Alpha = 0.5f;
						dayPassing2D2._tmpFader.Alpha = 0.5f;
						dayPassing2D2._raycastBlocker.SetActive(true);
						dayPassing2D2.Noise.weight = 0.02f;
						dayPassing2D2.DayView.text = NgoEx.DayText(dayPassing2D2._dayIndex.Value - 1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
						((Component)dayPassing2D2.CalendarScroll).gameObject.SetActive(false);
					}), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => dayPassing2D2._spriteFader.Alpha), (DOSetter<float>)delegate(float x)
					{
						dayPassing2D2._spriteFader.Alpha = x;
					}, 1f, 0.01f), (Ease)2)), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => dayPassing2D2._tmpFader.Alpha), (DOSetter<float>)delegate(float x)
					{
						dayPassing2D2._tmpFader.Alpha = x;
					}, 1f, 0.01f), (Ease)2)), (Tween)(object)ShortcutExtensionsTMPText.DOText(dayPassing2D.DayView, "????", 4f, false, (ScrambleMode)4, (string)null)), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => dayPassing2D2.Noise.weight), (DOSetter<float>)delegate(float x)
					{
						dayPassing2D2.Noise.weight = x;
					}, 1f, 0.2f), (Ease)17)), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => dayPassing2D2._spriteFader.Alpha), (DOSetter<float>)delegate(float x)
					{
						dayPassing2D2._spriteFader.Alpha = x;
					}, 0f, 0.4f), (Ease)2)), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => dayPassing2D2._tmpFader.Alpha), (DOSetter<float>)delegate(float x)
					{
						dayPassing2D2._tmpFader.Alpha = x;
					}, 0f, 0.4f), (Ease)2)), (TweenCallback)delegate
					{
						dayPassing2D2.endAnimationNotbackShortcuts(isBackObi);
						SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.DayIndex, 100);
					}), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => dayPassing2D2.Noise.weight), (DOSetter<float>)delegate(float x)
					{
						dayPassing2D2.Noise.weight = x;
					}, 0f, 0.2f), (Ease)18));
					val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<Sequence>(dayPassing2D.ypsequence));
					if (!((TweenAwaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CyearsPass_003Ed__15>(ref val, ref this);
						return;
					}
					goto IL_0222;
				}
				goto end_IL_000e;
				IL_0222:
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
	private SpriteRenderersFader _spriteFader;

	[SerializeField]
	private TMPTextsFader _tmpFader;

	[SerializeField]
	private GameObject _raycastBlocker;

	[SerializeField]
	private RectTransform ArrowImageRect;

	[SerializeField]
	private RectTransform CalendarScroll;

	[SerializeField]
	private TMP_Text DayView;

	[SerializeField]
	private SpriteRenderer _heartSprite;

	private ReactiveProperty<int> _dayIndex;

	private ReactiveProperty<int> _dayPart;

	[SerializeField]
	private Volume Noise;

	private Sequence sequence;

	private Sequence ypsequence;

	private bool playingAnimation;

	[AsyncStateMachine(typeof(_003CStart_003Ed__13))]
	private UniTask Start()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CStart_003Ed__13 _003CStart_003Ed__14 = default(_003CStart_003Ed__13);
		_003CStart_003Ed__14._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CStart_003Ed__14._003C_003E4__this = this;
		_003CStart_003Ed__14._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CStart_003Ed__14._003C_003Et__builder)).Start<_003CStart_003Ed__13>(ref _003CStart_003Ed__14);
		return ((AsyncUniTaskMethodBuilder)(ref _003CStart_003Ed__14._003C_003Et__builder)).Task;
	}

	private void SkipDayPass()
	{
		if (playingAnimation)
		{
			TweenExtensions.Kill((Tween)(object)sequence, true);
			endAnimation();
		}
	}

	[AsyncStateMachine(typeof(_003CyearsPass_003Ed__15))]
	public UniTask yearsPass(bool isBackObi = true)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CyearsPass_003Ed__15 _003CyearsPass_003Ed__16 = default(_003CyearsPass_003Ed__15);
		_003CyearsPass_003Ed__16._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CyearsPass_003Ed__16._003C_003E4__this = this;
		_003CyearsPass_003Ed__16.isBackObi = isBackObi;
		_003CyearsPass_003Ed__16._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CyearsPass_003Ed__16._003C_003Et__builder)).Start<_003CyearsPass_003Ed__15>(ref _003CyearsPass_003Ed__16);
		return ((AsyncUniTaskMethodBuilder)(ref _003CyearsPass_003Ed__16._003C_003Et__builder)).Task;
	}

	private void dayPass(int dayIndex, int dayPart, int previousDayPart)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
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
			_spriteFader.Alpha = 1f;
			_tmpFader.Alpha = 1f;
			_raycastBlocker.SetActive(true);
			Noise.weight = 0.02f;
			DayView.text = NgoEx.DayText(previousDay, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			AudioManager.Instance.PlaySeByType(SoundType.SE_piyo);
		}), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveX((Transform)(object)CalendarScroll, -188f * (float)previousDay - 48f * (float)previousDayPart - 75.200005f, 0.0001f, true), (Ease)2)), (Tween)(object)TweenSettingsExtensions.SetRelative<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)ArrowImageRect, -28f, 0.4f, true), true));
		object obj2 = _003C_003Ec._003C_003E9__16_1;
		if (obj2 == null)
		{
			TweenCallback val = delegate
			{
				SingletonMonoBehaviour<Poem>.Instance.CleanPoem();
			};
			_003C_003Ec._003C_003E9__16_1 = val;
			obj2 = (object)val;
		}
		sequence = TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Join(TweenSettingsExtensions.Append(TweenSettingsExtensions.Join(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.AppendCallback(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(obj, (TweenCallback)obj2), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveX((Transform)(object)CalendarScroll, -188f * (float)dayIndex - 48f * (float)dayPart - 75.200005f, 0.4f, true), (Ease)4)), (TweenCallback)delegate
		{
			DayView.text = NgoEx.DayText(dayIndex, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			AudioManager.Instance.PlaySeByType(SoundType.SE_Notification);
		}), (TweenCallback)delegate
		{
			UnloadAssets();
		}), 0.9f), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => Noise.weight), (DOSetter<float>)delegate(float x)
		{
			Noise.weight = x;
		}, 1f, 0.2f), (Ease)17)), (Tween)(object)TweenSettingsExtensions.SetRelative<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)ArrowImageRect, 28f, 0.4f, true), (Ease)10), true)), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => _spriteFader.Alpha), (DOSetter<float>)delegate(float x)
		{
			_spriteFader.Alpha = x;
		}, 0f, 0.4f), (Ease)2)), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => _tmpFader.Alpha), (DOSetter<float>)delegate(float x)
		{
			_tmpFader.Alpha = x;
		}, 0f, 0.4f), (Ease)2)), (TweenCallback)delegate
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
		_raycastBlocker.SetActive(false);
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) != 1)
		{
			SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: true);
		}
	}

	private void endAnimationNotbackShortcuts(bool isBackObi = true)
	{
		playingAnimation = false;
		_raycastBlocker.SetActive(false);
	}

	private void UnloadAssets()
	{
		LoadWebcamData.DeleteAllCache();
	}
}
