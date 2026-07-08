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
using UnityEngine.UI;

namespace ngov3;

public class LiveScenario : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CEndScenario_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public LiveScenario _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			LiveScenario liveScenario = _003C_003E4__this;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b9;
				}
				if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Grand && SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Ideon)
				{
					liveScenario._Live.Tenchan.OnEndStream();
					SingletonMonoBehaviour<EventManager>.Instance.ObiActive(onoff: true);
					UniTask val2 = UniTask.Delay(Constants.MIDDLE, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CEndScenario_003Ed__16>(ref val, ref this);
						return;
					}
					goto IL_00b9;
				}
				goto end_IL_000e;
				IL_00b9:
				((Awaiter)(ref val)).GetResult();
				PostEffectManager.Instance.ResetShader();
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CPlay_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Playing context;

		public LiveScenario _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private Awaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			//IL_0291: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			LiveScenario liveScenario = _003C_003E4__this;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0190;
				}
				Awaiter val2;
				if (num == 1)
				{
					val2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02a0;
				}
				if (context.startReading)
				{
					liveScenario._Live.ReadComment();
					liveScenario.BASESPEED = 1;
				}
				else if (context.isSetting)
				{
					if (context.ongaku != SoundType.None)
					{
						AudioManager.Instance.PlaySeByType(context.ongaku, context.isLoopAnim);
					}
					else
					{
						SingletonMonoBehaviour<ChanceEffectController>.Instance._current.Value = context.obi;
						SingletonMonoBehaviour<ChanceEffectController>.Instance._anim.Value = context.inout;
						SingletonMonoBehaviour<EventManager>.Instance.ObiActive(onoff: false);
						liveScenario.BASESPEED = 1;
					}
				}
				else
				{
					if (!context.isYohaku)
					{
						if (context.isJimaku)
						{
							liveScenario.BASESPEED = liveScenario.STARTSPEED;
							UniTask val3 = liveScenario.showJimaku(context);
							val = ((UniTask)(ref val3)).GetAwaiter();
							if (!((Awaiter)(ref val)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = val;
								((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlay_003Ed__17>(ref val, ref this);
								return;
							}
							goto IL_0190;
						}
						liveScenario.BASESPEED = liveScenario.STARTSPEED / 14 * context.nakami.Length;
						if (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN)
						{
							if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ideon)
							{
								liveScenario.BASESPEED = Mathf.CeilToInt((float)liveScenario.BASESPEED / 2.5f);
							}
							else if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ginga)
							{
								liveScenario.BASESPEED = Mathf.CeilToInt((float)liveScenario.BASESPEED / 2f);
							}
						}
						liveScenario.showComment(context);
						YieldAwaitable val4 = UniTask.Yield();
						val2 = ((YieldAwaitable)(ref val4)).GetAwaiter();
						if (!((Awaiter)(ref val2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = val2;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlay_003Ed__17>(ref val2, ref this);
							return;
						}
						goto IL_02a0;
					}
					liveScenario.BASESPEED = 1;
					liveScenario._Live.AddMob(context.nakami);
					liveScenario._Live.CommentScroll.verticalNormalizedPosition = 0f;
				}
				goto end_IL_000e;
				IL_02a0:
				((Awaiter)(ref val2)).GetResult();
				liveScenario._Live.CommentScroll.verticalNormalizedPosition = 0f;
				goto end_IL_000e;
				IL_0190:
				((Awaiter)(ref val)).GetResult();
				liveScenario._Live.setAnti(context.antiComment, context.showAnti);
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CPlayScenario_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public LiveScenario _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Unknown result type (might be due to invalid IL or missing references)
			//IL_0275: Unknown result type (might be due to invalid IL or missing references)
			//IL_027c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			LiveScenario CS_0024_003C_003E8__locals12 = _003C_003E4__this;
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
					goto IL_0090;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_011d;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01aa;
				case 3:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_021a;
				default:
					if (CS_0024_003C_003E8__locals12.playing.Count > 0)
					{
						val2 = CS_0024_003C_003E8__locals12.Play(CS_0024_003C_003E8__locals12.playing[0]);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlayScenario_003Ed__15>(ref val, ref this);
							return;
						}
						goto IL_0090;
					}
					goto IL_0237;
				case 4:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0090:
					((Awaiter)(ref val)).GetResult();
					CS_0024_003C_003E8__locals12.playing.RemoveAt(0);
					if (CS_0024_003C_003E8__locals12.playing.Count > 0)
					{
						val2 = UniTask.Delay(CS_0024_003C_003E8__locals12.BASESPEED, false, (PlayerLoopTiming)8, default(CancellationToken), false);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlayScenario_003Ed__15>(ref val, ref this);
							return;
						}
						goto IL_011d;
					}
					goto IL_0237;
					IL_0237:
					val2 = CS_0024_003C_003E8__locals12.EndScenario();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlayScenario_003Ed__15>(ref val, ref this);
						return;
					}
					break;
					IL_021a:
					((Awaiter)(ref val)).GetResult();
					goto IL_0124;
					IL_011d:
					((Awaiter)(ref val)).GetResult();
					goto IL_0124;
					IL_0124:
					if (CS_0024_003C_003E8__locals12.isGensoku.Value || CS_0024_003C_003E8__locals12.isPause)
					{
						val2 = UniTask.WaitWhile((Func<bool>)(() => CS_0024_003C_003E8__locals12.isGensoku.Value || CS_0024_003C_003E8__locals12.isPause), (PlayerLoopTiming)8, default(CancellationToken), false);
						val = ((UniTask)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlayScenario_003Ed__15>(ref val, ref this);
							return;
						}
						goto IL_01aa;
					}
					goto default;
					IL_01aa:
					((Awaiter)(ref val)).GetResult();
					val2 = UniTask.Delay(CS_0024_003C_003E8__locals12.BASESPEED, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlayScenario_003Ed__15>(ref val, ref this);
						return;
					}
					goto IL_021a;
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
	private struct _003CStartScenario_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public LiveScenario _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			LiveScenario liveScenario = _003C_003E4__this;
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
						goto IL_0144;
					}
					liveScenario.isStarted = true;
					if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) != 2)
					{
						goto IL_00f0;
					}
					SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tooltip_secondHaishin);
					TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(TweenSettingsExtensions.SetLoops<TweenerCore<Color, Color, ColorOptions>>(DOTweenModuleUI.DOColor(((Component)liveScenario._Live._HaisinSpeed).gameObject.GetComponent<Image>(), new Color(1f, 0.8f, 0.8f), 1f), 4));
					val2 = NgoEvent.DelaySkippable(Constants.SLOW);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartScenario_003Ed__12>(ref val, ref this);
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
				SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
				goto IL_00f0;
				IL_0144:
				((Awaiter)(ref val)).GetResult();
				goto end_IL_000e;
				IL_00f0:
				val2 = liveScenario.PlayScenario();
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartScenario_003Ed__12>(ref val, ref this);
					return;
				}
				goto IL_0144;
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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CshowJimaku_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Playing context;

		public LiveScenario _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			LiveScenario liveScenario = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					if (context.animation != "")
					{
						liveScenario._Live.ChotenAnimation(context.animation, context.isLoopAnim);
					}
					UniTask val = liveScenario._Live.ShowJimaku(context);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CshowJimaku_003Ed__19>(ref val2, ref this);
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

	[SerializeField]
	public List<Playing> playing;

	public int TOGGLEDBASESPEED = 3000;

	public int STARTSPEED = 3000;

	public int BASESPEED = 3000;

	public ReactiveProperty<bool> isGensoku = new ReactiveProperty<bool>(false);

	public bool isPause;

	public EffectType defaultEffectType = EffectType.Kenjo;

	[SerializeField]
	protected Live _Live;

	protected LanguageType _lang;

	public string title = "超絶最かわてんしちゃん降臨の儀";

	public bool isStarted;

	protected virtual void Awake()
	{
		playing = new List<Playing>();
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		_Live = ((Component)((Component)((Component)this).transform.parent).transform.parent).GetComponent<Live>();
		_lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		SingletonMonoBehaviour<NotificationManager>.Instance.Clean();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(ObserveExtensions.ObserveEveryValueChanged<ReactiveProperty<bool>, bool>(isGensoku, (Func<ReactiveProperty<bool>, bool>)((ReactiveProperty<bool> x) => x.Value), (FrameCountType)0, false), (Action<bool>)delegate(bool v)
		{
			PostEffectManager.Instance.MogoMogo(v);
		}), (Component)(object)this);
	}

	[AsyncStateMachine(typeof(_003CStartScenario_003Ed__12))]
	public virtual UniTask StartScenario()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CStartScenario_003Ed__12 _003CStartScenario_003Ed__13 = default(_003CStartScenario_003Ed__12);
		_003CStartScenario_003Ed__13._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CStartScenario_003Ed__13._003C_003E4__this = this;
		_003CStartScenario_003Ed__13._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CStartScenario_003Ed__13._003C_003Et__builder)).Start<_003CStartScenario_003Ed__12>(ref _003CStartScenario_003Ed__13);
		return ((AsyncUniTaskMethodBuilder)(ref _003CStartScenario_003Ed__13._003C_003Et__builder)).Task;
	}

	public void PlayScenarioToNextSerihu()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		while (playing.Count > 0)
		{
			Playing obj = playing[0];
			Play(playing[0]);
			playing.RemoveAt(0);
			if (obj.isJimaku)
			{
				break;
			}
		}
	}

	public void SkipScenario()
	{
		BASESPEED = 1;
		playing = new List<Playing>
		{
			new Playing(SoundType.SE_piyo, isloop: false)
		};
	}

	[AsyncStateMachine(typeof(_003CPlayScenario_003Ed__15))]
	public UniTask PlayScenario()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CPlayScenario_003Ed__15 _003CPlayScenario_003Ed__16 = default(_003CPlayScenario_003Ed__15);
		_003CPlayScenario_003Ed__16._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CPlayScenario_003Ed__16._003C_003E4__this = this;
		_003CPlayScenario_003Ed__16._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CPlayScenario_003Ed__16._003C_003Et__builder)).Start<_003CPlayScenario_003Ed__15>(ref _003CPlayScenario_003Ed__16);
		return ((AsyncUniTaskMethodBuilder)(ref _003CPlayScenario_003Ed__16._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CEndScenario_003Ed__16))]
	private UniTask EndScenario()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CEndScenario_003Ed__16 _003CEndScenario_003Ed__17 = default(_003CEndScenario_003Ed__16);
		_003CEndScenario_003Ed__17._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CEndScenario_003Ed__17._003C_003E4__this = this;
		_003CEndScenario_003Ed__17._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CEndScenario_003Ed__17._003C_003Et__builder)).Start<_003CEndScenario_003Ed__16>(ref _003CEndScenario_003Ed__17);
		return ((AsyncUniTaskMethodBuilder)(ref _003CEndScenario_003Ed__17._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CPlay_003Ed__17))]
	public UniTask Play(Playing context)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CPlay_003Ed__17 _003CPlay_003Ed__18 = default(_003CPlay_003Ed__17);
		_003CPlay_003Ed__18._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CPlay_003Ed__18._003C_003E4__this = this;
		_003CPlay_003Ed__18.context = context;
		_003CPlay_003Ed__18._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CPlay_003Ed__18._003C_003Et__builder)).Start<_003CPlay_003Ed__17>(ref _003CPlay_003Ed__18);
		return ((AsyncUniTaskMethodBuilder)(ref _003CPlay_003Ed__18._003C_003Et__builder)).Task;
	}

	public void showComment(Playing context)
	{
		_Live.NewComment(context);
	}

	[AsyncStateMachine(typeof(_003CshowJimaku_003Ed__19))]
	public UniTask showJimaku(Playing context)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CshowJimaku_003Ed__19 _003CshowJimaku_003Ed__20 = default(_003CshowJimaku_003Ed__19);
		_003CshowJimaku_003Ed__20._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CshowJimaku_003Ed__20._003C_003E4__this = this;
		_003CshowJimaku_003Ed__20.context = context;
		_003CshowJimaku_003Ed__20._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CshowJimaku_003Ed__20._003C_003Et__builder)).Start<_003CshowJimaku_003Ed__19>(ref _003CshowJimaku_003Ed__20);
		return ((AsyncUniTaskMethodBuilder)(ref _003CshowJimaku_003Ed__20._003C_003Et__builder)).Task;
	}

	public void OnDestroy()
	{
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: true);
	}
}
