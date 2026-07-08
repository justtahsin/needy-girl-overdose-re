using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Qitz.DataUtil;

public static class CSVFromGoogleSpreadSheet
{
	public static IEnumerator GetCSVFromGoogleSpreadSheetUrl(string url, Action<string> callBack)
	{
		url = url.Replace("edit#", "export?format=csv&");
		UnityWebRequest request = UnityWebRequest.Get(url);
		yield return request.Send();
		if (request.isNetworkError)
		{
			Debug.LogError((object)request.error);
			callBack(request.error);
		}
		else
		{
			string text = request.downloadHandler.text;
			callBack(text);
		}
	}
}
