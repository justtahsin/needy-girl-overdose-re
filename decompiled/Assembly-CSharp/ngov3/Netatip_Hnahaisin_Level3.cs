using Cysharp.Threading.Tasks;

namespace ngov3;

public class Netatip_Hnahaisin_Level3 : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Hhaisin3_Chou001", _lang);
		playing.Add(new Playing("first"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin3_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_ice1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin3_Chou003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin3_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_ice2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso017", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin3_Chou010", _lang), "stream_cho_kobiru"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin3_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, isBadComment: true, NgoEx.Kome("Hnahaisin3_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso016", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin3_Chou009", _lang), "stream_cho_h"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Hhaisin3_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso014", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin3_Chou007", _lang), "stream_cho_h"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Hnahaisin3_Kuso015", _lang), StatusType.Tension, 0, 10, NgoEx.TenTalk("Hhaisin3_Chou008", _lang), "stream_cho_kobiru"));
		playing.Add(new Playing("middle"));
		playing.Add(new Playing(startRead: true));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		await base.StartScenario();
		_Live.EndHaishin();
	}
}
