using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Imbouron_Level3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Imbouron3_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron3_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron3_Chou003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso025", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron3_Chou011", _lang), "stream_cho_teach2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron3_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso009", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron3_Chou009", _lang), "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron3_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso026", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron3_Chou012", _lang), "stream_cho_dokuzetsu"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron3_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_gaoo", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron3_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron3_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_bad", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso022", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron3_Chou010", _lang), "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron3_Kuso024", _lang)));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami1_Chou007", _lang)));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
