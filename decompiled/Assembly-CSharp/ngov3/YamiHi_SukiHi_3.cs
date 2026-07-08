using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class YamiHi_SukiHi_3 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_YL);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi3_001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi3_002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi3_003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi3_004);
		endEvent();
	}
}
