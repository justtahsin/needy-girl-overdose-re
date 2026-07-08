using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Action_HaishinClean : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Broadcast);
		SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = false;
		endEvent();
	}
}
