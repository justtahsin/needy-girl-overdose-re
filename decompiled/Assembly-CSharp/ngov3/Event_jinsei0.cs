using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_jinsei0 : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_jinsei0;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Tweet287);
		await NgoEvent.DelaySkippable(4400);
		endEvent();
	}
}
