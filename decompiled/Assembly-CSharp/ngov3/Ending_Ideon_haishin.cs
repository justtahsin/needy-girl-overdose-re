using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Ending_Ideon_haishin : LiveScenario
{
	private bool isEnd;

	private int light;

	protected override void Awake()
	{
		base.Awake();
		_Live.isUncontrollable = true;
		_Live._HaisinSkip.gameObject.SetActive(value: false);
		if (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN)
		{
			_Live.Speed = 3;
		}
		else
		{
			_Live.Speed = 0;
		}
		_Live._HaisinSpeed.gameObject.SetActive(value: false);
		_Live.SetSpeedLock(isLock: true);
		_Live.isGuideEnable = false;
		SingletonMonoBehaviour<ControllerGuideManager>.Instance.IsReady = false;
		title = NgoEx.TenTalk("Ideon_000", _lang);
		playing.Add(new Playing(ChanceEffectType.Ide, "Ide_in"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kashikoma"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_003", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_kobiru"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_004", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_005", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(ChanceEffectType.Ide, "Ide2"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_006", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(ChanceEffectType.Ide, "Ide2_loop"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_007", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_008", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_reaction1"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_009", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_teach3"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end000", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end001", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_010", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end003", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end004", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end002", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end005", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end007", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_012", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_013", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end008", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end009", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end010", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end006", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_015", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_shobon_smile"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end011", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end012", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end013", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end014", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end015", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end016", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_016", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end017", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_017", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_pointing"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end019", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_018", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end020", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end021", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_019", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end022", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end023", _lang)));
		playing.Add(new Playing(ChanceEffectType.Ide, "ide_invoke"));
		playing.Add(new Playing(SoundType.SE_ideonSound, isloop: false));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_020", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_akaruku"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Ideon_021", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_ide_invoke"));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
		playing.Add(new Playing(isJimaku: false, NgoEx.Kome("Ending_Ideon_end024", _lang)));
	}

	private void Update()
	{
		light++;
		if (isEnd && light > 1200)
		{
			PostEffectManager.Instance.SetShaderWeight((float)(light - 1200) / 100f);
		}
		else
		{
			PostEffectManager.Instance.SetShaderWeight(0f);
		}
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_ideon);
		await base.StartScenario();
		PostEffectManager.Instance.SetShader(EffectType.SatujinNoise);
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Ending_Ideon_afterHaishin>();
	}
}
