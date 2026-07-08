using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KituneMaster : ScriptableObject, IParamSetter<KituneMaster.Param>
{
	[Serializable]
	public class Param
	{
		public string Id;

		public string FollowerRank;

		public int ResNumber;

		public string BodyJp;

		public string BodyEn;

		public string BodyCn;

		public string BodyKo;

		public string BodyTw;

		public string BodyVn;

		public string BodyFr;

		public string BodyIt;

		public string BodyGe;

		public string BodySp;

		public string BodyRu;
	}

	public List<Param> param = new List<Param>();

	public void SetParam<T>(IEnumerable<T> newParams)
	{
		param = newParams.Cast<Param>().ToList();
	}
}
