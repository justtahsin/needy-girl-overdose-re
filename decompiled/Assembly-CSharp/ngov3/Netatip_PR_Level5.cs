using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_PR_Level5 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("PR5_Chou001", _lang);
		_Live.isOiwai = true;
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business1"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business4"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou007", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business5"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business6"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business7"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou010", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business8"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou011", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business9"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_anken_business10"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("PR5_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou013", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou014", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru_superchat"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("PR5_Chou015", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing"));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_kenjo, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
