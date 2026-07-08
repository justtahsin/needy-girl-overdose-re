using System.Collections.Generic;
using UnityEngine;

namespace ngov3;

public class Odekake : MonoBehaviour
{
	[SerializeField]
	private GameObject GingaStation;

	[SerializeField]
	private List<GameObject> _odekakeButtonObjs = new List<GameObject>();

	public List<GameObject> SelectableObjects => _odekakeButtonObjs;

	public void Awake()
	{
		bool active = SingletonMonoBehaviour<StatusManager>.Instance.isTodayGangimari && SingletonMonoBehaviour<NetaManager>.Instance.usedAlpha.Exists((AlphaLevel al) => al.alphaType == AlphaType.Kaidan && al.level == 5);
		GingaStation.SetActive(active);
	}
}
