using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Hnahaisin_Level2 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Hhaisin2_Chou001", _lang);
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin2_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Hnahaisin2_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin2_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin2_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_h"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin2_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_chance_porori_idle"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso008", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin2_Chou009", _lang), "stream_cho_porori_pokan", "", isLoopAnim: false));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(SoundType.SE_Tetehen, isloop: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin2_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_chance_porori_win_stop", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin2_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_chance_porori_win"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso022", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin2_Chou011", _lang), "stream_cho_chance_porori_win2", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso018", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin2_Chou010", _lang), "stream_cho_pointing_porori", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso023", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin2_Chou012", _lang), "stream_cho_chance_porori_win3", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin2_Kuso021", _lang)));
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
