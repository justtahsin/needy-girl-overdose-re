using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ngov3;

public class Ending_Ideon : NgoEvent
{
	private bool shuffle;

	private int light;

	private Bloom _bloomLight;

	private IWindow taiki;

	private IWindow keijiban;

	private IWindow hutaba;

	private IWindow niconico;

	private IWindow news;

	private IWindow insta;

	private IWindow wiki;

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Ideon;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		await UniTask.Delay(500);
		AudioManager.Instance.StopBgm();
		LoadWebcamData.DeleteAllCache();
		await Resources.UnloadUnusedAssets().ToUniTask();
		await GenerateWindowOutOfScreen();
		IWindow taskmanager = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.TaskManager);
		TaskManagerManager taskmanagerManager = taskmanager.nakamiApp.GetComponent<TaskManagerManager>();
		taskmanagerManager.SetToolTip(onoff: false);
		await UniTask.Yield();
		taskmanager.Maximize();
		taskmanager.Uncloseable();
		shuffle = true;
		await UniTask.Delay(600);
		taskmanagerManager.ReadyToOutOfOrder();
		await UniTask.Delay(600);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_endng_normal, isLoop: true);
		PostEffectManager.Instance.SetShader(EffectType.BloomLight);
		PostEffectManager.Instance.SetShaderWeight(0.2f);
		PostEffectManager.Instance.BloomLight.profile.TryGet<Bloom>(out _bloomLight);
		_bloomLight.intensity.value = 0f;
		float totalTime = 9f;
		float flashStartTime = 2f;
		float currentTime = 0f;
		float bloomMaxIntensity = 70f;
		taskmanagerManager.GoOutOfOrder();
		for (; currentTime < totalTime; currentTime += Time.deltaTime)
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.Follower, Random.Range(1, 9999999));
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.Stress, Random.Range(1, 100));
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.Love, Random.Range(1, 100));
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatusToNumber(StatusType.Yami, Random.Range(1, 100));
			if (currentTime > flashStartTime)
			{
				_bloomLight.intensity.value = (currentTime - flashStartTime) / (totalTime - flashStartTime) * bloomMaxIntensity;
			}
			await UniTask.Yield();
		}
		PostEffectManager.Instance.ResetShader();
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.TaskManager);
		shuffle = false;
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_ideon_kokuti1);
		await UniTask.Delay(2000);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_ideon_kokuti2);
		await UniTask.Delay(2000);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddTweet(TweetType.Ending_ideon_kokuti3);
		await UniTask.Delay(2000);
		SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Ending_ideon_kokuti4, new List<KusoRepType>
		{
			KusoRepType.Ending_Ideon_kuso001,
			KusoRepType.Ending_Ideon_kuso002,
			KusoRepType.Ending_Ideon_kuso003,
			KusoRepType.Ending_Ideon_kuso004,
			KusoRepType.Ending_Ideon_kuso005,
			KusoRepType.Ending_Ideon_kuso006,
			KusoRepType.Ending_Ideon_kuso007,
			KusoRepType.Ending_Ideon_kuso008,
			KusoRepType.Ending_Ideon_kuso009,
			KusoRepType.Ending_Ideon_kuso010,
			KusoRepType.Ending_Ideon_kuso011,
			KusoRepType.Ending_Ideon_kuso012
		});
		await UniTask.Delay(14000);
		await PopWindows();
		SingletonMonoBehaviour<Settings>.Instance.addImage("wikipedia", doSave: false);
		SingletonMonoBehaviour<Settings>.Instance.addImage("seinarukana", doSave: false);
		SingletonMonoBehaviour<Settings>.Instance.addImage("news", doSave: false);
		SingletonMonoBehaviour<Settings>.Instance.addImage("futaba2", doSave: false);
		SingletonMonoBehaviour<Settings>.Instance.addImage("futaba", doSave: false);
		SingletonMonoBehaviour<Settings>.Instance.addImage("insta", doSave: false);
		HaishinFirstAnimation.LoadHaishinFirstAnimation().Forget();
		endEvent();
	}

	private async UniTask GenerateWindowOutOfScreen()
	{
		Vector3 vector = new Vector3(2000f, 2000f, 0f);
		taiki = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.Ideon_taiki, playSe: false, makeTaskButton: false);
		taiki.Uncloseable();
		taiki.GameObjectTransform.position += vector;
		keijiban = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.KeijibanMini, playSe: false, makeTaskButton: false);
		keijiban.GameObjectTransform.position += vector;
		hutaba = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.Ideon_hutaba, playSe: false, makeTaskButton: false);
		hutaba.GameObjectTransform.position += vector;
		niconico = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.Ideon_nico, playSe: false, makeTaskButton: false);
		niconico.GameObjectTransform.position += vector;
		news = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.Ideon_news, playSe: false, makeTaskButton: false);
		news.GameObjectTransform.position += vector;
		insta = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.Ideon_Insta, playSe: false, makeTaskButton: false);
		insta.GameObjectTransform.position += vector;
		wiki = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow_Compact(AppType.Ideon_wiki, playSe: false, makeTaskButton: false);
		wiki.GameObjectTransform.position += vector;
		await UniTask.DelayFrame(5);
	}

	private async UniTask PopWindows()
	{
		Vector3 vector = new Vector3(2000f, 2000f, 0f);
		taiki.GameObjectTransform.position -= vector;
		SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(taiki);
		taiki.Touched();
		AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
		keijiban.GameObjectTransform.position -= vector;
		SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(keijiban);
		keijiban.Touched();
		AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
		hutaba.GameObjectTransform.position -= vector;
		SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(hutaba);
		hutaba.Touched();
		AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
		niconico.GameObjectTransform.position -= vector;
		SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(niconico);
		niconico.Touched();
		AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
		news.GameObjectTransform.position -= vector;
		SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(news);
		news.Touched();
		AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
		insta.GameObjectTransform.position -= vector;
		SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(insta);
		insta.Touched();
		AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
		wiki.GameObjectTransform.position -= vector;
		SingletonMonoBehaviour<WindowManager>.Instance.MakeTaskButton(wiki);
		wiki.Touched();
		AudioManager.Instance.PlaySeByType(SoundType.SE_kari);
	}
}
