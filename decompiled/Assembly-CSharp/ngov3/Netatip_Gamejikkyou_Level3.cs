using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Gamejikkyou_Level3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Gamejikkyou3_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou3_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_ape1", isLoopAnim: false));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Gamejikkyou3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou3_Chou003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Gamejikkyou3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso022", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou3_Chou011", _lang), "stream_cho_game_ape3", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou3_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_ape2", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou3_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso014", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou3_Chou008", _lang), "stream_cho_game_ape3", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou3_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou3_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Gamejikkyou3_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso018", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou3_Chou009", _lang) + "___" + NgoEx.TenTalk("Gamejikkyou3_Chou010", _lang), "stream_cho_game_ape4", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Gamejikkyou3_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso023", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou3_Chou012", _lang), "stream_cho_game_ape5"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou3_Kuso021", _lang)));
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
