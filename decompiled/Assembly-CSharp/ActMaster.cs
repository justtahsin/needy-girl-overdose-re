using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActMaster : ScriptableObject, IParamSetter<ActMaster.Param>
{
	[Serializable]
	public class Param
	{
		public string Id;

		public string TitleJp;

		public string TitleEn;

		public string TitleCn;

		public string TitleKo;

		public string TitleTw;

		public string TitleVn;

		public string TitleFr;

		public string TitleIt;

		public string TitleGe;

		public string TitleSp;

		public string TitleRu;
	}

	public List<Param> param = new List<Param>();

	public void SetParam<T>(IEnumerable<T> newParams)
	{
		param = newParams.Cast<Param>().ToList();
	}
}
