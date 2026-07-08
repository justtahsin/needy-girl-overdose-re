using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Kaisetu_Level3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Kaisetu3_Chouten001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu3_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_idle"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu3_Chouten003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu3_Chouten004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu3_Chouten005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso010", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu3_Chouten013", _lang), "stream_cho_yukkuri_smile", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu3_Chouten006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_idle"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu3_Chouten007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_teach"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu3_Chouten008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso022", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu3_Chouten014", _lang), "stream_cho_yukkuri_teach", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu3_Chouten009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_idle"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso023", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu3_Chouten015", _lang), "stream_cho_yukkuri_smile", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Kaisetu3_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu3_Chouten010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu3_Chouten011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_wink", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso019", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu3_Chouten012", _lang), "stream_cho_yukkuri_wink", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu3_Kuso016", _lang)));
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
