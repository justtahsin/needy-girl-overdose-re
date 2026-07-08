using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Hnahaisin_Level1 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Hhaisin1_Chou001", _lang);
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin1_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin1_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_h"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin1_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin1_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin1_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_h_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso031", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin1_Chou010", _lang), "stream_cho_kawaiku_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin1_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pout"));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Hnahaisin1_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso025", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin1_Chou008", _lang), "stream_cho_shobon", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso027", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin1_Chou009", _lang), "stream_cho_kawaiku_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin1_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Hnahaisin1_Kuso030", _lang)));
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
