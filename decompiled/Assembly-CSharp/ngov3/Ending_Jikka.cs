using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_Jikka : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Jikka;
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_kenjo);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Aim_NotAchieved_Day14_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Aim_NotAchieved_Day14_LINE002);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_out_a");
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		AchievementStatsUpdater.UpdateStats("Ending_Common");
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		endEvent();
	}
}
