using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;

namespace ngov3;

public class Action_WaitTimePassing1ToEndResult : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.isResulting.Where((bool v) => !v).Take(1).Subscribe(delegate
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<TimePassing1>();
			endEvent();
		})
			.AddTo(compositeDisposable);
	}
}
