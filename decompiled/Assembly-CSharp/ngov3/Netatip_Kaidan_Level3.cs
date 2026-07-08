using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Kaidan_Level3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Kaidan3_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan3_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pout"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso022", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaidan3_Chou015", _lang), "stream_cho_dokuzetsu_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso004", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaidan3_Chou013", _lang), "stream_cho_nyo", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan3_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso021", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaidan3_Chou014", _lang), "stream_cho_teach", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan3_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan3_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_fever"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan3_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pout"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan3_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso014", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaidan3_Chou011", _lang) + "___" + NgoEx.TenTalk("Kaidan3_Chou012", _lang), "stream_cho_eeto"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan3_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan3_Chou009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan3_Chou010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan3_Kuso020", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
