using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Qitz.DataUtil;

public class BaseDataStore<T> : ScriptableObject
{
	[SerializeField]
	[Header("マスターデータ読み込みタイプ")]
	private LoadingType loadingType;

	[SerializeField]
	[Header("読み込み元のGoogoleSpreadSheetのurl")]
	private string loadingServerUrl;

	[SerializeField]
	[Header("CSVから読み込む")]
	private TextAsset csv;

	[SerializeField]
	private List<T> items;

	public List<T> Items => items;

	[ContextMenu("サーバーからデータを読み込む")]
	protected virtual void LoadDataFromServer()
	{
		if (loadingType == LoadingType.URL)
		{
			LoadFromURL(loadingServerUrl);
		}
		else
		{
			LoadFromCSV(csv.text);
		}
	}

	private void LoadFromURL(string loadingServerUrl)
	{
		GameObject ga = new GameObject();
		ga.AddComponent<StartCorutinReferrer>().StartCoroutine(JsonFromGoogleSpreadSheet.GetJsonArrayFromGoogleSpreadSheetUrl(loadingServerUrl, delegate(string[] jsonArry)
		{
			items = jsonArry.Select((string j) => JsonUtility.FromJson<T>(j)).ToList();
			Object.DestroyImmediate(ga);
		}));
	}

	private void LoadFromCSV(string csv)
	{
		string[] jsonArrayFromCSV = JsonFromGoogleSpreadSheet.GetJsonArrayFromCSV(csv);
		items = jsonArrayFromCSV.Select((string j) => JsonUtility.FromJson<T>(j)).ToList();
	}
}
