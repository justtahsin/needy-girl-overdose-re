using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Sumabura : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Sumabura001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Sumabura002);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Sumabura002_Option001,
			JineType.Event_Sumabura002_Option002
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Sumabura002_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Sumabura003);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Sumabura002_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Sumabura004);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
