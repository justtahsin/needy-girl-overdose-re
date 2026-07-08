using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class haishin_horror_day5 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Ending_KowaiInternet_Day5_Title", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day5_Chou001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_iei"));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day5_Chou002", _lang)));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day5_Chou003", _lang)));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day5_Chou004", _lang)));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day5_Chou005", _lang)));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day5_Chou006", _lang)));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day5_Chou007", _lang)));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day5_Chou008", _lang)));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day5_Chou009", _lang)));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day5_Chou010", _lang)));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(SoundType.SE_zarazaranoise_lv2, isloop: true));
		playing.Add(new Playing(isJimaku: true, ""));
	}

	public override async UniTask StartScenario()
	{
		SingletonMonoBehaviour<Settings>.Instance.haishinSpeed = 0;
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_horrornoise_B, isLoop: true);
		await base.StartScenario();
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		AchievementStatsUpdater.UpdateStats("Ending_KowaiInternet");
	}
}
