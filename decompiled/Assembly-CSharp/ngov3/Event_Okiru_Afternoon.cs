using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Okiru_Afternoon : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<StatusManager>.Instance.timePassing();
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -5);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Yami, -2);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okiru_Afternoon001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okiru_Afternoon002);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Okiru_Afternoon002_Option001,
			JineType.Event_Okiru_Afternoon002_Option002
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Okiru_Afternoon002_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okiru_Afternoon003);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okiru_Afternoon004);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okiru_Afternoon005);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Okiru_Afternoon002_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okiru_Afternoon006);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okiru_Afternoon007);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
