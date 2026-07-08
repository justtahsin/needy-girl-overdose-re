using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Copyceleb : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_Copyceleb;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_F);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Copyceleb_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Copyceleb_JINE002);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Copyceleb_JINE002_Option001,
			JineType.Event_Copyceleb_JINE002_Option002,
			JineType.Event_Copyceleb_JINE002_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Copyceleb_JINE002_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Copyceleb_JINE003);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Copyceleb_JINE004);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Copyceleb_JINE002_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Copyceleb_JINE005);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Copyceleb_JINE006);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Copyceleb_JINE002_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Copyceleb_JINE007);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Copyceleb_JINE008);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
