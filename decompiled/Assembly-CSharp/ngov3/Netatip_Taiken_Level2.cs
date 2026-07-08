using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Taiken_Level2 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Taiken2_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken2_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_dokuzetsu_fever"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken2_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_dokuzetsu_fever"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso013", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken2_Chou010", _lang), "stream_cho_teach", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso005", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken2_Chou008", _lang), "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: true, "", StatusType.Tension, 1, 0, "", "", "", isLoopAnim: true, SuperchatType.White, showAnti: true, NgoEx.TenTalk("Taiken2_Anti004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken2_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_dokuzetsu"));
		playing.Add(new Playing(isJimaku: true, "", StatusType.Tension, 1, 0, "", "", "", isLoopAnim: true, SuperchatType.White, showAnti: true, NgoEx.TenTalk("Taiken2_Anti005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken2_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_bad", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, "", StatusType.Tension, 1, 0, "", "", "", isLoopAnim: true, SuperchatType.White, showAnti: true, NgoEx.TenTalk("Taiken2_Anti006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken2_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_crying_angry"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso014", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken2_Chou011", _lang), "stream_cho_dokuzetsu_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso009", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Taiken2_Chou009", _lang), "stream_cho_pointing", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, ""));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Taiken2_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pout"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Taiken2_Kuso012", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
