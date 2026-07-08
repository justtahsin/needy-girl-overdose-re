using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using UnityEngine;

namespace ngov3;

public class Status_Stress2_Day : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_craziness");
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		PostEffectManager.Instance.SetShader(EffectType.GoCrazy);
		float weight = 0f;
		await DOTween.To(() => weight, delegate(float x)
		{
			PostEffectManager.Instance.SetShaderWeight(x);
		}, 1f, 1.2f).SetEase(Ease.InExpo).Play();
		await NgoEvent.DelaySkippable(4400);
		PostEffectManager.Instance.ResetShaderCalmly();
		CmdMaster.Param cmd = NgoEx.CmdFromType(CmdType.DarknessS2);
		SingletonMonoBehaviour<StatusManager>.Instance.AddDiffToDelta(cmd);
		await SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
		foreach (Transform item in SingletonMonoBehaviour<EventManager>.Instance.hakkyoRotationObjectTr)
		{
			item.DORotate(new Vector3(0f, 0f, 2.6f), 0.2f).SetEase(Ease.OutBounce).Play();
		}
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.SelfHarm_crazy, CommandResult.success));
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<ChipGet_Darkness_2>();
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<TimePassing2>();
		endEvent();
	}
}
