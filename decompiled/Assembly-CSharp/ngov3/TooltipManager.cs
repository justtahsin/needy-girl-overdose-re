using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using UnityEngine;

namespace ngov3;

public class TooltipManager : SingletonMonoBehaviour<TooltipManager>
{
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
		Hide(onlyHomingTooltip: true);
		_tooltipCancelSource = new CancellationTokenSource();
		try
		{
			if (_tooltip2DInstance == null)
			{
				_tooltip2DInstance = UnityEngine.Object.Instantiate(_tooltip2DPrefab, _sprite2DParent);
				Vector3 vector = new Vector3(-3000f, 0f, 0f);
				Transform transform = _tooltip2DInstance.transform;
				transform.position = new Vector3(vector.x, vector.y, transform.position.z);
			}
			else
			{
				_tooltip2DInstance.gameObject.SetActive(value: true);
			}
			_tooltip2DInstance.SetData(type, pos, isHoming, text);
			await UniTask.Delay(100, ignoreTimeScale: false, PlayerLoopTiming.Update, _tooltipCancelSource.Token);
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
		Hide(onlyHomingTooltip: true);
		_tooltipCancelSource = new CancellationTokenSource();
		try
		{
			await UniTask.Delay(150, ignoreTimeScale: false, PlayerLoopTiming.Update, _tooltipCancelSource.Token);
			if (_pienTorialTooltip2DInstance == null)
			{
				_pienTorialTooltip2DInstance = UnityEngine.Object.Instantiate(_pienTorialTooltip2DPrefab, _sprite2DParent);
				Vector3 vector = new Vector3(-3000f, 0f, 0f);
				Transform transform = _pienTorialTooltip2DInstance.transform;
				transform.position = new Vector3(vector.x, vector.y, transform.position.z);
			}
			else
			{
				_pienTorialTooltip2DInstance.gameObject.SetActive(value: true);
			}
			_pienTorialTooltip2DInstance.SetData(type, pos, isHoming, text);
			await UniTask.Delay(100, ignoreTimeScale: false, PlayerLoopTiming.Update, _tooltipCancelSource.Token);
			AudioManager.Instance.PlaySeByType(SoundType.SE_pop_tutorial);
			ActiveTooltip = _pienTorialTooltip2DInstance;
		}
		catch (OperationCanceledException)
		{
		}
	}

	public async UniTask ShowAction(ActionType a, CmdMaster.Param c)
	{
		if (_statusTooltip2DInstance == null)
		{
			_statusTooltip2DInstance = UnityEngine.Object.Instantiate(_statusTooltip2DPrefab, _sprite2DParent);
		}
		else
		{
			_statusTooltip2DInstance.gameObject.SetActive(value: true);
		}
		StatusTooltip2D statusTooltip2DInstance = _statusTooltip2DInstance;
		statusTooltip2DInstance.SlidePosition();
		LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		ActMaster.Param a2 = NgoEx.ActFromType(a);
		statusTooltip2DInstance.SetActionName(a2, value);
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

	public void Hide(bool onlyHomingTooltip = false)
	{
		if (!(_sprite2DParent == null) && _sprite2DParent.childCount != 0)
		{
			CancelShowing();
			Vector3 vector = new Vector3(-3000f, 0f, 0f);
			if (_pienTorialTooltip2DInstance != null)
			{
				Vector3 position = _pienTorialTooltip2DInstance.transform.position;
				position.x = vector.x;
				position.y = vector.y;
				_pienTorialTooltip2DInstance.transform.position = position;
			}
			if (_tooltip2DInstance != null)
			{
				Vector3 position2 = _tooltip2DInstance.transform.position;
				position2.x = vector.x;
				position2.y = vector.y;
				_tooltip2DInstance.transform.position = position2;
			}
			if (_statusTooltip2DInstance != null && !onlyHomingTooltip)
			{
				Vector3 position3 = _statusTooltip2DInstance.transform.position;
				position3.x = vector.x;
				position3.y = vector.y;
				_statusTooltip2DInstance.transform.position = position3;
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
