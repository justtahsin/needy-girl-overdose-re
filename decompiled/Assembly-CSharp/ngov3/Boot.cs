using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ngov3;

public class Boot : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<Unit, LanguageType> _003C_003E9__48_0;

		public static TweenCallback _003C_003E9__51_1;

		public static TweenCallback _003C_003E9__51_2;

		public static Action<Unit> _003C_003E9__52_1;

		public static Func<IWindow, bool> _003C_003E9__66_0;

		public static Func<Button, GameObject> _003C_003E9__66_1;

		internal LanguageType _003CStart_003Eb__48_0(Unit _)
		{
			return SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		}

		internal void _003CBootOS_003Eb__51_1()
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_BIOS_HDD);
		}

		internal void _003CBootOS_003Eb__51_2()
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_Boot);
		}

		internal void _003CwaitAccept_003Eb__52_1(Unit _)
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
			Application.Quit();
		}

		internal bool _003CGetSelectableObjects_003Eb__66_0(IWindow w)
		{
			return w.activeState == ActiveState.Active;
		}

		internal GameObject _003CGetSelectableObjects_003Eb__66_1(Button btn)
		{
			return ((Component)btn).gameObject;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CBootOS_003Ed__51 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Boot _003C_003E4__this;

		private float _003CwaitInBios_003E5__2;

		private float _003CwaitInSplash_003E5__3;

		private UniTask _003CloadAssetTask_003E5__4;

		private Awaiter _003C_003Eu__1;

		private TweenAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0410: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_0314: Unknown result type (might be due to invalid IL or missing references)
			//IL_0319: Unknown result type (might be due to invalid IL or missing references)
			//IL_0321: Unknown result type (might be due to invalid IL or missing references)
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Unknown result type (might be due to invalid IL or missing references)
			//IL_037c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Unknown result type (might be due to invalid IL or missing references)
			//IL_033d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0342: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_02df: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Expected O, but got Unknown
			//IL_0356: Unknown result type (might be due to invalid IL or missing references)
			//IL_0357: Unknown result type (might be due to invalid IL or missing references)
			//IL_0433: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Expected O, but got Unknown
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Expected O, but got Unknown
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Boot CS_0024_003C_003E8__locals23 = _003C_003E4__this;
			try
			{
				Awaiter val;
				TweenAwaiter val2;
				Sequence obj;
				object obj2;
				Sequence obj3;
				object obj4;
				switch (num)
				{
				default:
				{
					Debug.Log((object)"BootOS:1");
					float num2 = 3f;
					_003CwaitInBios_003E5__2 = 8f;
					_003CwaitInSplash_003E5__3 = 7f;
					_003CloadAssetTask_003E5__4 = CS_0024_003C_003E8__locals23.LoadAssets();
					if (!LoadAppData.IsAppDataExist())
					{
						CS_0024_003C_003E8__locals23.Bios.alpha = 0f;
						UniTask val3 = UniTask.Delay(Mathf.FloorToInt(num2 * 1000f), false, (PlayerLoopTiming)8, default(CancellationToken), false);
						val = ((UniTask)(ref val3)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CBootOS_003Ed__51>(ref val, ref this);
							return;
						}
						goto IL_00e0;
					}
					goto IL_00f7;
				}
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00e0;
				case 1:
					val2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01ee;
				case 2:
					val2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0330;
				case 3:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0330:
					((TweenAwaiter)(ref val2)).GetResult();
					val = ((UniTask)(ref _003CloadAssetTask_003E5__4)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CBootOS_003Ed__51>(ref val, ref this);
						return;
					}
					break;
					IL_01ee:
					((TweenAwaiter)(ref val2)).GetResult();
					((Graphic)((Component)CS_0024_003C_003E8__locals23.Bios).gameObject.GetComponent<Image>()).color = new Color(0f, 0f, 0f, 1f);
					CS_0024_003C_003E8__locals23.Bios.alpha = 0f;
					CS_0024_003C_003E8__locals23.Bios.interactable = false;
					CS_0024_003C_003E8__locals23.Bios.blocksRaycasts = false;
					((Component)CS_0024_003C_003E8__locals23.Bios).gameObject.SetActive(false);
					Debug.Log((object)"BootOS:2");
					obj = DOTween.Sequence();
					obj2 = _003C_003Ec._003C_003E9__51_2;
					if (obj2 == null)
					{
						TweenCallback val4 = delegate
						{
							AudioManager.Instance.PlaySeByType(SoundType.SE_Boot);
						};
						_003C_003Ec._003C_003E9__51_2 = val4;
						obj2 = (object)val4;
					}
					CS_0024_003C_003E8__locals23.splashSequence = TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(obj, (TweenCallback)obj2), (Tween)(object)DOTweenModuleUI.DOFade(CS_0024_003C_003E8__locals23.Splash, 1f, 2.2f)), _003CwaitInSplash_003E5__3), (Tween)(object)DOTweenModuleUI.DOFade(CS_0024_003C_003E8__locals23.Splash, 0f, 0.2f));
					val2 = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<Sequence>(CS_0024_003C_003E8__locals23.splashSequence));
					if (!((TweenAwaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CBootOS_003Ed__51>(ref val2, ref this);
						return;
					}
					goto IL_0330;
					IL_00e0:
					((Awaiter)(ref val)).GetResult();
					CS_0024_003C_003E8__locals23.Bios.alpha = 1f;
					goto IL_00f7;
					IL_00f7:
					if (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN)
					{
						((Component)CS_0024_003C_003E8__locals23.BootImage).gameObject.GetComponent<Image>().sprite = CS_0024_003C_003E8__locals23.enBoot;
					}
					obj3 = TweenSettingsExtensions.AppendInterval(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
					{
						AudioManager.Instance.StopAll();
						AudioManager.Instance.PlaySeByType(SoundType.SE_BIOS_piko);
						CS_0024_003C_003E8__locals23.Bios.alpha = 1f;
					}), 1.4f);
					obj4 = _003C_003Ec._003C_003E9__51_1;
					if (obj4 == null)
					{
						TweenCallback val5 = delegate
						{
							AudioManager.Instance.PlaySeByType(SoundType.SE_BIOS_HDD);
						};
						_003C_003Ec._003C_003E9__51_1 = val5;
						obj4 = (object)val5;
					}
					CS_0024_003C_003E8__locals23.biosSequence = TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(obj3, (TweenCallback)obj4), (Tween)(object)TweenSettingsExtensions.SetEase<TweenerCore<string, string, StringOptions>>(ShortcutExtensionsTMPText.DOText(CS_0024_003C_003E8__locals23.bootingText, "Booting Windose20.............................", _003CwaitInBios_003E5__2, true, (ScrambleMode)0, (string)null), (Ease)6));
					val2 = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<Sequence>(CS_0024_003C_003E8__locals23.biosSequence));
					if (!((TweenAwaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CBootOS_003Ed__51>(ref val2, ref this);
						return;
					}
					goto IL_01ee;
				}
				((Awaiter)(ref val)).GetResult();
				Debug.Log((object)"アセットのロードが完了しました");
				CS_0024_003C_003E8__locals23.Splash.interactable = false;
				CS_0024_003C_003E8__locals23.Splash.blocksRaycasts = false;
				((Component)CS_0024_003C_003E8__locals23.Splash).gameObject.SetActive(false);
				AudioManager.Instance.StopByType(SoundType.SE_Boot);
				((Component)CS_0024_003C_003E8__locals23.Login).gameObject.SetActive(true);
				SingletonMonoBehaviour<CursorManager>.Instance.SetCursorShowHide(show: true);
				SingletonMonoBehaviour<CursorManager>.Instance.MoveCursorToCenter();
				CS_0024_003C_003E8__locals23.waitAccept();
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003CloadAssetTask_003E5__4 = default(UniTask);
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CloadAssetTask_003E5__4 = default(UniTask);
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
	private struct _003CLoadAssets_003Ed__65 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Boot _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Boot boot = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					Debug.Log((object)"LoadAssets");
					new CancellationTokenSource();
					UniTask val = LoadAppData.LoadAppDataAsset();
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CLoadAssets_003Ed__65>(ref val2, ref this);
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
				boot.assetLoadComplete = true;
				Debug.Log((object)"assetLoadComplete!!");
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
	private struct _003CResume_003Ed__58 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Boot _003C_003E4__this;

		public int datanum;

		public string datapath;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Boot boot = _003C_003E4__this;
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
						goto IL_011c;
					}
					SingletonMonoBehaviour<CursorManager>.Instance.SetCursorShowHide(show: false);
					val2 = boot.showWelcome();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CResume_003Ed__58>(ref val, ref this);
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
				SingletonMonoBehaviour<Settings>.Instance.saveNumber = datanum;
				SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = true;
				SingletonMonoBehaviour<Settings>.Instance.nowSaveFile = datapath + SaveRelayer.EXTENTION;
				val2 = UnityAsyncExtensions.ToUniTask(Resources.UnloadUnusedAssets(), (IProgress<float>)null, (PlayerLoopTiming)8, default(CancellationToken), false);
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CResume_003Ed__58>(ref val, ref this);
					return;
				}
				goto IL_011c;
				IL_011c:
				((Awaiter)(ref val)).GetResult();
				SceneManager.LoadSceneAsync("WindowUITestScene");
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
	private struct _003CStartGame_003Ed__60 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Boot _003C_003E4__this;

		public int saveNumber;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Boot boot = _003C_003E4__this;
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
						goto IL_0102;
					}
					SingletonMonoBehaviour<CursorManager>.Instance.SetCursorShowHide(show: false);
					val2 = boot.showWelcome(startover: true);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartGame_003Ed__60>(ref val, ref this);
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
				SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = false;
				SingletonMonoBehaviour<Settings>.Instance.saveNumber = saveNumber;
				val2 = UnityAsyncExtensions.ToUniTask(Resources.UnloadUnusedAssets(), (IProgress<float>)null, (PlayerLoopTiming)8, default(CancellationToken), false);
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartGame_003Ed__60>(ref val, ref this);
					return;
				}
				goto IL_0102;
				IL_0102:
				((Awaiter)(ref val)).GetResult();
				SceneManager.LoadScene("WindowUITestScene");
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
	private struct _003CshowWelcome_003Ed__59 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Boot _003C_003E4__this;

		public bool startover;

		private TweenAwaiter _003C_003Eu__1;

		private Awaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_026b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_0237: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Boot boot = _003C_003E4__this;
			try
			{
				TweenAwaiter val2;
				Awaiter val;
				UniTask val3;
				switch (num)
				{
				default:
					boot.ChooseDay.alpha = 0f;
					boot.ChooseDay.interactable = false;
					boot.ChooseDay.blocksRaycasts = false;
					boot.Welcome.alpha = 1f;
					boot.Welcome.interactable = true;
					boot.Welcome.blocksRaycasts = true;
					if ((Object)(object)SingletonMonoBehaviour<ControllerGuideManager>.Instance != (Object)null)
					{
						SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = false;
					}
					boot.WelcomeText.text = NgoEx.SystemTextFromType(SystemTextType.Window_Welcome, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
					AudioManager.Instance?.StopBgm();
					AudioManager.Instance?.PlaySeByType(SoundType.SE_command_execute);
					if (!startover)
					{
						boot.WelcomeIcon.sprite = boot.ten;
						goto IL_0220;
					}
					boot.WelcomeIcon.sprite = boot.ame;
					val2 = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOScale(((Component)boot.WelcomeIcon).gameObject.transform, new Vector3(0f, 2f, 1f), 0.2f)));
					if (!((TweenAwaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CshowWelcome_003Ed__59>(ref val2, ref this);
						return;
					}
					goto IL_0180;
				case 0:
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0180;
				case 1:
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0219;
				case 2:
					{
						val = _003C_003Eu__2;
						_003C_003Eu__2 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0219:
					((TweenAwaiter)(ref val2)).GetResult();
					goto IL_0220;
					IL_0220:
					val3 = UniTask.Delay(Constants.FAST, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CshowWelcome_003Ed__59>(ref val, ref this);
						return;
					}
					break;
					IL_0180:
					((TweenAwaiter)(ref val2)).GetResult();
					boot.WelcomeIcon.sprite = boot.ten;
					val2 = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOScale(((Component)boot.WelcomeIcon).gameObject.transform, new Vector3(2f, 2f, 1f), 0.2f)));
					if (!((TweenAwaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CshowWelcome_003Ed__59>(ref val2, ref this);
						return;
					}
					goto IL_0219;
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

	[SerializeField]
	private Button ButtonToTestScene;

	[SerializeField]
	private CanvasGroup Bios;

	[SerializeField]
	private GameObject NSO;

	[SerializeField]
	private CanvasGroup biosBooting;

	[SerializeField]
	private TMP_Text bootingText;

	[SerializeField]
	private CanvasGroup Splash;

	[SerializeField]
	private Image BootImage;

	[SerializeField]
	private Sprite enBoot;

	[SerializeField]
	private CanvasGroup Login;

	[SerializeField]
	private RectTransform openControlPanel;

	[SerializeField]
	private GameObject Hint;

	[SerializeField]
	private Transform endingParent;

	[SerializeField]
	private GameObject _achievedBlock;

	[SerializeField]
	private GameObject _unachievedBlock;

	[SerializeField]
	private Button liveGenButton;

	[SerializeField]
	private CanvasGroup Caution;

	[SerializeField]
	private TMP_Text Caution_Header;

	[SerializeField]
	private TMP_Text Caution_Nakami;

	[SerializeField]
	private TMP_Text Caution_Ok;

	[SerializeField]
	private TMP_Text Caution_Cancel;

	[SerializeField]
	private Button Ok;

	[SerializeField]
	private Button Cancel;

	[SerializeField]
	private CanvasGroup ChooseUser;

	[SerializeField]
	private Button Data1;

	[SerializeField]
	private Button Data2;

	[SerializeField]
	private Button Data3;

	[SerializeField]
	private Button Data0;

	[SerializeField]
	private Sprite ame;

	[SerializeField]
	private Sprite ten;

	[SerializeField]
	private CanvasGroup ChooseDay;

	[SerializeField]
	private Image DataIcon;

	[SerializeField]
	private TMP_Text _Hyouji;

	[SerializeField]
	private Button Back;

	[SerializeField]
	private TMP_Dropdown days;

	[SerializeField]
	private Button StartButton;

	[SerializeField]
	private Button NewAccount;

	[SerializeField]
	private string chosenDay = "";

	[SerializeField]
	private CanvasGroup Welcome;

	[SerializeField]
	private Image WelcomeIcon;

	[SerializeField]
	private TMP_Text WelcomeText;

	private Sequence biosSequence;

	private Sequence splashSequence;

	private string beforeText = "";

	private AsyncOperation asyncLoad;

	private bool assetLoadComplete;

	[SerializeField]
	private Texture2D playstationCoursor;

	private List<GameObject> endingBlocks = new List<GameObject>();

	public void Awake()
	{
		DisposeManager();
		AudioManager.Instance.StopAll();
		CleanEnds();
	}

	private void DisposeManager()
	{
		if ((Object)(object)PostEffectManager.Instance != (Object)null)
		{
			PostEffectManager.Instance.Dispose();
		}
	}

	public async void Start()
	{
		Debug.Log((object)"Start1");
		((Component)liveGenButton).gameObject.SetActive(true);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>(Observable.Skip<LanguageType>(Observable.DistinctUntilChanged<LanguageType>(Observable.Select<Unit, LanguageType>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, LanguageType>)((Unit _) => SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value))), 1), (Action<LanguageType>)delegate(LanguageType lang)
		{
			ChangeLanguage(lang);
		}), ((Component)this).gameObject);
		if ((Object)(object)ButtonToTestScene != (Object)null)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(ButtonToTestScene), (Action<Unit>)delegate
			{
				OnDebugButtonClicked();
			}), ((Component)this).gameObject);
		}
		Debug.Log((object)"Start2");
		if (SaveRelayer.IsSettingDataExists())
		{
			SingletonMonoBehaviour<Settings>.Instance.Load();
			if (SingletonMonoBehaviour<Settings>.Instance.adieu)
			{
				SingletonMonoBehaviour<Settings>.Instance.saveNumber = 0;
				SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = true;
				SingletonMonoBehaviour<Settings>.Instance.nowSaveFile = "Data0_Day30" + SaveRelayer.EXTENTION;
				SceneManager.LoadScene("WindowUITestScene");
			}
			if (SingletonMonoBehaviour<Settings>.Instance.mitaEnd.Contains(EndingType.Ending_Grand) && SingletonMonoBehaviour<Settings>.Instance.mitaEnd.Contains(EndingType.Ending_Happy))
			{
				Hint.SetActive(true);
			}
			List<EndingType> list = SingletonMonoBehaviour<Settings>.Instance.mitaEnd.Distinct().ToList();
			list.Remove(EndingType.Ending_NetShut);
			if (list.Count >= 24)
			{
				((Component)Data0).gameObject.SetActive(true);
			}
		}
		else
		{
			if ((int)Application.systemLanguage == 22)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.JP);
			}
			else if ((int)Application.systemLanguage == 23)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.KO);
			}
			else if ((int)Application.systemLanguage == 41)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.TW);
			}
			else if ((int)Application.systemLanguage == 39)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.VN);
			}
			else if ((int)Application.systemLanguage == 6 || (int)Application.systemLanguage == 40)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.CN);
			}
			else if ((int)Application.systemLanguage == 14)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.FR);
			}
			else if ((int)Application.systemLanguage == 21)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.IT);
			}
			else if ((int)Application.systemLanguage == 15)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.GE);
			}
			else if ((int)Application.systemLanguage == 34)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.SP);
			}
			else if ((int)Application.systemLanguage == 30)
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.RU);
			}
			else
			{
				SingletonMonoBehaviour<Settings>.Instance.ChangeLanguage(LanguageType.EN);
			}
			SingletonMonoBehaviour<Settings>.Instance.SetResolution();
			SingletonMonoBehaviour<Settings>.Instance.Save();
		}
		ShowEnds();
		Debug.Log((object)"Start3");
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(((Component)Bios).gameObject.GetComponent<Button>()), (Action<Unit>)delegate
		{
			onClickBios();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(((Component)Splash).gameObject.GetComponent<Button>()), (Action<Unit>)delegate
		{
			onClickSplash();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate(LanguageType lang)
		{
			SetCaution(lang);
		}), ((Component)this).gameObject);
		NSO.SetActive(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN);
		SingletonMonoBehaviour<Settings>.Instance.AddCreditImage();
		((Component)Login).gameObject.SetActive(false);
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursorShowHide(show: false);
		Debug.Log((object)"Start4");
		await BootOS();
	}

	private void onClickBios()
	{
		Debug.Log((object)"onClickBios");
		if (assetLoadComplete)
		{
			Debug.Log((object)"onClickBios:assetLoadComplete");
			TweenExtensions.Kill((Tween)(object)biosSequence, true);
		}
	}

	private void onClickSplash()
	{
		Debug.Log((object)"onClickSplash");
		if (assetLoadComplete)
		{
			Debug.Log((object)"onClickSplash:assetLoadComplete");
			TweenExtensions.Kill((Tween)(object)splashSequence, true);
		}
	}

	[AsyncStateMachine(typeof(_003CBootOS_003Ed__51))]
	public UniTask BootOS()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CBootOS_003Ed__51 _003CBootOS_003Ed__52 = default(_003CBootOS_003Ed__51);
		_003CBootOS_003Ed__52._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CBootOS_003Ed__52._003C_003E4__this = this;
		_003CBootOS_003Ed__52._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CBootOS_003Ed__52._003C_003Et__builder)).Start<_003CBootOS_003Ed__51>(ref _003CBootOS_003Ed__52);
		return ((AsyncUniTaskMethodBuilder)(ref _003CBootOS_003Ed__52._003C_003Et__builder)).Task;
	}

	private void waitAccept()
	{
		Debug.Log((object)"waitAccept:1");
		AudioManager.Instance.PlaySeByType(SoundType.SE_Boot_Caution);
		AudioManager.Instance.PlayBgmById("BGM_OP_PV");
		Login.alpha = 1f;
		Login.interactable = true;
		ChooseDay.alpha = 0f;
		ChooseDay.interactable = false;
		ChooseDay.blocksRaycasts = false;
		ChooseUser.alpha = 0f;
		ChooseUser.interactable = false;
		ChooseUser.blocksRaycasts = false;
		Welcome.alpha = 0f;
		Welcome.interactable = false;
		Welcome.blocksRaycasts = false;
		if ((Object)(object)SingletonMonoBehaviour<ControllerGuideManager>.Instance != (Object)null)
		{
			SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = true;
		}
		Debug.Log((object)"waitAccept:2");
		SetCaution(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(Ok), (Action<Unit>)delegate
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			Debug.Log((object)"waitAccept:3");
			openControlPanel.anchoredPosition = new Vector2(50f, -60f);
			WaitChooseUser();
		}), (Component)(object)Ok);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(Cancel), (Action<Unit>)delegate
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
			Application.Quit();
		}), (Component)(object)Cancel);
		((Component)Cancel).gameObject.SetActive(true);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(Data1), (Action<Unit>)delegate
		{
			WaitChooseDay(1);
		}), (Component)(object)Data1);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(Data2), (Action<Unit>)delegate
		{
			WaitChooseDay(2);
		}), (Component)(object)Data2);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(Data3), (Action<Unit>)delegate
		{
			WaitChooseDay(3);
		}), (Component)(object)Data3);
		Debug.Log((object)"waitAccept:END");
	}

	private void WaitChooseUser()
	{
		AudioManager.Instance.StopByType(SoundType.SE_BIOS_HDD);
		AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
		Caution.alpha = 0f;
		Caution.interactable = false;
		Caution.blocksRaycasts = false;
		((Component)Caution).gameObject.SetActive(false);
		ChooseDay.alpha = 0f;
		ChooseDay.interactable = false;
		ChooseDay.blocksRaycasts = false;
		Welcome.alpha = 0f;
		Welcome.interactable = false;
		Welcome.blocksRaycasts = false;
		ChooseUser.alpha = 1f;
		ChooseUser.interactable = true;
		ChooseUser.blocksRaycasts = true;
		if (SaveRelayer.IsSlotDataExists("Data1_Day1" + SaveRelayer.EXTENTION))
		{
			((Component)((Component)Data1).gameObject.transform.GetChild(0)).GetComponent<Image>().sprite = ten;
		}
		else
		{
			((Component)((Component)Data1).gameObject.transform.GetChild(0)).GetComponent<Image>().sprite = ame;
		}
		if (SaveRelayer.IsSlotDataExists("Data2_Day1" + SaveRelayer.EXTENTION))
		{
			((Component)((Component)Data2).gameObject.transform.GetChild(0)).GetComponent<Image>().sprite = ten;
		}
		else
		{
			((Component)((Component)Data2).gameObject.transform.GetChild(0)).GetComponent<Image>().sprite = ame;
		}
		if (SaveRelayer.IsSlotDataExists("Data3_Day1" + SaveRelayer.EXTENTION))
		{
			((Component)((Component)Data3).gameObject.transform.GetChild(0)).GetComponent<Image>().sprite = ten;
		}
		else
		{
			((Component)((Component)Data3).gameObject.transform.GetChild(0)).GetComponent<Image>().sprite = ame;
		}
	}

	private void SetCaution(LanguageType lang)
	{
		Caution_Header.text = NgoEx.SystemTextFromType(SystemTextType.System_caution_title, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		Caution_Nakami.text = NgoEx.SystemTextFromType(SystemTextType.System_caution, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		Caution_Ok.text = NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		Caution_Cancel.text = NgoEx.SystemTextFromType(SystemTextType.Dialog_Cancell, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	private void WaitChooseDay(int _DataNumber)
	{
		Caution.alpha = 0f;
		Caution.interactable = false;
		Caution.blocksRaycasts = false;
		ChooseUser.alpha = 0f;
		ChooseUser.interactable = false;
		ChooseUser.blocksRaycasts = false;
		Welcome.alpha = 0f;
		Welcome.interactable = false;
		Welcome.blocksRaycasts = false;
		ChooseDay.alpha = 1f;
		ChooseDay.interactable = true;
		ChooseDay.blocksRaycasts = true;
		SingletonMonoBehaviour<Settings>.Instance.saveNumber = _DataNumber;
		AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
		((Component)Back).gameObject.GetComponentInChildren<TMP_Text>().text = "◀";
		_Hyouji.text = $"Data{_DataNumber}";
		SetChosenDayText(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value, _DataNumber);
		setChosenDay();
		IDisposable disp0 = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate(LanguageType lang)
		{
			SetChosenDayText(lang, _DataNumber);
		}), ((Component)this).gameObject);
		IDisposable disp1 = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(NewAccount), (Action<Unit>)async delegate
		{
			await StartGame(_DataNumber);
		}), ((Component)this).gameObject);
		IDisposable disp2 = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(UnityUIComponentExtensions.OnClickAsObservable(StartButton), (Func<Unit, bool>)((Unit _) => chosenDay == "Day1")), (Action<Unit>)async delegate
		{
			await StartGame(_DataNumber);
		}), ((Component)this).gameObject);
		IDisposable disp3 = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(Observable.Where<Unit>(UnityUIComponentExtensions.OnClickAsObservable(StartButton), (Func<Unit, bool>)((Unit _) => chosenDay != "Day1")), (Action<Unit>)async delegate
		{
			await Resume(_DataNumber, $"Data{_DataNumber}_{chosenDay}");
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(Back), (Action<Unit>)delegate
		{
			((UnityEventBase)days.onValueChanged).RemoveAllListeners();
			disp0.Dispose();
			disp1.Dispose();
			disp2.Dispose();
			disp3.Dispose();
			WaitChooseUser();
		}), (Component)(object)Back);
	}

	private void SetChosenDayText(LanguageType lang, int _DataNumber)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		days.options.Clear();
		for (int num = 30; num >= 2; num--)
		{
			if (SaveRelayer.IsSlotDataExists($"Data{_DataNumber}_Day{num}{SaveRelayer.EXTENTION}"))
			{
				days.options.Add(new OptionData
				{
					text = NgoEx.DayText(num, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)
				});
			}
		}
		days.options.Add(new OptionData
		{
			text = NgoEx.DayText(1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)
		});
		days.RefreshShownValue();
		if (SaveRelayer.IsSlotDataExists($"Data{_DataNumber}_Day1{SaveRelayer.EXTENTION}"))
		{
			DataIcon.sprite = ten;
			((Component)NewAccount).gameObject.SetActive(true);
			((Component)NewAccount).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Newgame01, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			((Component)StartButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Continue, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else
		{
			DataIcon.sprite = ame;
			((Component)NewAccount).gameObject.SetActive(false);
			((Component)StartButton).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Newgame00, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
	}

	private void setChosenDay()
	{
		chosenDay = "Day" + Regex.Replace(days.options[days.value].text, "[^0-9]", "");
		((UnityEvent<int>)(object)days.onValueChanged).AddListener((UnityAction<int>)delegate
		{
			chosenDay = "Day" + Regex.Replace(days.options[days.value].text, "[^0-9]", "");
		});
	}

	[AsyncStateMachine(typeof(_003CResume_003Ed__58))]
	private UniTask Resume(int datanum, string datapath)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CResume_003Ed__58 _003CResume_003Ed__59 = default(_003CResume_003Ed__58);
		_003CResume_003Ed__59._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CResume_003Ed__59._003C_003E4__this = this;
		_003CResume_003Ed__59.datanum = datanum;
		_003CResume_003Ed__59.datapath = datapath;
		_003CResume_003Ed__59._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CResume_003Ed__59._003C_003Et__builder)).Start<_003CResume_003Ed__58>(ref _003CResume_003Ed__59);
		return ((AsyncUniTaskMethodBuilder)(ref _003CResume_003Ed__59._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CshowWelcome_003Ed__59))]
	private UniTask showWelcome(bool startover = false)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CshowWelcome_003Ed__59 _003CshowWelcome_003Ed__60 = default(_003CshowWelcome_003Ed__59);
		_003CshowWelcome_003Ed__60._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CshowWelcome_003Ed__60._003C_003E4__this = this;
		_003CshowWelcome_003Ed__60.startover = startover;
		_003CshowWelcome_003Ed__60._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CshowWelcome_003Ed__60._003C_003Et__builder)).Start<_003CshowWelcome_003Ed__59>(ref _003CshowWelcome_003Ed__60);
		return ((AsyncUniTaskMethodBuilder)(ref _003CshowWelcome_003Ed__60._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CStartGame_003Ed__60))]
	private UniTask StartGame(int saveNumber)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CStartGame_003Ed__60 _003CStartGame_003Ed__61 = default(_003CStartGame_003Ed__60);
		_003CStartGame_003Ed__61._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CStartGame_003Ed__61._003C_003E4__this = this;
		_003CStartGame_003Ed__61.saveNumber = saveNumber;
		_003CStartGame_003Ed__61._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CStartGame_003Ed__61._003C_003Et__builder)).Start<_003CStartGame_003Ed__60>(ref _003CStartGame_003Ed__61);
		return ((AsyncUniTaskMethodBuilder)(ref _003CStartGame_003Ed__61._003C_003Et__builder)).Task;
	}

	private void CleanEnds()
	{
		foreach (GameObject endingBlock in endingBlocks)
		{
			Object.Destroy((Object)(object)endingBlock);
		}
		endingBlocks = new List<GameObject>();
	}

	private void ShowEnds()
	{
		List<EndingType> mitaEnd = SingletonMonoBehaviour<Settings>.Instance.mitaEnd;
		string id;
		foreach (EndingType value in Enum.GetValues(typeof(EndingType)))
		{
			if (value != EndingType.Ending_None && value != EndingType.Ending_Completed && value != EndingType.Ending_NetShut)
			{
				EndingMaster.Param param = NgoEx.EndingFromType(value);
				id = param.Id;
				NgoEx.SetEndingTextByLanguage(param, out var endName, out var endJisseki);
				if (mitaEnd.Exists((EndingType gotend) => gotend.ToString() == id))
				{
					GameObject val = Object.Instantiate<GameObject>(_achievedBlock, endingParent);
					val.GetComponent<TooltipCaller>().isShowTooltip = true;
					val.GetComponent<TooltipCaller>().textNakami = endName + "\n" + endJisseki;
					endingBlocks.Add(val);
				}
				else
				{
					GameObject val2 = Object.Instantiate<GameObject>(_unachievedBlock, endingParent);
					val2.GetComponent<TooltipCaller>().isShowTooltip = true;
					val2.GetComponent<TooltipCaller>().textNakami = endName + "\n" + endJisseki;
					endingBlocks.Add(val2);
				}
			}
		}
	}

	private void ChangeLanguage(LanguageType lang)
	{
		CleanEnds();
		ShowEnds();
	}

	[AsyncStateMachine(typeof(_003CLoadAssets_003Ed__65))]
	private UniTask LoadAssets()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadAssets_003Ed__65 _003CLoadAssets_003Ed__66 = default(_003CLoadAssets_003Ed__65);
		_003CLoadAssets_003Ed__66._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CLoadAssets_003Ed__66._003C_003E4__this = this;
		_003CLoadAssets_003Ed__66._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CLoadAssets_003Ed__66._003C_003Et__builder)).Start<_003CLoadAssets_003Ed__65>(ref _003CLoadAssets_003Ed__66);
		return ((AsyncUniTaskMethodBuilder)(ref _003CLoadAssets_003Ed__66._003C_003Et__builder)).Task;
	}

	public List<GameObject> GetSelectableObjects()
	{
		List<GameObject> list = new List<GameObject>();
		if (SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Count > 0)
		{
			IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.WindowList.FirstOrDefault((IWindow w) => w.activeState == ActiveState.Active);
			switch (window.appType)
			{
			case AppType.ControlPanel:
				list = window.nakamiApp.GetComponent<ControllPanelView>().GetSelectableObjects();
				break;
			case AppType.MyPicture:
				list.AddRange(from btn in window.nakamiApp.GetComponentsInChildren<Button>()
					select ((Component)btn).gameObject);
				break;
			case AppType.LastEnd:
				list.AddRange(window.nakamiApp.GetComponent<adieuDialog>().SelectableObjects);
				break;
			}
		}
		else if (Caution.interactable)
		{
			list.Add(((Component)Ok).gameObject);
		}
		else if (ChooseUser.interactable)
		{
			list.Add(((Component)Data1).gameObject);
			list.Add(((Component)Data2).gameObject);
			list.Add(((Component)Data3).gameObject);
		}
		else if (ChooseDay.interactable && !Object.op_Implicit((Object)(object)((Component)days).GetComponentInChildren<ScrollRect>(false)))
		{
			list.Add(((Component)StartButton).gameObject);
			list.Add(((Component)days).gameObject);
		}
		return list;
	}

	public GameObject GetCancelObject()
	{
		if (ChooseDay.interactable && SingletonMonoBehaviour<WindowManager>.Instance.WindowList.Count <= 0)
		{
			return ((Component)Back).gameObject;
		}
		return null;
	}

	public void OnDebugButtonClicked()
	{
		SingletonMonoBehaviour<Settings>.Instance.saveNumber = 4;
		SceneManager.LoadScene("Window2DTestScene");
	}
}
