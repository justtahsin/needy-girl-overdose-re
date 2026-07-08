using System;
using System.Collections.Generic;
using NGO;
using UnityEngine;

namespace ngov3;

public class App_LoadData : MonoBehaviour
{
	[SerializeField]
	private Transform parent;

	[SerializeField]
	private GameObject _achievedBlock;

	[SerializeField]
	private GameObject _unachievedBlock;

	public void Awake()
	{
		List<EndingType> mitaEnd = SingletonMonoBehaviour<Settings>.Instance.mitaEnd;
		string[] names = Enum.GetNames(typeof(EndingType));
		foreach (string id in names)
		{
			if (!(id == "Ending_None") && !(id == "Ending_Completed") && !(id == "Ending_NetShut"))
			{
				if (mitaEnd.Exists((EndingType gotend) => gotend.ToString() == id))
				{
					UnityEngine.Object.Instantiate(_achievedBlock, parent);
				}
				else
				{
					UnityEngine.Object.Instantiate(_unachievedBlock, parent);
				}
			}
		}
	}
}
