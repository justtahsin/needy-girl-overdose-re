using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Angel_Level5 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Angel5_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_angel", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou005", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso036", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou013", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso036", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou014", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_fever"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso036", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel5_Kuso036", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou016", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou017", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing2"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel5_Chou018", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_InternetOverdose8bit, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
