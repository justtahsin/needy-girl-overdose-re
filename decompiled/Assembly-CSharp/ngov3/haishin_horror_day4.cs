using Cysharp.Threading.Tasks;

namespace ngov3;

public class haishin_horror_day4 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isUncontrollable = true;
		defaultEffectType = EffectType.Yugami;
		title = NgoEx.TenTalk("Ending_KowaiInternet_Day4_Title", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day4_Chou001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_kashikoma", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day4_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_bokoboko"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day4_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_comment"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day4_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_smile"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day4_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_idle"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day4_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day4_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day4_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_eeto"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day4_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_idle"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day4_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_comment"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day4_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day4_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_smile"));
	}

	public override async UniTask StartScenario()
	{
		PostEffectManager.Instance.SetShader(EffectType.Yugami);
		PostEffectManager.Instance.SetShaderWeight(0.3f);
		await base.StartScenario();
		PostEffectManager.Instance.SetShaderWeight(1f);
		_Live.HaishinClean();
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Scenario_horror_day4_Afterhaisin>();
	}
}
