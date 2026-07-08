using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Taiken_Level4 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Taiken4_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken4_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_superchat", isLoopAnim: false));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken4_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken4_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Taiken4_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso014", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken4_Chou014", _lang) + "___" + NgoEx.TenTalk("Taiken4_Chou015", _lang), "stream_cho_shobon___stream_cho_pointing", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken4_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken4_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken4_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken4_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Taiken4_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken4_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su_smile", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken4_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken4_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_dokuzetsu_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso025", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken4_Chou013", _lang), "stream_cho_unrest", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken4_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken4_Kuso029", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken4_Chou016", _lang), "stream_cho_h"));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Taiken4_Kuso028", _lang)));
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
