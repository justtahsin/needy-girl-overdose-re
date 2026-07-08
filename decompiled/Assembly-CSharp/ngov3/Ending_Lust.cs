using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_Lust : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Lust;
		SingletonMonoBehaviour<CommandManager>.Instance.disableAllCommands();
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Inran_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Inran_JINE002);
		SingletonMonoBehaviour<TooltipManager>.Instance.Show(TooltipType.Tooltip_yaru);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.AsobuLust);
		SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(AppType.AsobuLust);
		PostEffectManager.Instance.SetShader(EffectType.Otona);
		SingletonMonoBehaviour<ChanceEffectController>.Instance.OnReach(ChanceEffectType.Porori);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		endEvent();
	}
}
