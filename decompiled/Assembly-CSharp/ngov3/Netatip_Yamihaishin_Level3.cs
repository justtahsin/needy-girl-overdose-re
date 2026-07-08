using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Yamihaishin_Level3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Yami3_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami3_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pout"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami3_Chou003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami3_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_hitotabi1", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Yami3_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami3_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Yami3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso025", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Yami3_Chou010", _lang), "stream_cho_shobon", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami3_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso017", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Yami3_Chou008", _lang), "stream_cho_sorrow_smile", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami3_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_sorrow_smile", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso021", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Yami3_Chou009", _lang), "stream_cho_sorrow_smile", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Yami3_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso026", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Yami3_Chou011", _lang), "stream_cho_hitotabi2", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami3_Kuso024", _lang)));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		SingletonMonoBehaviour<EventManager>.Instance.kyuusiCount = 3;
		_Live.EndHaishin();
	}
}
