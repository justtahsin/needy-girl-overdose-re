using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_Happy_AfterHaishin : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Broadcast);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_Happy_Tweet001);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Poketter).Maximize();
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Happy_JINE001);
		SingletonMonoBehaviour<NotificationManager>.Instance.AddUrauraNotifier(NgoEx.EndingTextFromType(EndingTextType.Ending_Happy_System001, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		endEvent();
	}
}
