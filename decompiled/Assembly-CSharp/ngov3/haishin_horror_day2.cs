using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class haishin_horror_day2 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isUncontrollable = true;
		title = NgoEx.TenTalk("Ending_KowaiInternet_Day2_Title", _lang);
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_peace", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pout"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business8"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day2_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou014", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business9"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day2_Chou015", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness3", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, "", StatusType.Tension, 1, 0, "", "", "stream_cho_vomiting1", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, "", StatusType.Tension, 1, 0, "", "", "stream_cho_vomiting2", isLoopAnim: false));
	}

	public override async UniTask StartScenario()
	{
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_KowaiInternet;
		await base.StartScenario();
		_Live.HaishinClean();
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Scenario_horror_day2_Afterhaisin>();
	}
}
