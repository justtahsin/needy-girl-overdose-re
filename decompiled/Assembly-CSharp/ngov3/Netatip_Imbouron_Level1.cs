using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Imbouron_Level1 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Imbouron1_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron1_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron1_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso021", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron1_Chou012", _lang), "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron1_Chou004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso007", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron1_Chou010", _lang), "stream_cho_gaoo", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron1_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron1_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron1_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso018", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron1_Chou011", _lang), "stream_cho_nyo", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron1_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_bad", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron1_Kuso022", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron1_Chou013", _lang), "stream_cho_bad", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron1_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_superchat", isLoopAnim: false));
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
