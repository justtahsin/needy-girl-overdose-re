using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class SetJineSeparator : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Neta);
		endEvent();
	}
}
