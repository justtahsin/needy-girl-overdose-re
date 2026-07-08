using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Otakutalk_Level3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Otaktalk3_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk3_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk3_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk3_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su_smile", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso011", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Otaktalk3_Chou012", _lang), "stream_cho_su_smile", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk3_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk3_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk3_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk3_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk3_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk3_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso019", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Otaktalk3_Chou011", _lang), "stream_cho_pointing", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk3_Kuso023", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Otaktalk3_Chou013", _lang), "stream_cho_eeto"));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
