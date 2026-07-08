using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Fetish : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		await base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Fetish_JINE001);
		SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
		SingletonMonoBehaviour<JineManager>.Instance.Message.Subscribe(async delegate(string m)
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, m));
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Fetish_JINE002);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
