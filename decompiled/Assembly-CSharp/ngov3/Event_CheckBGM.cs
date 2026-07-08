using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Event_CheckBGM : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) == 1)
		{
			endEvent();
			return;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.isHorror && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) > 27)
		{
			endEvent();
			return;
		}
		SoundType soundType = SoundType.BGM_mainloop_kenjo;
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		if (status >= 5000)
		{
			soundType = SoundType.BGM_mainloop_normal;
		}
		if (status >= 10000)
		{
			soundType = SoundType.BGM_mainloop_yami;
		}
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) >= 11)
		{
			soundType = SoundType.BGM_mainloop_middle;
		}
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) >= 20)
		{
			soundType = SoundType.BGM_mainloop_shuban;
		}
		if (AudioManager.Instance != null && (AudioManager.Instance.PlayingBgm.Value == null || AudioManager.Instance?.PlayingBgm.Value.Sound.Id != soundType.ToString()))
		{
			AudioManager.Instance?.PlayBgmByType(soundType, isLoop: true);
		}
		endEvent();
	}
}
