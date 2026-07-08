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
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Ending_Meta : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CSpeak_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Meta _003C_003E4__this;

		public string nakami;

		private TweenAwaiter _003C_003Eu__1;

		private Awaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Meta ending_Meta = _003C_003E4__this;
			try
			{
				Awaiter val;
				TweenAwaiter val2;
				if (num != 0)
				{
					if (num == 1)
					{
						val = _003C_003Eu__2;
						_003C_003Eu__2 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0119;
					}
					ending_Meta._jimaku.text = "";
					float num2 = 0.3f;
					val2 = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<string, string, StringOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<string, string, StringOptions>>(ShortcutExtensionsTMPText.DOText(ending_Meta._jimaku, nakami, (float)nakami.Length * num2, true, (ScrambleMode)0, (string)null), (Ease)1)));
					if (!((TweenAwaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CSpeak_003Ed__15>(ref val2, ref this);
						return;
					}
				}
				else
				{
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TweenAwaiter)(ref val2)).GetResult();
				UniTask val3 = UniTask.Delay(Constants.MIDDLE, false, (PlayerLoopTiming)8, default(CancellationToken), false);
				val = ((UniTask)(ref val3)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CSpeak_003Ed__15>(ref val, ref this);
					return;
				}
				goto IL_0119;
				IL_0119:
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
	private struct _003Cend_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Meta _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Meta ending_Meta = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					((Component)ending_Meta._button1).gameObject.SetActive(false);
					((Component)ending_Meta._button2).gameObject.SetActive(false);
					val2 = ending_Meta.Speak(NgoEx.TenTalk("Ending_Meta016", ending_Meta._lang));
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003Cend_003Ed__12>(ref val, ref this);
						return;
					}
					goto IL_00ad;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00ad;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_011b;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01a1;
				case 3:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_011b:
					((Awaiter)(ref val)).GetResult();
					ending_Meta._tenbody.SetActive(false);
					ending_Meta._tenhand.SetActive(true);
					val2 = ending_Meta.Speak(NgoEx.TenTalk("Ending_Meta_Comment005", ending_Meta._lang));
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003Cend_003Ed__12>(ref val, ref this);
						return;
					}
					goto IL_01a1;
					IL_00ad:
					((Awaiter)(ref val)).GetResult();
					val2 = ending_Meta.Speak(NgoEx.TenTalk("Ending_Meta_Comment004", ending_Meta._lang));
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003Cend_003Ed__12>(ref val, ref this);
						return;
					}
					goto IL_011b;
					IL_01a1:
					((Awaiter)(ref val)).GetResult();
					val2 = UniTask.Delay(Constants.SLOW, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003Cend_003Ed__12>(ref val, ref this);
						return;
					}
					break;
				}
				((Awaiter)(ref val)).GetResult();
				AchievementStatsUpdater.UpdateStats("Ending_Meta");
				SingletonMonoBehaviour<EventManager>.Instance.CallEnding();
				ending_Meta.endEvent();
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
	private struct _003CstartCast_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Meta _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Meta CS_0024_003C_003E8__locals48 = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Bank);
					CS_0024_003C_003E8__locals48._tenWindow.SetActive(true);
					TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOScale(CS_0024_003C_003E8__locals48._tenbody.transform, new Vector3(6f, 6f, 1f), 60f));
					AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
					((Component)GameObject.Find("EndingCover").transform.Find("jimaku")).gameObject.SetActive(true);
					val2 = CS_0024_003C_003E8__locals48.Speak(NgoEx.TenTalk("Ending_Meta_Comment001", CS_0024_003C_003E8__locals48._lang));
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartCast_003Ed__11>(ref val, ref this);
						return;
					}
					goto IL_0104;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0104;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0172;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01e0;
				case 3:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0172:
					((Awaiter)(ref val)).GetResult();
					val2 = CS_0024_003C_003E8__locals48.Speak(NgoEx.TenTalk("Ending_Meta_Comment003", CS_0024_003C_003E8__locals48._lang));
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartCast_003Ed__11>(ref val, ref this);
						return;
					}
					goto IL_01e0;
					IL_0104:
					((Awaiter)(ref val)).GetResult();
					val2 = CS_0024_003C_003E8__locals48.Speak(NgoEx.TenTalk("Ending_Meta_Comment002", CS_0024_003C_003E8__locals48._lang));
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartCast_003Ed__11>(ref val, ref this);
						return;
					}
					goto IL_0172;
					IL_01e0:
					((Awaiter)(ref val)).GetResult();
					val2 = CS_0024_003C_003E8__locals48.Speak(NgoEx.TenTalk("Ending_Meta005", CS_0024_003C_003E8__locals48._lang));
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartCast_003Ed__11>(ref val, ref this);
						return;
					}
					break;
				}
				((Awaiter)(ref val)).GetResult();
				CS_0024_003C_003E8__locals48.ShowButton1(NgoEx.TenTalk("Ending_Meta006_pi", CS_0024_003C_003E8__locals48._lang));
				CS_0024_003C_003E8__locals48._disposable = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals48._button1), (Action<Unit>)async delegate
				{
					CS_0024_003C_003E8__locals48._disposable.Dispose();
					((Component)CS_0024_003C_003E8__locals48._button1).gameObject.SetActive(false);
					await CS_0024_003C_003E8__locals48.Speak(NgoEx.TenTalk("Ending_Meta007", CS_0024_003C_003E8__locals48._lang));
					await CS_0024_003C_003E8__locals48.Speak(NgoEx.TenTalk("Ending_Meta008", CS_0024_003C_003E8__locals48._lang));
					await CS_0024_003C_003E8__locals48.Speak(NgoEx.TenTalk("Ending_Meta009", CS_0024_003C_003E8__locals48._lang));
					await CS_0024_003C_003E8__locals48.Speak(NgoEx.TenTalk("Ending_Meta010", CS_0024_003C_003E8__locals48._lang));
					CS_0024_003C_003E8__locals48.ShowButton1(NgoEx.TenTalk("Ending_Meta011_pi", CS_0024_003C_003E8__locals48._lang));
					CS_0024_003C_003E8__locals48._disposable = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals48._button1), (Action<Unit>)async delegate
					{
						CS_0024_003C_003E8__locals48._disposable.Dispose();
						((Component)CS_0024_003C_003E8__locals48._button1).gameObject.SetActive(false);
						await CS_0024_003C_003E8__locals48.Speak(NgoEx.TenTalk("Ending_Meta012", CS_0024_003C_003E8__locals48._lang));
						await CS_0024_003C_003E8__locals48.Speak(NgoEx.TenTalk("Ending_Meta013", CS_0024_003C_003E8__locals48._lang));
						CS_0024_003C_003E8__locals48.ShowButton1(NgoEx.TenTalk("Ending_Meta014_pi", CS_0024_003C_003E8__locals48._lang));
						CS_0024_003C_003E8__locals48.ShowButton2(NgoEx.TenTalk("Ending_Meta015_pi", CS_0024_003C_003E8__locals48._lang));
						CS_0024_003C_003E8__locals48._disposable = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals48._button1), (Action<Unit>)delegate
						{
							//IL_0001: Unknown result type (might be due to invalid IL or missing references)
							CS_0024_003C_003E8__locals48.end();
						}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals48.compositeDisposable);
						CS_0024_003C_003E8__locals48._disposable = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals48._button2), (Action<Unit>)delegate
						{
							//IL_0001: Unknown result type (might be due to invalid IL or missing references)
							CS_0024_003C_003E8__locals48.end();
						}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals48.compositeDisposable);
					}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals48.compositeDisposable);
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals48.compositeDisposable);
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

		public Ending_Meta _003C_003E4__this;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_036c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0371: Unknown result type (might be due to invalid IL or missing references)
			//IL_0378: Unknown result type (might be due to invalid IL or missing references)
			//IL_0408: Unknown result type (might be due to invalid IL or missing references)
			//IL_040d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0414: Unknown result type (might be due to invalid IL or missing references)
			//IL_048b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0490: Unknown result type (might be due to invalid IL or missing references)
			//IL_0497: Unknown result type (might be due to invalid IL or missing references)
			//IL_050a: Unknown result type (might be due to invalid IL or missing references)
			//IL_050f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0516: Unknown result type (might be due to invalid IL or missing references)
			//IL_0565: Unknown result type (might be due to invalid IL or missing references)
			//IL_056a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0571: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0331: Unknown result type (might be due to invalid IL or missing references)
			//IL_0336: Unknown result type (might be due to invalid IL or missing references)
			//IL_0339: Unknown result type (might be due to invalid IL or missing references)
			//IL_033e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03da: Unknown result type (might be due to invalid IL or missing references)
			//IL_0450: Unknown result type (might be due to invalid IL or missing references)
			//IL_0455: Unknown result type (might be due to invalid IL or missing references)
			//IL_0458: Unknown result type (might be due to invalid IL or missing references)
			//IL_045d: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_052d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0532: Unknown result type (might be due to invalid IL or missing references)
			//IL_0535: Unknown result type (might be due to invalid IL or missing references)
			//IL_053a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0352: Unknown result type (might be due to invalid IL or missing references)
			//IL_0353: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_0471: Unknown result type (might be due to invalid IL or missing references)
			//IL_0472: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_054e: Unknown result type (might be due to invalid IL or missing references)
			//IL_054f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Meta ending_Meta = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					((NgoEvent)ending_Meta).startEvent(cancellationToken);
					SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Meta;
					SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
					SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
					ending_Meta._lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
					ending_Meta._jimaku = ((Component)GameObject.Find("EndingCover").transform.Find("jimaku").Find("jimakuText")).gameObject.GetComponent<TMP_Text>();
					ending_Meta._tenWindow = ((Component)GameObject.Find("EndingCover").transform.Find("castwindow")).gameObject;
					ending_Meta._tenbody = ((Component)ending_Meta._tenWindow.transform.GetChild(0).GetChild(1)).gameObject;
					ending_Meta._tenhand = ((Component)GameObject.Find("EndingCover").transform.Find("meta")).gameObject;
					ending_Meta._button1 = ((Component)GameObject.Find("Metacover").transform.Find("Button1")).gameObject.GetComponent<Button>();
					ending_Meta._button2 = ((Component)GameObject.Find("Metacover").transform.Find("Button2")).gameObject.GetComponent<Button>();
					PostEffectManager.Instance.ResetShader();
					PostEffectManager.Instance.SetShader(EffectType.Psyche);
					PostEffectManager.Instance.SetShaderWeight(0.2f);
					val2 = NgoEvent.DelaySkippable(Constants.MIDDLE);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_01e6;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01e6;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02d4;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0387;
				case 3:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0423;
				case 4:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_04a6;
				case 5:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0525;
				case 6:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_04a6:
					((Awaiter)(ref val)).GetResult();
					GameObject.Find("Obi").SetActive(false);
					val2 = UniTask.Delay(1000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_0525;
					IL_01e6:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
					SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Jine);
					SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Poketter);
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.NetaChoose);
					SingletonMonoBehaviour<CommandManager>.Instance.disableAllCommands();
					SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = true;
					SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.Tension).Value = 20;
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Bank);
					AudioManager.Instance.PlayBgmByType(SoundType.BANK_bank);
					val2 = UniTask.Delay(5000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_02d4;
					IL_0423:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<TaskbarManager>.Instance.TaskBarGroup.alpha = 0f;
					val2 = UniTask.Delay(2000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_04a6;
					IL_02d4:
					((Awaiter)(ref val)).GetResult();
					TweenExtensions.Play<TweenerCore<Quaternion, Vector3, QuaternionOptions>>(ShortcutExtensions.DORotate(GameObject.Find("ShortCutParent").transform, new Vector3(0f, 0f, 1200f), 10f, (RotateMode)0));
					SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 1f);
					val2 = UniTask.Delay(4000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_0387;
					IL_0525:
					((Awaiter)(ref val)).GetResult();
					val2 = ending_Meta.startCast();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					break;
					IL_0387:
					((Awaiter)(ref val)).GetResult();
					((Graphic)GameObject.Find("MainPanel").GetComponent<Image>()).color = new Color(0f, 0f, 0f, 1f);
					val2 = UniTask.Delay(3000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_0423;
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

	private TMP_Text _jimaku;

	private LanguageType _lang;

	private GameObject _tenWindow;

	private GameObject _tenbody;

	private GameObject _tenhand;

	private Button _button1;

	private Button _button2;

	private IDisposable _disposable;

	protected override void Awake()
	{
		base.Awake();
	}

	private void Update()
	{
		PostEffectManager.Instance.SetShaderWeight(Random.Range(0.2f, 0.25f));
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

	[AsyncStateMachine(typeof(_003CstartCast_003Ed__11))]
	private UniTask startCast()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CstartCast_003Ed__11 _003CstartCast_003Ed__12 = default(_003CstartCast_003Ed__11);
		_003CstartCast_003Ed__12._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartCast_003Ed__12._003C_003E4__this = this;
		_003CstartCast_003Ed__12._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartCast_003Ed__12._003C_003Et__builder)).Start<_003CstartCast_003Ed__11>(ref _003CstartCast_003Ed__12);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartCast_003Ed__12._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003Cend_003Ed__12))]
	private UniTask end()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003Cend_003Ed__12 _003Cend_003Ed__13 = default(_003Cend_003Ed__12);
		_003Cend_003Ed__13._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003Cend_003Ed__13._003C_003E4__this = this;
		_003Cend_003Ed__13._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003Cend_003Ed__13._003C_003Et__builder)).Start<_003Cend_003Ed__12>(ref _003Cend_003Ed__13);
		return ((AsyncUniTaskMethodBuilder)(ref _003Cend_003Ed__13._003C_003Et__builder)).Task;
	}

	private void ShowButton1(string labeltext)
	{
		((Component)_button1).GetComponentInChildren<TMP_Text>().text = labeltext;
		((Component)_button1).gameObject.SetActive(true);
	}

	private void ShowButton2(string labeltext)
	{
		((Component)_button2).GetComponentInChildren<TMP_Text>().text = labeltext;
		((Component)_button2).gameObject.SetActive(true);
	}

	[AsyncStateMachine(typeof(_003CSpeak_003Ed__15))]
	private UniTask Speak(string nakami)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CSpeak_003Ed__15 _003CSpeak_003Ed__16 = default(_003CSpeak_003Ed__15);
		_003CSpeak_003Ed__16._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CSpeak_003Ed__16._003C_003E4__this = this;
		_003CSpeak_003Ed__16.nakami = nakami;
		_003CSpeak_003Ed__16._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CSpeak_003Ed__16._003C_003Et__builder)).Start<_003CSpeak_003Ed__15>(ref _003CSpeak_003Ed__16);
		return ((AsyncUniTaskMethodBuilder)(ref _003CSpeak_003Ed__16._003C_003Et__builder)).Task;
	}
}
