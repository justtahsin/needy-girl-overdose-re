using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public class Scenario_horror_day3_day : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.TaskManager);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		await UniTask.Delay(Constants.MIDDLE);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_vomiting1");
		await UniTask.Delay(Constants.FAST);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Die).Uncloseable();
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.KeijibanMini);
		IWindow window2 = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.KeijibanMini);
		IWindow window3 = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.KeijibanMini);
		window.nakamiApp.GetComponent<KitsuneView>().UpdateContents(0);
		window2.nakamiApp.GetComponent<KitsuneView>().UpdateContents(1);
		window3.nakamiApp.GetComponent<KitsuneView>().UpdateContents(2);
		window.setRandomPosition();
		window2.setRandomPosition();
		window3.setRandomPosition();
		IChachedWindowParent chachedWindowParent = SingletonMonoBehaviour<ChachedWindowStore>.Instance.GetChachedWindowParent(ChachedWindowType.HORROR_DAY_3);
		for (int eye = 1; eye <= 22; eye++)
		{
			ChachedWindowObject chachedWindowObject = chachedWindowParent.Pop();
			chachedWindowObject.Open();
			chachedWindowObject.ExecNumberEvent(eye);
			await UniTask.Delay(120);
		}
		endEvent();
	}
}
