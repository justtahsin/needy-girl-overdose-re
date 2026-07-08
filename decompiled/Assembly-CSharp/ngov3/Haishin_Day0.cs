using Cysharp.Threading.Tasks;

namespace ngov3;

public class Haishin_Day0 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Haisin_Day0_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Day0haisin_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_angel"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso013", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Haisin_Day0_Chou013", _lang), "stream_cho_nyo", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Day0haisin_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso016", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Haisin_Day0_Chou014", _lang), "stream_cho_dokuzetsu_superchat", "", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Day0haisin_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Day0haisin_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso027", _lang)));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Haisin_Day0_Chou012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Day0haisin_Kuso029", _lang)));
	}

	public override async UniTask StartScenario()
	{
		SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.turorial_beforeHaishin2);
		await NgoEvent.DelaySkippable(Constants.SLOW * 3);
		SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
		await base.StartScenario();
		SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tutorial_afterHaishin);
		await NgoEvent.DelaySkippable(Constants.SLOW * 2);
		SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
		_Live.HaishinClean();
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Scenario_loop1_day0_night_AfterHaisin>();
	}
}
