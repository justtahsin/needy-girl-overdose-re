using System;
using System.Collections.Generic;
using NGO;

namespace ngov3;

[Serializable]
public class SlotData
{
	public List<JineData> jineHistory;

	public List<TweetData> poketterHistory;

	public List<string> eventsHistory;

	public List<string> dayActionHistory;

	public int loop;

	public int midokumushi;

	public int psycheCount;

	public List<AlphaLevel> havingNetas;

	public List<AlphaLevel> usedNetas;

	public bool isJuncho;

	public bool isHearTrauma;

	public JineType trauma;

	public CmdType firstDate = CmdType.None;

	public bool isHappaOK;

	public bool isHorror;

	public bool isGedatsu;

	public bool beforeWristCut;

	public bool isWristCut;

	public bool isHakkyo;

	public int wishlist;

	public int loveDiary;

	public bool isShurokued;

	public int kyuusiCount;

	public bool isOpenGinga;

	public bool is150mil;

	public bool is300mil;

	public bool is500mil;

	public List<Status> stats;
}
