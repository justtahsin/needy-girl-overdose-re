using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Scenario_horror_day2_Afterhaisin : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_vomiting1");
		await NgoEvent.DelaySkippable(Constants.FAST);
		SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.EgosaResult);
		await UniTask.Delay(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW * 2);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Keijiban);
		await UniTask.Delay(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW * 2);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<WindowManager>.Instance.CleanOnCommand();
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_vomiting2");
		await NgoEvent.DelaySkippable(Constants.FAST);
		PostEffectManager.Instance.SetShader(EffectType.Noisy);
		PostEffectManager.Instance.SetShaderWeight(1f);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<StatusManager>.Instance.timePassingToNextMorning();
		PostEffectManager.Instance.ResetShader();
		endEvent();
	}
}
