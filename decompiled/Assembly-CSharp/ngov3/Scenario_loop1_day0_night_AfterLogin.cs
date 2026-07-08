using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class Scenario_loop1_day0_night_AfterLogin : NgoEvent
{
	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_idle");
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.TaskManager);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Login);
		AudioManager.Instance?.PlayBgmByType(SoundType.BGM_mainloop_normal, isLoop: true);
		GameObject.Find("LoginShortCut").GetComponent<CanvasGroup>().alpha = 0f;
		GameObject.Find("LoginShortCut").GetComponent<CanvasGroup>().interactable = false;
		GameObject.Find("LoginShortCut").GetComponent<CanvasGroup>().blocksRaycasts = false;
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE005);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE006);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE007);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE008);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Day0_JINE008_Option001,
			JineType.Day0_JINE008_Option002
		});
		SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tooltip_firstJine);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Day0_JINE008_Option001).Subscribe(async delegate
		{
			eventContinue1();
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Day0_JINE008_Option002).Subscribe(async delegate
		{
			eventContinue1();
		}).AddTo(compositeDisposable);
	}

	private async void eventContinue1()
	{
		SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE009);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE010);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE011);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE012);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE013);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE014);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE015);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Day0_JINE016);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		SingletonMonoBehaviour<EventManager>.Instance.AddEventQueue<Action_HaishinStart>();
		endEvent();
	}
}
