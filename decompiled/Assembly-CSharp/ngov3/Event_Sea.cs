using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Sea : NgoEvent
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
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Sea_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Sea_JINE002);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Sea_JINE002_Option001,
			JineType.Event_Sea_JINE002_Option002
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Sea_JINE002_Option001).Subscribe(async delegate
		{
			await GoOut();
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Sea_JINE003);
			await NgoEvent.DelaySkippable(2400);
			SingletonMonoBehaviour<StatusManager>.Instance.TimeDelta(2);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -15);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Love, 6);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Sea_Tweet001);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			SingletonMonoBehaviour<NotificationManager>.Instance.AddTimePassingNotifier(2);
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Sea_JINE002_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Sea_JINE004);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: true);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
