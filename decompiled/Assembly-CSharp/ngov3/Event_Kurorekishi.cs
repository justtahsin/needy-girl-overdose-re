using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Kurorekishi : NgoEvent
{
	private IDisposable _disposable;

	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi001);
		SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
		_disposable = SingletonMonoBehaviour<JineManager>.Instance.Message.Subscribe(async delegate(string m)
		{
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, m));
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi002);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi003);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi004);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi005);
			_disposable.Dispose();
			SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
			_disposable = SingletonMonoBehaviour<JineManager>.Instance.Message.Subscribe(async delegate(string n)
			{
				SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, n));
				_disposable.Dispose();
				await NgoEvent.DelaySkippable(Constants.FAST);
				await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi006);
				await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi007);
				await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi008);
				await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi009);
				SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
				{
					JineType.Event_Kurorekisi009_Option001,
					JineType.Event_Kurorekisi009_Option002,
					JineType.Event_Kurorekisi009_Option003
				});
				SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi009_Option001).Subscribe(async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi010);
					SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
					endEvent();
				}).AddTo(compositeDisposable);
				SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi009_Option002).Subscribe(async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi011);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi012);
					SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
					endEvent();
				}).AddTo(compositeDisposable);
				SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi009_Option003).Subscribe(async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi013);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi014);
					SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
					endEvent();
				}).AddTo(compositeDisposable);
			});
		});
	}

	private async UniTask ConsumerStartEvent()
	{
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi001);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Kurorekisi001_Option001,
			JineType.Event_Kurorekisi001_Option002,
			JineType.Event_Kurorekisi001_Option003
		});
		_disposable = SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi001_Option001 || x.Value.id == JineType.Event_Kurorekisi001_Option002 || x.Value.id == JineType.Event_Kurorekisi001_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi002);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi003);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi004);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi005);
			_disposable.Dispose();
			SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
			{
				JineType.Event_Kurorekisi005_Option001,
				JineType.Event_Kurorekisi005_Option002,
				JineType.Event_Kurorekisi005_Option003
			});
			_disposable = SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi005_Option001 || x.Value.id == JineType.Event_Kurorekisi005_Option002 || x.Value.id == JineType.Event_Kurorekisi005_Option003).Subscribe(async delegate
			{
				_disposable.Dispose();
				await NgoEvent.DelaySkippable(Constants.FAST);
				await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi006);
				await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi007);
				await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi008);
				await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi009);
				SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
				{
					JineType.Event_Kurorekisi009_Option001,
					JineType.Event_Kurorekisi009_Option002,
					JineType.Event_Kurorekisi009_Option003
				});
				SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi009_Option001).Subscribe(async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi010);
					SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
					endEvent();
				}).AddTo(compositeDisposable);
				SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi009_Option002).Subscribe(async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi011);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi012);
					SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
					endEvent();
				}).AddTo(compositeDisposable);
				SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Kurorekisi009_Option003).Subscribe(async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi013);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Kurorekisi014);
					SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -2);
					endEvent();
				}).AddTo(compositeDisposable);
			});
		}).AddTo(compositeDisposable);
	}
}
