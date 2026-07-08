using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class Scenario_loop1_day0_night : NgoEvent
{
	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		await UniTask.Delay(2700);
		SingletonMonoBehaviour<StatusManager>.Instance.Moved.Value = true;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0.2f);
		SingletonMonoBehaviour<JineManager>.Instance.Uncontrolable();
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Password_JINE001);
		GameObject.Find("LoginShortCut").GetComponent<CanvasGroup>().alpha = 1f;
		GameObject.Find("LoginShortCut").GetComponent<CanvasGroup>().interactable = true;
		GameObject.Find("LoginShortCut").GetComponent<CanvasGroup>().blocksRaycasts = true;
		(from v in SingletonMonoBehaviour<NotificationManager>.Instance.ObserveEveryValueChanged((NotificationManager c) => SingletonMonoBehaviour<NotificationManager>.Instance._notiferParent.childCount)
			where v == 0
			select v).Take(1).Subscribe(delegate
		{
			SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tutorial_first);
		}).AddTo(compositeDisposable);
		endEvent();
	}
}
