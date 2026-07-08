using System;
using System.Collections.Generic;
using UnityEngine;

namespace NGO;

public class ResourceLocalMaster : ScriptableObject, ILocalMaster<Sprite>
{
	private const string _CRPATH = "Assets/_NGO/_Designer/Credits/";

	private const string _PATH = "Assets/_NGO/Nen_ai/LocalData/";

	private const string _PHOTO_PATH = "Assets/_NGO/_Designer/Images/TweetPhoto";

	private const string _FUN_ARTS_PRO_PATH = "Assets/_NGO/FunArts/Pro";

	private const string _FUN_ARTS_PI_PATH = "Assets/_NGO/FunArts/Pi";

	public List<ResourceLocal> ResourceList = new List<ResourceLocal>();

	public Sprite BaseType()
	{
		throw new NotImplementedException();
	}

	public void UpdateMaster()
	{
	}

	public void AddTextureToAddressabe()
	{
	}
}
