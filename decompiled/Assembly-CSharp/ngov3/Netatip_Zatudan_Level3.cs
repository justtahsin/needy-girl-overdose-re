using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Zatudan_Level3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Zatudan3_Chouten001", _lang);
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan3_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan3_Chouten003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan3_Chouten004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso007", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Zatudan3_Chouten006", _lang) + "___" + NgoEx.TenTalk("Zatudan3_Chouten007", _lang), "stream_cho_dokuzetsu_superchat___stream_cho_teach", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso016", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Zatudan3_Chouten011", _lang), "stream_cho_akaruku_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan3_Chouten005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_fever"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso010", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Zatudan3_Chouten008", _lang) + "___" + NgoEx.TenTalk("Zatudan3_Chouten009", _lang) + "___" + NgoEx.TenTalk("Zatudan3_Chouten010", _lang), "stream_cho_su___stream_cho_su___stream_cho_shobon", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso017", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Zatudan3_Chouten012", _lang), "stream_cho_su_smile", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan3_Kuso015", _lang)));
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
