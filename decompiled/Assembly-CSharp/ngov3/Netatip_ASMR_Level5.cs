using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_ASMR_Level5 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		_Live.isOiwai = true;
		title = NgoEx.TenTalk("ASMR5_Chouten001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR5_Chouten002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_balanceball_asmr"));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR5_Chouten003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR5_Chouten004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR5_Chouten005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR5_Chouten006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR5_Chouten007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso031", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR5_Chouten008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso032", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso035", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR5_Chouten009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso036", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("ASMR5_Kuso038", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("ASMR5_Chouten010", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_kenjo, isLoop: true);
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
