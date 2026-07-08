using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class ChipGet_Imbouron_5 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.NetaGet_Imbouron5_1);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.NetaGet_Imbouron5_2);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.NetaGet_Imbouron5_3);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.NetaGet_Imbouron5_4);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.NetaGet_Imbouron5_5);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		endEvent();
	}
}
