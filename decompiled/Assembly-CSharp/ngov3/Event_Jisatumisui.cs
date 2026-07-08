using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Jisatumisui : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Jisatumisui001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Jisatumisui002);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Jisatumisui002_Option001,
			JineType.Event_Jisatumisui002_Option002,
			JineType.Event_Jisatumisui002_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Jisatumisui002_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Jisatumisui003);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Jisatumisui002_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Jisatumisui004);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Jisatumisui005);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Jisatumisui002_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Jisatumisui006);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Jisatumisui007);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Jisatumisui008);
			SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Jisatu;
			AchievementStatsUpdater.UpdateStats("Ending_Jisatuhoujo");
			SingletonMonoBehaviour<EventManager>.Instance.CallEnding();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
