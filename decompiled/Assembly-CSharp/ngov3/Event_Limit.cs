using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Limit : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_Limit;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_S);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Limit_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Limit_JINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Limit_JINE003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Limit_JINE004);
		(from v in SingletonMonoBehaviour<NotificationManager>.Instance.ObserveEveryValueChanged((NotificationManager _) => SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount)
			where v == 0
			select v).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			await SingletonMonoBehaviour<EventManager>.Instance.ExecuteActionConfirmed(ActionType.SleepToTomorrow, CmdType.SleepToTomorrow3, isEventCommand: true);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
