using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace ngov3;

public class Status_Stress2_Night : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_craziness");
		SingletonMonoBehaviour<EventManager>.Instance.alpha = AlphaType.Darkness;
		SingletonMonoBehaviour<EventManager>.Instance.alphaLevel = 2;
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Action_HaishinStart>();
		GameObject.Find("MainPanel").transform.DORotate(new Vector3(0f, 0f, 0f), 0.2f);
		endEvent();
	}
}
