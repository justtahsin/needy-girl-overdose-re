using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using UniRx;
using UnityEngine;

namespace ngov3;

public class Ending_Needy : NgoEvent
{
	private IDisposable _disposable;

	private IDisposable _disposable2;

	private GameObject _KyouizonEndAnimation;

	private JineType _onTimeout = JineType.Ending_Kyouizon_OiJINE2;

	private JineType _onDragJine = JineType.Ending_Kyouizon_OiJINE1;

	private bool _onFocus;

	private bool _isShaderActivate;

	private float _shaderWeight;

	protected override void Awake()
	{
		base.Awake();
	}

	private void Update()
	{
		if (_isShaderActivate)
		{
			_shaderWeight += 0.001f;
			if (_shaderWeight > 1f)
			{
				_shaderWeight -= 0.2f;
			}
			PostEffectManager.Instance.SetShaderWeight(_shaderWeight);
		}
	}

	public override async UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		base.startEvent(cancellationToken);
		SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_Needy;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Needy000);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Needy001);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Needy002);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Needy003);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Jine_BeforeEnding_Needy004);
		SingletonMonoBehaviour<NotificationManager>.Instance.AddMaturoNotifier();
		(from v in SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart)
			where v == 3
			select v).Subscribe(async delegate
		{
			night();
		}).AddTo(compositeDisposable);
	}

	private async UniTask night()
	{
		OnStartNeedyEnd();
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE001);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Jine_BeforeEnding_Needy004_Option001,
			JineType.Jine_BeforeEnding_Needy004_Option002,
			JineType.Jine_BeforeEnding_Needy004_Option003
		});
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Jine_BeforeEnding_Needy004_Option001).Subscribe(async delegate
		{
			await eventContinue1();
			SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Jine_BeforeEnding_Needy004_Option002).Subscribe(async delegate
		{
			await eventContinue1();
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
		}).AddTo(compositeDisposable);
		SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Where((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Jine_BeforeEnding_Needy004_Option003).Subscribe(async delegate
		{
			await eventContinue1();
			await NgoEvent.DelaySkippable(Constants.MIDDLE);
		});
	}

	private async UniTask eventContinue1()
	{
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE002);
		AudioManager.Instance.PlaySeByType(SoundType.SE_heartbeat);
		await OnDatePlaceAsync();
	}

	public void OnStartNeedyEnd()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.Webcam);
		AudioManager.Instance.StopBgm();
		AudioManager.Instance.PlayBgmByType(SoundType.BGM_event_kincho, isLoop: true);
		PostEffectManager.Instance.SetShader(EffectType.Kyouizon);
		_isShaderActivate = true;
		SingletonMonoBehaviour<EventManager>.Instance.SetShortcutState(isEnable: false);
		IWindow window = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Jine);
		window.Uncloseable();
		window.UnityGameObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
	}

	private async UniTask OnDatePlaceAsync(CancellationToken token = default(CancellationToken))
	{
		List<string> resList = NgoEx_Temp.GetOdekakeResponseList();
		CmdType firstDate = SingletonMonoBehaviour<EventManager>.Instance.FirstDate;
		if (firstDate == CmdType.None)
		{
			await OnSexCountAsync(token);
			return;
		}
		string answerTitle = NgoEx.CmdName(firstDate, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		await UniTask.Delay(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE003);
		AudioManager.Instance.PlaySeByType(SoundType.SE_heartbeat);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(resList);
		_disposable = SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Subscribe(async delegate(CollectionAddEvent<JineData> sentdata)
		{
			_disposable.Dispose();
			if (sentdata.Value.freeMessage != answerTitle)
			{
				if (string.IsNullOrEmpty(answerTitle) || answerTitle == NgoEx.CmdName(CmdType.OdekakeZikka, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value))
				{
					await UniTask.Delay(1000, ignoreTimeScale: false, PlayerLoopTiming.Update, token);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE014);
					await UniTask.Delay(1000, ignoreTimeScale: false, PlayerLoopTiming.Update, token);
				}
				await DieByNeedyEvent(token);
			}
			else
			{
				await OnSexCountAsync(token);
			}
		}).AddTo(compositeDisposable);
	}

	private async UniTask OnSexCountAsync(CancellationToken token = default(CancellationToken))
	{
		List<JineType> resList = new List<JineType>
		{
			JineType.Ending_Kyouizon_JINE004_Option1,
			JineType.Ending_Kyouizon_JINE004_Option2,
			JineType.Ending_Kyouizon_JINE004_Option3,
			JineType.Ending_Kyouizon_JINE004_Option4,
			JineType.Ending_Kyouizon_JINE004_Option5
		};
		await UniTask.Delay(1000, ignoreTimeScale: false, PlayerLoopTiming.Update, token);
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE004);
		AudioManager.Instance.PlaySeByType(SoundType.SE_heartbeat);
		await UniTask.Delay(1000, ignoreTimeScale: false, PlayerLoopTiming.Update, token);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(resList);
		_disposable = SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Subscribe(async delegate(CollectionAddEvent<JineData> sentdata)
		{
			_disposable.Dispose();
			JineType id = sentdata.Value.id;
			int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.MadeLoveCounter);
			int num = resList.IndexOf(id) + 1;
			if (status != num)
			{
				if (status == 0)
				{
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE009);
					await UniTask.Delay(Constants.MIDDLE);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE013);
					await UniTask.Delay(Constants.SLOW);
					await DieByNeedyEvent(token, isFocused: true);
				}
				else
				{
					await DieByNeedyEvent(token);
				}
			}
			else
			{
				await OnLonglineAsync(token);
			}
		}).AddTo(compositeDisposable);
	}

	public async UniTask OnLonglineAsync(CancellationToken token = default(CancellationToken))
	{
		JineType trauma = SingletonMonoBehaviour<EventManager>.Instance.Trauma;
		if (trauma == JineType.None)
		{
			await LongMessageAsync(token);
			return;
		}
		List<JineType> resList = new List<JineType>
		{
			JineType.Ending_Kyouizon_JINE005_Option1,
			JineType.Ending_Kyouizon_JINE005_Option2,
			JineType.Ending_Kyouizon_JINE005_Option3,
			JineType.Ending_Kyouizon_JINE005_Option4,
			JineType.Ending_Kyouizon_JINE005_Option5
		};
		List<JineType> list = new List<JineType>
		{
			JineType.Event_LongLINE001,
			JineType.Event_LongLINE002,
			JineType.Event_LongLINE003,
			JineType.Event_LongLINE004,
			JineType.Event_LongLINE005
		};
		int answerIndex = list.IndexOf(trauma);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE005);
		AudioManager.Instance.PlaySeByType(SoundType.SE_heartbeat);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(resList);
		_disposable = SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Subscribe(async delegate(CollectionAddEvent<JineData> sentdata)
		{
			_disposable.Dispose();
			if (resList.IndexOf(sentdata.Value.id) != answerIndex)
			{
				await DieByNeedyEvent(token);
			}
			else
			{
				await LongMessageAsync(token);
			}
		}).AddTo(compositeDisposable);
	}

	private async UniTask ConsumerLongMessageAsync(CancellationToken token = default(CancellationToken))
	{
		List<JineType> resList = new List<JineType>
		{
			JineType.Ending_Kyouizon_JINE006_Option1,
			JineType.Ending_Kyouizon_JINE006_Option2,
			JineType.Ending_Kyouizon_JINE006_Option3,
			JineType.Ending_Kyouizon_JINE006_Option4,
			JineType.Ending_Kyouizon_JINE006_Option5
		};
		CancellationTokenSource tokenSource = new CancellationTokenSource();
		OnTimeOutAsync(tokenSource.Token).Forget();
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE006);
		AudioManager.Instance.PlaySeByType(SoundType.SE_heartbeat);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(resList);
		_disposable = SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory.Subscribe(async delegate(CollectionAddEvent<JineData> sentdata)
		{
			_disposable.Dispose();
			tokenSource.Cancel();
			tokenSource.Dispose();
			resList.IndexOf(sentdata.Value.id);
			if (sentdata.Value.id == JineType.Ending_Kyouizon_JINE006_Option3)
			{
				await AliveRoute();
			}
			else
			{
				await DieByNeedyEvent(token);
			}
		}).AddTo(compositeDisposable);
	}

	private async UniTask LongMessageAsync(CancellationToken token = default(CancellationToken))
	{
		CancellationTokenSource tokenSource = new CancellationTokenSource();
		OnTimeOutAsync(tokenSource.Token).Forget();
		OnUnFocusedGameAsync(tokenSource.Token).Forget();
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE006);
		AudioManager.Instance.PlaySeByType(SoundType.SE_heartbeat);
		tokenSource.Cancel();
		tokenSource.Dispose();
		_ = GUIUtility.systemCopyBuffer;
		SingletonMonoBehaviour<JineManager>.Instance.StartMessage();
		_disposable2 = SingletonMonoBehaviour<JineManager>.Instance.Message.Subscribe(async delegate(string n)
		{
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, n));
			_disposable2.Dispose();
			bool checkLength = n.Length >= 100;
			bool checkNotCopyAndPaste = true;
			bool checkHasAme = n.Contains("あめ") || n.Contains("Ame") || n.Contains("糖糖") || n.Contains("아메") || n.Contains(NgoEx.SystemTextFromType(SystemTextType.Tooltip_Ame, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
			await UniTask.Delay(3500, ignoreTimeScale: false, PlayerLoopTiming.Update, token);
			if (checkLength && checkNotCopyAndPaste && checkHasAme)
			{
				await AliveRoute();
			}
			else
			{
				await DieByNeedyEvent(token);
			}
		}).AddTo(compositeDisposable);
	}

	private async UniTask AliveRoute()
	{
		PostEffectManager.Instance.ResetShaderCalmly();
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Webcam);
		_isShaderActivate = false;
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE007);
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		IWindow w = SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.AsobuNeedy);
		SingletonMonoBehaviour<WindowManager>.Instance.Uncloseable(w);
		endEvent();
	}

	private async UniTaskVoid OnTimeOutAsync(CancellationToken token = default(CancellationToken))
	{
		while (!token.IsCancellationRequested)
		{
			await UniTask.Delay(60000, ignoreTimeScale: false, PlayerLoopTiming.Update, token);
			if (!token.IsCancellationRequested)
			{
				await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(_onTimeout);
			}
		}
	}

	private async UniTaskVoid OnUnFocusedGameAsync(CancellationToken token = default(CancellationToken))
	{
		while (!token.IsCancellationRequested)
		{
			await UniTask.WaitUntil(() => !_onFocus, PlayerLoopTiming.Update, token);
			await UniTask.WaitUntil(() => _onFocus, PlayerLoopTiming.Update, token);
			if (token.IsCancellationRequested)
			{
				break;
			}
			await DieByNeedyEvent(token, isFocused: true);
		}
	}

	private void OnApplicationFocus(bool focus)
	{
		_onFocus = focus;
	}

	private async UniTask DieByNeedyEvent(CancellationToken token = default(CancellationToken), bool isFocused = false)
	{
		await GetNeedieList(isFocused);
		RectTransform MainCanvas = GameObject.Find("MainPanel").GetComponent<RectTransform>();
		_KyouizonEndAnimation = GameObject.Find("EndingCover").transform.Find("KyouizonEndAnimation").gameObject;
		AudioManager.Instance.StopAll();
		await UniTask.Delay(2500);
		AudioManager.Instance.PlaySeByType(SoundType.SE_zugozugozugo);
		MainCanvas.DOPunchPosition(new Vector3(20f, 20f, 0f), 2f, 10, 1f, snapping: true).Play();
		PostEffectManager.Instance.SetShader(EffectType.Bleeding);
		await UniTask.Delay(2000);
		_isShaderActivate = false;
		_KyouizonEndAnimation.SetActive(value: true);
		await UniTask.Delay(1500);
		PostEffectManager.Instance.ResetShader();
		AudioManager.Instance.PlaySeByType(SoundType.SE_zubasi);
		await UniTask.Delay(2000);
		AudioManager.Instance.PlaySeByType(SoundType.SE_bugo);
		MainCanvas.DORotate(new Vector3(0f, 0f, 2.4f), 1f).SetEase(Ease.OutBounce).Play();
		await UniTask.Delay(4000);
		AchievementStatsUpdater.UpdateStats("Ending_Needy");
		SingletonMonoBehaviour<EventManager>.Instance.CallEnding();
		endEvent();
	}

	private async UniTask GetNeedieList(bool isFocused = false)
	{
		if (isFocused)
		{
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE010);
			await UniTask.Delay(Constants.SLOW);
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE011);
			await UniTask.Delay(Constants.SLOW);
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE012);
			return;
		}
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await UniTask.Delay(500);
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await UniTask.Delay(500);
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await UniTask.Delay(500);
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await UniTask.Delay(500);
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await UniTask.Delay(300);
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await UniTask.Delay(300);
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await UniTask.Delay(300);
		SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await UniTask.Delay(300);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE008);
		await UniTask.Delay(Constants.SLOW);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE009);
		await UniTask.Delay(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE010);
		await UniTask.Delay(Constants.SLOW);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE011);
		await UniTask.Delay(Constants.SLOW);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Ending_Kyouizon_JINE012);
	}
}
