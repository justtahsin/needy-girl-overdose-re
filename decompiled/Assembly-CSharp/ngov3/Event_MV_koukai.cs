using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_MV_koukai : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Song_LINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Song_LINE009);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Song_LINE010);
		await NgoEvent.DelaySkippable(Constants.FAST);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Event_PV_toukou);
		endEvent();
	}
}
