using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;

namespace ngov3;

public class Ending_Completed : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await UniTask.Delay(200);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Completed;
		ClickableAllScreen(onoff: true);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		GameObject.Find("StartMenu").GetComponent<CanvasGroup>().interactable = false;
		GameObject.Find("StartMenu").GetComponent<CanvasGroup>().alpha = 0f;
		Transform transform = GameObject.Find("ShortCutParent").transform;
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
		Time.timeScale = 6f;
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Jine);
		await UniTask.Delay(12000);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_Completed_day1_000);
		await UniTask.Delay(12000);
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<DayPassing>();
		endEvent();
	}
}
