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
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ResultCover : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static TweenCallback _003C_003E9__7_1;

		internal void _003CStartResult_003Eb__7_1()
		{
			IWindow w = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.TaskManagerforResult);
			SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(w);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CEndResult_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public ResultCover _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private TweenAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			ResultCover resultCover = _003C_003E4__this;
			try
			{
				UniTask val3;
				Awaiter val2;
				TweenAwaiter val;
				switch (num)
				{
				default:
					val3 = SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
					val2 = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CEndResult_003Ed__8>(ref val2, ref this);
						return;
					}
					goto IL_007b;
				case 0:
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_007b;
				case 1:
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00ea;
				case 2:
					{
						val = _003C_003Eu__2;
						_003C_003Eu__2 = default(TweenAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00ea:
					((Awaiter)(ref val2)).GetResult();
					resultCover._cover.interactable = false;
					resultCover._cover.blocksRaycasts = false;
					val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(resultCover._cover, 0f, 0.1f)));
					if (!((TweenAwaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CEndResult_003Ed__8>(ref val, ref this);
						return;
					}
					break;
					IL_007b:
					((Awaiter)(ref val2)).GetResult();
					val3 = UniTask.Delay(800, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val2 = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CEndResult_003Ed__8>(ref val2, ref this);
						return;
					}
					goto IL_00ea;
				}
				((TweenAwaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<WindowManager>.Instance.Close(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.TaskManagerforResult));
				SingletonMonoBehaviour<EventManager>.Instance.isResulting.Value = false;
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
	private CanvasGroup _cover;

	[SerializeField]
	private RectTransform _obi;

	[SerializeField]
	private Button _next;

	[SerializeField]
	private TMP_Text _buttonLabel;

	[SerializeField]
	private TMP_Text _message;

	private Sequence sequence;

	public void Awake()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_next), (Action<Unit>)delegate
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			EndResult();
		}), (Component)(object)_next);
	}

	public void StartResult(string message)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		SingletonMonoBehaviour<EventManager>.Instance.isResulting.Value = true;
		Sequence obj = TweenSettingsExtensions.Append(TweenSettingsExtensions.Append(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
		{
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			_cover.alpha = 0f;
			_cover.interactable = true;
			_cover.blocksRaycasts = true;
			((Transform)_obi).localPosition = new Vector3(0f, 0f, 0f);
			((Component)_next).transform.localPosition = new Vector3(720f, 0f, 0f);
			((Component)_cover).gameObject.transform.SetAsLastSibling();
			_message.text = message;
		}), (Tween)(object)DOTweenModuleUI.DOFade(_cover, 1f, 0.4f)), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)_obi, 980f, 0.4f, true), (Ease)31));
		object obj2 = _003C_003Ec._003C_003E9__7_1;
		if (obj2 == null)
		{
			TweenCallback val = delegate
			{
				IWindow w = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.TaskManagerforResult);
				SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(w);
			};
			_003C_003Ec._003C_003E9__7_1 = val;
			obj2 = (object)val;
		}
		TweenExtensions.Play<Sequence>(TweenSettingsExtensions.OnComplete<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(obj, (TweenCallback)obj2), (Tween)(object)ShortcutExtensions.DOLocalMoveY(((Component)_next).transform, 160f, 0.4f, true)), (TweenCallback)delegate
		{
			_cover.interactable = true;
		}));
	}

	[AsyncStateMachine(typeof(_003CEndResult_003Ed__8))]
	public UniTask EndResult()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CEndResult_003Ed__8 _003CEndResult_003Ed__9 = default(_003CEndResult_003Ed__8);
		_003CEndResult_003Ed__9._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CEndResult_003Ed__9._003C_003E4__this = this;
		_003CEndResult_003Ed__9._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CEndResult_003Ed__9._003C_003Et__builder)).Start<_003CEndResult_003Ed__8>(ref _003CEndResult_003Ed__9);
		return ((AsyncUniTaskMethodBuilder)(ref _003CEndResult_003Ed__9._003C_003Et__builder)).Task;
	}
}
