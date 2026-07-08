using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MobCommentMaster : ScriptableObject, IParamSetter<MobCommentMaster.Param>
{
	[Serializable]
	public class Param
	{
		public string Id;

		public int Rank;

		public string BodyJP;

		public string BodyEn;

		public string BodyCh;

		public string BodyKo;

		public string BodyTw;

		public string BodyVn;

		public string BodyFr;

		public string BodyIt;

		public string BodyGe;

		public string BodySp;

		public string BodyRu;

		public string timing;

		public string goodbad;
	}

	public List<Param> param = new List<Param>();

	public void SetParam<T>(IEnumerable<T> newParams)
	{
		param = newParams.Cast<Param>().ToList();
	}
}
