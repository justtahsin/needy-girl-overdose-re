using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace ngov3;

public class Action_HaishinEnd : NgoEvent
{
	private IDisposable CancelToken = new SingleAssignmentDisposable();

	private IDisposable token1 = new SingleAssignmentDisposable();

	private IDisposable token2 = new SingleAssignmentDisposable();

	private IDisposable token3 = new SingleAssignmentDisposable();

	private ReactiveProperty<bool> isCleaned = new ReactiveProperty<bool>(initialValue: true);

	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Broadcast);
		CmdType cmdType = SingletonMonoBehaviour<CommandManager>.Instance.ChooseCommand(ActionType.Haishin);
		SingletonMonoBehaviour<EventManager>.Instance.executingAction = cmdType;
		SingletonMonoBehaviour<EventManager>.Instance.ApplyStatus(cmdType);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		tweetFromTip(SingletonMonoBehaviour<EventManager>.Instance.alpha, SingletonMonoBehaviour<EventManager>.Instance.alphaLevel);
		SingletonMonoBehaviour<EventManager>.Instance.setActionHistory($"{SingletonMonoBehaviour<EventManager>.Instance.alpha}_{SingletonMonoBehaviour<EventManager>.Instance.alphaLevel}");
		new CancellationTokenSource();
		if (SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count > 0)
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Result);
		}
		SingletonMonoBehaviour<EventManager>.Instance.Aim.Value = "はいしん";
		SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.TaskManager));
		await SingletonMonoBehaviour<StatusManager>.Instance.DeltaToStatus();
		if (SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount > 0)
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Jine);
			await NgoEvent.DelaySkippable(SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount * Constants.MIDDLE);
		}
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, Vector2.zero, CursorMode.Auto);
		SingletonMonoBehaviour<EventManager>.Instance.TimePass();
		SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = false;
		endEvent();
	}

	private bool checkCleaned()
	{
		if (SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount == 0 && SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count == 0)
		{
			return SingletonMonoBehaviour<EventManager>.Instance.eventQueue.Count == 0;
		}
		return false;
	}
}
