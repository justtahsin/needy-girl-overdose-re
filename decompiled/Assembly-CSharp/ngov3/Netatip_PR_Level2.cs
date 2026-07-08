using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_PR_Level2 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("PR2_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR2_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_make1"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("PR2_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR2_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_make2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso017", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("PR2_Chou013", _lang), "stream_cho_anken_make9"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR2_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_make3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR2_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_make4"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR2_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_make5", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR2_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_make6", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso013", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("PR2_Chou011", _lang), "stream_cho_anken_make8"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR2_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_make7", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR2_Chou009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR2_Kuso016", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("PR2_Chou012", _lang), "stream_cho_anken_make1"));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR2_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_make7", isLoopAnim: false));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
