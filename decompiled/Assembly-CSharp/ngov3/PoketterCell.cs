using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
using UnityEngine.Video;

namespace ngov3;

public class PoketterCell : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public string imageId;

		public ResourceLocal resource;

		internal bool _003CFetchTweetImage_003Eb__0(ResourceLocal r)
		{
			return r.FileName == imageId;
		}

		internal void _003CFetchTweetImage_003Eb__1(Unit _)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			ImageViewerHelper.OpenImageViewer(resource.FileName);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CAnimate_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterCell _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCell poketterCell = _003C_003E4__this;
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
						goto IL_00d6;
					}
					val2 = poketterCell.Show();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAnimate_003Ed__20>(ref val, ref this);
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
				poketterCell.FavRtMove();
				poketterCell.SetKusoRep();
				val2 = poketterCell.ShowKusoReps();
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAnimate_003Ed__20>(ref val, ref this);
					return;
				}
				goto IL_00d6;
				IL_00d6:
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
	private struct _003CFetchTweetImage_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

		public PoketterCell _003C_003E4__this;

		private _003C_003Ec__DisplayClass24_0 _003C_003E8__1;

		private bool _003ChasImage_003E5__2;

		private Image _003C_003E7__wrap2;

		private Awaiter<Sprite> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCell CS_0024_003C_003E8__locals8 = _003C_003E4__this;
			bool result;
			try
			{
				Awaiter<Sprite> val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<Sprite>);
					num = (_003C_003E1__state = -1);
					goto IL_0163;
				}
				_003ChasImage_003E5__2 = CS_0024_003C_003E8__locals8.tweetDrawable.ImageId.IsNotEmpty();
				((Component)CS_0024_003C_003E8__locals8._image).gameObject.SetActive(_003ChasImage_003E5__2);
				if (!_003ChasImage_003E5__2)
				{
					goto IL_0212;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass24_0();
				_003C_003E8__1.imageId = CS_0024_003C_003E8__locals8.tweetDrawable.ImageId;
				_003C_003E8__1.resource = CS_0024_003C_003E8__locals8._resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == _003C_003E8__1.imageId);
				SingletonMonoBehaviour<Settings>.Instance.addImage(_003C_003E8__1.imageId);
				if (_003C_003E8__1.resource != null)
				{
					_003C_003E7__wrap2 = CS_0024_003C_003E8__locals8._image;
					val = LoadPictures.LoadPictureAsync(_003C_003E8__1.resource.FileName, LoadPictures.PictureType.Poketter).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CFetchTweetImage_003Ed__24>(ref val, ref this);
						return;
					}
					goto IL_0163;
				}
				Debug.LogError((object)("TWEET MASTER: " + _003C_003E8__1.imageId + " の 画像Id がなかったよ " + _003C_003E8__1.imageId));
				result = false;
				goto end_IL_000e;
				IL_0212:
				result = _003ChasImage_003E5__2;
				goto end_IL_000e;
				IL_0163:
				Sprite result2 = val.GetResult();
				_003C_003E7__wrap2.sprite = result2;
				_003C_003E7__wrap2 = null;
				if (!(_003C_003E8__1.imageId == "MV_thumbnail"))
				{
					Button component = ((Component)CS_0024_003C_003E8__locals8._image).gameObject.GetComponent<Button>();
					DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(component), (Action<Unit>)delegate
					{
						//IL_000b: Unknown result type (might be due to invalid IL or missing references)
						ImageViewerHelper.OpenImageViewer(_003C_003E8__1.resource.FileName);
					}), ((Component)component).gameObject);
					_003C_003E8__1 = null;
					goto IL_0212;
				}
				Button component2 = ((Component)CS_0024_003C_003E8__locals8._image).gameObject.GetComponent<Button>();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(component2), (Action<Unit>)async delegate
				{
					await CS_0024_003C_003E8__locals8.PlayMV();
				}), ((Component)component2).gameObject);
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
	private struct _003CPlayMV_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterCell _003C_003E4__this;

		private VideoPlayer _003CvideoViewer_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCell poketterCell = _003C_003E4__this;
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
						goto IL_0171;
					}
					_003CvideoViewer_003E5__2 = GameObject.Find("Main Camera").GetComponent<VideoPlayer>();
					_003CvideoViewer_003E5__2.clip = Resources.Load<VideoClip>("Videos/INTERNETOVERDOSE");
					_003CvideoViewer_003E5__2.Prepare();
					_003CvideoViewer_003E5__2.aspectRatio = (VideoAspectRatio)3;
					_003CvideoViewer_003E5__2.SetDirectAudioVolume((ushort)0, SingletonMonoBehaviour<Settings>.Instance.BgmVolume);
					AudioManager.Instance.StopBgm();
					_003CvideoViewer_003E5__2.targetCameraAlpha = 1f;
					_003CvideoViewer_003E5__2.Play();
					val2 = NgoEvent.DelaySkippable(2000);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlayMV_003Ed__25>(ref val, ref this);
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
				AudioManager.Instance.PlayBgmByType(SoundType.BGM_InternetOverdose);
				poketterCell._baseCanvasGroup.interactable = false;
				val2 = NgoEvent.DelaySkippable(224000);
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CPlayMV_003Ed__25>(ref val, ref this);
					return;
				}
				goto IL_0171;
				IL_0171:
				((Awaiter)(ref val)).GetResult();
				_003CvideoViewer_003E5__2.targetCameraAlpha = 0f;
				_003CvideoViewer_003E5__2.Stop();
				AudioManager.Instance.PlayBgmByType(SoundType.BGM_InternetOverdose8bit, isLoop: true);
				poketterCell._baseCanvasGroup.interactable = true;
				_003CvideoViewer_003E5__2.aspectRatio = (VideoAspectRatio)2;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003CvideoViewer_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CvideoViewer_003E5__2 = null;
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
	private struct _003CShow_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterCell _003C_003E4__this;

		private float _003Cfade_003E5__2;

		private TweenAwaiter _003C_003Eu__1;

		private Awaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCell poketterCell = _003C_003E4__this;
			try
			{
				TweenAwaiter val2;
				Awaiter val;
				UniTask val3;
				switch (num)
				{
				default:
				{
					poketterCell._baseCanvasGroup.alpha = 0f;
					RectTransform component = ((Component)poketterCell).GetComponent<RectTransform>();
					((Transform)component).localScale = new Vector3(1f, 0f, 1f);
					float num2 = (float)poketterCell._scrollMillisecond / 1000f;
					_003Cfade_003E5__2 = (float)poketterCell._fadeMillisecond / 1000f;
					UniTaskCancellationExtensions.GetCancellationTokenOnDestroy(((Component)poketterCell).gameObject);
					val2 = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOScaleY((Transform)(object)component, 1f, num2)));
					if (!((TweenAwaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CShow_003Ed__26>(ref val2, ref this);
						return;
					}
					goto IL_00db;
				}
				case 0:
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00db;
				case 1:
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_014b;
				case 2:
					{
						val = _003C_003Eu__2;
						_003C_003Eu__2 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_014b:
					((TweenAwaiter)(ref val2)).GetResult();
					val3 = NgoEvent.DelaySkippable(poketterCell._bodyText.text.Length * 10);
					val = ((UniTask)(ref val3)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CShow_003Ed__26>(ref val, ref this);
						return;
					}
					break;
					IL_00db:
					((TweenAwaiter)(ref val2)).GetResult();
					val2 = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(poketterCell._baseCanvasGroup, 1f, _003Cfade_003E5__2)));
					if (!((TweenAwaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CShow_003Ed__26>(ref val2, ref this);
						return;
					}
					goto IL_014b;
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
	private struct _003CShowKusoReps_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public PoketterCell _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private int _003Ci_003E5__2;

		private void MoveNext()
		{
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PoketterCell poketterCell = _003C_003E4__this;
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
						goto IL_00fc;
					}
					if (((Transform)poketterCell._kusoRepRoot).childCount == 0)
					{
						goto IL_0087;
					}
					val2 = NgoEvent.DelaySkippable(Constants.MIDDLE);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CShowKusoReps_003Ed__31>(ref val, ref this);
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
				goto IL_0087;
				IL_0087:
				_003Ci_003E5__2 = 0;
				goto IL_0115;
				IL_00fc:
				((Awaiter)(ref val)).GetResult();
				_003Ci_003E5__2++;
				goto IL_0115;
				IL_0115:
				if (_003Ci_003E5__2 < ((Transform)poketterCell._kusoRepRoot).childCount)
				{
					val2 = ((Component)((Transform)poketterCell._kusoRepRoot).GetChild(_003Ci_003E5__2)).GetComponent<KusoRepView>().Show();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CShowKusoReps_003Ed__31>(ref val, ref this);
						return;
					}
					goto IL_00fc;
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
	protected Image _userIcon;

	[SerializeField]
	protected TMP_Text _userText;

	[SerializeField]
	protected TMP_Text _bodyText;

	[SerializeField]
	protected TMP_Text _dateText;

	[SerializeField]
	protected Image _image;

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
	private KusoRepView _kusoRepPrefab;

	[SerializeField]
	[Header("ツイートが出現するときにスクロールする時間")]
	private int _scrollMillisecond = 1000;

	[SerializeField]
	[Header("ツイートがフェードインする時間")]
	private int _fadeMillisecond = 300;

	[Header("バズりパワーがテロテロする時間")]
	[SerializeField]
	private int _buzzMillisecond = 1000;

	private TweetDrawable tweetDrawable;

	private CanvasGroup _baseCanvasGroup;

	public void Awake()
	{
		_baseCanvasGroup = ((Component)this).GetComponent<CanvasGroup>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
		{
			OnLanguageUpdated();
		}), ((Component)this).gameObject);
	}

	public void SetData(TweetDrawable nakami)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		tweetDrawable = nakami;
		SetUserIcon();
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
		FetchTweetImage();
	}

	public void SetDataStatic(TweetDrawable nakami)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		tweetDrawable = nakami;
		SetUserIcon();
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
		FetchTweetImage();
		SetKusoRepStatic();
		_rtText.text = ConvertGigaNumber(nakami.RtNumber);
		_favText.text = ConvertGigaNumber(nakami.FavNumber);
	}

	[AsyncStateMachine(typeof(_003CAnimate_003Ed__20))]
	public UniTask Animate()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CAnimate_003Ed__20 _003CAnimate_003Ed__21 = default(_003CAnimate_003Ed__20);
		_003CAnimate_003Ed__21._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CAnimate_003Ed__21._003C_003E4__this = this;
		_003CAnimate_003Ed__21._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CAnimate_003Ed__21._003C_003Et__builder)).Start<_003CAnimate_003Ed__20>(ref _003CAnimate_003Ed__21);
		return ((AsyncUniTaskMethodBuilder)(ref _003CAnimate_003Ed__21._003C_003Et__builder)).Task;
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
		switch (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)
		{
		case LanguageType.JP:
			_bodyText.text = tweetDrawable.BodyJp;
			break;
		case LanguageType.CN:
			_bodyText.text = tweetDrawable.BodyCn;
			break;
		case LanguageType.KO:
			_bodyText.text = tweetDrawable.BodyKo;
			break;
		case LanguageType.TW:
			_bodyText.text = tweetDrawable.BodyTw;
			break;
		case LanguageType.VN:
			_bodyText.text = tweetDrawable.BodyVn;
			break;
		case LanguageType.FR:
			_bodyText.text = tweetDrawable.BodyFr;
			break;
		case LanguageType.IT:
			_bodyText.text = tweetDrawable.BodyIt;
			break;
		case LanguageType.GE:
			_bodyText.text = tweetDrawable.BodyGe;
			break;
		case LanguageType.SP:
			_bodyText.text = tweetDrawable.BodySp;
			break;
		case LanguageType.RU:
			_bodyText.text = tweetDrawable.BodyRu;
			break;
		default:
			_bodyText.text = tweetDrawable.BodyEn;
			break;
		}
	}

	[AsyncStateMachine(typeof(_003CFetchTweetImage_003Ed__24))]
	private UniTask<bool> FetchTweetImage()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CFetchTweetImage_003Ed__24 _003CFetchTweetImage_003Ed__25 = default(_003CFetchTweetImage_003Ed__24);
		_003CFetchTweetImage_003Ed__25._003C_003Et__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		_003CFetchTweetImage_003Ed__25._003C_003E4__this = this;
		_003CFetchTweetImage_003Ed__25._003C_003E1__state = -1;
		_003CFetchTweetImage_003Ed__25._003C_003Et__builder.Start<_003CFetchTweetImage_003Ed__24>(ref _003CFetchTweetImage_003Ed__25);
		return _003CFetchTweetImage_003Ed__25._003C_003Et__builder.Task;
	}

	[AsyncStateMachine(typeof(_003CPlayMV_003Ed__25))]
	private UniTask PlayMV()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CPlayMV_003Ed__25 _003CPlayMV_003Ed__26 = default(_003CPlayMV_003Ed__25);
		_003CPlayMV_003Ed__26._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CPlayMV_003Ed__26._003C_003E4__this = this;
		_003CPlayMV_003Ed__26._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CPlayMV_003Ed__26._003C_003Et__builder)).Start<_003CPlayMV_003Ed__25>(ref _003CPlayMV_003Ed__26);
		return ((AsyncUniTaskMethodBuilder)(ref _003CPlayMV_003Ed__26._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShow_003Ed__26))]
	private UniTask Show()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CShow_003Ed__26 _003CShow_003Ed__27 = default(_003CShow_003Ed__26);
		_003CShow_003Ed__27._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CShow_003Ed__27._003C_003E4__this = this;
		_003CShow_003Ed__27._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CShow_003Ed__27._003C_003Et__builder)).Start<_003CShow_003Ed__26>(ref _003CShow_003Ed__27);
		return ((AsyncUniTaskMethodBuilder)(ref _003CShow_003Ed__27._003C_003Et__builder)).Task;
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

	private void SetKusoRep()
	{
		foreach (KusoRepDrawable kusoRep in tweetDrawable.kusoReps)
		{
			Object.Instantiate<KusoRepView>(_kusoRepPrefab, ((Component)_kusoRepRoot).transform).SetData(kusoRep);
		}
	}

	private void SetKusoRepStatic()
	{
		foreach (KusoRepDrawable kusoRep in tweetDrawable.kusoReps)
		{
			KusoRepView kusoRepView = Object.Instantiate<KusoRepView>(_kusoRepPrefab, ((Component)_kusoRepRoot).transform);
			kusoRepView.SetData(kusoRep);
			kusoRepView.ShowPosted();
		}
	}

	[AsyncStateMachine(typeof(_003CShowKusoReps_003Ed__31))]
	private UniTask ShowKusoReps()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CShowKusoReps_003Ed__31 _003CShowKusoReps_003Ed__32 = default(_003CShowKusoReps_003Ed__31);
		_003CShowKusoReps_003Ed__32._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CShowKusoReps_003Ed__32._003C_003E4__this = this;
		_003CShowKusoReps_003Ed__32._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CShowKusoReps_003Ed__32._003C_003Et__builder)).Start<_003CShowKusoReps_003Ed__31>(ref _003CShowKusoReps_003Ed__32);
		return ((AsyncUniTaskMethodBuilder)(ref _003CShowKusoReps_003Ed__32._003C_003Et__builder)).Task;
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
	}
}
