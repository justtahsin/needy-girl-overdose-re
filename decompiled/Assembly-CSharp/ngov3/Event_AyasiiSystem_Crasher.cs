using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Event_AyasiiSystem_Crasher : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		for (int i = 0; i < 30; i++)
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.CrashNakami).setRandomPosition();
			await UniTask.Delay(4);
		}
		endEvent();
	}
}
