using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_MenheraFriend : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_Menherafriend;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_F);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Menherafriend_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Menherafriend_JINE002);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Menherafriend_JINE002_Option001,
			JineType.Event_Menherafriend_JINE002_Option002,
			JineType.Event_Menherafriend_JINE002_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Menherafriend_JINE002_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Menherafriend_JINE003);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Menherafriend_JINE002_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Menherafriend_JINE004);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Menherafriend_JINE002_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Menherafriend_JINE005);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
