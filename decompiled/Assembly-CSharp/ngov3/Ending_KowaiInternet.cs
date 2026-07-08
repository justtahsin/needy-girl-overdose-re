using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_KowaiInternet : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_KowaiInternet;
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistoryFromString("インターネットこわい");
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		endEvent();
	}
}
