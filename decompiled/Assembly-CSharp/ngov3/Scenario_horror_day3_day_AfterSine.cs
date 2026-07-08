using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Scenario_horror_day3_day_AfterSine : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
		List<IWindow> bins = new List<IWindow>();
		for (int bin = 0; bin < 20; bin++)
		{
			IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_NoInteractive(AppType.PillPuron_Horror);
			window.setRandomPosition();
			bins.Add(window);
			await UniTask.Delay(30);
		}
		await UniTask.Delay(30);
		for (int bin = 19; bin >= 0; bin--)
		{
			PronHorror pronView = bins[bin].nakamiApp.GetComponentInChildren<PronHorror>();
			pronView.OnDose();
			await UniTask.Delay(30);
			pronView.OnDose();
			await UniTask.Delay(30);
			pronView.OnDose();
			await UniTask.Delay(30);
			pronView.OnDose();
			SingletonMonoBehaviour<WindowManager>.Instance.Close(bins[bin]);
		}
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		GameObject.Find("MainPanel").GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);
		PostEffectManager.Instance.SetShader(EffectType.SatujinNoise);
		PostEffectManager.Instance.SetShaderWeight(0.05f);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_craziness");
		PostEffectManager.Instance.SetShader(EffectType.WristCut);
		IWindow w = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Darkness);
		SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(AppType.Darkness);
		WristcutView tekubi = w.nakamiApp.GetComponentInChildren<WristcutView>();
		tekubi._goButton.gameObject.SetActive(value: false);
		tekubi._finishButton.gameObject.SetActive(value: false);
		tekubi.OnGo(27);
		await UniTask.Delay(1000);
		tekubi.OnGo(27);
		await UniTask.Delay(1000);
		tekubi.OnGo(27);
		await UniTask.Delay(800);
		tekubi.OnGo(27);
		await UniTask.Delay(400);
		tekubi.OnGo(27);
		SingletonMonoBehaviour<WindowManager>.Instance.Close(w);
		SingletonMonoBehaviour<StatusManager>.Instance.timePassing(2);
		PostEffectManager.Instance.SetShader(EffectType.Invert);
		PostEffectManager.Instance.SetShaderWeight(1f);
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Action_HaishinStart>();
		endEvent();
	}

	public async UniTask AfterSine()
	{
	}
}
