using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Imbouron_Level2 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Imbouron2_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron2_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso019", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron2_Chou013", _lang), "stream_cho_teach", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron2_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron2_Chou004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron2_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso010", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron2_Chou011", _lang) + "___" + NgoEx.TenTalk("Imbouron2_Chou012", _lang), "stream_cho_akaruku___stream_cho_teach"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron2_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron2_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pray"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso015", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Imbouron2_Chou009", _lang) + "___" + NgoEx.TenTalk("Imbouron2_Chou010", _lang), "stream_cho_pointing", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Imbouron2_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Imbouron2_Kuso018", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Imbouron2_Chou008", _lang)));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
