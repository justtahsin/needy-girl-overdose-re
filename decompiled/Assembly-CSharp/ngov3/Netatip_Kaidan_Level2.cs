using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Kaidan_Level2 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Kaidan2_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan2_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_dokuzetsu_superchat", isLoopAnim: false));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso001", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaidan2_Chou011", _lang), "stream_cho_pointing", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan2_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan2_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso014", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaidan2_Chou012", _lang), "stream_cho_dokuzetsu_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan2_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan2_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan2_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan2_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan2_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan2_Kuso013", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaidan2_Chou010", _lang), "stream_cho_nyo", "", isLoopAnim: false));
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
