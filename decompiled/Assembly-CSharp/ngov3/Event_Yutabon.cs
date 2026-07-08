using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Yutabon : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yutabon001);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Yutabon001_Option001,
			JineType.Event_Yutabon001_Option002,
			JineType.Event_Yutabon001_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yutabon001_Option001).Subscribe(async delegate
		{
			eventContinue1();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yutabon001_Option002).Subscribe(async delegate
		{
			eventContinue1();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yutabon001_Option003).Subscribe(async delegate
		{
			eventContinue1();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue1()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yutabon002);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Yutabon002_Option001,
			JineType.Event_Yutabon002_Option002,
			JineType.Event_Yutabon002_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yutabon002_Option001).Subscribe(async delegate
		{
			eventContinue2();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yutabon002_Option002).Subscribe(async delegate
		{
			eventContinue2();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yutabon002_Option003).Subscribe(async delegate
		{
			eventContinue2();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue2()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yutabon003);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Yutabon003_Option001,
			JineType.Event_Yutabon003_Option002,
			JineType.Event_Yutabon003_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yutabon003_Option001).Subscribe(async delegate
		{
			eventContinue3();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yutabon003_Option002).Subscribe(async delegate
		{
			eventContinue3();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Yutabon003_Option003).Subscribe(async delegate
		{
			eventContinue3();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue3()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Yutabon004);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Yutabon004_Option001,
			JineType.Event_Yutabon004_Option001,
			JineType.Event_Yutabon004_Option001
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Subscribe(async delegate
		{
			await UniTask.Delay(1500);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
