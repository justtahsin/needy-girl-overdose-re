using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;

namespace ngov3;

public class Action_OkusuriPuronOverdoseY4 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		AudioManager.Instance.PlaySeByType(SoundType.SE_takepill_lv2);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim(SingletonMonoBehaviour<EventManager>.Instance.PlatformDiffAnimationMaster.GetAnimationNameFromKey(PlatformDiffAnimationKey.PURON));
		await NgoEvent.DelaySkippable(Constants.SLOW);
		float weight = 0f;
		PostEffectManager.Instance.SetShader(EffectType.OD2);
		await DOTween.To(() => weight, delegate(float x)
		{
			PostEffectManager.Instance.SetShaderWeight(x, EffectType.OD2);
		}, 0.4f, 1.2f).SetEase(Ease.InExpo).Play();
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Kusuri_sihan_od, CommandResult.success));
		PostEffectManager.Instance.ResetShaderCalmly(EffectType.OD2);
		SingletonMonoBehaviour<StatusManager>.Instance.isTodayGangimari = true;
		AchievementStatsUpdater.UpdateStats("Command_OD");
		endEvent();
	}
}
