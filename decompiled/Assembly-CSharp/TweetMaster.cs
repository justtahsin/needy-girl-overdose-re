using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TweetMaster : ScriptableObject, IParamSetter<TweetMaster.Param>
{
	[Serializable]
	public class Param
	{
		public string Id;

		public string CommandID;

		public string Result;

		public string OmoteBodyJp;

		public string OmoteBodyEn;

		public string OmoteBodyCn;

		public string OtomeBodyKo;

		public string OmoteBodyTw;

		public string OmoteBodyVn;

		public string OmoteBodyFr;

		public string OmoteBodyIt;

		public string OmoteBodyGe;

		public string OmoteBodySp;

		public string OmoteBodyRu;

		public string OmoteImageId;

		public int BuzzPowerFav;

		public int BuzzPowerRT;

		public string UraBodyJp;

		public string UraBodyEn;

		public string UraBodyCn;

		public string UraBodyKo;

		public string UraBodyTw;

		public string UraBodyVn;

		public string UraBodyFr;

		public string UraBodyIt;

		public string UraBodyGe;

		public string UraBodySp;

		public string UraBodyRu;

		public string UraImageId;

		public bool isNight;

		public bool isDay;
	}

	public List<Param> param = new List<Param>();

	public void SetParam<T>(IEnumerable<T> newParams)
	{
		param = newParams.Cast<Param>().ToList();
	}
}
