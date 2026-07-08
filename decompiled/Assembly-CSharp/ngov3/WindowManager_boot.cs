using UnityEngine;

namespace ngov3;

public class WindowManager_boot : WindowManager
{
	[SerializeField]
	private GameObject controlPanel;

	[SerializeField]
	private GameObject Hint;

	private new void Start()
	{
		Hint.SetActive(false);
		controlPanel.SetActive(false);
	}

	public Window NewWindow(AppType appType)
	{
		switch (appType)
		{
		case AppType.ControlPanel:
			controlPanel.SetActive(true);
			break;
		default:
			NewWindow(appType, true);
			break;
		case AppType.MyPicture:
			break;
		}
		return null;
	}

	public void Close(Window w)
	{
		switch (w.appType)
		{
		case AppType.ControlPanel:
			controlPanel.SetActive(false);
			break;
		default:
			Close((IWindow)w);
			break;
		case AppType.MyPicture:
			break;
		}
	}
}
