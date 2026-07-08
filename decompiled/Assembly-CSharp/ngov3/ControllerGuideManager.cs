using UnityEngine;

namespace ngov3;

public class ControllerGuideManager : SingletonMonoBehaviour<ControllerGuideManager>
{
	[SerializeField]
	private ControllerGuide _guideObject;

	[SerializeField]
	private ControllerGuide _playStationGuideObject;

	[SerializeField]
	private ControllerGuide.TabType _tabType;

	[SerializeField]
	private bool _isReady;

	public bool IsReady
	{
		get
		{
			return _isReady;
		}
		set
		{
			_isReady = value;
			if (!value)
			{
				CloseGuide();
			}
		}
	}

	public ControllerGuide Guide => _guideObject;

	public void ShowGuide()
	{
		if (_isReady)
		{
			Guide.ChangeState(_tabType);
		}
	}

	public void ForceShowGuide()
	{
		Guide.ChangeState(_tabType);
	}

	public void ShowLiveGuide()
	{
		if (_isReady)
		{
			SingletonMonoBehaviour<ShortcutInputManager>.Instance.ChangeControllerMode(ShortcutInputManager.ControllerMode.Desktop);
			Guide.ChangeState(ControllerGuide.TabType.Live);
		}
	}

	public void CloseGuide()
	{
		Guide.CloseGuideImmediate();
	}

	public void SetActiveLiveApp(Live activeLive)
	{
		Guide.ActiveLiveApp = activeLive;
	}

	public void RemoveActiveLiveApp()
	{
		Guide.ActiveLiveApp = null;
	}
}
