using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_OpenGinga : NgoEvent
{
	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.After_netlore001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.After_netlore002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.After_netlore003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.After_netlore004);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
		SingletonMonoBehaviour<EventManager>.Instance.isOpenGinga = true;
		endEvent();
	}
}
