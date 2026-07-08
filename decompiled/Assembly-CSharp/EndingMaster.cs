using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EndingMaster : ScriptableObject, IParamSetter<EndingMaster.Param>
{
	[Serializable]
	public class Param
	{
		public string Id;

		public string EndingNameJp;

		public string EndingNameEn;

		public string EndingNameCn;

		public string EndingNameKo;

		public string EndingNameTw;

		public string EndingNameVn;

		public string EndingNameFr;

		public string EndingNameIt;

		public string EndingNameGe;

		public string EndingNameSp;

		public string EndingNameRu;

		public string JissekiJp;

		public string JissekiEn;

		public string JissekiCn;

		public string JissekiKo;

		public string JissekiTw;

		public string JissekiVn;

		public string JissekiFr;

		public string JissekiIt;

		public string JissekiGe;

		public string JissekiSp;

		public string JissekiRu;

		public string ReasonJp;

		public string ReasonEn;

		public string ReasonCn;

		public string ReasonKo;

		public string ReasonTw;

		public string ReasonVn;

		public string ReasonFr;

		public string ReasonIt;

		public string ReasonGe;

		public string ReasonSp;

		public string ReasonRu;
	}

	public List<Param> param = new List<Param>();

	public void SetParam<T>(IEnumerable<T> newParams)
	{
		param = newParams.Cast<Param>().ToList();
	}
}
