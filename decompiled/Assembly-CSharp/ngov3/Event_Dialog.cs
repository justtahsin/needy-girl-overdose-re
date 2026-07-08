using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UniRx;

namespace ngov3;

public class Event_Dialog : NgoEvent
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003ClastTweet_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Event_Dialog _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Event_Dialog CS_0024_003C_003E8__locals6 = _003C_003E4__this;
			try
			{
				Awaiter val;
				UniTask val2;
				if (num != 0)
				{
					if (num == 1)
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0153;
					}
					if (CS_0024_003C_003E8__locals6.point > 6)
					{
						SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Dialog_Tweet_Good);
					}
					if (CS_0024_003C_003E8__locals6.point <= 6 && CS_0024_003C_003E8__locals6.point >= 3)
					{
						SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Dialog_Tweet_Normal);
					}
					if (CS_0024_003C_003E8__locals6.point <= 2)
					{
						SingletonMonoBehaviour<PoketterManager>.Instance.AddQueueWithKusoreps(TweetType.Event_Dialog_Tweet_Bad);
					}
					SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.Poketter);
					SingletonMonoBehaviour<WindowManager>.Instance.GetNakamiFromApp(AppType.Poketter).GetComponent<PoketterView2D>().shootTweetAll();
					val2 = NgoEvent.DelaySkippable(Constants.SLOW);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003ClastTweet_003Ed__10>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val)).GetResult();
				val2 = NgoEvent.DelaySkippable(Constants.SLOW);
				val = ((UniTask)(ref val2)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003ClastTweet_003Ed__10>(ref val, ref this);
					return;
				}
				goto IL_0153;
				IL_0153:
				((Awaiter)(ref val)).GetResult();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(Observable.Where<int>(ObserveExtensions.ObserveEveryValueChanged<PoketterManager, int>(SingletonMonoBehaviour<PoketterManager>.Instance, (Func<PoketterManager, int>)((PoketterManager _poketter) => ((Collection<TweetData>)(object)SingletonMonoBehaviour<PoketterManager>.Instance._tweetQueue).Count), (FrameCountType)0, false), (Func<int, bool>)((int v) => v == 0)), (Action<int>)async delegate
				{
					await NgoEvent.DelaySkippable(Constants.SLOW);
					CS_0024_003C_003E8__locals6.endEvent();
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals6.compositeDisposable);
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CstartEvent_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Event_Dialog _003C_003E4__this;

		public CancellationToken cancellationToken;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Event_Dialog CS_0024_003C_003E8__locals8 = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					((NgoEvent)CS_0024_003C_003E8__locals8).startEvent(cancellationToken);
					AudioManager.Instance.PlayBgmByType(SoundType.BGM_zarazaranoise_lv2, isLoop: true);
					SingletonMonoBehaviour<WebCamManager>.Instance.SetBaseAnim("stream_ame_idle_anxiety_e");
					UniTask val = SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE001);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CstartEvent_003Ed__2>(ref val2, ref this);
						return;
					}
				}
				else
				{
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val2)).GetResult();
				SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
				{
					JineType.Event_Dialog_JINE001_Option001,
					JineType.Event_Dialog_JINE001_Option002,
					JineType.Event_Dialog_JINE001_Option003
				});
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE001_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					CS_0024_003C_003E8__locals8.point++;
					SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE001_Reply001);
					CS_0024_003C_003E8__locals8.eventContinue1();
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals8.compositeDisposable);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE001_Option002)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE001_Reply002);
					CS_0024_003C_003E8__locals8.eventContinue1();
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals8.compositeDisposable);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE001_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
				{
					await NgoEvent.DelaySkippable(Constants.FAST);
					await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE001_Reply003);
					CS_0024_003C_003E8__locals8.eventContinue1();
				}), (ICollection<IDisposable>)CS_0024_003C_003E8__locals8.compositeDisposable);
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private int point;

	protected override void Awake()
	{
		base.Awake();
	}

	[AsyncStateMachine(typeof(_003CstartEvent_003Ed__2))]
	public override UniTask startEvent(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CstartEvent_003Ed__2 _003CstartEvent_003Ed__3 = default(_003CstartEvent_003Ed__2);
		_003CstartEvent_003Ed__3._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CstartEvent_003Ed__3._003C_003E4__this = this;
		_003CstartEvent_003Ed__3.cancellationToken = cancellationToken;
		_003CstartEvent_003Ed__3._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__3._003C_003Et__builder)).Start<_003CstartEvent_003Ed__2>(ref _003CstartEvent_003Ed__3);
		return ((AsyncUniTaskMethodBuilder)(ref _003CstartEvent_003Ed__3._003C_003Et__builder)).Task;
	}

	private async void eventContinue1()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE002);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE002_Option001,
			JineType.Event_Dialog_JINE002_Option002,
			JineType.Event_Dialog_JINE002_Option003
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE002_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE002_Reply001);
			eventContinue2();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE002_Option002)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE002_Reply002);
			eventContinue2();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE002_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE002_Reply003);
			eventContinue2();
		}), (ICollection<IDisposable>)compositeDisposable);
	}

	private async void eventContinue2()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE003);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE003_Option001,
			JineType.Event_Dialog_JINE003_Option002,
			JineType.Event_Dialog_JINE003_Option003
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE003_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE003_Reply001);
			eventContinue3();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE003_Option002)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE003_Reply002);
			eventContinue3();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE003_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE003_Reply003);
			eventContinue3();
		}), (ICollection<IDisposable>)compositeDisposable);
	}

	private async void eventContinue3()
	{
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE004);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE004_Option001,
			JineType.Event_Dialog_JINE004_Option002,
			JineType.Event_Dialog_JINE004_Option003
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE004_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE004_Reply001);
			eventContinue4();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE004_Option002)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE004_Reply002);
			eventContinue4();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE004_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE004_Reply003);
			eventContinue4();
		}), (ICollection<IDisposable>)compositeDisposable);
	}

	private async void eventContinue4()
	{
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE005);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE005_Option001,
			JineType.Event_Dialog_JINE005_Option002,
			JineType.Event_Dialog_JINE005_Option003
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE005_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE005_Reply001);
			eventContinue5();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE005_Option002)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE005_Reply002);
			eventContinue5();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE005_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE005_Reply003);
			eventContinue5();
		}), (ICollection<IDisposable>)compositeDisposable);
	}

	private async void eventContinue5()
	{
		await NgoEvent.DelaySkippable(Constants.MIDDLE);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE006);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE006_Option001,
			JineType.Event_Dialog_JINE006_Option002,
			JineType.Event_Dialog_JINE006_Option003
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE006_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE006_Reply001);
			eventContinue6();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE006_Option002)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE006_Reply002);
			eventContinue6();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE006_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE006_Reply003);
			eventContinue6();
		}), (ICollection<IDisposable>)compositeDisposable);
	}

	private async void eventContinue6()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE007);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE007_Option001,
			JineType.Event_Dialog_JINE007_Option002,
			JineType.Event_Dialog_JINE007_Option003
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE007_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE007_Reply001);
			eventContinue7();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE007_Option002)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE007_Reply002);
			eventContinue7();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE007_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE007_Reply003);
			eventContinue7();
		}), (ICollection<IDisposable>)compositeDisposable);
	}

	private async void eventContinue7()
	{
		await NgoEvent.DelaySkippable(Constants.FAST);
		await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE008);
		SingletonMonoBehaviour<JineManager>.Instance.StartOption(new List<JineType>
		{
			JineType.Event_Dialog_JINE008_Option001,
			JineType.Event_Dialog_JINE008_Option002,
			JineType.Event_Dialog_JINE008_Option003
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE008_Option001)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			point++;
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, -1);
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE008_Reply001);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			await lastTweet();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE008_Option002)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE008_Reply002);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(StatusType.Stress, 1);
			await lastTweet();
		}), (ICollection<IDisposable>)compositeDisposable);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(Observable.Where<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Func<CollectionAddEvent<JineData>, bool>)((CollectionAddEvent<JineData> x) => x.Value.id == JineType.Event_Dialog_JINE008_Option003)), (Action<CollectionAddEvent<JineData>>)async delegate
		{
			await NgoEvent.DelaySkippable(Constants.FAST);
			await SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(JineType.Event_Dialog_JINE008_Reply003);
			SingletonMonoBehaviour<JineManager>.Instance.StartStamp();
			await lastTweet();
		}), (ICollection<IDisposable>)compositeDisposable);
	}

	[AsyncStateMachine(typeof(_003ClastTweet_003Ed__10))]
	private UniTask lastTweet()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003ClastTweet_003Ed__10 _003ClastTweet_003Ed__11 = default(_003ClastTweet_003Ed__10);
		_003ClastTweet_003Ed__11._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003ClastTweet_003Ed__11._003C_003E4__this = this;
		_003ClastTweet_003Ed__11._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003ClastTweet_003Ed__11._003C_003Et__builder)).Start<_003ClastTweet_003Ed__10>(ref _003ClastTweet_003Ed__11);
		return ((AsyncUniTaskMethodBuilder)(ref _003ClastTweet_003Ed__11._003C_003Et__builder)).Task;
	}
}
