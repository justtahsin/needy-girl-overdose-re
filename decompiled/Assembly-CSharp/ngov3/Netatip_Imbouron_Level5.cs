using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Imbouron_Level5 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Imbouron5_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron5_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku_superchat", isLoopAnim: false));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron5_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grgr4"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron5_Chou004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron5_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron5_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grgr"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron5_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron5_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron5_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grgr2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron5_Chou010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron5_Chou011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron5_Chou012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron5_Chou013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron5_Chou014", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grgr"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron5_Kuso025", _lang)));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_happy, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
