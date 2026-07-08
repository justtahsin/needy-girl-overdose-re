using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;

namespace ngov3;

public class Ending_Sucide_haishin : LiveScenario
{
	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Ending_Sayonara_001", _lang);
		_Live.isUncontrollable = true;
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Sayonara_Chou001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_sayonara1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso005", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Sayonara_Chou002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_sayonara2", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso006", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_Sayonara_Chou003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_sayonara3", isLoopAnim: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso012", _lang)));
		playing.Add(new Playing(SoundType.SE_dosa, isloop: false));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Sayonara_Kuso016", _lang)));
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.StopAll();
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_wind, isLoop: true);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.sayonalastDialog);
		GameObject.Find("MainPanel").transform.Find("liveend").gameObject.SetActive(value: false);
		await base.StartScenario();
		AchievementStatsUpdater.UpdateStats("Ending_Sucide");
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
	}
}
