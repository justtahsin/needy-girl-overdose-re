using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Angel_Level3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Angel3_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_fever"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pray"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou015", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso036", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel3_Chou018", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso038", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso039", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel3_Kuso040", _lang)));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
