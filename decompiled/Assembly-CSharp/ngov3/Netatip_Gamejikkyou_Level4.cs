using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Gamejikkyou_Level4 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Gamejikkyou4_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_twilight1"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_twilight2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Gamejikkyou4_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_twilight3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso031", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou4_Chou016", _lang), "stream_cho_game_twilight8", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_twilight4"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_twilight5", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso025", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou4_Chou013", _lang), "stream_cho_game_twilight3"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou4_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_twilight6", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso030", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou4_Chou015", _lang), "stream_cho_game_twilight7", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso028", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou4_Chou014", _lang), "stream_cho_game_twilight3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou4_Kuso029", _lang)));
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
