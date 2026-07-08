using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;

namespace ngov3;

public class Ending_Completed_Day30_afterOut : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Completed;
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: true);
		GameObject.Find("StartMenu").GetComponent<CanvasGroup>().interactable = true;
		GameObject.Find("StartMenu").GetComponent<CanvasGroup>().alpha = 1f;
		SingletonMonoBehaviour<WebCamManager>.Instance.HideGirl();
		Transform transform = GameObject.Find("ShortCutParent").transform;
		if ((bool)transform)
		{
			transform.Find("Live").gameObject.SetActive(value: false);
			transform.Find("asobu").gameObject.SetActive(value: false);
			transform.Find("neru").gameObject.SetActive(value: false);
			transform.Find("okusuri").gameObject.SetActive(value: false);
			transform.Find("internet").gameObject.SetActive(value: false);
			transform.Find("Odekake").gameObject.SetActive(value: false);
			transform.Find("Live").gameObject.SetActive(value: false);
			Transform transform2 = SingletonMonoBehaviour<TaskbarManager>.Instance.TaskBarObj.transform;
			transform2.Find("AmechanShortcut").gameObject.SetActive(value: false);
			transform2.Find("TaskManagerShortcut").gameObject.SetActive(value: false);
		}
		SingletonMonoBehaviour<CommandManager>.Instance.disableAllCommands();
		GameObject.Find("himitu").GetComponent<EventKakusinikuru>().enabled = false;
		IWindow w = SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Webcam);
		w.setInActive();
		await UniTask.Delay(1000);
		w.setActive();
		await UniTask.Delay(1000);
		w.setInActive();
		await UniTask.Delay(1000);
		w.setActive();
		await UniTask.Delay(1000);
		w.setInActive();
		await UniTask.Delay(1000);
		w.setActive();
		await UniTask.Delay(1000);
		w.setInActive();
		await UniTask.Delay(1000);
		w.setActive();
		await UniTask.Delay(1000);
	}
}
