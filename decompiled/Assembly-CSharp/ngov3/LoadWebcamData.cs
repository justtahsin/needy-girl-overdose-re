using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ngov3;

public static class LoadWebcamData
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CLoadAnimation_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<AnimationClip> _003C_003Et__builder;

		public string address;

		private AsyncOperationHandle<AnimationClip> _003Chandle_003E5__2;

		private AsyncOperationHandle<AnimationClip> _003CcachedHandle_003E5__3;

		private Awaiter<AnimationClip> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			AnimationClip result;
			try
			{
				Awaiter<AnimationClip> val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<AnimationClip>);
					num = (_003C_003E1__state = -1);
					goto IL_009d;
				}
				if (num != 1)
				{
					if (cachedAnimHandles.ContainsKey(address))
					{
						_003CcachedHandle_003E5__3 = cachedAnimHandles[address];
						if (!_003CcachedHandle_003E5__3.IsDone)
						{
							val = AddressablesAsyncExtensions.GetAwaiter<AnimationClip>(_003CcachedHandle_003E5__3);
							if (!val.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = val;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<AnimationClip>, _003CLoadAnimation_003Ed__3>(ref val, ref this);
								return;
							}
							goto IL_009d;
						}
						goto IL_00a5;
					}
					_003Chandle_003E5__2 = Addressables.LoadAssetAsync<AnimationClip>((object)address);
					cachedAnimHandles.Add(address, _003Chandle_003E5__2);
					val = AddressablesAsyncExtensions.GetAwaiter<AnimationClip>(_003Chandle_003E5__2);
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<AnimationClip>, _003CLoadAnimation_003Ed__3>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<AnimationClip>);
					num = (_003C_003E1__state = -1);
				}
				val.GetResult();
				KeyQueueManage(address);
				if ((Object)(object)_003Chandle_003E5__2.Result == (Object)null)
				{
					Debug.LogError((object)("LoadWebCan:" + address + "のアニメーションがAddressable内にありません！"));
				}
				result = _003Chandle_003E5__2.Result;
				goto end_IL_0007;
				IL_009d:
				val.GetResult();
				goto IL_00a5;
				IL_00a5:
				result = _003CcachedHandle_003E5__3.Result;
				end_IL_0007:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Chandle_003E5__2 = default(AsyncOperationHandle<AnimationClip>);
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Chandle_003E5__2 = default(AsyncOperationHandle<AnimationClip>);
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

	private static Dictionary<string, AsyncOperationHandle<AnimationClip>> cachedAnimHandles = new Dictionary<string, AsyncOperationHandle<AnimationClip>>();

	private static Queue<string> resentKeys = new Queue<string>();

	private static int queueCapacity = 10;

	[AsyncStateMachine(typeof(_003CLoadAnimation_003Ed__3))]
	public static UniTask<AnimationClip> LoadAnimation(string address)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadAnimation_003Ed__3 _003CLoadAnimation_003Ed__4 = default(_003CLoadAnimation_003Ed__3);
		_003CLoadAnimation_003Ed__4._003C_003Et__builder = AsyncUniTaskMethodBuilder<AnimationClip>.Create();
		_003CLoadAnimation_003Ed__4.address = address;
		_003CLoadAnimation_003Ed__4._003C_003E1__state = -1;
		_003CLoadAnimation_003Ed__4._003C_003Et__builder.Start<_003CLoadAnimation_003Ed__3>(ref _003CLoadAnimation_003Ed__4);
		return _003CLoadAnimation_003Ed__4._003C_003Et__builder.Task;
	}

	public static void DeleteAllCache()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		foreach (KeyValuePair<string, AsyncOperationHandle<AnimationClip>> cachedAnimHandle in cachedAnimHandles)
		{
			Addressables.Release<AnimationClip>(cachedAnimHandle.Value);
		}
		cachedAnimHandles.Clear();
		resentKeys.Clear();
	}

	private static void KeyQueueManage(string newKey)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		resentKeys.Enqueue(newKey);
		if (resentKeys.Count > queueCapacity)
		{
			string text = resentKeys.Dequeue();
			if (!resentKeys.Contains(text))
			{
				AsyncOperationHandle<AnimationClip> val = cachedAnimHandles[text];
				cachedAnimHandles.Remove(text);
				Addressables.Release<AnimationClip>(val);
			}
		}
	}
}
