using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Wishlist_day2_4 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Wishlist_JINE007);
		(from v in SingletonMonoBehaviour<NotificationManager>.Instance.ObserveEveryValueChanged((NotificationManager _) => SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount)
			where v == 0
			select v).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			await SingletonMonoBehaviour<EventManager>.Instance.ExecuteActionConfirmed(ActionType.PlayMakeLove, CmdType.PlayMakeLove, isEventCommand: true);
			await UniTask.Delay(4500);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
