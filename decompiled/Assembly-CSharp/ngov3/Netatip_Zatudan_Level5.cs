using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Zatudan_Level5 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Zatudan5_Chouten001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan5_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan5_Chouten003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan5_Chouten004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan5_Chouten005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan5_Chouten006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan5_Chouten007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan5_Chouten008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su_smile", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan5_Chouten009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan5_Chouten010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan5_Chouten011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso026", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan5_Chouten012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Zatudan5_Chouten013", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Zatudan5_Kuso029", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing("last"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Yami1_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_endng_normal, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
