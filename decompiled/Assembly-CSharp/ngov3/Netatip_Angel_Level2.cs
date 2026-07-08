using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Angel_Level2 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Angel2_Chou001", _lang);
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_peace", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su_smile", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou013", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou015", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso036", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel2_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel2_Chou017", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing", isLoopAnim: false));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
