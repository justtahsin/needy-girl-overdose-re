using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Zatudan_Level2 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Zatudan2_Chouten001", _lang);
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan2_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso020", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Zatudan2_Chouten010", _lang), "stream_cho_kobiru", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan2_Chouten003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan2_Chouten004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pout"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan2_Chouten005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan2_Chouten006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_crying_angry"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso015", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Zatudan2_Chouten008", _lang), "stream_cho_shobon", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso017", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Zatudan2_Chouten009", _lang), "stream_cho_dokuzetsu_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan2_Chouten007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan2_Kuso019", _lang)));
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
