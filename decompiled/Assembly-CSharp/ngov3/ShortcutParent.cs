using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ngov3;

public class ShortcutParent : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> _selectableObjects;

	public List<GameObject> SelectabelObjects => _selectableObjects.Where((GameObject s) => s.gameObject.activeSelf).ToList();

	private async void Start()
	{
		RestShortCutCollider();
	}

	private async void RestShortCutCollider()
	{
		await UniTask.DelayFrame(1, (PlayerLoopTiming)8, default(CancellationToken), false);
		((Component)this).gameObject.SetActive(false);
		await UniTask.DelayFrame(1, (PlayerLoopTiming)8, default(CancellationToken), false);
		((Component)this).gameObject.SetActive(true);
	}
}
