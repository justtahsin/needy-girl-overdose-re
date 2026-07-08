using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Gamejikkyou_Level2 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Gamejikkyou2_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou2_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su_superchat", isLoopAnim: false));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou2_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou2_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso022", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou2_Chou011", _lang), "stream_cho_kawaiku_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou2_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Gamejikkyou2_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Gamejikkyou2_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou2_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso015", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou2_Chou009", _lang), "stream_cho_pointing", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso016", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Gamejikkyou2_Chou010", _lang), "stream_cho_eeto"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou2_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou2_Chou007", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou2_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_richter", isLoopAnim: false));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
