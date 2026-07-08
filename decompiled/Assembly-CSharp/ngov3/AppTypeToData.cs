using System;
using NGO;
using UnityEngine;

namespace ngov3;

[Serializable]
public class AppTypeToData
{
	public string AppNameJP;

	public SystemTextType AppName;

	public AppType appType;

	public Sprite appIcon;

	public float FirstWidth;

	public float FirstHeight;

	public float FirstPosX;

	public float FirstPosY;

	public bool isOnly;

	public GameObject InnerContent;

	public bool is2DWindow;

	public AppTypeToData(bool isOnly)
	{
		appType = AppType.Test;
		AppNameJP = "testJP";
		FirstWidth = 200f;
		FirstHeight = 200f;
		FirstPosX = 0f;
		FirstPosY = 0f;
		this.isOnly = isOnly;
	}
}
