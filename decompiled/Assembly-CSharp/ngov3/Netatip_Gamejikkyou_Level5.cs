using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Gamejikkyou_Level5 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Gamejikkyou5_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_sayo1"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_sayo2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_sayo3"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou014", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_sayo4", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Gamejikkyou5_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou015", _lang)));
		playing.Add(new Playing(SoundType.SE_chime_horror, isloop: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Gamejikkyou5_Chou016", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_game_sayo5", isLoopAnim: false));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_endng_normal, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
