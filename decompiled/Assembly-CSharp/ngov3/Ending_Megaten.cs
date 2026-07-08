using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ngov3;

public class Ending_Megaten : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	private void Update()
	{
		PostEffectManager.Instance.SetShaderWeight((float)Random.Range(0, 100) / 100f);
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		string poem = NgoEx.SystemTextFromType(SystemTextType.Ending_Megaten_System001, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		string jine = NgoEx.SystemTextFromType(SystemTextType.Ending_Megaten_JINE001, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_craziness");
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Webcam).Maximize();
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<WindowManager>.Instance.CleanAll();
		await SingletonMonoBehaviour<Poem>.Instance.StartPoem(poem);
		SingletonMonoBehaviour<Poem>.Instance.CleanPoem();
		for (int i = 0; i < 30; i++)
		{
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistoryFromString(jine);
			await UniTask.Delay(30);
		}
		AchievementStatsUpdater.UpdateStats("Ending_Megaten");
		PostEffectManager.Instance.ResetShader();
		SceneManager.LoadScene("BiosToLoad");
		endEvent();
	}
}
