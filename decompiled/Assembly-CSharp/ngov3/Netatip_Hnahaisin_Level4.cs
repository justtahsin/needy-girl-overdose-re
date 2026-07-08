using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Hnahaisin_Level4 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Hhaisin4_Chou001", _lang);
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin4_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin4_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin4_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin4_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_balanceball_start"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin4_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_balanceball"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso024", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin4_Chou010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin4_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso017", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin4_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso018", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin4_Chou009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Hnahaisin4_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin4_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Hnahaisin4_Kuso023", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
