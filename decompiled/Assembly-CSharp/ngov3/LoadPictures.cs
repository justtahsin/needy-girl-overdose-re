using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ngov3;

public static class LoadPictures
{
	public enum PictureType
	{
		Poketter,
		JINE,
		MyPicture,
		ImageViewer
	}

	public struct PictureHandleData
	{
		public bool usedInPoketter;

		public bool usedInJine;

		public bool usedInMyPicture;

		public bool usedInImageViewer;

		public AsyncOperationHandle<Sprite> handle;

		public bool isUsedAnywhere
		{
			get
			{
				if (!usedInMyPicture && !usedInPoketter && !usedInJine)
				{
					return usedInImageViewer;
				}
				return true;
			}
		}

		public void SetUsedPlace(PictureType type, bool value)
		{
			switch (type)
			{
			case PictureType.Poketter:
				usedInPoketter = value;
				break;
			case PictureType.JINE:
				usedInJine = value;
				break;
			case PictureType.MyPicture:
				usedInMyPicture = value;
				break;
			default:
				usedInImageViewer = value;
				break;
			}
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CLoadPictureAsync_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<Sprite> _003C_003Et__builder;

		public PictureType type;

		public string address;

		private PictureHandleData _003CcachedHandleData_003E5__2;

		private Awaiter<Sprite> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Sprite result;
			try
			{
				Awaiter<Sprite> val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<Sprite>);
					num = (_003C_003E1__state = -1);
					goto IL_0120;
				}
				if (num != 1)
				{
					CancellationToken token = SelectCancelationTokenSource(type, forCancel: false).Token;
					if (handleDatas.ContainsKey(address))
					{
						_003CcachedHandleData_003E5__2 = handleDatas[address];
						switch (type)
						{
						case PictureType.Poketter:
							_003CcachedHandleData_003E5__2.usedInPoketter = true;
							break;
						case PictureType.JINE:
							_003CcachedHandleData_003E5__2.usedInJine = true;
							break;
						case PictureType.MyPicture:
							_003CcachedHandleData_003E5__2.usedInMyPicture = true;
							break;
						default:
							_003CcachedHandleData_003E5__2.usedInImageViewer = true;
							break;
						}
						if (!_003CcachedHandleData_003E5__2.handle.IsDone)
						{
							val = AddressablesAsyncExtensions.WithCancellation<Sprite>(_003CcachedHandleData_003E5__2.handle, token, false, false).GetAwaiter();
							if (!val.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = val;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CLoadPictureAsync_003Ed__7>(ref val, ref this);
								return;
							}
							goto IL_0120;
						}
						goto IL_0128;
					}
					_003CcachedHandleData_003E5__2 = default(PictureHandleData);
					_003CcachedHandleData_003E5__2.usedInMyPicture = type == PictureType.MyPicture;
					_003CcachedHandleData_003E5__2.usedInPoketter = type == PictureType.Poketter;
					_003CcachedHandleData_003E5__2.usedInJine = type == PictureType.JINE;
					_003CcachedHandleData_003E5__2.usedInImageViewer = type == PictureType.ImageViewer;
					_003CcachedHandleData_003E5__2.handle = Addressables.LoadAssetAsync<Sprite>((object)address);
					handleDatas.Add(address, _003CcachedHandleData_003E5__2);
					val = AddressablesAsyncExtensions.WithCancellation<Sprite>(_003CcachedHandleData_003E5__2.handle, token, false, false).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CLoadPictureAsync_003Ed__7>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<Sprite>);
					num = (_003C_003E1__state = -1);
				}
				val.GetResult();
				if ((Object)(object)_003CcachedHandleData_003E5__2.handle.Result == (Object)null)
				{
					Debug.LogError((object)("LoadPictures:" + address + "\ufffd\ufffdSprite\ufffd\ufffdAddressable\ufffd\ufffd\ufffdɂ\ufffd\ufffd\ufffd܂\ufffd\ufffd\ufffdI"));
				}
				result = _003CcachedHandleData_003E5__2.handle.Result;
				goto end_IL_0007;
				IL_0128:
				result = _003CcachedHandleData_003E5__2.handle.Result;
				goto end_IL_0007;
				IL_0120:
				val.GetResult();
				goto IL_0128;
				end_IL_0007:;
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

