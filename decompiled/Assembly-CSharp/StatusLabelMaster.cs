using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatusLabelMaster : ScriptableObject, IParamSetter<StatusLabelMaster.Param>
{
	[Serializable]
	public class Param
	{
		public string Id;

		public string Body;

		public string BodyEn;

		public string BodyCn;

		public string BodyKo;

		public string BodyTw;
	}

	public List<Param> param = new List<Param>();

	public void SetParam<T>(IEnumerable<T> newParams)
	{
		param = newParams.Cast<Param>().ToList();
	}
}
