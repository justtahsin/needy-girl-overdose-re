using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class Test_ShowAllJine : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		Debug.Log("Test_ShowAllJine");
		JineView2D jineView2D = null;
		Observable.Interval(TimeSpan.FromMilliseconds(1000.0)).Subscribe(delegate
		{
			if (jineView2D == null)
			{
				jineView2D = UnityEngine.Object.FindObjectOfType<JineView2D>();
			}
			jineView2D?.OnPicked();
		}).AddTo(SingletonMonoBehaviour<JineManager>.Instance);
		List<JineType> jines = new List<JineType>();
		foreach (JineType value in Enum.GetValues(typeof(JineType)))
		{
			jines.Add(value);
		}
		jines = jines.OrderBy((JineType j) => j.ToString()).ToList();
		int index = 0;
		foreach (JineType Value in jines)
		{
			if (index % 10 == 0)
			{
				SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(index + "/" + Enum.GetValues(typeof(JineType)).Length);
			}
			Debug.Log("作成開始：" + Value);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(Value);
			Debug.Log(index + "/" + jines.Count + "/" + Value);
			index++;
		}
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator("AllJineList End");
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		endEvent();
	}
}
