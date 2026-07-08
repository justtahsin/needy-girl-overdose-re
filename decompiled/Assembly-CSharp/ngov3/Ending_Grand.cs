using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class Ending_Grand : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Grand;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<TaskbarManager>.Instance.TaskBarGroup.alpha = 0f;
		GameObject.Find("stack").SetActive(value: false);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Grand000);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_endng_normal);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Grand001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Grand002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Grand003);
		SingletonMonoBehaviour<NotificationManager>.Instance.AddMaturoNotifier();
		(from v in SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart)
			where v == 3
			select v).Subscribe(async delegate
		{
			SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
			IWindow w = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.App_Ending_Grand);
			SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(w);
			SingletonMonoBehaviour<WindowManager>.Instance.UnMovable(w);
			AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_grand);
			HaishinFirstAnimation.LoadHaishinFirstAnimation().Forget();
			await UniTask.Delay(106000);
			SingletonMonoBehaviour<Settings>.Instance.haishinSpeed = 0;
			IWindow w2 = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.LiveDark);
			SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(w2);
			endEvent();
		}).AddTo(compositeDisposable);
	}
}
