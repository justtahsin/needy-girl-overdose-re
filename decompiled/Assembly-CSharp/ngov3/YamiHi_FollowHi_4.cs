using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class YamiHi_FollowHi_4 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_YF);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_FollowHi4_001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_FollowHi4_002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_FollowHi4_003);
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 2);
		endEvent();
	}
}
