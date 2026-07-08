using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Haishin_Happyend : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Ending_Happy_Chou000", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Happy_Chou001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso004", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Happy_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso013", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Happy_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso016", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Happy_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso019", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Happy_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso023", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Happy_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso032", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Happy_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso036", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Happy_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_peace", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso038", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso039", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso040", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso041", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso042", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso043", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso044", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso045", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso046", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso047", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso048", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso049", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Happy_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso050", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso051", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso052", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso053", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso054", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso055", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso056", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso057", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso058", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso059", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Happy_Kuso060", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Happy_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_h_superchat", isLoopAnim: false));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_happy, isLoop: true);
		await base.StartScenario();
		_Live.HaishinClean();
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Ending_Happy_AfterHaishin>();
	}
}
