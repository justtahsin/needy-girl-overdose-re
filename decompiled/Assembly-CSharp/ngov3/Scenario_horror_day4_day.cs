using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace ngov3;

public class Scenario_horror_day4_day : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		GameObject.Find("GameManager").GetComponent<WindowManager>().DieOut();
		GameObject.Find("MainPanel").GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.TaskManager);
		PostEffectManager.Instance.SetShader(EffectType.horror);
		PostEffectManager.Instance.SetShaderWeight(0.13f);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0.2f);
		GameObject.Find("InvertVolume").GetComponent<Volume>().enabled = true;
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_craziness");
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_vomiting1");
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE001);
		SingletonMonoBehaviour<WebCamManager>.Instance.PlayAnim("stream_ame_vomiting2");
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE002);
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE003);
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType> { JineType.Ending_KowaiInternet_Day4_LINE003_pi });
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Ending_KowaiInternet_Day4_LINE003_pi).Subscribe(async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE004);
			AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
			eventContinue1();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue1()
	{
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE005);
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_KowaiInternet_Day4_LINE006);
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		await UniTask.Delay(14);
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		await UniTask.Delay(14);
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		await UniTask.Delay(14);
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		await UniTask.Delay(14);
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		await UniTask.Delay(14);
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		await UniTask.Delay(14);
		AudioManager.Instance.PlaySeByType(SoundType.SE_chime);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_chime, isLoop: true);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		GameObject.Find("HakkyoShortCutParent").GetComponent<CanvasGroup>().alpha = 1f;
		GameObject.Find("HakkyoShortCutParent").GetComponent<CanvasGroup>().interactable = true;
		GameObject.Find("HakkyoShortCutParent").GetComponent<CanvasGroup>().blocksRaycasts = true;
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: true);
		endEvent();
	}
}
