using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;
using ngov3.Effect;

namespace ngov3;

public class Ending_Normal : NgoEvent
{
	private IDisposable _disposable;

	private List<JineType> resList = new List<JineType>
	{
		JineType.Ending_Normal_JINE004_Option001,
		JineType.Ending_Normal_JINE004_Option002,
		JineType.Ending_Normal_JINE004_Option003,
		JineType.Ending_Normal_JINE004_Option004,
		JineType.Ending_Normal_JINE004_Option005
	};

	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Normal;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Normal000);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Normal001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Normal002);
		SingletonMonoBehaviour<NotificationManager>.Instance.AddMaturoNotifier();
		(from v in SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart)
			where v == 3
			select v).Subscribe(async delegate
		{
			StartBerserk();
		}).AddTo(compositeDisposable);
	}

	private async UniTask StartBerserk()
	{
		SingletonMonoBehaviour<EventManager>.Instance.executingAction = CmdType.None;
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_kincho, isLoop: true);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Normal_ChoutenTweet001);
		await UniTask.Delay(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Normal_ChoutenTweet002);
		await UniTask.Delay(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Normal_ChoutenTweet003);
		await UniTask.Delay(Constants.SLOW);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Normal_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Normal_JINE002);
		OnLonglineAsync();
	}

	public async UniTask OnLonglineAsync()
	{
		JineType trauma = SingletonMonoBehaviour<EventManager>.Instance.Trauma;
		if (trauma == JineType.None)
		{
			Debug.Log("Ending_Normalトラウマ聞いてなかったら飛ばす::" + trauma);
			await BlockedByeBye();
			return;
		}
		List<JineType> list = new List<JineType>
		{
			JineType.Event_LongLINE001,
			JineType.Event_LongLINE002,
			JineType.Event_LongLINE003,
			JineType.Event_LongLINE004,
			JineType.Event_LongLINE005
		};
		int answerIndex = list.IndexOf(trauma);
		Debug.Log("Ending_Normal:" + answerIndex + ":" + trauma);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Normal_JINE003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Normal_JINE004);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(resList);
		_disposable = SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Subscribe(async delegate(CollectionAddEvent<JineData> sentdata)
		{
			_disposable.Dispose();
			int num = resList.IndexOf(sentdata.Value.id);
			Debug.Log("sentIndex=" + num);
			if (num != answerIndex)
			{
				await BlockedByeBye();
			}
			else
			{
				await Seikai();
			}
		}).AddTo(compositeDisposable);
	}

	private async UniTask Seikai()
	{
		await NgoEvent.DelaySkippable(Constants.SLOW);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Normal_JINE005);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_smile");
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Normal_JINE006);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Normal_JINE007);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Normal_JINE008);
		await hibi();
	}

	private async UniTask hibi()
	{
		await NgoEvent.DelaySkippable(Constants.SLOW);
		GameObject.Find("DayPassingCover").GetComponent<IDayPassing>().yearsPass();
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		GameObject.Find("Live").gameObject.SetActive(value: false);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.TaskManager);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Jine);
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		window._close.interactable = false;
		window._minimize.interactable = false;
		window._maximize.interactable = false;
		await UniTask.Delay(Constants.SLOW);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Normal_000);
		await UniTask.Delay(Constants.SLOW);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_ending_kenjo, isLoop: true);
		PostEffectManager.Instance.AnmakuWeight(0.2f);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Normal_001);
		await UniTask.Delay(Constants.SLOW);
		PostEffectManager.Instance.AnmakuWeight(0.3f);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Normal_002);
		await UniTask.Delay(Constants.SLOW);
		PostEffectManager.Instance.AnmakuWeight(0.4f);
		await UniTask.Delay(Constants.FAST);
		(from count in SingletonMonoBehaviour<PoketterManager>.Instance.ObserveEveryValueChanged((PoketterManager pktr) => pktr._tweetQueue.Count)
			where count == 0
			select count).Take(1).Subscribe(async delegate
		{
			await UniTask.Delay(Constants.SLOW);
			await hutuutumannai();
		}).AddTo(compositeDisposable);
	}

	private async UniTask hutuutumannai()
	{
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Normal_ChoutenTweet004);
		await UniTask.Delay(Constants.MIDDLE);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_endng_normal, isLoop: true);
		PostEffectManager.Instance.AnmakuWeight(0f);
		SingletonMonoBehaviour<ChanceEffectController>.Instance.OnReach(ChanceEffectType.Body);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<ChanceEffectController>.Instance.OnFever();
		await BlockedByeBye();
	}

	private async UniTask BlockedByeBye()
	{
		PostEffectManager.Instance.SetShader(EffectType.Noisy);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.TaskManager);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Jine);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<PoketterManager>.Instance.isBlocked.Value = true;
		PostEffectManager.Instance.ResetShader();
		await NgoEvent.DelaySkippable(Constants.SLOW);
		await NgoEvent.DelaySkippable(Constants.FAST);
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		AchievementStatsUpdater.UpdateStats("Ending_Normal");
		await UniTask.Delay(Constants.SLOW * 20);
		endEvent();
	}
}
