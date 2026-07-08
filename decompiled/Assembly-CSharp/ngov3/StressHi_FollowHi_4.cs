using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class StressHi_FollowHi_4 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_SF);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.StHi_FollowHi4_001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.StHi_FollowHi4_002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.StHi_FollowHi4_003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.StHi_FollowHi4_004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.StHi_FollowHi4_005);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 2);
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		endEvent();
	}
}
