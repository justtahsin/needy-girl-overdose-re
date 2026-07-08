using System;
using NGO;

namespace ngov3;

[Serializable]
public struct Playing
{
	public bool isJimaku;

	public bool isYohaku;

	public string nakami;

	public StatusType diffStatusType;

	public int delta;

	public int additionalTension;

	public string henji;

	public string animation;

	public bool isLoopAnim;

	public string henjiAnim;

	public bool isSetting;

	public SoundType ongaku;

	public ChanceEffectType obi;

	public string inout;

	public bool startReading;

	public SuperchatType color;

	public bool showAnti;

	public string antiComment;

	public Playing(bool isJimaku, string nakami, StatusType difftype = StatusType.Tension, int delta = 1, int AdditionalTension = 0, string henji = "", string henjiAnim = "", string animation = "", bool isLoopAnim = true, SuperchatType color = SuperchatType.White, bool showAnti = false, string antiComment = "")
	{
		if (isJimaku)
		{
			isYohaku = false;
			this.isJimaku = true;
			this.nakami = nakami;
			diffStatusType = difftype;
			this.delta = delta;
			additionalTension = AdditionalTension;
			this.henji = henji;
			this.henjiAnim = henjiAnim;
			this.animation = animation;
			this.isLoopAnim = isLoopAnim;
			isSetting = false;
			ongaku = SoundType.None;
			obi = ChanceEffectType.None;
			inout = "";
			startReading = false;
			this.color = SuperchatType.White;
			this.showAnti = showAnti;
			this.antiComment = antiComment;
		}
		else
		{
			isYohaku = false;
			this.isJimaku = false;
			this.nakami = nakami;
			diffStatusType = difftype;
			this.delta = delta;
			additionalTension = AdditionalTension;
			this.henji = henji;
			this.henjiAnim = henjiAnim;
			this.animation = "";
			this.isLoopAnim = false;
			isSetting = false;
			ongaku = SoundType.None;
			obi = ChanceEffectType.None;
			inout = "";
			startReading = false;
			this.color = color;
			this.showAnti = showAnti;
			this.antiComment = antiComment;
		}
	}

	public Playing(bool isJimaku, bool isBadComment, string nakami)
	{
		isYohaku = false;
		this.isJimaku = isJimaku;
		this.nakami = nakami;
		additionalTension = 0;
		henji = "";
		henjiAnim = "";
		animation = "";
		isLoopAnim = false;
		isSetting = false;
		ongaku = SoundType.None;
		obi = ChanceEffectType.None;
		inout = "";
		startReading = false;
		color = SuperchatType.White;
		showAnti = false;
		antiComment = "";
		if (isBadComment)
		{
			diffStatusType = StatusType.Stress;
			delta = -1;
		}
		else
		{
			diffStatusType = StatusType.Tension;
			delta = 0;
		}
	}

	public Playing(string position = "middle")
	{
		isYohaku = true;
		isJimaku = false;
		nakami = position;
		diffStatusType = StatusType.Tension;
		delta = 0;
		additionalTension = 0;
		henji = "";
		henjiAnim = "";
		animation = "";
		isLoopAnim = false;
		isSetting = false;
		ongaku = SoundType.None;
		obi = ChanceEffectType.None;
		inout = "";
		startReading = false;
		color = SuperchatType.White;
		showAnti = false;
		antiComment = "";
	}

	public Playing(SoundType sound, bool isloop)
	{
		isYohaku = false;
		isJimaku = false;
		nakami = "";
		diffStatusType = StatusType.Tension;
		delta = 0;
		additionalTension = 0;
		henji = "";
		henjiAnim = "";
		animation = "";
		isLoopAnim = isloop;
		isSetting = true;
		ongaku = sound;
		obi = ChanceEffectType.None;
		inout = "";
		startReading = false;
		color = SuperchatType.White;
		showAnti = false;
		antiComment = "";
	}

	public Playing(ChanceEffectType chance, string inout)
	{
		isYohaku = false;
		isJimaku = false;
		nakami = "";
		diffStatusType = StatusType.Tension;
		delta = 0;
		additionalTension = 0;
		henji = "";
		henjiAnim = "";
		animation = "";
		isLoopAnim = false;
		isSetting = true;
		ongaku = SoundType.None;
		obi = chance;
		this.inout = inout;
		startReading = false;
		color = SuperchatType.White;
		showAnti = false;
		antiComment = "";
	}

	public Playing(bool startRead)
	{
		isYohaku = false;
		isJimaku = false;
		nakami = "";
		diffStatusType = StatusType.Tension;
		delta = 0;
		additionalTension = 0;
		henji = "";
		henjiAnim = "";
		animation = "";
		isLoopAnim = false;
		isSetting = false;
		ongaku = SoundType.None;
		obi = ChanceEffectType.None;
		inout = "";
		startReading = true;
		color = SuperchatType.White;
		showAnti = false;
		antiComment = "";
	}
}
