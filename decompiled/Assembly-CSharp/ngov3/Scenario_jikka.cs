using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Scenario_jikka : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_jikka_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_jikka_LINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_jikka_LINE003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_jikka_LINE004);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Scenario_jikka_LINE004_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Scenario_jikka_LINE004_pi).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("positive");
			await NgoEvent.DelaySkippable(2500);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_jikka_LINE005);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusMaxToNumber(StatusType.Love, 120);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
