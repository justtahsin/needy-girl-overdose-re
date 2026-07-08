using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Action_OdekakeZikka : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
		await GoOut();
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Hometown_JINE001);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Hometown_Tweet001);
		endEvent();
	}
}
