using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace ngov3;

public static class LoadAppData
{
	private static AppTypeToDataAsset app2data;

	public static async UniTask LoadAppDataAsset()
	{
		AppTypeToDataAsset appTypeToDataAsset = await Addressables.LoadAssetAsync<AppTypeToDataAsset>("Apps");
		if (appTypeToDataAsset != null)
		{
			app2data = appTypeToDataAsset;
		}
	}

	public static AppTypeToData ReadAppContent(AppType appType)
	{
		if (app2data == null)
		{
			app2data = Addressables.LoadAssetAsync<AppTypeToDataAsset>("Apps").WaitForCompletion();
		}
		if (app2data != null)
		{
			return app2data.Apps.Find((AppTypeToData app) => app.appType == appType);
		}
		return null;
	}

	public static bool IsAppDataExist()
	{
		return app2data != null;
	}
}
