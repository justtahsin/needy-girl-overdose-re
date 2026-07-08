using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class ChipGet_Otakutalk_1 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.NetaGet_OtakuTalk1_1);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.NetaGet_OtakuTalk1_2);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.NetaGet_OtakuTalk1_3);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.NetaGet_OtakuTalk1_4);
		endEvent();
	}
}
