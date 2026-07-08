using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Kaidan_Level5 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Kaidan5_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pray"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su_smile", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou011", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso014", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou013", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach2"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou015", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pray"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan5_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan5_Chou016", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_endng_normal, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
