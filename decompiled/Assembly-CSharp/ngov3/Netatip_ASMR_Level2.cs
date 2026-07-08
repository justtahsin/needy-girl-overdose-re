using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_ASMR_Level2 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("ASMR2_Chouten001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR2_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_asmr2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR2_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR2_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR2_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR2_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR2_Chouten003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_asmr5"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR2_Kuso005", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR2_Chouten006", _lang), "stream_cho_asmr3", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR2_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR2_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR2_Chouten004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR2_Kuso008", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR2_Chouten007", _lang), "stream_cho_asmr5"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR2_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR2_Chouten005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR2_Kuso013", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("ASMR2_Chouten008", _lang), "stream_cho_asmr2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR2_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR2_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR2_Kuso012", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
