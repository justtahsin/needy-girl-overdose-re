using UnityEngine;

namespace ngov3;

public class TaskbarManager : SingletonMonoBehaviour<TaskbarManager>
{
	[SerializeField]
	private CanvasGroup _taskbarGroup;

	[SerializeField]
	private StartMenuView _startMenu;

	public CanvasGroup TaskBarGroup => _taskbarGroup;

	public GameObject TaskBarObj => _taskbarGroup.gameObject;

	public void SetTaskbarInteractive(bool interactive)
	{
		if (interactive)
		{
			Interactive();
		}
		else
		{
			DisInteractive();
		}
	}

	private void Interactive()
	{
		_taskbarGroup.interactable = true;
		_taskbarGroup.blocksRaycasts = true;
	}

	private void DisInteractive()
	{
		_taskbarGroup.interactable = false;
		_taskbarGroup.blocksRaycasts = false;
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.LoadData);
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.LoadDialog);
		if (_startMenu.IsShowIng)
		{
			_startMenu.OnHide();
		}
	}
}
