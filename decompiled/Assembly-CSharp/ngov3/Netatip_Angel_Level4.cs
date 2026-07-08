using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Angel_Level4 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Angel4_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_peace", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su_smile", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou013", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso036", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou015", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel4_Chou016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso038", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso039", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso040", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso041", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel4_Kuso042", _lang)));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
