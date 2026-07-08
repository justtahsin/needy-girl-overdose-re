using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Yamihaishin_Level1 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Yami1_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami1_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami1_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso004", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Yami1_Chou010", _lang), "stream_cho_pointing", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami1_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso019", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Yami1_Chou011", _lang), "stream_cho_akaruku_superchat"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami1_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami1_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso017", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Yami1_Chou008", _lang) + "___" + NgoEx.TenTalk("Yami1_Chou009", _lang), "stream_cho_kobiru_fever___stream_cho_kobiru_superchat"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami1_Kuso018", _lang)));
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
