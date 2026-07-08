using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Status_Stress1_Night : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AchievementStatsUpdater.UpdateStats("Command_Wrist");
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_craziness");
		SingletonMonoBehaviour<EventManager>.Instance.alpha = AlphaType.Darkness;
		SingletonMonoBehaviour<EventManager>.Instance.alphaLevel = 1;
		GameObject.Find("MainPanel").GetComponent<Image>().DOColor(new Color(1f, 1f, 1f, 1f), 32f)
			.Play();
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Action_HaishinStart>();
		endEvent();
	}
}
