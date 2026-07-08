using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

public class Action_HaishinStart : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken, skipWatchSp: true);
		if (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Yamihaishin)
		{
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
			AudioManager.Instance.PlaySeByType(SoundType.SE_takepill_lv1);
			SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim(SingletonMonoBehaviour<EventManager>.Instance.PlatformDiffAnimationMaster.GetAnimationNameFromKey(PlatformDiffAnimationKey.DAYPASS));
			await UniTask.Delay(2200);
		}
		SingletonMonoBehaviour<WindowManager>.Instance.CleanOnCommand();
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
		SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Jine);
		SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Poketter);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.NetaChoose);
		SingletonMonoBehaviour<CommandManager>.Instance.disableAllCommands();
		SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = true;
		SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.Tension).Value = 20;
		UniTask loadAnimTask = HaishinFirstAnimation.LoadHaishinFirstAnimation();
		if (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Yamihaishin && SingletonMonoBehaviour<EventManager>.Instance.alphaLevel == 5)
		{
			SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Ending_Yami>();
			endEvent();
			return;
		}
		int seed = UnityEngine.Random.Range(0, 300);
		CancellationTokenSource cts = new CancellationTokenSource();
		ClickableAllScreen(onoff: true);
		SingletonMonoBehaviour<EventManager>.Instance.cover.OnPointerDownAsObservable().Subscribe(delegate
		{
			cts.Cancel();
			ClickableAllScreen(onoff: false);
		}).AddTo(compositeDisposable);
		if (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Darkness)
		{
			PostEffectManager.Instance.SetShader(EffectType.Invert);
			PostEffectManager.Instance.SetShaderWeight(1f);
		}
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Bank);
		await UniTask.Delay(350);
		if (seed == 0 && SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_None && SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Darkness)
		{
			AudioManager.Instance.PlayBgmByType(SoundType.BANK_bank);
			await UniTask.Delay(9000);
			ClickableAllScreen(onoff: false);
			AudioManager.Instance.StopByType(SoundType.BANK_bank);
			SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Bank);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Missingwig_JINE001);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Missingwig_JINE002);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Missingwig_JINE003);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Missingwig_JINE004);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Missingwig_JINE005);
			SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Jine);
			await loadAnimTask;
			startCast();
		}
		else
		{
			try
			{
				AudioManager.Instance.PlayBgmByType(SoundType.BANK_bank);
				await UniTask.Delay(15000, ignoreTimeScale: false, PlayerLoopTiming.Update, cts.Token);
				cts.Cancel();
				await loadAnimTask;
				startCast();
			}
			catch (OperationCanceledException ex)
			{
				_ = ex;
				AudioManager.Instance.StopByType(SoundType.BANK_bank);
				await loadAnimTask;
				startCast();
			}
		}
	}

	private void startCast()
	{
		ClickableAllScreen(onoff: false);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Login);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Bank);
		SoundType soundType = SoundType.BGM_mainloop_kenjo;
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		if (status >= 5000)
		{
			soundType = SoundType.BGM_mainloop_normal;
		}
		if (status >= 10000)
		{
			soundType = SoundType.BGM_mainloop_yami;
		}
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) >= 11)
		{
			soundType = SoundType.BGM_mainloop_middle;
		}
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) >= 20)
		{
			soundType = SoundType.BGM_mainloop_shuban;
		}
		if (AudioManager.Instance != null && (AudioManager.Instance.PlayingBgm.Value == null || AudioManager.Instance?.PlayingBgm.Value.Sound.Id != soundType.ToString()))
		{
			AudioManager.Instance.PlayBgmByType(soundType, isLoop: true);
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Darkness)
		{
			PostEffectManager.Instance.ResetShaderCalmly();
		}
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Broadcast);
		SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(AppType.Broadcast);
		SingletonMonoBehaviour<WindowManager>.Instance.UnMovable(AppType.Broadcast);
		endEvent();
	}
}
