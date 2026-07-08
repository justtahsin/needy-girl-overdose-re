using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Pinojien : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_Pinojien;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Pinojien_JINE001);
		SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
		SingletonMonoBehaviour<JineManager>.Instance.Message.Subscribe(async delegate(string m)
		{
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, m));
			await NgoEvent.DelaySkippable(1600);
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.ame, JineType.Event_Pinojien_Tweet001, ResponseType.IdMessage, StampType.None, m));
			SingletonMonoBehaviour<EventManager>.Instance.KituneJien = m;
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}

	private async UniTask ConsumerStartEvent()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Pinojien_JINE001);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Pinojien_JINE001_Option001,
			JineType.Event_Pinojien_JINE001_Option002,
			JineType.Event_Pinojien_JINE001_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Pinojien_JINE001_Option001 || x.Value.id == JineType.Event_Pinojien_JINE001_Option002 || x.Value.id == JineType.Event_Pinojien_JINE001_Option003).Subscribe(async delegate(CollectionAddEvent<JineData> m)
		{
			string message = JineDataConverter.GetJineTextFromTypeId(m.Value.id);
			await NgoEvent.DelaySkippable(1600);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.ame, JineType.Event_Pinojien_Tweet001, ResponseType.IdMessage, StampType.None, message));
			SingletonMonoBehaviour<EventManager>.Instance.KituneJien = message;
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
