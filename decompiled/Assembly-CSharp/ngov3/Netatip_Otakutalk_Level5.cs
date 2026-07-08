using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Otakutalk_Level5 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Otaktalk5_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk5_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk5_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su_smile", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk5_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk5_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk5_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk5_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk5_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk5_Chou009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk5_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk5_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Otakutalk5_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk5_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Otaktalk5_Chou013", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su_fever"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_endng_normal, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
