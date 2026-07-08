using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UniRx;
using UnityEngine.Networking;

namespace ngov3;

public class Ending_Happy : NgoEvent
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_happy, isLoop: true);
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false, 0f);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Happy000);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Happy001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Happy002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Happy003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Happy004);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Happy005);
		SingletonMonoBehaviour<NotificationManager>.Instance.AddMaturoNotifier();
		(from v in SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart)
			where v == 3
			select v).Subscribe(async delegate
		{
			if (!SingletonMonoBehaviour<Settings>.Instance.mitaEnd.Contains(EndingType.Ending_Happy))
			{
				GoHappy();
			}
			else
			{
				FinishedCheckInternetAccess(await GetRequestAsync());
			}
		}).AddTo(compositeDisposable);
	}

	private void FinishedCheckInternetAccess(bool isSuccess)
	{
		if (isSuccess)
		{
			GoHappy();
		}
		else
		{
			GoNetshut();
		}
	}

	private async UniTask<bool> GetRequestAsync()
	{
		UnityWebRequest unityWebRequest = UnityWebRequest.Get("https://weibo.com/");
		unityWebRequest.timeout = 4;
		try
		{
			await unityWebRequest.SendWebRequest();
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private void GoHappy()
	{
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Happy;
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Action_HaishinStart>();
		endEvent();
	}

	private void GoNetshut()
	{
		SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Ending_NetShut>();
		endEvent();
	}
}
