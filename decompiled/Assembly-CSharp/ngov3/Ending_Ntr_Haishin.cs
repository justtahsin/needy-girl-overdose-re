using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_Ntr_Haishin : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Ending_NTR_Chou000", _lang);
		_Live.isUncontrollable = true;
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_NTR_Chou001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_ntr1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_NTR_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_ntr2", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_NTR_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_ntr3", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso021", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso025", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_NTR_Chou004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_ntr4", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_NTR_Chou005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_NTR_Kuso029", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_NTR_Chou006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_ntr5", isLoopAnim: false));
		playing.Add(new Playing("last"));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_ending_kenjo);
		await base.StartScenario();
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Ending_Ntr_AfterHaishin>();
	}
}
