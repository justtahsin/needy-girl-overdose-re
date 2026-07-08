using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Scenario_topstreamer_trakenjoikeike : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_happy, isLoop: true);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_trakenjoikeike_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_trakenjoikeike_LINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_trakenjoikeike_LINE003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_trakenjoikeike_LINE004);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Scenario_topstreamer_trakenjoikeike_LINE004_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Scenario_topstreamer_trakenjoikeike_LINE004_pi).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Scenario_topstreamer_trakenjoikeike_LINE005);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
