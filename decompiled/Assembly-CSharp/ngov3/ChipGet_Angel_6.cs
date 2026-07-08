using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class ChipGet_Angel_6 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_DarkAngel001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_DarkAngel002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_DarkAngel003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_DarkAngel004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_DarkAngel005);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_DarkAngel006);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_DarkAngel007);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_DarkAngel008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_DarkAngel009);
		endEvent();
	}
}
