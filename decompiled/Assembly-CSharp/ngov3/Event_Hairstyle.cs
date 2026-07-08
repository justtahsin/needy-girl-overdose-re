using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Hairstyle : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Hairstyle_JINE001);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Hairstyle_JINE001_Option001,
			JineType.Event_Hairstyle_JINE001_Option002,
			JineType.Event_Hairstyle_JINE001_Option003,
			JineType.Event_Hairstyle_JINE001_Option004
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Hairstyle_JINE001_Option001).Subscribe(async delegate
		{
			SingletonMonoBehaviour<WebCamManager>.Instance.GoOut();
			PostEffectManager.Instance.AnmakuWeight(1f);
			await NgoEvent.DelaySkippable(3400);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Hairstyle_JINE002);
			SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_hair_side");
			PostEffectManager.Instance.ResetShader();
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Hairstyle_JINE001_Option002).Subscribe(async delegate
		{
			SingletonMonoBehaviour<WebCamManager>.Instance.GoOut();
			PostEffectManager.Instance.AnmakuWeight(1f);
			await NgoEvent.DelaySkippable(3400);
			SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_hair_poney");
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			PostEffectManager.Instance.ResetShader();
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Hairstyle_JINE002);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Hairstyle_JINE001_Option003).Subscribe(async delegate
		{
			SingletonMonoBehaviour<WebCamManager>.Instance.GoOut();
			PostEffectManager.Instance.AnmakuWeight(1f);
			await NgoEvent.DelaySkippable(3400);
			SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_hair_long");
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			PostEffectManager.Instance.ResetShader();
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Hairstyle_JINE002);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Hairstyle_JINE001_Option004).Subscribe(async delegate
		{
			SingletonMonoBehaviour<WebCamManager>.Instance.GoOut();
			PostEffectManager.Instance.AnmakuWeight(1f);
			await NgoEvent.DelaySkippable(3400);
			SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_hair_drill");
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
			PostEffectManager.Instance.ResetShader();
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Hairstyle_JINE002);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
