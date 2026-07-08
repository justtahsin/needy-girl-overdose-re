using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_MailInterview : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_F);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_JINE001);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_MailInterbiew_JINE001_Option001,
			JineType.Event_MailInterbiew_JINE001_Option002,
			JineType.Event_MailInterbiew_JINE001_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_MailInterbiew_JINE001_Option001).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_Kiji001);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue1();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_MailInterbiew_JINE001_Option002).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_Kiji002);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue1();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_MailInterbiew_JINE001_Option003).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_Kiji003);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue1();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue1()
	{
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_JINE002);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_MailInterbiew_JINE002_Option001,
			JineType.Event_MailInterbiew_JINE002_Option002,
			JineType.Event_MailInterbiew_JINE002_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_MailInterbiew_JINE002_Option001).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_Kiji004);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue2();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_MailInterbiew_JINE002_Option002).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_Kiji005);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue2();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_MailInterbiew_JINE002_Option003).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_Kiji006);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue2();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue2()
	{
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_JINE003);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_MailInterbiew_JINE003_Option001,
			JineType.Event_MailInterbiew_JINE003_Option002,
			JineType.Event_MailInterbiew_JINE003_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_MailInterbiew_JINE003_Option001).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_Kiji007);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue3();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_MailInterbiew_JINE003_Option002).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_Kiji008);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue3();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_MailInterbiew_JINE003_Option003).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_Kiji009);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue3();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue3()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_JINE004);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_MailInterbiew_JINE004_Option001,
			JineType.Event_MailInterbiew_JINE004_Option002,
			JineType.Event_MailInterbiew_JINE004_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_MailInterbiew_JINE004_Option001).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_Kiji010);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue4();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_MailInterbiew_JINE004_Option002).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_Kiji011);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue4();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_MailInterbiew_JINE004_Option003).Subscribe(async delegate
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_Kiji012);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			eventContinue4();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue4()
	{
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_MailInterbiew_JINE005);
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
		endEvent();
	}
}
