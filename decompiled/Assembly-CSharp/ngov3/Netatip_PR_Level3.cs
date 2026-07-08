using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_PR_Level3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("PR3_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR3_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_game1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso020", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("PR3_Chou012", _lang), "stream_cho_anken_game9"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR3_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_game2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR3_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_game3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR3_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_game4", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR3_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_game5"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR3_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR3_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_game6"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso015", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("PR3_Chou010", _lang), "stream_cho_anken_game7"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso016", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("PR3_Chou011", _lang), "stream_cho_anken_game8"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR3_Kuso014", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR3_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_game7"));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
