using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Okiru_Night : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<StatusManager>.Instance.timePassing(2);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -8);
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Yami, -3);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okiru_Night001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okiru_Night002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okiru_Night003);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Event_Okiru_Night003_Option001 });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Okiru_Night003_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okiru_Night004);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okiru_Night005);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Okiru_Night006);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
