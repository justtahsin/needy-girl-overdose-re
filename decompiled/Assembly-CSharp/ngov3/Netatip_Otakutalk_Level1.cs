using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Otakutalk_Level1 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Otaktalk1_Chou001", _lang);
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk1_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma_otaku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk1_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_otaku2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso004", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Otaktalk1_Chou011", _lang), "stream_cho_otaku_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso015", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Otaktalk1_Chou012", _lang), "stream_cho_otaku_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk1_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_otaku2"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk1_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk1_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_otaku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso009", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Otaktalk1_Chou010", _lang), "stream_cho_pointing_otaku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk1_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_otaku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk1_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso016", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Otaktalk1_Chou013", _lang), "stream_cho_pointing_otaku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk1_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_otaku2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk1_Kuso014", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
