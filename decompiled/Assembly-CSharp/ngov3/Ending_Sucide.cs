using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class Ending_Sucide : NgoEvent
{
	private IDisposable _disposable;

	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Sucide;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		HaishinFirstAnimation.LoadHaishinFirstAnimation().Forget();
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Suicide000);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_ending_dead, isLoop: true);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Suicide001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Suicide002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Suicide003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Suicide004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Suicide005);
		SingletonMonoBehaviour<NotificationManager>.Instance.AddMaturoNotifier();
		(from v in SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart)
			where v == 3
			select v).Subscribe(async delegate
		{
			await night();
		}).AddTo(compositeDisposable);
	}

	private async UniTask night()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_Suicide001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_Suicide002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_Suicide003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_Ending_Suicide004);
		GameObject.Find("MainPanel").transform.Find("liveend").gameObject.SetActive(value: true);
	}
}
