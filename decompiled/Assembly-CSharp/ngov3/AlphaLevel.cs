using System;

namespace ngov3;

[Serializable]
public class AlphaLevel
{
	public AlphaType alphaType;

	public int level;

	public AlphaLevel(AlphaType alphaType, int level)
	{
		this.alphaType = alphaType;
		this.level = level;
	}

	public AlphaLevel()
	{
		alphaType = AlphaType.none;
		level = 0;
	}
}
