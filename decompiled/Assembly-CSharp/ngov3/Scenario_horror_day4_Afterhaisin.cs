using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;

namespace ngov3;

public class Scenario_horror_day4_Afterhaisin : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		await SingletonMonoBehaviour<Poem>.Instance.StartPoem(NgoEx.SystemTextFromType(SystemTextType.Ending_KowaiInternet_Day4_Poem1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		SingletonMonoBehaviour<Poem>.Instance.CleanPoem();
		await SingletonMonoBehaviour<Poem>.Instance.StartPoem(NgoEx.SystemTextFromType(SystemTextType.Ending_KowaiInternet_Day4_Poem2, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		SingletonMonoBehaviour<Poem>.Instance.CleanPoem();
		PostEffectManager.Instance.SetShaderWeight(0f);
		SingletonMonoBehaviour<StatusManager>.Instance.timePassingToNextMorning();
		endEvent();
	}
}
