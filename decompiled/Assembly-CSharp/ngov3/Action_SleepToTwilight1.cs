using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Action_SleepToTwilight1 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken, skipWatchSp: true);
		SingletonMonoBehaviour<WebCamManager>.Instance.GoOut();
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		PostEffectManager.Instance.AnmakuWeight(1f);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		PostEffectManager.Instance.ResetShader();
		endEvent();
	}
}
