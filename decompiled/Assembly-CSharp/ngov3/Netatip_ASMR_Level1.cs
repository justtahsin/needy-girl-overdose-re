using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_ASMR_Level1 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("ASMR1_Chouten001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR1_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_asmr1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("ASMR1_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR1_Chouten003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR1_Chouten004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR1_Chouten005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR1_Chouten006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_sleepy1", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR1_Chouten007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_sleepy1", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso015", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR1_Chouten008", _lang), "stream_cho_sleepy2___stream_cho_sleepy3", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso030", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR1_Chouten011", _lang), "stream_cho_asmr1", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso019", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR1_Chouten010", _lang), "stream_cho_sleepy3", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR1_Kuso029", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
