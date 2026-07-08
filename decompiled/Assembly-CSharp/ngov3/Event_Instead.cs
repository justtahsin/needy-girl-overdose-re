using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Instead : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_Instead;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Instead_JINE001);
		await NgoEvent.DelaySkippable(1600);
		SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
		SingletonMonoBehaviour<JineManager>.Instance.Message.Subscribe(async delegate(string m)
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, m));
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(new TweetData(m));
			await NgoEvent.DelaySkippable(1600);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Instead_JINE002);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}

	private async UniTask ConsumerStartEvent()
	{
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Instead_JINE001);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Instead_JINE001_Option001,
			JineType.Event_Instead_JINE001_Option002,
			JineType.Event_Instead_JINE001_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Instead_JINE001_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Event_Instead_001);
			await NgoEvent.DelaySkippable(1600);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Instead_JINE002);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Instead_JINE001_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Event_Instead_002);
			await NgoEvent.DelaySkippable(1600);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Instead_JINE002);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Instead_JINE001_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Instead_003);
			await NgoEvent.DelaySkippable(1600);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Instead_JINE002);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
