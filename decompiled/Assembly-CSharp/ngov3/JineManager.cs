using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class JineManager : SingletonMonoBehaviour<JineManager>
{
	public enum WaitStatusType
	{
		Stamp,
		Option,
		FreeForm,
		ChooseAction,
		Uncontrolable
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CAddJineHistory_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public JineManager _003C_003E4__this;

		public JineData l;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			JineManager jineManager = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					if (!jineManager.isJinedThisTime)
					{
						jineManager.addTimeSeparator(SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart));
						jineManager.isJinedThisTime = true;
					}
					if (l.user == JineUserType.ame && l.responseType == ResponseType.Stamp)
					{
						((Component)jineManager).GetComponent<Event_WebCamSumaho>().StartLooking();
					}
					else
					{
						AudioManager.Instance?.PlaySeByType(SoundType.SE_jine_send_stamp);
					}
					((Collection<JineData>)(object)jineManager._history).Add(l);
					if (l.user != JineUserType.ame || l.responseType != ResponseType.IdMessage)
					{
						break;
					}
					switch (jineManager._lang)
					{
					case LanguageType.JP:
						break;
					case LanguageType.CN:
					case LanguageType.KO:
					case LanguageType.TW:
						goto IL_016b;
					default:
						goto IL_01e7;
					}
					val2 = NgoEvent.DelaySkippable(JineDataConverter.convertJineDataToDrawable(l).BodyJp.Length * 180);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAddJineHistory_003Ed__23>(ref val, ref this);
						return;
					}
					goto IL_015f;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_015f;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01de;
				case 2:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0254;
					}
					IL_016b:
					val2 = NgoEvent.DelaySkippable(JineDataConverter.convertJineDataToDrawable(l).BodyCn.Length * 200);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAddJineHistory_003Ed__23>(ref val, ref this);
						return;
					}
					goto IL_01de;
					IL_0254:
					((Awaiter)(ref val)).GetResult();
					break;
					IL_01e7:
					val2 = NgoEvent.DelaySkippable(JineDataConverter.convertJineDataToDrawable(l).BodyEn.Length * 120);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAddJineHistory_003Ed__23>(ref val, ref this);
						return;
					}
					goto IL_0254;
					IL_01de:
					((Awaiter)(ref val)).GetResult();
					break;
					IL_015f:
					((Awaiter)(ref val)).GetResult();
					break;
				}
				((Component)jineManager).GetComponent<Event_WebCamSumaho>().OnBlur();
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
	private struct _003CAddJineHistory_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public JineManager _003C_003E4__this;

		public JineType t;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			JineManager jineManager = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					UniTask val = jineManager.AddJineHistoryFromType(t);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAddJineHistory_003Ed__25>(ref val2, ref this);
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
	private struct _003CAddJineHistoryFromString_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public bool isAme;

		public JineManager _003C_003E4__this;

		public string s;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			JineManager jineManager = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					JineUserType user = ((!isAme) ? JineUserType.pi : JineUserType.ame);
					UniTask val = jineManager.AddJineHistory(new JineData(user, JineType.None, ResponseType.Freeform, StampType.None, s));
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAddJineHistoryFromString_003Ed__24>(ref val2, ref this);
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
	private struct _003CAddJineHistoryFromType_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public JineType t;

		public JineManager _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			JineManager jineManager = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					JineData l = new JineData(t);
					UniTask val = jineManager.AddJineHistory(l);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAddJineHistoryFromType_003Ed__26>(ref val2, ref this);
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

	private LanguageType _lang;

	private ReactiveCollection<JineData> _history = new ReactiveCollection<JineData>();

	[SerializeField]
	public List<JineData> history = new List<JineData>();

	private readonly ReactiveCollection<JineData> _options = new ReactiveCollection<JineData>();

	public Subject<string> Message = new Subject<string>();

	public ReactiveProperty<WaitStatusType> waitStatus = new ReactiveProperty<WaitStatusType>(WaitStatusType.Stamp);

	[SerializeField]
	private Button _forTest;

	private bool isJinedThisTime;

	private int JINECOUNT_ONLOAD = 25;

	public IObservable<CollectionAddEvent<JineData>> OnChangeHistory => _history.ObserveAdd();

	public List<JineData> options => ((IEnumerable<JineData>)_options).ToList();

	public IObservable<CollectionAddEvent<JineData>> OnStartOptions => _options.ObserveAdd();

	public int JineCountOnLoad => JINECOUNT_ONLOAD;

	public void Start()
	{
		if ((Object)(object)_forTest != (Object)null)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_forTest), (Action<Unit>)delegate
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				AddJineHistoryFromType(JineDataConverter.RandomEnumValue<JineType>());
			}), (Component)(object)_forTest);
		}
		_lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayIndex), (Action<int>)delegate(int day)
		{
			addDaySeparator(day);
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)SingletonMonoBehaviour<StatusManager>.Instance.GetStatusObservable(StatusType.DayPart), (Action<int>)delegate
		{
			isJinedThisTime = false;
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(OnChangeHistory, (Action<CollectionAddEvent<JineData>>)delegate(CollectionAddEvent<JineData> value)
		{
			history.Add(value.Value);
		}), (Component)(object)this);
	}

	private void addDaySeparator(int day)
	{
		JineData item = new JineData(JineType.None, JineUserType.separator, day);
		((Collection<JineData>)(object)_history).Add(item);
	}

	public void addTimeSeparator(int DayPart)
	{
		((Collection<JineData>)(object)_history).Add(new JineData(JineType.None, JineUserType.timeSeparator, DayPart));
	}

	public void addEventSeparator(string separation)
	{
		((Collection<JineData>)(object)_history).Add(new JineData(JineUserType.eventSeparator, JineType.None, ResponseType.Freeform, StampType.None, separation));
	}

	public void addEventSeparator(JineType type)
	{
		((Collection<JineData>)(object)_history).Add(new JineData(JineUserType.eventSeparator, type));
	}

	[AsyncStateMachine(typeof(_003CAddJineHistory_003Ed__23))]
	public UniTask AddJineHistory(JineData l)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CAddJineHistory_003Ed__23 _003CAddJineHistory_003Ed__26 = default(_003CAddJineHistory_003Ed__23);
		_003CAddJineHistory_003Ed__26._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CAddJineHistory_003Ed__26._003C_003E4__this = this;
		_003CAddJineHistory_003Ed__26.l = l;
		_003CAddJineHistory_003Ed__26._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CAddJineHistory_003Ed__26._003C_003Et__builder)).Start<_003CAddJineHistory_003Ed__23>(ref _003CAddJineHistory_003Ed__26);
		return ((AsyncUniTaskMethodBuilder)(ref _003CAddJineHistory_003Ed__26._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAddJineHistoryFromString_003Ed__24))]
	public UniTask AddJineHistoryFromString(string s, bool isAme = true)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CAddJineHistoryFromString_003Ed__24 _003CAddJineHistoryFromString_003Ed__25 = default(_003CAddJineHistoryFromString_003Ed__24);
		_003CAddJineHistoryFromString_003Ed__25._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CAddJineHistoryFromString_003Ed__25._003C_003E4__this = this;
		_003CAddJineHistoryFromString_003Ed__25.s = s;
		_003CAddJineHistoryFromString_003Ed__25.isAme = isAme;
		_003CAddJineHistoryFromString_003Ed__25._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CAddJineHistoryFromString_003Ed__25._003C_003Et__builder)).Start<_003CAddJineHistoryFromString_003Ed__24>(ref _003CAddJineHistoryFromString_003Ed__25);
		return ((AsyncUniTaskMethodBuilder)(ref _003CAddJineHistoryFromString_003Ed__25._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAddJineHistory_003Ed__25))]
	public UniTask AddJineHistory(JineType t)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CAddJineHistory_003Ed__25 _003CAddJineHistory_003Ed__26 = default(_003CAddJineHistory_003Ed__25);
		_003CAddJineHistory_003Ed__26._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CAddJineHistory_003Ed__26._003C_003E4__this = this;
		_003CAddJineHistory_003Ed__26.t = t;
		_003CAddJineHistory_003Ed__26._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CAddJineHistory_003Ed__26._003C_003Et__builder)).Start<_003CAddJineHistory_003Ed__25>(ref _003CAddJineHistory_003Ed__26);
		return ((AsyncUniTaskMethodBuilder)(ref _003CAddJineHistory_003Ed__26._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAddJineHistoryFromType_003Ed__26))]
	public UniTask AddJineHistoryFromType(JineType t)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CAddJineHistoryFromType_003Ed__26 _003CAddJineHistoryFromType_003Ed__27 = default(_003CAddJineHistoryFromType_003Ed__26);
		_003CAddJineHistoryFromType_003Ed__27._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CAddJineHistoryFromType_003Ed__27._003C_003E4__this = this;
		_003CAddJineHistoryFromType_003Ed__27.t = t;
		_003CAddJineHistoryFromType_003Ed__27._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CAddJineHistoryFromType_003Ed__27._003C_003Et__builder)).Start<_003CAddJineHistoryFromType_003Ed__26>(ref _003CAddJineHistoryFromType_003Ed__27);
		return ((AsyncUniTaskMethodBuilder)(ref _003CAddJineHistoryFromType_003Ed__27._003C_003Et__builder)).Task;
	}

	public void Uncontrolable()
	{
		waitStatus.Value = WaitStatusType.Uncontrolable;
	}

	public void StartStamp()
	{
		waitStatus.Value = WaitStatusType.Stamp;
	}

	public void StartOption(List<JineType> l)
	{
		foreach (JineType item2 in l)
		{
			JineData item = new JineData(item2, JineUserType.pi);
			((Collection<JineData>)(object)_options).Add(item);
		}
		if (SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.Jine))
		{
			SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Jine));
		}
		waitStatus.Value = WaitStatusType.Option;
	}

	public void StartOption(List<string> l)
	{
		foreach (string item2 in l)
		{
			JineData item = new JineData(JineUserType.pi, JineType.None, ResponseType.Freeform, StampType.None, item2);
			((Collection<JineData>)(object)_options).Add(item);
		}
		if (SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.Jine))
		{
			SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Jine));
		}
		waitStatus.Value = WaitStatusType.Option;
	}

	public void EndOption()
	{
		((Collection<JineData>)(object)_options).Clear();
	}

	public void StartMessage()
	{
		if (SingletonMonoBehaviour<WindowManager>.Instance.isAppOpen(AppType.Jine))
		{
			SingletonMonoBehaviour<WindowManager>.Instance.Touched(SingletonMonoBehaviour<WindowManager>.Instance.GetWindowFromApp(AppType.Jine));
		}
		waitStatus.Value = WaitStatusType.FreeForm;
	}

	public void EndMessage(string msg)
	{
		waitStatus.Value = WaitStatusType.Stamp;
		Message.OnNext(msg);
	}

	public List<JineData> GetHistoryRange(int start, int end)
	{
		if (start >= history.Count || history.Count == 0 || start > end)
		{
			return new List<JineData>();
		}
		if (end >= history.Count)
		{
			return history.GetRange(start, history.Count - start);
		}
		int count = end - start;
		return history.GetRange(start, count);
	}

	public List<JineData> GetNewest()
	{
		int num = Math.Max(0, history.Count - JINECOUNT_ONLOAD);
		if (num != 0)
		{
			return history.GetRange(num, JINECOUNT_ONLOAD);
		}
		return history.GetRange(num, history.Count);
	}
}
