using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Zatudan_Level4 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Zatudan4_Chouten001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan4_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Zatudan4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan4_Chouten003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan4_Chouten004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso022", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Zatudan4_Chouten010", _lang) + "___" + NgoEx.TenTalk("Zatudan4_Chouten011", _lang), "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan4_Chouten005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan4_Chouten006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan4_Chouten007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso016", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Zatudan4_Chouten012", _lang), "stream_cho_su_fever"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso019", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Zatudan4_Chouten013", _lang), "stream_cho_pointing"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan4_Chouten008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan4_Kuso021", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan4_Chouten009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku_superchat", isLoopAnim: false));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
