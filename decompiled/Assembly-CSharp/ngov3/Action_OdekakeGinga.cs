using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;

namespace ngov3;

public class Action_OdekakeGinga : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Ginga;
		GameObject.Find("ShortCutParent").GetComponent<CanvasGroup>().alpha = 0f;
		GameObject.Find("ShortCutParent").GetComponent<CanvasGroup>().interactable = false;
		GameObject.Find("ShortCutParent").GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.Find("stack").SetActive(value: false);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<TaskbarManager>.Instance.TaskBarGroup.alpha = 0f;
		SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
		HaishinFirstAnimation.LoadHaishinFirstAnimation().Forget();
		await GoOut();
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_ending_ginga, isLoop: true);
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.LiveDark);
		window.Uncloseable();
		window.UnMovable();
	}
}
