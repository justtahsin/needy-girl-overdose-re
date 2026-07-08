using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;

namespace ngov3;

public class Ending_NetShut : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		GameObject.Find("stack").SetActive(value: false);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<TaskbarManager>.Instance.TaskBarGroup.alpha = 0f;
		SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_NetShut;
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_InternetOverdose8bit);
		IWindow w = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.App_Ending_Netshut);
		SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(w);
		SingletonMonoBehaviour<WindowManager>.Instance.UnMovable(w);
		await UniTask.Delay(120000);
		SingletonMonoBehaviour<Settings>.Instance.addImage("tweet_selfie_cho_net_disconnection");
		AchievementStatsUpdater.UpdateStats("Ending_NetShut");
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		await UniTask.Delay(125000);
		endEvent();
	}
}
