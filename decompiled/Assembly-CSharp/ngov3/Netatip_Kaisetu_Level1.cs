using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Kaisetu_Level1 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Kaisetu1_Chouten001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu1_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_idle"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu1_Chouten003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu1_Chouten004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso020", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu1_Chouten012", _lang), "stream_cho_yukkuri_teach", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso006", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu1_Chouten009", _lang) + "___" + NgoEx.TenTalk("Kaisetu1_Chouten010", _lang), "stream_cho_yukkuri_smile___stream_cho_yukkuri_idle", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu1_Chouten005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu1_Chouten006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_yukkuri_smile"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu1_Chouten007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso016", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Kaisetu1_Chouten011", _lang), "stream_cho_yukkuri_idle"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaisetu1_Chouten008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaisetu1_Kuso019", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
