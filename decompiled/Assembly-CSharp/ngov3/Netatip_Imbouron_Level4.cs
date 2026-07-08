using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Imbouron_Level4 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Imbouron4_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron4_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grgr3"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Imbouron4_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron4_Chou003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron4_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grgr4", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron4_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grgr"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso014", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron4_Chou012", _lang) + "___" + NgoEx.TenTalk("Imbouron4_Chou013", _lang), "stream_cho_grgr"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron4_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron4_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron4_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grgr3"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron4_Chou009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso023", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron4_Chou014", _lang), "stream_cho_grgr"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron4_Kuso026", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron4_Chou015", _lang), "stream_cho_grgr3"));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron4_Chou011", _lang)));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
