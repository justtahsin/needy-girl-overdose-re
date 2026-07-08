using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Darkness_Level1 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		defaultEffectType = EffectType.GoCrazy;
		title = NgoEx.TenTalk("Darkness1_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness1_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pout"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness1_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness1_Chou004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness1_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness1_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness1_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pout"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness1_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness1_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness1_Chou009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness1_Chou010", _lang)));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_kincho, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
