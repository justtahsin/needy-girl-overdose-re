using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ngov3;

public static class LoadAppData
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CLoadAppDataAsset_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		private Awaiter<AppTypeToDataAsset> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				Awaiter<AppTypeToDataAsset> val;
				if (num != 0)
				{
					val = AddressablesAsyncExtensions.GetAwaiter<AppTypeToDataAsset>(Addressables.LoadAssetAsync<AppTypeToDataAsset>((object)"Apps"));
					if (!val.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<AppTypeToDataAsset>, _003CLoadAppDataAsset_003Ed__1>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<AppTypeToDataAsset>);
					num = (_003C_003E1__state = -1);
				}
				AppTypeToDataAsset result = val.GetResult();
				if ((Object)(object)result != (Object)null)
				{
					app2data = result;
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

	private static AppTypeToDataAsset app2data;

	[AsyncStateMachine(typeof(_003CLoadAppDataAsset_003Ed__1))]
	public static UniTask LoadAppDataAsset()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadAppDataAsset_003Ed__1 _003CLoadAppDataAsset_003Ed__2 = default(_003CLoadAppDataAsset_003Ed__1);
		_003CLoadAppDataAsset_003Ed__2._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CLoadAppDataAsset_003Ed__2._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CLoadAppDataAsset_003Ed__2._003C_003Et__builder)).Start<_003CLoadAppDataAsset_003Ed__1>(ref _003CLoadAppDataAsset_003Ed__2);
		return ((AsyncUniTaskMethodBuilder)(ref _003CLoadAppDataAsset_003Ed__2._003C_003Et__builder)).Task;
	}

	public static AppTypeToData ReadAppContent(AppType appType)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)app2data == (Object)null)
		{
			app2data = Addressables.LoadAssetAsync<AppTypeToDataAsset>((object)"Apps").WaitForCompletion();
		}
		if ((Object)(object)app2data != (Object)null)
		{
			return app2data.Apps.Find((AppTypeToData app) => app.appType == appType);
		}
		return null;
	}

	public static bool IsAppDataExist()
	{
		return (Object)(object)app2data != (Object)null;
	}
}
