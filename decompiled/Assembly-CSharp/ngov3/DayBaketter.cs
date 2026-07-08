using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

namespace ngov3;

public class DayBaketter : MonoBehaviour
{
	[SerializeField]
	private TMP_Text label;

	private List<string> bakes = new List<string>
	{
		"荳?", "縺", "､莠", "後", "ｉ荳", "峨＞", "蝗", "帙", "ｈ", "莠",
		"斐", "←蜈", "ｭ縺?", "ｸ?", "＠蜈ｫ", "縺ｦ", "荵", "昴≠", "縲?", "≠蜉ｩ",
		"縺", "代※"
	};

	public void Start()
	{
		(from v in SingletonMonoBehaviour<EventManager>.Instance.ObserveEveryValueChanged((EventManager v) => v.isHorror)
			where v
			select v).Subscribe(delegate
		{
			AddBake();
		}).AddTo(base.gameObject);
	}

	private void AddBake()
	{
		if (!(label == null))
		{
			label.text = bakes[Random.Range(0, bakes.Count)];
		}
	}
}
