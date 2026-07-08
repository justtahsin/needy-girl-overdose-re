using System;
using System.Collections.Generic;
using NGO;

namespace ngov3;

[Serializable]
public class SettingData
{
	public LanguageType languageType = LanguageType.EN;

	public float bgmVolume = 0.6f;

	public float seVolume = 0.8f;

	public int haishinSpeed;

	public List<EndingType> mitaEnd = new List<EndingType>();

	public List<string> imageHistory = new List<string>();

	public List<int> unLockedZip = new List<int>();

	public ResolutionType resolution;

	public VibrationType vibrationType;

	public List<string> animationKeyHistory = new List<string>();
}
