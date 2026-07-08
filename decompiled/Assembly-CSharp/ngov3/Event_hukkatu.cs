using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Event_hukkatu : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_hukkatu_001);
		await NgoEvent.DelaySkippable(4400);
		endEvent();
	}
}
