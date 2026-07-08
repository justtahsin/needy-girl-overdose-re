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

public static class LoadLiveViewData
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CLoadAnimation_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<AnimationClip> _003C_003Et__builder;

		public string address;

		public CancellationToken token;

		private AsyncOperationHandle<AnimationClip> _003Chandle_003E5__2;

		private AsyncOperationHandle<AnimationClip> _003CcachedHandle_003E5__3;

		private Awaiter<AnimationClip> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
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
					goto IL_00b0;
				}
				if (num != 1)
				{
					if (cachedAnimHandles.ContainsKey(address))
					{
						_003CcachedHandle_003E5__3 = cachedAnimHandles[address];
						if (!_003CcachedHandle_003E5__3.IsDone)
						{
							val = AddressablesAsyncExtensions.WithCancellation<AnimationClip>(_003CcachedHandle_003E5__3, token, false, false).GetAwaiter();
							if (!val.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = val;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<AnimationClip>, _003CLoadAnimation_003Ed__1>(ref val, ref this);
								return;
							}
							goto IL_00b0;
						}
						goto IL_00b8;
					}
					_003Chandle_003E5__2 = Addressables.LoadAssetAsync<AnimationClip>((object)address);
					cachedAnimHandles.Add(address, _003Chandle_003E5__2);
					val = AddressablesAsyncExtensions.WithCancellation<AnimationClip>(_003Chandle_003E5__2, token, false, false).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<Awaiter<AnimationClip>, _003CLoadAnimation_003Ed__1>(ref val, ref this);
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
				if ((Object)(object)_003Chandle_003E5__2.Result == (Object)null)
				{
					Debug.LogError((object)("LoadLiveViewData:" + address + "\ufffd\u0303A\ufffdj\ufffd\ufffd\ufffd[\ufffdV\ufffd\ufffd\ufffd\ufffd\ufffd\ufffdAddressable\ufffd\ufffd\ufffdɂ\ufffd\ufffd\ufffd܂\ufffd\ufffd\ufffdI"));
				}
				result = _003Chandle_003E5__2.Result;
				goto end_IL_0007;
				IL_00b0:
				val.GetResult();
				goto IL_00b8;
				IL_00b8:
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

	[AsyncStateMachine(typeof(_003CLoadAnimation_003Ed__1))]
	public static UniTask<AnimationClip> LoadAnimation(string address, CancellationToken token)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadAnimation_003Ed__1 _003CLoadAnimation_003Ed__2 = default(_003CLoadAnimation_003Ed__1);
		_003CLoadAnimation_003Ed__2._003C_003Et__builder = AsyncUniTaskMethodBuilder<AnimationClip>.Create();
		_003CLoadAnimation_003Ed__2.address = address;
		_003CLoadAnimation_003Ed__2.token = token;
		_003CLoadAnimation_003Ed__2._003C_003E1__state = -1;
		_003CLoadAnimation_003Ed__2._003C_003Et__builder.Start<_003CLoadAnimation_003Ed__1>(ref _003CLoadAnimation_003Ed__2);
		return _003CLoadAnimation_003Ed__2._003C_003Et__builder.Task;
	}

	public static void DeleteAllCache()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		foreach (KeyValuePair<string, AsyncOperationHandle<AnimationClip>> cachedAnimHandle in cachedAnimHandles)
		{
			Addressables.Release<AnimationClip>(cachedAnimHandle.Value);
		}
		cachedAnimHandles.Clear();
	}
}
