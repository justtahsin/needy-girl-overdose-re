using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventTextMaster : ScriptableObject, IParamSetter<EventTextMaster.Param>
{
	[Serializable]
	public class Param
	{
		public string Id;

		public string EventId;

		public string BodyJp;

		public string BodyEn;

		public string BodyCn;

		public string BodyKo;

		public string BodyTw;

		public string ArgumentType1;

		public string ArgumentType2;

		public string ArgumentType3;

		public string ArgumentType4;
	}

	public List<Param> param = new List<Param>();

	public void SetParam<T>(IEnumerable<T> newParams)
	{
		param = newParams.Cast<Param>().ToList();
	}
}
