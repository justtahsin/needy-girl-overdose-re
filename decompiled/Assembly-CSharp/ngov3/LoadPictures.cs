using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
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

	private static Dictionary<string, PictureHandleData> handleDatas = new Dictionary<string, PictureHandleData>();

	private static CancellationTokenSource cancellationTokenSource_MyPicture = null;

	private static CancellationTokenSource cancellationTokenSource_ImageViewer = null;

	private static CancellationTokenSource cancellationTokenSource_Poketter = null;

	private static CancellationTokenSource cancellationTokenSource_JINE = null;

	public static async UniTask<Sprite> LoadPictureAsync(string address, PictureType type)
	{
		CancellationToken token = SelectCancelationTokenSource(type, forCancel: false).Token;
		PictureHandleData cachedHandleData;
		if (handleDatas.ContainsKey(address))
		{
			cachedHandleData = handleDatas[address];
			switch (type)
			{
			case PictureType.Poketter:
				cachedHandleData.usedInPoketter = true;
				break;
			case PictureType.JINE:
				cachedHandleData.usedInJine = true;
				break;
			case PictureType.MyPicture:
				cachedHandleData.usedInMyPicture = true;
				break;
			default:
				cachedHandleData.usedInImageViewer = true;
				break;
			}
			if (!cachedHandleData.handle.IsDone)
			{
				await cachedHandleData.handle.WithCancellation(token);
			}
			return cachedHandleData.handle.Result;
		}
		cachedHandleData = new PictureHandleData
		{
			usedInMyPicture = (type == PictureType.MyPicture),
			usedInPoketter = (type == PictureType.Poketter),
			usedInJine = (type == PictureType.JINE),
			usedInImageViewer = (type == PictureType.ImageViewer),
			handle = Addressables.LoadAssetAsync<Sprite>(address)
		};
		handleDatas.Add(address, cachedHandleData);
		await cachedHandleData.handle.WithCancellation(token);
		if (cachedHandleData.handle.Result == null)
		{
			Debug.LogError("LoadPictures:" + address + "\ufffd\ufffdSprite\ufffd\ufffdAddressable\ufffd\ufffd\ufffdɂ\ufffd\ufffd\ufffd܂\ufffd\ufffd\ufffdI");
		}
		return cachedHandleData.handle.Result;
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
		SelectCancelationTokenSource(type, forCancel: true).Cancel();
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, PictureHandleData> handleData in handleDatas)
		{
			PictureHandleData value = handleData.Value;
			value.SetUsedPlace(type, value: false);
			if (!value.isUsedAnywhere)
			{
				Addressables.Release(value.handle);
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
		if (handleDatas.ContainsKey(address))
		{
			PictureHandleData pictureHandleData = handleDatas[address];
			pictureHandleData.SetUsedPlace(type, value: false);
			if (!pictureHandleData.isUsedAnywhere)
			{
				Addressables.Release(pictureHandleData.handle);
				handleDatas.Remove(address);
			}
		}
	}
}
