using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class haishin_horror_day3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isUncontrollable = true;
		title = NgoEx.TenTalk("Ending_KowaiInternet_Day3_Title", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day3_Chou001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_bad", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day3_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_laugh"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day3_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness3", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day3_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness4", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day3_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_glare"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day3_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_omae", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day3_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_lower"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day3_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day3_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_bad", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day3_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_horror_laugh"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_KowaiInternet_Day3_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_KowaiInternet_Day3_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness3", isLoopAnim: false));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_zarazaranoise_lv2, isLoop: true);
		PostEffectManager.Instance.SetShader(EffectType.horror);
		PostEffectManager.Instance.SetShaderWeight(0.13f);
		GameObject.Find("MainPanel").GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
		await base.StartScenario();
		_Live.HaishinClean();
		PostEffectManager.Instance.SetShader(EffectType.horror);
		PostEffectManager.Instance.SetShaderWeight(0.13f);
		await SingletonMonoBehaviour<WindowManager>.Instance.DieOut();
		await UniTask.Delay(Constants.MIDDLE);
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<TimePassing1>();
	}
}
