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

public class Login : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CConsoleInput_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Login _003C_003E4__this;

		private CancellationToken _003Ctoken_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Login login = _003C_003E4__this;
			try
			{
				Awaiter val;
				UniTask val2;
				if (num != 0)
				{
					if (num == 1)
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0164;
					}
					((Component)login._input).gameObject.SetActive(false);
					SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
					_003Ctoken_003E5__2 = UniTaskCancellationExtensions.GetCancellationTokenOnDestroy((MonoBehaviour)(object)login);
					login._badge.SetActive(false);
					((Selectable)login._login).interactable = false;
					login._passText.maxVisibleCharacters = 0;
					val2 = UniTask.Delay(Constants.FAST, false, (PlayerLoopTiming)8, _003Ctoken_003E5__2, false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CConsoleInput_003Ed__8>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val)).GetResult();
				if (!((Object)(object)login == (Object)null))
				{
					((Component)login._placeholderText).gameObject.SetActive(false);
					val2 = DOTweenAsyncExtensions.WithCancellation((Tween)(object)TweenExtensions.Play<TweenerCore<int, int, NoOptions>>(ShortcutExtensionsTMPText.DOMaxVisibleCharacters(login._passText, 12, 3f)), _003Ctoken_003E5__2);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CConsoleInput_003Ed__8>(ref val, ref this);
						return;
					}
					goto IL_0164;
				}
				goto end_IL_000e;
				IL_0164:
				((Awaiter)(ref val)).GetResult();
				if (!((Object)(object)login == (Object)null))
				{
					DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(login._login), (Action<Unit>)delegate
					{
						SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Scenario_loop1_day0_night_AfterLogin>();
					}), ((Component)login).gameObject);
					login._badge.SetActive(true);
					((Selectable)login._login).interactable = true;
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Ctoken_003E5__2 = default(CancellationToken);
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Ctoken_003E5__2 = default(CancellationToken);
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
	private Button _login;

	[SerializeField]
	private GameObject _badge;

	[SerializeField]
	private TMP_InputField _input;

	[SerializeField]
	private TMP_Text _passText;

	[SerializeField]
	private TMP_Text _placeholderText;

	public GameObject LoginButtonObj => ((Component)_login).gameObject;

	private void Awake()
	{
		((Component)_passText).gameObject.SetActive(false);
		((Component)_placeholderText).gameObject.SetActive(false);
		SteamInput();
	}

	[AsyncStateMachine(typeof(_003CConsoleInput_003Ed__8))]
	private UniTask ConsoleInput()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CConsoleInput_003Ed__8 _003CConsoleInput_003Ed__9 = default(_003CConsoleInput_003Ed__8);
		_003CConsoleInput_003Ed__9._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CConsoleInput_003Ed__9._003C_003E4__this = this;
		_003CConsoleInput_003Ed__9._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CConsoleInput_003Ed__9._003C_003Et__builder)).Start<_003CConsoleInput_003Ed__8>(ref _003CConsoleInput_003Ed__9);
		return ((AsyncUniTaskMethodBuilder)(ref _003CConsoleInput_003Ed__9._003C_003Et__builder)).Task;
	}

	private void SteamInput()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<string>(ObserveExtensions.ObserveEveryValueChanged<TMP_InputField, string>(_input, (Func<TMP_InputField, string>)((TMP_InputField _input) => _input.text), (FrameCountType)0, false), (Action<string>)delegate(string text)
		{
			couldLogin(text);
		}), ((Component)this).gameObject);
		SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
		_badge.SetActive(false);
		((Selectable)_login).interactable = false;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_login), (Action<Unit>)delegate
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Scenario_loop1_day0_night_AfterLogin>();
		}), ((Component)this).gameObject);
	}

	private void couldLogin(string text)
	{
		if (text == "angelkawaii2" || text == "angelikawaii2")
		{
			_badge.SetActive(true);
			((Selectable)_login).interactable = true;
		}
		else
		{
			_badge.SetActive(false);
			((Selectable)_login).interactable = false;
		}
	}
}
