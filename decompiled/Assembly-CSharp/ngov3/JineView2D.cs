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

public class JineView2D : MonoBehaviour, IApp2D, IScrollable2D, IClickable, IStorable
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CAwake_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public JineView2D _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			JineView2D CS_0024_003C_003E8__locals16 = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					List<JineData> list = new List<JineData>(SingletonMonoBehaviour<JineManager>.Instance.GetNewest());
					list.Reverse();
					List<JineData>.Enumerator enumerator = list.GetEnumerator();
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
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CAwake_003Ed__30>(ref val2, ref this);
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
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(CS_0024_003C_003E8__locals16.ToBottom.OnClickAsObservable(), (Action<Unit>)async delegate
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
	private struct _003CForceScrollToLatest_003Ed__37 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public JineView2D _003C_003E4__this;

		private TweenAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			JineView2D CS_0024_003C_003E8__locals3 = _003C_003E4__this;
			try
			{
				TweenAwaiter val;
				if (num != 0)
				{
					((Component)CS_0024_003C_003E8__locals3.ToBottom).gameObject.SetActive(false);
					ScrollRect scrollRect = CS_0024_003C_003E8__locals3._scrollRect;
					val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)((scrollRect != null) ? TweenExtensions.Play<Tweener>(TweenSettingsExtensions.OnComplete<Tweener>(TweenSettingsExtensions.SetEase<Tweener>(DOTweenModuleUI.DOVerticalNormalizedPos(scrollRect, 0f, 0.15f, true), (Ease)5), (TweenCallback)delegate
					{
						CS_0024_003C_003E8__locals3._scrollRect.verticalNormalizedPosition = 0f;
					})) : null));
					if (!((TweenAwaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CForceScrollToLatest_003Ed__37>(ref val, ref this);
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
	private struct _003CScrollToLatest_003Ed__36 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public JineView2D _003C_003E4__this;

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
			JineView2D jineView2D = _003C_003E4__this;
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
					val2 = jineView2D.ForceScrollToLatest();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CScrollToLatest_003Ed__36>(ref val, ref this);
						return;
					}
					goto IL_007b;
				}
				if (!(jineView2D._scrollRect.verticalNormalizedPosition > 0.15f) || SingletonMonoBehaviour<JineManager>.Instance.history.Count <= 20)
				{
					val2 = jineView2D.ForceScrollToLatest();
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CScrollToLatest_003Ed__36>(ref val, ref this);
						return;
					}
					goto IL_0113;
				}
				((Component)jineView2D.ToBottom).gameObject.SetActive(true);
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
	private struct _003CmakeJine_003Ed__34 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public JineData Ids;

		public JineView2D _003C_003E4__this;

		public bool isNew;

		private void MoveNext()
		{
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			JineView2D jineView2D = _003C_003E4__this;
			try
			{
				JineDrawable nakami = JineDataConverter.convertJineDataToDrawable(Ids, jineView2D.isAmeHead);
				Debug.Log((object)$"<color=green>{Ids.id}:{nakami.BodyJp}</color>");
				JineCell2D jineCell2D = null;
				switch (nakami.JineUserType)
				{
				case JineUserType.ame:
					jineCell2D = Object.Instantiate<JineCell2D>(jineView2D.AmeJine, (Transform)(object)jineView2D._jineWaku);
					jineCell2D.setData(nakami);
					jineView2D.isAmeHead = false;
					break;
				case JineUserType.pi:
				{
					jineCell2D = Object.Instantiate<JineCell2D>(jineView2D.PiJine, (Transform)(object)jineView2D._jineWaku);
					int kidokMilliSecond = ((!isNew) ? 1 : 800);
					jineCell2D.setData(nakami, kidokMilliSecond);
					jineView2D.isAmeHead = true;
					break;
				}
				case JineUserType.separator:
					jineCell2D = Object.Instantiate<JineCell2D>(jineView2D.Separator, (Transform)(object)jineView2D._jineWaku);
					jineCell2D.setDay(nakami.Day);
					jineView2D.isAmeHead = true;
					break;
				case JineUserType.timeSeparator:
					jineCell2D = Object.Instantiate<JineCell2D>(jineView2D.TimeSeparator, (Transform)(object)jineView2D._jineWaku);
					jineCell2D.setDayPart(nakami.Day);
					jineView2D.isAmeHead = true;
					break;
				case JineUserType.eventSeparator:
					jineCell2D = Object.Instantiate<JineCell2D>(jineView2D.TimeSeparator, (Transform)(object)jineView2D._jineWaku);
					jineCell2D.setData(nakami);
					jineView2D.isAmeHead = true;
					break;
				}
				jineCell2D.SetUpMask(jineView2D.viewPortRect);
				jineView2D.contentsVerticalGridLayout.AddLayoutObject(jineCell2D);
				jineView2D._jineCells.Add(jineCell2D);
				if (Ids.id != JineType.Event_LongLINE001 && Ids.id != JineType.Event_LongLINE002 && Ids.id != JineType.Event_LongLINE003 && Ids.id != JineType.Event_LongLINE004 && Ids.id != JineType.Event_LongLINE005)
				{
					if (nakami.JineUserType == JineUserType.pi)
					{
						jineView2D.ForceScrollToLatest();
					}
					else
					{
						jineView2D.ScrollToLatest();
					}
				}
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

	[SerializeField]
	private Button2D ToBottom;

	[SerializeField]
	private JineCell2D AmeJine;

	[SerializeField]
	private JineCell2D PiJine;

	[SerializeField]
	private JineCell2D PiJineWithButton;

	[SerializeField]
	private JineCell2D Separator;

	[SerializeField]
	private JineCell2D TimeSeparator;

	[SerializeField]
	private RectTransform _jineWaku;

	[SerializeField]
	private ScrollRect _scrollRect;

	[SerializeField]
	private Fader2D _piHenji;

	[SerializeField]
	private GameObject _piStamp;

	[SerializeField]
	private GameObject _piOptions;

	[SerializeField]
	private GameObject _piOptionContent;

	[SerializeField]
	private Canvas _piFreeform;

	[SerializeField]
	private TMP_InputField _inputField;

	[SerializeField]
	private Button _submit;

	[SerializeField]
	private bool isAmeHead = true;

	[SerializeField]
	private VerticalGridLayout2D contentsVerticalGridLayout;

	[SerializeField]
	private VerticalLayoutGroup optionsVerticalLayoutGroup;

	private List<JineCell2D> _jineCells = new List<JineCell2D>();

	private List<GameObject> _selectableObjects = new List<GameObject>();

	[SerializeField]
	private RewiredScrollReceiver rewiredScrollReceiver;

	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private RectTransform viewPortRect;

	public IReadOnlyList<GameObject> SelectableObjects => _selectableObjects;

	public RewiredScrollReceiver RewiredScrollReceiver => rewiredScrollReceiver;

	public ScrollRect ScrollRect => scrollRect;

	public void SetSortOrder(int order)
	{
		_piFreeform.sortingOrder = order;
	}

	[AsyncStateMachine(typeof(_003CAwake_003Ed__30))]
	public UniTask Awake()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CAwake_003Ed__30 _003CAwake_003Ed__31 = default(_003CAwake_003Ed__30);
		_003CAwake_003Ed__31._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CAwake_003Ed__31._003C_003E4__this = this;
		_003CAwake_003Ed__31._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CAwake_003Ed__31._003C_003Et__builder)).Start<_003CAwake_003Ed__30>(ref _003CAwake_003Ed__31);
		return ((AsyncUniTaskMethodBuilder)(ref _003CAwake_003Ed__31._003C_003Et__builder)).Task;
	}

	public void OnPicked()
	{
		int num = _jineCells.Count - SingletonMonoBehaviour<JineManager>.Instance.JineCountOnLoad;
		if (num > 0)
		{
			List<JineCell2D> range = _jineCells.GetRange(0, num);
			_jineCells.RemoveRange(0, num);
			foreach (JineCell2D item in range)
			{
				Object.Destroy((Object)(object)((Component)item).gameObject);
			}
		}
		((Component)ToBottom).gameObject.SetActive(false);
	}

	public void OnStored()
	{
		_scrollRect.verticalNormalizedPosition = 0f;
	}

	private void SwitchJineStatus(JineManager.WaitStatusType value)
	{
		switch (value)
		{
		case JineManager.WaitStatusType.Stamp:
			showStamp();
			_selectableObjects.Clear();
			_selectableObjects.AddRange(_piStamp.GetComponentsInChildren<JineStampView2D>().First().SelectableObjects);
			break;
		case JineManager.WaitStatusType.FreeForm:
			showMessage();
			break;
		case JineManager.WaitStatusType.ChooseAction:
			showStamp();
			_selectableObjects.Clear();
			_selectableObjects.AddRange(_piStamp.GetComponentsInChildren<JineStampView2D>().First().SelectableObjects);
			break;
		default:
			hideReactions();
			break;
		case JineManager.WaitStatusType.Option:
			break;
		}
	}

	[AsyncStateMachine(typeof(_003CmakeJine_003Ed__34))]
	public UniTask makeJine(JineData Ids, int page, bool isNew = true)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CmakeJine_003Ed__34 _003CmakeJine_003Ed__35 = default(_003CmakeJine_003Ed__34);
		_003CmakeJine_003Ed__35._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CmakeJine_003Ed__35._003C_003E4__this = this;
		_003CmakeJine_003Ed__35.Ids = Ids;
		_003CmakeJine_003Ed__35.isNew = isNew;
		_003CmakeJine_003Ed__35._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CmakeJine_003Ed__35._003C_003Et__builder)).Start<_003CmakeJine_003Ed__34>(ref _003CmakeJine_003Ed__35);
		return ((AsyncUniTaskMethodBuilder)(ref _003CmakeJine_003Ed__35._003C_003Et__builder)).Task;
	}

	public void LoadJine(int startFromNewest, int endFromNewest)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
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
			{
				JineCell2D jineCell2D2 = Object.Instantiate<JineCell2D>(AmeJine, (Transform)(object)_jineWaku);
				_jineCells.Add(jineCell2D2);
				contentsVerticalGridLayout.AddLayoutObject(jineCell2D2);
				jineCell2D2.setData(nakami);
				jineCell2D2.SetUpMask(viewPortRect);
				break;
			}
			case JineUserType.pi:
			{
				JineCell2D jineCell2D = Object.Instantiate<JineCell2D>(PiJine, (Transform)(object)_jineWaku);
				_jineCells.Add(jineCell2D);
				contentsVerticalGridLayout.AddLayoutObject(jineCell2D);
				jineCell2D.setData(nakami, 0);
				jineCell2D.SetUpMask(viewPortRect);
				break;
			}
			}
		}
	}

	[AsyncStateMachine(typeof(_003CScrollToLatest_003Ed__36))]
	public UniTask ScrollToLatest()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CScrollToLatest_003Ed__36 _003CScrollToLatest_003Ed__37 = default(_003CScrollToLatest_003Ed__36);
		_003CScrollToLatest_003Ed__37._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CScrollToLatest_003Ed__37._003C_003E4__this = this;
		_003CScrollToLatest_003Ed__37._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CScrollToLatest_003Ed__37._003C_003Et__builder)).Start<_003CScrollToLatest_003Ed__36>(ref _003CScrollToLatest_003Ed__37);
		return ((AsyncUniTaskMethodBuilder)(ref _003CScrollToLatest_003Ed__37._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CForceScrollToLatest_003Ed__37))]
	public UniTask ForceScrollToLatest()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CForceScrollToLatest_003Ed__37 _003CForceScrollToLatest_003Ed__38 = default(_003CForceScrollToLatest_003Ed__37);
		_003CForceScrollToLatest_003Ed__38._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CForceScrollToLatest_003Ed__38._003C_003E4__this = this;
		_003CForceScrollToLatest_003Ed__38._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CForceScrollToLatest_003Ed__38._003C_003Et__builder)).Start<_003CForceScrollToLatest_003Ed__37>(ref _003CForceScrollToLatest_003Ed__38);
		return ((AsyncUniTaskMethodBuilder)(ref _003CForceScrollToLatest_003Ed__38._003C_003Et__builder)).Task;
	}

	public void showStamp()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		clearOptions();
		showPihenji();
		_piStamp.SetActive(true);
		_piOptions.SetActive(false);
		((Component)_piFreeform).gameObject.SetActive(false);
		ScrollToLatest();
	}

	public void showOptions()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		showPihenji();
		_piStamp.SetActive(false);
		_piOptions.SetActive(true);
		((Component)_piFreeform).gameObject.SetActive(false);
		ScrollToLatest();
	}

	public async void AddOptions(JineType opt)
	{
		JineData OptData = new JineData(opt, JineUserType.pi);
		JineDrawable nakami = JineDataConverter.convertJineDataToDrawable(OptData);
		JineCell2D jineCell2D = Object.Instantiate<JineCell2D>(PiJineWithButton, _piOptionContent.transform);
		_selectableObjects.Add(((Component)jineCell2D.BalloonRend).gameObject);
		jineCell2D.setData(nakami, -1);
		TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(TweenSettingsExtensions.SetLoops<TweenerCore<Color, Color, ColorOptions>>(DOTweenModuleSprite.DOColor(((Component)((Component)jineCell2D).gameObject.transform.Find("Balloon")).gameObject.GetComponent<SpriteRenderer>(), new Color(0.8f, 1f, 0f), 1.2f), -1, (LoopType)1));
		TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(TweenSettingsExtensions.SetLoops<TweenerCore<Color, Color, ColorOptions>>(DOTweenModuleSprite.DOColor(((Component)((Component)jineCell2D).gameObject.transform.Find("Balloon").Find("Tail")).gameObject.GetComponent<SpriteRenderer>(), new Color(0.8f, 1f, 0f), 1.2f), -1, (LoopType)1));
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(((Component)((Component)jineCell2D).transform).GetComponentInChildren<Button>()), (Action<Unit>)delegate
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(OptData);
			clearOptions();
			hideReactions();
			SingletonMonoBehaviour<JineManager>.Instance.EndOption();
		}), (Component)(object)jineCell2D);
	}

	public async void AddOptions(JineData OptData)
	{
		if (_piOptionContent.transform.childCount == 0)
		{
			_selectableObjects.Clear();
		}
		JineDrawable nakami = JineDataConverter.convertJineDataToDrawable(OptData);
		JineCell2D jineCell2D = Object.Instantiate<JineCell2D>(PiJineWithButton, _piOptionContent.transform);
		_selectableObjects.Add(((Component)jineCell2D.BalloonRend).gameObject);
		jineCell2D.setData(nakami, -1);
		TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(TweenSettingsExtensions.SetLoops<TweenerCore<Color, Color, ColorOptions>>(DOTweenModuleSprite.DOColor(jineCell2D.BalloonRend, new Color(0.8f, 1f, 0f), 1.2f), -1, (LoopType)1));
		TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(TweenSettingsExtensions.SetLoops<TweenerCore<Color, Color, ColorOptions>>(DOTweenModuleSprite.DOColor(jineCell2D.TailRend, new Color(0.8f, 1f, 0f), 1.2f), -1, (LoopType)1));
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(((Component)((Component)jineCell2D).transform).GetComponentInChildren<Button>()), (Action<Unit>)delegate
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			SingletonMonoBehaviour<JineManager>.Instance.AddJineHistory(OptData);
			clearOptions();
			hideReactions();
			SingletonMonoBehaviour<JineManager>.Instance.EndOption();
		}), (Component)(object)jineCell2D);
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
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		_piStamp.SetActive(false);
		showPihenji();
		clearOptions();
		((Component)_piFreeform).gameObject.SetActive(true);
		SetSortOrder(40);
		ScrollToLatest();
	}

	public void sendMessage(string msg)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (!(msg == ""))
		{
			_inputField.text = string.Empty;
			hidePihenji();
			((Component)_piFreeform).gameObject.SetActive(false);
			SingletonMonoBehaviour<JineManager>.Instance.EndMessage(msg);
			ScrollToLatest();
		}
	}

	public void hideReactions()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		hidePihenji();
		clearOptions();
		_piStamp.SetActive(false);
		_piOptions.SetActive(false);
		((Component)_piFreeform).gameObject.SetActive(false);
		ScrollToLatest();
		_selectableObjects.Clear();
	}

	private void hidePihenji()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		UniTaskExtensions.Forget(_piHenji.DOFade(0.4f, 0f, (Ease)22, UniTaskCancellationExtensions.GetCancellationTokenOnDestroy((MonoBehaviour)(object)this)));
	}

	private void showPihenji()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		UniTaskExtensions.Forget(_piHenji.DOFade(0.4f, 0.5f, (Ease)22, UniTaskCancellationExtensions.GetCancellationTokenOnDestroy((MonoBehaviour)(object)this)));
	}

	public void Click()
	{
	}
}
