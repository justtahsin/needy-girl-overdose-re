using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Darkness_Level2 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		defaultEffectType = EffectType.GoCrazy;
		title = NgoEx.TenTalk("Darkness2_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness2_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness2_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness2_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness3", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness2_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness2_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness2_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness2_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness2_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness4", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness2_Chou010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness2_Chou011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Darkness2_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_craziness3", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Darkness2_Kuso017", _lang)));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_yami, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
