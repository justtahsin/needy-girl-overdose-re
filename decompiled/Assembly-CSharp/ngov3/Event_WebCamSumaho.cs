using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ngov3;

public class Event_WebCamSumaho : MonoBehaviour
{
	public async UniTask OnLooking(int looking = 2000)
	{
		SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
		await UniTask.Delay(looking);
		OnBlur();
	}

	public async UniTask StartLooking()
	{
		SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
	}

	public void OnBlur()
	{
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayCurrentAnim();
	}
}
