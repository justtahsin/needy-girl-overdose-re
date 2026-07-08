using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Yamihaishin_Level4 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Yami4_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami4_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Yami4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami4_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami4_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami4_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami4_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pout"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami4_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Yami4_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso042", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Yami4_Chou014", _lang), "stream_cho_su"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami4_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pout"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami4_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_dokuzetsu_fever"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso034", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Yami4_Chou010", _lang) + "___" + NgoEx.TenTalk("Yami4_Chou011", _lang), "stream_cho_su___stream_cho_pointing"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso036", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Yami4_Chou012", _lang) + "___" + NgoEx.TenTalk("Yami4_Chou013", _lang), "stream_cho_bad", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso038", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso039", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso040", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami4_Kuso041", _lang)));
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
