using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Scenario_loop1_day1_day : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE005);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE006);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE007);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE008);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Day1_JINE008_Option001 });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Day1_JINE008_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day1_JINE009);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = false;
			SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: true);
			SingletonMonoBehaviour<WebCamManager>.Instance.RandomizeAmeAnimation();
			SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tooltip_firstStamp);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.responseType == ResponseType.Stamp && x.Value.user == JineUserType.pi).Subscribe(delegate
			{
				SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
				SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tooltip_day2);
				endEvent();
			}).AddTo(compositeDisposable);
		}).AddTo(compositeDisposable);
	}
}
