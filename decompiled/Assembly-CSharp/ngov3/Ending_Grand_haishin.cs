using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ngov3;

public class Ending_Grand_haishin : LiveScenario
{
	private Bloom _bloomLight;

	protected override void Awake()
	{
		base.Awake();
		PostEffectManager.Instance.BloomLight.profile.TryGet<Bloom>(out _bloomLight);
		title = "";
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Grand_LastHaihin001", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grandend1"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Grand_LastHaihin002", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grandend2"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Grand_LastHaihin003", _lang)));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, NgoEx.TenTalk("Grand_LastHaihin004", _lang), StatusType.Tension, 1, 0, "", "", "stream_cho_grandend3"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing(isJimaku: true, "", StatusType.Tension, 1, 0, "", "", "stream_cho_grandend3"));
		playing.Add(new Playing("rainbow"));
		playing.Add(new Playing("rainbow"));
	}

	private void Update()
	{
		_bloomLight.intensity.value = 6f + Random.Range(0f, 4f);
	}

	public override async UniTask StartScenario()
	{
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_event_emo, isLoop: true);
		PostEffectManager.Instance.SetShader(EffectType.BloomLight);
		PostEffectManager.Instance.SetShaderWeight(0.17f);
		await base.StartScenario();
		AchievementStatsUpdater.UpdateStats("Ending_Grand");
		SingletonMonoBehaviour<NotificationManager>.Instance.osimai();
		await UniTask.Delay(Constants.SLOW * 200);
	}
}
