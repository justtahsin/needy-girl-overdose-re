using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Okusan : NgoEvent
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
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan002);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Okusan002_Option1,
			JineType.Event_Okusan002_Option2,
			JineType.Event_Okusan002_Option3
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Okusan002_Option1).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan004);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan005);
			(from v in SingletonMonoBehaviour<NotificationManager>.Instance.ObserveEveryValueChanged((NotificationManager notificationManager) => SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount)
				where v == 0
				select v).Subscribe(async delegate
			{
				await NgoEvent.DelaySkippable(Constants.MIDDLE);
				SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
				IWindow w = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.GoOut);
				SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(w);
				endEvent();
			}).AddTo(compositeDisposable);
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Okusan002_Option2).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan007);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan008);
			(from v in SingletonMonoBehaviour<NotificationManager>.Instance.ObserveEveryValueChanged((NotificationManager notificationManager) => SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount)
				where v == 0
				select v).Subscribe(async delegate
			{
				await NgoEvent.DelaySkippable(Constants.MIDDLE);
				await SingletonMonoBehaviour<EventManager>.Instance.ExecuteActionConfirmed(ActionType.PlayIchatuku, CmdType.PlayIchatukuIchatuku, isEventCommand: true);
				endEvent();
			}).AddTo(compositeDisposable);
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Okusan002_Option3).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan010);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okusan011);
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
	}
}
