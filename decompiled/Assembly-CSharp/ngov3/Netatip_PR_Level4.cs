using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_PR_Level4 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("PR4_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR4_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_figure1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso002", _lang)));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR4_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_figure2", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso014", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("PR4_Chou012", _lang), "stream_cho_pray", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR4_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_figure3", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR4_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_figure4"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso015", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("PR4_Chou013", _lang), "stream_cho_dokuzetsu_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR4_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_figure5", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR4_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_figure6", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR4_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_figure7"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso012", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("PR4_Chou010", _lang) + "___" + NgoEx.TenTalk("PR4_Chou010_after", _lang), "stream_cho_eeto___stream_cho_dokuzetsu_superchat"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR4_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_hitotabi1", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR4_Kuso013", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("PR4_Chou011", _lang), "stream_cho_dokuzetsu_superchat", "", isLoopAnim: false));
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
