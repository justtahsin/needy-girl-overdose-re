using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_ASMR_Level3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("ASMR3_Chouten001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR3_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_asmr1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR3_Chouten003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_asmr4", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR3_Chouten004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_asmr5"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR3_Chouten005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_asmr4", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso020", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR3_Chouten008", _lang), "stream_cho_asmr6", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso010", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR3_Chouten006", _lang), "stream_cho_asmr6", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso021", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR3_Chouten009", _lang), "stream_cho_asmr5"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso013", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR3_Chouten007", _lang), "stream_cho_asmr6", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR3_Kuso019", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
