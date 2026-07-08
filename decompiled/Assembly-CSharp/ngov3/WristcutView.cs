using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public sealed class WristcutView : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003COnCompleted_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public WristcutView _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			WristcutView wristcutView = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					UniTask val = UniTask.Delay(80, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnCompleted_003Ed__14>(ref val2, ref this);
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
				TweenExtensions.Kill((Tween)(object)wristcutView._barMove, false);
				wristcutView._onGoButton.OnCompleted();
				wristcutView._finishButton.OnCommand();
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
	private float _targetY;

	[SerializeField]
	private Image _kizuPrefab;

	[SerializeField]
	private Image _bar;

	[SerializeField]
	public Button _goButton;

	[SerializeField]
	private TMP_Text _goButtonT;

	public ActionButton _finishButton;

	[SerializeField]
	private RectTransform _root;

	private Subject<Cut> _onGoButton = new Subject<Cut>();

	private Sequence _barMove;

	public IObservable<Cut> OnGoButton => (IObservable<Cut>)_onGoButton;

	public void OnStartGame(int day, int cutCount)
	{
		_goButtonT.text = NgoEx.SystemTextFromType(SystemTextType.WristGO, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		MoveBar();
		_ = cutCount;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(Observable.Take<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_goButton), cutCount), (Action<Unit>)delegate
		{
			OnGo(day);
			cutCount--;
			_goButtonT.text = cutCount.ToString();
		}, (Action)delegate
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			OnGo(day);
			UniTaskExtensions.Forget(OnCompleted());
		}), ((Component)this).gameObject);
	}

	private void MoveBar()
	{
		_barMove = TweenExtensions.Play<Sequence>(TweenSettingsExtensions.SetLoops<Sequence>(TweenSettingsExtensions.SetRelative<Sequence>(TweenSettingsExtensions.SetEase<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.Append(DOTween.Sequence(), (Tween)(object)DOTweenModuleUI.DOAnchorPosY(((Graphic)_bar).rectTransform, _targetY, 3f, true)), (Tween)(object)DOTweenModuleUI.DOAnchorPosY(((Graphic)_bar).rectTransform, 0f - _targetY, 3f, true)), (Ease)1)), -1));
	}

	public void OnGo(int dayIndex)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		_onGoButton.OnNext(new Cut
		{
			DayIndex = dayIndex,
			Position = ((Graphic)_bar).rectTransform.anchoredPosition
		});
		((Graphic)Object.Instantiate<Image>(_kizuPrefab, (Transform)(object)_root)).rectTransform.anchoredPosition = ((Graphic)_bar).rectTransform.anchoredPosition;
	}

	[AsyncStateMachine(typeof(_003COnCompleted_003Ed__14))]
	public UniTask OnCompleted()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003COnCompleted_003Ed__14 _003COnCompleted_003Ed__15 = default(_003COnCompleted_003Ed__14);
		_003COnCompleted_003Ed__15._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003COnCompleted_003Ed__15._003C_003E4__this = this;
		_003COnCompleted_003Ed__15._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003COnCompleted_003Ed__15._003C_003Et__builder)).Start<_003COnCompleted_003Ed__14>(ref _003COnCompleted_003Ed__15);
		return ((AsyncUniTaskMethodBuilder)(ref _003COnCompleted_003Ed__15._003C_003Et__builder)).Task;
	}
}
