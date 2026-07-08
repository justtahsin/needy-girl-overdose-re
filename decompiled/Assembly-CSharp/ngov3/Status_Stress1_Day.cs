using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Status_Stress1_Day : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_craziness");
		GameObject.Find("MainPanel").GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_craziness");
		PostEffectManager.Instance.SetShader(EffectType.WristCut);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Wristcat_JINE004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Wristcat_JINE005);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Wristcat_JINE006);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Wristcat_JINE007);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Darkness);
		SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(AppType.Darkness);
		endEvent();
	}
}
