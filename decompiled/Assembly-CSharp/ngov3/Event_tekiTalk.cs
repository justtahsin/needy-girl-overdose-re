using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Event_tekiTalk : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistoryFromString("もう喋ることない //種切れしました");
		endEvent();
	}
}
