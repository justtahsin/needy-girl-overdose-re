using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Ura_internatAngel : NgoEvent
{
	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		SingletonMonoBehaviour<EventManager>.Instance.alpha = AlphaType.Angel;
		SingletonMonoBehaviour<EventManager>.Instance.alphaLevel = 6;
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Action_HaishinStart>();
		endEvent();
	}
}
