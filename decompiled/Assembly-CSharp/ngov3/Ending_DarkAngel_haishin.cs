using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;
using UnityEngine.Rendering;

namespace ngov3;

public class Ending_DarkAngel_haishin : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isUncontrollable = true;
		defaultEffectType = EffectType.GoCrazy;
		title = "";
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_idle2_1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_idle2_2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_lower2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_lower1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel020", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_wristcut1_1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel025", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_wristcut1_2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel030", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel032", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel035", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_wristcut1_3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel036", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel038", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel039", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel040", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_darkangel009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_neckcut"));
		playing.Add(new Playing(SoundType.SE_zubasi, isloop: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_darkangel041", _lang)));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_InternetOverdose8bit, isLoop: true);
		GameObject.Find("InvertVolume").GetComponent<Volume>().enabled = true;
		await base.StartScenario();
		NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(ShortcutInputManager.ControllerMode.Desktop);
		AchievementStatsUpdater.UpdateStats("Ending_DarkAngel");
		SingletonMonoBehaviour<EventManager>.Instance.CallEnding();
	}
}
