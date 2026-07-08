using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Yamihaishin_Level5 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Yami5_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, "", StatusType.Tension, 1, 0, "", "", "stream_ame_yanda_carisma"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso005", _lang)));
		playing.Add(new Playing(ChanceEffectType.Gothic, "in"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso007", _lang)));
		playing.Add(new Playing(ChanceEffectType.Gothic, "win_stop"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso010", _lang)));
		playing.Add(new Playing(ChanceEffectType.Gothic, "win"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Yami5_Kuso031", _lang)));
		playing.Add(new Playing(ChanceEffectType.Gothic, "out"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_kincho, isLoop: true);
		await base.StartScenario();
		await UniTask.Delay(2400);
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Ending_Yami_AfterHaishin>();
	}
}
