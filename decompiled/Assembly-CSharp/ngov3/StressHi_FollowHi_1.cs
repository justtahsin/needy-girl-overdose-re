using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class StressHi_FollowHi_1 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_SF);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.StHi_FollowHi1_001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.StHi_FollowHi1_002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.StHi_FollowHi1_003);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
		SingletonMonoBehaviour<JineManager>.Instance.Message.Subscribe(async delegate(string m)
		{
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, m));
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.StHi_FollowHi1_004);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}

	private async UniTask ConsumerStartEvent()
	{
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_SF);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.StHi_FollowHi1_001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.StHi_FollowHi1_002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.StHi_FollowHi1_003);
		await NgoEvent.DelaySkippable(Constants.FAST);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.StHi_FollowHi1_003_Option001,
			JineType.StHi_FollowHi1_003_Option002,
			JineType.StHi_FollowHi1_003_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.StHi_FollowHi1_003_Option001 || x.Value.id == JineType.StHi_FollowHi1_003_Option002 || x.Value.id == JineType.StHi_FollowHi1_003_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.StHi_FollowHi1_004);
			await NgoEvent.DelaySkippable(Constants.FAST);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
