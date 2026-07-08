using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Zatudan_Level1 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Zatudan1_Chouten001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan1_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Zatudan1_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan1_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan1_Kuso016", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Zatudan1_Chouten010", _lang), "stream_cho_akaruku_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan1_Chouten003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan1_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan1_Kuso017", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Zatudan1_Chouten011", _lang), "stream_cho_kakkoyoku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan1_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan1_Chouten004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan1_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan1_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan1_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan1_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan1_Chouten005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan1_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan1_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Zatudan1_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Zatudan1_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan1_Chouten006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan1_Kuso014", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Zatudan1_Chouten007", _lang), "stream_cho_pointing", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan1_Kuso015", _lang), StatusType.Tension, 0, 1, NgoEx.TenTalk("Zatudan1_Chouten008", _lang) + "___" + NgoEx.TenTalk("Zatudan1_Chouten009", _lang), "stream_cho_dokuzetsu_superchat___stream_cho_kawaiku_superchat", "", isLoopAnim: false));
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
