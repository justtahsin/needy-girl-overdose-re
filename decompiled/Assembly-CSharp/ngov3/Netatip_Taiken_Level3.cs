using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Taiken_Level3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Taiken3_Chou001", _lang);
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken3_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing_microphone", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Taiken3_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso021", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken3_Chou013", _lang), "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken3_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_microphone"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken3_Chou004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso020", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken3_Chou012", _lang), "stream_cho_kakkoyoku_superchat"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken3_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_superchat_microphone", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken3_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken3_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken3_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso014", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken3_Chou010", _lang), "stream_cho_shobon", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken3_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_hitotabi1", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso017", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken3_Chou011", _lang), "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken3_Kuso019", _lang)));
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
