using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Event_AyasiiSystem_GotMail : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.CrashMail);
		endEvent();
	}
}
