using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;

namespace ngov3;

public static class ImageViewerHelper
{
	public static List<ResourceLocal> _ResourcesList;

	public static List<ResourceLocal> _FanArtList;

	public static async UniTaskVoid OpenImageViewer(string address)
	{
		if ((from iv in Object.FindObjectsByType<ImageViewer>(FindObjectsSortMode.InstanceID)
			where iv.ImageAddress == address
			select iv).Count() == 0)
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.ImageViewer).nakamiApp.GetComponent<ImageViewer>().SetData(address);
		}
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
