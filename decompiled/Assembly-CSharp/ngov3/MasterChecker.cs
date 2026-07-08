using System;
using System.Collections.Generic;
using System.Linq;
using NGO;
using UnityEngine;

namespace ngov3;

public class MasterChecker
{
	public void CheckSystemTextMaster()
	{
		List<SystemTextMaster.Param> param = Resources.Load<SystemTextMaster>("Master/SystemText").param;
		string[] names = Enum.GetNames(typeof(SystemTextType));
		foreach (string value in names)
		{
			if (param.FirstOrDefault((SystemTextMaster.Param x) => x.Id == value) == null)
			{
				Debug.LogError((object)("Resources/Master/SystemText:のmaster中に" + value + "の値が存在しません"));
			}
		}
	}

	public void CheckEndingTypeMaster()
	{
		List<EndingMaster.Param> param = Resources.Load<EndingMaster>("Master/Ending").param;
		foreach (EndingType value in Enum.GetValues(typeof(EndingType)))
		{
			if (param.FirstOrDefault((EndingMaster.Param x) => x.Id == value.ToString()) == null)
			{
				Debug.LogError((object)("Resources/Master/Ending:のmaster中に" + value.ToString() + "の値が存在しません"));
			}
		}
	}
}
