using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class JineView : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CAwake_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public JineView _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			JineView CS_0024_003C_003E8__locals16 = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					List<JineData>.Enumerator enumerator = SingletonMonoBehaviour<JineManager>.Instance.GetNewest().GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							JineData current = enumerator.Current;
							CS_0024_003C_003E8__locals16.makeJine(current, 0, isNew: false);
						}
					}
					finally
					{
						if (num < 0)
						{
							((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
						}
					}
					UniTask val = CS_0024_003C_003E8__locals16.ForceScrollToLatest();
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAwake_003Ed__21>(ref val2, ref this);
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
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<JineManager.WaitStatusType>((IObservable<JineManager.WaitStatusType>)SingletonMonoBehaviour<JineManager>.Instance.waitStatus, (Action<JineManager.WaitStatusType>)delegate(JineManager.WaitStatusType value)
				{
					CS_0024_003C_003E8__locals16.SwitchJineStatus(value);
				}), ((Component)CS_0024_003C_003E8__locals16).gameObject);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnChangeHistory, (Action<CollectionAddEvent<JineData>>)async delegate(CollectionAddEvent<JineData> JineData)
				{
					//IL_0016: Unknown result type (might be due to invalid IL or missing references)
					//IL_0017: Unknown result type (might be due to invalid IL or missing references)
					await CS_0024_003C_003E8__locals16.makeJine(JineData.Value, 0);
				}), ((Component)CS_0024_003C_003E8__locals16).gameObject);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<CollectionAddEvent<JineData>>(SingletonMonoBehaviour<JineManager>.Instance.OnStartOptions, (Action<CollectionAddEvent<JineData>>)delegate(CollectionAddEvent<JineData> l)
				{
					CS_0024_003C_003E8__locals16.showOptions();
					CS_0024_003C_003E8__locals16.AddOptions(l.Value);
				}), ((Component)CS_0024_003C_003E8__locals16).gameObject);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals16._submit), (Action<Unit>)delegate
				{
					CS_0024_003C_003E8__locals16.sendMessage(CS_0024_003C_003E8__locals16._inputField.text);
				}), (Component)(object)CS_0024_003C_003E8__locals16._submit);
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(CS_0024_003C_003E8__locals16.ToBottom), (Action<Unit>)async delegate
				{
					await CS_0024_003C_003E8__locals16.ForceScrollToLatest();
				}), (Component)(object)CS_0024_003C_003E8__locals16.ToBottom);
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
	private struct _003CForceScrollToLatest_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public JineView _003C_003E4__this;

		private TweenAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			JineView jineView = _003C_003E4__this;
			try
			{
				TweenAwaiter val;
				if (num != 0)
				{
					((Component)jineView.ToBottom).gameObject.SetActive(false);
					val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<Tweener>(TweenSettingsExtensions.SetEase<Tweener>(DOTweenModuleUI.DOVerticalNormalizedPos(jineView._scrollRect, 0f, 0.15f, true), (Ease)5)));
					if (!((TweenAwaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CForceScrollToLatest_003Ed__26>(ref val, ref this);
						return;
					}
				}
				else
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(TweenAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TweenAwaiter)(ref val)).GetResult();
				jineView._scrollRect.verticalNormalizedPosition = 0f;
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
	private struct _003CScrollToLatest_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public JineView _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			JineView jineView = _003C_003E4__this;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_007b;
				}
				if (num == 1)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0113;
				}
				UniTask val2;
				if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Completed)
				{
					val2 = jineView.ForceScrollToLatest();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CScrollToLatest_003Ed__25>(ref val, ref this);
						return;
					}
					goto IL_007b;
				}
				if (!(jineView._scrollRect.verticalNormalizedPosition > 0.15f) || SingletonMonoBehaviour<JineManager>.Instance.history.Count <= 20)
				{
					val2 = jineView.ForceScrollToLatest();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CScrollToLatest_003Ed__25>(ref val, ref this);
						return;
					}
					goto IL_0113;
				}
				((Component)jineView.ToBottom).gameObject.SetActive(true);
				goto end_IL_000e;
				IL_0113:
				((Awaiter)(ref val)).GetResult();
				goto end_IL_000e;
				IL_007b:
				((Awaiter)(ref val)).GetResult();
				end_IL_000e:;
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
	private struct _003CmakeJine_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public JineData Ids;

		public JineView _003C_003E4__this;

		public bool isNew;

		private JineDrawable _003CjineDrawable_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			JineView jineView = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					_003CjineDrawable_003E5__2 = JineDataConverter.convertJineDataToDrawable(Ids, jineView.isAmeHead);
					switch (_003CjineDrawable_003E5__2.JineUserType)
					{
					case JineUserType.ame:
						break;
					case JineUserType.pi:
						goto IL_00e8;
					case JineUserType.separator:
						Object.Instantiate<JineCell>(jineView.Separator, (Transform)(object)jineView._jineWaku).setDay(_003CjineDrawable_003E5__2.Day);
						jineView.isAmeHead = true;
						goto end_IL_000f;
					case JineUserType.timeSeparator:
						Object.Instantiate<JineCell>(jineView.TimeSeparator, (Transform)(object)jineView._jineWaku).setDayPart(_003CjineDrawable_003E5__2.Day);
						jineView.isAmeHead = true;
						goto end_IL_000f;
					case JineUserType.eventSeparator:
						goto IL_01d8;
					default:
						goto end_IL_000f;
					}
					val2 = Object.Instantiate<JineCell>(jineView.AmeJine, (Transform)(object)jineView._jineWaku).setData(_003CjineDrawable_003E5__2);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CmakeJine_003Ed__23>(ref val, ref this);
						return;
					}
					goto IL_00d5;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00d5;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_016b;
				case 2:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_024b;
					}
					IL_01d8:
					val2 = Object.Instantiate<JineCell>(jineView.TimeSeparator, (Transform)(object)jineView._jineWaku).setData(_003CjineDrawable_003E5__2);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CmakeJine_003Ed__23>(ref val, ref this);
						return;
					}
					goto IL_024b;
					IL_00d5:
					((Awaiter)(ref val)).GetResult();
					jineView.isAmeHead = false;
					break;
					IL_024b:
					((Awaiter)(ref val)).GetResult();
					jineView.isAmeHead = true;
					break;
					IL_00e8:
					val2 = Object.Instantiate<JineCell>(jineView.PiJine, (Transform)(object)jineView._jineWaku).setData(kidokMilliSecond: (!isNew) ? 1 : 800, nakami: _003CjineDrawable_003E5__2);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CmakeJine_003Ed__23>(ref val, ref this);
						return;
					}
					goto IL_016b;
					IL_016b:
					((Awaiter)(ref val)).GetResult();
					jineView.isAmeHead = true;
					break;
					end_IL_000f:
					break;
				}
				if (Ids.id != JineType.Event_LongLINE001 && Ids.id != JineType.Event_LongLINE002 && Ids.id != JineType.Event_LongLINE003 && Ids.id != JineType.Event_LongLINE004 && Ids.id != JineType.Event_LongLINE005)
				{
					if (_003CjineDrawable_003E5__2.JineUserType == JineUserType.pi)
					{
						jineView.ForceScrollToLatest();
					}
					else
					{
						jineView.ScrollToLatest();
					}
				}
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003CjineDrawable_003E5__2 = default(JineDrawable);
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CjineDrawable_003E5__2 = default(JineDrawable);
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

	private EventManager _event;

	[SerializeField]
	private GameObject _blink;

	[SerializeField]
	private Button ToBottom;

	[SerializeField]
	private JineCell AmeJine;

	[SerializeField]
	private JineCell PiJine;

	[SerializeField]
	private JineCell Separator;

	[SerializeField]
	private JineCell TimeSeparator;

	[SerializeField]
	private RectTransform _jineWaku;

	[SerializeField]
	private ScrollRect _scrollRect;

	[SerializeField]
	private GameObject _padding;

	[SerializeField]
	private CanvasGroup _piHenji;

	[SerializeField]
	private GameObject _piStamp;

	[SerializeField]
	private GameObject _piOptions;

	[SerializeField]
	private GameObject _piOptionContent;

	[SerializeField]
	private GameObject _piFreeform;

	[SerializeField]
	private TMP_InputField _inputField;

	[SerializeField]
	private Button _submit;

	[SerializeField]
	private bool isAmeHead = true;

	private List<GameObject> _selectableObjects = new List<GameObject>();

	public IReadOnlyList<GameObject> SelectableObjects => _selectableObjects;

	[AsyncStateMachine(typeof(_003CAwake_003Ed__21))]
	public UniTask Awake()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CAwake_003Ed__21 _003CAwake_003Ed__22 = default(_003CAwake_003Ed__21);
		_003CAwake_003Ed__22._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CAwake_003Ed__22._003C_003E4__this = this;
		_003CAwake_003Ed__22._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CAwake_003Ed__22._003C_003Et__builder)).Start<_003CAwake_003Ed__21>(ref _003CAwake_003Ed__22);
		return ((AsyncUniTaskMethodBuilder)(ref _003CAwake_003Ed__22._003C_003Et__builder)).Task;
	}

	private void SwitchJineStatus(JineManager.WaitStatusType value)
	{
		_selectableObjects.Clear();
		switch (value)
		{
		case JineManager.WaitStatusType.Stamp:
			showStamp();
			_selectableObjects.AddRange(_piStamp.GetComponentsInChildren<JineStampView>().First().SelectableObjects);
			break;
		case JineManager.WaitStatusType.Option:
		{
			showOptions();
			if (_piOptionContent.transform.childCount == 0)
			{
				foreach (JineData option in SingletonMonoBehaviour<JineManager>.Instance.options)
				{
					AddOptions(option);
				}
			}
			JineCell[] componentsInChildren = _piOptionContent.GetComponentsInChildren<JineCell>();
			foreach (JineCell jineCell in componentsInChildren)
			{
				_selectableObjects.Add(((Component)jineCell).gameObject);
			}
			break;
		}
		case JineManager.WaitStatusType.FreeForm:
			showMessage();
			break;
		case JineManager.WaitStatusType.ChooseAction:
			showStamp();
			_selectableObjects.AddRange(_piStamp.GetComponentsInChildren<JineStampView>().First().SelectableObjects);
			break;
		default:
			hideReactions();
			break;
		}
	}

	[AsyncStateMachine(typeof(_003CmakeJine_003Ed__23))]
	public UniTask makeJine(JineData Ids, int page, bool isNew = true)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CmakeJine_003Ed__23 _003CmakeJine_003Ed__24 = default(_003CmakeJine_003Ed__23);
		_003CmakeJine_003Ed__24._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CmakeJine_003Ed__24._003C_003E4__this = this;
		_003CmakeJine_003Ed__24.Ids = Ids;
		_003CmakeJine_003Ed__24.isNew = isNew;
		_003CmakeJine_003Ed__24._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CmakeJine_003Ed__24._003C_003Et__builder)).Start<_003CmakeJine_003Ed__23>(ref _003CmakeJine_003Ed__24);
		return ((AsyncUniTaskMethodBuilder)(ref _003CmakeJine_003Ed__24._003C_003Et__builder)).Task;
	}

	public void LoadJine(int startFromNewest, int endFromNewest)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		int count = SingletonMonoBehaviour<JineManager>.Instance.history.Count;
		if (startFromNewest >= count || startFromNewest > endFromNewest)
		{
			return;
		}
		foreach (JineData item in SingletonMonoBehaviour<JineManager>.Instance.GetHistoryRange(startFromNewest, endFromNewest))
		{
			JineDrawable nakami = JineDataConverter.convertJineDataToDrawable(item);
			switch (nakami.JineUserType)
			{
			case JineUserType.ame:
				Object.Instantiate<JineCell>(AmeJine, (Transform)(object)_jineWaku).setData(nakami);
				break;
			case JineUserType.pi:
				Object.Instantiate<JineCell>(PiJine, (Transform)(object)_jineWaku).setData(nakami, 0);
				break;
			}
		}
	}

	[AsyncStateMachine(typeof(_003CScrollToLatest_003Ed__25))]
	public UniTask ScrollToLatest()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CScrollToLatest_003Ed__25 _003CScrollToLatest_003Ed__26 = default(_003CScrollToLatest_003Ed__25);
		_003CScrollToLatest_003Ed__26._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CScrollToLatest_003Ed__26._003C_003E4__this = this;
		_003CScrollToLatest_003Ed__26._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CScrollToLatest_003Ed__26._003C_003Et__builder)).Start<_003CScrollToLatest_003Ed__25>(ref _003CScrollToLatest_003Ed__26);
		return ((AsyncUniTaskMethodBuilder)(ref _003CScrollToLatest_003Ed__26._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CForceScrollToLatest_003Ed__26))]
	public UniTask ForceScrollToLatest()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CForceScrollToLatest_003Ed__26 _003CForceScrollToLatest_003Ed__27 = default(_003CForceScrollToLatest_003Ed__26);
		_003CForceScrollToLatest_003Ed__27._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CForceScrollToLatest_003Ed__27._003C_003E4__this = this;
		_003CForceScrollToLatest_003Ed__27._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CForceScrollToLatest_003Ed__27._003C_003Et__builder)).Start<_003CForceScrollToLatest_003Ed__26>(ref _003CForceScrollToLatest_003Ed__27);
		return ((AsyncUniTaskMethodBuilder)(ref _003CForceScrollToLatest_003Ed__27._003C_003Et__builder)).Task;
	}

	public void showStamp()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		clearOptions();
		showPihenji();
		_piStamp.SetActive(true);
		_piOptions.SetActive(false);
		_piFreeform.SetActive(false);
		ScrollToLatest();
	}

	public void showOptions()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		showPihenji();
		_piStamp.SetActive(false);
		_piOptions.SetActive(true);
		_piFreeform.SetActive(false);
		ScrollToLatest();
	}

	public void AddOptions(JineType opt)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		JineData OptData = new JineData(opt, JineUserType.pi);
		JineDrawable nakami = JineDataConverter.convertJineDataToDrawable(OptData);
		JineCell jineCell = Object.Instantiate<JineCell>(PiJine, _piOptionContent.transform);
		jineCell.setData(nakami, -1);
		TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(TweenSettingsExtensions.SetLoops<TweenerCore<Color, Color, ColorOptions>>(DOTweenModuleUI.DOColor(((Component)((Component)jineCell).gameObject.transform.Find("Balloon")).gameObject.GetComponent<Image>(), new Color(0.8f, 1f, 0f), 1.2f), -1, (LoopType)1));
		TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(TweenSettingsExtensions.SetLoops<TweenerCore<Color, Color, ColorOptions>>(DOTweenModuleUI.DOColor(((Component)((Component)jineCell).gameObject.transform.Find("Balloon").Find("Tail")).gameObject.GetComponent<Image>(), new Color(0.8f, 1f, 0f), 1.2f), -1, (LoopType)1));
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(((Component)((Component)jineCell).transform).GetComponentInChildren<Button>()), (Action<Unit>)delegate
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(OptData);
			clearOptions();
			hideReactions();
			SingletonMonoBehaviour<JineManager>.Instance.EndOption();
		}), (Component)(object)jineCell);
	}

	public void AddOptions(JineData OptData)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		JineDrawable nakami = JineDataConverter.convertJineDataToDrawable(OptData);
		JineCell jineCell = Object.Instantiate<JineCell>(PiJine, _piOptionContent.transform);
		jineCell.setData(nakami, -1);
		TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(TweenSettingsExtensions.SetLoops<TweenerCore<Color, Color, ColorOptions>>(DOTweenModuleUI.DOColor(((Component)((Component)jineCell).gameObject.transform.Find("Balloon")).gameObject.GetComponent<Image>(), new Color(0.8f, 1f, 0f), 1.2f), -1, (LoopType)1));
		TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(TweenSettingsExtensions.SetLoops<TweenerCore<Color, Color, ColorOptions>>(DOTweenModuleUI.DOColor(((Component)((Component)jineCell).gameObject.transform.Find("Balloon").Find("Tail")).gameObject.GetComponent<Image>(), new Color(0.8f, 1f, 0f), 1.2f), -1, (LoopType)1));
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(((Component)((Component)jineCell).transform).GetComponentInChildren<Button>()), (Action<Unit>)delegate
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(OptData);
			clearOptions();
			hideReactions();
			SingletonMonoBehaviour<JineManager>.Instance.EndOption();
		}), (Component)(object)jineCell);
	}

	private void clearOptions()
	{
		for (int i = 0; i < _piOptionContent.transform.childCount; i++)
		{
			Object.Destroy((Object)(object)((Component)_piOptionContent.transform.GetChild(i)).gameObject);
		}
	}

	public void showMessage()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		_piStamp.SetActive(false);
		showPihenji();
		clearOptions();
		_piFreeform.SetActive(true);
		ScrollToLatest();
	}

	public void sendMessage(string msg)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		if (!(msg == ""))
		{
			_inputField.text = string.Empty;
			hidePihenji();
			_piFreeform.SetActive(false);
			SingletonMonoBehaviour<JineManager>.Instance.EndMessage(msg);
			ScrollToLatest();
		}
	}

	public void hideReactions()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		hidePihenji();
		clearOptions();
		_piStamp.SetActive(false);
		_piOptions.SetActive(false);
		_piFreeform.SetActive(false);
		ScrollToLatest();
	}

	private void hidePihenji()
	{
		TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(_piHenji, 0f, 0.4f), (Ease)22));
	}

	private void showPihenji()
	{
		TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(_piHenji, 1f, 0.4f), (Ease)22));
	}
}
