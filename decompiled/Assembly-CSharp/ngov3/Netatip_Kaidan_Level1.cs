using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Netatip_Kaidan_Level1 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Kaidan1_Chou001", _lang);
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan1_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma", isLoopAnim: false));
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan1_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan1_Chou004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan1_Chou005", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(SoundType.SE_gagagagaga, isloop: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Kaidan1_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Kaidan1_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan1_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_unrest"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan1_Chou007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Kaidan1_Chou008", _lang)));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
