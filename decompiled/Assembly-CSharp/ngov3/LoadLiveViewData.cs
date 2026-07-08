using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ngov3;

public static class LoadLiveViewData
{
	private static Dictionary<string, AsyncOperationHandle<AnimationClip>> cachedAnimHandles = new Dictionary<string, AsyncOperationHandle<AnimationClip>>();

	public static async UniTask<AnimationClip> LoadAnimation(string address, CancellationToken token)
	{
		if (cachedAnimHandles.ContainsKey(address))
		{
			AsyncOperationHandle<AnimationClip> cachedHandle = cachedAnimHandles[address];
			if (!cachedHandle.IsDone)
			{
				await cachedHandle.WithCancellation(token);
			}
			return cachedHandle.Result;
		}
		AsyncOperationHandle<AnimationClip> handle = Addressables.LoadAssetAsync<AnimationClip>(address);
		cachedAnimHandles.Add(address, handle);
		await handle.WithCancellation(token);
		if (handle.Result == null)
		{
			Debug.LogError("LoadLiveViewData:" + address + "\ufffd\u0303A\ufffdj\ufffd\ufffd\ufffd[\ufffdV\ufffd\ufffd\ufffd\ufffd\ufffd\ufffdAddressable\ufffd\ufffd\ufffdɂ\ufffd\ufffd\ufffd܂\ufffd\ufffd\ufffdI");
		}
		return handle.Result;
	}

	public static void DeleteAllCache()
	{
		foreach (KeyValuePair<string, AsyncOperationHandle<AnimationClip>> cachedAnimHandle in cachedAnimHandles)
		{
			Addressables.Release(cachedAnimHandle.Value);
		}
		cachedAnimHandles.Clear();
	}
}
