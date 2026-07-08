using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Angel_Level6 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		defaultEffectType = EffectType.GoCrazy;
		title = "";
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_angle"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel020", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_idle"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel025", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_lower1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel030", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel031", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel032", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel034", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel036", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel038", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel039", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_lower2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel040", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel041", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel042", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel043", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel044", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel045", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel046", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel047", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel048", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel049", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_craziness1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel050", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel051", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel052", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel053", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_craziness2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel054", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel055", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel056", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel057", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel058", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel059", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel060", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel061", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel062", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel063", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("DarkAngel_014", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_b_craziness1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel064", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel065", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel066", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("darkangel067", _lang)));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_grand, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
