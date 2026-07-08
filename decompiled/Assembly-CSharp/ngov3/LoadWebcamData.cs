using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ngov3;

public static class LoadWebcamData
{
	private static Dictionary<string, AsyncOperationHandle<AnimationClip>> cachedAnimHandles = new Dictionary<string, AsyncOperationHandle<AnimationClip>>();

	private static Queue<string> resentKeys = new Queue<string>();

	private static int queueCapacity = 10;

	public static async UniTask<AnimationClip> LoadAnimation(string address)
	{
		if (cachedAnimHandles.ContainsKey(address))
		{
			AsyncOperationHandle<AnimationClip> cachedHandle = cachedAnimHandles[address];
			if (!cachedHandle.IsDone)
			{
				await cachedHandle;
			}
			return cachedHandle.Result;
		}
		AsyncOperationHandle<AnimationClip> handle = Addressables.LoadAssetAsync<AnimationClip>(address);
		cachedAnimHandles.Add(address, handle);
		await handle;
		KeyQueueManage(address);
		if (handle.Result == null)
		{
			Debug.LogError("LoadWebCan:" + address + "のアニメーションがAddressable内にありません！");
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
		resentKeys.Clear();
	}

	private static void KeyQueueManage(string newKey)
	{
		resentKeys.Enqueue(newKey);
		if (resentKeys.Count > queueCapacity)
		{
			string text = resentKeys.Dequeue();
			if (!resentKeys.Contains(text))
			{
				AsyncOperationHandle<AnimationClip> handle = cachedAnimHandles[text];
				cachedAnimHandles.Remove(text);
				Addressables.Release(handle);
			}
		}
	}
}
