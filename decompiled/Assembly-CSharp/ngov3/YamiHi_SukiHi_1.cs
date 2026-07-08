using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class YamiHi_SukiHi_1 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_YL);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi1_001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi1_002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi1_003);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 2);
		endEvent();
	}
}
