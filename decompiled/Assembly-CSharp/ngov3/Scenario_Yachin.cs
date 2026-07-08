using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Scenario_Yachin : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance.PlaySeByType(SoundType.SE_Mail);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Mail);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.YachinMail);
		await NgoEvent.DelaySkippable(Constants.SLOW);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_Aim);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Aim_Rent_LINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Aim_Rent_LINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.LINE_Aim);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Aim_Rent_LINE004);
		SingletonMonoBehaviour<EventManager>.Instance.Aim.Value = "DAY10までにフォロワー1万人";
		endEvent();
	}
}
