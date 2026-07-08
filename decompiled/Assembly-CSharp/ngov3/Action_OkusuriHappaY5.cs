using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;

namespace ngov3;

public class Action_OkusuriHappaY5 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		AudioManager.Instance.PlaySeByType(SoundType.SE_takepill_lv4);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim(SingletonMonoBehaviour<EventManager>.Instance.PlatformDiffAnimationMaster.GetAnimationNameFromKey(PlatformDiffAnimationKey.HAPPA));
		await NgoEvent.DelaySkippable(Constants.SLOW);
		float weight = 0f;
		PostEffectManager.Instance.SetShader(EffectType.Weed);
		await DOTween.To(() => weight, delegate(float x)
		{
			PostEffectManager.Instance.SetShaderWeight(x, EffectType.Weed);
		}, 0.8f, 1.2f).SetEase(Ease.InExpo).Play();
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Kusuri_happa, CommandResult.success));
		PostEffectManager.Instance.ResetShaderCalmly(EffectType.Weed);
		SingletonMonoBehaviour<StatusManager>.Instance.isTodayGangimari = true;
		AchievementStatsUpdater.UpdateStats("Command_Weed");
		endEvent();
	}
}
