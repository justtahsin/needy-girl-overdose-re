using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using UnityEngine;
using UnityEngine.Video;

namespace ngov3;

public class Action_OkusuriPsyche : NgoEvent
{
	private VideoPlayer eizo;

	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		eizo = Camera.main.GetComponent<VideoPlayer>();
		eizo.enabled = true;
		eizo.clip = Resources.Load<VideoClip>($"Videos/Psyche{Random.Range(1, 33)}");
		eizo.Prepare();
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim(SingletonMonoBehaviour<EventManager>.Instance.PlatformDiffAnimationMaster.GetAnimationNameFromKey(PlatformDiffAnimationKey.PSYCHE));
		await NgoEvent.DelaySkippable(Constants.SLOW);
		float weight = 0f;
		PostEffectManager.Instance.SetShader(EffectType.Psyche);
		await DOTween.To(() => weight, delegate(float x)
		{
			PostEffectManager.Instance.SetShaderWeight(x, EffectType.Psyche);
		}, 1f, 1.2f).SetEase(Ease.InExpo).Play();
		eizo.targetCameraAlpha = 1f;
		eizo.Play();
		await NgoEvent.DelaySkippable(3000);
		PostEffectManager.Instance.ResetShaderCalmly(EffectType.Psyche);
		await NgoEvent.DelaySkippable(17000);
		eizo.targetCameraAlpha = 0f;
		eizo.enabled = false;
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Kusuri_psyche, CommandResult.success));
		SingletonMonoBehaviour<EventManager>.Instance.psycheCount++;
		SingletonMonoBehaviour<StatusManager>.Instance.isTodayGangimari = true;
		AchievementStatsUpdater.UpdateStats("Command_Psyche");
		endEvent();
	}
}
