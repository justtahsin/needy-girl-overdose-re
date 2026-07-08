using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceMaster : ScriptableObject, IParamSetter<ResourceMaster.Param>
{
	[Serializable]
	public class Param
	{
		public string Id;

		public string FileName;
	}

	public List<Param> param = new List<Param>();

	public void SetParam<T>(IEnumerable<T> newParams)
	{
		param = newParams.Cast<Param>().ToList();
	}
}
