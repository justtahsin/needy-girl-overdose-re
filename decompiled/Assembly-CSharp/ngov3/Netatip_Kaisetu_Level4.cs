using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Kaisetu_Level4 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Kaisetu4_Chouten001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu4_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_cry", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu4_Chouten003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso004", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu4_Chouten009", _lang), "stream_cho_yukkuri_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso018", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu4_Chouten011", _lang), "stream_cho_yukkuri_idle"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu4_Chouten004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_teach"));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Kaisetu4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu4_Chouten005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu4_Chouten006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_idle"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu4_Chouten007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_bye", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso014", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu4_Chouten010", _lang), "stream_cho_yukkuri_wink"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso019", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu4_Chouten012", _lang), "stream_cho_yukkuri_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu4_Kuso017", _lang)));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu4_Chouten008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_anger", isLoopAnim: false));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
