using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Dialog : NgoEvent
{
	private int point;

	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_zarazaranoise_lv2, isLoop: true);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_idle_anxiety_e");
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE001);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE001_Option001,
			JineType.Event_Dialog_JINE001_Option002,
			JineType.Event_Dialog_JINE001_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE001_Option001).Subscribe(async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE001_Reply001);
			eventContinue1();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE001_Option002).Subscribe(async delegate
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE001_Reply002);
			eventContinue1();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE001_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE001_Reply003);
			eventContinue1();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue1()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE002);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE002_Option001,
			JineType.Event_Dialog_JINE002_Option002,
			JineType.Event_Dialog_JINE002_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE002_Option001).Subscribe(async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE002_Reply001);
			eventContinue2();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE002_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE002_Reply002);
			eventContinue2();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE002_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE002_Reply003);
			eventContinue2();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue2()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE003);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE003_Option001,
			JineType.Event_Dialog_JINE003_Option002,
			JineType.Event_Dialog_JINE003_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE003_Option001).Subscribe(async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE003_Reply001);
			eventContinue3();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE003_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE003_Reply002);
			eventContinue3();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE003_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE003_Reply003);
			eventContinue3();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue3()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE004);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE004_Option001,
			JineType.Event_Dialog_JINE004_Option002,
			JineType.Event_Dialog_JINE004_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE004_Option001).Subscribe(async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE004_Reply001);
			eventContinue4();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE004_Option002).Subscribe(async delegate
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE004_Reply002);
			eventContinue4();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE004_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE004_Reply003);
			eventContinue4();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue4()
	{
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE005);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE005_Option001,
			JineType.Event_Dialog_JINE005_Option002,
			JineType.Event_Dialog_JINE005_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE005_Option001).Subscribe(async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE005_Reply001);
			eventContinue5();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE005_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE005_Reply002);
			eventContinue5();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE005_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE005_Reply003);
			eventContinue5();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue5()
	{
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE006);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE006_Option001,
			JineType.Event_Dialog_JINE006_Option002,
			JineType.Event_Dialog_JINE006_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE006_Option001).Subscribe(async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE006_Reply001);
			eventContinue6();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE006_Option002).Subscribe(async delegate
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE006_Reply002);
			eventContinue6();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE006_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE006_Reply003);
			eventContinue6();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue6()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE007);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE007_Option001,
			JineType.Event_Dialog_JINE007_Option002,
			JineType.Event_Dialog_JINE007_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE007_Option001).Subscribe(async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE007_Reply001);
			eventContinue7();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE007_Option002).Subscribe(async delegate
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE007_Reply002);
			eventContinue7();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE007_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE007_Reply003);
			eventContinue7();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue7()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE008);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE008_Option001,
			JineType.Event_Dialog_JINE008_Option002,
			JineType.Event_Dialog_JINE008_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE008_Option001).Subscribe(async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE008_Reply001);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			await lastTweet();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE008_Option002).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE008_Reply002);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await lastTweet();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE008_Option003).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE008_Reply003);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			await lastTweet();
		}).AddTo(compositeDisposable);
	}

	private async UniTask lastTweet()
	{
		if (point > 6)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Dialog_Tweet_Good);
		}
		if (point <= 6 && point >= 3)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Dialog_Tweet_Normal);
		}
		if (point <= 2)
		{
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Dialog_Tweet_Bad);
		}
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		(from v in SingletonMonoBehaviour<PoketterManager>.Instance.ObserveEveryValueChanged((PoketterManager _poketter) => SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue.Count)
			where v == 0
			select v).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.SLOW);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
