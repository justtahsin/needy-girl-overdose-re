using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class TimePassing1 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.executingAction = CmdType.None;
		SingletonMonoBehaviour<WindowManager>.Instance.CleanOnCommand();
		SingletonMonoBehaviour<WebCamManager>.Instance.RandomizeAmeAnimation();
		SingletonMonoBehaviour<CommandManager>.Instance.restoreCommands();
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: true);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: true);
		await SingletonMonoBehaviour<StatusManager>.Instance.timePassing();
		endEvent();
	}
}
