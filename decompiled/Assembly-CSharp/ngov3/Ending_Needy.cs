using System;
using System.Collections.Generic;
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
using UniRx;
using UnityEngine;

namespace ngov3;

public class Ending_Needy : NgoEvent
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public Ending_Needy _003C_003E4__this;

		public string answerTitle;

		public CancellationToken token;

		internal async void _003COnDatePlaceAsync_003Eb__0(CollectionAddEvent<JineData> sentdata)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			_003C_003E4__this._disposable.Dispose();
			if (sentdata.Value.freeMessage != answerTitle)
			{
				if (string.IsNullOrEmpty(answerTitle) || answerTitle == NgoEx.CmdName(CmdType.OdekakeZikka, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value))
				{
					await UniTask.Delay(1000, false, (PlayerLoopTiming)8, token, false);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE014);
					await UniTask.Delay(1000, false, (PlayerLoopTiming)8, token, false);
				}
				await _003C_003E4__this.DieByNeedyEvent(token);
			}
			else
			{
				await _003C_003E4__this.OnSexCountAsync(token);
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public Ending_Needy _003C_003E4__this;

		public List<JineType> resList;

		public CancellationToken token;

		internal async void _003COnSexCountAsync_003Eb__0(CollectionAddEvent<JineData> sentdata)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			_003C_003E4__this._disposable.Dispose();
			JineType id = sentdata.Value.id;
			int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.MadeLoveCounter);
			int num = resList.IndexOf(id) + 1;
			if (status != num)
			{
				if (status == 0)
				{
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE009);
					await UniTask.Delay(Constants.MIDDLE, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE013);
					await UniTask.Delay(Constants.SLOW, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					await _003C_003E4__this.DieByNeedyEvent(token, isFocused: true);
				}
				else
				{
					await _003C_003E4__this.DieByNeedyEvent(token);
				}
			}
			else
			{
				await _003C_003E4__this.OnLonglineAsync(token);
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public Ending_Needy _003C_003E4__this;

		public List<JineType> resList;

		public int answerIndex;

		public CancellationToken token;

		internal async void _003COnLonglineAsync_003Eb__0(CollectionAddEvent<JineData> sentdata)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			_003C_003E4__this._disposable.Dispose();
			if (resList.IndexOf(sentdata.Value.id) != answerIndex)
			{
				await _003C_003E4__this.DieByNeedyEvent(token);
			}
			else
			{
				await _003C_003E4__this.LongMessageAsync(token);
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public Ending_Needy _003C_003E4__this;

		public CancellationTokenSource tokenSource;

		public List<JineType> resList;

		public CancellationToken token;

		internal async void _003CConsumerLongMessageAsync_003Eb__0(CollectionAddEvent<JineData> sentdata)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			_003C_003E4__this._disposable.Dispose();
			tokenSource.Cancel();
			tokenSource.Dispose();
			resList.IndexOf(sentdata.Value.id);
			if (sentdata.Value.id == JineType.Ending_Kyouizon_JINE006_Option3)
			{
				await _003C_003E4__this.AliveRoute();
			}
			else
			{
				await _003C_003E4__this.DieByNeedyEvent(token);
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public Ending_Needy _003C_003E4__this;

		public CancellationToken token;

		internal async void _003CLongMessageAsync_003Eb__0(string n)
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, n));
			_003C_003E4__this._disposable2.Dispose();
			bool checkLength = n.Length >= 100;
			bool checkNotCopyAndPaste = true;
			bool checkHasAme = n.Contains("あめ") || n.Contains("Ame") || n.Contains("糖糖") || n.Contains("아메") || n.Contains(NgoEx.SystemTextFromType(SystemTextType.Tooltip_Ame, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
			await UniTask.Delay(3500, false, (PlayerLoopTiming)8, token, false);
			if (checkLength && checkNotCopyAndPaste && checkHasAme)
			{
				await _003C_003E4__this.AliveRoute();
			}
			else
			{
				await _003C_003E4__this.DieByNeedyEvent(token);
			}
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CAliveRoute_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Needy _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Needy ending_Needy = _003C_003E4__this;
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
						goto IL_00f8;
					}
					PostEffectManager.Instance.ResetShaderCalmly();
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
					ending_Needy._isShaderActivate = false;
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE007);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAliveRoute_003Ed__19>(ref val, ref this);
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
				val2 = NgoEvent.DelaySkippable(Constants.MIDDLE);
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAliveRoute_003Ed__19>(ref val, ref this);
					return;
				}
				goto IL_00f8;
				IL_00f8:
				((Awaiter)(ref val)).GetResult();
				IWindow w = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.AsobuNeedy);
				SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(w);
				ending_Needy.endEvent();
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
	private struct _003CConsumerLongMessageAsync_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Needy _003C_003E4__this;

		public CancellationToken token;

		private _003C_003Ec__DisplayClass17_0 _003C_003E8__1;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Needy ending_Needy = _003C_003E4__this;
			try
			{
				Awaiter val3;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass17_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.token = token;
					_003C_003E8__1.resList = new List<JineType>
					{
						JineType.Ending_Kyouizon_JINE006_Option1,
						JineType.Ending_Kyouizon_JINE006_Option2,
						JineType.Ending_Kyouizon_JINE006_Option3,
						JineType.Ending_Kyouizon_JINE006_Option4,
						JineType.Ending_Kyouizon_JINE006_Option5
					};
					_003C_003E8__1.tokenSource = new CancellationTokenSource();
					UniTaskVoid val = ending_Needy.OnTimeOutAsync(_003C_003E8__1.tokenSource.Token);
					((UniTaskVoid)(ref val)).Forget();
					UniTask val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE006);
					val3 = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val3)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val3;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CConsumerLongMessageAsync_003Ed__17>(ref val3, ref this);
						return;
					}
				}
				else
				{
					val3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val3)).GetResult();
				AudioManager.Instance.PlaySeByType(SoundType.SE_heartbeat);
				SingletonMonoBehaviour<JineManager>.Instance.StartOption(_003C_003E8__1.resList);
				ending_Needy._disposable = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Action<CollectionAddEvent<JineData>>)async delegate(CollectionAddEvent<JineData> sentdata)
				{
					//IL_0016: Unknown result type (might be due to invalid IL or missing references)
					//IL_0017: Unknown result type (might be due to invalid IL or missing references)
					_003C_003E8__1._003C_003E4__this._disposable.Dispose();
					_003C_003E8__1.tokenSource.Cancel();
					_003C_003E8__1.tokenSource.Dispose();
					_003C_003E8__1.resList.IndexOf(sentdata.Value.id);
					if (sentdata.Value.id == JineType.Ending_Kyouizon_JINE006_Option3)
					{
						await _003C_003E8__1._003C_003E4__this.AliveRoute();
					}
					else
					{
						await _003C_003E8__1._003C_003E4__this.DieByNeedyEvent(_003C_003E8__1.token);
					}
				}), (ICollection<IDisposable>)ending_Needy.compositeDisposable);
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
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
	private struct _003CDieByNeedyEvent_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Needy _003C_003E4__this;

		public bool isFocused;

		private RectTransform _003CMainCanvas_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0390: Unknown result type (might be due to invalid IL or missing references)
			//IL_0395: Unknown result type (might be due to invalid IL or missing references)
			//IL_039c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0329: Unknown result type (might be due to invalid IL or missing references)
			//IL_0358: Unknown result type (might be due to invalid IL or missing references)
			//IL_035d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0360: Unknown result type (might be due to invalid IL or missing references)
			//IL_0365: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Unknown result type (might be due to invalid IL or missing references)
			//IL_037a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Needy ending_Needy = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					val2 = ending_Needy.GetNeedieList(isFocused);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CDieByNeedyEvent_003Ed__23>(ref val, ref this);
						return;
					}
					goto IL_0089;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0089;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_013b;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01f6;
				case 3:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0278;
				case 4:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02ff;
				case 5:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_01f6:
					((Awaiter)(ref val)).GetResult();
					ending_Needy._isShaderActivate = false;
					ending_Needy._KyouizonEndAnimation.SetActive(true);
					val2 = UniTask.Delay(1500, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CDieByNeedyEvent_003Ed__23>(ref val, ref this);
						return;
					}
					goto IL_0278;
					IL_0089:
					((Awaiter)(ref val)).GetResult();
					_003CMainCanvas_003E5__2 = GameObject.Find("MainPanel").GetComponent<RectTransform>();
					ending_Needy._KyouizonEndAnimation = ((Component)GameObject.Find("EndingCover").transform.Find("KyouizonEndAnimation")).gameObject;
					AudioManager.Instance.StopAll();
					val2 = UniTask.Delay(2500, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CDieByNeedyEvent_003Ed__23>(ref val, ref this);
						return;
					}
					goto IL_013b;
					IL_02ff:
					((Awaiter)(ref val)).GetResult();
					AudioManager.Instance.PlaySeByType(SoundType.SE_bugo);
					TweenExtensions.Play<TweenerCore<Quaternion, Vector3, QuaternionOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Quaternion, Vector3, QuaternionOptions>>(ShortcutExtensions.DORotate((Transform)(object)_003CMainCanvas_003E5__2, new Vector3(0f, 0f, 2.4f), 1f, (RotateMode)0), (Ease)30));
					val2 = UniTask.Delay(4000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CDieByNeedyEvent_003Ed__23>(ref val, ref this);
						return;
					}
					break;
					IL_013b:
					((Awaiter)(ref val)).GetResult();
					AudioManager.Instance.PlaySeByType(SoundType.SE_zugozugozugo);
					TweenExtensions.Play<Tweener>(ShortcutExtensions.DOPunchPosition((Transform)(object)_003CMainCanvas_003E5__2, new Vector3(20f, 20f, 0f), 2f, 10, 1f, true));
					PostEffectManager.Instance.SetShader(EffectType.Bleeding);
					val2 = UniTask.Delay(2000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CDieByNeedyEvent_003Ed__23>(ref val, ref this);
						return;
					}
					goto IL_01f6;
					IL_0278:
					((Awaiter)(ref val)).GetResult();
					PostEffectManager.Instance.ResetShader();
					AudioManager.Instance.PlaySeByType(SoundType.SE_zubasi);
					val2 = UniTask.Delay(2000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CDieByNeedyEvent_003Ed__23>(ref val, ref this);
						return;
					}
					goto IL_02ff;
				}
				((Awaiter)(ref val)).GetResult();
				AchievementStatsUpdater.UpdateStats("Ending_Needy");
				SingletonMonoBehaviour<EventManager>.Instance.CallEnding();
				ending_Needy.endEvent();
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003CMainCanvas_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CMainCanvas_003E5__2 = null;
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
	private struct _003CGetNeedieList_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public bool isFocused;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_027c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_0373: Unknown result type (might be due to invalid IL or missing references)
			//IL_0378: Unknown result type (might be due to invalid IL or missing references)
			//IL_037f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_046f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0474: Unknown result type (might be due to invalid IL or missing references)
			//IL_047b: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_056c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0571: Unknown result type (might be due to invalid IL or missing references)
			//IL_0578: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_063c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0641: Unknown result type (might be due to invalid IL or missing references)
			//IL_0648: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_070c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0711: Unknown result type (might be due to invalid IL or missing references)
			//IL_0718: Unknown result type (might be due to invalid IL or missing references)
			//IL_0774: Unknown result type (might be due to invalid IL or missing references)
			//IL_0779: Unknown result type (might be due to invalid IL or missing references)
			//IL_0780: Unknown result type (might be due to invalid IL or missing references)
			//IL_07dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_07e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_07e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0844: Unknown result type (might be due to invalid IL or missing references)
			//IL_0849: Unknown result type (might be due to invalid IL or missing references)
			//IL_0850: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_08b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0914: Unknown result type (might be due to invalid IL or missing references)
			//IL_0919: Unknown result type (might be due to invalid IL or missing references)
			//IL_0920: Unknown result type (might be due to invalid IL or missing references)
			//IL_097c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0981: Unknown result type (might be due to invalid IL or missing references)
			//IL_0988: Unknown result type (might be due to invalid IL or missing references)
			//IL_09e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_09e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_09f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a53: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a58: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a5f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0abb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ac0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ac7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b2a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b2f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b36: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b92: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b97: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b9e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c01: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c06: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c0d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c69: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c6e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c75: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cd8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cdd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ce4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d3d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d42: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d49: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0321: Unknown result type (might be due to invalid IL or missing references)
			//IL_0338: Unknown result type (might be due to invalid IL or missing references)
			//IL_033d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0340: Unknown result type (might be due to invalid IL or missing references)
			//IL_0345: Unknown result type (might be due to invalid IL or missing references)
			//IL_039f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03be: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_041d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0434: Unknown result type (might be due to invalid IL or missing references)
			//IL_0439: Unknown result type (might be due to invalid IL or missing references)
			//IL_043c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0441: Unknown result type (might be due to invalid IL or missing references)
			//IL_049b: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0519: Unknown result type (might be due to invalid IL or missing references)
			//IL_0530: Unknown result type (might be due to invalid IL or missing references)
			//IL_0535: Unknown result type (might be due to invalid IL or missing references)
			//IL_0538: Unknown result type (might be due to invalid IL or missing references)
			//IL_053d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0598: Unknown result type (might be due to invalid IL or missing references)
			//IL_059d: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0600: Unknown result type (might be due to invalid IL or missing references)
			//IL_0605: Unknown result type (might be due to invalid IL or missing references)
			//IL_0608: Unknown result type (might be due to invalid IL or missing references)
			//IL_060d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0668: Unknown result type (might be due to invalid IL or missing references)
			//IL_066d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0670: Unknown result type (might be due to invalid IL or missing references)
			//IL_0675: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0738: Unknown result type (might be due to invalid IL or missing references)
			//IL_073d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0740: Unknown result type (might be due to invalid IL or missing references)
			//IL_0745: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0808: Unknown result type (might be due to invalid IL or missing references)
			//IL_080d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0810: Unknown result type (might be due to invalid IL or missing references)
			//IL_0815: Unknown result type (might be due to invalid IL or missing references)
			//IL_0870: Unknown result type (might be due to invalid IL or missing references)
			//IL_0875: Unknown result type (might be due to invalid IL or missing references)
			//IL_0878: Unknown result type (might be due to invalid IL or missing references)
			//IL_087d: Unknown result type (might be due to invalid IL or missing references)
			//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_08dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_08e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_08e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0940: Unknown result type (might be due to invalid IL or missing references)
			//IL_0945: Unknown result type (might be due to invalid IL or missing references)
			//IL_0948: Unknown result type (might be due to invalid IL or missing references)
			//IL_094d: Unknown result type (might be due to invalid IL or missing references)
			//IL_09a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_09b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a17: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a1c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a1f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a24: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a7f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a84: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a87: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a8c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0aee: Unknown result type (might be due to invalid IL or missing references)
			//IL_0af3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0af6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0afb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b56: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b5b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b5e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b63: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bc5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bcd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bd2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c2d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c32: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c35: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c3a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c9c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ca1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ca4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ca9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d04: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d09: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d0c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d11: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_025e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02db: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0359: Unknown result type (might be due to invalid IL or missing references)
			//IL_035a: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0455: Unknown result type (might be due to invalid IL or missing references)
			//IL_0456: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0552: Unknown result type (might be due to invalid IL or missing references)
			//IL_0553: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_05bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0622: Unknown result type (might be due to invalid IL or missing references)
			//IL_0623: Unknown result type (might be due to invalid IL or missing references)
			//IL_068a: Unknown result type (might be due to invalid IL or missing references)
			//IL_068b: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_075a: Unknown result type (might be due to invalid IL or missing references)
			//IL_075b: Unknown result type (might be due to invalid IL or missing references)
			//IL_07c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_07c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_082a: Unknown result type (might be due to invalid IL or missing references)
			//IL_082b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0892: Unknown result type (might be due to invalid IL or missing references)
			//IL_0893: Unknown result type (might be due to invalid IL or missing references)
			//IL_08fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_08fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0962: Unknown result type (might be due to invalid IL or missing references)
			//IL_0963: Unknown result type (might be due to invalid IL or missing references)
			//IL_09ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_09cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a39: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a3a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0aa1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0aa2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b10: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b11: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b78: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b79: Unknown result type (might be due to invalid IL or missing references)
			//IL_0be7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0be8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c4f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c50: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cbe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cbf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d26: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d27: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					if (isFocused)
					{
						SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE010);
						val2 = UniTask.Delay(Constants.SLOW, false, (PlayerLoopTiming)8, default(CancellationToken), false);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
							return;
						}
						goto IL_0103;
					}
					SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val2 = UniTask.Delay(500, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0214;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0103;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0181;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0214;
				case 3:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0292;
				case 4:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0310;
				case 5:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_038e;
				case 6:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_040c;
				case 7:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_048a;
				case 8:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0508;
				case 9:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0587;
				case 10:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_05ef;
				case 11:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0657;
				case 12:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_06bf;
				case 13:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0727;
				case 14:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_078f;
				case 15:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_07f7;
				case 16:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_085f;
				case 17:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_08c7;
				case 18:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_092f;
				case 19:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0997;
				case 20:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_09ff;
				case 21:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0a6e;
				case 22:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0ad6;
				case 23:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0b45;
				case 24:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0bad;
				case 25:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0c1c;
				case 26:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0c84;
				case 27:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0cf3;
				case 28:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_09ff:
					((Awaiter)(ref val)).GetResult();
					val2 = UniTask.Delay(Constants.SLOW, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 21);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0a6e;
					IL_0bad:
					((Awaiter)(ref val)).GetResult();
					val2 = UniTask.Delay(Constants.SLOW, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 25);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0c1c;
					IL_0103:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE011);
					val2 = UniTask.Delay(Constants.SLOW, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0181;
					IL_0a6e:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE009);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 22);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0ad6;
					IL_0181:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE012);
					goto end_IL_0007;
					IL_0727:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 14);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_078f;
					IL_078f:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 15);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_07f7;
					IL_0214:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val2 = UniTask.Delay(500, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0292;
					IL_07f7:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 16);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_085f;
					IL_0292:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val2 = UniTask.Delay(500, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0310;
					IL_0c84:
					((Awaiter)(ref val)).GetResult();
					val2 = UniTask.Delay(Constants.SLOW, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 27);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0cf3;
					IL_0310:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val2 = UniTask.Delay(500, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_038e;
					IL_085f:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 17);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_08c7;
					IL_038e:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val2 = UniTask.Delay(300, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_040c;
					IL_0ad6:
					((Awaiter)(ref val)).GetResult();
					val2 = UniTask.Delay(Constants.FAST, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 23);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0b45;
					IL_040c:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val2 = UniTask.Delay(300, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 7);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_048a;
					IL_08c7:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 18);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_092f;
					IL_048a:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val2 = UniTask.Delay(300, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 8);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0508;
					IL_0c1c:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE011);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 26);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0c84;
					IL_0508:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val2 = UniTask.Delay(300, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 9);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0587;
					IL_092f:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 19);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0997;
					IL_0587:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 10);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_05ef;
					IL_0b45:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE010);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 24);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0bad;
					IL_05ef:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 11);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0657;
					IL_0997:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 20);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_09ff;
					IL_0657:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 12);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_06bf;
					IL_0cf3:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE012);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 28);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					break;
					IL_06bf:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 13);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGetNeedieList_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0727;
				}
				((Awaiter)(ref val)).GetResult();
				end_IL_0007:;
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
	private struct _003CLongMessageAsync_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Needy _003C_003E4__this;

		public CancellationToken token;

		private _003C_003Ec__DisplayClass18_0 _003C_003E8__1;

		private CancellationTokenSource _003CtokenSource_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Needy ending_Needy = _003C_003E4__this;
			try
			{
				Awaiter val3;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass18_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.token = token;
					_003CtokenSource_003E5__2 = new CancellationTokenSource();
					UniTaskVoid val = ending_Needy.OnTimeOutAsync(_003CtokenSource_003E5__2.Token);
					((UniTaskVoid)(ref val)).Forget();
					val = ending_Needy.OnUnFocusedGameAsync(_003CtokenSource_003E5__2.Token);
					((UniTaskVoid)(ref val)).Forget();
					UniTask val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE006);
					val3 = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val3)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val3;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CLongMessageAsync_003Ed__18>(ref val3, ref this);
						return;
					}
				}
				else
				{
					val3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val3)).GetResult();
				AudioManager.Instance.PlaySeByType(SoundType.SE_heartbeat);
				_003CtokenSource_003E5__2.Cancel();
				_003CtokenSource_003E5__2.Dispose();
				_ = GUIUtility.systemCopyBuffer;
				SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
				ending_Needy._disposable2 = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<string>((IObservable<string>)SingletonMonoBehaviour<JineManager>.Instance.Message, (Action<string>)async delegate(string n)
				{
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, n));
					_003C_003E8__1._003C_003E4__this._disposable2.Dispose();
					bool checkLength = n.Length >= 100;
					bool checkNotCopyAndPaste = true;
					bool checkHasAme = n.Contains("あめ") || n.Contains("Ame") || n.Contains("糖糖") || n.Contains("아메") || n.Contains(NgoEx.SystemTextFromType(SystemTextType.Tooltip_Ame, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
					await UniTask.Delay(3500, false, (PlayerLoopTiming)8, _003C_003E8__1.token, false);
					if (checkLength && checkNotCopyAndPaste && checkHasAme)
					{
						await _003C_003E8__1._003C_003E4__this.AliveRoute();
					}
					else
					{
						await _003C_003E8__1._003C_003E4__this.DieByNeedyEvent(_003C_003E8__1.token);
					}
				}), (ICollection<IDisposable>)ending_Needy.compositeDisposable);
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CtokenSource_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CtokenSource_003E5__2 = null;
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
	private struct _003COnDatePlaceAsync_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Needy _003C_003E4__this;

		public CancellationToken token;

		private _003C_003Ec__DisplayClass14_0 _003C_003E8__1;

		private List<string> _003CresList_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Needy ending_Needy = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass14_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.token = token;
					_003CresList_003E5__2 = NgoEx_Temp.GetOdekakeResponseList();
					CmdType firstDate = SingletonMonoBehaviour<EventManager>.Instance.FirstDate;
					if (firstDate == CmdType.None)
					{
						val2 = ending_Needy.OnSexCountAsync(_003C_003E8__1.token);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnDatePlaceAsync_003Ed__14>(ref val, ref this);
							return;
						}
						goto IL_00ce;
					}
					_003C_003E8__1.answerTitle = NgoEx.CmdName(firstDate, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
					val2 = UniTask.Delay(Constants.MIDDLE, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnDatePlaceAsync_003Ed__14>(ref val, ref this);
						return;
					}
					goto IL_0163;
				}
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00ce;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0163;
				case 2:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00ce:
					((Awaiter)(ref val)).GetResult();
					goto end_IL_000e;
					IL_0163:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE003);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnDatePlaceAsync_003Ed__14>(ref val, ref this);
						return;
					}
					break;
				}
				((Awaiter)(ref val)).GetResult();
				AudioManager.Instance.PlaySeByType(SoundType.SE_heartbeat);
				SingletonMonoBehaviour<JineManager>.Instance.StartOption(_003CresList_003E5__2);
				ending_Needy._disposable = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Action<CollectionAddEvent<JineData>>)async delegate(CollectionAddEvent<JineData> sentdata)
				{
					//IL_0016: Unknown result type (might be due to invalid IL or missing references)
					//IL_0017: Unknown result type (might be due to invalid IL or missing references)
					_003C_003E8__1._003C_003E4__this._disposable.Dispose();
					if (sentdata.Value.freeMessage != _003C_003E8__1.answerTitle)
					{
						if (string.IsNullOrEmpty(_003C_003E8__1.answerTitle) || _003C_003E8__1.answerTitle == NgoEx.CmdName(CmdType.OdekakeZikka, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value))
						{
							await UniTask.Delay(1000, false, (PlayerLoopTiming)8, _003C_003E8__1.token, false);
							await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE014);
							await UniTask.Delay(1000, false, (PlayerLoopTiming)8, _003C_003E8__1.token, false);
						}
						await _003C_003E8__1._003C_003E4__this.DieByNeedyEvent(_003C_003E8__1.token);
					}
					else
					{
						await _003C_003E8__1._003C_003E4__this.OnSexCountAsync(_003C_003E8__1.token);
					}
				}), (ICollection<IDisposable>)ending_Needy.compositeDisposable);
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CresList_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CresList_003E5__2 = null;
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
	private struct _003COnLonglineAsync_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Needy _003C_003E4__this;

		public CancellationToken token;

		private _003C_003Ec__DisplayClass16_0 _003C_003E8__1;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Needy ending_Needy = _003C_003E4__this;
			try
			{
				Awaiter val;
				switch (num)
				{
				default:
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass16_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.token = token;
					JineType trauma = SingletonMonoBehaviour<EventManager>.Instance.Trauma;
					UniTask val2;
					if (trauma == JineType.None)
					{
						val2 = ending_Needy.LongMessageAsync(_003C_003E8__1.token);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnLonglineAsync_003Ed__16>(ref val, ref this);
							return;
						}
						goto IL_00f1;
					}
					_003C_003E8__1.resList = new List<JineType>
					{
						JineType.Ending_Kyouizon_JINE005_Option1,
						JineType.Ending_Kyouizon_JINE005_Option2,
						JineType.Ending_Kyouizon_JINE005_Option3,
						JineType.Ending_Kyouizon_JINE005_Option4,
						JineType.Ending_Kyouizon_JINE005_Option5
					};
					List<JineType> list = new List<JineType>
					{
						JineType.Event_LongLINE001,
						JineType.Event_LongLINE002,
						JineType.Event_LongLINE003,
						JineType.Event_LongLINE004,
						JineType.Event_LongLINE005
					};
					_003C_003E8__1.answerIndex = list.IndexOf(trauma);
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE005);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnLonglineAsync_003Ed__16>(ref val, ref this);
						return;
					}
					break;
				}
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					((Awaiter)(ref val)).GetResult();
					goto end_IL_000e;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00f1;
				case 2:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00f1:
					((Awaiter)(ref val)).GetResult();
					goto end_IL_000e;
				}
				((Awaiter)(ref val)).GetResult();
				AudioManager.Instance.PlaySeByType(SoundType.SE_heartbeat);
				SingletonMonoBehaviour<JineManager>.Instance.StartOption(_003C_003E8__1.resList);
				ending_Needy._disposable = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Action<CollectionAddEvent<JineData>>)async delegate(CollectionAddEvent<JineData> sentdata)
				{
					//IL_0016: Unknown result type (might be due to invalid IL or missing references)
					//IL_0017: Unknown result type (might be due to invalid IL or missing references)
					_003C_003E8__1._003C_003E4__this._disposable.Dispose();
					if (_003C_003E8__1.resList.IndexOf(sentdata.Value.id) != _003C_003E8__1.answerIndex)
					{
						await _003C_003E8__1._003C_003E4__this.DieByNeedyEvent(_003C_003E8__1.token);
					}
					else
					{
						await _003C_003E8__1._003C_003E4__this.LongMessageAsync(_003C_003E8__1.token);
					}
				}), (ICollection<IDisposable>)ending_Needy.compositeDisposable);
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
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
	private struct _003COnSexCountAsync_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Needy _003C_003E4__this;

		public CancellationToken token;

		private _003C_003Ec__DisplayClass15_0 _003C_003E8__1;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Needy ending_Needy = _003C_003E4__this;
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
						goto IL_0186;
					}
					_003C_003E8__1 = new _003C_003Ec__DisplayClass15_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.token = token;
					_003C_003E8__1.resList = new List<JineType>
					{
						JineType.Ending_Kyouizon_JINE004_Option1,
						JineType.Ending_Kyouizon_JINE004_Option2,
						JineType.Ending_Kyouizon_JINE004_Option3,
						JineType.Ending_Kyouizon_JINE004_Option4,
						JineType.Ending_Kyouizon_JINE004_Option5
					};
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, _003C_003E8__1.token, false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnSexCountAsync_003Ed__15>(ref val, ref this);
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
				SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE004);
				AudioManager.Instance.PlaySeByType(SoundType.SE_heartbeat);
				val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, _003C_003E8__1.token, false);
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnSexCountAsync_003Ed__15>(ref val, ref this);
					return;
				}
				goto IL_0186;
				IL_0186:
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<JineManager>.Instance.StartOption(_003C_003E8__1.resList);
				ending_Needy._disposable = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Action<CollectionAddEvent<JineData>>)async delegate(CollectionAddEvent<JineData> sentdata)
				{
					//IL_0016: Unknown result type (might be due to invalid IL or missing references)
					//IL_0017: Unknown result type (might be due to invalid IL or missing references)
					_003C_003E8__1._003C_003E4__this._disposable.Dispose();
					JineType id = sentdata.Value.id;
					int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.MadeLoveCounter);
					int num2 = _003C_003E8__1.resList.IndexOf(id) + 1;
					if (status != num2)
					{
						if (status == 0)
						{
							await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE009);
							await UniTask.Delay(Constants.MIDDLE, false, (PlayerLoopTiming)8, default(CancellationToken), false);
							await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE013);
							await UniTask.Delay(Constants.SLOW, false, (PlayerLoopTiming)8, default(CancellationToken), false);
							await _003C_003E8__1._003C_003E4__this.DieByNeedyEvent(_003C_003E8__1.token, isFocused: true);
						}
						else
						{
							await _003C_003E8__1._003C_003E4__this.DieByNeedyEvent(_003C_003E8__1.token);
						}
					}
					else
					{
						await _003C_003E8__1._003C_003E4__this.OnLonglineAsync(_003C_003E8__1.token);
					}
				}), (ICollection<IDisposable>)ending_Needy.compositeDisposable);
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
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
	private struct _003COnTimeOutAsync_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public CancellationToken token;

		public Ending_Needy _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Needy ending_Needy = _003C_003E4__this;
			try
			{
				Awaiter val;
				if (num != 0)
				{
					if (num != 1)
					{
						goto IL_00fa;
					}
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00f3;
				}
				val = _003C_003Eu__1;
				_003C_003Eu__1 = default(Awaiter);
				num = (_003C_003E1__state = -1);
				goto IL_0081;
				IL_00f3:
				((Awaiter)(ref val)).GetResult();
				goto IL_00fa;
				IL_00fa:
				UniTask val2;
				if (!token.IsCancellationRequested)
				{
					val2 = UniTask.Delay(60000, false, (PlayerLoopTiming)8, token, false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnTimeOutAsync_003Ed__20>(ref val, ref this);
						return;
					}
					goto IL_0081;
				}
				goto end_IL_000e;
				IL_0081:
				((Awaiter)(ref val)).GetResult();
				if (!token.IsCancellationRequested)
				{
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(ending_Needy._onTimeout);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnTimeOutAsync_003Ed__20>(ref val, ref this);
						return;
					}
					goto IL_00f3;
				}
				goto IL_00fa;
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003COnUnFocusedGameAsync_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public Ending_Needy _003C_003E4__this;

		public CancellationToken token;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Needy CS_0024_003C_003E8__locals3 = _003C_003E4__this;
			try
			{
				Awaiter val;
				UniTask val2;
				switch (num)
				{
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_008f;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0100;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_016f;
				default:
					{
						if (!token.IsCancellationRequested)
						{
							val2 = UniTask.WaitUntil((Func<bool>)(() => !CS_0024_003C_003E8__locals3._onFocus), (PlayerLoopTiming)8, token, false);
							val = ((UniTask)(ref val2)).GetAwaiter();
							if (!((Awaiter)(ref val)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = val;
								((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnUnFocusedGameAsync_003Ed__21>(ref val, ref this);
								return;
							}
							goto IL_008f;
						}
						break;
					}
					IL_008f:
					((Awaiter)(ref val)).GetResult();
					val2 = UniTask.WaitUntil((Func<bool>)(() => CS_0024_003C_003E8__locals3._onFocus), (PlayerLoopTiming)8, token, false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnUnFocusedGameAsync_003Ed__21>(ref val, ref this);
						return;
					}
					goto IL_0100;
					IL_0100:
					((Awaiter)(ref val)).GetResult();
					if (!token.IsCancellationRequested)
					{
						val2 = CS_0024_003C_003E8__locals3.DieByNeedyEvent(token, isFocused: true);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = val;
							((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnUnFocusedGameAsync_003Ed__21>(ref val, ref this);
							return;
						}
						goto IL_016f;
					}
					break;
					IL_016f:
					((Awaiter)(ref val)).GetResult();
					goto default;
				}
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CeventContinue1_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Needy _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Needy ending_Needy = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					val2 = NgoEvent.DelaySkippable(Constants.MIDDLE);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CeventContinue1_003Ed__12>(ref val, ref this);
						return;
					}
					goto IL_007b;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_007b;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00e2;
				case 2:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00e2:
					((Awaiter)(ref val)).GetResult();
					AudioManager.Instance.PlaySeByType(SoundType.SE_heartbeat);
					val2 = ending_Needy.OnDatePlaceAsync();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CeventContinue1_003Ed__12>(ref val, ref this);
						return;
					}
					break;
					IL_007b:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE002);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CeventContinue1_003Ed__12>(ref val, ref this);
						return;
					}
					goto IL_00e2;
				}
				((Awaiter)(ref val)).GetResult();
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
	private struct _003Cnight_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Needy _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Needy CS_0024_003C_003E8__locals6 = _003C_003E4__this;
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
						goto IL_00e0;
					}
					CS_0024_003C_003E8__locals6.OnStartNeedyEnd();
					val2 = NgoEvent.DelaySkippable(Constants.MIDDLE);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003Cnight_003Ed__11>(ref val, ref this);
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
				val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE001);
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003Cnight_003Ed__11>(ref val, ref this);
					return;
				}
				goto IL_00e0;
				IL_00e0:
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
				{
					JineType.Jine_BeforeEnding_Needy004_Option001,
					JineType.Jine_BeforeEnding_Needy004_Option002,
					JineType.Jine_BeforeEnding_Needy004_Option003
				});
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Jine_BeforeEnding_Needy004_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					await CS_0024_003C_003E8__locals6.eventContinue1();
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
					await NgoEvent.DelaySkippable(Constants.MIDDLE);
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals6.compositeDisposable);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Jine_BeforeEnding_Needy004_Option002)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					await CS_0024_003C_003E8__locals6.eventContinue1();
					await NgoEvent.DelaySkippable(Constants.MIDDLE);
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals6.compositeDisposable);
				ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Jine_BeforeEnding_Needy004_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					await CS_0024_003C_003E8__locals6.eventContinue1();
					await NgoEvent.DelaySkippable(Constants.MIDDLE);
				});
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
	private struct _003CstartEvent_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Needy _003C_003E4__this;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0201: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Needy CS_0024_003C_003E8__locals3 = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					((NgoEvent)CS_0024_003C_003E8__locals3).startEvent(cancellationToken);
					SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Needy;
					SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
					SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Needy000);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_00bb;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00bb;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0122;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0189;
				case 3:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01f0;
				case 4:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_01f0:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Needy004);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					break;
					IL_00bb:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Needy001);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_0122;
					IL_0189:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Needy003);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_01f0;
					IL_0122:
					((Awaiter)(ref val)).GetResult();
					val2 = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Needy002);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_0189;
				}
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<NotificationManager>.Instance.AddMaturoNotifier();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>((IObservable<int>)SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart), (Func<int, bool>)((int v) => v == 3)), (Action<int>)async delegate
				{
					CS_0024_003C_003E8__locals3.night();
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals3.compositeDisposable);
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

	private IDisposable _disposable;

	private IDisposable _disposable2;

	private GameObject _KyouizonEndAnimation;

	private JineType _onTimeout = JineType.Ending_Kyouizon_OiJINE2;

	private JineType _onDragJine = JineType.Ending_Kyouizon_OiJINE1;

	private bool _onFocus;

	private bool _isShaderActivate;

	private float _shaderWeight;

	protected override void Awake()
	{
		base.Awake();
	}

	private void Update()
	{
		if (_isShaderActivate)
		{
			_shaderWeight += 0.001f;
			if (_shaderWeight > 1f)
			{
				_shaderWeight -= 0.2f;
			}
			PostEffectManager.Instance.SetShaderWeight(_shaderWeight);
		}
	}

	[AsyncStateMachine(typeof(_003CstartEvent_003Ed__10))]
	public override UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CstartEvent_003Ed__10 _003CstartEvent_003Ed__11 = default(_003CstartEvent_003Ed__10);
		_003CstartEvent_003Ed__11._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartEvent_003Ed__11._003C_003E4__this = this;
		_003CstartEvent_003Ed__11.cancellationToken = cancellationToken;
		_003CstartEvent_003Ed__11._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__11._003C_003Et__builder)).Start<_003CstartEvent_003Ed__10>(ref _003CstartEvent_003Ed__11);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__11._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003Cnight_003Ed__11))]
	private UniTask night()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003Cnight_003Ed__11 _003Cnight_003Ed__12 = default(_003Cnight_003Ed__11);
		_003Cnight_003Ed__12._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003Cnight_003Ed__12._003C_003E4__this = this;
		_003Cnight_003Ed__12._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003Cnight_003Ed__12._003C_003Et__builder)).Start<_003Cnight_003Ed__11>(ref _003Cnight_003Ed__12);
		return ((AsyncUniTaskMethodBuilder)(ref _003Cnight_003Ed__12._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CeventContinue1_003Ed__12))]
	private UniTask eventContinue1()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CeventContinue1_003Ed__12 _003CeventContinue1_003Ed__13 = default(_003CeventContinue1_003Ed__12);
		_003CeventContinue1_003Ed__13._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CeventContinue1_003Ed__13._003C_003E4__this = this;
		_003CeventContinue1_003Ed__13._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CeventContinue1_003Ed__13._003C_003Et__builder)).Start<_003CeventContinue1_003Ed__12>(ref _003CeventContinue1_003Ed__13);
		return ((AsyncUniTaskMethodBuilder)(ref _003CeventContinue1_003Ed__13._003C_003Et__builder)).Task;
	}

	public void OnStartNeedyEnd()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
		AudioManager.Instance.StopBgm();
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_kincho, isLoop: true);
		PostEffectManager.Instance.SetShader(EffectType.Kyouizon);
		_isShaderActivate = true;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Jine);
		window.Uncloseable();
		((Transform)window.UnityGameObject.GetComponent<RectTransform>()).localPosition = new Vector3(0f, 0f, 0f);
	}

	[AsyncStateMachine(typeof(_003COnDatePlaceAsync_003Ed__14))]
	private UniTask OnDatePlaceAsync(CancellationToken token = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003COnDatePlaceAsync_003Ed__14 _003COnDatePlaceAsync_003Ed__15 = default(_003COnDatePlaceAsync_003Ed__14);
		_003COnDatePlaceAsync_003Ed__15._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003COnDatePlaceAsync_003Ed__15._003C_003E4__this = this;
		_003COnDatePlaceAsync_003Ed__15.token = token;
		_003COnDatePlaceAsync_003Ed__15._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003COnDatePlaceAsync_003Ed__15._003C_003Et__builder)).Start<_003COnDatePlaceAsync_003Ed__14>(ref _003COnDatePlaceAsync_003Ed__15);
		return ((AsyncUniTaskMethodBuilder)(ref _003COnDatePlaceAsync_003Ed__15._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COnSexCountAsync_003Ed__15))]
	private UniTask OnSexCountAsync(CancellationToken token = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003COnSexCountAsync_003Ed__15 _003COnSexCountAsync_003Ed__16 = default(_003COnSexCountAsync_003Ed__15);
		_003COnSexCountAsync_003Ed__16._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003COnSexCountAsync_003Ed__16._003C_003E4__this = this;
		_003COnSexCountAsync_003Ed__16.token = token;
		_003COnSexCountAsync_003Ed__16._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003COnSexCountAsync_003Ed__16._003C_003Et__builder)).Start<_003COnSexCountAsync_003Ed__15>(ref _003COnSexCountAsync_003Ed__16);
		return ((AsyncUniTaskMethodBuilder)(ref _003COnSexCountAsync_003Ed__16._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COnLonglineAsync_003Ed__16))]
	public UniTask OnLonglineAsync(CancellationToken token = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003COnLonglineAsync_003Ed__16 _003COnLonglineAsync_003Ed__17 = default(_003COnLonglineAsync_003Ed__16);
		_003COnLonglineAsync_003Ed__17._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003COnLonglineAsync_003Ed__17._003C_003E4__this = this;
		_003COnLonglineAsync_003Ed__17.token = token;
		_003COnLonglineAsync_003Ed__17._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003COnLonglineAsync_003Ed__17._003C_003Et__builder)).Start<_003COnLonglineAsync_003Ed__16>(ref _003COnLonglineAsync_003Ed__17);
		return ((AsyncUniTaskMethodBuilder)(ref _003COnLonglineAsync_003Ed__17._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CConsumerLongMessageAsync_003Ed__17))]
	private UniTask ConsumerLongMessageAsync(CancellationToken token = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CConsumerLongMessageAsync_003Ed__17 _003CConsumerLongMessageAsync_003Ed__18 = default(_003CConsumerLongMessageAsync_003Ed__17);
		_003CConsumerLongMessageAsync_003Ed__18._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CConsumerLongMessageAsync_003Ed__18._003C_003E4__this = this;
		_003CConsumerLongMessageAsync_003Ed__18.token = token;
		_003CConsumerLongMessageAsync_003Ed__18._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CConsumerLongMessageAsync_003Ed__18._003C_003Et__builder)).Start<_003CConsumerLongMessageAsync_003Ed__17>(ref _003CConsumerLongMessageAsync_003Ed__18);
		return ((AsyncUniTaskMethodBuilder)(ref _003CConsumerLongMessageAsync_003Ed__18._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLongMessageAsync_003Ed__18))]
	private UniTask LongMessageAsync(CancellationToken token = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CLongMessageAsync_003Ed__18 _003CLongMessageAsync_003Ed__19 = default(_003CLongMessageAsync_003Ed__18);
		_003CLongMessageAsync_003Ed__19._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CLongMessageAsync_003Ed__19._003C_003E4__this = this;
		_003CLongMessageAsync_003Ed__19.token = token;
		_003CLongMessageAsync_003Ed__19._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CLongMessageAsync_003Ed__19._003C_003Et__builder)).Start<_003CLongMessageAsync_003Ed__18>(ref _003CLongMessageAsync_003Ed__19);
		return ((AsyncUniTaskMethodBuilder)(ref _003CLongMessageAsync_003Ed__19._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAliveRoute_003Ed__19))]
	private UniTask AliveRoute()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CAliveRoute_003Ed__19 _003CAliveRoute_003Ed__20 = default(_003CAliveRoute_003Ed__19);
		_003CAliveRoute_003Ed__20._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CAliveRoute_003Ed__20._003C_003E4__this = this;
		_003CAliveRoute_003Ed__20._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CAliveRoute_003Ed__20._003C_003Et__builder)).Start<_003CAliveRoute_003Ed__19>(ref _003CAliveRoute_003Ed__20);
		return ((AsyncUniTaskMethodBuilder)(ref _003CAliveRoute_003Ed__20._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COnTimeOutAsync_003Ed__20))]
	private UniTaskVoid OnTimeOutAsync(CancellationToken token = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003COnTimeOutAsync_003Ed__20 _003COnTimeOutAsync_003Ed__21 = default(_003COnTimeOutAsync_003Ed__20);
		_003COnTimeOutAsync_003Ed__21._003C_003Et__builder = AsyncUniTaskVoidMethodBuilder.Create();
		_003COnTimeOutAsync_003Ed__21._003C_003E4__this = this;
		_003COnTimeOutAsync_003Ed__21.token = token;
		_003COnTimeOutAsync_003Ed__21._003C_003E1__state = -1;
		((AsyncUniTaskVoidMethodBuilder)(ref _003COnTimeOutAsync_003Ed__21._003C_003Et__builder)).Start<_003COnTimeOutAsync_003Ed__20>(ref _003COnTimeOutAsync_003Ed__21);
		return ((AsyncUniTaskVoidMethodBuilder)(ref _003COnTimeOutAsync_003Ed__21._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COnUnFocusedGameAsync_003Ed__21))]
	private UniTaskVoid OnUnFocusedGameAsync(CancellationToken token = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003COnUnFocusedGameAsync_003Ed__21 _003COnUnFocusedGameAsync_003Ed__22 = default(_003COnUnFocusedGameAsync_003Ed__21);
		_003COnUnFocusedGameAsync_003Ed__22._003C_003Et__builder = AsyncUniTaskVoidMethodBuilder.Create();
		_003COnUnFocusedGameAsync_003Ed__22._003C_003E4__this = this;
		_003COnUnFocusedGameAsync_003Ed__22.token = token;
		_003COnUnFocusedGameAsync_003Ed__22._003C_003E1__state = -1;
		((AsyncUniTaskVoidMethodBuilder)(ref _003COnUnFocusedGameAsync_003Ed__22._003C_003Et__builder)).Start<_003COnUnFocusedGameAsync_003Ed__21>(ref _003COnUnFocusedGameAsync_003Ed__22);
		return ((AsyncUniTaskVoidMethodBuilder)(ref _003COnUnFocusedGameAsync_003Ed__22._003C_003Et__builder)).Task;
	}

	private void OnApplicationFocus(bool focus)
	{
		_onFocus = focus;
	}

	[AsyncStateMachine(typeof(_003CDieByNeedyEvent_003Ed__23))]
	private UniTask DieByNeedyEvent(CancellationToken token = default(CancellationToken), bool isFocused = false)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CDieByNeedyEvent_003Ed__23 _003CDieByNeedyEvent_003Ed__24 = default(_003CDieByNeedyEvent_003Ed__23);
		_003CDieByNeedyEvent_003Ed__24._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CDieByNeedyEvent_003Ed__24._003C_003E4__this = this;
		_003CDieByNeedyEvent_003Ed__24.isFocused = isFocused;
		_003CDieByNeedyEvent_003Ed__24._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CDieByNeedyEvent_003Ed__24._003C_003Et__builder)).Start<_003CDieByNeedyEvent_003Ed__23>(ref _003CDieByNeedyEvent_003Ed__24);
		return ((AsyncUniTaskMethodBuilder)(ref _003CDieByNeedyEvent_003Ed__24._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGetNeedieList_003Ed__24))]
	private UniTask GetNeedieList(bool isFocused = false)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CGetNeedieList_003Ed__24 _003CGetNeedieList_003Ed__25 = default(_003CGetNeedieList_003Ed__24);
		_003CGetNeedieList_003Ed__25._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CGetNeedieList_003Ed__25.isFocused = isFocused;
		_003CGetNeedieList_003Ed__25._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CGetNeedieList_003Ed__25._003C_003Et__builder)).Start<_003CGetNeedieList_003Ed__24>(ref _003CGetNeedieList_003Ed__25);
		return ((AsyncUniTaskMethodBuilder)(ref _003CGetNeedieList_003Ed__25._003C_003Et__builder)).Task;
	}
}
