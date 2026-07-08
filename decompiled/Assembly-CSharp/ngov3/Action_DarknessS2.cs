using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using UnityEngine;

namespace ngov3;

public class Action_DarknessS2 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		PostEffectManager.Instance.SetShader(EffectType.GoCrazy);
		await NgoEvent.DelaySkippable(8400);
		GameObject.Find("MainPanel").transform.DORotate(new Vector3(0f, 0f, 2.6f), 0.2f);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.SelfHarm_crazy, CommandResult.success));
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		PostEffectManager.Instance.ResetShaderCalmly();
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<ChipGet_Darkness_2>();
		endEvent();
	}
}
