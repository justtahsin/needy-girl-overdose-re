using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class YamiHi_SukiHi_4 : NgoEvent
{
	private IDisposable disp;

	private bool henjied;

	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_YL);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi4_001);
		SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
		disp = SingletonMonoBehaviour<JineManager>.Instance.Message.Subscribe(async delegate(string m)
		{
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, m));
			henjied = true;
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi4_002);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi4_003);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi4_004);
			disp.Dispose();
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
			endEvent();
		}).AddTo(compositeDisposable);
		await UniTask.Delay(6000);
		if (!henjied)
		{
			SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
			disp.Dispose();
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi4_005);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi4_006);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 2);
			endEvent();
		}
	}

	private async UniTask ConsumerStartEvent()
	{
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_YL);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi4_001);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.YamiHi_SukiHi4_001_pi });
		disp = SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.YamiHi_SukiHi4_001_pi).Subscribe(async delegate
		{
			henjied = true;
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi4_002);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi4_003);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi4_004);
			disp.Dispose();
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
			endEvent();
		}).AddTo(compositeDisposable);
		await UniTask.Delay(1500);
		if (!henjied)
		{
			SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
			disp.Dispose();
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi4_005);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.YamiHi_SukiHi4_006);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 2);
			endEvent();
		}
	}
}
