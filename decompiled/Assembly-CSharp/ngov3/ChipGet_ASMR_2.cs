using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class ChipGet_ASMR_2 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.NetaGet_ASMR2_1);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.NetaGet_ASMR2_2);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.NetaGet_ASMR2_3);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.NetaGet_ASMR2_4);
		endEvent();
	}
}
