using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ngov3;

public class Ending_Ideon : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGenerateWindowOutOfScreen_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Ideon _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Ideon ending_Ideon = _003C_003E4__this;
			try
			{
				Awaiter val3;
				if (num != 0)
				{
					Vector3 val = default(Vector3);
					((Vector3)(ref val))._002Ector(2000f, 2000f, 0f);
					ending_Ideon.taiki = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.Ideon_taiki, playSe: false, makeTaskButton: false);
					ending_Ideon.taiki.Uncloseable();
					Transform gameObjectTransform = ending_Ideon.taiki.GameObjectTransform;
					gameObjectTransform.position += val;
					ending_Ideon.keijiban = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.KeijibanMini, playSe: false, makeTaskButton: false);
					Transform gameObjectTransform2 = ending_Ideon.keijiban.GameObjectTransform;
					gameObjectTransform2.position += val;
					ending_Ideon.hutaba = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.Ideon_hutaba, playSe: false, makeTaskButton: false);
					Transform gameObjectTransform3 = ending_Ideon.hutaba.GameObjectTransform;
					gameObjectTransform3.position += val;
					ending_Ideon.niconico = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.Ideon_nico, playSe: false, makeTaskButton: false);
					Transform gameObjectTransform4 = ending_Ideon.niconico.GameObjectTransform;
					gameObjectTransform4.position += val;
					ending_Ideon.news = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.Ideon_news, playSe: false, makeTaskButton: false);
					Transform gameObjectTransform5 = ending_Ideon.news.GameObjectTransform;
					gameObjectTransform5.position += val;
					ending_Ideon.insta = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.Ideon_Insta, playSe: false, makeTaskButton: false);
					Transform gameObjectTransform6 = ending_Ideon.insta.GameObjectTransform;
					gameObjectTransform6.position += val;
					ending_Ideon.wiki = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.Ideon_wiki, playSe: false, makeTaskButton: false);
					Transform gameObjectTransform7 = ending_Ideon.wiki.GameObjectTransform;
					gameObjectTransform7.position += val;
					UniTask val2 = UniTask.DelayFrame(5, (PlayerLoopTiming)8, default(CancellationToken), false);
					val3 = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val3)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val3;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CGenerateWindowOutOfScreen_003Ed__11>(ref val3, ref this);
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
	private struct _003CPopWindows_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Ending_Ideon _003C_003E4__this;

		private void MoveNext()
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			Ending_Ideon ending_Ideon = _003C_003E4__this;
			try
			{
				Vector3 val = default(Vector3);
				((Vector3)(ref val))._002Ector(2000f, 2000f, 0f);
				Transform gameObjectTransform = ending_Ideon.taiki.GameObjectTransform;
				gameObjectTransform.position -= val;
				SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(ending_Ideon.taiki);
				ending_Ideon.taiki.Touched();
				AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
				Transform gameObjectTransform2 = ending_Ideon.keijiban.GameObjectTransform;
				gameObjectTransform2.position -= val;
				SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(ending_Ideon.keijiban);
				ending_Ideon.keijiban.Touched();
				AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
				Transform gameObjectTransform3 = ending_Ideon.hutaba.GameObjectTransform;
				gameObjectTransform3.position -= val;
				SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(ending_Ideon.hutaba);
				ending_Ideon.hutaba.Touched();
				AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
				Transform gameObjectTransform4 = ending_Ideon.niconico.GameObjectTransform;
				gameObjectTransform4.position -= val;
				SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(ending_Ideon.niconico);
				ending_Ideon.niconico.Touched();
				AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
				Transform gameObjectTransform5 = ending_Ideon.news.GameObjectTransform;
				gameObjectTransform5.position -= val;
				SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(ending_Ideon.news);
				ending_Ideon.news.Touched();
				AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
				Transform gameObjectTransform6 = ending_Ideon.insta.GameObjectTransform;
				gameObjectTransform6.position -= val;
				SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(ending_Ideon.insta);
				ending_Ideon.insta.Touched();
				AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
				Transform gameObjectTransform7 = ending_Ideon.wiki.GameObjectTransform;
				gameObjectTransform7.position -= val;
				SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(ending_Ideon.wiki);
				ending_Ideon.wiki.Touched();
				AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
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

		public Ending_Ideon _003C_003E4__this;

		public CancellationToken cancellationToken;

		private IWindow _003Ctaskmanager_003E5__2;

		private TaskManagerManager _003CtaskmanagerManager_003E5__3;

		private float _003CtotalTime_003E5__4;

		private float _003CflashStartTime_003E5__5;

		private float _003CcurrentTime_003E5__6;

		private float _003CbloomMaxIntensity_003E5__7;

		private Awaiter _003C_003Eu__1;

		private Awaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0237: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_033e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0343: Unknown result type (might be due to invalid IL or missing references)
			//IL_034a: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_058d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0592: Unknown result type (might be due to invalid IL or missing references)
			//IL_0599: Unknown result type (might be due to invalid IL or missing references)
			//IL_060b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0610: Unknown result type (might be due to invalid IL or missing references)
			//IL_0617: Unknown result type (might be due to invalid IL or missing references)
			//IL_068a: Unknown result type (might be due to invalid IL or missing references)
			//IL_068f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0696: Unknown result type (might be due to invalid IL or missing references)
			//IL_0793: Unknown result type (might be due to invalid IL or missing references)
			//IL_0798: Unknown result type (might be due to invalid IL or missing references)
			//IL_079f: Unknown result type (might be due to invalid IL or missing references)
			//IL_07f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0291: Unknown result type (might be due to invalid IL or missing references)
			//IL_0296: Unknown result type (might be due to invalid IL or missing references)
			//IL_0302: Unknown result type (might be due to invalid IL or missing references)
			//IL_0307: Unknown result type (might be due to invalid IL or missing references)
			//IL_030b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_05dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_064d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0652: Unknown result type (might be due to invalid IL or missing references)
			//IL_0656: Unknown result type (might be due to invalid IL or missing references)
			//IL_065b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0756: Unknown result type (might be due to invalid IL or missing references)
			//IL_075b: Unknown result type (might be due to invalid IL or missing references)
			//IL_075f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0764: Unknown result type (might be due to invalid IL or missing references)
			//IL_07b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_07bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_07c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0875: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_0324: Unknown result type (might be due to invalid IL or missing references)
			//IL_0325: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0670: Unknown result type (might be due to invalid IL or missing references)
			//IL_0671: Unknown result type (might be due to invalid IL or missing references)
			//IL_0779: Unknown result type (might be due to invalid IL or missing references)
			//IL_077a: Unknown result type (might be due to invalid IL or missing references)
			//IL_07d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_07da: Unknown result type (might be due to invalid IL or missing references)
			//IL_0551: Unknown result type (might be due to invalid IL or missing references)
			//IL_0556: Unknown result type (might be due to invalid IL or missing references)
			//IL_055a: Unknown result type (might be due to invalid IL or missing references)
			//IL_055f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0483: Unknown result type (might be due to invalid IL or missing references)
			//IL_0488: Unknown result type (might be due to invalid IL or missing references)
			//IL_048c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0491: Unknown result type (might be due to invalid IL or missing references)
			//IL_0573: Unknown result type (might be due to invalid IL or missing references)
			//IL_0574: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Ending_Ideon ending_Ideon = _003C_003E4__this;
			try
			{
				UniTask val3;
				Awaiter val;
				Awaiter val2;
				YieldAwaitable val4;
				switch (num)
				{
				default:
					((NgoEvent)ending_Ideon).startEvent(cancellationToken);
					SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Ideon;
					SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
					SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
					val3 = UniTask.Delay(500, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_00e0;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00e0;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_015e;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01bd;
				case 3:
					val2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0253;
				case 4:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02df;
				case 5:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0359;
				case 6:
					val2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_04dd;
				case 7:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_05a8;
				case 8:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0626;
				case 9:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_06a5;
				case 10:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_07ae;
				case 11:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_04f6:
					if (_003CcurrentTime_003E5__6 < _003CtotalTime_003E5__4)
					{
						SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.Follower, Random.Range(1, 9999999));
						SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.Stress, Random.Range(1, 100));
						SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.Love, Random.Range(1, 100));
						SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.Yami, Random.Range(1, 100));
						if (_003CcurrentTime_003E5__6 > _003CflashStartTime_003E5__5)
						{
							((VolumeParameter<float>)(object)ending_Ideon._bloomLight.intensity).value = (_003CcurrentTime_003E5__6 - _003CflashStartTime_003E5__5) / (_003CtotalTime_003E5__4 - _003CflashStartTime_003E5__5) * _003CbloomMaxIntensity_003E5__7;
						}
						val4 = UniTask.Yield();
						val2 = ((YieldAwaitable)(ref val4)).GetAwaiter();
						if (!((Awaiter)(ref val2)).IsCompleted)
						{
							num = (_003C_003E1__state = 6);
							_003C_003Eu__2 = val2;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val2, ref this);
							return;
						}
						goto IL_04dd;
					}
					PostEffectManager.Instance.ResetShader();
					SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.TaskManager);
					ending_Ideon.shuffle = false;
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
					SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_ideon_kokuti1);
					val3 = UniTask.Delay(2000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 7);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_05a8;
					IL_00e0:
					((Awaiter)(ref val)).GetResult();
					AudioManager.Instance.StopBgm();
					LoadWebcamData.DeleteAllCache();
					val3 = UnityAsyncExtensions.ToUniTask(Resources.UnloadUnusedAssets(), (IProgress<float>)null, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_015e;
					IL_07ae:
					((Awaiter)(ref val)).GetResult();
					val3 = ending_Ideon.PopWindows();
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 11);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					break;
					IL_015e:
					((Awaiter)(ref val)).GetResult();
					val3 = ending_Ideon.GenerateWindowOutOfScreen();
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_01bd;
					IL_06a5:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_ideon_kokuti4, new List<KusoRepType>
					{
						KusoRepType.Ending_Ideon_kuso001,
						KusoRepType.Ending_Ideon_kuso002,
						KusoRepType.Ending_Ideon_kuso003,
						KusoRepType.Ending_Ideon_kuso004,
						KusoRepType.Ending_Ideon_kuso005,
						KusoRepType.Ending_Ideon_kuso006,
						KusoRepType.Ending_Ideon_kuso007,
						KusoRepType.Ending_Ideon_kuso008,
						KusoRepType.Ending_Ideon_kuso009,
						KusoRepType.Ending_Ideon_kuso010,
						KusoRepType.Ending_Ideon_kuso011,
						KusoRepType.Ending_Ideon_kuso012
					});
					val3 = UniTask.Delay(14000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 10);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_07ae;
					IL_01bd:
					((Awaiter)(ref val)).GetResult();
					_003Ctaskmanager_003E5__2 = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.TaskManager);
					_003CtaskmanagerManager_003E5__3 = _003Ctaskmanager_003E5__2.nakamiApp.GetComponent<TaskManagerManager>();
					_003CtaskmanagerManager_003E5__3.SetToolTip(onoff: false);
					val4 = UniTask.Yield();
					val2 = ((YieldAwaitable)(ref val4)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__2 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val2, ref this);
						return;
					}
					goto IL_0253;
					IL_05a8:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_ideon_kokuti2);
					val3 = UniTask.Delay(2000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 8);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_0626;
					IL_0253:
					((Awaiter)(ref val2)).GetResult();
					_003Ctaskmanager_003E5__2.Maximize();
					_003Ctaskmanager_003E5__2.Uncloseable();
					ending_Ideon.shuffle = true;
					val3 = UniTask.Delay(600, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_02df;
					IL_04dd:
					((Awaiter)(ref val2)).GetResult();
					_003CcurrentTime_003E5__6 += Time.deltaTime;
					goto IL_04f6;
					IL_02df:
					((Awaiter)(ref val)).GetResult();
					_003CtaskmanagerManager_003E5__3.ReadyToOutOfOrder();
					val3 = UniTask.Delay(600, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_0359;
					IL_0626:
					((Awaiter)(ref val)).GetResult();
					SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_ideon_kokuti3);
					val3 = UniTask.Delay(2000, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 9);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_06a5;
					IL_0359:
					((Awaiter)(ref val)).GetResult();
					AudioManager.Instance.PlayBgmByType(SoundType.BGM_endng_normal, isLoop: true);
					PostEffectManager.Instance.SetShader(EffectType.BloomLight);
					PostEffectManager.Instance.SetShaderWeight(0.2f);
					PostEffectManager.Instance.BloomLight.profile.TryGet<Bloom>(ref ending_Ideon._bloomLight);
					((VolumeParameter<float>)(object)ending_Ideon._bloomLight.intensity).value = 0f;
					_003CtotalTime_003E5__4 = 9f;
					_003CflashStartTime_003E5__5 = 2f;
					_003CcurrentTime_003E5__6 = 0f;
					_003CbloomMaxIntensity_003E5__7 = 70f;
					_003CtaskmanagerManager_003E5__3.GoOutOfOrder();
					goto IL_04f6;
				}
				((Awaiter)(ref val)).GetResult();
				SingletonMonoBehaviour<Settings>.Instance.addImage("wikipedia", doSave: false);
				SingletonMonoBehaviour<Settings>.Instance.addImage("seinarukana", doSave: false);
				SingletonMonoBehaviour<Settings>.Instance.addImage("news", doSave: false);
				SingletonMonoBehaviour<Settings>.Instance.addImage("futaba2", doSave: false);
				SingletonMonoBehaviour<Settings>.Instance.addImage("futaba", doSave: false);
				SingletonMonoBehaviour<Settings>.Instance.addImage("insta", doSave: false);
				UniTaskExtensions.Forget(HaishinFirstAnimation.LoadHaishinFirstAnimation());
				ending_Ideon.endEvent();
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Ctaskmanager_003E5__2 = null;
				_003CtaskmanagerManager_003E5__3 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Ctaskmanager_003E5__2 = null;
			_003CtaskmanagerManager_003E5__3 = null;
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

	private bool shuffle;

	private int light;

	private Bloom _bloomLight;

	private IWindow taiki;

	private IWindow keijiban;

	private IWindow hutaba;

	private IWindow niconico;

	private IWindow news;

	private IWindow insta;

	private IWindow wiki;

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

	[AsyncStateMachine(typeof(_003CGenerateWindowOutOfScreen_003Ed__11))]
	private UniTask GenerateWindowOutOfScreen()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CGenerateWindowOutOfScreen_003Ed__11 _003CGenerateWindowOutOfScreen_003Ed__12 = default(_003CGenerateWindowOutOfScreen_003Ed__11);
		_003CGenerateWindowOutOfScreen_003Ed__12._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CGenerateWindowOutOfScreen_003Ed__12._003C_003E4__this = this;
		_003CGenerateWindowOutOfScreen_003Ed__12._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CGenerateWindowOutOfScreen_003Ed__12._003C_003Et__builder)).Start<_003CGenerateWindowOutOfScreen_003Ed__11>(ref _003CGenerateWindowOutOfScreen_003Ed__12);
		return ((AsyncUniTaskMethodBuilder)(ref _003CGenerateWindowOutOfScreen_003Ed__12._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CPopWindows_003Ed__12))]
	private UniTask PopWindows()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CPopWindows_003Ed__12 _003CPopWindows_003Ed__13 = default(_003CPopWindows_003Ed__12);
		_003CPopWindows_003Ed__13._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CPopWindows_003Ed__13._003C_003E4__this = this;
		_003CPopWindows_003Ed__13._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CPopWindows_003Ed__13._003C_003Et__builder)).Start<_003CPopWindows_003Ed__12>(ref _003CPopWindows_003Ed__13);
		return ((AsyncUniTaskMethodBuilder)(ref _003CPopWindows_003Ed__13._003C_003Et__builder)).Task;
	}
}
