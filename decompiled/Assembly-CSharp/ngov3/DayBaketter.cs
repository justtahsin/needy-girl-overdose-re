using System;
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
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(Observable.Where<bool>(ObserveExtensions.ObserveEveryValueChanged<EventManager, bool>(SingletonMonoBehaviour<EventManager>.Instance, (Func<EventManager, bool>)((EventManager v) => v.isHorror), (FrameCountType)0, false), (Func<bool, bool>)((bool v) => v)), (Action<bool>)delegate
		{
			AddBake();
		}), ((Component)this).gameObject);
	}

	private void AddBake()
	{
		if (!((Object)(object)label == (Object)null))
		{
			label.text = bakes[Random.Range(0, bakes.Count)];
		}
	}
}
