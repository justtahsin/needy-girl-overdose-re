using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Yandeiru : NgoEvent
{
	private IDisposable disposable;

	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru001);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Yandeiru001_Optuion001,
			JineType.Event_Yandeiru001_Optuion002,
			JineType.Event_Yandeiru001_Optuion003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yandeiru001_Optuion001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru002);
			eventContinue1();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yandeiru001_Optuion002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru003);
			eventContinue1();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yandeiru001_Optuion003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru004);
			eventContinue1();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue1()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru005);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Yandeiru005_Option001,
			JineType.Event_Yandeiru005_Option002,
			JineType.Event_Yandeiru005_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yandeiru005_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru006);
			eventContinue2();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yandeiru005_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru007);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			eventContinue2();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yandeiru005_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru008);
			eventContinue2();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue2()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru009);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Yandeiru009_Option001,
			JineType.Event_Yandeiru009_Option002,
			JineType.Event_Yandeiru009_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yandeiru009_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru010);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			eventContinue3();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yandeiru009_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru011);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			eventContinue3();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yandeiru009_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru012);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			eventContinue3();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue3()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru013);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
		SingletonMonoBehaviour<JineManager>.Instance.Message.Subscribe(async delegate(string n)
		{
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, n));
		}).AddTo(compositeDisposable);
		disposable = SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Subscribe(async delegate(CollectionAddEvent<JineData> m)
		{
			if (m.Value.freeMessage == "愛してる" || m.Value.freeMessage.Contains("i love you", StringComparison.OrdinalIgnoreCase) || m.Value.freeMessage == "我爱你" || m.Value.freeMessage == "사랑해")
			{
				disposable.Dispose();
				await NgoEvent.DelaySkippable(Constants.MIDDLE);
				SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
				await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru014);
			}
			else
			{
				disposable.Dispose();
				await NgoEvent.DelaySkippable(Constants.MIDDLE);
				SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
				await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru015);
			}
			endEvent();
		}).AddTo(compositeDisposable);
	}

	private async UniTask ConsumerEventContinue3()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru013);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Yandeiru013_Option001,
			JineType.Event_Yandeiru013_Option002,
			JineType.Event_Yandeiru013_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yandeiru013_Option001).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru014);
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yandeiru013_Option002 || x.Value.id == JineType.Event_Yandeiru013_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yandeiru015);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
