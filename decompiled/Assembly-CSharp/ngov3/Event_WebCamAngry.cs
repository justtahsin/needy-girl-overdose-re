using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Event_WebCamAngry : MonoBehaviour
{
	private void Awake()
	{
		if (!SingletonMonoBehaviour<WebCamManager>.Instance.hidegirl.Value)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(((Component)this).GetComponent<Button>()), (Action<Unit>)delegate
			{
				Angry();
			}), ((Component)this).gameObject);
		}
	}

	public async void Angry()
	{
		await UniTask.Delay(300, false, (PlayerLoopTiming)8, default(CancellationToken), false);
		if (!SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.Webcam))
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		}
		SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Webcam));
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_henoji");
		await UniTask.Delay(1800, false, (PlayerLoopTiming)8, default(CancellationToken), false);
		SingletonMonoBehaviour<WebCamManager>.Instance.ResetAnim();
	}
}
