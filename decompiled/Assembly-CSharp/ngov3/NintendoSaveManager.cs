using System.Collections.Generic;

namespace ngov3;

public static class NintendoSaveManager
{
	public static void Init()
	{
	}

	public static string GetSavePath(string fileName)
	{
		return "";
	}

	public static bool IsExistSlotData(string fileName)
	{
		return false;
	}

	public static void SaveSlot(string fileName, string slotJson)
	{
	}

	public static string LoadSlot(string fileName)
	{
		return "";
	}

	public static void DeleteSaveData(string fileName)
	{
	}

	public static void DeleteSaveDatas(List<string> fileNames)
	{
	}

	public static string GetSettingPath()
	{
		return "";
	}

	public static bool IsExistSettingData()
	{
		return false;
	}

	public static void SaveSettingData(string systemJson)
	{
	}

	public static string LoadSettingData()
	{
		return "";
	}
}
