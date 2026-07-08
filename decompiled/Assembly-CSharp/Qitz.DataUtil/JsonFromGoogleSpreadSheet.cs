using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Qitz.DataUtil;

public static class JsonFromGoogleSpreadSheet
{
	public static IEnumerator GetTeargetTypeDataFromGoogleSpreadSheetUrl<T>(string url, Action<List<T>> callBack)
	{
		yield return GetJsonArrayFromGoogleSpreadSheetUrl(url, delegate(string[] jsonArray)
		{
			callBack(jsonArray.Select((string json) => JsonUtility.FromJson<T>(json)).ToList());
		});
	}

	public static IEnumerator GetJsonArrayFromGoogleSpreadSheetUrl(string url, Action<string[]> callBack)
	{
		yield return CSVFromGoogleSpreadSheet.GetCSVFromGoogleSpreadSheetUrl(url, delegate(string csv)
		{
			callBack(GetJsonArrayFromCSV(csv));
		});
	}

	public static string[] GetJsonArrayFromCSV(string csv)
	{
		string[] array = csv.Split(new string[1] { "\r\n" }, StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = array[i].Replace("\"", "");
			array[i] = array[i].Replace("\r", "¥n").Replace("\n", "¥n");
		}
		string[] array2 = new string[array.Length - 1];
		List<string> list = array.Skip(1).ToList();
		string[] array3 = array[0].Split(',');
		int num = 0;
		foreach (string item in list)
		{
			string[] array4 = item.Split(',');
			string text = "{\"";
			for (int j = 0; j < array3.Length; j++)
			{
				if (j != 0)
				{
					text += "\"";
				}
				text += array3[j];
				text += "\":\"";
				text += array4[j];
				text += "\"";
				if (j != array3.Length - 1)
				{
					text += ",";
				}
			}
			text += "}";
			text = text.Replace("\b", "");
			array2[num] = text;
			num++;
		}
		return array2;
	}
}
