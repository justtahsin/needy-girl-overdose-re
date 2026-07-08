using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_Ntr : NgoEvent
{
	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Ntr;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Action_HaishinStart>();
		endEvent();
	}
}
