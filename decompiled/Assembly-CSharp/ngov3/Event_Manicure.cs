using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Manicure : NgoEvent
{
	protected override void Awake()
	{
		type = EventType.Event_Manicure;
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Status_L);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Manicure_JINE001);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Manicure_JINE001_Option1,
			JineType.Event_Manicure_JINE001_Option2,
			JineType.Event_Manicure_JINE001_Option3,
			JineType.Event_Manicure_JINE001_Option4
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Manicure_JINE001_Option1).Subscribe(async delegate
		{
			SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_nail");
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Manicure_skyblue);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			SingletonMonoBehaviour<WebCamManager>.Instance.RandomizeAmeAnimation();
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Manicure_JINE001_Option2).Subscribe(async delegate
		{
			SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_nail");
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Manicure_purple);
			SingletonMonoBehaviour<WebCamManager>.Instance.RandomizeAmeAnimation();
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Manicure_JINE001_Option3).Subscribe(async delegate
		{
			SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_nail");
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Manicure_rainbow);
			SingletonMonoBehaviour<WebCamManager>.Instance.RandomizeAmeAnimation();
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Manicure_JINE001_Option4).Subscribe(async delegate
		{
			SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_nail");
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<WebCamManager>.Instance.WatchSp();
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Manicure_black);
			SingletonMonoBehaviour<WebCamManager>.Instance.RandomizeAmeAnimation();
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
