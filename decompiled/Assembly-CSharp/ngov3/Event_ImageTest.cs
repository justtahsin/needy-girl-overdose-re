using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Event_ImageTest : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.AfterTweet_Angel1, new List<KusoRepType> { KusoRepType.FanRep003 });
		endEvent();
	}
}
