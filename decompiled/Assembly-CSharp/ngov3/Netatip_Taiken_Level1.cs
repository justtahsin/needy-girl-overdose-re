using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Taiken_Level1 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Taiken1_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken1_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kakkoyoku_superchat", isLoopAnim: false));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken1_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken1_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken1_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken1_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken1_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Taiken1_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken1_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken1_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken1_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken1_Kuso007", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken1_Chou010", _lang), "stream_cho_kawaiku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken1_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken1_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken1_Kuso014", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken1_Chou011", _lang), "stream_cho_kawaiku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken1_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken1_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken1_Kuso010", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken1_Chou008", _lang) + "___" + NgoEx.TenTalk("Taiken1_Chou009", _lang), "stream_cho_dokuzetsu_fever"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken1_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken1_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken1_Kuso013", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
