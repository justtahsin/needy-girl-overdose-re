using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_LoveJINE : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_LoveJINE;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_L);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_LoveJINE_JINE001);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_LoveJINE_JINE001_Option001,
			JineType.Event_LoveJINE_JINE001_Option002,
			JineType.Event_LoveJINE_JINE001_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_LoveJINE_JINE001_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_LoveJINE_JINE002);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			(from v in SingletonMonoBehaviour<NotificationManager>.Instance.ObserveEveryValueChanged((NotificationManager notificationManager) => SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount)
				where v == 0
				select v).Subscribe(async delegate
			{
				await NgoEvent.DelaySkippable(Constants.MIDDLE);
				await SingletonMonoBehaviour<EventManager>.Instance.ExecuteActionConfirmed(ActionType.PlayMakeLove, CmdType.PlayMakeLove, isEventCommand: true);
				await UniTask.Delay(4500);
				endEvent();
			}).AddTo(compositeDisposable);
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_LoveJINE_JINE001_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_LoveJINE_JINE003);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 2);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: true);
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_LoveJINE_JINE001_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_LoveJINE_JINE004);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: true);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
