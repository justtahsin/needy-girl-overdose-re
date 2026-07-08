using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace ngov3;

public class NetaManager : SingletonMonoBehaviour<NetaManager>
{
	private readonly ReactiveCollection<AlphaLevel> _gotAlpha = new ReactiveCollection<AlphaLevel>
	{
		new AlphaLevel(AlphaType.Zatudan, 1)
	};

	public List<AlphaLevel> GotAlpha = new List<AlphaLevel>
	{
		new AlphaLevel(AlphaType.Zatudan, 1)
	};

	private readonly ReactiveCollection<AlphaLevel> _usedAlpha = new ReactiveCollection<AlphaLevel>();

	public List<AlphaLevel> usedAlpha = new List<AlphaLevel>();

	private ChipGetCover _chipGet;

	private EventManager _event;

	public IObservable<CollectionAddEvent<AlphaLevel>> OnAddAlpha => _gotAlpha.ObserveAdd();

	public IObservable<CollectionAddEvent<AlphaLevel>> OnUseAlpha => _usedAlpha.ObserveAdd();

	public ChipGetCover ChipGetCover => _chipGet;

	protected override void Awake()
	{
		base.Awake();
		_chipGet = GameObject.Find("ChipGetCover").GetComponent<ChipGetCover>();
		OnAddAlpha.Subscribe(delegate(CollectionAddEvent<AlphaLevel> value)
		{
			GotAlpha.Add(value.Value);
		}).AddTo(this);
		OnUseAlpha.Subscribe(delegate(CollectionAddEvent<AlphaLevel> value)
		{
			usedAlpha.Add(value.Value);
		}).AddTo(this);
	}

	public void ShowingGettingChip(AlphaType gotChip, int level)
	{
		_chipGet.getNewChip(gotChip, level);
		if (GotAlpha.Count == 2)
		{
			SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tutorial_neta);
		}
	}

	public int GetAlphaChipLevel(AlphaType chip)
	{
		List<AlphaLevel> list = GotAlpha.Where((AlphaLevel a) => a.alphaType == chip).ToList();
		if (list.Count == 0)
		{
			return 0;
		}
		return list.Max((AlphaLevel a) => a.level);
	}

	public void GetChip(AlphaType gotChip, int level)
	{
		_gotAlpha.Add(new AlphaLevel(gotChip, level));
	}

	public void Haishined(AlphaType alpha, int level)
	{
		_usedAlpha.Add(new AlphaLevel(alpha, level));
	}

	public List<Tuple<ActionType, AlphaLevel>> fetchNextActionHint()
	{
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		List<Tuple<ActionType, AlphaLevel>> list = new List<Tuple<ActionType, AlphaLevel>>();
		int num = Enum.GetNames(typeof(AlphaType)).Length - 3;
		for (int i = 0; i <= num; i++)
		{
			AlphaType type = (AlphaType)Enum.ToObject(typeof(AlphaType), i);
			List<AlphaLevel> list2 = usedAlpha.FindAll((AlphaLevel a) => a.alphaType == type);
			int nextlevel;
			if (list2.Count == 0)
			{
				nextlevel = 1;
			}
			else
			{
				nextlevel = list2.Max((AlphaLevel a) => a.level) + 1;
			}
			if ((nextlevel != 3 || status >= 10000) && (nextlevel != 4 || status >= 100000) && (nextlevel != 5 || status >= 250000) && !GotAlpha.Any((AlphaLevel alphaLevel) => alphaLevel.alphaType == type && alphaLevel.level == nextlevel))
			{
				AlphaTypeToData alphaTypeToData = LoadNetaData.ReadNetaContent(type, nextlevel);
				if (alphaTypeToData != null)
				{
					AlphaLevel item = new AlphaLevel(type, nextlevel);
					Tuple<ActionType, AlphaLevel> item2 = new Tuple<ActionType, AlphaLevel>(alphaTypeToData.getJouken, item);
					list.Add(item2);
				}
			}
		}
		return list;
	}
}
