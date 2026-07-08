using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CmdMaster : ScriptableObject, IParamSetter<CmdMaster.Param>
{
	[Serializable]
	public class Param
	{
		public string ParentAct;

		public string Id;

		public string LabelJp;

		public string LabelEn;

		public string LabelCn;

		public string LabelKo;

		public string LabelTw;

		public string LabelVn;

		public string LabelFr;

		public string LabelIt;

		public string LabelGe;

		public string LabelSp;

		public string LabelRu;

		public string DescJp;

		public string DescEn;

		public string DescCn;

		public string DescKo;

		public string DescTw;

		public string DescVn;

		public string DescFr;

		public string DescIt;

		public string DescGe;

		public string DescSp;

		public string DescRu;

		public string TweetID;

		public int PassingTime;

		public int FollowerDelta;

		public int AttentionDelta;

		public int StressDelta;

		public int YamiDelta;

		public int FavorDelta;

		public int OkusuriCount;

		public int OirokeCount;

		public int SNS;

		public int GameCount;

		public int CinePhillCount;

		public int ShabekuriCount;

		public int DatespotCount;

		public int Harumagedo;
	}

	public List<Param> param = new List<Param>();

	public void SetParam<T>(IEnumerable<T> newParams)
	{
		param = newParams.Cast<Param>().ToList();
	}
}