	private static Dictionary<string, PictureHandleData> handleDatas = new Dictionary<string, PictureHandleData>();

	private static CancellationTokenSource cancellationTokenSource_MyPicture = null;

	private static CancellationTokenSource cancellationTokenSource_ImageViewer = null;

	private static CancellationTokenSource cancellationTokenSource_Poketter = null;

	private static CancellationTokenSource cancellationTokenSource_JINE = null;

	[AsyncStateMachine(typeof(_003CLoadPictureAsync_003Ed__7))]
	public static UniTask<Sprite> LoadPictureAsync(string address, PictureType type)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadPictureAsync_003Ed__7 _003CLoadPictureAsync_003Ed__8 = default(_003CLoadPictureAsync_003Ed__7);
		_003CLoadPictureAsync_003Ed__8._003C_003Et__builder = AsyncUniTaskMethodBuilder<Sprite>.Create();
		_003CLoadPictureAsync_003Ed__8.address = address;
		_003CLoadPictureAsync_003Ed__8.type = type;
		_003CLoadPictureAsync_003Ed__8._003C_003E1__state = -1;
		_003CLoadPictureAsync_003Ed__8._003C_003Et__builder.Start<_003CLoadPictureAsync_003Ed__7>(ref _003CLoadPictureAsync_003Ed__8);
		return _003CLoadPictureAsync_003Ed__8._003C_003Et__builder.Task;
	}

	private static CancellationTokenSource SelectCancelationTokenSource(PictureType type, bool forCancel)
	{
		CancellationTokenSource cancellationTokenSource = null;
		switch (type)
		{
		case PictureType.Poketter:
			if (cancellationTokenSource_Poketter == null)
			{
				cancellationTokenSource_Poketter = new CancellationTokenSource();
			}
			cancellationTokenSource = cancellationTokenSource_Poketter;
			if (forCancel)
			{
				cancellationTokenSource_Poketter = null;
			}
			break;
		case PictureType.JINE:
			if (cancellationTokenSource_JINE == null)
			{
				cancellationTokenSource_JINE = new CancellationTokenSource();
			}
			cancellationTokenSource = cancellationTokenSource_JINE;
			if (forCancel)
			{
				cancellationTokenSource_JINE = null;
			}
			break;
		case PictureType.MyPicture:
			if (cancellationTokenSource_MyPicture == null)
			{
				cancellationTokenSource_MyPicture = new CancellationTokenSource();
			}
			cancellationTokenSource = cancellationTokenSource_MyPicture;
			if (forCancel)
			{
				cancellationTokenSource_MyPicture = null;
			}
			break;
		default:
			if (cancellationTokenSource_ImageViewer == null)
			{
				cancellationTokenSource_ImageViewer = new CancellationTokenSource();
			}
			cancellationTokenSource = cancellationTokenSource_ImageViewer;
			if (forCancel)
			{
				cancellationTokenSource_ImageViewer = null;
			}
			break;
		}
		return cancellationTokenSource;
	}

	public static void DeleteCache(PictureType type)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		SelectCancelationTokenSource(type, forCancel: true).Cancel();
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, PictureHandleData> handleData in handleDatas)
		{
			PictureHandleData value = handleData.Value;
			value.SetUsedPlace(type, value: false);
			if (!value.isUsedAnywhere)
			{
				Addressables.Release<Sprite>(value.handle);
				list.Add(handleData.Key);
			}
		}
		foreach (string item in list)
		{
			handleDatas.Remove(item);
		}
	}

	public static void DeleteCache(string address, PictureType type)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (handleDatas.ContainsKey(address))
		{
			PictureHandleData pictureHandleData = handleDatas[address];
			pictureHandleData.SetUsedPlace(type, value: false);
			if (!pictureHandleData.isUsedAnywhere)
			{
				Addressables.Release<Sprite>(pictureHandleData.handle);
				handleDatas.Remove(address);
			}
		}
	}
}
