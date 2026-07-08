using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_Sukisuki : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Sukisuki;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.JINE_Ending_Sukisuki001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.JINE_Ending_Sukisuki002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.JINE_Ending_Sukisuki002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.JINE_Ending_Sukisuki002);
		SingletonMonoBehaviour<WindowManager>.Instance.LoveOut();
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.JINE_Ending_Sukisuki002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.JINE_Ending_Sukisuki002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.JINE_Ending_Sukisuki002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.JINE_Ending_Sukisuki002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.JINE_Ending_Sukisuki002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.JINE_Ending_Sukisuki002);
		AchievementStatsUpdater.UpdateStats("Ending_Sukisuki");
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		for (int i = 0; i < 100; i++)
		{
			if (!(SingletonMonoBehaviour<JineManager>.Instance == null))
			{
				await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.JINE_Ending_Sukisuki002);
				await UniTask.Delay(300);
			}
		}
	}
}
