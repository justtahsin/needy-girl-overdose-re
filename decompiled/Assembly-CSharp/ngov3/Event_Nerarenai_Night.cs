using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;

namespace ngov3;

public class Event_Nerarenai_Night : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<JineManager>.Instance.addEventSeparator(JineType.Jine_Label_days);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Nerarenai_Night001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Nerarenai_Night002);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: true);
		GameObject.Find("Live").GetComponent<CanvasGroup>().interactable = false;
		GameObject.Find("neru").GetComponent<CanvasGroup>().interactable = false;
		GameObject.Find("Odekake").GetComponent<CanvasGroup>().interactable = false;
		SingletonMonoBehaviour<EventManager>.Instance.inNightBonus = true;
		SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
		endEvent();
	}
}
