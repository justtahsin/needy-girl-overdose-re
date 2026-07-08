using Cysharp.Threading.Tasks;

namespace ngov3;

public class haishin_horror_day1 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isUncontrollable = true;
		title = NgoEx.TenTalk("Ending_KowaiInternet_Day1_Title", _lang);
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kawaiku_superchat", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pout"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pout"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_anger", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso036", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso038", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso039", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso040", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso041", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso042", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso043", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso044", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso045", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou013", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness4"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso046", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou014", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_vomiting1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso047", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day1_Kuso048", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day1_Chou015", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_vomiting2"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.HaishinClean();
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<TimePassing1>();
	}
}
