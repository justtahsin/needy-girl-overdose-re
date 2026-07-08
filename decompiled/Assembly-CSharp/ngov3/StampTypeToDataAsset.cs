using System;
using System.Collections.Generic;
using UnityEngine;

namespace ngov3;

public class StampTypeToDataAsset : ScriptableObject
{
	[Serializable]
	public struct StampTypeToData
	{
		public StampType type;

		public Sprite JpImage;

		public Sprite EnImage;

		public Sprite CnImage;

		public Sprite KoImage;

		public Sprite TwImage;

		public Sprite VnImage;

		public Sprite FrImage;

		public Sprite ItImage;

		public Sprite GeImage;

		public Sprite SpImage;

		public Sprite RuImage;
	}

	public List<StampTypeToData> stampTypeToData = new List<StampTypeToData>();
}
