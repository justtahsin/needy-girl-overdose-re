using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_Mibare : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_kenjo);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Mibare_Tweet001);
		await NgoEvent.DelaySkippable(1800);
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		endEvent();
	}
}
