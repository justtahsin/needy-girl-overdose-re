using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using UnityEngine;

namespace ngov3;

public class TooltipManager : SingletonMonoBehaviour<TooltipManager>
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CShowAction_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public TooltipManager _003C_003E4__this;

		public ActionType a;

		public CmdMaster.Param c;

		private void MoveNext()
		{
			TooltipManager tooltipManager = _003C_003E4__this;
			try
			{
				if ((Object)(object)tooltipManager._statusTooltip2DInstance == (Object)null)
				{
					tooltipManager._statusTooltip2DInstance = Object.Instantiate<StatusTooltip2D>(tooltipManager._statusTooltip2DPrefab, tooltipManager._sprite2DParent);
				}
				else
				{
					((Component)tooltipManager._statusTooltip2DInstance).gameObject.SetActive(true);
				}
				StatusTooltip2D statusTooltip2DInstance = tooltipManager._statusTooltip2DInstance;
				statusTooltip2DInstance.SlidePosition();
				LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
				ActMaster.Param param = NgoEx.ActFromType(a);
				statusTooltip2DInstance.SetActionName(param, value);
				statusTooltip2DInstance.SetCommandName(c, value);
				statusTooltip2DInstance.SetCommandDesc(c, value);
				if (c.FollowerDelta != 0)
				{
					statusTooltip2DInstance.SetFollowerDiff(c);
				}
				statusTooltip2DInstance.SetMainStatusDiff(SingletonMonoBehaviour<StatusManager>.Instance.Diffs(c));
				if (c.OkusuriCount > 0 || c.OirokeCount > 0 || c.SNS > 0 || c.GameCount > 0 || c.CinePhillCount > 0 || c.ShabekuriCount > 0 || c.Harumagedo > 0)
				{
					statusTooltip2DInstance.SetBonusLine(visible: true, value);
					statusTooltip2DInstance.SetStatusDiff(SingletonMonoBehaviour<StatusManager>.Instance.Diffs(c));
				}
				else
				{
					statusTooltip2DInstance.SetBonusLine(visible: false, value);
				}
				statusTooltip2DInstance.SetPassingTime(c.PassingTime + SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart), c.PassingTime, SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart));
				AudioManager.Instance.PlaySeByType(SoundType.SE_pop_tooltip);
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
	private Transform _sprite2DParent;

	[SerializeField]
	private Tooltip2D _tooltip2DPrefab;

	[SerializeField]
	private PienTorialTooltip2D _pienTorialTooltip2DPrefab;

	[SerializeField]
	private StatusTooltip2D _statusTooltip2DPrefab;

	public ITooltip ActiveTooltip;

	private Tooltip2D _tooltip2DInstance;

	private PienTorialTooltip2D _pienTorialTooltip2DInstance;

	private StatusTooltip2D _statusTooltip2DInstance;

	private CancellationTokenSource _tooltipCancelSource;

	public void Update()
	{
		if (ActiveTooltip != null)
		{
			ActiveTooltip.SetHomingPos();
		}
	}

	public async void Show(Vector3 pos, TooltipType type, bool isHoming, string text = "")
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		Hide(onlyHomingTooltip: true);
		_tooltipCancelSource = new CancellationTokenSource();
		try
		{
			if ((Object)(object)_tooltip2DInstance == (Object)null)
			{
				_tooltip2DInstance = Object.Instantiate<Tooltip2D>(_tooltip2DPrefab, _sprite2DParent);
				Vector3 val = default(Vector3);
				((Vector3)(ref val))._002Ector(-3000f, 0f, 0f);
				Transform transform = ((Component)_tooltip2DInstance).transform;
				transform.position = new Vector3(val.x, val.y, transform.position.z);
			}
			else
			{
				((Component)_tooltip2DInstance).gameObject.SetActive(true);
			}
			_tooltip2DInstance.SetData(type, pos, isHoming, text);
			await UniTask.Delay(100, false, (PlayerLoopTiming)8, _tooltipCancelSource.Token, false);
			AudioManager.Instance.PlaySeByType(SoundType.SE_pop_tooltip);
			ActiveTooltip = _tooltip2DInstance;
		}
		catch (OperationCanceledException)
		{
		}
	}

	public async void Show(TooltipType type)
	{
		Show(new Vector3(0f, 0f, 0f), type, isHoming: true);
	}

	public async void ShowTutorial(TooltipType type, string text = "")
	{
		ShowTutorial(new Vector3(0f, 0f, 0f), type, isHoming: true, text);
	}

	public async void ShowTutorial(Vector3 pos, TooltipType type, bool isHoming, string text = "")
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		Hide(onlyHomingTooltip: true);
		_tooltipCancelSource = new CancellationTokenSource();
		try
		{
			await UniTask.Delay(150, false, (PlayerLoopTiming)8, _tooltipCancelSource.Token, false);
			if ((Object)(object)_pienTorialTooltip2DInstance == (Object)null)
			{
				_pienTorialTooltip2DInstance = Object.Instantiate<PienTorialTooltip2D>(_pienTorialTooltip2DPrefab, _sprite2DParent);
				Vector3 val = default(Vector3);
				((Vector3)(ref val))._002Ector(-3000f, 0f, 0f);
				Transform transform = ((Component)_pienTorialTooltip2DInstance).transform;
				transform.position = new Vector3(val.x, val.y, transform.position.z);
			}
			else
			{
				((Component)_pienTorialTooltip2DInstance).gameObject.SetActive(true);
			}
			_pienTorialTooltip2DInstance.SetData(type, pos, isHoming, text);
			await UniTask.Delay(100, false, (PlayerLoopTiming)8, _tooltipCancelSource.Token, false);
			AudioManager.Instance.PlaySeByType(SoundType.SE_pop_tutorial);
			ActiveTooltip = _pienTorialTooltip2DInstance;
		}
		catch (OperationCanceledException)
		{
		}
	}

	[AsyncStateMachine(typeof(_003CShowAction_003Ed__14))]
	public UniTask ShowAction(ActionType a, CmdMaster.Param c)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CShowAction_003Ed__14 _003CShowAction_003Ed__15 = default(_003CShowAction_003Ed__14);
		_003CShowAction_003Ed__15._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CShowAction_003Ed__15._003C_003E4__this = this;
		_003CShowAction_003Ed__15.a = a;
		_003CShowAction_003Ed__15.c = c;
		_003CShowAction_003Ed__15._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CShowAction_003Ed__15._003C_003Et__builder)).Start<_003CShowAction_003Ed__14>(ref _003CShowAction_003Ed__15);
		return ((AsyncUniTaskMethodBuilder)(ref _003CShowAction_003Ed__15._003C_003Et__builder)).Task;
	}

	public void Hide(bool onlyHomingTooltip = false)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)_sprite2DParent == (Object)null) && _sprite2DParent.childCount != 0)
		{
			CancelShowing();
			Vector3 val = default(Vector3);
			((Vector3)(ref val))._002Ector(-3000f, 0f, 0f);
			if ((Object)(object)_pienTorialTooltip2DInstance != (Object)null)
			{
				Vector3 position = ((Component)_pienTorialTooltip2DInstance).transform.position;
				position.x = val.x;
				position.y = val.y;
				((Component)_pienTorialTooltip2DInstance).transform.position = position;
			}
			if ((Object)(object)_tooltip2DInstance != (Object)null)
			{
				Vector3 position2 = ((Component)_tooltip2DInstance).transform.position;
				position2.x = val.x;
				position2.y = val.y;
				((Component)_tooltip2DInstance).transform.position = position2;
			}
			if ((Object)(object)_statusTooltip2DInstance != (Object)null && !onlyHomingTooltip)
			{
				Vector3 position3 = ((Component)_statusTooltip2DInstance).transform.position;
				position3.x = val.x;
				position3.y = val.y;
				((Component)_statusTooltip2DInstance).transform.position = position3;
				_statusTooltip2DInstance.OnHide();
			}
			ActiveTooltip = null;
		}
	}

	private void CancelShowing()
	{
		if (_tooltipCancelSource != null)
		{
			_tooltipCancelSource.Cancel();
		}
	}
}
