using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Kaisetu_Level2 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Kaisetu2_Chouten001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu2_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_smile", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu2_Chouten003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_idle"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu2_Chouten004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu2_Chouten005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso012", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu2_Chouten011", _lang) + "___" + NgoEx.TenTalk("Kaisetu2_Chouten012", _lang), "stream_cho_yukkuri_smile", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu2_Chouten006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu2_Chouten007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_idle"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso023", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu2_Chouten013", _lang), "stream_cho_yukkuri_wink", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu2_Chouten008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu2_Chouten009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_wink", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu2_Kuso022", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu2_Chouten010", _lang), "stream_cho_yukkuri_smile", "", isLoopAnim: false));
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
