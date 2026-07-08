using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_ASMR_Level4 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("ASMR4_Chouten001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR4_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_asmr4", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR4_Chouten003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR4_Chouten004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_asmr1", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR4_Chouten005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_asmr8", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR4_Chouten006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_asmr7"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR4_Chouten007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_asmr7"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR4_Chouten008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_asmr7_end", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso025", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR4_Chouten012", _lang), "stream_cho_asmr4"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso043", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR4_Chouten013", _lang), "stream_cho_asmr4"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR4_Chouten009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso029", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR4_Chouten010", _lang) + "___" + NgoEx.TenTalk("ASMR4_Chouten011", _lang), "stream_cho_asmr7_end___stream_cho_asmr4", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso042", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR4_Chouten014", _lang), "stream_cho_asmr1", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("ASMR4_Kuso035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso036", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso038", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso039", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso040", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR4_Kuso041", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
