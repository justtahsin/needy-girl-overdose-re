using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_DateHolic : NgoEvent
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
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_DateHolic001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_DateHolic002);
		(from v in SingletonMonoBehaviour<NotificationManager>.Instance.ObserveEveryValueChanged((NotificationManager _) => SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount)
			where v == 0
			select v).First().Subscribe(delegate
		{
			IWindow w = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.GoOut);
			SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(w);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
