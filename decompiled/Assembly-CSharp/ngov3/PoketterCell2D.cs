using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
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
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

namespace ngov3;

public class PoketterCell2D : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public string imageId;

		public ResourceLocal resource;

		internal bool _003CFetchTweetImage_003Eb__0(ResourceLocal r)
		{
			return r.FileName == imageId;
		}

		internal void _003CFetchTweetImage_003Eb__2()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			ImageViewerHelper.OpenImageViewer(resource.FileName);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass45_0
	{
		public VideoPlayer videoViewer;

		internal bool _003CPlayMV_003Eb__0()
		{
			return videoViewer.isPrepared;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CAnimate_003Ed__40 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterCell2D _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCell2D poketterCell2D = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					UniTask val = poketterCell2D.Show();
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAnimate_003Ed__40>(ref val2, ref this);
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
				poketterCell2D.FavRtMove();
				UniTaskExtensions.Forget(poketterCell2D.ShowKusoReps());
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
	private struct _003CFetchTweetImage_003Ed__44 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

		public PoketterCell2D _003C_003E4__this;

		private _003C_003Ec__DisplayClass44_0 _003C_003E8__1;

		private bool _003ChasImage_003E5__2;

		private Awaiter<Sprite> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Expected O, but got Unknown
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Expected O, but got Unknown
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCell2D CS_0024_003C_003E8__locals10 = _003C_003E4__this;
			bool result;
			try
			{
				Awaiter<Sprite> val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<Sprite>);
					num = (_003C_003E1__state = -1);
					goto IL_0158;
				}
				_003ChasImage_003E5__2 = CS_0024_003C_003E8__locals10.tweetDrawable.ImageId.IsNotEmpty();
				((Component)CS_0024_003C_003E8__locals10._image).gameObject.SetActive(_003ChasImage_003E5__2);
				if (!_003ChasImage_003E5__2)
				{
					goto IL_01e1;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass44_0();
				_003C_003E8__1.imageId = CS_0024_003C_003E8__locals10.tweetDrawable.ImageId;
				_003C_003E8__1.resource = CS_0024_003C_003E8__locals10._resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == _003C_003E8__1.imageId);
				if (_003C_003E8__1.resource != null)
				{
					SingletonMonoBehaviour<Settings>.Instance.addImage(_003C_003E8__1.imageId);
					val = LoadPictures.LoadPictureAsync(_003C_003E8__1.resource.FileName, LoadPictures.PictureType.Poketter).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CFetchTweetImage_003Ed__44>(ref val, ref this);
						return;
					}
					goto IL_0158;
				}
				Debug.Log((object)("TWEET MASTERリソースがないよ！:" + _003C_003E8__1.imageId));
				((Component)CS_0024_003C_003E8__locals10._image).gameObject.SetActive(false);
				result = false;
				goto end_IL_000e;
				IL_01e1:
				result = _003ChasImage_003E5__2;
				goto end_IL_000e;
				IL_0158:
				Sprite result2 = val.GetResult();
				CS_0024_003C_003E8__locals10._image.sprite = result2;
				CS_0024_003C_003E8__locals10._imageFileName = _003C_003E8__1.resource.FileName;
				if (!(_003C_003E8__1.imageId == "MV_thumbnail"))
				{
					((UnityEvent)((Button)CS_0024_003C_003E8__locals10.imageButton).onClick).AddListener((UnityAction)delegate
					{
						//IL_000b: Unknown result type (might be due to invalid IL or missing references)
						ImageViewerHelper.OpenImageViewer(_003C_003E8__1.resource.FileName);
					});
					_003C_003E8__1 = null;
					goto IL_01e1;
				}
				((UnityEvent)((Button)CS_0024_003C_003E8__locals10.imageButton).onClick).AddListener((UnityAction)async delegate
				{
					await CS_0024_003C_003E8__locals10.PlayMV();
				});
				result = true;
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_003C_003Et__builder.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CPlayMV_003Ed__45 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterCell2D _003C_003E4__this;

		private _003C_003Ec__DisplayClass45_0 _003C_003E8__1;

		private Awaiter _003C_003Eu__1;

		private Awaiter<int> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCell2D poketterCell2D = _003C_003E4__this;
			try
			{
				UniTask val3;
				Awaiter val2;
				Awaiter<int> val;
				switch (num)
				{
				default:
					_003C_003E8__1 = new _003C_003Ec__DisplayClass45_0();
					((Behaviour)poketterCell2D.imageButton).enabled = false;
					SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(ShortcutInputManager.ControllerMode.MV_Playing);
					_003C_003E8__1.videoViewer = GameObject.Find("Main Camera").GetComponent<VideoPlayer>();
					_003C_003E8__1.videoViewer.clip = Resources.Load<VideoClip>("Videos/INTERNETOVERDOSE");
					_003C_003E8__1.videoViewer.Prepare();
					val3 = UniTask.WaitUntil((Func<bool>)(() => _003C_003E8__1.videoViewer.isPrepared), (PlayerLoopTiming)8, UniTaskCancellationExtensions.GetCancellationTokenOnDestroy((MonoBehaviour)(object)poketterCell2D), false);
					val2 = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlayMV_003Ed__45>(ref val2, ref this);
						return;
					}
					goto IL_00f5;
				case 0:
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00f5;
				case 1:
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01b2;
				case 2:
					{
						val = _003C_003Eu__2;
						_003C_003Eu__2 = default(Awaiter<int>);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_01b2:
					((Awaiter)(ref val2)).GetResult();
					AudioManager.Instance.PlayBgmByType(SoundType.BGM_InternetOverdose);
					val = UniTask.WhenAny((UniTask[])(object)new UniTask[2]
					{
						NgoEvent.DelaySkippable(224000),
						UniTask.WaitUntil((Func<bool>)(() => SingletonMonoBehaviour<ShortcutInputManager>.Instance.Player.GetButtonDown("StopPlaying")), (PlayerLoopTiming)8, default(CancellationToken), false)
					}).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<int>, _003CPlayMV_003Ed__45>(ref val, ref this);
						return;
					}
					break;
					IL_00f5:
					((Awaiter)(ref val2)).GetResult();
					_003C_003E8__1.videoViewer.aspectRatio = (VideoAspectRatio)3;
					_003C_003E8__1.videoViewer.SetDirectAudioVolume((ushort)0, SingletonMonoBehaviour<Settings>.Instance.BgmVolume);
					AudioManager.Instance.StopBgm();
					_003C_003E8__1.videoViewer.targetCameraAlpha = 1f;
					_003C_003E8__1.videoViewer.Play();
					val3 = NgoEvent.DelaySkippable(2000);
					val2 = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlayMV_003Ed__45>(ref val2, ref this);
						return;
					}
					goto IL_01b2;
				}
				val.GetResult();
				_003C_003E8__1.videoViewer.targetCameraAlpha = 0f;
				_003C_003E8__1.videoViewer.Stop();
				AudioManager.Instance.PlayBgmByType(SoundType.BGM_InternetOverdose8bit, isLoop: true);
				_003C_003E8__1.videoViewer.aspectRatio = (VideoAspectRatio)2;
				((Behaviour)poketterCell2D.imageButton).enabled = true;
				SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(ShortcutInputManager.ControllerMode.Desktop);
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
	private struct _003CSetData_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterCell2D _003C_003E4__this;

		public TweetDrawable nakami;

		private Awaiter<bool> _003C_003Eu__1;

		private Awaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCell2D poketterCell2D = _003C_003E4__this;
			try
			{
				Awaiter val;
				Awaiter<bool> val2;
				if (num != 0)
				{
					if (num == 1)
					{
						val = _003C_003Eu__2;
						_003C_003Eu__2 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01a2;
					}
					poketterCell2D.fader.SetAlpha(0f);
					poketterCell2D.tweetDrawable = nakami;
					poketterCell2D.SetUserIcon();
					poketterCell2D.SetUserName();
					poketterCell2D.FetchBody();
					if (poketterCell2D.tweetDrawable.Day >= 30)
					{
						poketterCell2D._dateText.text = "????";
					}
					else
					{
						poketterCell2D._dateText.text = NgoEx.DayText(poketterCell2D.tweetDrawable.Day, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) + " " + NgoEx.CmdName(poketterCell2D.tweetDrawable.cmdType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
					}
					val2 = poketterCell2D.FetchTweetImage().GetAwaiter();
					if (!val2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<bool>, _003CSetData_003Ed__38>(ref val2, ref this);
						return;
					}
				}
				else
				{
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<bool>);
					num = (_003C_003E1__state = -1);
				}
				bool result = val2.GetResult();
				poketterCell2D._imageExist = result;
				poketterCell2D.SetLayout(poketterCell2D._imageExist);
				if (poketterCell2D._imageExist)
				{
					UniTask val3 = UniTask.DelayFrame(1, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CSetData_003Ed__38>(ref val, ref this);
						return;
					}
					goto IL_01a2;
				}
				goto IL_01a9;
				IL_01a2:
				((Awaiter)(ref val)).GetResult();
				goto IL_01a9;
				IL_01a9:
				if (!poketterCell2D._imageExist && poketterCell2D._bodyText.text == "\"")
				{
					Debug.Log((object)"ここで本文・Imageともに空だった場合はTweetを破棄する");
					((Component)poketterCell2D).gameObject.SetActive(false);
				}
				if (poketterCell2D._bodyText.text == "" || poketterCell2D._bodyText.text == "N/A" || poketterCell2D._bodyText.text == "”")
				{
					Debug.Log((object)"bodyTextがN/Aか空文字だった場合はTweetを破棄する");
					((Component)poketterCell2D).gameObject.SetActive(false);
				}
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
	private struct _003CSetDataStatic_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterCell2D _003C_003E4__this;

		public TweetDrawable nakami;

		private Awaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCell2D poketterCell2D = _003C_003E4__this;
			try
			{
				Awaiter<bool> val;
				if (num != 0)
				{
					poketterCell2D.tweetDrawable = nakami;
					poketterCell2D.SetUserIcon();
					poketterCell2D.SetUserName();
					poketterCell2D.FetchBody();
					if (poketterCell2D.tweetDrawable.Day >= 30)
					{
						poketterCell2D._dateText.text = "????";
					}
					else
					{
						poketterCell2D._dateText.text = NgoEx.DayText(poketterCell2D.tweetDrawable.Day, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) + " " + NgoEx.CmdName(poketterCell2D.tweetDrawable.cmdType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
					}
					val = poketterCell2D.FetchTweetImage().GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<bool>, _003CSetDataStatic_003Ed__39>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<bool>);
					num = (_003C_003E1__state = -1);
				}
				bool result = val.GetResult();
				poketterCell2D._imageExist = result;
				poketterCell2D.SetLayout(poketterCell2D._imageExist);
				UniTaskExtensions.Forget(poketterCell2D.SetKusoRepStatic());
				poketterCell2D._rtText.text = poketterCell2D.ConvertGigaNumber(nakami.RtNumber);
				poketterCell2D._favText.text = poketterCell2D.ConvertGigaNumber(nakami.FavNumber);
				Debug.Log((object)"描画判定");
				if (!poketterCell2D._imageExist && poketterCell2D._bodyText.text == "")
				{
					Debug.Log((object)"ここで本文・Imageともに空だった場合はTweetを破棄する");
					((Component)poketterCell2D).gameObject.SetActive(false);
				}
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
	private struct _003CSetKusoRepStatic_003Ed__49 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterCell2D _003C_003E4__this;

		private List<KusoRepDrawable>.Enumerator _003C_003E7__wrap1;

		private KusoRepView2D _003Ckusorep_003E5__3;

		private Awaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCell2D poketterCell2D = _003C_003E4__this;
			try
			{
				if (num != 0)
				{
					if (poketterCell2D.tweetDrawable.kusoReps.Count > 0)
					{
						((Behaviour)poketterCell2D._kusorepParentGroup).enabled = true;
					}
					_003C_003E7__wrap1 = poketterCell2D.tweetDrawable.kusoReps.GetEnumerator();
				}
				try
				{
					if (num != 0)
					{
						goto IL_0103;
					}
					Awaiter<bool> val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_00e9;
					IL_00e9:
					val.GetResult();
					_003Ckusorep_003E5__3.ShowPosted();
					_003Ckusorep_003E5__3 = null;
					goto IL_0103;
					IL_0103:
					if (_003C_003E7__wrap1.MoveNext())
					{
						KusoRepDrawable current = _003C_003E7__wrap1.Current;
						_003Ckusorep_003E5__3 = Object.Instantiate<KusoRepView2D>(poketterCell2D._kusoRepPrefab, ((Component)poketterCell2D._kusoRepRoot).transform);
						poketterCell2D._kusoreps.Add(_003Ckusorep_003E5__3);
						val = _003Ckusorep_003E5__3.SetData(current).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<bool>, _003CSetKusoRepStatic_003Ed__49>(ref val, ref this);
							return;
						}
						goto IL_00e9;
					}
				}
				finally
				{
					if (num < 0)
					{
						((IDisposable)_003C_003E7__wrap1/*cast due to constrained. prefix*/).Dispose();
					}
				}
				_003C_003E7__wrap1 = default(List<KusoRepDrawable>.Enumerator);
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
	private struct _003CShow_003Ed__46 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterCell2D _003C_003E4__this;

		private TweenAwaiter _003C_003Eu__1;

		private Awaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCell2D poketterCell2D = _003C_003E4__this;
			try
			{
				TweenAwaiter val2;
				Awaiter val;
				UniTask val3;
				switch (num)
				{
				default:
				{
					poketterCell2D.fader.SetAlpha(0f);
					RectTransform component = ((Component)poketterCell2D).GetComponent<RectTransform>();
					((Transform)component).localScale = new Vector3(1f, 0f, 1f);
					float num2 = (float)poketterCell2D._scrollMillisecond / 1000f;
					val2 = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOScaleY((Transform)(object)component, 1f, num2)));
					if (!((TweenAwaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CShow_003Ed__46>(ref val2, ref this);
						return;
					}
					goto IL_00c1;
				}
				case 0:
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c1;
				case 1:
					val = _003C_003Eu__2;
					_003C_003Eu__2 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_013c;
				case 2:
					{
						val = _003C_003Eu__2;
						_003C_003Eu__2 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_013c:
					((Awaiter)(ref val)).GetResult();
					val3 = NgoEvent.DelaySkippable(poketterCell2D._bodyText.text.Length * 10);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CShow_003Ed__46>(ref val, ref this);
						return;
					}
					break;
					IL_00c1:
					((TweenAwaiter)(ref val2)).GetResult();
					val3 = poketterCell2D.fader.DOFade(1f, 1f);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CShow_003Ed__46>(ref val, ref this);
						return;
					}
					goto IL_013c;
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
	private struct _003CShowKusoReps_003Ed__50 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterCell2D _003C_003E4__this;

		private List<KusoRepDrawable>.Enumerator _003C_003E7__wrap1;

		private Awaiter<bool> _003C_003Eu__1;

		private Awaiter _003C_003Eu__2;

		private int _003Ci_003E5__3;

		private void MoveNext()
		{
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCell2D poketterCell2D = _003C_003E4__this;
			try
			{
				UniTask val3;
				Awaiter val;
				switch (num)
				{
				default:
					if (poketterCell2D.tweetDrawable.kusoReps.Count > 0)
					{
						((Behaviour)poketterCell2D._kusorepParentGroup).enabled = true;
					}
					_003C_003E7__wrap1 = poketterCell2D.tweetDrawable.kusoReps.GetEnumerator();
					goto case 0;
				case 0:
					try
					{
						if (num != 0)
						{
							goto IL_00f1;
						}
						Awaiter<bool> val2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_00e9;
						IL_00e9:
						val2.GetResult();
						goto IL_00f1;
						IL_00f1:
						if (_003C_003E7__wrap1.MoveNext())
						{
							KusoRepDrawable current = _003C_003E7__wrap1.Current;
							KusoRepView2D kusoRepView2D = Object.Instantiate<KusoRepView2D>(poketterCell2D._kusoRepPrefab, ((Component)poketterCell2D._kusoRepRoot).transform);
							poketterCell2D._kusoreps.Add(kusoRepView2D);
							val2 = kusoRepView2D.SetData(current).GetAwaiter();
							if (!val2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = val2;
								((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<bool>, _003CShowKusoReps_003Ed__50>(ref val2, ref this);
								return;
							}
							goto IL_00e9;
						}
					}
					finally
					{
						if (num < 0)
						{
							((IDisposable)_003C_003E7__wrap1/*cast due to constrained. prefix*/).Dispose();
						}
					}
					_003C_003E7__wrap1 = default(List<KusoRepDrawable>.Enumerator);
					if (((Transform)poketterCell2D._kusoRepRoot).childCount != 0)
					{
						val3 = NgoEvent.DelaySkippable(Constants.MIDDLE);
						val = ((UniTask)(ref val3)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CShowKusoReps_003Ed__50>(ref val, ref this);
							return;
						}
						goto IL_0191;
					}
					goto IL_0198;
				case 1:
					val = _003C_003Eu__2;
					_003C_003Eu__2 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0191;
				case 2:
					{
						val = _003C_003Eu__2;
						_003C_003Eu__2 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0211;
					}
					IL_0191:
					((Awaiter)(ref val)).GetResult();
					goto IL_0198;
					IL_0211:
					((Awaiter)(ref val)).GetResult();
					_003Ci_003E5__3++;
					goto IL_022a;
					IL_0198:
					_003Ci_003E5__3 = 0;
					goto IL_022a;
					IL_022a:
					if (_003Ci_003E5__3 < ((Transform)poketterCell2D._kusoRepRoot).childCount)
					{
						val3 = ((Component)((Transform)poketterCell2D._kusoRepRoot).GetChild(_003Ci_003E5__3)).GetComponent<KusoRepView2D>().Show();
						val = ((UniTask)(ref val3)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = val;
							((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CShowKusoReps_003Ed__50>(ref val, ref this);
							return;
						}
						goto IL_0211;
					}
					break;
				}
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
	protected ResourceLocalMaster _resourceMaster;

	[SerializeField]
	protected SpriteRenderer _userIcon;

	[SerializeField]
	protected TMP_Text _userText;

	[SerializeField]
	protected TMP_Text _bodyText;

	[SerializeField]
	protected TMP_Text _dateText;

	[SerializeField]
	protected SpriteRenderer _image;

	[SerializeField]
	protected Sprite _omoteIcon;

	[SerializeField]
	protected Sprite _uraIcon;

	[SerializeField]
	protected TMP_Text _rtText;

	[SerializeField]
	protected TMP_Text _favText;

	[SerializeField]
	private RectTransform _kusoRepRoot;

	[SerializeField]
	private KusoRepView2D _kusoRepPrefab;

	[SerializeField]
	[Header("\ufffdc\ufffdC\ufffd[\ufffdg\ufffd\ufffd\ufffdo\ufffd\ufffd\ufffd\ufffd\ufffd\ufffdƂ\ufffd\ufffdɃX\ufffdN\ufffd\ufffd\ufffd[\ufffd\ufffd\ufffd\ufffd\ufffd鎞\ufffd\ufffd")]
	private int _scrollMillisecond = 1000;

	[Header("\ufffdc\ufffdC\ufffd[\ufffdg\ufffd\ufffd\ufffdt\ufffdF\ufffd[\ufffdh\ufffdC\ufffd\ufffd\ufffd\ufffd\ufffd鎞\ufffd\ufffd")]
	[SerializeField]
	private int _fadeMillisecond = 300;

	[SerializeField]
	[Header("\ufffdo\ufffdY\ufffd\ufffdp\ufffd\ufffd\ufffd[\ufffd\ufffd\ufffde\ufffd\ufffd\ufffde\ufffd\ufffd\ufffd\ufffd\ufffd鎞\ufffd\ufffd")]
	private int _buzzMillisecond = 1000;

	private TweetDrawable tweetDrawable;

	[SerializeField]
	private Fader2D fader;

	[SerializeField]
	private Button2D imageButton;

	private List<KusoRepView2D> _kusoreps = new List<KusoRepView2D>();

	private string _imageFileName = "N/A";

	[Header("Layout Components")]
	[SerializeField]
	protected LayoutElement _postElement;

	[SerializeField]
	protected RectTransform _postRectTr;

	[SerializeField]
	protected LayoutElement _bodyElement;

	[SerializeField]
	protected RectTransform _bodyRectTr;

	[SerializeField]
	protected LayoutElement _userTextElement;

	[SerializeField]
	protected RectTransform _userTextRectTr;

	[SerializeField]
	protected LayoutElement _bodyTextElement;

	[SerializeField]
	protected RectTransform _bodyTextRectTr;

	[SerializeField]
	protected LayoutElement _imageElement;

	[SerializeField]
	protected RectTransform _imageRectTr;

	[SerializeField]
	protected LayoutElement _buzzElement;

	[SerializeField]
	protected RectTransform _buzzRectTr;

	[SerializeField]
	protected LayoutElement _datetElement;

	[SerializeField]
	protected RectTransform _dateRectTr;

	[SerializeField]
	protected VerticalLayoutGroup _kusorepParentGroup;

	private bool _imageExist;

	[SerializeField]
	private ScrolllOverHungObject imageOverHungObject;

	public void Awake()
	{
		((Behaviour)_kusorepParentGroup).enabled = false;
		imageOverHungObject.SetParentRect(((Component)((Component)this).transform.parent.parent).GetComponent<RectTransform>());
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			OnLanguageUpdated();
		}), ((Component)this).gameObject);
	}

	[AsyncStateMachine(typeof(_003CSetData_003Ed__38))]
	public UniTask SetData(TweetDrawable nakami)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CSetData_003Ed__38 _003CSetData_003Ed__39 = default(_003CSetData_003Ed__38);
		_003CSetData_003Ed__39._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CSetData_003Ed__39._003C_003E4__this = this;
		_003CSetData_003Ed__39.nakami = nakami;
		_003CSetData_003Ed__39._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CSetData_003Ed__39._003C_003Et__builder)).Start<_003CSetData_003Ed__38>(ref _003CSetData_003Ed__39);
		return ((AsyncUniTaskMethodBuilder)(ref _003CSetData_003Ed__39._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSetDataStatic_003Ed__39))]
	public UniTask SetDataStatic(TweetDrawable nakami)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CSetDataStatic_003Ed__39 _003CSetDataStatic_003Ed__40 = default(_003CSetDataStatic_003Ed__39);
		_003CSetDataStatic_003Ed__40._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CSetDataStatic_003Ed__40._003C_003E4__this = this;
		_003CSetDataStatic_003Ed__40.nakami = nakami;
		_003CSetDataStatic_003Ed__40._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CSetDataStatic_003Ed__40._003C_003Et__builder)).Start<_003CSetDataStatic_003Ed__39>(ref _003CSetDataStatic_003Ed__40);
		return ((AsyncUniTaskMethodBuilder)(ref _003CSetDataStatic_003Ed__40._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAnimate_003Ed__40))]
	public UniTask Animate()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CAnimate_003Ed__40 _003CAnimate_003Ed__41 = default(_003CAnimate_003Ed__40);
		_003CAnimate_003Ed__41._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CAnimate_003Ed__41._003C_003E4__this = this;
		_003CAnimate_003Ed__41._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CAnimate_003Ed__41._003C_003Et__builder)).Start<_003CAnimate_003Ed__40>(ref _003CAnimate_003Ed__41);
		return ((AsyncUniTaskMethodBuilder)(ref _003CAnimate_003Ed__41._003C_003Et__builder)).Task;
	}

	protected virtual bool SetUserIcon()
	{
		_userIcon.sprite = (tweetDrawable.IsOmote ? _omoteIcon : _uraIcon);
		return (Object)(object)_userIcon.sprite != (Object)null;
	}

	protected virtual bool SetUserName()
	{
		_userText.text = (tweetDrawable.IsOmote ? NgoEx.SystemTextFromType(SystemTextType.Account_Omote, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) : NgoEx.SystemTextFromType(SystemTextType.Account_Ura_Name, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		return !string.IsNullOrEmpty(_userText.text);
	}

	private void FetchBody()
	{
		_bodyText.text = NgoEx.GetTweetBody(tweetDrawable, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	[AsyncStateMachine(typeof(_003CFetchTweetImage_003Ed__44))]
	private UniTask<bool> FetchTweetImage()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CFetchTweetImage_003Ed__44 _003CFetchTweetImage_003Ed__45 = default(_003CFetchTweetImage_003Ed__44);
		_003CFetchTweetImage_003Ed__45._003C_003Et__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		_003CFetchTweetImage_003Ed__45._003C_003E4__this = this;
		_003CFetchTweetImage_003Ed__45._003C_003E1__state = -1;
		_003CFetchTweetImage_003Ed__45._003C_003Et__builder.Start<_003CFetchTweetImage_003Ed__44>(ref _003CFetchTweetImage_003Ed__45);
		return _003CFetchTweetImage_003Ed__45._003C_003Et__builder.Task;
	}

	[AsyncStateMachine(typeof(_003CPlayMV_003Ed__45))]
	private UniTask PlayMV()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CPlayMV_003Ed__45 _003CPlayMV_003Ed__46 = default(_003CPlayMV_003Ed__45);
		_003CPlayMV_003Ed__46._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CPlayMV_003Ed__46._003C_003E4__this = this;
		_003CPlayMV_003Ed__46._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CPlayMV_003Ed__46._003C_003Et__builder)).Start<_003CPlayMV_003Ed__45>(ref _003CPlayMV_003Ed__46);
		return ((AsyncUniTaskMethodBuilder)(ref _003CPlayMV_003Ed__46._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShow_003Ed__46))]
	[ContextMenu("\ufffdt\ufffdF\ufffd[\ufffd_\ufffd[\ufffdA\ufffdj\ufffd\ufffd\ufffd\u030e\ufffd\ufffds")]
	private UniTask Show()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CShow_003Ed__46 _003CShow_003Ed__47 = default(_003CShow_003Ed__46);
		_003CShow_003Ed__47._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CShow_003Ed__47._003C_003E4__this = this;
		_003CShow_003Ed__47._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CShow_003Ed__47._003C_003Et__builder)).Start<_003CShow_003Ed__46>(ref _003CShow_003Ed__47);
		return ((AsyncUniTaskMethodBuilder)(ref _003CShow_003Ed__47._003C_003Et__builder)).Task;
	}

	private string ConvertGigaNumber(int number)
	{
		if (number > 1000000000)
		{
			return $"{number / 100000000}G";
		}
		if (number > 1000000)
		{
			return $"{number / 100000}M";
		}
		if (number > 10000)
		{
			return $"{number / 1000}K";
		}
		return number.ToString();
	}

	private void FavRtMove()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		if (!tweetDrawable.IsOmote)
		{
			return;
		}
		float num = (float)_buzzMillisecond / 1000f;
		if (tweetDrawable.RtNumber > 0)
		{
			TweenExtensions.Play<TweenerCore<int, int, NoOptions>>(TweenSettingsExtensions.OnComplete<TweenerCore<int, int, NoOptions>>(ShortcutExtensionsTMPText.DOCounter(_rtText, 0, tweetDrawable.RtNumber, num, true, (CultureInfo)null), (TweenCallback)delegate
			{
				_rtText.text = ConvertGigaNumber(tweetDrawable.RtNumber);
			}));
		}
		if (tweetDrawable.FavNumber > 0)
		{
			TweenExtensions.Play<TweenerCore<int, int, NoOptions>>(TweenSettingsExtensions.OnComplete<TweenerCore<int, int, NoOptions>>(ShortcutExtensionsTMPText.DOCounter(_favText, 0, tweetDrawable.FavNumber, num, true, (CultureInfo)null), (TweenCallback)delegate
			{
				_favText.text = ConvertGigaNumber(tweetDrawable.FavNumber);
			}));
		}
	}

	[AsyncStateMachine(typeof(_003CSetKusoRepStatic_003Ed__49))]
	private UniTask SetKusoRepStatic()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CSetKusoRepStatic_003Ed__49 _003CSetKusoRepStatic_003Ed__50 = default(_003CSetKusoRepStatic_003Ed__49);
		_003CSetKusoRepStatic_003Ed__50._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CSetKusoRepStatic_003Ed__50._003C_003E4__this = this;
		_003CSetKusoRepStatic_003Ed__50._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CSetKusoRepStatic_003Ed__50._003C_003Et__builder)).Start<_003CSetKusoRepStatic_003Ed__49>(ref _003CSetKusoRepStatic_003Ed__50);
		return ((AsyncUniTaskMethodBuilder)(ref _003CSetKusoRepStatic_003Ed__50._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowKusoReps_003Ed__50))]
	private UniTask ShowKusoReps()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CShowKusoReps_003Ed__50 _003CShowKusoReps_003Ed__51 = default(_003CShowKusoReps_003Ed__50);
		_003CShowKusoReps_003Ed__51._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CShowKusoReps_003Ed__51._003C_003E4__this = this;
		_003CShowKusoReps_003Ed__51._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CShowKusoReps_003Ed__51._003C_003Et__builder)).Start<_003CShowKusoReps_003Ed__50>(ref _003CShowKusoReps_003Ed__51);
		return ((AsyncUniTaskMethodBuilder)(ref _003CShowKusoReps_003Ed__51._003C_003Et__builder)).Task;
	}

	private async void SetLayout(bool imageExist)
	{
		await UniTask.DelayFrame(2, (PlayerLoopTiming)8, default(CancellationToken), false);
		_bodyTextElement.minHeight = _bodyText.preferredHeight;
		_bodyTextRectTr.sizeDelta = new Vector2(_bodyTextRectTr.sizeDelta.x, _bodyTextElement.minHeight);
		float num = 0f;
		float num2 = 6f;
		float num3 = 0f;
		num += _userTextElement.minHeight + num2;
		num3 -= _userTextElement.minHeight / 2f;
		_userTextRectTr.anchoredPosition = new Vector2(_userTextRectTr.anchoredPosition.x, num3);
		num3 -= _userTextElement.minHeight / 2f;
		num3 -= num2;
		num += _bodyTextElement.minHeight + num2;
		num3 -= _bodyTextElement.minHeight / 2f;
		_bodyTextRectTr.anchoredPosition = new Vector2(_bodyTextRectTr.anchoredPosition.x, num3);
		num3 -= _bodyTextElement.minHeight / 2f;
		num3 -= num2;
		if (imageExist)
		{
			num += _imageElement.minHeight + num2;
			num3 -= _imageElement.minHeight / 2f;
			_imageRectTr.anchoredPosition = new Vector2(_imageRectTr.anchoredPosition.x, num3);
			num3 -= _imageElement.minHeight / 2f;
			num3 -= num2;
		}
		num += _buzzElement.minHeight + num2;
		num3 -= _buzzElement.minHeight / 2f;
		_buzzRectTr.anchoredPosition = new Vector2(_buzzRectTr.anchoredPosition.x, num3);
		num3 -= _buzzElement.minHeight / 2f;
		num3 -= num2;
		num += _datetElement.minHeight;
		num3 -= _datetElement.minHeight / 2f;
		_dateRectTr.anchoredPosition = new Vector2(_dateRectTr.anchoredPosition.x, num3);
		_bodyElement.minHeight = num;
		_postElement.minHeight = num;
		_bodyRectTr.sizeDelta = new Vector2(_bodyRectTr.sizeDelta.x, num);
		_postRectTr.sizeDelta = new Vector2(_postRectTr.sizeDelta.x, num);
	}

	private void OnDestroy()
	{
		if (_imageFileName != "N/A")
		{
			LoadPictures.DeleteCache(_imageFileName, LoadPictures.PictureType.Poketter);
		}
	}

	public void OnLanguageUpdated()
	{
		SetUserName();
		FetchBody();
		if (tweetDrawable.Day >= 30)
		{
			_dateText.text = "????";
		}
		else
		{
			_dateText.text = NgoEx.DayText(tweetDrawable.Day, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) + " " + NgoEx.CmdName(tweetDrawable.cmdType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		SetLayout(_imageExist);
	}
}
