using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_MV_shuroku : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<CommandManager>.Instance.disableAllCommands();
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0.2f);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Song_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Song_LINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Song_LINE003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Song_LINE004);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Event_Song_LINE004_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Song_LINE004_pi).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Song_LINE005);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Song_LINE006);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Song_LINE007);
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
			await GoOut();
			SingletonMonoBehaviour<EventManager>.Instance.ClearEventQueue();
			SingletonMonoBehaviour<StatusManager>.Instance.TimeDelta(2);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Song_Tweet001_omote);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Song_Tweet001_ura);
			SingletonMonoBehaviour<NotificationManager>.Instance.AddTimePassingNotifier(2);
			await NgoEvent.DelaySkippable(Constants.FAST);
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
