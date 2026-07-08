using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Action_HaishinDark : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<WindowManager>.Instance.CleanOnCommand();
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
		SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Jine);
		SingletonMonoBehaviour<WindowManager>.Instance.MinifyApp(AppType.Poketter);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.NetaChoose);
		SingletonMonoBehaviour<CommandManager>.Instance.disableAllCommands();
		SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = true;
		PostEffectManager.Instance.AnmakuWeight(1f);
		AudioManager.Instance.PlaySeByType(SoundType.SE_busuri);
		PostEffectManager.Instance.ResetShader();
		startCast();
	}

	private void startCast()
	{
		ClickableAllScreen(onoff: false);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Login);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Bank);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.LiveDark);
		SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(AppType.LiveDark);
		SingletonMonoBehaviour<WindowManager>.Instance.UnMovable(AppType.LiveDark);
		endEvent();
	}
}
