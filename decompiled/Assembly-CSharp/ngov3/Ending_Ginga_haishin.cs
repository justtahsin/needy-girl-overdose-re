using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;

namespace ngov3;

public class Ending_Ginga_haishin : LiveScenario
{
	private int light;

	protected override void Awake()
	{
		base.Awake();
		title = NgoEx.TenTalk("Ending_ginga000", _lang);
		_Live.isUncontrollable = true;
		_Live.Speed = 1;
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_ginga001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_g_express1"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga001", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_ginga002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga013", _lang)));
		playing.Add(new Playing(isJimaku: true, "", StatusType.Tension, 1, 0, "", "", "stream_cho_g_express1_2"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_ginga003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_g_express2"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga017", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_ginga004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga023", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga025", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga026", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga027", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga028", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga029", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga030", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga031", _lang)));
		playing.Add(new Playing(isJimaku: true, "", StatusType.Tension, 1, 0, "", "", "stream_cho_g_express2_3"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_ginga005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga032", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga033", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga034", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga035", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga036", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga037", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga038", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga039", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga040", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_ginga006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_g_express3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga041", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga042", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga043", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga044", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga045", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga046", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga047", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga048", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_ginga007", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga049", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga050", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga051", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga052", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga053", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga054", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga055", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga056", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga057", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_ginga008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga058", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga059", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga060", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga061", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga062", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga063", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga064", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga065", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga066", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_ginga009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga067", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga068", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga069", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga070", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga071", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga072", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga073", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga074", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga075", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga076", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_ginga010", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga077", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga078", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga079", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga080", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga081", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga082", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga083", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga084", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga085", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga086", _lang)));
		playing.Add(new Playing(isJimaku: true, "", StatusType.Tension, 1, 0, "", "", "stream_cho_g_express3_4"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_ginga011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga087", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga088", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga089", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga090", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga091", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga092", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga093", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga094", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga095", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ending_ginga012", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_g_express4"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga096", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga097", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga098", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga099", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga100", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga101", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga102", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga103", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga104", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga105", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga106", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_ginga107", _lang)));
	}

	private void Start()
	{
	}

	private void bloom()
	{
		Debug.Log("light:" + light);
		light++;
		if (light <= 2150 && light > 2000)
		{
			PostEffectManager.Instance.SetShaderWeight(((float)light - 2000f) / 150f);
		}
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_ginga);
		await base.StartScenario();
		_Live.HaishinClean();
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.LiveDark);
		SingletonMonoBehaviour<EventManager>.Instance.ClearEventQueue();
		AchievementStatsUpdater.UpdateStats("Ending_Ginga");
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
	}
}
