using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using yutokun;

namespace CSVUtil;

public class NGOMasterMergUseCase
{
	public List<List<string>> LoadCSV(string csvPath)
	{
		return CSVParser.LoadFromString(new StreamReader(csvPath, Encoding.UTF8).ReadToEnd());
	}

	public List<List<string>> GetAlignCSVColumn(List<List<string>> referToCSV, List<List<string>> alignSideCSV)
	{
		List<string> list = referToCSV.FirstOrDefault();
		List<Dictionary<string, string>> list2 = CreateKeyValuePairList(alignSideCSV);
		List<List<string>> list3 = new List<List<string>> { list };
		foreach (Dictionary<string, string> item in list2)
		{
			List<string> list4 = new List<string>();
			foreach (string item2 in list)
			{
				if (item.ContainsKey(item2))
				{
					list4.Add(item[item2]);
				}
				else
				{
					list4.Add("");
				}
			}
			list3.Add(list4);
		}
		return list3;
	}

	public void ExportCSV(string outPutPath, List<List<string>> taretList)
	{
		List<Dictionary<string, string>> keyValues = CreateKeyValuePairList(taretList);
		Debug.Log((object)("outPutPath=" + outPutPath));
		ExportCSV(outPutPath, keyValues);
	}

	public void ExportCSV(string outPutPath, List<Dictionary<string, string>> keyValues)
	{
		if (keyValues.Count == 0)
		{
			Debug.LogError((object)"データが空です");
			return;
		}
		IEnumerable<string> header = from keyValuePair in keyValues.FirstOrDefault()
			select keyValuePair.Key;
		string text = GetHeaderTextLine(header);
		foreach (Dictionary<string, string> keyValue in keyValues)
		{
			IEnumerable<string> enumerable = keyValue.Select((KeyValuePair<string, string> keyValue) => keyValue.Value);
			string text2 = "";
			int num = 0;
			foreach (string item in enumerable)
			{
				num++;
				bool num2 = enumerable.Count() <= num;
				text2 += "\"";
				text2 += item.Replace('"', '”');
				text2 += "\"";
				if (!num2)
				{
					text2 += ",";
				}
			}
			text += text2;
			text += Environment.NewLine;
		}
		StreamWriter streamWriter = new StreamWriter(outPutPath, append: false, Encoding.UTF8);
		streamWriter.Write(text);
		streamWriter.Close();
	}

	private string GetHeaderTextLine(IEnumerable<string> header)
	{
		string text = "";
		int num = 0;
		foreach (string item in header)
		{
			num++;
			bool num2 = header.Count() <= num;
			text += "\"";
			text += item;
			text += "\"";
			if (!num2)
			{
				text += ",";
			}
		}
		return text + Environment.NewLine;
	}

	public List<Dictionary<string, string>> GetValueMergedCSV(string idKey, List<List<string>> mergeTargetCSV, List<List<string>> mergeSideCSV)
	{
		List<Dictionary<string, string>> rowMergedCSV = GetRowMergedCSV(idKey, mergeTargetCSV, mergeSideCSV);
		List<Dictionary<string, string>> searchTarget = CreateKeyValuePairList(mergeSideCSV);
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		foreach (Dictionary<string, string> item in rowMergedCSV)
		{
			string id = item[idKey];
			Dictionary<string, string> iDDict = GetIDDict(id, searchTarget);
			if (iDDict != null)
			{
				Dictionary<string, string> mergedDict = GetMergedDict(item, iDDict);
				list.Add(mergedDict);
			}
			else
			{
				list.Add(item);
			}
		}
		return list;
	}

	private Dictionary<string, string> GetMergedDict(Dictionary<string, string> mergeTarget, Dictionary<string, string> mergeSide)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (string item in mergeTarget.Select((KeyValuePair<string, string> keyValuePair) => keyValuePair.Key))
		{
			if (mergeTarget[item] != mergeSide[item] && !string.IsNullOrEmpty(mergeSide[item]))
			{
				dictionary.Add(item, mergeSide[item]);
			}
			else
			{
				dictionary.Add(item, mergeTarget[item]);
			}
		}
		return dictionary;
	}

	private List<Dictionary<string, string>> GetRowMergedCSV(string idKey, List<List<string>> mergeTargetCSV, List<List<string>> mergeSideCSV)
	{
		List<Dictionary<string, string>> list = CreateKeyValuePairList(mergeTargetCSV);
		List<Dictionary<string, string>> list2 = CreateKeyValuePairList(mergeSideCSV);
		List<Dictionary<string, string>> list3 = new List<Dictionary<string, string>>();
		foreach (Dictionary<string, string> item in list2)
		{
			string id = item[idKey];
			if (GetIDDict(id, list) == null)
			{
				list3.Add(item);
			}
		}
		list.AddRange(list3);
		return list;
	}

	public Dictionary<string, string> GetIDDict(string id, List<Dictionary<string, string>> searchTarget)
	{
		foreach (Dictionary<string, string> item in searchTarget)
		{
			foreach (KeyValuePair<string, string> item2 in item)
			{
				if (item2.Value == id)
				{
					return item;
				}
			}
		}
		return null;
	}

	private List<Dictionary<string, string>> CreateKeyValuePairList(List<List<string>> targetCSV)
	{
		List<string> list = targetCSV.FirstOrDefault();
		List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
		IEnumerable<List<string>> enumerable = targetCSV.Skip(1);
		int num = 1;
		foreach (List<string> item in enumerable)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			for (int i = 0; i < list.Count; i++)
			{
				try
				{
					dictionary.Add(list[i], item[i]);
				}
				catch (Exception ex)
				{
					throw new Exception("error occard" + list[i] + ":" + item[i] + ":" + num + ":" + ex);
				}
			}
			list2.Add(dictionary);
			num++;
		}
		return list2;
	}
}
