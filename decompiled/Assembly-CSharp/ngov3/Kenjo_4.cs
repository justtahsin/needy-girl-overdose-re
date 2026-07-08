using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Kenjo_4 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_Kenjo);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.KenjoHi4_001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.KenjoHi4_002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.KenjoHi4_003);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Yami, -2);
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		endEvent();
	}
}
