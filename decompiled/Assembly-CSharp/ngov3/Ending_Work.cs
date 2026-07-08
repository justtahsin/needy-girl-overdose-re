using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;
using ngov3.Effect;

namespace ngov3;

public class Ending_Work : NgoEvent
{
	private CanvasGroup shortcuts;

	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Work;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Work000);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Futaride_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Futaride_JINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Futaride_JINE003);
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		await NgoEvent.DelaySkippable(5000);
		await NgoEvent.DelaySkippable(5000);
		SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
		GameObject.Find("DayPassingCover").GetComponent<IDayPassing>().yearsPass();
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0.2f);
		GameObject.Find("Live").gameObject.SetActive(value: false);
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Jine);
		window._close.interactable = false;
		window._minimize.interactable = false;
		window._maximize.interactable = false;
		SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
		window.UnityGameObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
		await UniTask.Delay(8000);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Futaride_JINE004);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Ending_Futaride_JINE004_Option001,
			JineType.Ending_Futaride_JINE004_Option002,
			JineType.Ending_Futaride_JINE004_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Futaride_JINE004_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(1400);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Futaride_JINE005);
			eventContinue1();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Futaride_JINE004_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(1400);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Futaride_JINE005);
			eventContinue1();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Futaride_JINE004_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(1400);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Futaride_JINE005);
			eventContinue1();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue1()
	{
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Ending_Futaride_JINE005_Option001,
			JineType.Ending_Futaride_JINE005_Option002,
			JineType.Ending_Futaride_JINE005_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Futaride_JINE005_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(2800);
			eventContinue2();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Futaride_JINE005_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(2800);
			eventContinue2();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Futaride_JINE005_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(2800);
			eventContinue2();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue2()
	{
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Ending_Futaride_JINE005_Option004,
			JineType.Ending_Futaride_JINE005_Option005,
			JineType.Ending_Futaride_JINE005_Option006
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Futaride_JINE005_Option004).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(4800);
			eventContinue3();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Futaride_JINE005_Option005).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(4800);
			eventContinue3();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Futaride_JINE005_Option006).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(4800);
			eventContinue3();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue3()
	{
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Ending_Futaride_JINE005_Option007,
			JineType.Ending_Futaride_JINE005_Option008,
			JineType.Ending_Futaride_JINE005_Option009
		});
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Futaride_JINE005_Option007).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(6000);
			SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Ending_Work_Last);
			AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_kenjo);
			await NgoEvent.DelaySkippable(6000);
			AchievementStatsUpdater.UpdateStats("Ending_Work");
			SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Futaride_JINE005_Option008).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(6000);
			SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Ending_Work_Last);
			AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_kenjo);
			await NgoEvent.DelaySkippable(6000);
			AchievementStatsUpdater.UpdateStats("Ending_Work");
			SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_Futaride_JINE005_Option009).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(6000);
			SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Ending_Work_Last);
			AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_kenjo, isLoop: true);
			AchievementStatsUpdater.UpdateStats("Ending_Work");
			await NgoEvent.DelaySkippable(6000);
			SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		}).AddTo(compositeDisposable);
	}
}
