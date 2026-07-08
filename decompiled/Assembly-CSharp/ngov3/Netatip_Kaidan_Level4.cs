using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Kaidan_Level4 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Kaidan4_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan4_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan4_Chou003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan4_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan4_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso018", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaidan4_Chou013", _lang), "stream_cho_pointing", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan4_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach2"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan4_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso010", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaidan4_Chou010", _lang), "stream_cho_kawaiku_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan4_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso017", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaidan4_Chou012", _lang), "stream_cho_dokuzetsu", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan4_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso014", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaidan4_Chou011", _lang), "stream_cho_kawaiku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan4_Kuso016", _lang)));
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
