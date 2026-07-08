using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Taiken_Level5 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Taiken5_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan1", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan2", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan3", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan4", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou015", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan5", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso036", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso038", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou020", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan4", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken5_Chou021", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_fan6", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso039", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso040", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso041", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken5_Kuso042", _lang)));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_endng_normal, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
