using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Angel_Level1 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("Angel1_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel1_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel1_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_fever"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel1_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_peace", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel1_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel1_Chou006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel1_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel1_Chou008", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel1_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_eeto"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel1_Chou010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel1_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_su_smile", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Angel1_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel1_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel1_Chou013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Angel1_Chou014", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
