using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;

namespace ngov3;

public class Ending_Completed_Day30 : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await UniTask.Delay(1000);
		ClickableAllScreen(onoff: false);
		SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(ShortcutInputManager.ControllerMode.Desktop);
		Time.timeScale = 1f;
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Jine);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_Completed_day30_000);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_Completed_day30_001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_Completed_day30_002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_Completed_day30_003);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_out_a");
		SingletonMonoBehaviour<Settings>.Instance.adieu = true;
		SingletonMonoBehaviour<Settings>.Instance.Save();
		SingletonMonoBehaviour<EventManager>.Instance.Save(30);
		await UniTask.Delay(3200);
		SingletonMonoBehaviour<WebCamManager>.Instance.HideGirl();
		AchievementStatsUpdater.UpdateStats("Ending_Completed");
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Ending_Completed_Day30_afterOut>();
		endEvent();
	}
}
