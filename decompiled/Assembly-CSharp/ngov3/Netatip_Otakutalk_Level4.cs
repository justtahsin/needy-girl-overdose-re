using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Otakutalk_Level4 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Otaktalk4_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk4_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk4_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk4_Chou004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk4_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk4_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso007", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Otaktalk4_Chou012", _lang), "stream_cho_kashikoma"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk4_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk4_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk4_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk4_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso021", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Otaktalk4_Chou014", _lang), "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk4_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso018", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Otaktalk4_Chou013", _lang), "stream_cho_su_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk4_Kuso020", _lang)));
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
