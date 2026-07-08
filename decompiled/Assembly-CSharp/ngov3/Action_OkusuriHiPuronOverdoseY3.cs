using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;

namespace ngov3;

public class Action_OkusuriHiPuronOverdoseY3 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Stress) > 80)
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Badtrip_Sihan_JINE001);
		}
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		AudioManager.Instance.PlaySeByType(SoundType.SE_takepill_lv3);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim(SingletonMonoBehaviour<EventManager>.Instance.PlatformDiffAnimationMaster.GetAnimationNameFromKey(PlatformDiffAnimationKey.HIPURON));
		await NgoEvent.DelaySkippable(Constants.SLOW);
		float weight = 0f;
		PostEffectManager.Instance.SetShader(EffectType.OD3);
		await DOTween.To(() => weight, delegate(float x)
		{
			PostEffectManager.Instance.SetShaderWeight(x, EffectType.OD3);
		}, 1f, 1.2f).SetEase(Ease.InExpo).Play();
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetFetcher.CommandTweet(CommandType.Kusuri_shohou_od, CommandResult.success));
		PostEffectManager.Instance.ResetShaderCalmly(EffectType.OD3);
		SingletonMonoBehaviour<StatusManager>.Instance.isTodayGangimari = true;
		AchievementStatsUpdater.UpdateStats("Command_OD");
		endEvent();
	}
}
