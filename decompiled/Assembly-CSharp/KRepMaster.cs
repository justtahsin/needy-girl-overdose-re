using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KRepMaster : ScriptableObject, IParamSetter<KRepMaster.Param>
{
	[Serializable]
	public class Param
	{
		public string Id;

		public string ParentID;

		public string IconId;

		public string UserId;

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

		public string ImageId;
	}

	public List<Param> param = new List<Param>();

	public void SetParam<T>(IEnumerable<T> newParams)
	{
		param = newParams.Cast<Param>().ToList();
	}
}
