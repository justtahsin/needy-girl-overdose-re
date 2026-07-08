using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UnityEngine;

namespace ngov3;

public static class ImageViewerHelper
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003COpenImageViewer_003Ed__0 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public string address;

		private void MoveNext()
		{
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				string address = this.address;
				if ((from iv in Object.FindObjectsByType<ImageViewer>((FindObjectsSortMode)1)
					where iv.ImageAddress == address
					select iv).Count() == 0)
				{
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.ImageViewer).nakamiApp.GetComponent<ImageViewer>().SetData(address);
				}
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public static List<ResourceLocal> _ResourcesList;

	public static List<ResourceLocal> _FanArtList;

	[AsyncStateMachine(typeof(_003COpenImageViewer_003Ed__0))]
	public static UniTaskVoid OpenImageViewer(string address)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003COpenImageViewer_003Ed__0 _003COpenImageViewer_003Ed__1 = default(_003COpenImageViewer_003Ed__0);
		_003COpenImageViewer_003Ed__1._003C_003Et__builder = AsyncUniTaskVoidMethodBuilder.Create();
		_003COpenImageViewer_003Ed__1.address = address;
		_003COpenImageViewer_003Ed__1._003C_003E1__state = -1;
		((AsyncUniTaskVoidMethodBuilder)(ref _003COpenImageViewer_003Ed__1._003C_003Et__builder)).Start<_003COpenImageViewer_003Ed__0>(ref _003COpenImageViewer_003Ed__1);
		return ((AsyncUniTaskVoidMethodBuilder)(ref _003COpenImageViewer_003Ed__1._003C_003Et__builder)).Task;
	}

	public static List<ResourceLocal> LoadResourcesList()
	{
		if (_ResourcesList == null)
		{
			_ResourcesList = Resources.Load<ResourceLocalMaster>("LocalMaster/ResourceLocalMaster")?.ResourceList;
		}
		return _ResourcesList;
	}

	public static List<ResourceLocal> LoadFanArtList()
	{
		if (_FanArtList == null)
		{
			_FanArtList = Resources.Load<ResourceLocalMaster>("LocalMaster/ResourceLocalMaster")?.ResourceList.Where((ResourceLocal r) => r.Id.StartsWith("@")).ToList();
		}
		return _FanArtList;
	}
}
